using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newEquip, Equipment oldEquip)
    {
        if (newEquip != null)
        {
            armor.AddModifier(newEquip.armor);
            damage.AddModifier(newEquip.damage);
        }

        if (oldEquip != null)
        {
            armor.RemoveModifier(newEquip.armor);
            damage.RemoveModifier(newEquip.damage);
        }
    }

    public override void Die()
    {
        PlayerManager.instance.KillPlayer();
    }
}
