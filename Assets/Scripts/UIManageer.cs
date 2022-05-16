using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManageer : MonoBehaviour
{
    public GameObject tapPanel;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;
    private void Start()
    {
        TapToStartPanel();
    }
    public void TapToStartPanel()
    {
        tapPanel.SetActive(true);
        FindObjectOfType<PlayerMovement>().isMove = false;
    }
    public void TapToStart()
    {
        tapPanel.SetActive(false);
        FindObjectOfType<PlayerMovement>().isMove = true;
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);

    }
    public void GameWin()
    {
        gameWinPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameWinPanel()
    {
        gameWinPanel.SetActive(false);

        FindObjectOfType<SaveLoadSystem>().GetLevel();
    }
}
