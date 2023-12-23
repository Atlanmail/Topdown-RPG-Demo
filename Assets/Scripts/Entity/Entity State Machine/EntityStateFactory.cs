using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using System;
using Assets.Scripts.Entity.Entity_State_Machine;

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
            _states["Walk"] = state;
        }

        return state;
    }


    public virtual EntityAttackState Attack() {
        EntityBaseState state;

        if (!_states.TryGetValue("Attack", out state) || state == null)
        {
            // If "Idle" state does not exist or is null, create a new state
            state = new EntityAttackState(_context, this);
            _states["Attack"] = state;
        }

        return state as EntityAttackState;
    }

    public virtual EntityStaggerState Stagger()
    {
        EntityBaseState state;

        if (!_states.TryGetValue("Stagger", out state) || state == null)
        {
            // If "Idle" state does not exist or is null, create a new state
            state = new EntityStaggerState(_context, this);
            _states["Stagger"] = state;
        }

        return state as EntityStaggerState;
    }

    public virtual EntityDeathState Death()
    {
        EntityBaseState state;

        if (!_states.TryGetValue("Death", out state) || state == null)
        {
            // If "Idle" state does not exist or is null, create a new state
            state = new EntityDeathState(_context, this);
            _states["Death"] = state;
        }

        return state as EntityDeathState;
    }

    public virtual EntityBlockState Block()
    {
        EntityBaseState state;

        if (!_states.TryGetValue("Block", out state) || state == null)
        {
            // If "Idle" state does not exist or is null, create a new state
            state = new EntityBlockState(_context, this);
            _states["Block"] = state;
        }

        return state as EntityBlockState;
    }

    public virtual EntityGroundedState Grounded()
    {
        EntityBaseState state;
        if (!_states.TryGetValue("Grounded", out state) || state == null)
        {
            state = new EntityGroundedState(_context, this);
            _states["Grounded"] = state;
        }

        return state as EntityGroundedState;
    }

    public virtual EntityAirborneState Airborne()
    {
        EntityBaseState state;
        if (!_states.TryGetValue("Airborne", out state) || state == null)
        {
            state = new EntityAirborneState(_context, this);
            _states["Airborne"] = state;
        }

        return state as EntityAirborneState;
    }

    public virtual EntityJumpState Jump()
    {
        EntityBaseState state;
        if (!_states.TryGetValue("Jump", out state) || state == null)
        {
            state = new EntityJumpState(_context, this);
            _states["Jump"] = state;
        }

        return state as EntityJumpState;
    }

    public virtual EntityFallingState Fall()
    {
        EntityBaseState state;
        if (!_states.TryGetValue("Fall", out state) || state == null)
        {
            state = new EntityFallingState(_context, this);
            _states["Fall"] = state;
        }

        return state as EntityFallingState;
    }
}
