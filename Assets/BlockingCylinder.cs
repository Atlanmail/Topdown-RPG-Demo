using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingCylinder : MonoBehaviour
{

    BlockboxManager m_BlockboxManager;
    // Start is called before the first frame update
    void Start()
    {
        m_BlockboxManager = GetComponent<BlockboxManager>();
        m_BlockboxManager.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
