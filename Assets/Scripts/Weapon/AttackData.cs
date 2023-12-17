using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AttackData", menuName = "Data/AttackData")]

public class AttackData : ScriptableObject
{
    public float physicalDamage;
    public float fireDamage;
    public float waterDamage;
    public float earthDamage;

}
