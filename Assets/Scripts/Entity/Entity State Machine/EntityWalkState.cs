using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class EntityWalkState : EntityBaseState
{
    
    protected CharacterController _characterController;
    protected float _speed;
    protected Vector2 _movementInput;
    protected Animator _animator;
    protected bool _isWalking;
    protected Transform _transform;
    protected float _rotationFactorPerFrame;
    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="currentContext"></param>
    /// <param name="factory"></param>
    public EntityWalkState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory)
    {
        _characterController = _ctx.charController;
        _speed = _ctx.speed;
        _animator = _ctx.Animator;
        _transform = _ctx.transform;
        _rotationFactorPerFrame = _ctx.rotationFactorPerFrame;
    }

    public override void CheckSwitchStates()
    {
        if (_ctx.attackButtonPressed == true)
        {
            SwitchState(_factory.Attack());
            return;
        }


        /// check idle
        /// 
        if (_movementInput != Vector2.zero)
        {
            return;
        }

        Vector3 curVelocity = _ctx.charController.velocity;

        curVelocity.y = 0;

        if (curVelocity.magnitude < 0.3f)
        {
            SwitchState(_factory.Idle());
            return;
        }
    }

    public override void EnterState()
    {
        Debug.Log("Entered walk");
    }

    public override void ExitState()
    {
        Debug.Log("Exited Walk");

        _animator.SetBool("isWalking", false);
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

        handleAnimation();
        handleRotation();
        handleMovement();


        CheckSwitchStates();

    }

    public override void Cleanup()
    {
        
    }

    protected virtual void handleMovement()
    {
        Vector3 moveDirection = new Vector3(_movementInput.x, 0, _movementInput.y);
        ///Debug.Log(moveDirection);
        _characterController.SimpleMove(moveDirection * _speed);
    }

    protected virtual void handleAnimation()
    {
        _animator.SetBool("isWalking", true);
    }

    protected virtual void handleRotation()
    {
        if (_movementInput == Vector2.zero)
        {
            return;
        }

        Vector3 positionToLookAt = new Vector3(_movementInput.x, 0, _movementInput.y);


        Quaternion currentRotation = _transform.rotation;

        Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);

        _transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
    }

}

