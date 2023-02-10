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
        //_totalCoins = PlayerPrefs.GetInt("CoinsCollected",0);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnCoinCollected -= UpdateCoinsCount;
    }

    private void UpdateCoinsCount()
    {
        _totalCoins += 1;
        OnCoinsUpdated?.Invoke(_totalCoins);
    }


}
