using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavoloScript : MonoBehaviour, IInteractable
{
    public GameObject skullPrefab;
    public GameObject omeriPrefab;

    public Animator portaAnimator;

    private bool isSkullPlaced = false;
    private bool isOmeroPlaced = false;


    public void Interact()
    {
        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            if (playerInventory.hasSkull && !isSkullPlaced)
            {
                PlaceSkull(playerInventory);
            }
            else if (playerInventory.hasOmero && !isOmeroPlaced)
            {
                PlaceOmero(playerInventory);
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

    private void PlaceOmero(InventarioScript playerInventory)
    {
        // Posiziona gli omeri sul tavolo
        omeriPrefab.SetActive(true);
        playerInventory.RemoveOmero();
        isOmeroPlaced = true;
        Debug.Log("Omeri posizionati sul tavolo.");

    }
}
