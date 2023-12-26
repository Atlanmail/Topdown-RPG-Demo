using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EntityStaggerState : EntityBaseState
{
    protected Animator _animator;
    protected Transform _transform;

    protected Hitbox _hitbox;
    protected AttackData _attackData;
    protected EntityData _entityData;



    // variables for animations
    
    protected bool _isStaggered;

    /// <summary>
    /// 
    /// </summary>
    protected HurtboxManager _hurtboxManager;
    protected BlockboxManager _blockboxManager;


    protected bool _isFinished;
    public EntityStaggerState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory)
    {
        _animator = _ctx.Animator;
        _transform = _ctx.transform;

        _hitbox = _ctx.attackHitbox;
        _entityData = _ctx.entityData;
        _attackData = _entityData.attackData;

        _isStaggered = _ctx.staggered;
        _isFinished = false;
    }




    public override void CheckSwitchStates()
    {

        if (_ctx.isDead)
        {
            SwitchState(_factory.Death());
            return;
        }

        if (_isFinished)
        {
            Debug.Log("Entering idle from stagger");
            SwitchState(_factory.Idle());
            return;
        }
    }

    public override void Cleanup()
    {
        
    }

    public override void EnterState()
    {
        _isFinished = false;
        _animator.Play("Stagger");    
    }

    public override void ExitState()
    {
        _ctx.staggerEnd();
    }

    public override void FixedUpdateState()
    {
        
    }

    public override void InitializeSubState()
    {
        
    }

    public override void LateUpdateState()
    {
        
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public void staggerEnd()
    {
        
        _isFinished = true;
    }


}
