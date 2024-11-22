using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public InputActionReference forwardRef;
    public InputActionReference leftRightRef;
    public InputActionReference posPressRef;
    private Vector2 mousePosition;
    public Vector2 pressPosition;
    private bool havePos = false;

    static PlayerInputs instance;

    public static PlayerInputs Instance
    {
        get
        {
            if(instance == null)
                instance = FindObjectOfType<PlayerInputs>();
            return instance;
        }
    }
    private void Awake()
    {
        forwardRef.action.performed += ForwardPerformed;
        forwardRef.action.canceled += ForwardCanceled;
        leftRightRef.action.performed += LeftRightPerformed;
        leftRightRef.action.canceled += LeftRightCanceled;
        posPressRef.action.performed += PressPerformed;
    }

    private void OnEnable()
    {
        forwardRef.action.Enable();
        leftRightRef.action.Enable();
        posPressRef.action.Enable();
    }

    private void OnDisable()
    {
        forwardRef.action.Disable();
        leftRightRef.action.Disable();
        posPressRef.action.Disable();
    }

    private void ForwardPerformed(InputAction.CallbackContext context)
    {
        PlayerManager.Instance.GetPlayerMovement().isMovingForward = true;
        if (!havePos) return;
        pressPosition = mousePosition;
    }

    private void ForwardCanceled(InputAction.CallbackContext context)
    {
        PlayerManager.Instance.GetPlayerMovement().isMovingForward = false;
    }

    private void LeftRightPerformed(InputAction.CallbackContext context)
    {
        PlayerManager.Instance.GetPlayerMovement().isMovingLeftRight = true;
    }

    private void LeftRightCanceled(InputAction.CallbackContext context)
    {
        PlayerManager.Instance.GetPlayerMovement().isMovingLeftRight = false;
    }

    private void PressPerformed(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        havePos = true;
    }
}
