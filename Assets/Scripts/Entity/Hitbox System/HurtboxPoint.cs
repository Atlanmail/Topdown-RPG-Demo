using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxPoint : MonoBehaviour
{

    [SerializeField] bool _trailEnabled = false;
    TrailRenderer _trailRenderer;


    Hurtbox _hurtbox;
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
        _hurtbox = GetComponentInParent<Hurtbox>();

        _hurtbox.hurtboxEnable += enable;
        _hurtbox.hurtboxDisable += disable;
    }

    void OnDisable()
    {
        _hurtbox.hurtboxEnable -= enable;
        _hurtbox.hurtboxDisable -= disable;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (_enabled)
        {
            handleCasting();
        }
        else
        {
            _trailRenderer.enabled = false;
            _trailRenderer.Clear();
        }
    }

    void handleCasting()
    {
        _trailRenderer.enabled = true;
    }

    void enable()
    {
        _enabled = true;
    }
    void disable()
    {
        _enabled = false;
    }

    
}

