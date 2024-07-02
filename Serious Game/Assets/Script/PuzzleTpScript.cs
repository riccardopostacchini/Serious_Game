using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTpScript : MonoBehaviour
{
    // Posizione di destinazione per il teletrasporto
    public Transform Destinazione;
    public GameObject Giocatore;

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se il collider appartiene al layer "Giocatore"
        if (other.gameObject.layer == LayerMask.NameToLayer("Giocatore"))
        {
            // Teletrasporta il giocatore alla nuova posizione
            Giocatore.transform.position = Destinazione.position;
            Debug.Log("Giocatore teletrasportato alla nuova posizione.");
        }
    }
}
