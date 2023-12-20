using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableData", menuName = "Data/InteractableData")]
public class InteractableData : ScriptableObject, IDamagable
{
    // health
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    /// hasLoaded
    /// 
    private bool hasLoaded = false;

    /// <summary>
    ///  getters and setters
    /// </summary>
    public float currentHealth { get { return _currentHealth; } }
    public float maxHealth { get { return _maxHealth; } }

    private void OnEnable()
    {
        if (!hasLoaded)
        {
            onLoad();
        }
        
    }

    public void onLoad()
    {
        _currentHealth = _maxHealth;
        hasLoaded = true;
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
