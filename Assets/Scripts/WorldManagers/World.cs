using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerTracker
{
    GameObject _player;

    private static PlayerTracker _instance;

    private PlayerTracker()
    {

    }
    public static PlayerTracker Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerTracker();
            }
            return _instance;
        }
    }

    public void setPlayer(GameObject player)
    {
        _player = player;
    }

    public GameObject getPlayer()
    {
        return _player;
    }
}
