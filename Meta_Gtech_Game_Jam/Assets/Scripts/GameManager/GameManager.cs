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
    private float elapsedTime;
    private bool canStartGameModeSoleil;
    private void Start()
    {
        canStartGameModeSoleil = false;
        startTime = Time.time;
    }

    private void Update()
    {
        CooldownAfterModelSoleilExecution();
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
        int palier = 0; float threshold = palierSound;
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
        }
        else
        {
            palierSound = Random.Range(minPalierObjectifAtteint, minPalier + 1);
        }
        palierSound = Mathf.Max(palierSound, minPalier);
    }
}
