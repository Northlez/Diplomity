using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    IList<HolderData> holders;
    PlayerData player;

    public SaveData(IList<HolderData> holdersData, PlayerData playerData)
    {
        holders = holdersData;
        player = playerData;
    }

    public IList<HolderData> GetHoldersList()
    {
        return holders;
    }

    public PlayerData GetPlayerData()
    {
        return player;
    }
}
