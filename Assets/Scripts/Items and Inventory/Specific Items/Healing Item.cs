using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing Item", menuName = "Inventory/Items/Healing Item")]
public class HealingItem : Item
{
    public int amountOfHealing=0;

    public override void Use()
    {
        PlayerManager.instance.Heal(amountOfHealing);
        RemoveFromInventory();
    }
}
