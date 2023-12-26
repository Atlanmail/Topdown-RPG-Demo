using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class ArcherAttackState : EntityAttackState
{

    private GameObject arrowPrefab;
    private float arrowCreateDistance = 2f;
    private CharacterController _controller;

    public ArcherAttackState(EntityStateMachine currentContext, EntityStateFactory factory)
        : base(currentContext, factory)
    {
        arrowPrefab = Arrow.defaultArrow;
        _controller = _ctx.charController;
    }
    public override void EnterState()
    {
        _isFinished = false;
        if (arrowPrefab == null)
        {
            arrowPrefab = GameObject.Find("Arrow");
        }


        fireProjectile();
    }

    public override void ExitState()
    {
        _ctx.attackButtonPressed = false;
    }

    private void fireProjectile()
    {
        ///Debug.Log("Fired projectile");
        _ctx.attackButtonPressed = false;
        _animator.SetTrigger("Right Swing");


    }

    public override void onAttackWindupStart()
    {
        ///Debug.Log("Archer attack windup start");
        _attackState = 1;
    }

    public override void onAttackAnimationStart()
    {
        ///_hitbox.colliderEnable();
        _attackState = 2;

        GameObject arrowObject = GameObject.Instantiate(arrowPrefab);
        Arrow arrow = arrowObject.GetComponent<Arrow>();

        arrow.setPosition(_controller.center + _ctx.transform.position + _controller.transform.forward * arrowCreateDistance);
        arrow.facePosition(_controller.center + _ctx.transform.position + _controller.transform.forward * arrowCreateDistance * 4);
        arrow.setAttackData(_attackData);
        arrow.setEntityData(_entityData);


        arrow.startMoving();
    }

    public override void onAttackAnimationEnd()
    {
        /// _hitbox.colliderDisable();
        _isFinished = true;

        _attackState = 3;
    }

    public override void onAttackAnimationRecovered()
    {
        ///checkIfFinished();
        _attackState = 0;
    }
}
