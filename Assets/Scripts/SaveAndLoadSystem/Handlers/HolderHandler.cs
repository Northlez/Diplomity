using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderHandler : MonoBehaviour
{

    public static IList<HolderData> SaveHolders()
    {
        IList<HolderData> holdersData = new List<HolderData>();
        var holders = FindObjectsOfType<ObjectInventory>();
        foreach (var holder in holders)
        {
            HolderData holderData = new HolderData();
            holderData.id = holder.GetComponent<HolderObject>().id;
            holderData.itemsNames = new List<string>();
            for(int i=0; i<holder.items.Count; i++)
            {
                if (holder.items[i] != null)
                {
                    holderData.itemsNames.Add(holder.items[i].name);
                }
            }
            holdersData.Add(holderData);
        }
        return holdersData;
    }

    public static void LoadHolders(IList<HolderData> holdersData)
    { 
        var holders = FindObjectsOfType<HolderObject>();
        foreach (HolderData holderData in holdersData)
        {
            //Проходим по всем объектам-холдерам в сцене
            foreach(HolderObject holder in holders)
            {
                //Если ID данных и ID объекта совпадают -- добавляем все предметы из данных
                if (holderData.id==holder.id)
                {
                    ObjectInventory inv = holder.GetComponent<ObjectInventory>();
                    inv.Clear();
                    foreach(string name in holderData.itemsNames)
                    {
                        inv.Add(Resources.Load<Item>("Items/"+name));
                    }
                    break;
                }
            }
        }
    }
}
