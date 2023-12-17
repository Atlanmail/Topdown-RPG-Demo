using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{

    float maxHealth { get; }

    float currentHealth { get; }

    void damage(AttackData damageAmount);

    /// recommend a die function ig

}