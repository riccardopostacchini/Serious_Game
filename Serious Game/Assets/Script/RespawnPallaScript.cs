using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPallaScript : MonoBehaviour
{
    public Transform teleportDestination; // La destinazione del teletrasporto

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto che attraversa il trigger ha il tag "palla"
        if (other.CompareTag("palla"))
        {
            Teleport(other.gameObject);
        }
    }

    private void Teleport(GameObject objectToTeleport)
    {
        if (teleportDestination != null)
        {
            // Teletrasporta l'oggetto alla posizione della destinazione
            objectToTeleport.transform.position = teleportDestination.position;
        }
        else
        {
            Debug.LogWarning("Teleport destination non assegnato.");
        }
    }
}
