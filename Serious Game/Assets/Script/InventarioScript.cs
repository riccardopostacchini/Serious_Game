using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioScript : MonoBehaviour
{
    public bool hasSkull = false;
    public bool hasOmero = false;
    public bool hasKey = false;

    public void AddKey()
    {
        hasKey = true;
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
}
