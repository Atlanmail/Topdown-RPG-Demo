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
        ///
        if (_ctx.isDead)
        {
            SwitchState(_factory.Death());
            return;
        }
        if (_ctx.staggered)
        {
            SwitchState(_factory.Stagger());
            return;
        }
        if (_ctx.attackButtonPressed == true)
        {
            SwitchState(_factory.Attack());
            return;
        }

        if (_ctx.blockButtonPressed == true)
        {
            SwitchState(_factory.Block());
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
        ///Debug.Log("From Idle, Is grounded " + _ctx.isGrounded());
    }

    public override void ExitState()
    {
        ///Debug.Log("Exited Idle");
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
