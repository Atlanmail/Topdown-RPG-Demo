using Assets.Scripts.Entity.Entity_State_Machine;
using System.Collections;
using UnityEngine;


public class EntityAirborneState : EntityBaseState
{
    protected CharacterController _controller;

    public EntityAirborneState(EntityStateMachine currentContext, EntityStateFactory factory) : base(currentContext, factory)
    {
        _isRootState = true;

        _controller = _ctx.charController;
        //InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        if (_ctx.isGrounded() && _currentSubState is EntityFallingState)
        {
            ///Debug.Log("Entering grounded"); 
            SwitchState(_factory.Grounded());
            return;
        }
    }

    public override void Cleanup()
    {
        ///throw new System.NotImplementedException();
    }

    public override void EnterState()
    {
        Debug.Log("Entered airborne");
        InitializeSubState();
    }

    public override void ExitState()
    {
        ///SetSubState(_factory.Idle());
        ///throw new System.NotImplementedException();
    }

    public override void FixedUpdateState()
    {
        ///throw new System.NotImplementedException();
    }

    public override void InitializeSubState()
    {
        if (_ctx.jumpButtonPressed)
        {
            Debug.Log("Set substate jump");
            SetSubState(_factory.Jump());
            return;
        }
        else
        {
            SetSubState(_factory.Falling());
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
