using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityJumpState : EntityBaseState
{
    protected CharacterController _controller;
    protected Animator _animator;
    protected EntityData _entityData;


    protected bool _isFinished;
    protected int _jumpFrames;
    protected int _curJumpFrame;
    protected float _jumpHeight;

    protected Vector2 horizontalVelocity;
    public EntityJumpState(EntityStateMachine currentContext, EntityStateFactory factory) 
    : base(currentContext, factory) 
    {
        _controller = _ctx.charController;
        _animator = _ctx.Animator;
        _entityData = _ctx.entityData;

        _jumpHeight = _ctx.entityData.jumpHeight;
        _jumpFrames = _ctx.entityData.jumpFrames;

        _isFinished = false;
    }
    public override void CheckSwitchStates()
    {
        if (_isFinished)
        {
            ///Debug.Log("Switching to falling");
            SwitchState(_factory.Falling());
            return;
        }
    }

    public override void Cleanup()
    {
        ///throw new System.NotImplementedException();
    }

    public override void EnterState()
    {

        Debug.Log("Entered jump");
        beginJump();
    }

    public override void ExitState()
    {
        ///throw new System.NotImplementedException();
    }

    public override void FixedUpdateState()
    {
        
        handleJump();
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
        CheckSwitchStates();
    }

    // Start is called before the first frame update
    protected virtual void handleJump()
    {
        ///Debug.Log("Handling jump");
        if (_isFinished)
        {
            return;
        }
        if (_curJumpFrame < _jumpFrames)
        {
            ///Debug.Log("Handling movement");
            float moveDirectionYToBe = (_jumpHeight / (float)_jumpFrames);

            ///Debug.Log(moveDirectionYToBe);

            ///moveDirection.y = moveDirectionYToBe; /// velocity is jumpHeight / jumpFrames
            ///Debug.Log(moveDirection.ToString());
            Vector3 moveDirection = new Vector3(0, moveDirectionYToBe, 0);
            ///Debug.Log(moveDirection.ToString());
            _controller.Move(moveDirection);
        }
        else
        {
            ///Debug.Log("Is finished is true");
            _isFinished = true;
        }
        _curJumpFrame++;
        
    }

    protected virtual void beginJump()
    {
        if (_ctx.isGrounded() == true)
        {
            ///return;
        }


        _curJumpFrame = 0;
        _isFinished = false;
        _ctx.ClearInput();
    }
}
