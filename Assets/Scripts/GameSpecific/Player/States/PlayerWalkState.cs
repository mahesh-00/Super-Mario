using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateFactory psf, PlayerStateMachine psm) : base(psf, psm)
    {
    }

    public override void CheckSwitchStates()
    {
        if (!PlayerStateMachine.IsWalkingLeft && !PlayerStateMachine.IsWalkingRight)
            SwitchStates(Factory.Idle());
        if (PlayerStateMachine.IsJumping && PlayerStateMachine.IsGrounded)
        {
            SwitchStates(Factory.Jump());
        }
    }

    public override void EnterState()
    {
      
    }

    public override void ExitState()
    {
        
    }

    public override void InitializeSubStates()
    {
       
    }

    public override void UpdateState()
    {
       Vector2 walkDirection = PlayerStateMachine.IsWalkingRight?new Vector2(5,0): new Vector2(-5,0);
       PlayerStateMachine.Rb.MovePosition(PlayerStateMachine.Rb.position +  walkDirection * Time.fixedDeltaTime);
       CheckSwitchStates();
       // rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
