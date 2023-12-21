using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IDamagable
{
    

    [SerializeField] InteractableData interactableData;
    /// <summary>
    ///  hurtbox managers
    /// </summary>
    HurtboxManager _manager;

    private float _currentHealth;

    public float currentHealth { get { return _currentHealth; } }
    public float maxHealth { get { return interactableData.MaxHealth; } }
    
    void Start()
    {
        _currentHealth = interactableData.MaxHealth;

        _manager = GetComponent<HurtboxManager>();
        _manager.OnTakeDamage += onDamage;
    }

    void OnEnable()
    {

        if ( _manager != null )
        {
            _manager.OnTakeDamage += onDamage;
        }
        
    }

    void OnDisable()
    {
        _manager.OnTakeDamage -= onDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void onDamage(EntityData entityData, AttackData attackData)
    {
        damage(attackData);
    }
    public void damage(AttackData attackData)
    {

        float damageAmount = attackData.physicalDamage;
        _currentHealth -= damageAmount;

        Debug.Log(this + " " + _currentHealth);
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            die();
        }
    }

    public void die()
    {
        Debug.Log("I died");
    }
}
