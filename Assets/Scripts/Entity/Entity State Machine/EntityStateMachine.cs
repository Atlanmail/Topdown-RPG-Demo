using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateMachine : MonoBehaviour, IMoveable, IDamagable, ICanAttack
{

    /// <summary>
    /// controllers
    /// </summary>
    private CharacterController _charController;
    [SerializeField] private Animator _animator;
    [SerializeField] private EntityController _entityController;

    /// <summary>
    /// state factory
    /// </summary>
    protected EntityBaseState _currentState;
    EntityStateFactory _states;
    /// movement variables

    [SerializeField] protected float _speed = 5f;
    protected Vector2 _movementInput;
    protected float _rotationFactorPerFrame = 15f;

    /// health variables
    /// 

    protected float _maxHealth;
    protected float _currentHealth;

    /// attack variables
    /// 
    protected bool _attackButtonPressed = false;

    /// <summary>
    /// getters and setters
    /// </summary>
    public EntityBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    [SerializeField] public float speed { get => _speed; set => _speed = value; }
    public float maxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float currentHealth { get => _currentHealth; set => _currentHealth = value; }
    public CharacterController charController { get => _charController; }

    public Vector2 movementInput { get => _movementInput; set => _movementInput = value; }
    public Animator Animator { get => _animator; }

    public float rotationFactorPerFrame { get => _rotationFactorPerFrame; }

    public bool attackButtonPressed { get => _attackButtonPressed; set => _attackButtonPressed = value; }

    void Awake()
    {
        // setup state

        _states = new EntityStateFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();

        
        
    }

    void Start()
    {
        /// setup char controller
        _charController = GetComponent<CharacterController>();
    }
    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    void Update()
    {
        ///Debug.Log(_currentState.ToString());
        _currentState.UpdateState();
    }

    void FixedUpdate()
    {
        _currentState.FixedUpdateState();
    }

    void LateUpdate()
    {
        _currentState.LateUpdateState();
    }

    
    public void Shove(Vector3 positionChange, float timeElapsed)
    {
        throw new System.NotImplementedException();
    }

    public Quaternion getFaceDirection()
    {
        throw new System.NotImplementedException();
    }

    public void damage(float damageAmount)
    {
        throw new System.NotImplementedException();
    }

    public void die()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector2 movementInput)
    {
        _movementInput = movementInput;
    }

    public void Attack()
    {
        ///Debug.Log("Attacked!");
        _attackButtonPressed = true;
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

    public void onAttackWindupStart()
    {
        if (_currentState is EntityAttackState)
        {
            EntityAttackState myState = _currentState as EntityAttackState;
            myState.onAttackWindupStart();
        }
    }

    public void onAttackAnimationStart()
    {
        if (_currentState is EntityAttackState)
        {
            EntityAttackState myState = _currentState as EntityAttackState;
            myState.onAttackAnimationStart();
        }
    }

    public void onAttackAnimationEnd()
    {
        if (_currentState is EntityAttackState)
        {
            EntityAttackState myState = _currentState as EntityAttackState;
            myState.onAttackAnimationEnd();
        }
    }

    public void onAttackAnimationRecovered()
    {
        if (_currentState is EntityAttackState)
        {
            EntityAttackState myState = _currentState as EntityAttackState;
            myState.onAttackAnimationRecovered();
        }
    }
}
