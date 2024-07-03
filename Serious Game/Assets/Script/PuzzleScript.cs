using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour, IInteractable
{
    public float distanceFromPlayer = 0.75f; // Distanza dal giocatore
    private bool isCollected = false;
    private Transform playerCameraTransform; // Riferimento alla trasformazione della telecamera del giocatore

    private static PuzzleScript collectedPiece; // Pezzo di puzzle raccolto attualmente

    private void Start()
    {
        playerCameraTransform = Camera.main.transform;
    }

    public void Interact()
    {
        if (!isCollected && collectedPiece == null)
        {
            CollectPuzzlePiece();
        }
        else
        {
            Debug.Log("Già un pezzo di puzzle raccolto o questo pezzo è già raccolto.");
        }
    }

    private void CollectPuzzlePiece()
    {
        isCollected = true;
        collectedPiece = this;

        // Disattiva il collider per evitare interferenze
        GetComponent<Collider>().enabled = false;

        Debug.Log("Pezzo di puzzle raccolto.");
    }

    private void Update()
    {
        if (isCollected)
        {
            // Continua a seguire la telecamera del giocatore
            transform.position = playerCameraTransform.position + playerCameraTransform.forward * distanceFromPlayer;
            transform.rotation = Quaternion.LookRotation(playerCameraTransform.forward, playerCameraTransform.up);
        }
    }

    public bool IsCollected()
    {
        return isCollected;
    }

    public void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    public static bool HasCollectedPiece()
    {
        return collectedPiece != null;
    }

    public static PuzzleScript GetCollectedPiece()
    {
        return collectedPiece;
    }

    public static void ClearCollectedPiece()
    {
        collectedPiece = null;
    }
}
