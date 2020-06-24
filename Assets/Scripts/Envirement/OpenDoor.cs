using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    PlayerInventory inv;
    Animator animator;

    public string id;
    public Item key;
    public bool locked; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        inv = PlayerInventory.instance;
    }

    public bool SearchForKey()
    {
        return inv.items.Contains(key);
    }

    public override void Interact()
    {
        if (locked && SearchForKey())
        {
            locked = false;
            inv.Remove(key);
            Debug.Log("Вы открыли замок!");

        }
        else if(!locked)
        {
            if (!animator.GetBool("Open"))
            {
                animator.SetBool("Open", true);
            }
            else
            {
                animator.SetBool("Open", false);
            }
        }
        
    }
}
