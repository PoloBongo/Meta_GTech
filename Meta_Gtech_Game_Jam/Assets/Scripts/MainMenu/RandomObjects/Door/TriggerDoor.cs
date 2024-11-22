using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private RotateDoor rotateDoorRight;
    [SerializeField] private RotateDoor rotateDoorLeft; 

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            rotateDoorRight.RotateDoorSetup();
            rotateDoorLeft.RotateDoorSetup();
        }
    }
}
