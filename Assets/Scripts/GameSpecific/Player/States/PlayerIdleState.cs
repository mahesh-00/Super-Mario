using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    Vector3 _currentVelocity;
    public PlayerIdleState(PlayerStateFactory psf, PlayerStateMachine psm) : base(psf, psm)
    {
        
    }

    public override void CheckSwitchStates()
    {
        if (PlayerStateMachine.IsWalkingLeft || PlayerStateMachine.IsWalkingRight)
            SwitchStates(Factory.Walk());
        if (PlayerStateMachine.IsJumping && PlayerStateMachine.IsGrounded)
        {
            SwitchStates(Factory.Jump());
        }
    }

    public override void EnterState()
    {
        //PlayerStateMachine.Rb.velocity = Vector3.SmoothDamp( PlayerStateMachine.Rb.velocity, new Vector3(0f,  PlayerStateMachine.Rb.velocity.y, 0f), ref _currentVelocity, 0.4f * Time.fixedDeltaTime);
        //PlayerStateMachine.Rb.velocity = new Vector2(0,0);   
    }

    public override void ExitState()
    {
        
    }

    public override void InitializeSubStates()
    {
        
    }

    public override void UpdateState()
    {
       CheckSwitchStates();
    }
}
