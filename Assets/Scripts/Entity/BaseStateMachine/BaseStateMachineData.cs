using UnityEditor;
using UnityEngine;

namespace BaseStateMachine
{
    public abstract class BaseStateMachineData : ScriptableObject
    {
        public abstract void initialize();

        public abstract BaseStateMachineData Clone();
    }
}