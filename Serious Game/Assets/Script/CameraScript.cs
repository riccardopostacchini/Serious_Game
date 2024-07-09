using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public float sensX = 100f;
    public float sensY = 100f;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public Slider sensitivitySlider; // Aggiungi questa variabile per il riferimento allo slider

    private float sensitivityMultiplier = 1f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Assicurati che il valore iniziale dello slider corrisponda alla sensibilità iniziale
        if (sensitivitySlider != null)
        {
            sensitivitySlider.value = sensitivityMultiplier;
            sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity); // Aggiungi il listener per lo slider
        }
    }

    void Update()
    {
        // Applica la sensibilità del mouse
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX * sensitivityMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY * sensitivityMultiplier;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    // Metodo per aggiornare la sensibilità in base al valore dello slider
    public void UpdateSensitivity(float newSensitivity)
    {
        sensitivityMultiplier = newSensitivity;
    }
}