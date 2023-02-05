using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private PlayerStateMachine _playerStateMachine;
    [SerializeField] private Animator _playerAnimator;
    private int _idle, _walk, _jump;

    void Awake()
    {
         _playerStateMachine = GetComponent<PlayerStateMachine>();
         _playerStateMachine.OnEnterState += UpdateAnimationStates;
        _idle = Animator.StringToHash("Ground");
        _jump = Animator.StringToHash("isJumping");
        _walk = Animator.StringToHash("isRunning");
    }

  
    void OnDisable()
    {
          _playerStateMachine.OnEnterState -= UpdateAnimationStates;
    }

    private void UpdateAnimationStates(PlayerStateMachine.PlayerStates newState)
    {
        switch(newState)
        {
            case PlayerStateMachine.PlayerStates.Idle:
                PlayAnimation(_idle);
                break;
            case PlayerStateMachine.PlayerStates.LeftWalk:
                PlayAnimation(_walk);
                break;
            case PlayerStateMachine.PlayerStates.RightWalk:
                PlayAnimation(_walk);
                break;
            case PlayerStateMachine.PlayerStates.Jump:
                PlayAnimation(_jump);
                break;
             default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    void PlayAnimation(int _id)
    {
        ExitAnimation();
        _playerAnimator.SetTrigger(_id);
    }

    void ExitAnimation()
    {
        _playerAnimator.SetBool(_idle,false);
        _playerAnimator.SetBool(_walk,false);
        _playerAnimator.SetBool(_jump,false);
    }
}
