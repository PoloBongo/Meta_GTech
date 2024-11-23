using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAutoDisable : MonoBehaviour
{
    void FixedUpdate()
    {
        if ((PlayerManager.Instance.GetPlayerMovement().transform.position.x - transform.position.x) > 5f)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
