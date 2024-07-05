using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PallaScript : MonoBehaviour, IInteractable
{
    public float holdDistance = 2.0f; // Distanza dall'oggetto tenuto di fronte alla telecamera
    public float throwForce = 10.0f; // Forza con cui l'oggetto viene lanciato
    public float colliderReenableDelay = 0.1f;

    private Camera playerCamera;
    private GameObject heldObject;
    private bool isHoldingObject = false;
    private Rigidbody heldObjectRigidbody;
    private Collider heldObjectCollider;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        if (isHoldingObject)
        {
            // Mantieni l'oggetto di fronte alla telecamera
            Vector3 targetPosition = playerCamera.transform.position + playerCamera.transform.forward * holdDistance;
            heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, targetPosition, Time.deltaTime * 10);
            heldObject.transform.rotation = Quaternion.LookRotation(playerCamera.transform.forward, Vector3.up);

            // Lancia l'oggetto se viene premuto il tasto di interazione
            if (Input.GetKeyDown(KeyCode.E)) // Sostituisci con il tasto di interazione desiderato
            {
                ThrowHeldObject();
            }
        }
    }

    public void Interact()
    {
        if (!isHoldingObject)
        {
            PickupObject();
        }
    }

    private void PickupObject()
    {
        isHoldingObject = true;
        heldObject = gameObject;
        GetComponent<Collider>().enabled = false;
        heldObjectRigidbody = heldObject.GetComponent<Rigidbody>();
        heldObjectCollider = heldObject.GetComponent<Collider>();

        if (heldObjectRigidbody != null)
        {
            heldObjectRigidbody.isKinematic = true; // Disabilita la fisica mentre l'oggetto è tenuto
        }

        Debug.Log("Oggetto raccolto.");
    }

    private void ThrowHeldObject()
    {
        if (heldObjectRigidbody != null)
        {
            heldObjectRigidbody.isKinematic = false; // Riabilita la fisica
            heldObjectRigidbody.AddForce(playerCamera.transform.forward * throwForce, ForceMode.VelocityChange); // Lancia l'oggetto
        }
        if (heldObjectCollider != null)
        {
            StartCoroutine(ReenableColliderAfterDelay(colliderReenableDelay));
        }
        heldObject = null;
        isHoldingObject = false;
        
        Debug.Log("Oggetto lanciato.");
    }

    private IEnumerator ReenableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (heldObjectCollider != null)
        {
            heldObjectCollider.enabled = true;
            Debug.Log("Collider riattivato.");
        }
    }


}
