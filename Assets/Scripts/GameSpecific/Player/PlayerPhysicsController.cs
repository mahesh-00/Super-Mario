using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    [SerializeField] private Transform _groundRayTF;
    private PlayerStateMachine _playerStateMachine;
    [SerializeField]private LayerMask _groundMask;

    void Start()
    {
        _playerStateMachine = GetComponent<PlayerStateMachine>();

        //GameManager.Instance.OnWalking+= CheckForLeftEdge;
    }

    void FixedUpdate()
    {
        RaycastHit2D hitGroundMiddle = Physics2D.Raycast(_groundRayTF.position, Vector2.down,0.2f,_groundMask);
        RaycastHit2D hitGroundLeft = Physics2D.Raycast(_groundRayTF.position - new Vector3(0.5f,0,0), Vector2.down,0.2f,_groundMask);
        RaycastHit2D hitGroundRight = Physics2D.Raycast(_groundRayTF.position + new Vector3(0.5f,0,0), Vector2.down,0.2f,_groundMask);
        Debug.DrawRay(_groundRayTF.position - new Vector3(0.5f,0,0),Vector2.down * hitGroundLeft.distance,Color.red);
        Debug.DrawRay(_groundRayTF.position + new Vector3(0.5f,0,0),Vector2.down * hitGroundRight.distance,Color.red);
        if(hitGroundMiddle.collider !=  null || hitGroundLeft.collider != null || hitGroundRight.collider != null)
            _playerStateMachine.IsGrounded = true;
        else
            _playerStateMachine.IsGrounded = false;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
       
        // if (collision.gameObject.CompareTag(CONSTANTS.GROUND))
        // {
        //      _playerStateMachine.IsGrounded = true;
        //      Debug.Log("grounde");
        // }
           

        if (collision.gameObject.CompareTag(CONSTANTS.CASTLE))
            GameManager.Instance.OnCastleReached?.Invoke();

        if (collision.gameObject.CompareTag(CONSTANTS.FALLTRIGGER) && _playerStateMachine.IsAlive)
            GameManager.Instance.OnPlayerKilled?.Invoke();
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        // if (collision.gameObject.CompareTag(CONSTANTS.GROUND))
        // {
        //     _playerStateMachine.IsGrounded = false;
        //     Debug.Log("not grounded");

        // }
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANTS.ENEMY))
        {
            Vector2 offset = new Vector2(transform.position.x, transform.position.y - 0.64f);
            if (offset.y < collision.transform.position.y && _playerStateMachine.IsAlive)  //enemy has killed player
            {
                GameManager.Instance.OnPlayerKilled?.Invoke();
            }
            else //player has killed enemy

                collision.gameObject.GetComponent<EnemyController>().OnEnemyKilled?.Invoke();
        }
         
      
    }
}
