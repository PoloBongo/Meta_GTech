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

    [SerializeField] private AudioSource audioSource; 
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
        audioSource.Play();
        FindObjectOfType<LeadboardCanvas>().MoveImageDown(500f, 2f);
        StartCoroutine(ghostMovements.SetupGhostLeaderboard(ghostRotation, rotateDuration, originalPosition, moveDuration));
    }
}
