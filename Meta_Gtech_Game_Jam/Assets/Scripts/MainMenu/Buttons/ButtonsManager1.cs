using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsManager1 : MonoBehaviour
{
    [SerializeField] LeaderboardStart leaderboardStart;
    private bool isPressed = false;

    /// <summary>
    /// Switch to game scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
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

        leaderboardStart.setupLeaderboard();
    }
}
