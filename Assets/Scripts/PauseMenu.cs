using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUi;
    public GameObject SettingsMenuPanel;
    public GameObject PauseMenuPanel;
    public GameObject SavePanel;
    public GameObject LoadPanel;

    private void Start()
    {
        PauseMenuUi.SetActive(false);
        BackToPauseMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        BackToPauseMenu();
    }

    public void Save()
    {
        PauseMenuPanel.SetActive(false);
        SavePanel.SetActive(true);
    }

    public void Load()
    {
        PauseMenuPanel.SetActive(false);
        LoadPanel.SetActive(true);
    }

    public void Settings()
    {
        PauseMenuPanel.SetActive(false);
        SettingsMenuPanel.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        PauseMenuPanel.SetActive(true);
        SettingsMenuPanel.SetActive(false);
        SavePanel.SetActive(false);
        LoadPanel.SetActive(false);
    }
       

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Resume();
    }
}
