using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    
    Vector3 _currentVelocity;
    float fallMultiplier = 5;
    Vector2 vecGravity ;
    public PlayerFallState(PlayerStateFactory psf, PlayerStateMachine psm) : base(psf, psm)
    {
        IsRootState = true;
        //InitializeSubStates();
    }

    public override void CheckSwitchStates()
    {
        if(PlayerStateMachine.IsGrounded)
        {
           SwitchStates(Factory.Grounded());
        }
    }

    public override void EnterState()
    {
       vecGravity = new Vector2(0,-Physics2D.gravity.y);
    }

    public override void ExitState()
    {
       
    }

    public override void InitializeSubStates()
    {
        if (PlayerStateMachine.IsWalkingLeft || PlayerStateMachine.IsWalkingRight)
            SetSubState(Factory.Walk());
        else if (!PlayerStateMachine.IsWalkingLeft || !PlayerStateMachine.IsWalkingRight)
            SetSubState(Factory.Idle());
         if(PlayerStateMachine.IsJumping && PlayerStateMachine.IsGrounded)
        {
            SetSubState(Factory.Jump());
        }
    }

    public override void UpdateState()
    {
        float walkDirection = PlayerStateMachine.IsWalkingRight?5:PlayerStateMachine.IsWalkingLeft?-5:0;
        PlayerStateMachine.Rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime; 
        //PlayerStateMachine.Rb.velocity = Vector3.SmoothDamp(PlayerStateMachine.Rb.velocity, new Vector2(0f,  PlayerStateMachine.Rb.velocity.y), ref _currentVelocity, 1 * Time.fixedDeltaTime);
        CheckSwitchStates();   
    }
    
}
