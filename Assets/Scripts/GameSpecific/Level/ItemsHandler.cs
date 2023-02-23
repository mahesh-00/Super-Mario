using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsHandler : MonoBehaviour
{
    private int _totalCoins;
    public static Action<int> OnCoinsUpdated;
    
    private void Awake()
    {

    }
    private void Start()
    {
        GameManager.Instance.OnCoinCollected += UpdateCoinsCount;
        GameManager.Instance.OnGameCompleted += ResetCoins;
        //_totalCoins = PlayerPrefs.GetInt("CoinsCollected",0);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnCoinCollected -= UpdateCoinsCount;
        GameManager.Instance.OnGameCompleted -= ResetCoins;
    }

    private void UpdateCoinsCount()
    {
        _totalCoins += 1;
        OnCoinsUpdated?.Invoke(_totalCoins);
    }

    private void ResetCoins()
    {
        _totalCoins = 0;
    }


}
