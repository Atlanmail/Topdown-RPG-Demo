using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using System;

public class EntityStateFactory
{
    protected EntityStateMachine _context;

    protected Dictionary<string, EntityBaseState> _states;
    public EntityStateFactory(EntityStateMachine context)
    {
        _context = context;
        _states = new Dictionary<string, EntityBaseState>();
    }

    public virtual EntityBaseState Idle()
    {
        EntityBaseState state;

        if (!_states.TryGetValue("Idle", out state) || state == null)
        {
            // If "Idle" state does not exist or is null, create a new state
            state = new EntityIdleState(_context, this);
            _states["Idle"] = state;
        }

        return state;
    }
    public virtual EntityBaseState Walk()
    {
        EntityBaseState state;

        if (!_states.TryGetValue("Walk", out state) || state == null)
        {
            // If "Idle" state does not exist or is null, create a new state
            state = new EntityWalkState(_context, this);
            _states["Idle"] = state;
        }

        return state;
    }

    public virtual EntityBaseState Jump()
    {
        return new EntityJumpState(_context, this);
    }

    public virtual EntityBaseState Grounded()
    {
        return new EntityGroundedState(_context, this);
    }

    public virtual EntityBaseState Run()
    {
        return new EntityRunState(_context, this);
    }

    public virtual EntityBaseState Attack() {
        return new EntityAttackState(_context, this);
    }
}
