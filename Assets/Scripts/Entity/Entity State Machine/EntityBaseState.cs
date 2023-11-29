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


    protected bool _isRootState = true;

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

    protected void SwitchState(EntityBaseState newState) 
    {
        /// current state exits state
        ExitState();
        
        newState.EnterState();

        _ctx.CurrentState = newState;

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
        _currentSuperState = newSuperState;
        _isRootState = false;
    }
    protected void SetSubState(EntityBaseState newSubstate) {
        _currentSubState = newSubstate;
        newSubstate.SetSuperState(this);
    }
}
