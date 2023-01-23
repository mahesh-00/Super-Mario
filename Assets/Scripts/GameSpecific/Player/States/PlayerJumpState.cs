using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateFactory psf, PlayerStateMachine psm) : base(psf, psm)
    {
        IsRootState = true;
        InitializeSubStates();
    }

    public override void CheckSwitchStates()
    {
        if(!PlayerStateMachine.IsGrounded)
        {
           SwitchStates(Factory.Grounded());
        }
            
    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        if(PlayerStateMachine.IsGrounded)
        {
            float walkDirection = PlayerStateMachine.IsWalkingRight?5:PlayerStateMachine.IsWalkingLeft?-5:0;
            PlayerStateMachine.Rb.AddForce( new Vector2(0f,20f), ForceMode2D.Impulse);
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
