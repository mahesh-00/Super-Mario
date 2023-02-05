using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
   private PlayerStateMachine _playerStateMachine;

   void Start()
   {
    _playerStateMachine = GetComponent<PlayerStateMachine>();
 
    //GameManager.Instance.OnWalking+= CheckForLeftEdge;
   }

   void Update()
   {

   } 

   
   void OnTriggerEnter2D(Collider2D collision)
   {
       
        if(collision.gameObject.CompareTag(CONSTANTS.GROUND)) 
            _playerStateMachine.IsGrounded = true;
           
        if(collision.gameObject.CompareTag(CONSTANTS.CASTLE))
            GameManager.Instance.OnCastleReached?.Invoke();
        if(collision.gameObject.CompareTag(CONSTANTS.FALLTRIGGER))
            GameManager.Instance.OnPlayerKilled?.Invoke();     
        
   }

    void OnTriggerExit2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag(CONSTANTS.GROUND))
        {
            _playerStateMachine.IsGrounded = false;
           
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.CompareTag(CONSTANTS.ENEMY))
         {
            Vector2 offset = new Vector2(transform.position.x,transform.position.y - 0.64f);
            if(offset.y > collision.transform.position.y) //player has killed enemy
            {
                collision.gameObject.GetComponent<EnemyController>().OnEnemyKilled?.Invoke();
            }
            else
                GameManager.Instance.OnPlayerKilled?.Invoke(); //enemy has killed player
         }
    }
}
