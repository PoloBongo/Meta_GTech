using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   
    [SerializeField] private Transform player; 
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f); 

    private void LateUpdate()
    {
        if (player == null) return;


        Vector3 cameraPosition = transform.position;

 
        cameraPosition.z = player.position.z + offset.z;

        transform.position = cameraPosition;
    }
}
