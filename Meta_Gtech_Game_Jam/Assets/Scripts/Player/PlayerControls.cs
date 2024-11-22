using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public InputAction movement;
    Vector2 moveDirection = Vector2.zero;
    public float speed = 10.0f;
    public bool isMoving = false;

    private void OnEnable()
    {
        movement.Enable();
    }
    
    private void OnDisable()
    {
        movement.Disable();
    }

    private void Update()
    {
        moveDirection = movement.ReadValue<Vector2>();
        isMoving = moveDirection != Vector2.zero;
    }
    
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(moveDirection.x, 0, moveDirection.y) * speed * Time.fixedDeltaTime);
    }
}
