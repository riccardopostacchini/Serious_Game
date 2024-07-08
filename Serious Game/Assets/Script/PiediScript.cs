using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiediScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectPiedi();
    }

    private void CollectPiedi()
    {

        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddPiedi();
            Destroy(gameObject);
        }
    }
}
