using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeschioScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectSkull();
    }

    private void CollectSkull()
    {
        // Trova l'inventario del giocatore e aggiungi il teschio
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddSkull();
            Destroy(gameObject); // Rimuove il teschio dalla scena
            Debug.Log("Hai raccolto il teschio.");
        }
    }
}
