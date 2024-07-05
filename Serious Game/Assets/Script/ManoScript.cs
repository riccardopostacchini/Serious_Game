using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManoScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectMano();
    }

    private void CollectMano()
    {
        
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddColonna();
            Destroy(gameObject); 
        }
    }
}