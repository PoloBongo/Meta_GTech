using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightManager : MonoBehaviour
{
    private List<Light> lights = new List<Light>();
    [SerializeField] private GameModeSoleil modeSoleil;
    public Material materialToChange;
    private bool stateLight;
    public float blinkDuration = 3f; // Durée totale du clignotement
    private float elapsedTime = 0f;
    private bool active;
    private bool sonActive;

    private bool isBlinking = false;
    private float timer = 0f;
    private void Start()
    {
        TurnOnAllLights();

        active = true;
        sonActive = true;
    }

    private void Update()
    {
        if (Keyboard.current[Key.L].wasPressedThisFrame)
        {
            TurnOffAllLights();
        }
        if (Keyboard.current[Key.K].wasPressedThisFrame)
        {
            TurnOnAllLights();
        }
        if (Keyboard.current[Key.P].wasPressedThisFrame)
        {
            modeSoleil.PlaySound();
        }

        if (!isBlinking) return;
        UpdateBlinkTimer();
        
        //PlaySoleil();


    }
    public void PlaySoleil()
    {
        if (active)
        {
            LightEffect(0);
        }
        if (sonActive)
        {
            modeSoleil.PlaySound();
            sonActive = false;
        }
    }

    public void SetEmissionColor(Color newColor)
    {
        if (materialToChange != null)
        {
            materialToChange.SetColor("_EmissionColor", newColor);
            DynamicGI.UpdateEnvironment();
        }
    }

    public List<Light> GetAllLights()
    {
        var allLights = FindObjectsOfType<Light>();
        lights.AddRange(allLights);
        return lights;
    }

    public void SetLightIntensity(float directionalIntensity, float lightIntensity, bool state)
    {
        GetAllLights();

        foreach (var l in lights)
        {
            if (l.type == LightType.Directional)
            {
                l.intensity = directionalIntensity;
            }
            else
            {
                ParticleSystem particleSystem = l.GetComponentInParent<ParticleSystem>();
                particleSystem = l.GetComponentInParent<ParticleSystem>(true);
                if (particleSystem) particleSystem.gameObject.SetActive(state);
                l.intensity = lightIntensity;
            }
        }
    }

    public void LightEffect(int _round)
    {
        if (lights.Count == 0) return;
        elapsedTime += Time.deltaTime;


        if (elapsedTime < 3f)
        {
            float blinkInterval = 0.5f; 
            bool isOn = Mathf.FloorToInt(elapsedTime / blinkInterval) % 2 == 0;

            if (isOn)
            {
                
                TurnOffAllLights();
                

            }
            else
            {

                TurnOnAllLights();
                
            }
        }
        else
        {
            TurnOffAllLights();
            active = false;
        }
    }

    public void BlinkAllLights()
    {
        isBlinking = true;
        TurnOffAllLights();
    }

    private void UpdateBlinkTimer()
    {
        if (isBlinking)
        {
            timer += Time.deltaTime;
            if(timer > 0.3f)
            {
                TurnOnAllLights();
                isBlinking = false;
                timer = 0;
            }
        }
    }

    public void TurnOffAllLights()
    {
        SetStateLight(false);
        SetLightIntensity(0, 0, false);
        SetEmissionColor(Color.black);
    }

    public void TurnOnAllLights()
    {
        SetStateLight(true);
        SetLightIntensity(0.1f, 40, true);
        SetEmissionColor(Color.white);
    }

    public bool GetStateLight()
    {
        return stateLight;
    }

    private void SetStateLight(bool _state)
    {
        stateLight = _state;
    }
}