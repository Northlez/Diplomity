using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{

    #region Singleton 

    public static LoadingManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    #endregion

    bool loadedFromSave;
    string path;

    public void Load(SaveData data)
    {
        StartCoroutine(LoadAsync(data));
    }

    IEnumerator LoadAsync(SaveData data)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(data.GetSavedSceneIndex());

        while (!operation.isDone)
        {
            yield return null;
        }

        var stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        PlayerDataHanlder.LoadPlayerData(data.GetPlayerData());
        EnemyDataHandler.LoadEnemiesData(data.GetEnemiesData());
        HolderHandler.LoadHolders(data.GetHoldersList());
        ItemsHandler.LoadItems(data.GetItemsData());
        DoorHandler.LoadDoors(data.GetDoorsData());
    }

}
