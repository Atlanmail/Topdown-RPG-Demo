using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class EntityWalkState : EntityBaseState
{
    public EntityWalkState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory) { }

    protected CharacterController _characterController;
    protected float _speed;
    protected Vector2 _movementInput;
    public override void CheckSwitchStates()
    {
        if (_movementInput != Vector2.zero)
        {
            return;
        }

        Vector3 curVelocity = _ctx.charController.velocity;

        curVelocity.y = 0;

        if (curVelocity.magnitude < 0.3f)
        {
            SwitchState(_factory.Idle());
        }
    }

    public override void EnterState()
    {
        Debug.Log("Entered Walk");
        _characterController = _ctx.charController;
        _speed = _ctx.speed;



    }

    public override void ExitState()
    {
        Debug.Log("Exited Walk");
    }

    public override void FixedUpdateState()
    {
        


    }

    public override void InitializeSubState()
    {
        throw new System.NotImplementedException();
    }

    public override void LateUpdateState()
    {
        
    }

    public override void UpdateState()
    {
       _movementInput = _ctx.movementInput;

        HandleMovement();

        CheckSwitchStates();

    }

    public override void Cleanup()
    {
        
    }

    protected virtual void HandleMovement()
    {
        Vector3 moveDirection = new Vector3(_movementInput.x, 0, _movementInput.y);
        Debug.Log(moveDirection);
        _characterController.SimpleMove(moveDirection * _speed);
    }

}

