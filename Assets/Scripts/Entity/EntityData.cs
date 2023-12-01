using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EntityData", order = 1)]
public class EntityData : ScriptableObject
{
    [SerializeField] protected float _speed = 5f;
    /// <summary>
    /// protected Vector2 _movementInput;
    /// </summary>
    protected float _rotationFactorPerFrame = 15f;

    /// health variables
    /// 

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    /// attack variables
    /// 
    ///private bool _attackButtonPressed = false;
}
