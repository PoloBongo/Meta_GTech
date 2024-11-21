using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private RotateDoor rotateDoorRight; // R�f�rence au script RotateDoor
    [SerializeField] private RotateDoor rotateDoorLeft; // R�f�rence au script RotateDoor

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet entrant est le fant�me
        if (other.CompareTag("Player"));
        {
            Debug.Log("Fant�me d�tect� ! Ouverture de la grille.");
            rotateDoorRight.RotateDoorSetup();
            rotateDoorLeft.RotateDoorSetup();
        }
    }
}
