using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "EntityData", menuName = "Data/EntityData")]

public class EntityData : ScriptableObject,  IDamagable
{
    
   
    /// health variables
    /// 

    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    /// attack variables
    /// 

    [SerializeField] private float _attackPower;
    
    //

    /// speed variables
    [SerializeField] private float _speed;
    public float rotationSpeed = 15f;

    private bool hasLoaded = false;

    /// jump variables
    /// 
    [SerializeField] private int _jumpFrames = 24; /// frames jump will last
    private float _jumpHeight = 3.5f; /// jump height
    /// important variables idk
    int damageLastTakenFrame;
    [SerializeField] int damageTakenCooldown = 1; /// frames since damageLastTaken
    /// <summary>
    /// getters and setters
    /// </summary>
    public float currentHealth { get { return _currentHealth; } }
    public float maxHealth { get { return _maxHealth; } }

    public float speed { get { return _speed; } }

    public float attackPower { get { return _attackPower; } }
    public float jumpHeight { get { return _jumpHeight; } }
    public int jumpFrames { get { return _jumpFrames; } }


    [SerializeField] public AttackData attackData;
    /// <summary>
    /// events
    /// </summary>

    public delegate void StaggerEventHandler();
    public event StaggerEventHandler OnStagger;

    public delegate void DeathEventHandler();
    public event DeathEventHandler OnDeath;

    public delegate void HealthChangedEventHandler(float changeAmount);
    public event HealthChangedEventHandler OnHealthChanged;

    public void damage(AttackData attackData)
    {
       if (Time.frameCount - damageLastTakenFrame < damageTakenCooldown)
        {
            return;
        }

       damageLastTakenFrame = Time.frameCount;

        float damageAmount = attackData.physicalDamage;
        
        _currentHealth -= damageAmount;

        
        ///Debug.Log(this + " " + _currentHealth);
        if (_currentHealth <= 0.2f )
        {
            OnHealthChanged?.Invoke(damageAmount + _currentHealth);
            _currentHealth = 0;
            die();
        }
        else
        {
            OnHealthChanged?.Invoke(damageAmount);
            stagger();
        }

        

        
    }

    public void die()
    {

        ///Debug.Log("die");
        OnDeath?.Invoke();
    }


    /// <summary>
    /// sets the entityData to a default state
    /// </summary>
    public void initialize()
    {
        _currentHealth = maxHealth;
        damageLastTakenFrame = Time.frameCount;
    }
    public EntityData Clone()
    {
        EntityData clone = ScriptableObject.CreateInstance<EntityData>();
        clone._maxHealth = this._maxHealth;
        clone._attackPower = this._attackPower;
        clone._speed = this._speed;
        clone.rotationSpeed = this.rotationSpeed;
        clone.attackData = this.attackData; // Make sure to handle this if AttackData needs to be cloned as well
        clone.hasLoaded = false;
        clone.damageTakenCooldown = this.damageTakenCooldown;
        clone.initialize();

        return clone;
    }

    public void stagger()
    {
        OnStagger?.Invoke();
    }

    
}
