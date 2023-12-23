using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackState : EntityBaseState, IAttackState
{
    protected Animator _animator;
    protected Transform _transform;
    
    protected Hitbox _hitbox;
    protected AttackData _attackData;
    protected EntityData _entityData;
    
    // variables for animations
    private bool _isFinished = false;
    private bool _hasSwungRight = false;
    private bool _hasSwungLeft = false;

    private int _attackState = 0; /// 0 is not attacking, 1 is windup, 2 is damage portion, 3 is cooldown

    public int attackState { get => _attackState; }

    protected bool _attackButtonPressed;
    

    public EntityAttackState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory) 
    {
        _animator = _ctx.Animator;
        _transform = _ctx.transform;
        _isFinished = false;
        _hasSwungRight = false;
        _hasSwungLeft=false;

        _hitbox = _ctx.attackHitbox;
        _entityData = _ctx.entityData;
        _attackData = _entityData.attackData;

        HurtboxManager hurtboxManager = _ctx.hurtboxManager;
        BlockboxManager blockboxManager = _ctx.blockboxManager;

        
       
        
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


        /// conditions for blocking
        if (_ctx.blockButtonPressed && _attackState < 2) 
        {
            SwitchState(_factory.Block());
            return;
        }
        if (_isFinished)
        {
            SwitchState(_factory.Idle());
            return;
        }
    }

    public override void Cleanup()
    {
        ///throw new System.NotImplementedException();
    }

    public override void EnterState()
    {
        ///Debug.Log("Entered attack");
        _isFinished = false;
        _ctx.refreshInput();
        _hasSwungRight = false;
        _hasSwungLeft = false;

        _hitbox.OnEnterCollision += onHitboxCollision;
        _hitbox.colliderDisable();

        playRightSwing();
        
    }

    public override void ExitState()
    {  
        ///Debug.Log("Exited attack");
        _ctx.attackButtonPressed = false;

        ///_animator.SetBool("isLeftSwing", false);
        ///_animator.SetBool("isRightSwing", false);
        ///
        _hitbox.OnEnterCollision -= onHitboxCollision;
        _hitbox.colliderDisable();
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
        ///Debug.Log("Played right swing");
        _hasSwungRight = true;
        _ctx.attackButtonPressed = false;
        _animator.SetTrigger("Right Swing");
        
        
    }

    void playLeftSwing()
    {
        ////Debug.Log("Played left swing");
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

    private void onHitboxCollision(GameObject otherGameObject)
    {
        Hurtbox hurtboxHit = otherGameObject.GetComponent<Hurtbox>();
        Blockbox blockboxHit = otherGameObject.GetComponent<Blockbox>();
        ///Debug.Log(otherGameObject);

        if (hurtboxHit != null)
        {
            ///Debug.Log("Hit hurtbox");
            onHurtboxHit(hurtboxHit);
        }
        ///Debug.Log(blockboxHit);
        if (blockboxHit != null)
        {
            onBlockboxHit(blockboxHit);
        }
    }

    protected virtual void onHurtboxHit(Hurtbox hurtboxHit)
    {
        hurtboxHit.Damage(_entityData, _attackData);
    }

    protected virtual void onBlockboxHit(Blockbox blockboxHit)
    {
        _ctx.Stagger();
    }



    public void onAttackWindupStart()
    {
        _attackState = 1;
    }

    public void onAttackAnimationStart()
    {
        _hitbox.colliderEnable();
        _attackState = 2;
    }

    public void onAttackAnimationEnd()
    {
        _hitbox.colliderDisable();
        checkIfFinished();

        _attackState = 3;
    }

    public void onAttackAnimationRecovered()
    {
        checkIfFinished();
        _attackState = 0;
    }
}
