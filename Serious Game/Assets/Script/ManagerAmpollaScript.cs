using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAmpollaScript : MonoBehaviour
{
    public static ManagerAmpollaScript Instance { get; private set; }

    private HashSet<string> combinazioniAttivate = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantiene il manager attivo anche durante il cambio di scena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsCombinationActivated(string combinationKey)
    {
        return combinazioniAttivate.Contains(combinationKey);
    }

    public void AddCombination(string combinationKey)
    {
        combinazioniAttivate.Add(combinationKey);
    }
}
