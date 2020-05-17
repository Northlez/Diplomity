using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton 

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Больше одной сущности инвентаря");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public Transform dropTransform;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Недостаточно пространства");
            return false;
        }
        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void DropItem(Item item)
    {
        if (item.item3d != null)
        {
            Vector3 dropPosition = dropTransform.position;
            Vector3 dropPositionChange = dropTransform.forward * 2;
            Quaternion dropRotation = dropTransform.rotation;
            Instantiate(item.item3d, dropPosition + dropPositionChange, dropRotation);
        }
    }
}