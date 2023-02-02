using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateFactory psf, PlayerStateMachine psm) : base(psf, psm)
    {
        IsRootState = true;
        InitializeSubStates();
    }
  

    public override void EnterState()
    {
         PlayerStateMachine.AllowtoJump = true;
    }

    public override void ExitState()
    {

    }

    public override void InitializeSubStates()
    {
        if(PlayerStateMachine.IsWalkingLeft || PlayerStateMachine.IsWalkingRight)
            SetSubState(Factory.Walk());
        else if(!PlayerStateMachine.IsWalkingLeft || !PlayerStateMachine.IsWalkingRight)
            SetSubState(Factory.Idle());
         else if(PlayerStateMachine.IsJumping && PlayerStateMachine.IsGrounded)
        {
            SwitchStates(Factory.Jump());
        }
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void CheckSwitchStates()
    {
        
        if(!PlayerStateMachine.IsGrounded)
        {
            SwitchStates(Factory.Fall());
        }
        // if(PlayerStateMachine.IsWalkingLeft || PlayerStateMachine.IsWalkingRight)
        //     SwitchStates(Factory.Walk());
        // else if(!PlayerStateMachine.IsWalkingLeft || !PlayerStateMachine.IsWalkingRight)
        //     SwitchStates(Factory.Idle());
    }
}
