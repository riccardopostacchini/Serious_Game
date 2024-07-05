using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatuaScript : MonoBehaviour
{
    [Header("TextMeshPro Elements")]
    public TextMeshPro redValueText;
    public TextMeshPro blueValueText;

    [Header("Correct Values")]
    public int correctRedValue;
    public int correctBlueValue;

    [Header("Statue Elements")]
    public GameObject redEyes;

    private int currentRedValue;
    private int currentBlueValue;

    private ManagerStatue puzzleManager;

    private void Start()
    {
        // Initialize the values on the monitor
        currentRedValue = 0;
        currentBlueValue = 0;
        UpdateMonitor();
    }

    public void SetPuzzleManager(ManagerStatue manager)
    {
        puzzleManager = manager;
    }

    public void IncreaseRedValue()
    {
        currentRedValue++;
        UpdateMonitor();
        CheckPuzzleSolved();
    }

    public void DecreaseRedValue()
    {
        currentRedValue--;
        UpdateMonitor();
        CheckPuzzleSolved();
    }

    public void IncreaseBlueValue()
    {
        currentBlueValue++;
        UpdateMonitor();
        CheckPuzzleSolved();
    }

    public void DecreaseBlueValue()
    {
        currentBlueValue--;
        UpdateMonitor();
        CheckPuzzleSolved();
    }

    private void UpdateMonitor()
    {
        redValueText.text = currentRedValue.ToString();
        blueValueText.text = currentBlueValue.ToString();
    }

    private void CheckPuzzleSolved()
    {
        if (currentRedValue == correctRedValue && currentBlueValue == correctBlueValue)
        {
            redEyes.SetActive(false);
            Destroy(blueValueText);
            Destroy(redValueText);
            DisableButtons();

            if (puzzleManager != null)
            {
                puzzleManager.NotifyStatueSolved();
            }
        }
    }

    private void DisableButtons()
    {
        BottoniScript[] buttons = GetComponentsInChildren<BottoniScript>();
        foreach (BottoniScript button in buttons)
        {
            button.enabled = false;
        }
    }
}
