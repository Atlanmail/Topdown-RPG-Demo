using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockboxManager : MonoBehaviour
{
    List<Blockbox> _blockboxList;

    bool _enabled = true;
    /// <summary>
    ///  delegates
    /// </summary>
    /// <param name="attackData"></param>
    public delegate void DamageEventHandler(EntityData entity, AttackData attackData);
    public event DamageEventHandler OnBlockHit;
    public bool Enabled { get { return _enabled; } }


    void Start()
    {



        _blockboxList = new List<Blockbox>();

        Blockbox[] blockboxes = GetComponentsInChildren<Blockbox>();
        for (int i = 0; i < blockboxes.Length; i++)
        {
            blockboxes[i].Manager = this;
            _blockboxList.Add(blockboxes[i]);

        }


        foreach (Blockbox blockbox in _blockboxList)
        {
            ///Debug.Log(hurtbox);
        }


    }


    public void takeDamage(EntityData entityData, AttackData attackData)
    {
        OnBlockHit?.Invoke(entityData, attackData);
    }

    public void Enable()
    {
        foreach (Blockbox blockbox in _blockboxList)
        {
            blockbox.Enable();
        }

        _enabled = true;
    }

    public void Disable()
    {

        foreach (Blockbox blockbox in _blockboxList)
        {
            blockbox.Disable();
        }
        _enabled = false;
    }
}
