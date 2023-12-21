using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : EntityController
{

    private void Awake()
    {
        _entityStateMachine = GetComponent<EntityStateMachine>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
