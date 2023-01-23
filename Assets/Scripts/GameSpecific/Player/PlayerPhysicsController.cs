using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
   private PlayerStateMachine _playerStateMachine;


   void Start()
   {
    _playerStateMachine = GetComponent<PlayerStateMachine>();
   } 
   void OnTriggerEnter2D(Collider2D collision)
   {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _playerStateMachine.IsGrounded = true;
            //Debug.Log("grounded");
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.OnEnemyCollision?.Invoke();
        }
        if(collision.gameObject.CompareTag("Castle"))
        {
            GameManager.Instance.OnCastleReached?.Invoke();
        }
   }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _playerStateMachine.IsGrounded = false;
        }
    }

}
