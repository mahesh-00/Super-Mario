using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private bool _isBrickHit = false;
    private Animator _blockAnimator;
    [SerializeField] private bool _hasCoins;
    public enum BrickState
    {
        solid,
        breakable
    }
    public BrickState brickState;

    void Start()
    {
        //_blockAnimator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag(CONSTANTS.PLAYER) && !_isBrickHit)
       {
         if(collision.transform.position.y < transform.position.y)
         {
            OnBrickHit();
            Instantiate(GameManager.Instance.LevelData.Coin,transform.position + new Vector3(0,1.3f,0),Quaternion.identity);
            _isBrickHit = true;
           
         }
         
       }
    }

    private void OnBrickHit()
    {
        switch (brickState)
        {
            case BrickState.solid:
                Debug.Log("solid");
                break;
            case BrickState.breakable:
                Debug.Log("breakable");
                break;
                
        }
    }


}
