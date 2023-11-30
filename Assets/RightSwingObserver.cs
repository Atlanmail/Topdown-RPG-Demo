using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RightSwingObserver : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    // Start is called before the first frame update
    [SerializeField] private EntityStateMachine _entityStateMachine;

    public EntityStateMachine EntityStateMachine { get { return _entityStateMachine; } }
    void Awake()
    {
        if (EntityStateMachine == null)
        {
            ///_entityStateMachine = this.GetComponentInParent<EntityStateMachine>();
        }
    }

    /// <summary>
    ///  called when attack windup begins
    /// </summary>
    public void onAttackWindupStart()
    {
        Debug.Log("Windup start");
    }
    /// <summary>
    /// called when attack animation begins
    /// </summary>
    public void onAttackAnimationStart()
    {
        Debug.Log("Attack animation start");
    }
    /// <summary>
    /// called when attack animation ends, aka attack recovery start
    /// </summary>
    public void onAttackAnimationEnd()
    {
        Debug.Log("Attack animation end");
    }
    /// <summary>
    /// called when attack recovery ends.
    /// </summary>
    public void onAttackAnimationRecovered()
    {
        Debug.Log("Attack animation recovered");
    }
}