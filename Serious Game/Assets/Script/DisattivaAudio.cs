using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisattivaAudio : MonoBehaviour
{
    public GameObject lavaPool; // La pozza di lava con l'AudioSource

    private AudioSource lavaAudioSource;

    private void Start()
    {
        if (lavaPool != null)
        {
            lavaAudioSource = lavaPool.GetComponent<AudioSource>();
            if (lavaAudioSource == null)
            {
                Debug.LogError("Nessun AudioSource trovato sulla pozza di lava.");
            }
        }
        else
        {
            Debug.LogError("Nessuna pozza di lava assegnata.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Giocatore"))
        {
            if (lavaAudioSource != null && lavaAudioSource.isPlaying)
            {
                lavaAudioSource.Stop();
                Debug.Log("Audio della pozza di lava disattivato.");
            }
        }
    }
}
