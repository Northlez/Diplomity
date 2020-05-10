using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot { Head, Chest, Leags, Feet, Weapon, Shield }

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment/Armor")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot; 

    public int armor;
    public int damage;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);

        RemoveFromInventory();
    }

}
