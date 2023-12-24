using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entity.Entity_State_Machine
{
    public class EntityFallingState : EntityBaseState
    {
        protected CharacterController _controller;
        protected Animator _animator;
        public EntityFallingState(EntityStateMachine currentContext, EntityStateFactory factory) : base(currentContext, factory)
        {
            
            _controller = _ctx.charController;
            _animator = _ctx.Animator;
            
        }
        public override void CheckSwitchStates()
        {
            ///throw new System.NotImplementedException();
        }

        public override void Cleanup()
        {
            ///throw new System.NotImplementedException();
        }

        public override void EnterState()
        {
            ///Debug.Log("Started falling");
        }

        public override void ExitState()
        {
            ///throw new System.NotImplementedException();
        }

        public override void FixedUpdateState()
        {
            handleGravity();
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
            Debug.Log(_currentSuperState);
        }

        protected virtual void handleGravity()
        {
            float moveDirectionYToBe = -0.2f;

            Vector3 moveDirection = new Vector3(0, moveDirectionYToBe, 0);
            ///Debug.Log(moveDirection.ToString());
            _controller.Move(moveDirection);
        }

    }
}