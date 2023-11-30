using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanAttack
{
    void Attack();

    void onAttackWindupStart();
    /// <summary>
    /// called when attack animation begins
    /// </summary>
    void onAttackAnimationStart();
    /// <summary>
    /// called when attack animation ends, aka attack recovery start
    /// </summary>
    void onAttackAnimationEnd();
    /// <summary>
    /// called when attack recovery ends.
    /// </summary>
    void onAttackAnimationRecovered();
}