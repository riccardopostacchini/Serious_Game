using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTimerScript : MonoBehaviour
{
    public GameObject[] platforms; // Array di piattaforme da attivare/disattivare
    public float toggleInterval = 5.0f; // Intervallo di tempo in secondi tra attivazione e disattivazione

    private void Start()
    {
        // Inizia la coroutine per attivare e disattivare le piattaforme
        StartCoroutine(TogglePlatforms());
    }

    private IEnumerator TogglePlatforms()
    {
        while (true)
        {
            // Attiva le piattaforme
            SetPlatformsActive(true);
            yield return new WaitForSeconds(toggleInterval);

            // Disattiva le piattaforme
            SetPlatformsActive(false);
            yield return new WaitForSeconds(toggleInterval);
        }
    }

    private void SetPlatformsActive(bool isActive)
    {
        // Attiva o disattiva tutte le piattaforme
        foreach (GameObject platform in platforms)
        {
            platform.SetActive(isActive);
        }
    }
}
