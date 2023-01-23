using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState 
{
    protected bool IsRootState = false;
    protected PlayerStateFactory Factory;
    protected PlayerStateMachine PlayerStateMachine;
    private PlayerBaseState _currentSuperState;
    private PlayerBaseState _currentSubState;
    public PlayerBaseState(PlayerStateFactory psf,PlayerStateMachine psm)
    {
        Factory = psf;
        PlayerStateMachine = psm;
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InitializeSubStates();
    public void UpdateStates()
    {
        UpdateState();
        if(_currentSubState!=null)
            _currentSubState.UpdateStates();
    }
    protected void SwitchStates(PlayerBaseState newState)
    {
        ExitState();
        newState.EnterState();
        PlayerStateMachine.CurrentState = newState;
        Debug.Log(newState);
       
        // if(IsRootState)
        //     PlayerStateMachine.CurrentState = newState;
        // else if(_currentSuperState!=null)
        // { 

        //     _currentSuperState.SetSubState(newState);
        // }
         //Debug.Log("CurrentSuper state: "+ _currentSuperState +" Curren substate: "+_currentSubState);
    }
    protected void SetSuperState(PlayerBaseState newSuperState)
    {
        _currentSuperState = newSuperState;
    }
    protected void SetSubState(PlayerBaseState newSubState)
    {
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }
}
