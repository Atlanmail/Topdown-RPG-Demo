using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : EntityController
{

    [SerializeField] NPCBehavior behavior;

    private void Awake()
    {
        _entityStateMachine = GetComponent<EntityStateMachine>();

        behavior = new AttackBehavior(this);

        ///behavior.setController(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        behavior.Update();
    }

    private void FixedUpdate()
    {
        behavior.FixedUpdate();
    }

    public void onAttack()
    {
        _entityStateMachine.Attack();
    }

    public void moveTo(Vector3 position)
    {
        _entityStateMachine.MoveTo(position);
    }
}
