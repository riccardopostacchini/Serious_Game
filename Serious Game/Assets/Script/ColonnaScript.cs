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
        // Trova l'inventario del giocatore e aggiunge la colonna
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddColonna();
            Destroy(gameObject); // Rimuove la colonna dalla scena
            Debug.Log("Hai raccolto la colonna.");
        }
    }
}
