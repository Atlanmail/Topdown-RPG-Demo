using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : NPCBehavior
{

    public AttackBehavior(NPCController controller)
    {
        _controller = controller;

        curFrameCount = 0;
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
        

    }



}
