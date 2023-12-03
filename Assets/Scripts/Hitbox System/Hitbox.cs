using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    Collider _collider;

    List<Collider> _ignoredColliders;

    [SerializeField] EntityData _entityData;
    EntityStateMachine _entityStateMachine;


    public EntityData EntityData { get { return _entityData; } }

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
        _entityData = _entityStateMachine.entityData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;

        Hurtbox hurtboxHit = otherGameObject.GetComponent<Hurtbox>();

        if (hurtboxHit != null)
        {
            Debug.Log(hurtboxHit);
        }
    }

    public void addIgnoreColliders()
    {

    }
}
