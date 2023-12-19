using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollideBox : MonoBehaviour
{
    protected Collider _collider;
    protected EntityData _entityData;
    /// <summary>
    /// protected EntityStateMachine _entityStateMachine;
    /// </summary>

        

    public abstract bool IsActive { get; } // Abstract property for activation status

    protected virtual void Start()
    {
        _collider = GetComponent<Collider>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }

    public virtual void ColliderEnable()
    {
        _collider.enabled = true;
    }

    public virtual void ColliderDisable()
    {
        _collider.enabled = false;
    }
}
