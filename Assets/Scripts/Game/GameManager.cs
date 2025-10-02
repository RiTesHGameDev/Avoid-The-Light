using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isPaused = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayGame()
    {
        ResumeGame();
        SceneManager.LoadScene("Level");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit(); 
    }
    public void PauseGame()
    {
        Time.timeScale = 0f; 
        isPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void TogglePause()
    {
        if (isPaused) ResumeGame();
        else PauseGame();
    }
    public bool IsPaused()
    {
        return isPaused;
    }
}
