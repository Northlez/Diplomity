using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string id;
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject item3d;

    public virtual void Use()
    {
        // Использование предмета
    }

    public void RemoveFromInventory()
    {
        PlayerInventory.instance.Remove(this);
    }
}
