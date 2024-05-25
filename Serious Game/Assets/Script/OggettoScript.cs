using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OggettoScript : MonoBehaviour, IInteractable
{
   
    private bool isPickedUp = false;
    private Transform playerTransform;
    private float distanceToPlayer = 2.0f; // Distanza fissa tra oggetto e giocatore

    public void Interact()
    {
        isPickedUp = !isPickedUp;
        if (isPickedUp)
        {
            playerTransform = Camera.main.transform; // Assumi che la telecamera principale sia l'orientamento del giocatore
            StartCoroutine(FollowPlayer());
        }
        else
        {
            StopCoroutine(FollowPlayer());
        }
    }

    private IEnumerator FollowPlayer()
    {
        while (isPickedUp)
        {
            Vector3 targetPosition = playerTransform.position + playerTransform.forward * distanceToPlayer;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10); // Smoothing della posizione
            transform.rotation = Quaternion.Lerp(transform.rotation, playerTransform.rotation, Time.deltaTime * 10); // Smoothing della rotazione
            yield return null;
        }
    }
}
