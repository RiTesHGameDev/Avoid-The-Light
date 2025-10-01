using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("PANELS")]
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [Header("BUTTONS")]
    [SerializeField] private Button optionButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button replayButton2;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button mainMenuButton2;
    [SerializeField] private Button mainMenuButton3;
    private void Awake()
    {
        if (optionPanel == null)
            optionPanel.SetActive(false);
        if (winPanel == null)
            winPanel.SetActive(false);
        if (losePanel == null)
            losePanel.SetActive(false);
    }
    private void Start()
    {
        OnClickEvents();
    }
    private void OnClickEvents()
    {
        if (optionButton != null)
            optionButton.onClick.AddListener(OnOptionClick);

        if (backButton != null)
            backButton.onClick.AddListener(OnBackClick);

        if (replayButton != null)
            replayButton.onClick.AddListener(OnReplayClick);

        if (replayButton2 != null)
            replayButton2.onClick.AddListener(OnReplayClick);

        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(OnMainMenuClick);

        if (mainMenuButton2 != null)
            mainMenuButton2.onClick.AddListener(OnMainMenuClick);

        if (mainMenuButton3 != null)
            mainMenuButton3.onClick.AddListener(OnMainMenuClick);
    }
    private void OnOptionClick()
    {
        GameManager.Instance.PauseGame();
        optionPanel.SetActive(true);
    }
    private void OnBackClick()
    {
        GameManager.Instance.ResumeGame();
        optionPanel.SetActive(false);
    }
    private void OnMainMenuClick()
    {
        GameManager.Instance.MainMenu();
    }
    private void OnReplayClick() 
    {
        GameManager.Instance.ResumeGame();
        GameManager.Instance.RestartLevel();
    }
}
