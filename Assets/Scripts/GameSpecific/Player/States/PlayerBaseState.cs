using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState 
{
    protected bool IsRootState = false;
    protected PlayerStateFactory Factory;
    protected PlayerStateMachine PlayerStateMachine;
    public PlayerBaseState _currentSuperState;
    public PlayerBaseState _currentSubState;
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
    public void SwitchStates(PlayerBaseState newState)
    {
        ExitState();
        Debug.Log(newState);
        newState.EnterState();
        if(IsRootState)
        {
            PlayerStateMachine.CurrentState = newState;
           
        }
          
        else if(_currentSuperState!=null)
        { 
            _currentSuperState.SetSubState(newState);
        }
         //newState.EnterStates();
         
    }
    // void EnterStates()
    // {
    //     EnterState();
    //     _currentSubState?.EnterStates();
    // }
    protected void SetSuperState(PlayerBaseState _newSuperState)
    {
        _currentSuperState = _newSuperState;
        //Debug.Log("CurrentSuper state: "+ _currentSuperState +"  Current substate:  "+_currentSubState);
    }
    protected void SetSubState(PlayerBaseState _newSubState)
    {
        _currentSubState = _newSubState;
        _newSubState.SetSuperState(this);
    }
}
