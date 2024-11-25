using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerDistance playerDistance;
    public bool isDead = false;

    private static PlayerManager instance;

    public static PlayerManager Instance
    {
        get
        {
            if(instance == null)
                instance = FindObjectOfType<PlayerManager>();
            return instance;
        }
    }

    public PlayerMovement GetPlayerMovement()
    {
        return playerMovement;
    }

    public PlayerDistance GetPlayerDistance()
    {
        return playerDistance;
    }
    
}
