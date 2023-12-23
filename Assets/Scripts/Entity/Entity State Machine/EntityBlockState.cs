using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class EntityBlockState : EntityBaseState
{
    protected Animator _animator;


    protected BlockboxManager _blockboxManager;
    protected HurtboxManager _hurtboxManager;

    protected AttackData _attackData;
    protected EntityData _entityData;

    public EntityBlockState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory)
    {
        _animator = _ctx.Animator;

        _blockboxManager = _ctx.blockboxManager;
        _hurtboxManager = _ctx.hurtboxManager;

        _entityData = _ctx.entityData;
        _attackData = _entityData.attackData;

        _blockboxManager.OnBlockHit += onBlockHit;
        
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

        if (_ctx.blockButtonPressed == false)
        {
            SwitchState(_factory.Idle());
            return;
        }
    }

    public override void EnterState()
    {
        Debug.Log("Entered block");
        _blockboxManager.Enable();
        _animator.Play("Block");
        ///Debug.Log("Entered Idle");
    }

    public override void ExitState()
    {
        _animator.SetBool("isBlocking", false);
        _blockboxManager.Disable(); 
        _ctx.endBlock();
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
        _animator.SetBool("isBlocking", true);
    }

    protected virtual void onBlockHit(EntityData entityData, AttackData attackData)
    {
        
    }



}
