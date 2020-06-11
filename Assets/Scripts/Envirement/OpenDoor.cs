using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    private Animator animator;
    public Item key;
    PlayerInventory inv;
    public bool unlocked; 

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
        if (unlocked)
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
        else if(SearchForKey())
        {
            unlocked = true;
            inv.Remove(key);
            Debug.Log("Вы открыли замок!");
        }
        
    }
}
