using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrap : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject trapAIPrefab;
    [SerializeField] private float spawnDistanceToPlayer;

    private void Start()
    {
        PlaceSingleTrap();
    }

    private void PlaceSingleTrap()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        float spawnDistance = spawnDistanceToPlayer;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        Instantiate(trapAIPrefab, spawnPos, trapAIPrefab.transform.rotation);
    }
}
