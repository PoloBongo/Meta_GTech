using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private RotateDoor rotateDoorRight; // Référence au script RotateDoor
    [SerializeField] private RotateDoor rotateDoorLeft; // Référence au script RotateDoor

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant est le fantôme
        if (other.CompareTag("Player"));
        {
            Debug.Log("Fantôme détecté ! Ouverture de la grille.");
            rotateDoorRight.RotateDoorSetup();
            rotateDoorLeft.RotateDoorSetup();
        }
    }
}
