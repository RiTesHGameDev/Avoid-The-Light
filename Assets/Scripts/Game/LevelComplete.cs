using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private float delay = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ShowGameWinPanelAfterDelay());
        }
    }
    public void ShowGameWinPanel()
    {
        GameManager.Instance.PauseGame();
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }
    private IEnumerator ShowGameWinPanelAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        ShowGameWinPanel();
    }
}
