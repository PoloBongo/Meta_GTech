using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PopBriar : MonoBehaviour
{
    [SerializeField] private GameObject briar;
    [SerializeField] private GameObject player;
    private bool a = false;
    private void SpawnBriar()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        float spawnDistance = 1f;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        Instantiate(briar, spawnPos, briar.transform.rotation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !a)
        {
            SpawnBriar();
            a = true;
        }
    }
}
