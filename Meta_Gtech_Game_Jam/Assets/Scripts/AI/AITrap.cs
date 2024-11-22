using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrap : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject trapAIPrefab;
    [SerializeField] private float spawnDistanceToPlayer;
    [SerializeField] private int impulseForce;
    private Rigidbody rigibody;
    
    public delegate void OnPutTrap();
    public static event OnPutTrap OnCanPutTrap;

    private void Start()
    {
        rigibody = GetComponent<Rigidbody>();
        PlaceSingleTrap();
    }

    private void PlaceSingleTrap()
    {
        OnCanPutTrap?.Invoke();
        
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        float spawnDistance = spawnDistanceToPlayer;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        Instantiate(trapAIPrefab, spawnPos, trapAIPrefab.transform.rotation);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            rigibody.AddForce(-transform.forward * impulseForce, ForceMode.Impulse);
        }
    }
}
