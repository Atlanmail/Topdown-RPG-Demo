using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;


namespace BaseStateMachine
{
    public class StateMachine : MonoBehaviour
    {


        [SerializeField] private BaseStateMachineData _stateMachineData;
        [SerializeField] protected BaseState _currentState;
        BaseStateFactory _states;



        public BaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        public BaseStateMachineData StateMachineData { get { return _stateMachineData; } }

        void Awake()
        {
            stateMachineDataSetup();

            _states = new BaseStateFactory(this);

        }

        void Start()
        {
            enterDefaultState();

        }
        void OnEnable()
        {

        }

        void OnDisable()
        {

        }

        void Update()
        {


            _currentState.UpdateStates();
        }

        void FixedUpdate()
        {
            _currentState.FixedUpdateStates();
        }

        void LateUpdate()
        {
            _currentState.LateUpdateStates();
        }

        
        protected virtual void enterDefaultState()
        {
            _currentState = _states.Default();
            _currentState.EnterState();
        }
        /**
         * prepares stateMachineData
         */
        protected virtual void stateMachineDataInitialize()
        {
            _stateMachineData.initialize();
        }
        /**
         * Clones your stateMachineData from the template data
         */
        protected virtual void stateMachineDataSetup()
        {
            _stateMachineData = _stateMachineData.Clone();
        }
    }
}
