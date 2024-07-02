using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinTpScript : MonoBehaviour
{
    // Il nome della scena che vuoi caricare
    public string nomeScena;

    // Metodo che viene chiamato quando un altro collider entra nel trigger
    private void OnTriggerEnter(Collider other)
    {
        // Controlla se il collider appartiene al layer "Giocatore"
        if (other.gameObject.layer == LayerMask.NameToLayer("Giocatore"))
        {
            // Carica la nuova scena
            SceneManager.LoadScene(nomeScena);
        }
    }
}
