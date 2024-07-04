using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUDScript : MonoBehaviour
{
    public float speed = 2.0f; // Velocità di movimento della piattaforma
    public float range = 5.0f; // Distanza massima che la piattaforma può muovere da un lato all'altro

    private Vector3 startPosition; // Posizione iniziale della piattaforma

    void Start()
    {
        // Salva la posizione iniziale della piattaforma
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcola la nuova posizione della piattaforma usando Mathf.PingPong
        float newY = startPosition.y + Mathf.PingPong(Time.time * speed, range * 2) - range;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
