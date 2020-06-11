using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{

    #region Singleton 

    public static DataManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Больше одной сущности инвентаря");
            return;
        }
        instance = this;
    }

    private void Singleton(Scene scene, LoadSceneMode mode)
    {
        if (instance != null)
        {
            Debug.LogWarning("Больше одной сущности инвентаря");
            return;
        }
        instance = this;
    }

    #endregion

    bool loadedFromSave;
    string path;
    GameObject gameManager;

    public void Start()
    {
        SceneManager.sceneLoaded += onLoad;
        SceneManager.sceneLoaded += Singleton;
        gameManager = gameObject;
    }

    public void onLoad(Scene scene, LoadSceneMode mode)
    {
        if(loadedFromSave)
        {
            SaveData saveData = (SaveData)SerializationManager.Load(path);
            HolderHandler.LoadHolders(saveData.GetHoldersList());
            PlayerDataHanlder.LoadPlayerData(saveData.GetPlayerData());
            Clear();
        }
    }

    public void Set(string savePath)
    {
        loadedFromSave = true;
        path = savePath;
    }

    public void Clear()
    {
        loadedFromSave = false;
        path = string.Empty;
    }

}
