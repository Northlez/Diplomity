using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHanlder : MonoBehaviour
{
    static GameObject player;

    public static PlayerData SavePlayerData()
    {
        PlayerData playerData = new PlayerData();
        player = GameObject.FindGameObjectWithTag("Player");
        var inventory = PlayerInventory.instance;
        var stats = player.GetComponent<PlayerStats>();
        var equipment = EquipmentManager.instance;

        playerData.position = player.transform.position;
        playerData.rotation = player.transform.rotation;
        playerData.currentHealth = stats.currentHealth;
        playerData.equippedItems = new List<string>();
        playerData.itemsinInventory = new List<string>();

        foreach(var item in inventory.items)
        {
            playerData.itemsinInventory.Add(item.name);
        }
        foreach(var equip in equipment.currentEquipment)
        {
            if(equip != null)
                playerData.equippedItems.Add(equip.name);
        }

        return playerData;
    }

    public static void LoadPlayerData(PlayerData playerData)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var inventory = PlayerInventory.instance;
        var stats = player.GetComponent<PlayerStats>();
        var equipment = EquipmentManager.instance;

        player.transform.position = playerData.position;
        player.transform.rotation = playerData.rotation;
        player.transform.GetChild(0).transform.position.Set(0, 0, 0);
        stats.SetCurrentHealth(playerData.currentHealth);

        foreach(var equip in equipment.currentEquipment)
        {
            if (equip != null)
                equipment.Unequip((int)equip.equipSlot);
        }
        inventory.Clear();

        foreach(var itemName in playerData.itemsinInventory)
        {
            inventory.Add(Resources.Load<Item>("Items/" + itemName));
        }

        foreach(var equipName in playerData.equippedItems)
        {
            equipment.Equip(Resources.Load<Equipment>("Items/" + equipName));
        }

    }
}
