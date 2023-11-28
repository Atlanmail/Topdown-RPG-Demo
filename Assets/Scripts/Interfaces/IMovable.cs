using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    public float speed { get; set; }

    /**
     * given a direction vector, start moving in that direction
     * 
     */
    void Move(Vector2 directionVector);

    void Shove(Vector3 positionChange, float timeElapsed);

    Quaternion getFaceDirection();
}