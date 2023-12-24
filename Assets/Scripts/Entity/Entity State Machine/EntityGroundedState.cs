using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGroundedState : EntityBaseState
{
    public EntityGroundedState(EntityStateMachine currentContext, EntityStateFactory factory) : base(currentContext, factory)
    {
        _isRootState = true;
        ///InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        if (_ctx.isDead)
        {
            return;
        }


        bool jumpButtonPressed = _ctx.jumpButtonPressed;
        Debug.Log(jumpButtonPressed);
        if (jumpButtonPressed)
        {
            Debug.Log("Switching to airborne");
            SwitchState(_factory.Airborne());
            return;
        }
    }

    public override void Cleanup()
    {
        ///throw new System.NotImplementedException();
    }

    public override void EnterState()
    {
        _ctx.ClearInput();
        InitializeSubState();
    }

    public override void ExitState()
    {
        ///throw new System.NotImplementedException();
    }

    public override void FixedUpdateState()
    {
        ///throw new System.NotImplementedException();
    }

    public override void InitializeSubState()
    {
        if (_ctx.isDead)
        {
            SetSubState(_factory.Death());
            return;
        }
        if (_ctx.staggered)
        {
            SetSubState(_factory.Stagger());
            return;
        }
        if (_ctx.attackButtonPressed == true)
        {
            SetSubState(_factory.Attack());
            return;
        }

        if (_ctx.blockButtonPressed == true)
        {
            SetSubState(_factory.Block());
            return;
        }

        if (_ctx.movementInput != Vector2.zero)
        {
            SetSubState(_factory.Walk());
            return;
        }
        else
        {
            Debug.Log("entered idle");
            SetSubState(_factory.Idle());
            return;
        }
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
