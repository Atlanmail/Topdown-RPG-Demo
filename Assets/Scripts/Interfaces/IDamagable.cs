using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{

    float maxHealth { get; }

    float currentHealth { get; }

    void damage(float damageAmount);

    void die();

}