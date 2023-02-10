using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class GameScreen : CanvasView
{
    [SerializeField]private TextMeshProUGUI _livesRemainingText;
    [SerializeField]private TMP_Text _coinsCollectedText;
    // Start is called before the first frame update
    void OnEnable()
    {
        UIManager.Instance.OnLivesUpdated+= UpdateLivesRemainingUI;
        ItemsHandler.OnCoinsUpdated += UpdateCoinsCollected;
    }

    void OnDisable()
    {
        UIManager.Instance.OnLivesUpdated-= UpdateLivesRemainingUI;
        ItemsHandler.OnCoinsUpdated += UpdateCoinsCollected;
    }

    private void UpdateLivesRemainingUI(int obj)
    {
        _livesRemainingText.text = "Lives : "+ obj;
    }

    private void UpdateCoinsCollected(int _totalCoins)
    {
        _coinsCollectedText.text =  "Coins: " + _totalCoins.ToString();
    }

}
