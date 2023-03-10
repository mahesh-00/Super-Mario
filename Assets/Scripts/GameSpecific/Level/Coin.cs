using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool _isCoinCollected = false;

    void Awake()
    {
        _isCoinCollected = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.gameObject.CompareTag(CONSTANTS.PLAYER) && !_isCoinCollected)
        {
            _isCoinCollected = true;
            GameManager.Instance.OnCoinCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
