using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonManager : MonoBehaviour
{
    [SerializeField] private MenuDisplay menuDisplay;
    public void ResumeGame()
    {
        Debug.Log("Resuming game...");
        menuDisplay.ToggleMenu(); 
    }
    public void DisplayMenu()
    {
        menuDisplay.ToggleMenu();
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        SceneManager.LoadScene("MainMenu");
    }
    
}
