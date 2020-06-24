using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items/Healing Item")]
public class HealingItem : Item
{
    public int amountOfHealing;

    public override void Use()
    {
        PlayerManager.instance.Heal(amountOfHealing);
        RemoveFromInventory();
    }
}
