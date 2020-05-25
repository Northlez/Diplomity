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
        if (item != null)
        {
            bool wasPickedUp = PlayerInventory.instance.Add(item);
            if (wasPickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}
