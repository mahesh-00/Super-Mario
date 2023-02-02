using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnState : PlayerBaseState
{
   
    public PlayerRespawnState(PlayerStateFactory psf, PlayerStateMachine psm) : base(psf, psm)
    {
        
    }
    public override void EnterState()
    {
        PlayerStateMachine.transform.position = CheckPoint.LastCheckPointPos;
    }
    public override void UpdateState()
    {
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

        if ((Vector2)PlayerStateMachine.transform.position == Vector2.zero)
            SwitchStates(Factory.Idle());
    }
}
