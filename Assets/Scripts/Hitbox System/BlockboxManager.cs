using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockboxManager : MonoBehaviour
{
    private List<Blockbox> _blockboxList;

    bool _enabled = true;
    /// <summary>
    ///  delegates
    /// </summary>
    /// <param name="attackData"></param>
    public delegate void DamageEventHandler(EntityData entity, AttackData attackData);
    public event DamageEventHandler OnBlockHit;
    public bool Enabled { get { return _enabled; } }
    
    public List<Blockbox> BlockboxList { get { return _blockboxList; } }
   
    private void Awake()
    {
        _blockboxList = new List<Blockbox>();

        Blockbox[] blockboxes = GetComponentsInChildren<Blockbox>();
        for (int i = 0; i < blockboxes.Length; i++)
        {
            blockboxes[i].Manager = this;
            _blockboxList.Add(blockboxes[i]);

        }
    }
    void Start()
    {



        

        


        foreach (Blockbox blockbox in _blockboxList)
        {
            ///Debug.Log(hurtbox);
        }


    }


    public void takeDamage(EntityData entityData, AttackData attackData)
    {
        OnBlockHit?.Invoke(entityData, attackData);
    }
    /// <summary>
    /// enables the blockboxes
    /// </summary>
    public void Enable()
    {
        foreach (Blockbox blockbox in _blockboxList)
        {
            blockbox.Enable();
        }

        _enabled = true;
    }
    /// <summary>
    /// disables the blockboxes
    /// </summary>
    public void Disable()
    {

        foreach (Blockbox blockbox in _blockboxList)
        {
            blockbox.Disable();
        }
        _enabled = false;
    }
}
