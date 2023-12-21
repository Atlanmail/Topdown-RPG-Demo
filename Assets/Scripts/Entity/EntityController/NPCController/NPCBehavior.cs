using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class NPCBehavior
{

    protected NPCController _controller;

    public abstract void onEnter();
    public abstract void FixedUpdate();
    public abstract void Update();

    public abstract void SwitchState();

    public void setController(NPCController controller)
    {
        _controller = controller;
    }
}
