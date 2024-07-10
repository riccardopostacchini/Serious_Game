using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottoniScript : MonoBehaviour, IInteractable
{
    private AudioSource audioSource;
    public AudioClip electronicBip;
    public enum ButtonType
    {
        IncreaseRed,
        DecreaseRed,
        IncreaseBlue,
        DecreaseBlue
    }

    public ButtonType buttonType;
    public StatuaScript statuePuzzle;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Interact()
    {
        switch (buttonType)
        {
            case ButtonType.IncreaseRed:
                statuePuzzle.IncreaseRedValue();
                audioSource.PlayOneShot(electronicBip);
                break;
            case ButtonType.DecreaseRed:
                statuePuzzle.DecreaseRedValue();
                audioSource.PlayOneShot(electronicBip);
                break;
            case ButtonType.IncreaseBlue:
                statuePuzzle.IncreaseBlueValue();
                audioSource.PlayOneShot(electronicBip);
                break;
            case ButtonType.DecreaseBlue:
                statuePuzzle.DecreaseBlueValue();
                audioSource.PlayOneShot(electronicBip);
                break;
        }
    }
}
