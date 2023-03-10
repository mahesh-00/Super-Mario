using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    private bool _isFalling = false;
    public PlayerDeadState(PlayerStateFactory psf, PlayerStateMachine psm) : base(psf, psm)
    {

    }
    public override void EnterState()
    {
        PlayerStateMachine.OnEnterState(PlayerStateMachine.PlayerStates.Dead);
        PlayerStateMachine.transform.localScale = new Vector3(1, 0.5f, 0);
        Physics.IgnoreLayerCollision(CONSTANTS.PlayerLayer, CONSTANTS.GroundLayer, true);

    }
    public override void UpdateState()
    {
        if (!_isFalling)
        {
            PlayerStateMachine.Rb.velocity = new Vector2(0, 3) * 1.2f;
            //Debug.Log("jumping");
        }

        if (PlayerStateMachine.Rb.position.y >= 1.5f)
        {
            //Debug.Log("jump limit reached");
            PlayerStateMachine.GetComponent<BoxCollider2D>().isTrigger = true;
            _isFalling = true;
        }

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
        if (PlayerStateMachine.transform.position.y < -150)
            GameManager.Instance.OnGameCompleted?.Invoke();
    }
}
