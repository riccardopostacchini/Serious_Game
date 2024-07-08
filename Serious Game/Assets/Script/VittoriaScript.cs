using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VittoriaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Controlla se il collider appartiene al layer "Giocatore"
        if (other.gameObject.layer == LayerMask.NameToLayer("Giocatore"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

