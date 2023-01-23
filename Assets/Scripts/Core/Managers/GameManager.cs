using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Static fields
    private static GameManager _instance;

    #endregion

    #region Properties
    public static GameManager Instance => _instance;
    #endregion

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
    public Action OnEnemyCollision;
    public Action<GameState> OnPlayAgain;
    public Action<GameState> OnGameStateChanged;
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
    }

    void Disable()
    {
         OnCastleReached-= () => ChangeState(GameState.GameCompleteState);
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
                //HandleGameplayState();
                break;
            case GameState.GameCompleteState:
                // HandleLevelCompleteState();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }
}
