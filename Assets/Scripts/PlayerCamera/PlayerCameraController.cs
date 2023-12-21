using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    // transforms
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;
    private Transform _cameraTransform;

    EntityController _entityController;


    /// <summary>
    /// camera settings
    /// </summary>
    [SerializeField] Vector3 _cameraOffset;
    private float _cameraSpeed = 0.125f;
    private Vector3 cameraVelocity = Vector3.zero;

    //setters and getters

    public Transform target { get { return _target; } set { _target = value; } }

    void Start()
    {
        _cameraTransform = _camera.transform;

        ///_cameraOffset = new Vector3(0, 7, -3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        Vector3 desiredPosition = _target.position + _cameraOffset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(_cameraTransform.position, desiredPosition, ref cameraVelocity, _cameraSpeed);

        _cameraTransform.position = smoothedPosition;
    }

    void HandleRotation()
    {
        Vector3 targetPosition = _cameraTransform.position - _cameraOffset;
        _cameraTransform.LookAt(targetPosition);
    }
}
