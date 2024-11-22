using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameModeSoleil : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClip;

    private SoundManager soundManager;
    private AudioSource audioSource;
    private Coroutine soundCoroutine;
    private bool playerMove;

    public bool thirdSoundPlayed = false; // Devient vrai après le 3ème son
    private float thirdSoundTime = 0f; // Temps pour réinitialiser `thirdSoundPlayed`

    private int currenTime = 2;
    public float globalSpeed = 2f;

    private int soundIndex = 0;
    private bool isPlayingSound = false;
    void Start()
    {
        soundManager = GetComponent<SoundManager>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutineAction();
        PlaySound();
    }
    private void Update()
    {

        ManageSounds();
    }

    void StartCoroutineAction()
    {
        soundCoroutine = null;
       /*if (soundCoroutine == null) soundCoroutine = StartCoroutine(CoroutineAction(0.5f, 3, 2));*/
    }

    IEnumerator CoroutineAction(float vitesseDecompt = 1f, int _currentTime = 0,float vitesseson = 1)
    {
        int currentTime = 0;
        playerMove = false;
        soundManager.SoundPitch(vitesseson, audioClip[currentTime]);
        currentTime++;
        if(currentTime == _currentTime) yield break;
        yield return new WaitForSeconds(vitesseDecompt);
        soundManager.SoundPitch(vitesseson, audioClip[currentTime]);
        currentTime++;
        if (currentTime == _currentTime) yield break;
        yield return new WaitForSeconds(vitesseDecompt);
        soundManager.SoundPitch(vitesseson, audioClip[currentTime]);
        currentTime++;
        playerMove = true;
        yield return new WaitForSeconds(vitesseDecompt);
        soundManager.SoundPitch(vitesseson, audioClip[currentTime]);
        yield return new WaitForSeconds(3);
        playerMove = false;
        print(playerMove);
        yield break;
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
            soundIndex++; 
            if (soundIndex == currenTime) { return; }
            if (soundIndex < audioClip.Count)
            {
                PlaySound(); 
            }
        }
    }

    public int SetCurrenTime(int time) { return currenTime = time; }
    private void PlaySound()
    {
        if (soundIndex >= audioClip.Count)
            return; 

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
    }

    public void DodgeCountdown(float _vitesseDecompte)
    {
        soundCoroutine = null;
        if (soundCoroutine == null) soundCoroutine = StartCoroutine(CoroutineAction(_vitesseDecompte, 2));
    }

    /*public bool DecompteEnd()
    {
        if (currentTime <= 0)
        {
            return true;
        }
        return false;
    }*/

    public void UpdateTextDecompte()
    {
        /*Debug.Log((int) currentTime);*/
    }
}
