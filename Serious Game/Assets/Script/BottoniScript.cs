using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottoniScript : MonoBehaviour, IInteractable
{
    public enum ButtonType
    {
        IncreaseRed,
        DecreaseRed,
        IncreaseBlue,
        DecreaseBlue
    }

    public ButtonType buttonType;
    public StatuaScript statuePuzzle;

    public void Interact()
    {
        switch (buttonType)
        {
            case ButtonType.IncreaseRed:
                statuePuzzle.IncreaseRedValue();
                break;
            case ButtonType.DecreaseRed:
                statuePuzzle.DecreaseRedValue();
                break;
            case ButtonType.IncreaseBlue:
                statuePuzzle.IncreaseBlueValue();
                break;
            case ButtonType.DecreaseBlue:
                statuePuzzle.DecreaseBlueValue();
                break;
        }
    }
}
