using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newEquip, Equipment oldEquip);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        int numOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numOfSlots];
        inventory = Inventory.instance;
    }

    public void Equip(Equipment newEquip)
    {
        int slotIndex = (int)newEquip.equipSlot;

        Equipment oldEquip = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldEquip = currentEquipment[slotIndex];
            inventory.Add(oldEquip);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newEquip, oldEquip);
        }

        currentEquipment[slotIndex] = newEquip;
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldEquip = currentEquipment[slotIndex];
            inventory.Add(oldEquip);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldEquip);
            }
        }
    }

}
