using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackState : EntityBaseState
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

    protected bool _attackButtonPressed;
    

    public EntityAttackState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory) 
    {
        _animator = _ctx.Animator;
        _transform = _ctx.transform;
        _isFinished = false;
        _hasSwungRight = false;

        _hitbox = _ctx.attackHitbox;
        _entityData = _ctx.entityData;
        _attackData = _entityData.attackData;
       
        
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

        _hitbox.OnEnterCollision += onHitboxCollision;
        _hitbox.colliderDisable();

        playRightSwing();
        
    }

    public override void ExitState()
    {
        Debug.Log("Exited attack");
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
    public void onHitboxCollision(GameObject otherGameObject)
    {
        Hurtbox hurtboxHit = otherGameObject.GetComponent<Hurtbox>();

        ///Debug.Log(otherGameObject);

        if (hurtboxHit != null)
        {
            
            hurtboxHit.Damage(_entityData, _attackData);
        }
    }

    public void onAttackWindupStart()
    {
        
    }

    public void onAttackAnimationStart()
    {
        _hitbox.colliderEnable();
    }

    public void onAttackAnimationEnd()
    {
        _hitbox.colliderDisable();
        checkIfFinished();
    }

    public void onAttackAnimationRecovered()
    {
        checkIfFinished();
    }
}
