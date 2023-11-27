using System.Collections;
using System.Collections.Generic;
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

    public abstract void UpdateState();

    public abstract void CheckSwitchStates();

    public abstract void InitializeSubState();

    protected void UpdateStates() { }

    protected void SwitchState(EntityBaseState newState) 
    {
        /// current state exits state
        ExitState();
        
        newState.EnterState();

        _ctx.CurrentState = newState;
    }
    protected void SetSuperState() { }
    protected void SetSubState() { }
}
