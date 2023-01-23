using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class UIManager : MonoBehaviour
{

    #region Static fields
    private static UIManager _instance;

    #endregion

    #region Properties
    public static UIManager Instance => _instance;
    #endregion
    #region Editor-Assigned variables
    [SerializeField] private CanvasView _startMenuScreen, _gameScreen, _gameEndScreen;
    #endregion

    public Action<int> OnLivesUpdated;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);

    }

    void Start()
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChangeUI;
        GameManager.Instance.OnPlayAgain+= HandleGameStateChangeUI;
    }

    public void HandleGameStateChangeUI(GameState newState)
    {
        switch (newState)
        {
            case GameState.StartMenuState:
                HandleStartMenuState();
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

    }
    private void ShowRespectiveUIForState(CanvasView currentUIState, CanvasView newUIState)
    {
        currentUIState?.ShowView(false);
        newUIState?.ShowView(true);
    }
    private void HandleLevelCompleteState()
    {
        ShowRespectiveUIForState(_gameScreen, _gameEndScreen);
    }

    private void HandleGameplayState()
    {
        ShowRespectiveUIForState(_startMenuScreen, _gameScreen);
        //Debug.Log("game screen");
    }

    private void HandleStartMenuState()
    {
        ShowRespectiveUIForState(_gameEndScreen, _startMenuScreen);
        //Debug.Log("start menu");
    }
}
