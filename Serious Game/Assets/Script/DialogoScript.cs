using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoScript : MonoBehaviour
{
    public TextMeshProUGUI componenteTesto;
    public float velocitaTesto;
    public GameObject dialogBox; // Box di dialogo

    private Queue<string> lineeDialogo;
    private bool isTyping;

    // Riferimento al componente di movimento del giocatore
    private PlayerMovementTutorial playerMovement;

    private void Start()
    {
        if (componenteTesto != null)
        {
            componenteTesto.text = string.Empty;
        }
        if (dialogBox != null)
        {
            dialogBox.SetActive(false); // Nasconde la box di dialogo all'inizio
        }
        lineeDialogo = new Queue<string>();

        // Trova il componente di movimento del giocatore nella scena
        playerMovement = FindObjectOfType<PlayerMovementTutorial>();
    }

    public void MostraDialogo(string[] linee)
    {
        if (isTyping) return;

        lineeDialogo.Clear();
        foreach (string linea in linee)
        {
            lineeDialogo.Enqueue(linea);
        }

        // Disabilita il movimento del giocatore
        if (playerMovement != null)
        {
            playerMovement.EnableMove(false);
        }

        StartCoroutine(MostraProssimaLinea());
    }

    private IEnumerator MostraProssimaLinea()
    {
        isTyping = true;
        dialogBox.SetActive(true); // Mostra la box di dialogo

        while (lineeDialogo.Count > 0)
        {
            string linea = lineeDialogo.Dequeue();
            yield return StartCoroutine(DigitaLinea(linea));
            yield return new WaitForSeconds(1); // Pausa tra le linee
        }

        componenteTesto.text = string.Empty; // Pulisci il testo alla fine
        dialogBox.SetActive(false); // Nasconde la box di dialogo alla fine
        isTyping = false;

        // Riabilita il movimento del giocatore alla fine del dialogo
        if (playerMovement != null)
        {
            playerMovement.EnableMove(true);
        }
    }

    private IEnumerator DigitaLinea(string linea)
    {
        componenteTesto.text = string.Empty;
        foreach (char c in linea.ToCharArray())
        {
            componenteTesto.text += c;
            yield return new WaitForSeconds(velocitaTesto);
        }
    }
}
