using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{

    float maxHealth { get; set; }

    float currentHealth { get; set; }

    void damage(float damageAmount);

    void die();

}