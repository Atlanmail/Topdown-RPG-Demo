using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EntityIdleState : EntityBaseState
{
    public EntityIdleState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory) { }
    
    public override void CheckSwitchStates()
    {
        if (_ctx.movementInput != Vector2.zero)
        {
            SwitchState(_factory.Walk());
        }
    }

    public override void EnterState()
    {
        Debug.Log("Entered Idle");
    }

    public override void ExitState()
    {
        Debug.Log("Exited Idle");
    }

    public override void FixedUpdateState()
    {
        
    }

    public override void Cleanup()
    {

    }
    public override void InitializeSubState()
    {
        ///throw new System.NotImplementedException();
    }

    public override void LateUpdateState()
    {
        ///throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

}
