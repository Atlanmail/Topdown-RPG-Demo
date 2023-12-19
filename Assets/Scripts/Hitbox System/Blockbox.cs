using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockbox : MonoBehaviour
{
    Collider _collider;

    /// <summary>
    /// EntityStateMachine _entityStateMachine;
    /// </summary>

    BlockboxManager _manager;

    public bool isActive { get { return _collider.enabled; } }
    public BlockboxManager Manager { get { return _manager; } set { _manager = value; } }
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

    public virtual void Damage(EntityData entityData, AttackData attackData)
    {
        Manager.takeDamage(entityData, attackData);
    }
}
