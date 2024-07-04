using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToraceScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectTorace();
    }

    private void CollectTorace()
    {
        // Trova l'inventario del giocatore e aggiunge il torace
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddTorace();
            Destroy(gameObject); // Rimuove il torace dalla scena
            Debug.Log("Hai raccolto il torace.");
        }
    }
}

