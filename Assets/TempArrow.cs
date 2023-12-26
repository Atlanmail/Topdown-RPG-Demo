using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TempArrow : MonoBehaviour
{
    // Start is called before the first frame update
    Arrow arrow;
    Arrow arrow2;
    public bool hasCloned = true;
    void Start()
    {
        arrow = gameObject.GetComponent<Arrow>();
        
        arrow.setPosition(0, 5,0);
        arrow.facePosition(0,0 ,0);
        arrow.startMoving();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
