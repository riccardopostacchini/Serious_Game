using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncaScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectAnca();
    }

    private void CollectAnca()
    {

        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddAnca();
            Destroy(gameObject);
        }
    }
}
