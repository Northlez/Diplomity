using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderObject : Interactable
{
    PlayerInventory inventory;
    InventoryUI ui;
    ObjectInventory objectInventory;
    public string id;
    private void Start()
    {
        inventory = PlayerInventory.instance;
        ui = InventoryUI.instance;
        objectInventory = GetComponent<ObjectInventory>();
    }

    public override void Interact()
    {
        inventory.objectInventory = objectInventory;
        ui.OpenHolder();
    }
}
