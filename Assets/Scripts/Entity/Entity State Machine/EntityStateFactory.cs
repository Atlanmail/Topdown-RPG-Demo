using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateFactory
{
    EntityStateMachine _context;
    public EntityStateFactory(EntityStateMachine context)
    {
        _context = context;
    }

    public virtual EntityBaseState Idle()
    {
        return new EntityIdleState(_context, this);
    }
    public virtual EntityBaseState Walk()
    {
        return new EntityWalkState(_context, this);
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
