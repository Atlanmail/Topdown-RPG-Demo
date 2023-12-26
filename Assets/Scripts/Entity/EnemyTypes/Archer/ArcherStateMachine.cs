using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherStateMachine : EntityStateMachine
{
    /// <summary>
    /// ArcherStateFactory _archerStates;
    /// </summary>
    protected override void stateFactorySetup()
    {
        Debug.Log("New archer");
        ///_archerStates = new ArcherStateFactory(this);
        _states = new ArcherStateFactory(this);
        
    }

    public override void onAttackWindupStart()
    {
        if (_currentState is IAttackState)
        {
            ArcherAttackState myState = _currentState as ArcherAttackState;
            myState.onAttackWindupStart();
        }
        else if (_currentState.currentSubState is IAttackState)
        {
            ArcherAttackState myState = _currentState.currentSubState as ArcherAttackState;
            myState.onAttackWindupStart();
        }
    }

    public override void onAttackAnimationStart()
    {
        if (_currentState is IAttackState)
        {
            ArcherAttackState myState = _currentState as ArcherAttackState;
            myState.onAttackAnimationStart();
        }
        else if (_currentState.currentSubState is IAttackState)
        {

            ArcherAttackState myState = _currentState.currentSubState as ArcherAttackState;
            Debug.Log(myState + "");
            myState.onAttackAnimationStart();
        }
    }

    public override void onAttackAnimationEnd()
    {
        if (_currentState is IAttackState)
        {
            ArcherAttackState myState = _currentState as ArcherAttackState;
            myState.onAttackAnimationEnd();
        }
        else if (_currentState.currentSubState is IAttackState)
        {
            ArcherAttackState myState = _currentState.currentSubState as ArcherAttackState;
            myState.onAttackAnimationEnd();
        }
    }

    public override void onAttackAnimationRecovered()
    {
        if (_currentState is EntityAttackState)
        {
            ArcherAttackState myState = _currentState as ArcherAttackState;
            myState.onAttackAnimationRecovered();
        }
        else if (_currentState.currentSubState is IAttackState)
        {
            ArcherAttackState myState = _currentState.currentSubState as ArcherAttackState;
            myState.onAttackAnimationRecovered();
        }
    }
}
