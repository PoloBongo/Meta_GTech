using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardStart : MonoBehaviour
{
    [SerializeField] private GhostMovements ghostMovements;

    private float ghostRotation = 180f;
    [SerializeField] private float rotateDuration = 1f;

    [SerializeField] private GameObject targetPosition;
    [SerializeField] private float moveDuration;


    public void setupLeaderboard()
    {
        StartCoroutine(ghostMovements.SetupGhostLeaderboard(ghostRotation, rotateDuration, targetPosition.transform.position, moveDuration));
    }
}
