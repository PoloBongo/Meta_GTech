using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameModeSoleil : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClip;
    [SerializeField] LightManager lightManager;

    private AudioSource audioSource;

    public bool fourthSoundPlayed = false;
    private bool antiSpamLightOn = false;
    private float fourthSoundTime = 0f;

    private int currentTime = 3;
    public float globalSpeed = 2f;

    private int stockRandomFeinte;
    private int soundIndex = 0;
    private bool isPlayingSound = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (PlayerManager.Instance.isDead) return;
        ManageSounds();
    }

    private void ManageSounds()
    {
        if (fourthSoundPlayed && Time.time >= fourthSoundTime + Random.Range(3f, 8f))
        {
            fourthSoundPlayed = false;
            antiSpamLightOn = false;
        }

        if (!audioSource.isPlaying && isPlayingSound)
        {
            isPlayingSound = false; 
            if (soundIndex == currentTime) { soundIndex = 0; return; }
            soundIndex++; 
            if (soundIndex < audioClip.Count)
            {
                PlaySound(-1);
            }
        }

        if (!fourthSoundPlayed && !antiSpamLightOn)
        {
            lightManager.TurnOnAllLights();
            antiSpamLightOn = true;
        }
    }

    public int SetCurrentTime(int time) { return currentTime = time; }
    public void PlaySound(int _randomFeinte)
    {
        if (_randomFeinte != -1) stockRandomFeinte = _randomFeinte;
        if (soundIndex >= audioClip.Count)
            return;
        Debug.Log(stockRandomFeinte + "gameModeSoleil");
        if (stockRandomFeinte == soundIndex)
        {
            soundIndex = 0;
            return;
        }
        AudioClip currentClip = audioClip[soundIndex];
        audioSource.clip = currentClip;
        audioSource.pitch = globalSpeed;
        audioSource.Play();
        isPlayingSound = true;
        if(soundIndex < 3)
        {
             lightManager.BlinkAllLights();
        }
        else
        {
            fourthSoundPlayed = true;
            fourthSoundTime = Time.time;
            lightManager.TurnOffAllLights();
            soundIndex = 0;
            isPlayingSound = false;
        }
    }

    public bool IsFourthSoundPlayed() { return fourthSoundPlayed; }
    
    public bool GetIsPlayingSound() { return isPlayingSound; }

    public void SetGlobalSpeed(float _globalSpeed)
    {
        globalSpeed = _globalSpeed;
    }
}
