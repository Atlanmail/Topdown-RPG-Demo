using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : EntityController
{
    public enum Behavior
    {
        Attack,
        Archer,
        Boss
    }
    [SerializeField] private Behavior startingBehavior;
    NPCBehavior _behavior;
    Transform _transform;


    public Transform Transform { get { return _transform; } }

    private void Awake()
    {
        _entityStateMachine = GetComponent<EntityStateMachine>();

        if (startingBehavior == Behavior.Attack)
        {
            _behavior = new AttackBehavior(this);
        }
        else if (startingBehavior == Behavior.Archer)
        {
            _behavior = new ArcherBehavior(this);
        }
        else if (startingBehavior == Behavior.Boss)
        {
            ///_behavior = new BossBehavior(this);
        }
        _transform = transform;

        ///behavior.setController(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _behavior.Update();
    }

    private void FixedUpdate()
    {
        _behavior.FixedUpdate();
    }

    public void onAttack()
    {
        _entityStateMachine.Attack();
    }

    public void moveTo(Vector3 position)
    {
        _entityStateMachine.MoveTo(position);
    }

    public void facePosition(Vector3 position)
    {
        Vector3 shortPosition = (position - _entityStateMachine.transform.position);
        shortPosition.y = 0;

        shortPosition = shortPosition.normalized*1f;
        _entityStateMachine.MoveTo(shortPosition + _entityStateMachine.transform.position);
    }
}
