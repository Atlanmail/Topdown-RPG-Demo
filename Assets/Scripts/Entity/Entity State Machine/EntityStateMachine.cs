using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EntityStateMachine : MonoBehaviour, ICanAttack, IMoveable
{


    [SerializeField] private EntityData _entityData;

    /// <summary>
    /// controllers
    /// </summary>
    private CharacterController _charController;
    [SerializeField] private Animator _animator;
    [SerializeField] private EntityController _entityController;
    

    /// <summary>
    /// state factory
    /// </summary>
    [SerializeField] protected EntityBaseState _currentState;
    EntityStateFactory _states;
    /// movement variables

    
    protected Vector2 _movementInput;

    /// <summary>
    /// collidebox managers
    /// </summary>
    protected HurtboxManager _hurtboxManager;
    protected BlockboxManager _blockboxManager;

    /// <summary>
    /// input variables
    /// </summary>
    protected bool _attackButtonPressed = false;
    [SerializeField] protected Hitbox _attackHitbox;
    protected AttackData _attackData;
    protected bool _isStaggered = false;
    protected bool _isDead = false;

    protected bool _blockButtonPressed = false;
    protected bool _jumpButtonPressed = false;

    /// <summary>
    /// getters and setters
    /// </summary>
    public EntityBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
  
    public CharacterController charController { get => _charController; }

    public Vector2 movementInput { get => _movementInput; set => _movementInput = value; }
    public Animator Animator { get => _animator; }

    public float rotationSpeed { get => _entityData.rotationSpeed; }

    public bool attackButtonPressed { get => _attackButtonPressed; set => _attackButtonPressed = value; }

    public bool blockButtonPressed { get => _blockButtonPressed; }
    public bool jumpButtonPressed { get { return _jumpButtonPressed; } }
    public EntityData entityData { get => _entityData; }
    public float speed { get => _entityData.speed;}

    public float maxHealth => ((IDamagable)_entityData).maxHealth;

    public float currentHealth => ((IDamagable)_entityData).currentHealth;
    
    
    public Hitbox attackHitbox { get => _attackHitbox; }
    public AttackData attackData { get => _attackData; }

    public HurtboxManager hurtboxManager { get => _hurtboxManager; }
    public BlockboxManager blockboxManager { get => _blockboxManager; }

    public bool staggered { get => _isStaggered; }
    public bool isDead { get => _isDead; }

    void Awake()
    {

        /// setup entitydata

        entityDataSetup();
        /// setup char controller
        _charController = GetComponent<CharacterController>();


        /// setup hurtbox manager
        _hurtboxManager = GetComponent<HurtboxManager>();

        /// setup blockbox manager
        /// 
        _blockboxManager = GetComponent<BlockboxManager>();
        // setup state

        _states = new EntityStateFactory(this);
        
        
        
        
    }

    void Start()
    {
        initialize();
        ClearInput();

        /// setup hurtbox manager
        setupHurtboxManager();
        setupBlockboxManager();

        _attackHitbox.addIgnoreColliders(hurtboxManager);
        _attackHitbox.addIgnoreColliders(blockboxManager);
        _attackHitbox.addIgnoreController(_charController);


        /// setup entity data events
        /// 

        _entityData.OnStagger += Stagger;
        _entityData.OnDeath += onDeath;

    }
    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    void Update()
    {
        Debug.Log("Currently in " +_currentState.ToString() + "Substate " + _currentState.currentSubState.ToString());
        
        _currentState.UpdateStates();

        ///Debug.Log(_currentState.ToString());
    }

    void FixedUpdate()
    {
        _currentState.FixedUpdateStates();
    }

    void LateUpdate()
    {
        _currentState.LateUpdateStates();
    }
    protected virtual void initialize()
    {
        _currentState = _states.Grounded();
        _currentState.EnterState();
        _isDead = false;
        _entityData.initialize();
    }

    public void Shove(Vector3 positionChange, float timeElapsed)
    {
        throw new System.NotImplementedException();
    }

    public Quaternion getFaceDirection()
    {
        throw new System.NotImplementedException();
    }

    void setupHurtboxManager()
    {
        _hurtboxManager = GetComponent<HurtboxManager>();
        _hurtboxManager.Enable();
        _hurtboxManager.OnTakeDamage += onDamage;
    }

    void setupBlockboxManager()
    {
        _blockboxManager.Disable();
    }
    void onDamage(EntityData entityData, AttackData damageAmount)
    {
        _entityData.damage(damageAmount);
    }

    public void Move(Vector2 movementInput)
    {
        _movementInput = movementInput;
    }

    public void MoveTo(Vector3 target)
    {
        Vector3 subtractedVector = (target - charController.transform.position);

        Vector2 newMovementInput = new Vector2(subtractedVector.x, subtractedVector.z);

        if (newMovementInput.magnitude < 1f) /// if its only a small change don't move
        {
            _movementInput = Vector2.zero;
        }
        else
        {
            _movementInput = newMovementInput.normalized;
        }
        

    }

    void entityDataSetup()
    {
        _entityData = _entityData.Clone();
    }

    public void Attack()
    {
        ///Debug.Log("Attacked!");
        _attackButtonPressed = true;
    }

    public void Stagger()
    {
        _isStaggered = true;
    }
    public void OnJump()
    {
        ///Debug.Log("On jump " + _jumpButtonPressed);
        Debug.Log("Jump button pressed from onJump");
        _jumpButtonPressed = true;
        ///
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
        if (_currentState is IAttackState)
        {
            IAttackState myState = _currentState as IAttackState;
            myState.onAttackWindupStart();
        }
        else if (_currentState.currentSubState is IAttackState)
        {
            IAttackState myState = _currentState.currentSubState as IAttackState;
            myState.onAttackWindupStart();
        }
    }

    public void onAttackAnimationStart()
    {
        if (_currentState is IAttackState)
        {
            IAttackState myState = _currentState as IAttackState;
            myState.onAttackAnimationStart();
        }
        else if (_currentState.currentSubState is IAttackState)
        {
            IAttackState myState = _currentState.currentSubState as IAttackState;
            myState.onAttackAnimationStart();
        }
    }

    public void onAttackAnimationEnd()
    {
        if (_currentState is IAttackState)
        {
            IAttackState myState = _currentState as IAttackState;
            myState.onAttackAnimationEnd();
        }
        else if (_currentState.currentSubState is IAttackState)
        {
            IAttackState myState = _currentState.currentSubState as IAttackState;
            myState.onAttackAnimationEnd();
        }
    }

    public void onAttackAnimationRecovered()
    {
        if (_currentState is EntityAttackState)
        {
            IAttackState myState = _currentState as IAttackState;
            myState.onAttackAnimationRecovered();
        }
        else if (_currentState.currentSubState is IAttackState)
        {
            IAttackState myState = _currentState.currentSubState as IAttackState;
            myState.onAttackAnimationRecovered();
        }
    }

    public EntityAttackState GetEntityAttackState()
    {
        if (_currentState is EntityAttackState)
        {
            return _currentState as EntityAttackState;
        }
        else
        {
            return _states.Attack();
        }
    }

    public void staggerEnd()
    {
        if (_currentState is EntityStaggerState)
        {
            EntityStaggerState myState = _currentState as EntityStaggerState;
            myState.staggerEnd();
        }
    }

    public void onDeath()
    {
        _isDead = true;
        ///Debug.Log("_isDead " +  _isDead);
    }

    public void startBlock()
    {
        _blockButtonPressed = true;
    }

    public void endBlock()
    {
        _blockButtonPressed = false;
    }

    /// <summary>
    /// refreshes the input whenever a state changes system
    /// </summary>
    public void refreshInput()
    {
        _movementInput = Vector2.zero;
        _blockButtonPressed = false;
        _attackButtonPressed = false;
    }
    /// <summary>
    /// revives the entity, resetting entitydata and giving them back to an idle state.
    /// </summary>
    public void revive()
    {
        _isDead = false;
        _entityData.initialize();
        
    }

    /// <summary>
    /// teleports to a specific transform
    /// </summary>
    /// <param name="target"></param>
    public void bringTo(Transform target)
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
    /// <summary>
    /// clears the input, useful to prevent queued inputs
    /// </summary>
    public void ClearInput()
    {
        Debug.Log("Clear input");
        _jumpButtonPressed = false;
        _blockButtonPressed= false;
        _attackButtonPressed = false;
    }
    /// <summary>
    /// checks if the entity is grounded
    /// </summary>
    /// <returns></returns>
    public bool isGrounded()
    {
        return charController.isGrounded;
    }
}
