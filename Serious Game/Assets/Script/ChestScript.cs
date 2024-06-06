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
        if (!isOpen)
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        animator.SetTrigger("Open");
        isOpen = true;
    }
}
