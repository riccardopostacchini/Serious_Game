using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiaveScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectKey();
    }

    private void CollectKey()
    {
        // Trova l'inventario del giocatore e aggiungi la chiave
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddKey();
            Destroy(gameObject); // Rimuove la chiave dalla scena
            Debug.Log("Hai raccolto la chiave.");
        }
    }
}
