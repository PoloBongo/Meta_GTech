using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Slider volumeSlider;
    private float currentVolume = 1f;

    private void Awake()
    {
        print("soifsediofjoijs");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ApplyVolume();
    }

    public void OnVolumeSliderChanged(float value)
    {
        currentVolume = value;
        ApplyVolume();
    }

    private void ApplyVolume()
    {
        AudioListener.volume = currentVolume;
    }
}