using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
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
            

            Rigidbody giocatoreRigidbody = Giocatore.GetComponent<Rigidbody>();
            if (giocatoreRigidbody != null)
            {
                giocatoreRigidbody.velocity = Vector3.zero;
                giocatoreRigidbody.angularVelocity = Vector3.zero;
                
            }
            else
            {
                Debug.LogWarning("Rigidbody non trovato sul giocatore.");
            }
        }
    }
}
