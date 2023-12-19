using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    HurtboxManager _manager;
    
    void Start()
    {
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
        Debug.Log("Hit by: " + attackData + " from " + entityData);
    }
}
