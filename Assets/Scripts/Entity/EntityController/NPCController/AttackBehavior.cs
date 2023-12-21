using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : NPCBehavior
{

    PlayerTracker _playerTracker;

    Transform _transform;

    private float attackDistance = 1.5f;
    private float chaseDistance = 10f;
    public AttackBehavior(NPCController controller)
    {
        _controller = controller;

        curFrameCount = 0;

        _playerTracker = PlayerTracker.Instance;
        _transform = _controller.transform;
    }


    private int updateFrameCount = 12;
    private int curFrameCount;

    public override void onEnter()
    {
        
    }
    public override void FixedUpdate()
    {
        if (curFrameCount == updateFrameCount)
        {
            curFrameCount = 0;
            scanEnemy();
        }
        else
        {
            curFrameCount++;
        }
    }

    public override void SwitchState()
    {
        ///throw new System.NotImplementedException();
    }

    public override void Update()
    {
        
    }

    private void scanEnemy()
    {
        GameObject player = _playerTracker.getPlayer();

        float distance = Vector3.Distance(_transform.position, player.transform.position);

        if (distance < attackDistance)
        {
            _controller.onAttack();
        }
        else if (distance < chaseDistance)
        {
            _controller.moveTo(player.transform.position);
        }

    }



}
