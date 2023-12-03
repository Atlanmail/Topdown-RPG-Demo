using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackState : EntityBaseState, ICanAttack
{
    protected Animator _animator;
    protected Transform _transform;
    /// <summary>
    /// protected Hurtbox _hurtbox;
    /// </summary>

    private bool _isFinished = false;
    private bool _hasSwungRight = false;
    private bool _hasSwungLeft = false;

    protected bool _attackButtonPressed;
    

    public EntityAttackState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory) 
    {
        _animator = _ctx.Animator;
        _transform = _ctx.transform;
        _isFinished = false;
        _hasSwungRight = false;
        
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
        _hasSwungRight = false;
        _hasSwungLeft = false;
        playRightSwing();
        
    }

    public override void ExitState()
    {
        Debug.Log("Exited attack");
        _ctx.attackButtonPressed = false;

        ///_animator.SetBool("isLeftSwing", false);
        ///_animator.SetBool("isRightSwing", false);
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
        
        CheckSwitchStates();
    }

    void playRightSwing()
    {
        Debug.Log("Played right swing");
        _hasSwungRight = true;
        _ctx.attackButtonPressed = false;
        _animator.SetTrigger("Right Swing");
        
        
    }

    void playLeftSwing()
    {
        Debug.Log("Played left swing");
        _hasSwungLeft = true;
        _ctx.attackButtonPressed = false;
        _animator.SetTrigger("Left Swing");

    }

    void checkIfFinished ()
    {
        if (_ctx.attackButtonPressed == true && _hasSwungRight && _hasSwungLeft == false)
        {
            playLeftSwing();
        }
        else
        {
            _isFinished = true;
        }

       

    }
    public void Attack()
    {
        throw new System.AccessViolationException();
    }

    public void onAttackWindupStart()
    {
        
    }

    public void onAttackAnimationStart()
    {
        ///_hurtbox.Enable();
    }

    public void onAttackAnimationEnd()
    {
        ///_hurtbox.Disable();
    }

    public void onAttackAnimationRecovered()
    {
        checkIfFinished();
    }
}
