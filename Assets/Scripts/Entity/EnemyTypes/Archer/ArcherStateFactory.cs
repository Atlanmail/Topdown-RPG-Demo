using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherStateFactory : EntityStateFactory
{
    public ArcherStateFactory(EntityStateMachine context) : base(context)
    {
       // _states["Attack"] = new ArcherAttackState(_context, this);
    }

    public override EntityBaseState Attack()
    {
        Debug.Log("attack from factory");
        EntityBaseState state;

        if (!_states.TryGetValue("Attack", out state) || state == null)
        {
            // If "Idle" state does not exist or is null, create a new state
            state = new ArcherAttackState(_context, this);
            _states["Attack"] = state;
            
        }

        


        return state as EntityBaseState;
    }

    
}
