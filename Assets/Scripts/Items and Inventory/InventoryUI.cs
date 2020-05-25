using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryUI : MonoBehaviour
{

    #region Singleton 

    public static InventoryUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Больше одной сущности UI инвентаря");
            return;
        }
        instance = this;
    }

    #endregion

    public Transform itemsParent;
    public Transform objectItemsParent;
    public GameObject inventoryUI;

    PlayerInventory inventory;
    ObjectInventory objectInventory;

    ObjectInventorySlot[] objSlots;
    InventorySlot[] slots;

    void Start()
    {
        inventory = PlayerInventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {  
        if (Input.GetButtonDown("Inventory"))
        {
            inventory.invRegime = InventoryRegime.Regular;
            ToggleUI();
        }
    }

    void UpdateUI()
    {
        for (int i=0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].addItem(inventory.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
        if(inventory.objectInventory != null)
        {
            for (int i = 0; i < objSlots.Length; i++)
            {
                if (i < objectInventory.items.Count)
                {
                    objSlots[i].addItem(objectInventory.items[i]);
                }
                else
                {
                    objSlots[i].clearSlot();
                }
            }
        }
    }

    void ToggleUI()
    {
        Transform equipmentPanel = inventoryUI.transform.GetChild(1);
        Transform objectInventoryPanel = inventoryUI.transform.GetChild(2);

        if (inventory.invRegime == InventoryRegime.Regular)
        {
            equipmentPanel.gameObject.SetActive(true);
            objectInventoryPanel.gameObject.SetActive(false);

            foreach (InventorySlot slot in slots)
            {
                slot.ShowRemoveButton();
            }
            
        }
        else if(inventory.invRegime == InventoryRegime.ObjectInventory)
        {
            equipmentPanel.gameObject.SetActive(false);
            objectInventoryPanel.gameObject.SetActive(true);

            foreach (InventorySlot slot in slots)
            {
                slot.HideRemoveButton();
            }
            if (inventoryUI.activeSelf) inventory.invRegime = InventoryRegime.Regular;
        }
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void OpenHolder()
    {
        inventory.invRegime = InventoryRegime.ObjectInventory;
        objectInventory = inventory.objectInventory;
        objSlots = objectItemsParent.GetComponentsInChildren<ObjectInventorySlot>();
        ToggleUI();
        foreach(ObjectInventorySlot objSlot in objSlots)
        {
            objSlot.objectInventory = objectInventory;
        }

        inventory.onItemChangedCallback.Invoke();
    }
}
