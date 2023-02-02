using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateFactory psf, PlayerStateMachine psm) : base(psf, psm)
    {
       
    }

    public override void CheckSwitchStates()
    {
       if(PlayerStateMachine.Rb.velocity.y < 0) //Player will move downwards
       {
            SwitchStates(Factory.Fall());
       }

    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        if(PlayerStateMachine.IsGrounded && PlayerStateMachine.AllowtoJump)
        {
            Debug.Log("jumping");
            float walkDirection = PlayerStateMachine.IsWalkingRight?7:PlayerStateMachine.IsWalkingLeft?-7:0;
            PlayerStateMachine.Rb.AddForce( new Vector2(walkDirection,PlayerStateMachine.JumpSpeed), ForceMode2D.Impulse);
            PlayerStateMachine.AllowtoJump = false;
            //Debug.Log("jumping now....");
        }
        CheckSwitchStates();
    }

    public override void ExitState()
    {
        
    }

    public override void InitializeSubStates()
    {
        // if(PlayerStateMachine.IsWalkingLeft || PlayerStateMachine.IsWalkingRight)
        //     SetSubState(Factory.Walk());
        // else if(!PlayerStateMachine.IsWalkingLeft || !PlayerStateMachine.IsWalkingRight)
        //     SetSubState(Factory.Idle());
    }
}
