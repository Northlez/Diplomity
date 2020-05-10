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

    public SkinnedMeshRenderer targetMesh;
    public Transform weaponTransform;
    public Transform shieldTransform;

    Equipment[] currentEquipment;
    GameObject[] currentModels;

    public Transform equipParent;
    EquipSlot[] equipmentSlots;

    public delegate void OnEquipmentChanged(Equipment newEquip, Equipment oldEquip);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        int numOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numOfSlots];
        currentModels = new GameObject[numOfSlots];

        equipmentSlots = equipParent.GetComponentsInChildren<EquipSlot>();

        inventory = Inventory.instance;
    }

    public void Equip(Equipment newEquip)
    {
        int slotIndex = (int)newEquip.equipSlot;

        Equipment oldEquip = null;

        if (currentEquipment[slotIndex] != null)
        {
            equipmentSlots[slotIndex].Unequip();         
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newEquip, oldEquip);
        }

        if (newEquip != null)
        {
            if (newEquip.equipSlot == EquipmentSlot.Weapon)
            {
                equipmentSlots[slotIndex].AddEquip(newEquip);
                currentEquipment[slotIndex] = newEquip;              
                Weapon newWeapon = (Weapon)newEquip;
                GameObject newModel = Instantiate(newWeapon.model);
                currentModels[slotIndex] = newModel;
                newModel.transform.parent = weaponTransform;
                newModel.transform.localPosition = newWeapon.inHandPosition;
                newModel.transform.localRotation = Quaternion.Euler(newWeapon.inHandRotation);
            }
            else if (newEquip != null && newEquip.equipSlot == EquipmentSlot.Shield)
            {
                equipmentSlots[slotIndex].AddEquip(newEquip);
                currentEquipment[slotIndex] = newEquip;
                Shield newShield = (Shield)newEquip;
                GameObject newModel = Instantiate(newShield.model);
                currentModels[slotIndex] = newModel;
                newModel.transform.parent = shieldTransform;
                newModel.transform.localPosition = newShield.inHandPosition;
                newModel.transform.localRotation = Quaternion.Euler(newShield.inHandRotation); 
            }
            else
            {
                currentEquipment[slotIndex] = newEquip;
                equipmentSlots[slotIndex].AddEquip(newEquip);
            }
           
        }
        
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentModels[slotIndex] != null )
            {
                Destroy(currentModels[slotIndex].gameObject);
            }

            Equipment oldEquip = currentEquipment[slotIndex];
            inventory.Add(oldEquip);

            equipmentSlots[slotIndex].Unequip();
            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldEquip);
            }
        }
    }

}
