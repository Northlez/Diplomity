using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    public GameObject LoadPanel;
    public GameObject DeathPanel;

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void ActiavateLoadPanel()
    {
        DeathPanel.SetActive(false);
        LoadPanel.SetActive(true);
    }

    public void ReturnToDeathPanel()
    {
        DeathPanel.SetActive(true);
        LoadPanel.SetActive(false);
    }
}
