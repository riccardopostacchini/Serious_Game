using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TibiaScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectTibia();
    }

    private void CollectTibia()
    {

        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddTibia();
            Destroy(gameObject);
        }
    }
}
