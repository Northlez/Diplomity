using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 position;
    public Quaternion rotation;
    public int currentHealth;
    public List<string> itemsinInventory;
    public List<string> equippedItems;
}
