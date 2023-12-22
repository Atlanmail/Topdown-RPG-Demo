using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EntityDeathState : EntityBaseState
{
    protected Animator _animator;

    protected float oldHeight;
    protected float layHeight = 0.1f;

    public EntityDeathState(EntityStateMachine currentContext, EntityStateFactory factory)
    : base(currentContext, factory)
    {
        _animator = _ctx.Animator;
    }

    public override void CheckSwitchStates()
    {
        if (_ctx.isDead == false)
        {
            SwitchState(_factory.Idle());
            return;
        }
    }

    public override void EnterState()
    {
        oldHeight = _ctx.charController.height;
        _ctx.charController.height = layHeight;
        _animator.Play("Death");
        _ctx.charController.Move(Vector3.forward * 0.05f);
    }

    public override void ExitState()
    {
        ///Debug.Log("Exited Idle");
        _ctx.charController.height = oldHeight;
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

    }

}
