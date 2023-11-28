using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateMachine : MonoBehaviour, IMoveable, IDamagable
{

    /// <summary>
    /// controllers
    /// </summary>
    private CharacterController _charController;
    private Animator _animator;
    [SerializeField] private EntityController _entityController;

    /// <summary>
    /// state factory
    /// </summary>
    protected EntityBaseState _currentState;
    EntityStateFactory _states;
    /// movement variables

    [SerializeField] protected float _speed = 5f;
    protected Vector2 _movementInput;

    /// health variables
    /// 

    protected float _maxHealth;
    protected float _currentHealth;
    /// <summary>
    /// getters and setters
    /// </summary>
    public EntityBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    [SerializeField] public float speed { get => _speed; set => _speed = value; }
    public float maxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float currentHealth { get => _currentHealth; set => _currentHealth = value; }
    public CharacterController charController { get => _charController; }

    public Vector2 movementInput { get => _movementInput; set => _movementInput = value; }

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
}
