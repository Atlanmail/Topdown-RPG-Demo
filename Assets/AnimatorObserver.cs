using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorObserver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private EntityStateMachine _entityStateMachine;

    public EntityStateMachine EntityStateMachine { get { return _entityStateMachine; } }
    void Awake()
    {
        if (EntityStateMachine == null)
        {
            _entityStateMachine = this.GetComponentInParent<EntityStateMachine>();
        }
    }

/// <summary>
///  called when attack windup begins
/// </summary>
    public void onAttackWindupStart()
    {
        _entityStateMachine.onAttackWindupStart();
    }
    /// <summary>
    /// called when attack animation begins
    /// </summary>
    public void onAttackAnimationStart() 
    {
        _entityStateMachine.onAttackAnimationStart();
    }
    /// <summary>
    /// called when attack animation ends, aka attack recovery start
    /// </summary>
    public void onAttackAnimationEnd()
    {
        _entityStateMachine.onAttackAnimationEnd();
    }
    /// <summary>
    /// called when attack recovery ends.
    /// </summary>
    public void onAttackAnimationRecovered()
    {
        _entityStateMachine.onAttackAnimationRecovered();
    }
}
