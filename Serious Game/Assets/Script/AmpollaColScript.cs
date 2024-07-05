using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpollaColScript : MonoBehaviour
{
    public AudioClip attivazioneClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlaySound();
    }

    private void PlaySound()
    {
        if (attivazioneClip != null)
        {
            audioSource.PlayOneShot(attivazioneClip);
        }
    }

}
