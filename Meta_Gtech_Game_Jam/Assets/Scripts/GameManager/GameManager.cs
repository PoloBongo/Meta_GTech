using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float cooldownAfterModelSoleilExecution;
    [Header("Settings Game Manager")]
    [SerializeField] private GameModeSoleil gameModeSoleil;
    private float startTime;
    private float elapsedTime;
    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        CooldownAfterModelSoleilExecution();
    }

    private void CooldownAfterModelSoleilExecution()
    {
        elapsedTime = Time.time - startTime;
        if (elapsedTime >= cooldownAfterModelSoleilExecution)
        {
            elapsedTime = 0f;
            startTime = Time.time;
        }
    }
}
