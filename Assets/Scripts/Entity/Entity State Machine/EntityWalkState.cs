using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EntityWalkState : EntityBaseState
{
    
    protected CharacterController _characterController;
    protected float _speed;
    protected Vector2 _movementInput;
    protected Animator _animator;
    protected bool _isWalking;
    protected float _rotationSpeed;

    protected Transform _transform;
    protected EntityData _entityData;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="currentContext"></param>
    /// <param name="factory"></param>
    public EntityWalkState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory)
    {
        _entityData = _ctx.entityData;
        _characterController = _ctx.charController;
        _speed = _entityData.speed;
        _animator = _ctx.Animator;
        _transform = _ctx.transform;
        _rotationSpeed = _entityData.rotationSpeed;
    }

    public override void CheckSwitchStates()
    {
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


        /// check idle
        /// 
        if (_movementInput != Vector2.zero)
        {
            ///Debug.Log("From idle " + _movementInput.ToString());
            return;
        }

        Vector3 curVelocity = _ctx.charController.velocity;

        curVelocity.y = 0;

        if (curVelocity.magnitude < 0.3f)
        {
            ///Debug.Log("Switched to idle");
            SwitchState(_factory.Idle());
            return;
        }
    }

    public override void EnterState()
    {
        ///Debug.Log("Entered walk");
    }

    public override void ExitState()
    {
        ///Debug.Log("Exited Walk");

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

        _transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

}

