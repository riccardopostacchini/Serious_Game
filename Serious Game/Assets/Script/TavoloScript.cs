using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavoloScript : MonoBehaviour, IInteractable
{
    public GameObject skullPrefab;
    public GameObject omeriPrefab;
    public GameObject colonnaPrefab;
    public GameObject toracePrefab;
    public GameObject avambraccioPrefab;
    public GameObject maniPrefab;
    public GameObject ancaPrefab;
    public GameObject femorePrefab;

    public AudioClip porta;
    private AudioSource audioSource;

    public GameObject tpPuzzle;
    public GameObject tpColori;
    public GameObject tpParkour;
    public GameObject tpStatue;
    public GameObject tpBasket;
    public GameObject tpScacchi;

    public Animator portaAnimator;

    public bool isSkullPlaced = false;
    public bool isOmeroPlaced = false;
    public bool isColonnaPlaced = false;
    public bool isToracePlaced = false;
    public bool isAvambraccioPlaced = false;
    public bool isManiPlaced = false;
    public bool isAncaPlaced = false;
    public bool isFemorePlaced = false;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
            else if (playerInventory.hasColonna && !isColonnaPlaced)
            {
                PlaceColonna(playerInventory);
            }
            else if (playerInventory.hasTorace && !isToracePlaced)
            {
                PlaceTorace(playerInventory);
            }
            else if (playerInventory.hasAvambraccio && !isAvambraccioPlaced)
            {
                PlaceAvambraccio(playerInventory);
            }
            else if (playerInventory.hasMani && !isManiPlaced)
            {
                PlaceMani(playerInventory);
            }
            else if (playerInventory.hasAnca  && !isAncaPlaced)
            {
                PlaceAnca(playerInventory);
            }
            else if (playerInventory.hasFemore && !isFemorePlaced)
            {
                PlaceFemore(playerInventory);
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
        audioSource.PlayOneShot(porta);
    }

    private void PlaceOmero(InventarioScript playerInventory)
    {
        // Posiziona gli omeri sul tavolo
        omeriPrefab.SetActive(true);
        playerInventory.RemoveOmero();
        isOmeroPlaced = true;
        Debug.Log("Omeri posizionati sul tavolo.");
        tpPuzzle.SetActive(true);

    }

    private void PlaceColonna(InventarioScript playerInventory)
    {
        // Posiziona la colonna sul tavolo
        colonnaPrefab.SetActive(true);
        playerInventory.RemoveColonna();
        isColonnaPlaced = true;
        Debug.Log("Colonna posizionata sul tavolo.");
        tpColori.SetActive(true);

    }

    private void PlaceTorace(InventarioScript playerInventory)
    {
        // Posiziona il torace sul tavolo
        toracePrefab.SetActive(true);
        playerInventory.RemoveTorace();
        isToracePlaced = true;
        Debug.Log("Torace posizionati sul tavolo.");
        tpParkour.SetActive(true);


    }

    private void PlaceAvambraccio(InventarioScript playerInventory)
    {
       avambraccioPrefab.SetActive(true);
        playerInventory.RemoveAvambraccio();
        isAvambraccioPlaced = true;
        tpStatue.SetActive(true);
    }

    private void PlaceMani(InventarioScript playerInventory)
    {

        maniPrefab.SetActive(true);
        playerInventory.RemoveMani();
        isManiPlaced = true;
        tpBasket.SetActive(true);

    }

    private void PlaceAnca(InventarioScript playerInventory)
    {

        ancaPrefab.SetActive(true);
        playerInventory.RemoveAnca();
        isAncaPlaced = true;
        tpScacchi.SetActive(true);

    }

    private void PlaceFemore(InventarioScript playerInventory)
    {

        femorePrefab.SetActive(true);
        playerInventory.RemoveFemore();
        isFemorePlaced = true;
        

    }
}
