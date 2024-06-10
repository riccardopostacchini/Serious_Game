using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (!isOpen)
        {
            if (playerInventory.hasKey)
            {
                OpenChest();
            }
        }
    }

    private void OpenChest()
    {
        animator.SetTrigger("Open");
        isOpen = true;
    }
}
