using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment/Weapon")]
public class Weapon : Equipment
{
    public GameObject model;

    public Vector3 inHandPosition;
    public Vector3 inHandRotation;
}
