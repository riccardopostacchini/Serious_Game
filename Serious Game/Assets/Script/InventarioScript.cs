using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioScript : MonoBehaviour
{

    public bool hasSkull = false;
    public bool hasOmero = false;
    public bool hasColonna = false;
    public bool hasTorace = false;
    public bool hasAvambraccio = false;
    public bool hasMani = false;
    public bool hasAnca = false;
    public bool hasFemore = false;
    public bool hasTibia = false;
    public bool hasPiedi = false;
    public bool hasKey = false;

    public AudioClip keySound;
    public AudioClip skeletonSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void AddKey()
    {
        hasKey = true;
        audioSource.PlayOneShot(keySound);
    }

    public void RemoveKey()
    {
        hasKey = false;
        
    }
    public void AddSkull()
    {
        hasSkull = true;
        audioSource.PlayOneShot(skeletonSound);
        
    }

    public void RemoveSkull()
    {
        hasSkull = false;
        
    }

    public void AddOmero()
    {
        hasOmero = true;
        audioSource.PlayOneShot(skeletonSound);

    }

    public void RemoveOmero()
    {
        hasOmero = false;
        
    }

    public void AddColonna()
    {
        hasColonna = true;
        audioSource.PlayOneShot(skeletonSound);
    }

    public void RemoveColonna()
    {
        hasColonna = false;
        
    }

    public void AddTorace()
    {
        hasTorace = true;
        audioSource.PlayOneShot(skeletonSound);
    }

    public void RemoveTorace()
    {
        hasTorace = false;
        
    }

    public void AddAvambraccio()
    {
        hasAvambraccio = true;
        audioSource.PlayOneShot(skeletonSound);
    }

    public void RemoveAvambraccio()
    {
        hasAvambraccio = false;
        
    }

    public void AddMani()
    {
        hasMani = true;
        audioSource.PlayOneShot(skeletonSound);
    }

    public void RemoveMani()
    {
        hasMani = false;

    }

    public void AddAnca()
    {
        hasAnca = true;
        audioSource.PlayOneShot(skeletonSound);
    }

    public void RemoveAnca()
    {
        hasAnca = false;

    }

    public void AddFemore()
    {
        hasFemore = true;
        audioSource.PlayOneShot(skeletonSound);
    }

    public void RemoveFemore()
    {
        hasFemore = false;

    }

    public void AddTibia()
    {
        hasTibia = true;
        audioSource.PlayOneShot(skeletonSound);
    }

    public void RemoveTibia()
    {
        hasTibia = false;

    }

    public void AddPiedi()
    {
        hasPiedi = true;
        audioSource.PlayOneShot(skeletonSound);
    }

    public void RemovePiedi()
    {
        hasPiedi = false;

    }
}
