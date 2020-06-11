using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameObject dataManager;

    HolderHandler handler = new HolderHandler();

    public static bool GameIsPaused = false;

    public GameObject PauseMenuUi;

    string path;

    private void Start()
    {
        dataManager = GameObject.FindWithTag("DataManager");
        path = Application.dataPath + "/saves/HolderTestSave.save";
        
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
    }

    public void Save()
    {
        SaveData data = new SaveData(HolderHandler.SaveHolders(), PlayerDataHanlder.SavePlayerData());
        SerializationManager.Save("HolderTestSave", data);
    }

    public void Load()
    {      
        DataManager.instance.Set(path);
        DontDestroyOnLoad(dataManager);
        Resume();
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Resume();
    }
}
