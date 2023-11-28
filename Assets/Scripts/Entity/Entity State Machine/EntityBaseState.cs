using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class EntityBaseState 
{

    protected EntityStateMachine _ctx;
    protected EntityStateFactory _factory;
    
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

    protected void UpdateStates() { }

    protected void SwitchState(EntityBaseState newState) 
    {
        /// current state exits state
        ExitState();
        
        newState.EnterState();

        _ctx.CurrentState = newState;

       Cleanup();
        
    }
    protected void SetSuperState() { }
    protected void SetSubState() { }
}
