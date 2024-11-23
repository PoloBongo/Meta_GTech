using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAutoDisable : MonoBehaviour
{
    void Update()
    {
        if (PlayerManager.Instance.isDead) 
            transform.gameObject.SetActive(false);
        if (enabled && (PlayerManager.Instance.GetPlayerMovement().transform.position.x - transform.position.x) > 5f)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
