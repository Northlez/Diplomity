using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot { Head, Chest, Leags, Weapon, Shield, Feet }

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;

    public int armor;
    public int damage;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);

        RemoveFromInventory();
    }

}
