using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float cooldownAfterModelSoleilExecution;
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
            Debug.Log("sa fait 5 secondes");
            elapsedTime = 0f;
            startTime = Time.time;
        }
    }
}
