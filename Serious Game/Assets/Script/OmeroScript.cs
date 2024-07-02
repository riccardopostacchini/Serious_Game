using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmeroScript : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectOmero();
    }

    private void CollectOmero()
    {
        // Trova l'inventario del giocatore e aggiunge gli omeri
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddOmero();
            Destroy(gameObject); // Rimuove gli omeri dalla scena
            Debug.Log("Hai raccolto gli omeri.");
        }
    }
}