using System;
using System.Collections;
using System.Collections.Generic;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public float durationEase = 2f;
    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = transform.localPosition;
    }

    private void Start()
    {
        transform.position = originalPosition +Vector3.down * 5f;
        LMotion.Create(transform.position,
                originalPosition, durationEase)
            .WithEase(Ease.OutBack)
            .WithOnComplete(FreezeYAxis)
            .BindToPosition(transform);
    }

    private void FreezeYAxis()
    {
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY |
                                                          RigidbodyConstraints.FreezeRotationX |
                                                          RigidbodyConstraints.FreezeRotationZ;
    }
    
}
