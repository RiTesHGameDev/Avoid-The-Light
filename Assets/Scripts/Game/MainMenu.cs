using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] Button playButton;
    [SerializeField] Button exitButton;
    private void Awake()
    {
        if (mainMenu != null)
            mainMenu.SetActive(true);
    }
    private void Start()
    {
        if (playButton != null)
            playButton.onClick.AddListener(PlayButton);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitButton);
    }
    public void PlayButton()
    {
        GameManager.Instance.PlayGame();
    }
    public void ExitButton()
    {
        GameManager.Instance.ExitGame();
    }
}
