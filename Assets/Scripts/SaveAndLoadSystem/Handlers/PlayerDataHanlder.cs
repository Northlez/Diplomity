using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDataHanlder : MonoBehaviour
{
    static GameObject player;

    public static PlayerData SavePlayerData()
    {
        PlayerData playerData = new PlayerData();
        player = PlayerManager.instance.player;
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
        
        player = PlayerManager.instance.player;
        var agent = player.GetComponent<NavMeshAgent>();
        var inventory = PlayerInventory.instance;
        var stats = player.GetComponent<PlayerStats>();
        var equipment = EquipmentManager.instance;

        agent.enabled = false;
        player.transform.position = playerData.position;
        player.transform.rotation = playerData.rotation;
        stats.SetCurrentHealth(playerData.currentHealth);
        agent.enabled = true;

        foreach(var equip in equipment.currentEquipment)
        {
            if (equip != null)
                equipment.Unequip((int)equip.equipSlot);
        }
        inventory.Clear();

        foreach(var itemName in playerData.itemsinInventory)
        {
            Item item = Resources.Load<Item>("Items/Items/" + itemName);
            if(item == null)
            {
                item = Resources.Load<Item>("Items/Equipment/" + itemName);
            }
            if (item != null)
            {
                inventory.Add(item);
                inventory.onItemChangedCallback.Invoke();
            }
        }

        foreach(var equipName in playerData.equippedItems)
        {
            Equipment equip = Resources.Load<Equipment>("Items/Equipment/" + equipName);
            equipment.Equip(equip);          
        }

    }
}
