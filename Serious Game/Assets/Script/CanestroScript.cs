using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanestroScript : MonoBehaviour
{
    public AudioClip activationSound; // Il suono da riprodurre
    

    public GameObject muretto;
    public Animator animator; // L'animator per avviare l'animazione
    public string animationTriggerName = "Open"; // Il nome del trigger dell'animazione

    private AudioSource audioSource;
    

    private void Start()
    {
        // Assicurati che ci sia un AudioSource sul GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto che attraversa il trigger ha il tag "palla"
        if (other.CompareTag("palla"))
        {
            Destroy(muretto);
            PlaySound();
            StartAnimation();
        }
    }

    private void PlaySound()
    {
        if (activationSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(activationSound);
        }
        else
        {
            Debug.LogWarning("AudioSource o activationSound non assegnato.");
        }
    }

    private void StartAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(animationTriggerName);
        }
        else
        {
            Debug.LogWarning("Animator non assegnato.");
        }
    }
}
