using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    private bool _isBlockHit = false;
    private Animator _blockAnimator;

    void Start()
    {
        _blockAnimator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag(CONSTANTS.PLAYER) && !_isBlockHit)
       {
         if(collision.transform.position.y < transform.position.y)
         {
            Instantiate(GameManager.Instance.LevelData.Coin,transform.position + new Vector3(0,1.3f,0),Quaternion.identity);
            _isBlockHit = true;
            _blockAnimator.SetBool("used",true);
         }
         
       }
    }

}
