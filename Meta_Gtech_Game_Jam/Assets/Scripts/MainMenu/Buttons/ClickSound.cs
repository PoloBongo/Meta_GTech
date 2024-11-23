using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] public AudioClip clip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Click()
    {
        audioSource.PlayOneShot(clip);
    }
}
