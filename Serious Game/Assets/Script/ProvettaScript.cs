using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvettaScript : MonoBehaviour, IInteractable
{
    public string color; // Colore della provetta
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void Interact()
    {
        AmpollaScript ampolla = FindObjectOfType<AmpollaScript>();
        if (ampolla != null && ampolla.IsCollected())
        {
            ampolla.AddProvetta(this);
            Debug.Log($"Provetta {color} aggiunta all'ampolla");
        }
        else
        {
            Debug.Log("Nessuna ampolla raccolta o ampolla non trovata");
        }
    }

    public void ResetProvetta()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        GetComponent<Collider>().enabled = true;
        Debug.Log($"Provetta {color} resettata alla posizione originale");
    }
}