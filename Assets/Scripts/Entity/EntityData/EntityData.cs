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



    /// <summary>
    /// getters and setters
    /// </summary>
    public float currentHealth { get { return _currentHealth; } }
    public float maxHealth { get { return _maxHealth; } }

    public float speed { get { return _speed; } }

    public float attackPower { get { return _attackPower; } }

    [SerializeField] public AttackData attackData;

    public void damage(AttackData attackData)
    {

        float damageAmount = attackData.physicalDamage;
        _currentHealth -= damageAmount;

        Debug.Log(this + " " + _currentHealth);
        if (_currentHealth <= 0 )
        {
            _currentHealth = 0;
            die();
        }
    }

    public void die()
    {
        
    }
}
