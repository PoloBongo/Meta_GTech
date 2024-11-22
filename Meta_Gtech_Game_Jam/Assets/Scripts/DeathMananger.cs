using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMananger : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameModeSoleil gameMode;
    [SerializeField] private PlayerDistance playerDistance;
    [SerializeField] private Sauvegarde sauvegarde;
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
            if(sauvegarde.LoadScore() < playerDistance.GetDistance())
            {
                sauvegarde.SaveScore(playerDistance.GetDistance());
            }
        }
    }
}
