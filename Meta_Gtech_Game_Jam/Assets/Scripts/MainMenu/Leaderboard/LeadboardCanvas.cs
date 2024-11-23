using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadboardCanvas : MonoBehaviour
{
    [SerializeField] private RectTransform imageTransform; // L'image à déplacer


    private void Start()
    {
     
    }
    public void MoveImageDown(float targetY, float moveDuration)
    {
        StartCoroutine(SlideImageDown(targetY, moveDuration));
    }

    private IEnumerator SlideImageDown(float targetY, float duration)
    {
        float elapsedTime = 0f;
        Vector2 initialPosition = imageTransform.anchoredPosition; 
        Vector2 targetPosition = new Vector2(initialPosition.x, targetY); 

        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;


            imageTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, progress);

            elapsedTime += Time.deltaTime; 
            yield return null; 
        }

   
        imageTransform.anchoredPosition = targetPosition;
    }
}
