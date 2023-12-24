using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class EntityBaseState 
{
    /// <summary>
    ///  context and factory
    /// </summary>
    protected EntityStateMachine _ctx;
    protected EntityStateFactory _factory;

    /// <summary>
    /// sub and superstates
    /// </summary>
    protected EntityBaseState _currentSuperState;
    protected EntityBaseState _currentSubState;


    protected bool _isRootState = false;

    public EntityBaseState currentSubState { get { return _currentSubState; } }
    public EntityBaseState(EntityStateMachine currentContext, EntityStateFactory factory)
    {
        _ctx = currentContext;
        _factory = factory;
    }

    public abstract void EnterState();
    public abstract void ExitState();

    public abstract void UpdateState(); /// <summary>
    ///  runs on update in entity
    /// </summary>

    public abstract void FixedUpdateState(); /// <summary>
    ///  runs on fixedupdate in entity
    /// </summary>
    public abstract void LateUpdateState();
    /// <summary>
    /// runs on lateupdate in entity.
    /// </summary>
    public abstract void CheckSwitchStates();

    public abstract void InitializeSubState();

    /// <summary>
    /// cleanup is called after the state is switched and it is empty
    /// </summary>
    public abstract void Cleanup(); 

    public void UpdateStates() {
        UpdateState();

        if (_currentSubState != null) { 
            _currentSubState.UpdateStates();
        }
    }

    public void FixedUpdateStates()
    {
        FixedUpdateState();

        if (_currentSubState != null)
        {
            _currentSubState.FixedUpdateStates();
        }
    }
     
    public void LateUpdateStates()
    {
        LateUpdateState();

        if (_currentSubState != null)
        {
            _currentSubState.LateUpdateStates();
        }
    }

    protected void SwitchState(EntityBaseState newState) 
    {
        /// current state exits state
        ExitState();
        
        newState.EnterState();

        if (_isRootState)
        {
            _ctx.CurrentState = newState;
        } else {
             _currentSuperState.SetSubState(newState);
        }

       Cleanup();
        
    }
    protected void SetSuperState(EntityBaseState newSuperState) 
    {
        if (_currentSuperState != null)
        {
            _currentSuperState.ExitState();
        }


        _currentSuperState = newSuperState;
        ///_currentSuperState.EnterState();
        _isRootState = false;
    }
    protected void SetSubState(EntityBaseState newSubstate) {
        if (_currentSubState != null)
        {
            currentSubState.ExitState();
        }
        _currentSubState = newSubstate;
        _currentSubState.EnterState();

        newSubstate.SetSuperState(this);
    }
}
