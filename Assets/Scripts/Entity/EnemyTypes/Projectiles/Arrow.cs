using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject body;
    Hitbox hitbox;

    Rigidbody rb;


    EntityData data; ///the entity that fired this
    AttackData attackData; 

    private float speed = 10f;
    private int delay = 10;

    [SerializeField] public static GameObject defaultArrow;

    private void Awake()
    {
        body = gameObject.transform.Find("Body").gameObject;
        hitbox = gameObject.GetComponentInChildren<Hitbox>();
        rb = GetComponent<Rigidbody>();
        defaultArrow = gameObject;
        
    }

    private void Start()
    {
        hitbox.colliderDisable();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        hitbox.OnEnterCollision -= onHitboxCollision;
    }

    private void FixedUpdate()
    {
        delay--;

        if (delay <= 0)
        {
            hitbox.colliderEnable();
            hitbox.OnEnterCollision += onHitboxCollision;
        }
    }


    public Arrow Clone()
    {
        GameObject clone = Instantiate(gameObject);
        clone.transform.position = new Vector3 (0, 0, 0);
        clone.GetComponent<Arrow>().delay = 10;
        return clone.GetComponent<Arrow>();
    }

    public void setSpeed(float value)
    {
        speed = value;
    }
    public void setPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void setPosition(float x, float y, float z)
    {
        setPosition(new Vector3(x, y, z)); 
    }
    /// <summary>
    /// has the projectile face a certain position.
    /// </summary>
    /// <param name="positionToFace"></param>
    public void facePosition(Vector3 positionToFace)
    {
        transform.LookAt(positionToFace);
    }

    public void facePosition(float x, float y, float z)
    {
        facePosition(new Vector3(x, y, z));
    }

    public void startMoving()
    {
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }

    private void onHitboxCollision(GameObject otherGameObject)
    {
        Hurtbox hurtboxHit = otherGameObject.GetComponent<Hurtbox>();
        ///Debug.Log(otherGameObject);
        if (hurtboxHit != null)
        {
            ///Debug.Log("Hit hurtbox");
            hurtboxHit.Damage(data, attackData);
            
        }
        Destroy(gameObject);
    }

    public void setAttackData(AttackData attackData)
    {
        this.attackData = attackData;
        
    }

    public void setEntityData (EntityData entityData)
    {
        this.data = entityData;
    }

    

}
