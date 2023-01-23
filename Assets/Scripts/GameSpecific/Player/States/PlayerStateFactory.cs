using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory : MonoBehaviour
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
}
