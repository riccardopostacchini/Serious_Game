using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioScript : MonoBehaviour
{
    public AudioClip suonoCranio;
    public AudioClip suonoChiave;
    private AudioSource audioSource;

    public bool hasSkull = false;
    public bool hasOmero = false;
    public bool hasColonna = false;
    public bool hasTorace = false;
    public bool hasAvambraccio = false;
    public bool hasKey = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void AddKey()
    {
        hasKey = true;
        audioSource.PlayOneShot(suonoChiave);
        Debug.Log("Chiave raccolta");
    }

    public void RemoveKey()
    {
        hasKey = false;
        Debug.Log("Chiave rimossa dall'inventario");
    }
    public void AddSkull()
    {
        hasSkull = true;
        audioSource.PlayOneShot(suonoCranio);
        Debug.Log("Teschio raccolto!");
    }

    public void RemoveSkull()
    {
        hasSkull = false;
        Debug.Log("Teschio rimosso dall'inventario!");
    }

    public void AddOmero()
    {
        hasOmero = true;
        Debug.Log("Omeri raccolto!");
    }

    public void RemoveOmero()
    {
        hasOmero = false;
        Debug.Log("Omeri rimossi dall'inventario!");
    }

    public void AddColonna()
    {
        hasColonna = true;
        Debug.Log("Omeri raccolto!");
    }

    public void RemoveColonna()
    {
        hasColonna = false;
        Debug.Log("Omeri rimossi dall'inventario!");
    }

    public void AddTorace()
    {
        hasTorace = true;
        Debug.Log("Torace raccolto!");
    }

    public void RemoveTorace()
    {
        hasTorace = false;
        Debug.Log("torace rimosso dall'inventario!");
    }

    public void AddAvambraccio()
    {
        hasAvambraccio = true;
        
    }

    public void RemoveAvambraccio()
    {
        hasAvambraccio = false;
        
    }
}
