using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    ObjectInventory objectInventory;
    PlayerInventory inventory;
    Item item;

    void Start()
    {
        inventory = PlayerInventory.instance;
    }

    public void addItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    public void clearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        inventory.DropItem(item);
        inventory.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            if(inventory.invRegime == InventoryRegime.Regular)
            {
                item.Use();
            }
            else if(inventory.invRegime == InventoryRegime.ObjectInventory && inventory.objectInventory != null)
            {
                objectInventory = inventory.objectInventory;
                objectInventory.Add(item);
                inventory.Remove(item);
            }
        }
    }

    public void HideRemoveButton()
    {
        if (removeButton.gameObject.activeSelf)
        {
            removeButton.gameObject.SetActive(false);
        }
    }

    public void ShowRemoveButton()
    {
        if (!removeButton.gameObject.activeSelf && item != null)
        {
            removeButton.gameObject.SetActive(true);
        }
    }
}
