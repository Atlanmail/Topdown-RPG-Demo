using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "EntityData", menuName = "Data/EntityData")]

public class EntityData : ScriptableObject
{
    [SerializeField] protected float _speed = 5f;
    /// <summary>
    /// protected Vector2 _movementInput;
    /// </summary>
    protected float _rotationFactorPerFrame = 15f;

    /// health variables
    /// 

    public float _maxHealth;
    private float _currentHealth;

    /// attack variables
    /// 
    public bool attackButtonPressed = false;
}
