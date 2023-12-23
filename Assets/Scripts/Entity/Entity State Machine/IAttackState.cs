using System.Collections;
using UnityEngine;

public interface IAttackState
{

    public int attackState { get; }
    public void onAttackWindupStart();

    public void onAttackAnimationStart();

    public void onAttackAnimationEnd();

    public void onAttackAnimationRecovered();
}
