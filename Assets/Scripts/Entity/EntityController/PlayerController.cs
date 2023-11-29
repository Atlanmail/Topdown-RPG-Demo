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
        _entityStateMachine.Move(movementInput);
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        _entityStateMachine.Attack();
    }

    private void OnCast1(InputAction.CallbackContext context)
    {
        Debug.Log("Cast1 pressed");
    }

   

    
    

}
