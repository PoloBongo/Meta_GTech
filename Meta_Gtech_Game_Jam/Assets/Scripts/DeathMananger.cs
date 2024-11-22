using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathMananger : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameModeSoleil gameMode;
    [SerializeField] private PlayerDistance playerDistance;
    [SerializeField] private Sauvegarde sauvegarde;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI newScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    Rigidbody rb;

    private void Start()
    {
        rb = playerManager.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!gameMode.IsThirdSoundPlayed()) return;
        Verify();
    }
    public void Verify()
    {
        if(rb.velocity.magnitude >= 1 && gameMode.IsThirdSoundPlayed())
        {
            //lost
            playerManager.isDead = true;
            playerDistance.GetTextChangeValue().gameObject.SetActive(false);
            if(sauvegarde.LoadScore() < playerDistance.GetDistance())
            {
                sauvegarde.SaveScore(playerDistance.GetDistance());
            }
            newScoreText.text = playerDistance.GetDistance().ToString();
            bestScoreText.text = sauvegarde.LoadScore().ToString();
            endScreen.SetActive(true);
        }
    }
}
