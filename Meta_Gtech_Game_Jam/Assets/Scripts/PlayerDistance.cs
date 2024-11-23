using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDistance : MonoBehaviour
{
    public Vector3 startPosition;
    public float distance;
    [SerializeField] TextChangeValue textMesh;
    private void Awake()
    {
        startPosition = transform.position;
        textMesh.UpdateDistanceText(0,0);
    }
    
    public void UpdateCurrentDistance()
    {
        int tempDistance = (int)distance;
        distance = Vector3.Distance(startPosition, transform.position);
        textMesh.UpdateDistanceText(tempDistance,(int)distance);
    }

    public float GetDistance()
    {
        return distance;
    }

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }

    public TextChangeValue GetTextChangeValue()
    {
        return textMesh;
    }
    
}
