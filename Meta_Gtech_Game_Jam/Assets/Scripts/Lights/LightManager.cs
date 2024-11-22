using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightManager : MonoBehaviour
{
    private List<Light> lights = new List<Light>();
    public Material materialToChange;
    private bool stateLight;

    private void Start()
    {
        TurnOnAllLights();
    }

    private void Update()
    {
        if (Keyboard.current[Key.L].wasPressedThisFrame)
        {
            TurnOffAllLights();
            SetEmissionColor(Color.black);
        }
        if (Keyboard.current[Key.K].wasPressedThisFrame)
        {
            TurnOnAllLights();
            SetEmissionColor(Color.white);
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

    public void SetLightIntensity(float directionalIntensity, float lightIntensity)
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
                l.intensity = lightIntensity;
            }
        }
    }

    public void TurnOffAllLights()
    {
        SetStateLight(false);
        SetLightIntensity(0, 0);
    }

    public void TurnOnAllLights()
    {
        SetStateLight(true);
        SetLightIntensity(0.1f, 40);
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