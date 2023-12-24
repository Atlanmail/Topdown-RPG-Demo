using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : EntityController
{
    [SerializeField] private EntityStateMachine entityStateMachineSerialize; /// variable that allows to set entityStateMachine
    /// </summary>
    [SerializeField] private PlayerCameraController _cameraController;

    private PlayerActions _playerActions;

    private bool sprintButtonPressed = false;

    PlayerTracker _playerTracker;

    private void Awake()
    {
        _playerTracker = PlayerTracker.Instance;
        _playerTracker.setPlayer(this.gameObject);
    }
    void Start()
    {
        
    }
    void OnEnable()
    {
        _entityStateMachine = entityStateMachineSerialize;
        _playerActions = new PlayerActions();
        _playerActions.Enable();

        // Subscribe to actions
        _playerActions.Gameplay.Cast1.performed += OnCast1;
        _playerActions.Gameplay.Attack1.performed += OnAttack;
        _playerActions.Gameplay.MovementDirection.performed += MovementDirection_performed;
        _playerActions.Gameplay.Sprint.performed += Sprint_Performed;
        _playerActions.Gameplay.Jump.performed += Jump_performed;
        _playerActions.Gameplay.Shield.performed += OnShield;
    }

   

    void OnDisable()
    {   
        _playerActions.Gameplay.Cast1.performed -= OnCast1;
        _playerActions.Gameplay.Attack1.performed -= OnAttack;
        _playerActions.Gameplay.MovementDirection.performed -= MovementDirection_performed;
        _playerActions.Gameplay.Sprint.performed -= Sprint_Performed;
        
        _playerActions.Gameplay.Jump.performed -= Jump_performed;
    }
    private void Jump_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Jump pressed");
        _entityStateMachine.OnJump();
    }
    

    private void Sprint_Performed(InputAction.CallbackContext context)
    {
        float sprintInput = context.ReadValue<float>();

        if (sprintInput == 1)
        {
            Debug.Log("Sprint began");
        }
        else
        {
            Debug.Log("Sprint ended");
        }
    }

    private void MovementDirection_performed(InputAction.CallbackContext context)
    {
        
        Vector2 movementInput = context.ReadValue<Vector2>();
        ///Debug.Log(movementInput);
        _entityStateMachine.Move(movementInput);
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        ///Debug.Log(context.performed);
        _entityStateMachine.Attack();
    }

    private void OnCast1(InputAction.CallbackContext context)
    {
        _entityStateMachine.revive();
    }

    private void OnShield(InputAction.CallbackContext context)
    {
        float shieldInput = context.ReadValue<float>();

        if (shieldInput == 1)
        {
            _entityStateMachine.startBlock();
        }
        else
        {
            _entityStateMachine.endBlock();
        }
    }
   

    
    

}
