using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    

    [SerializeField] InteractableData interactableData;
    /// <summary>
    ///  hurtbox managers
    /// </summary>
    HurtboxManager _manager;

    
    void Start()
    {
        interactableData.onLoad();

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

    void onDamage(EntityData entityData,AttackData attackData)
    {
        interactableData.damage(attackData);
    }
}
