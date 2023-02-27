using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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
         if(PlayerStateMachine.IsJumping && PlayerStateMachine.IsGrounded)
        {
            SwitchStates(Factory.Jump());
        }
    }

    public override void EnterState()
    {
        if (PlayerStateMachine.IsWalkingLeft)
        {
            PlayerStateMachine.OnEnterState(PlayerStateMachine.PlayerStates.LeftWalk);
            PlayerStateMachine.transform.rotation = Quaternion.Euler(0,180,0);
        }
            
        else
        {
             PlayerStateMachine.OnEnterState(PlayerStateMachine.PlayerStates.RightWalk);
            PlayerStateMachine.transform.rotation = Quaternion.Euler(0,0,0);
        }
           
    }

    public override void ExitState()
    {
        
    }

    public override void InitializeSubStates()
    {
       
    }

    public override void UpdateState()
    {
        Vector2 walkDirection = PlayerStateMachine.IsWalkingRight ? new Vector2(PlayerStateMachine.WalkSpeed, 0) : new Vector2(-PlayerStateMachine.WalkSpeed, 0);
        Vector3 objectPosWorld = PlayerStateMachine.transform.position;

        // Convert the object's position to viewport space using the main camera
        Vector3 objectPosViewport = Camera.main.WorldToViewportPoint(objectPosWorld);
        // Check if the object is inside of the screen
        // if (objectPosViewport.x >= 0.02)
        // {
            PlayerStateMachine.Rb.MovePosition(PlayerStateMachine.Rb.position + walkDirection * Time.fixedDeltaTime);
            //Debug.Log("Object is inside of screen space!");
        //}

        // else
        // {
        //     PlayerStateMachine.Rb.MovePosition(PlayerStateMachine.Rb.position + new Vector2(1, 0) * Time.fixedDeltaTime);
        // }

        // Vector3 screenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        // Vector3 newBounds = PlayerStateMachine._cinemachineVirtualCamera.GetComponent<CinemachineConfiner>().m.size;
        
        // newBounds.x = screenPoint.x - confiner.transform.position.x;
        // confiner.m_Bounds.size = newBounds;
        CheckSwitchStates();
        // rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
