using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    Collider _collider;

    List<Collider> _ignoredColliders;

    EntityStateMachine _entity;
    EntityAttackState _attackState;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }

    public void addIgnoreColliders()
    {

    }
}
