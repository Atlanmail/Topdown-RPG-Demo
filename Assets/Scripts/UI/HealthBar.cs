using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _healthbarSlider;

    private EntityData _entityData;

    private float maxHealth;
    private float currentHealth;
    private void Awake()
    {
        _healthbarSlider = GetComponent<Slider>();

    }

    void Start()
    {
        
    }

    private void OnDisable()
    {
        _entityData.OnHealthChanged -= onHealthUpdate;
    }

    // Update is called once per frame
    void Update()   
    {
        
    }

    void onHealthUpdate(float changeAmount)
    {
        currentHealth = _entityData.currentHealth;

        if (currentHealth < 0) 
        {
            currentHealth = 0;
        }
        ///Debug.Log("Current percent health: " + (currentHealth / maxHealth));
        _healthbarSlider.value = (currentHealth/maxHealth);
    }

    public void setEntityData (EntityData entityData)
    {
        if (_entityData != null)
        {
            _entityData.OnHealthChanged -= onHealthUpdate;
        }
        _entityData = entityData;
        currentHealth = entityData.currentHealth;
        maxHealth = entityData.maxHealth;
        _entityData.OnHealthChanged += onHealthUpdate;

    }
}
