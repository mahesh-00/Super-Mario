using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class GameScreen : CanvasView
{
    [SerializeField]private TMP_Text _coinsCollectedText;
    [SerializeField]private GameObject _settingsScreen;
    // Start is called before the first frame update
    void OnEnable()
    {
        ItemsHandler.OnCoinsUpdated += UpdateCoinsCollected;
    }

    void OnDisable()
    {
        ItemsHandler.OnCoinsUpdated -= UpdateCoinsCollected;
    }

    private void UpdateLivesRemainingUI(int obj)
    {
        //_livesRemainingText.text = "Lives : "+ obj;
    }

    private void UpdateCoinsCollected(int _totalCoins)
    {
        _coinsCollectedText.text =  "COINS: " + _totalCoins.ToString();
    }

    public void UIEVENT_Menu()
    {
        _settingsScreen.SetActive(false);
        GameManager.Instance.OnGameCompleted?.Invoke();
        UIManager.Instance.HandleGameStateChangeUI(GameManager.GameState.StartMenuState);
    }

    public void UIEVENT_Resume()
    {
        _settingsScreen.SetActive(false);
    }

    public void UIEVENT_OpenSettings()
    {
        _settingsScreen.SetActive(true);
    }
}
