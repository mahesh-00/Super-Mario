using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private int _noOfLives = 3;
    //public int NoOfLives => _noOfLives;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnEnemyCollision+=UpdatePlayerLives;
    }

    private void UpdatePlayerLives()
    {
        _noOfLives-=1;
        UIManager.Instance.OnLivesUpdated?.Invoke(_noOfLives);
    }
}
