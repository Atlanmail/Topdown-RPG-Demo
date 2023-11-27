using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateMachine : MonoBehaviour
{
    [SerializeField] private CharacterController _charController;
    [SerializeField] private Animator _animator;
    [SerializeField] private EntityController _entityController;

    EntityBaseState _currentState;
    EntityStateFactory _states;

    public EntityBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }


    void Awake()
    {
        // setup state

        _states = new EntityStateFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
    }
    public void OnMovementInput(Vector2 movementInput)
    {
        Debug.Log("OnMovementInput " + movementInput);
    }

    public void OnJump() 
    {
        Debug.Log("Jump");
    }

    public void startSprint()
    {
        Debug.Log("Start sprint");
    }

    public void endSprint()
    {
        Debug.Log("End Sprint");
    }

    void HandleRotation()
    {

    }

    void HandleMovement()
    {

    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

}
