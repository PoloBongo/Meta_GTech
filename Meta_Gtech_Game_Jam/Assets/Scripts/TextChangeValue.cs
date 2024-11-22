using System.Collections;
using System.Collections.Generic;
using LitMotion;
using LitMotion.Extensions;
using TMPro;
using UnityEngine;

public class TextChangeValue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distanceValue;
    private MotionHandle tween = new MotionHandle();
    
    public void UpdateDistanceText(int currentValue ,int newValue)
    {
        if (tween.IsActive())
        {
            tween.Cancel();
        }
        
        tween = LMotion.Create(currentValue, newValue, 1f)
            .BindToText(distanceValue);
    }

    public TextMeshProUGUI GetDistanceText()
    {
        return distanceValue;
    }
}