using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BottoneScript : MonoBehaviour, IInteractable
{

    public int numeroKeypad = 1;

    public UnityEvent KeypadClick;

    public void Interact()
    {
        KeypadClick.Invoke();
    }
}

