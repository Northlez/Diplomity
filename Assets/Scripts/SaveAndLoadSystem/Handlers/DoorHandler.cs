using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DoorData
{
    public string id;
    public bool locked;
    public bool open;
}

public class DoorHandler : MonoBehaviour
{
    public static List<DoorData> SaveDoors()
    {
        List<DoorData> doorsData = new List<DoorData>();
        var doors = FindObjectsOfType<OpenDoor>();
        foreach (var door in doors)
        {
            DoorData doorData;
            Animator doorAnimator = door.GetComponent<Animator>();
            doorData.id = door.id;
            doorData.locked = door.locked;
            doorData.open = doorAnimator.GetBool("Open");
            doorsData.Add(doorData);
        }
        return doorsData;
    }

    public static void LoadDoors(List<DoorData> doorsData)
    {
        var doors = FindObjectsOfType<OpenDoor>();
        foreach (var door in doors)
        {
            foreach (var doorData in doorsData)
            {
                if (doorData.id == door.id)
                {
                    Animator doorAnimator = door.GetComponent<Animator>();

                    door.locked = doorData.locked;
                    doorAnimator.SetBool("Open", doorData.open);
                }
            }
        }
    }
}
