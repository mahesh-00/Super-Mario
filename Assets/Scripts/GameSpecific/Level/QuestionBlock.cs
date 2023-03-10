using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuestionBlock : MonoBehaviour
{
    private bool _isBlockHit = false;
    private Animator _blockAnimator;
    private Vector3 _originalPos;

    void Start()
    {
        _blockAnimator = GetComponent<Animator>();
        _originalPos = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag(CONSTANTS.PLAYER) && !_isBlockHit)
       {
         if(collision.transform.position.y < transform.position.y)
         {
            GameObject coin =  Instantiate(GameManager.Instance.LevelData.Coin,transform.position ,Quaternion.identity);
            coin.transform.DOMove(coin.transform.position + new Vector3(0,2f,0),0.6f).onComplete += () => Destroy(coin.gameObject);
             GameManager.Instance.OnCoinCollected?.Invoke();
            _isBlockHit = true;
            _blockAnimator.SetBool("used",true);
            transform.DOMove(transform.position + new Vector3(0,0.3f,0),0.15f).onComplete+= () =>
            {
              transform.DOMove(_originalPos,0.15f);
            };

         }
         
       }
    }

}
