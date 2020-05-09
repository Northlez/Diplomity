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
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(Equipment newEquip, Equipment oldEquip);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        int numOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numOfSlots];
        currentMeshes = new SkinnedMeshRenderer[numOfSlots];
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
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquip.mesh);
        currentMeshes[slotIndex] = newMesh;
        //newMesh.transform.parent = targetMesh.transform;
        if (newEquip != null && newEquip.equipSlot == EquipmentSlot.Weapon)
        {           
            newMesh.rootBone = weaponTransform;
            newMesh.transform.parent = weaponTransform;
        }
        else if (newEquip != null && newEquip.equipSlot == EquipmentSlot.Shield)
        {
            newMesh.transform.parent = shieldTransform;
            newMesh.rootBone = shieldTransform;
        }
        else
        {
            newMesh.transform.parent = targetMesh.transform;
            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
        }

        
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null )
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

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
