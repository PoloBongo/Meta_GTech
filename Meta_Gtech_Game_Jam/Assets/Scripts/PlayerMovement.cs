using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 2f;
    [SerializeField] float leftRightResistance = 50f;
    public float moveSmoothTime;
    
    public bool isMovingForward = false;
    public bool isMovingLeftRight = false;

    private Vector3 currentMoveVelocity;
    private Vector3 moveDampVelocity;
    private Vector3 currentForceVelocity;
    private void Update()
    {
        MovePlayer();
    }
    public void MovePlayer()
    {
        Vector2 movement = Vector2.zero;
        if (isMovingForward)
        {
            movement.x += 1f;
        }

        if (isMovingLeftRight && isMovingForward)
        {
            movement.y += PlayerInputs.Instance.leftRightRef.action.ReadValue<Vector2>().x - PlayerInputs.Instance.pressPosition.x ;
            if (Mathf.Abs(movement.y) > leftRightResistance)
            {
                movement.y = -Mathf.Clamp(movement.y, -1f, 1f);
            }
            else
            {
                movement.y = 0;
            }
        }
        currentMoveVelocity = Vector3.SmoothDamp(currentMoveVelocity, movement * playerSpeed, ref currentForceVelocity, moveSmoothTime);
        transform.position += new Vector3(currentMoveVelocity.x, 0, currentMoveVelocity.y) * Time.deltaTime;
        PlayerManager.Instance.GetPlayerDistance().UpdateCurrentDistance();
    }
}
