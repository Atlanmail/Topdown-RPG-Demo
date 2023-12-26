using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHealthController : MonoBehaviour
{
    [SerializeField] EntityStateMachine _entityStateMachine;
    HealthBar healthbar;
    void Start()
    {
        EntityData entityData = _entityStateMachine.entityData;
        healthbar = GetComponent<HealthBar>();

        healthbar.setEntityData(entityData);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
