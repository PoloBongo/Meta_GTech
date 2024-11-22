using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    /// <summary>
    /// Switch to game scene
    /// </summary>
    public void RetryGame()
    {
        SceneManager.LoadScene("Game");
    }
    /// <summary>
    /// Quit the game
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
