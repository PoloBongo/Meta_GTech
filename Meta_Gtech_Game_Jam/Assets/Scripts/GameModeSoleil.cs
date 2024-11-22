using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameModeSoleil : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClip;
    [SerializeField] LightManager lightManager;

    private AudioSource audioSource;

    public bool thirdSoundPlayed = false;
    private float thirdSoundTime = 0f;

    private int currenTime = 3;
    public float globalSpeed = 2f;

    private int soundIndex = 0;
    private bool isPlayingSound = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {

        ManageSounds();
    }

    private void ManageSounds()
    {
        if (thirdSoundPlayed && Time.time >= thirdSoundTime + 3f)
        {
            thirdSoundPlayed = false;
        }

        if (!audioSource.isPlaying && isPlayingSound)
        {
            isPlayingSound = false; 
            if (soundIndex == currenTime) { soundIndex = 0; return; }
            soundIndex++; 
            if (soundIndex < audioClip.Count)
            {
                PlaySound();
            }
        }
    }

    public int SetCurrenTime(int time) { return currenTime = time; }
    public void PlaySound()
    {
        if (soundIndex >= audioClip.Count)
            return; 
        print(soundIndex);
        AudioClip currentClip = audioClip[soundIndex];
        audioSource.clip = currentClip;
        audioSource.pitch = globalSpeed;
        audioSource.Play();
        isPlayingSound = true;
        
        if (soundIndex == 2)
        {
            thirdSoundPlayed = true;
            thirdSoundTime = Time.time;
        }
        if(soundIndex < 3)
        {
             lightManager.BlinkAllLights();
        }
        else
        {
            lightManager.TurnOffAllLights();
            soundIndex = 0;
            isPlayingSound = false;
        }
    }

}
