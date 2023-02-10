using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    private bool _isFalling = false;
    public PlayerDeadState(PlayerStateFactory psf, PlayerStateMachine psm) : base(psf, psm)
    {
        
    }
    public override void EnterState()
    {
      PlayerStateMachine.OnEnterState(PlayerStateMachine.PlayerStates.Dead);
      PlayerStateMachine.transform.localScale = new Vector3(1,0.5f,0);
       
    }
    public override void UpdateState()
    {
      if(!_isFalling)
      {
          PlayerStateMachine.Rb.MovePosition(PlayerStateMachine.Rb.position + new Vector2(0,3) * Time.fixedDeltaTime);
          //Debug.Log("jumping");
      }
        
      if(PlayerStateMachine.Rb.position.y > 2.5f)
      {
         //Debug.Log("jump limit reached");
         PlayerStateMachine.GetComponent<CapsuleCollider2D>().isTrigger = true; 
         _isFalling = true;
      }
    
      CheckSwitchStates();
    }
    public override void ExitState()
    {
       
    }

    public override void InitializeSubStates()
    {
       
    }

    public override void CheckSwitchStates()
    {
        if (PlayerStateMachine.transform.position.y < -5)
           GameManager.Instance.OnGameCompleted?.Invoke();
    }
}
