using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadScript : MonoBehaviour
{
    public string password = "6229314";
    private string InputUser = "";

  

    public AudioClip SuonoClick;
    public AudioClip SuonoCorretto;
    public AudioClip SuonoErrato;
    AudioSource audioSource;

    public Animator animator;
    public TextMeshPro inputDisplay;

    private void Start()
    {
        InputUser = "";
        audioSource = GetComponent<AudioSource>();
        inputDisplay.text = "";
    }
    public void BottoneClick(string numero)
    {
        audioSource.PlayOneShot(SuonoClick);
        InputUser += numero;
        inputDisplay.text = InputUser;

        if (InputUser.Length >= 7)
        {
            if (InputUser == password)
            {
                Debug.Log("password corretta");
                audioSource.PlayOneShot(SuonoCorretto);
                animator.SetTrigger("Open");
                inputDisplay.text = "Corretto";
            }
            else
            {
                Debug.Log("password errata");
                audioSource.PlayOneShot(SuonoErrato);
                InputUser = "";
                inputDisplay.text = "";
            }
        }
    }

}

