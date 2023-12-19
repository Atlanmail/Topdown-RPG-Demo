using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


/**
 * 
 * hurtbox that fires an event if .damage is called on it.
 * 
 */
public class Hurtbox : MonoBehaviour
{
    Collider _collider;

    /// <summary>
    /// EntityStateMachine _entityStateMachine;
    /// </summary>
    
    HurtboxManager _manager;

    public bool isActive { get { return _collider.enabled; } }
    public HurtboxManager Manager { get { return _manager; } set { _manager = value; } }
    ///public EntityData EntityData { get { return _entityData; } }
    public Collider BoxCollider { get { return _collider; } }
    void Awake()
    {
        _collider = GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void Enable()
    {
        _collider.enabled = true;
    }

    public void Disable()
    {
        _collider.enabled = false;
    }

    public virtual void Damage(EntityData entity, AttackData damage)
    {
        Manager.takeDamage(entity, damage);
    }

    
}
