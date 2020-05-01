using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3D : Interactable
{
    public Item item;

    public override void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Debug.Log(item.name + " поднят");
            Destroy(gameObject);
        }
    }
}
