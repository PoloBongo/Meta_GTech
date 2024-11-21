using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GhostMovements : MonoBehaviour
{
    [SerializeField] private float floatAmplitude = 0.5f; //Max amplitude
    [SerializeField] private float floatSpeed = 2f;       // Floating speed

  
    private Vector3 initialPosition;

    private void Start()
    {
        // Initial position
        initialPosition = transform.position;
    }

    private void Update()
    {
 
        float offsetY = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;//floating mouvement based on time

  
        transform.position = initialPosition + new Vector3(0f, offsetY, 0f);//apply mouvement
    }

    /// <summary>
    /// Rotate character from a certain angle (rotation value) during a certain amount of time (duration)
    /// </summary>
    public IEnumerator SetupGhostLeaderboard(float rotation, float duration,Vector3 targetPosition, float moveDuration)
    {
        yield return StartCoroutine(RotateOverTime(rotation, duration));

 
        yield return StartCoroutine(MoveToPosition(targetPosition, moveDuration));
    }
    /// <summary>
    /// Rotate character over time using a rotation value and duration
    /// </summary>
    private IEnumerator RotateOverTime(float rotation, float duration)
    {
        float elapsedTime = 0f;
        float initialRotation = transform.eulerAngles.y; // starting angle
        float targetRotation = initialRotation + rotation; // aimed angle

        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;
            float easedProgress = Mathf.SmoothStep(0f, 1f, progress);

            // Interpolate the rotation using the eased progress
            float currentRotation = Mathf.Lerp(initialRotation, targetRotation, easedProgress);

            // Apply rotation
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentRotation, transform.eulerAngles.z);

            elapsedTime += Time.deltaTime; // Increase time
            yield return null;
        }

        // Make sure the angle is the right one
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetRotation, transform.eulerAngles.z);
    }

    /// <summary>
    /// Move character over time to a position over time
    /// </summary>
    private IEnumerator MoveToPosition(Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position; // Starting position

        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;
            float easedProgress = Mathf.SmoothStep(0f, 1f, progress);

            // Interpolate position
            Vector3 currentPosition = Vector3.Lerp(initialPosition, targetPosition, easedProgress);

            // Apply position
            transform.position = currentPosition;

            elapsedTime += Time.deltaTime; // Increase time
            yield return null;
        }

        // Make sure the position is exact
        transform.position = targetPosition;
        print("gigi");
        FindObjectOfType<LeadboardCanvas>().MoveImageDown();
    }
}
