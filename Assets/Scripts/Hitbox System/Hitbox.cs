using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    Collider _collider;

    List<Collider> _ignoredColliders;

    EntityData _entityData;
    EntityStateMachine _entityStateMachine;

    public bool isActive { get { return _collider.enabled; } }
    public EntityData EntityData { get { return _entityData; } }
    
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
        _entityStateMachine = transform.root.GetComponent<EntityStateMachine>();
        _entityData = _entityStateMachine.entityData;
        
    }

    public delegate void CollisionEventHandler(GameObject gameObject); /// <summary>
    ///  event that gives the other gameobject
    /// </summary>
    public event CollisionEventHandler OnEnterCollision;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        
        GameObject otherGameObject = other.gameObject;
        OnEnterCollision?.Invoke(otherGameObject);


        /**Hurtbox hurtboxHit = otherGameObject.GetComponent<Hurtbox>();

        if (hurtboxHit != null)
        {
            hurtboxHit.Damage()
        }*/
    }

    public void addIgnoreCollider()
    {

    }

    public void colliderEnable()
    {
        _collider.enabled = true;
    }

    public void colliderDisable()
    {
        _collider.enabled = false;
    }
}
