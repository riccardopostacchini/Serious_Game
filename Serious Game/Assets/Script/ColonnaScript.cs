using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonnaScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectColonna();
    }

    private void CollectColonna()
    {

        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddColonna();
            Destroy(gameObject);
        }
    }
}
