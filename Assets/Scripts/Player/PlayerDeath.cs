using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private float delay = 1f;
    [SerializeField] private Rigidbody2D rb;
    private bool isDead = false;

    public void Die()
    {
        if (isDead) return;

        isDead = true;

        if (rb != null)
            rb.simulated = false;

        StartCoroutine(ShowLosePanelAfterDelay());
    }
    private void ShowLosePanel()
    {
        GameManager.Instance.PauseGame();
        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }
    }
    private IEnumerator ShowLosePanelAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        ShowLosePanel();
    }
}
