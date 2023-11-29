using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackState : EntityBaseState
{
    protected Animator _animator;
    protected Transform _transform;

    private bool _isFinished = false;

    protected bool _attackButtonPressed;

    public EntityAttackState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory) 
    {
        _animator = _ctx.Animator;
        _transform = _ctx.transform;
        _isFinished = false;
    }
    public override void CheckSwitchStates()
    {
        if (_isFinished)
        {
            SwitchState(_factory.Idle());
        }
    }

    public override void Cleanup()
    {
        ///throw new System.NotImplementedException();
    }

    public override void EnterState()
    {
        Debug.Log("Entered attack");
        _isFinished = false;
        _ctx.attackButtonPressed = false;
        playRightSwing();

        if (_attackButtonPressed == true )
        {
            playLeftSwing();
        }
        _isFinished = true;
        
    }

    public override void ExitState()
    {
        Debug.Log("Exited attack");
        _ctx.attackButtonPressed = false;

        _animator.SetBool("isLeftSwing", false);
        _animator.SetBool("isRightSwing", false);
    }

    public override void FixedUpdateState()
    {
        ///throw new System.NotImplementedException();
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
        _attackButtonPressed = _ctx.attackButtonPressed;
        CheckSwitchStates();
    }

    void playRightSwing()
    {
        Debug.Log("Played right swing");
        _animator.Play("Right Swing");

        
    }

    void playLeftSwing()
    {
        Debug.Log("Played left swing");
        _animator.Play("Left Swing");
    }
}
