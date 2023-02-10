using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private bool _isCoinCollected = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.gameObject.CompareTag(CONSTANTS.PLAYER) && !_isCoinCollected)
        {
            //Debug.Log("COINS COLLECTED ");
            _isCoinCollected = true;
            GameManager.Instance.OnCoinCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
