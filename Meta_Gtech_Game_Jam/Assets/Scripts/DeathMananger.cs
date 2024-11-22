using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMananger : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameModeSoleil gameMode;
    Rigidbody rb;

    private void Start()
    {
        rb = playerManager.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Verrify();
    }
    public void Verrify()
    {
        if(rb.velocity.magnitude >= 0 &&  gameMode.IsThirdSoundPlayed())
        {
            print("coucou");
        }
    }
}
