using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    [SerializeField] private float rotation;
    [SerializeField] private float duration;

    public void RotateDoorSetup()
    {
            StartCoroutine(RotateOverTime(rotation, duration));

    }

    private IEnumerator RotateOverTime(float rotation, float duration)
    {
        float elapsedTime = 0f;

        Quaternion initialRotation = transform.rotation; // Rotation de départ
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0f, rotation, 0f); // Rotation cible

        while (elapsedTime < duration)
        {
            // Interpolation entre la rotation initiale et la cible
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, elapsedTime / duration);

            elapsedTime += Time.deltaTime; // Temps écoulé
            yield return null; // Attendre la frame suivante
        }

        // Assurer la rotation finale
        transform.rotation = targetRotation;

    }
}
