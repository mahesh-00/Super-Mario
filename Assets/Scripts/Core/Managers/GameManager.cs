using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{

    #region Static fields
    private static GameManager _instance;

    #endregion

    #region Properties
    public static GameManager Instance => _instance;
    #endregion

   [SerializeField] public LevelData LevelData;

   [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private GameObject _player;
    private GameObject _currentLevel;
    private bool _isGameStarted = false;
    public bool IsGameStarted
    {
        get { return _isGameStarted; }
        set
        {
            _isGameStarted = value;
            if (value)
            {
                ChangeState(GameState.GamePlayState);
            }
        }

    }
    public Action OnCastleReached;
    public Action<GameState> OnPlayAgain;
    public Action<GameState> OnGameStateChanged;
    public Action<bool> OnLeftWalk;
    public Action<bool> OnRightWalk;
    public Action<bool> OnJump;
    public Action OnPlayerKilled;
    public Action OnPlayerDead;
    public Action OnGameCompleted;
    public Action OnCoinCollected;
    public enum GameState
    {
        StartMenuState,
        GamePlayState,
        GameCompleteState
    }

    private GameState _currentGameState;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);
        Application.targetFrameRate = 300;
      
    }
    void Start()
    {
        ChangeState(GameState.StartMenuState);
        OnCastleReached+= () => ChangeState(GameState.GameCompleteState);
        OnGameCompleted+= () => ChangeState(GameState.GameCompleteState);
    }

    void Disable()
    {
        OnCastleReached-= () => ChangeState(GameState.GameCompleteState);
        OnGameCompleted-= () => ChangeState(GameState.GameCompleteState);
    }

    public void ChangeState(GameState newState)
    {
        _currentGameState = newState;
        switch (newState)
        {
            case GameState.StartMenuState:
                //HandleStartMenuState();
                break;
            case GameState.GamePlayState:
                HandleGameplayState();
                break;
            case GameState.GameCompleteState:
                HandleLevelCompleteState();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleGameplayState()
    {
       _currentLevel = Instantiate(LevelData.LevelPrefabs[0].LevelPrefab);
       _player = Instantiate(LevelData.PlayerPrefab);
       _cinemachineVirtualCamera.Follow = _player.transform;
       _cinemachineVirtualCamera.LookAt =_player.transform;
       _cinemachineVirtualCamera.transform.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = LevelData.LevelPrefabs[0].BoundShape2D;
      
    }
    private void HandleLevelCompleteState()
    {
        Destroy(_player);
        Destroy(_currentLevel);
    }
}
