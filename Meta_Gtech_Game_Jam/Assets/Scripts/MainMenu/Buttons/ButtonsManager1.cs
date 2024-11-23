using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonsManager1 : MonoBehaviour
{
    [SerializeField] LeaderboardStart leaderboardStart;
    [SerializeField] GameObject mainMenuCanva;
    [SerializeField] private CanvaFadeController mainMenuCanvas;
    [SerializeField] private Button backButton;      
    [SerializeField] private GameObject ghost;

    public bool leaderboardIsPressed = false;

    private void Start()
    {
        backButton.gameObject.SetActive(false);
        mainMenuCanva.SetActive(true);
    }
    /// <summary>
    /// Switch to game scene
    /// </summary>
    public void StartGame()
    {
        StopAllCoroutines();
        SceneManager.LoadSceneAsync("MainGameUI");
    }
    /// <summary>
    /// Quit the game
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Setup Leaderboard
    /// </summary>
    public void Leaderboard()
    {
        if (!leaderboardIsPressed)
        {
            leaderboardIsPressed = true;
            mainMenuCanvas.FadeOutAndDisable();
            leaderboardStart.setupLeaderboard();
        }
    }

    /// <summary>
    /// Go back to menu
    /// </summary>
    public void BackToMenu()
    {
        leaderboardStart.setupMenu();
        backButton.gameObject.SetActive(false);
        
    }

}
