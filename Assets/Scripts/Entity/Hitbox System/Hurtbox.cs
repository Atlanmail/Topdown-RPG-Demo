using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{


    public delegate void OnHurtboxEnable();
    public OnHurtboxEnable hurtboxEnable;

    public delegate void OnHurtboxDisable();
    public OnHurtboxDisable hurtboxDisable;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void Enable()
    {
        if (hurtboxEnable != null) 
        {
            hurtboxEnable.Invoke();
        }
    }

    public void Disable()
    {
        if (hurtboxDisable != null)
        {
            hurtboxDisable.Invoke();
        }
    }

    public void onCollide(IDamagable target)
    {

    }
}
