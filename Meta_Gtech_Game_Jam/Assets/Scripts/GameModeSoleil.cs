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

    private int soundIndex = 0; 
    private float nextPlayTime = 0f; 
    public bool thirdSoundPlayed = false;
    private float thirdSoundTime = 0f;
    public float globalSpeed = 1f;

    private bool isPlayingSound;
    void Start()
    {
        soundManager = GetComponent<SoundManager>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutineAction();
        nextPlayTime = Time.time;
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
        // Réinitialise la variable `thirdSoundPlayed` après 3 secondes
        if (thirdSoundPlayed && Time.time >= thirdSoundTime + 3f)
        {
            thirdSoundPlayed = false;
        }

        // Vérifie si le son actuel est terminé
        if (!audioSource.isPlaying && isPlayingSound)
        {
            isPlayingSound = false; // Le son a fini de jouer
            soundIndex++; // Passe au prochain son

            if (soundIndex < audioClip.Count)
            {
                PlaySound(); // Joue le prochain son
            }
        }
    }

    /// <summary>
    /// Joue le son actuel.
    /// </summary>
    private void PlaySound()
    {
        if (soundIndex >= audioClip.Count)
            return; // Si tous les sons ont été joués, arrête

        AudioClip currentClip = audioClip[soundIndex];
        audioSource.clip = currentClip;
        audioSource.pitch = globalSpeed; // Ajuste la vitesse de lecture
        audioSource.Play();
        isPlayingSound = true;

        if (soundIndex == 2) // Si c'est le 3ème son
        {
            thirdSoundPlayed = true;
            thirdSoundTime = Time.time; // Stocke le temps pour réinitialisation
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
