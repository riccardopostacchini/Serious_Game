using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantieniCameraScript : MonoBehaviour
{
    public Transform cameraPosition;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
    }
    // Update is called once per frame
    public void Update()
    {
        transform.position = cameraPosition.position;
    }
}
