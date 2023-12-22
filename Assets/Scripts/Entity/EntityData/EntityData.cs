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

    /// <summary>
    /// getters and setters
    /// </summary>
    public float currentHealth { get { return _currentHealth; } }
    public float maxHealth { get { return _maxHealth; } }

    public float speed { get { return _speed; } }

    public float attackPower { get { return _attackPower; } }

    [SerializeField] public AttackData attackData;
    /// <summary>
    /// events
    /// </summary>

    public delegate void StaggerEventHandler();
    public event StaggerEventHandler OnStagger;

    public delegate void DeathEventHandler();
    public event DeathEventHandler OnDeath;

    public void damage(AttackData attackData)
    {

        float damageAmount = attackData.physicalDamage;
        _currentHealth -= damageAmount;

        Debug.Log(this + " " + _currentHealth);
        if (_currentHealth <= 0.2f )
        {
            _currentHealth = 0;
            die();
        }

        stagger();
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
        clone.initialize();

        return clone;
    }

    public void stagger()
    {
        OnStagger?.Invoke();
    }

    
}
