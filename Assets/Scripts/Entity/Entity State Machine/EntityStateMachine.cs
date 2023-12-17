using System.Collections;
using System.Collections.Generic;
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
    protected EntityBaseState _currentState;
    EntityStateFactory _states;
    /// movement variables

    
    protected Vector2 _movementInput;
    

 

    /// attack variables and hurtboxes
    /// 
    protected bool _attackButtonPressed = false;
    [SerializeField] protected Hitbox _attackHitbox;
    protected AttackData _attackData;
    protected HurtboxManager _hurtboxManager;

    /// <summary>
    /// getters and setters
    /// </summary>
    public EntityBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    
    public CharacterController charController { get => _charController; }

    public Vector2 movementInput { get => _movementInput; set => _movementInput = value; }
    public Animator Animator { get => _animator; }

    public float rotationSpeed { get => _entityData.rotationSpeed; }

    public bool attackButtonPressed { get => _attackButtonPressed; set => _attackButtonPressed = value; }

    

    public EntityData entityData { get => _entityData; }
    public float speed { get => _entityData.speed;}

    public float maxHealth => ((IDamagable)_entityData).maxHealth;

    public float currentHealth => ((IDamagable)_entityData).currentHealth;
    
    
    public Hitbox attackHitbox { get => _attackHitbox; }
    public AttackData attackData { get => _attackData; }
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
        
        
        /// setup hurtbox manager
        _hurtboxManager = GetComponent<HurtboxManager>();
        _hurtboxManager.OnTakeDamage += onDamage;
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

    void onDamage(AttackData damageAmount)
    {
        Debug.Log("Damage taken");
    }

    public void Move(Vector2 movementInput)
    {
        _movementInput = movementInput;
    }

    public void Attack()
    {
        Debug.Log("Attacked!");
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
}
