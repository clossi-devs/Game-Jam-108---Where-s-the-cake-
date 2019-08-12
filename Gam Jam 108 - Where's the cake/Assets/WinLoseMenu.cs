using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinLoseMenu : MonoBehaviour
{
    public bool IsGameWon = false;
    public bool IsGameLost = false;
    public GameObject WinMenuUI;
    public GameObject WinText;
    public GameObject LoseText;

    private void Start()
    {
        WinMenuUI.SetActive(false);
        WinText.SetActive(false);
        LoseText.SetActive(false);
    }

    private void Update()
    {
        if (IsGameLost)
        {
            LoseText.SetActive(true);
            WinMenuUI.SetActive(true);
        }
        if (IsGameWon)
        {
            WinText.SetActive(true);
            WinMenuUI.SetActive(true);
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
