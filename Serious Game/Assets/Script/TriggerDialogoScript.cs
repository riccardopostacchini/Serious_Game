using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogoScript : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] lineeDialogo;
    public GameObject oggettoAttivato; // Oggetto che attiva il dialogo

    private DialogoScript dialogManager;
    private bool dialogoGi‡Avviato;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogoScript>();
        dialogoGi‡Avviato = false;
    }

    private void Update()
    {
        // Verifica se l'oggetto attivatore Ë attivo e avvia il dialogo solo una volta
        if (!dialogoGi‡Avviato && oggettoAttivato.activeSelf)
        {
            AvviaDialogo();
        }
    }

    private void AvviaDialogo()
    {
        if (dialogManager != null)
        {
            dialogManager.MostraDialogo(lineeDialogo);
            dialogoGi‡Avviato = true; // Imposta il flag per evitare di avviare il dialogo pi˘ volte
        }
    }
}
