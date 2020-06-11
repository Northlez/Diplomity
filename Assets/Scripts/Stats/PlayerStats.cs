using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = FindObjectOfType<HealthBarScript>();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
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
            armor.RemoveModifier(oldEquip.armor);
            damage.RemoveModifier(oldEquip.damage);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        healthBar.SetHealth(currentHealth);
    }

    public override void Die()
    {
        PlayerManager.instance.KillPlayer();
    }

    public void SetCurrentHealth(int health)
    {
        currentHealth = health;
    }
}
