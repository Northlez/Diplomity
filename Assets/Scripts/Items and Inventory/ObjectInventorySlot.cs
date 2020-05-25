using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInventorySlot : MonoBehaviour
{
    public Image icon;

    PlayerInventory playerInventory;
    public ObjectInventory objectInventory { private get; set; }
    Item item;

    void Start()
    {
        playerInventory = PlayerInventory.instance;

    }

    public void addItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void clearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void GetItem()
    {
        if (item != null)
        {
            playerInventory.Add(item);
            objectInventory.Remove(item);
            clearSlot();
        }
        playerInventory.onItemChangedCallback.Invoke();
    }
}
