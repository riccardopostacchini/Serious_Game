using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioScript : MonoBehaviour
{
    public bool hasSkull = false;

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
}
