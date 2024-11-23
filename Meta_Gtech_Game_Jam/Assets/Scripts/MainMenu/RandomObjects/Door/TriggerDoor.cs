using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private RotateDoor rotateDoorRight;
    [SerializeField] private RotateDoor rotateDoorLeft;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            rotateDoorRight.RotateDoorSetup();
            rotateDoorLeft.RotateDoorSetup();
        }
    }
}
