using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvambraccioScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectAvambraccio();
    }

    private void CollectAvambraccio()
    {
        
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddAvambraccio();
            Destroy(gameObject); 
        }
    }
}
