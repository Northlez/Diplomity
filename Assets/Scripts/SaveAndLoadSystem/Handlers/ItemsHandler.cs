using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemData
{
    public string id;
    public Vector3 position;
    public Quaternion rotation;
}

public class ItemsHandler : MonoBehaviour
{
    public static List<ItemData> SaveItems()
    {
        List<ItemData> itemsData = new List<ItemData>();
        var items = FindObjectsOfType<Item3D>();
        foreach (var item in items)
        {
            ItemData itemData;
            itemData.id = item.id;
            itemData.position = item.transform.position;
            itemData.rotation = item.transform.rotation;
            itemsData.Add(itemData);
        }
        return itemsData;
    }

    public static void LoadItems(List<ItemData> itemsData)
    {
        var items = FindObjectsOfType<Item3D>();
        foreach(var item in items)
        {
            bool notPickedUp = false;
            foreach(var itemData in itemsData)
            {
                if(itemData.id == item.id)
                {
                    notPickedUp = true;
                    item.transform.position = itemData.position;
                    item.transform.rotation = itemData.rotation;
                }
            }
            if (!notPickedUp) Destroy(item.gameObject);
        }
    }
}
