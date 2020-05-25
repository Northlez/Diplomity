using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InventoryRegime { Regular, ObjectInventory }
public class PlayerInventory : Inventory
{
       
    #region Singleton 

    public static PlayerInventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Больше одной сущности инвентаря");
            return;
        }
        instance = this;
    }

    #endregion

    public Transform dropTransform;
    public ObjectInventory objectInventory;
    private InventoryRegime inventoryRegime;

    public void DropItem(Item item)
    {
        if (item.item3d != null)
        {
            Vector3 dropPosition = dropTransform.position;
            Vector3 dropPositionChange = dropTransform.forward;
            Instantiate(item.item3d, dropPosition + dropPositionChange, Quaternion.Euler(0, 0, 0));
        }
    }
    
    public InventoryRegime invRegime
    {
        get
        {
            return inventoryRegime;
        }
        set
        {
            inventoryRegime = value;
        }
    }

}
