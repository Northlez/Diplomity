using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SaveManager : MonoBehaviour
{

    string savePath;

    public TMP_InputField saveName;
    public GameObject loadButtonPrefab;
    public GameObject buttonsParent;
    public GameObject toMainMenuButton;

    public string[] saveFiles;

    private void Awake()
    {
        savePath = Application.dataPath + "/saves";

        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
    }

    public void SaveGame()
    {
        SaveData data = new SaveData(SceneManager.GetActiveScene().buildIndex, HolderHandler.SaveHolders(), PlayerDataHanlder.SavePlayerData(), EnemyDataHandler.SaveEnemiesData(), ItemsHandler.SaveItems(), DoorHandler.SaveDoors());
        SerializationManager.Save(saveName.text, data);
    }

    public void LoadGame(string path)
    {
        SaveData saveData = (SaveData)SerializationManager.Load(path);
        LoadingManager.instance.Load(saveData);
        DontDestroyOnLoad(LoadingManager.instance);
        Time.timeScale = 1f;
    }

    public void CheckSaveFiles()
    {
        saveFiles = Directory.GetFiles(savePath);
        Button[] buttons = buttonsParent.GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            Destroy(button.gameObject);
        }

        for (int i = 0; i < saveFiles.Length; i++)
        {
            GameObject buttonObject = Instantiate(loadButtonPrefab);
            buttonObject.transform.SetParent(buttonsParent.transform);

            var index = i;
            buttonObject.GetComponent<Button>().onClick.AddListener(() => LoadGame(saveFiles[index]));
            buttonObject.GetComponentInChildren<Text>().text = saveFiles[index].Replace(savePath + "\\", "").Replace(".save", "");
        }

        toMainMenuButton.SetActive(true);
    }

}
