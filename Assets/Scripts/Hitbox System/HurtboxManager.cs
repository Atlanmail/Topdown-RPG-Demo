using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * manages hurtboxes, when a hurtbox fires it triggers an event
 * doesn't manage which hurtbox sent that message
 * 
 */
public class HurtboxManager : MonoBehaviour
{
    List<Hurtbox> _hurtboxList;

    bool _enabled = true;
    /// <summary>
    ///  delegates
    /// </summary>
    /// <param name="attackData"></param>
    public delegate void DamageEventHandler(AttackData attackData);
    public event DamageEventHandler OnTakeDamage;
    public bool Enabled { get { return _enabled; } }


    void Start()
    {



        _hurtboxList = new List<Hurtbox>();

        Hurtbox[] hurtboxes = GetComponentsInChildren<Hurtbox>();
        for (int i = 0; i < hurtboxes.Length; i++)
        {
            hurtboxes[i].Manager = this;
            _hurtboxList.Add(hurtboxes[i]);

        }


        foreach (Hurtbox hurtbox in _hurtboxList)
        {
            Debug.Log(hurtbox);
        }


    }


    public void takeDamage(AttackData attackData)
    {
        OnTakeDamage?.Invoke(attackData);
    }

    public void Enable()
    {
        foreach (Hurtbox hurtbox in _hurtboxList)
        {
            hurtbox.Enable();
        }

        _enabled = true;
    }

    public void Disable()
    {

        foreach (Hurtbox hurtbox in _hurtboxList)
        {
            hurtbox.Disable();
        }
        _enabled = false;
    }



}
