using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTpScript : MonoBehaviour
{
    // Posizione di destinazione per il teletrasporto
    public Transform Destinazione;
    public GameObject Giocatore;

    private AudioSource audioSource;
    public AudioClip suonoTeletrasporto;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Controlla se il collider appartiene al layer "Giocatore"
        if (other.gameObject.layer == LayerMask.NameToLayer("Giocatore"))
        {
            audioSource.PlayOneShot(suonoTeletrasporto);
            // Teletrasporta il giocatore alla nuova posizione
            Giocatore.transform.position = Destinazione.position;
            Debug.Log("Giocatore teletrasportato alla nuova posizione.");

            Rigidbody giocatoreRigidbody = Giocatore.GetComponent<Rigidbody>();
            if (giocatoreRigidbody != null)
            {
                giocatoreRigidbody.velocity = Vector3.zero;
                giocatoreRigidbody.angularVelocity = Vector3.zero;
                Debug.Log("Velocit� del giocatore impostata a 0.");
            }
            else
            {
                Debug.LogWarning("Rigidbody non trovato sul giocatore.");
            }
        }
    }
}
