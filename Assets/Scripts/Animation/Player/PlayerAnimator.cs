using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimation
{
    public WeaponAnimations[] weaponAnimations;
    Dictionary<Equipment,AnimationClip[]> weaponAnimationDict;

    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        weaponAnimationDict = new Dictionary<Equipment, AnimationClip[]>();
        foreach (WeaponAnimations wa in weaponAnimations)
        {
            weaponAnimationDict.Add(wa.weapon, wa.clips);
        }

    }

    void OnEquipmentChanged(Equipment newEquip, Equipment oldEquip)
    {
        if(newEquip != null && newEquip.equipSlot == EquipmentSlot.Weapon)
        {
            characterAnimator.SetLayerWeight(1, 1);
            if(weaponAnimationDict.ContainsKey(newEquip))
            {
                currentAttackAnimSet = weaponAnimationDict[newEquip];
            }
        }
        else if (newEquip == null && oldEquip == null && oldEquip.equipSlot == EquipmentSlot.Weapon)
        {
            characterAnimator.SetLayerWeight(1, 0);
            currentAttackAnimSet = defaultAttackAnimSet;
        }

        if (newEquip != null && newEquip.equipSlot == EquipmentSlot.Shield)
        {
            characterAnimator.SetLayerWeight(2, 1);
        }
        else if (newEquip == null && oldEquip == null && oldEquip.equipSlot == EquipmentSlot.Shield)
        {
            characterAnimator.SetLayerWeight(2, 0);
        }
    }

    [System.Serializable]
    public struct WeaponAnimations
    {
        public Equipment weapon;
        public AnimationClip[] clips;
    }
}
