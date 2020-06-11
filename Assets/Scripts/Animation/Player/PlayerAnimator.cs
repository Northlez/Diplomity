using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimation
{
    public WeaponAnimations[] weaponAnimations;
    Dictionary<Weapon,AnimationClip[]> weaponAnimationDict;

    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        weaponAnimationDict = new Dictionary<Weapon, AnimationClip[]>();
        foreach (WeaponAnimations wa in weaponAnimations)
        {
            weaponAnimationDict.Add(wa.weapon, wa.clips);
        }

    }

    void OnEquipmentChanged(Equipment newEquip, Equipment oldEquip)
    {
        if(newEquip != null && newEquip.equipSlot == EquipmentSlot.Weapon)
        {
            Weapon newWeapon = (Weapon)newEquip;
            characterAnimator.SetLayerWeight(1, 1);
            if(weaponAnimationDict.ContainsKey(newWeapon))
            {
                currentAttackAnimSet = weaponAnimationDict[newWeapon];
            }
        }
        else if (newEquip == null && oldEquip.equipSlot == EquipmentSlot.Weapon)
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
        public Weapon weapon;
        public AnimationClip[] clips;
    }
}
