using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float cooldownAfterModelSoleilExecution;
    [Header("Settings Game Manager")]
    [SerializeField] private GameModeSoleil gameModeSoleil;
    [SerializeField] private PlayerDistance playerDistance;

    [Header("Settings Sound Play")]
    [SerializeField] private int palierSound;
    [SerializeField] private int minPalier;
    [SerializeField] private int minPalierObjectifAtteint;
    private int currentPalier = 0;
    private float startTime;
    private float startTimeTrap;
    private float elapsedTime;
    private float elapsedTimeTrap;
    private bool canStartGameModeSoleil;
    private bool cooldownTrap;
    private int maxRandom = 5;
    private int random;
    
    public delegate void OnPutTrapOnMap();
    public static event OnPutTrapOnMap OnCanPutTrapOnMap;
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private DeathMananger deathMananger;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = true;

        canStartGameModeSoleil = false;
        cooldownTrap = false;
        startTime = Time.time;
        startTimeTrap = Time.time;
        random = Random.Range(0, maxRandom);
    }

    private void Update()
    {
        CooldownAfterModelSoleilExecution();
        if (gameModeSoleil.IsThirdSoundPlayed())
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
        deathMananger.Verrify();
    }

    private void FixedUpdate()
    {
        ReturnActualPalier();
        
    }

    private void CooldownAfterModelSoleilExecution()
    {
        elapsedTime = Time.time - startTime;
        if (elapsedTime >= cooldownAfterModelSoleilExecution)
        {
            elapsedTime = 0f;
            startTime = Time.time;
            canStartGameModeSoleil = true;
            cooldownTrap = true;
        }
        elapsedTimeTrap = Time.time - startTime;
        if (elapsedTimeTrap >= random && cooldownTrap)
        {
            cooldownTrap = false;
            elapsedTimeTrap = 0f;
            startTimeTrap = Time.time;
            OnCanPutTrapOnMap?.Invoke();
            random = Random.Range(0, maxRandom);
        }
    }

    private void StartGameModeSoleil()
    {
        if (canStartGameModeSoleil)
        {
            gameModeSoleil.PlaySound();
        }
    }

    private void ReturnActualPalier()
    {
        float distance = playerDistance.GetDistance();
        int palier = CalculatePalier(distance);
        if (palier != currentPalier)
        {
            currentPalier = palier;
            StartGameModeSoleil();
            AdjustPalierSound();
        }
    }

    private int CalculatePalier(float distance) 
    {
        int palier = 0; 
        float threshold = palierSound;
        while (distance >= threshold)
        {
            palier++; threshold += palierSound;
        }
        return palier;
    }

    private void AdjustPalierSound() 
    {
        if (palierSound > minPalier)
        {
            palierSound -= 10;
            maxRandom--;
        }
        else
        {
            palierSound = Random.Range(minPalierObjectifAtteint, minPalier + 1);
        }

        if (maxRandom <= 3)
        {
            maxRandom = 3;
        }
        palierSound = Mathf.Max(palierSound, minPalier);
    }
}
