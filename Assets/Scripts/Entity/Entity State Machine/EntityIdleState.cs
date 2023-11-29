using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EntityIdleState : EntityBaseState
{
    protected Animator _animator;

    public EntityIdleState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory) {
        _animator = _ctx.Animator;
    }
    
    public override void CheckSwitchStates()
    {
        ///Debug.Log("Idle checking");
        if (_ctx.attackButtonPressed == true)
        {
            SwitchState(_factory.Attack());
            return;
        }

        if (_ctx.movementInput != Vector2.zero)
        {
            SwitchState(_factory.Walk());
            return;
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
        handleAnimation();
        CheckSwitchStates();
        
    }

    protected virtual void handleAnimation()
    {
        
    }

}
