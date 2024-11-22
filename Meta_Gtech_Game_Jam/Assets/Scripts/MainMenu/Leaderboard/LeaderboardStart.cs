using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardStart : MonoBehaviour
{
    [SerializeField] private GhostMovements ghostMovements;

    private float ghostRotation = 180f;
    [SerializeField] private float rotateDuration = 1f;

    [SerializeField] private GameObject targetPosition;
    [SerializeField] private GameObject ghost;
    [SerializeField] private float moveDuration;

    private Vector3 originalPosition;
    private void Start()
    {
        originalPosition = ghost.transform.position;
    }
    public void setupLeaderboard()
    {
        StartCoroutine(ghostMovements.SetupGhostLeaderboard(ghostRotation, rotateDuration, targetPosition.transform.position, moveDuration));
    }
    public void setupMenu()
    {
        FindObjectOfType<LeadboardCanvas>().MoveImageDown(500f);
        StartCoroutine(ghostMovements.SetupGhostLeaderboard(ghostRotation, rotateDuration, originalPosition, moveDuration));
    }
}
