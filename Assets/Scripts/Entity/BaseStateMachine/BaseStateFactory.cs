using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using System;

namespace BaseStateMachine
{
    /*
     * BaseStateFactory, 
     * 
     */
    public class BaseStateFactory

    {
        protected StateMachine _context;

        protected Dictionary<string, BaseState> _states;
        public BaseStateFactory(StateMachine context)
        {
            _context = context;
            _states = new Dictionary<string, BaseState>();
        }

        public virtual BaseState Default()
        {
            throw new NotImplementedException();
        }

        protected T GetOrCreateState<T>() where T : BaseState, new()
        {
            string typeName = typeof(T).Name;

            BaseState state;

            if (!_states.TryGetValue(typeName, out state) || state == null)
            {
                // If the state doesn't exist or is null, create a new instance
                state = new T();
                _states[typeName] = state;
            }

            return state as T;
        }

        
    }
}