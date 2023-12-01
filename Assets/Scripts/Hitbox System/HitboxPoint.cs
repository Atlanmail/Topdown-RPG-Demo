using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxPoint : MonoBehaviour
{

    [SerializeField] bool _trailEnabled = false;
    TrailRenderer _trailRenderer;


    Hitbox _hitbox;
    private bool _enabled = false;
    private float rayCooldown = 0;
    private float rayCooldownFrames = 4; /// <summary>
    ///  how many frames before another raycast.
    /// </summary>
    // Start is called before the first frame update


    void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();

        _trailRenderer.enabled = _trailEnabled;
    }

    void Start()
    {

    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void handleCasting()
    {
        
    }

    void enable()
    {
       
    }
    void disable()
    {
        
    }

    
}

