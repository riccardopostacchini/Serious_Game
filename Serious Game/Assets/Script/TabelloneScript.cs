using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabelloneScript : MonoBehaviour, IInteractable
{
    public List<GameObject> puzzleSlots; // Lista degli slot dei pezzi di puzzle sul tabellone
    public Animator Animator;

    private int placedPiecesCount = 0; // Contatore dei pezzi di puzzle posizionati
    private const int totalPieces = 15; // Numero totale di pezzi di puzzle
    public void Interact()
    {
        Debug.Log("Interagito con il tabellone.");
        if (PuzzleScript.HasCollectedPiece())
        {
            Debug.Log("C'è un pezzo di puzzle raccolto.");
            PuzzleScript collectedPuzzlePiece = PuzzleScript.GetCollectedPiece();
            if (collectedPuzzlePiece != null && collectedPuzzlePiece.IsCollected())
            {
                PlacePuzzlePiece(collectedPuzzlePiece);
                Debug.Log("Piazzato.");
            }
            else
            {
                Debug.Log("Nessun pezzo di puzzle raccolto trovato.");
            }
        }
        else
        {
            Debug.Log("Nessun pezzo di puzzle è stato raccolto.");
        }
    }

    private void PlacePuzzlePiece(PuzzleScript puzzlePiece)
    {
        // Attiva lo slot corretto per il pezzo di puzzle raccolto
        foreach (var slot in puzzleSlots)
        {
            if (slot.name == puzzlePiece.name)
            {
                slot.SetActive(true);
                break;
            }
        }

        // Distrugge il pezzo di puzzle che il giocatore aveva in mano
        Destroy(puzzlePiece.gameObject);
        PuzzleScript.ClearCollectedPiece();
        placedPiecesCount++;
        Debug.Log("Pezzo di puzzle posizionato sul tabellone. Totale posizionati: " + placedPiecesCount);

        // Controlla se tutti i pezzi sono stati posizionati
        if (placedPiecesCount >= totalPieces)
        {
            Debug.Log("Tutti i pezzi di puzzle sono stati posizionati. Avvia l'animazione finale.");
            Animator.SetTrigger("Open");
        }
    }
}
