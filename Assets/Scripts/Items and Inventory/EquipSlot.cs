using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot: MonoBehaviour
{
    public Image icon;

    Equipment equip;

    public void AddEquip(Equipment newEquip)
    {
        equip = newEquip;

        icon.sprite = equip.icon;
        icon.enabled = true;
    }

    public void Unequip()
    {
        equip = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
