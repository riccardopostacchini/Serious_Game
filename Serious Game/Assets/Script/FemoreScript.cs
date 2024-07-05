using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemoreScript : MonoBehaviour
{
    public void Interact()
    {
        CollectFemore();
    }

    private void CollectFemore()
    {

        InventarioScript playerInventory = FindObjectOfType<InventarioScript>();
        if (playerInventory != null)
        {
            playerInventory.AddFemore();
            Destroy(gameObject);
        }
    }
}
