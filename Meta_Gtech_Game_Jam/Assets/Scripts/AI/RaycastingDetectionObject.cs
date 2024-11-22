using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingDetectionObject : MonoBehaviour
{
    [SerializeField] private float rayLength = 10f;
    private bool isColliding = false;
    
    private void OnEnable()
    {
        AITrap.OnCanPutTrap += HandleReturnCanPutTrap;
    }

    private void OnDisable()
    {
        AITrap.OnCanPutTrap -= HandleReturnCanPutTrap;
    }

    private void HandleReturnCanPutTrap()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);
    }

    public bool GetIsColliding()
    {
        return isColliding;
    }

    public void SetIsColliding(bool _isColliding)
    {
        isColliding = _isColliding;
    }
}
