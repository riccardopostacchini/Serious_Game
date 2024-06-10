using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavoloScript : MonoBehaviour, IInteractable
{
    public GameObject skullPrefab; // Prefab del teschio da posizionare sul tavolo
    public Animator portaAnimator;
    private bool isSkullPlaced = false;

    public void Interact()
    {
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            if (playerInventory.hasSkull && !isSkullPlaced)
            {
                PlaceSkull(playerInventory);
            }
        
        }
    }

    private void PlaceSkull(InventarioScript playerInventory)
    {
        // Posiziona il teschio sul tavolo
        skullPrefab.SetActive(true);
        playerInventory.RemoveSkull();
        isSkullPlaced = true;
        Debug.Log("Teschio posizionato sul tavolo.");

        // Attiva l'animazione della porta
        portaAnimator.SetTrigger("Open");
        Debug.Log("Animazione della porta attivata");
    }
}
