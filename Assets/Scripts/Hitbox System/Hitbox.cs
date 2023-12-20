using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    Collider _collider;

    private List<Collider> _ignoredColliders;
    private List<CharacterController> _ignoredControllers;

    EntityData _entityData;
    EntityStateMachine _entityStateMachine;

    public bool isActive { get { return _collider.enabled; } }
    public EntityData EntityData { get { return _entityData; } }
    public Collider BoxCollider { get => _collider; }
    // Start is called before the first frame update

    private void Awake()
    {
        instantiateIgnoredList();
        _collider = GetComponent<Collider>();
    }
    void Start()
    {
       
        _entityStateMachine = transform.root.GetComponent<EntityStateMachine>();
        _entityData = _entityStateMachine.entityData;
        
    }

    public delegate void CollisionEventHandler(GameObject gameObject); /// <summary>
    ///  event that gives the other gameobject
    /// </summary>
    public event CollisionEventHandler OnEnterCollision;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Hit " + other.gameObject);
        GameObject otherGameObject = other.gameObject;
        OnEnterCollision?.Invoke(otherGameObject);


        /**Hurtbox hurtboxHit = otherGameObject.GetComponent<Hurtbox>();

        if (hurtboxHit != null)
        {
            hurtboxHit.Damage()
        }*/
    }

    public void addIgnoreCollider(Collider colliderToIgnore)
    {
        instantiateIgnoredList();
        _ignoredColliders.Add(colliderToIgnore);
        ///Debug.Log("Ignored" + colliderToIgnore);
        ///Debug.Log(_ignoredColliders.Count);
        
    }

    public void addIgnoreController(CharacterController controllerToIgnore)
    {
        instantiateIgnoredList();
        _ignoredControllers.Add(controllerToIgnore);
    }

    public void addIgnoreColliders(HurtboxManager hurtboxManager)
    {
        ///instantiateIgnoredList();

        List<Hurtbox> list = hurtboxManager.hurtboxList;
        
        if (list == null)
        {
            Debug.Log("Hurtbox List == null");
            return;
        }

        foreach (Hurtbox hurtbox in list)
        {
            Collider collider = hurtbox.BoxCollider;
            addIgnoreCollider(collider);
        }

    }

    public void addIgnoreColliders(BlockboxManager blockboxManager)
    {
        instantiateIgnoredList();
        

        if (blockboxManager.BlockboxList == null)
        {
            return;
        }

        List<Blockbox> list = blockboxManager.BlockboxList;
        foreach (Blockbox blockbox in list)
        {
            Collider collider = blockbox.BoxCollider;
            addIgnoreCollider(collider);
        
        }
    }

    public void colliderEnable()
    {
        _collider.enabled = true;

        foreach (Collider colliderToIgnore in _ignoredColliders) {
            Physics.IgnoreCollision(_collider, colliderToIgnore, true);
        }

        foreach (CharacterController controller in _ignoredControllers) {
            Physics.IgnoreCollision(_collider, controller, true);
        }
    }

    public void colliderDisable()
    {
        _collider.enabled = false;
    }
    
    private void instantiateIgnoredList()
    {
        if (_ignoredColliders == null)
        {
            _ignoredColliders = new List<Collider> ();
        }

        if (_ignoredControllers == null)
        {
            _ignoredControllers = new List<CharacterController>();
        }
    }

}
