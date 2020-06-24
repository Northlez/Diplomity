using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    int savedSceneIndex;
    PlayerData player;
    IList<HolderData> holders;
    List<ItemData> items;
    List<EnemiesData> enemies;
    List<DoorData> doors;

    public SaveData(int currentSceneIndex,IList<HolderData> holdersData, PlayerData playerData, List<EnemiesData> enemiesData, List<ItemData> itemsData, List<DoorData> doorsData)
    {
        savedSceneIndex = currentSceneIndex;
        player = playerData;
        holders = holdersData;
        items = itemsData;
        enemies = enemiesData;
        doors = doorsData;
    }

    public int GetSavedSceneIndex()
    {
        return savedSceneIndex;
    }

    public IList<HolderData> GetHoldersList()
    {
        return holders;
    }

    public PlayerData GetPlayerData()
    {
        return player;
    }

    public List<EnemiesData> GetEnemiesData()
    {
        return enemies;
    }

    public List<ItemData> GetItemsData()
    {
        return items;
    }

    public List<DoorData> GetDoorsData()
    {
        return doors;
    }
}
