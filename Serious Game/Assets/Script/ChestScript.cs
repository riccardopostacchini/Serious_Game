using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour, IInteractable
{
    public AudioClip openSound; 
    private AudioSource audioSource;
    private Animator animator;
    private bool isOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (!isOpen)
        {
            if (playerInventory.hasKey)
            {
                OpenChest();
                audioSource.PlayOneShot(openSound);
            }
        }
    }

    private void OpenChest()
    {
        animator.SetTrigger("Open");
        isOpen = true;
    }
}
