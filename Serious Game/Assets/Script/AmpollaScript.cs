using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpollaScript : MonoBehaviour, IInteractable
{
    public GameObject ampollaArancione;
    public GameObject ampollaViola;
    public GameObject ampollaVerde;
    public GameObject ampollaVuota;
    
    public float distanceFromPlayer = 0.75f; // Distanza dal giocatore

    public bool isCollected = false;
    private Transform playerCameraTransform; // Riferimento alla trasformazione della telecamera del giocatore
    private List<ProvettaScript> collectedProvette = new List<ProvettaScript>();

    private void Start()
    {
        playerCameraTransform = Camera.main.transform;
    }

    public void Update()
    {
         
    }
    public void Interact()
    {
        if (!isCollected)
        {
            CollectAmpolla();
        }
    }

    private void CollectAmpolla()
    {
        
        isCollected = true;
        
        StartCoroutine(FollowPlayer());
        Debug.Log("Ampolla raccolta");
        GetComponent<Collider>().enabled = false;
    }

    private IEnumerator FollowPlayer()
    {
        while (isCollected)
        {
            Vector3 targetPosition = playerCameraTransform.position + playerCameraTransform.forward * distanceFromPlayer;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
            transform.rotation = Quaternion.LookRotation(playerCameraTransform.forward, Vector3.up);
            yield return null;
        }
    }

    public void AddProvetta(ProvettaScript provetta)
    {
        collectedProvette.Add(provetta);
        Debug.Log($"Provetta {provetta.color} aggiunta. Totale provette: {collectedProvette.Count}");

        if (collectedProvette.Count == 2)
        {
            MixProvette();
        }
    }

    private void MixProvette()
    {
        string color1 = collectedProvette[0].color;
        string color2 = collectedProvette[1].color;
        string combinationKey = color1 + "_" + color2;

        // Dictionary with valid combinations
        Dictionary<string, GameObject> colorCombinations = new Dictionary<string, GameObject>
        {
            { "rosso_giallo", ampollaArancione },
            { "giallo_rosso", ampollaArancione },
            { "rosso_blu", ampollaViola },
            { "blu_rosso", ampollaViola },
            { "giallo_blu", ampollaVerde },
            { "blu_giallo", ampollaVerde }
        };

        if (colorCombinations.ContainsKey(combinationKey))
        {
            GameObject resultAmpolla = colorCombinations[combinationKey];
            resultAmpolla.SetActive(true);
            Destroy(collectedProvette[0].gameObject);
            Destroy(collectedProvette[1].gameObject);
            DestroyAmpollaVuota();
            Debug.Log($"Combinazione corretta: {combinationKey}. Ampolla {resultAmpolla.name} attivata.");
        }
        else
        {
            // Reset provette to their original positions if combination is invalid
            collectedProvette[0].ResetProvetta();
            collectedProvette[1].ResetProvetta();
            Debug.Log("Combinazione errata. Provette resettate.");
        }

        collectedProvette.Clear();
    }

    private void DestroyAmpollaVuota()
    {
        if (ampollaVuota != null)
        {
            Destroy(ampollaVuota);
        }
        

        isCollected = false; // Imposta a false dopo aver distrutto l'ampolla vuota
    }

    public bool IsCollected()
    {
        if (isCollected)
        {
            isCollected = false; // Inverti il valore solo se isCollected � true
            return false; // Restituisci false dopo l'inversione
        }
        else
        {
            return isCollected; // Restituisci il valore corrente di isCollected
        }


    }

}