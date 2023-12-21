using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableData", menuName = "Data/InteractableData")]
public class InteractableData : ScriptableObject
{
    // health
    [SerializeField] private float _maxHealth;
    /// hasLoaded
    /// 

    public float MaxHealth {  get { return _maxHealth; } }
}
