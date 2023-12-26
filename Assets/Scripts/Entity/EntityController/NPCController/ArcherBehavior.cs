    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ArcherBehavior : NPCBehavior
    {

        PlayerTracker _playerTracker;

        Transform _transform;

    
        private float chaseDistance = 20f;
        public ArcherBehavior(NPCController controller)
        {
            _controller = controller;

            curFrameCount = 0;

            _playerTracker = PlayerTracker.Instance;
            _transform = _controller.transform;
        }


        private int updateFrameCount = 100;
        private int curFrameCount;
        private int attackFrameCount = -1;
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
            if (attackFrameCount == 0)
            {
                _controller.onAttack();
            }

            curFrameCount++;
            attackFrameCount--;
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

        
            if (distance < chaseDistance)
            {
                Debug.Log("Starting attacks");
                _controller.facePosition(player.transform.position);

                attackFrameCount = 60;

                
            }

        }



    }
