using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory 
{
   PlayerStateMachine _playerStateMachine;

   public PlayerStateFactory(PlayerStateMachine lplayerStateMachine)
   {
    _playerStateMachine = lplayerStateMachine;
   }

   public PlayerBaseState Idle()
   {
        return new PlayerIdleState(this,_playerStateMachine);
   }

   public PlayerBaseState Walk()
   {
        return new PlayerWalkState(this,_playerStateMachine);
   }

   public PlayerBaseState Jump()
   {
        return new PlayerJumpState(this, _playerStateMachine);
   }

   public PlayerBaseState Grounded()
   {
        return new PlayerGroundedState (this, _playerStateMachine);
   }

   public PlayerBaseState Fall()
   {
     return new PlayerFallState(this,_playerStateMachine);
   }

   public PlayerBaseState Respawn()
   {
     return new PlayerRespawnState(this,_playerStateMachine);
   }
}
