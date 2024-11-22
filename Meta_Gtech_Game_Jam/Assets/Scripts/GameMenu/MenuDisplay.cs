using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDisplay : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    private bool isPaused = false;

    private void Start()
    {

        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
        ResumeGame();
    }


    public void ToggleMenu()
    {
        if (menuPanel != null)
        {
            isPaused = !isPaused;
            menuPanel.SetActive(isPaused); // Afficher ou cacher le menu

            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0f; 
        Debug.Log("Game Paused");
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; 
        Debug.Log("Game Resumed");
    }

   
}
