using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovementTutorial : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    public AudioClip camminata;
    public AudioClip salto;
    private AudioSource audioSource;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private bool ableToMove = true;

    public GameObject dialogueTrigger;
    private void Start()
    {
        dialogueTrigger.SetActive(true);
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (ableToMove)
        {
            grounded = Physics.Raycast(orientation.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
            Debug.DrawRay(orientation.position, Vector3.down, Color.red);
            MyInput();
            SpeedControl();

            // handle drag
            if (grounded)
                rb.drag = groundDrag;
            else
                rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!PausaScript.inPausa)
            MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (!PausaScript.inPausa)
        {
            // when to jump
            if (Input.GetKey(KeyCode.Space) && readyToJump && grounded)
            {
                readyToJump = false;

                Jump();

                Invoke(nameof(ResetJump), jumpCooldown);
            }
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
      
        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

            // Play walking sound if player is moving
            if (moveDirection.magnitude > 0 && !audioSource.isPlaying)
            {
                audioSource.clip = camminata;       
                audioSource.loop = true;
                audioSource.Play();
            }
            else if (moveDirection.magnitude == 0 && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        // in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

            // Stop walking sound when in air
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        audioSource.PlayOneShot(salto);

        
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    public void EnableMove(bool enable)
    {
        ableToMove = enable;
    }
}
