using UnityEngine;
using UnityEngine.UI;

public class SliderAudioSetup : MonoBehaviour
{
    public Slider mainSlider;
    private AudioManager audioManager;
    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        FoundAudioManager();
        audioManager.OnVolumeSliderChanged(mainSlider.value);
        Debug.Log(mainSlider.value);
    }

    private void FoundAudioManager()
    {
        AudioManager faudioManager = (AudioManager) FindObjectOfType(typeof(AudioManager));
        if (!faudioManager) Debug.LogError("Found Audio Manager not found");
        audioManager = faudioManager;
    }
}
