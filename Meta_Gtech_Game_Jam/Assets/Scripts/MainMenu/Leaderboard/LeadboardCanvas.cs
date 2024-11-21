using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadboardCanvas : MonoBehaviour
{
    [SerializeField] private RectTransform imageTransform; // L'image à déplacer

    [SerializeField] private float targetY = 0f; // Position finale en Y
    [SerializeField] private float moveDuration = 2f; // Durée de l'animation
    private void Start()
    {
     
    }
    public void MoveImageDown()
    {
        print("omg");
        StartCoroutine(SlideImageDown(targetY, moveDuration));
    }

    private IEnumerator SlideImageDown(float targetY, float duration)
    {
        float elapsedTime = 0f;
        Vector2 initialPosition = imageTransform.anchoredPosition; // Position initiale
        Vector2 targetPosition = new Vector2(initialPosition.x, targetY); // Position cible

        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;

            // Interpolation linéaire entre la position initiale et la cible
            imageTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, progress);

            elapsedTime += Time.deltaTime; // Temps écoulé
            yield return null; // Attendre la frame suivante
        }

        // S'assurer que la position finale est exacte
        imageTransform.anchoredPosition = targetPosition;
    }
}
