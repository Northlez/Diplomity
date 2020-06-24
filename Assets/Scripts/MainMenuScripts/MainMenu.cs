using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    public GameObject LoadPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        LoadPanel.SetActive(false);
    }

    public void ToLoadMenu()
    {
        MainMenuPanel.SetActive(false);
        LoadPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
