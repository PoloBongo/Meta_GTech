using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrap : MonoBehaviour
{
    [SerializeField] private List<GameObject> traps;
    [SerializeField] private Transform trapPlacementTest;

    private void Start()
    {
        PlaceTrap();
    }

    private void PlaceTrap()
    {
        Instantiate(traps[0], trapPlacementTest.position, trapPlacementTest.rotation);
    }
}
