using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantieniCameraScript : MonoBehaviour
{
    public Transform cameraPosition;
    
    // Update is called once per frame
    public void Update()
    {
        transform.position = cameraPosition.position;
    }
}
