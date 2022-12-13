using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public bool isSoundPlay = false;

    private CharacterController characterControler;
    private Camera playerCamera;
    private Animator animator;
    private Crouch crouchScript;
    private Health healthScript;
    private ScreenOverlay screenOverlayScript;

    public AudioSource audioSource;
    [SerializeField] private AudioClip tiredSound;

    [Header("Movement")]
    public float walkVelocity = 5f;
    public float currentVelocity = 4.0f;
    public float crouchVelocity = 4f;
    public float runVelocity = 12.0f;

    [Header("Jump")]
    private float playerHeight;
    public float jumpHeight = 2.0f;
    public float currentJumpHeight = 0f;
    private float jumpTime = 0;

    [Header("Mouse")]
    public float mouseSensitivity = 10f;
    [SerializeField] private float mouseUpDown = 0.0f;
    [SerializeField] private float mouseUpDownRange = 89.0f;

    [Header("Stamina")]
    public static float maxStamina = 150f;
    public static float currentStamina = 150f;
    public int staminaRegenerationFactor = 8;
    public bool isRest = true;
    public bool isSprint = false;
    public bool isSprintEffect = false;

    void OnEnable()
    {
        screenOverlayScript = GameObject.Find("PlayerCamera").GetComponent<ScreenOverlay>();
        playerCamera = Camera.main;
        characterControler = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerHeight = characterControler.height;
        crouchScript = GameObject.Find("Player").GetComponent<Crouch>();
        healthScript = GameObject.Find("Player").GetComponent<Health>();
        audioSource = GameObject.Find("AudioSource_Tired").GetComponent<AudioSource>();
    }

    void Update()
    {

        KeyboardInput();
        MouseInput();
        PlayerAnimation();
        Stamina();

    }

    private void KeyboardInput()
    {

        float moveForwardBack = Input.GetAxis("Vertical") * currentVelocity;

        float moveLeftRight = Input.GetAxis("Horizontal") * currentVelocity;

        if (characterControler.isGrounded && Input.GetButton("Jump") && crouchScript.isCrouch == false)
        {
            currentJumpHeight = jumpHeight;
        }
        else if (!characterControler.isGrounded)
        {
            currentJumpHeight += Physics.gravity.y * Time.deltaTime;
        }

        if (Input.GetKey("left shift") && crouchScript.isCrouch == false && Input.GetAxis("Vertical") > 0 && isRest == true && screenOverlayScript.intensity == 0)
        {
            currentVelocity = runVelocity;
            currentStamina -= 4 * Time.deltaTime;
            isSprint = true;

        }
        else if (!Input.GetKey("left shift") || crouchScript.isCrouch == true || isRest == false || screenOverlayScript.intensity != 0)
        {
            currentVelocity = walkVelocity;
            isSprint = false;
        }

        Vector3 movement = new Vector3(moveLeftRight, currentJumpHeight, moveForwardBack);

        movement = transform.rotation * movement;

        characterControler.Move(movement * Time.deltaTime);
    }

    private void MouseInput()
    {

        float mouseLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, mouseLeftRight, 0);

        mouseUpDown -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        mouseUpDown = Mathf.Clamp(mouseUpDown, -mouseUpDownRange, mouseUpDownRange);

        playerCamera.transform.localRotation = Quaternion.Euler(mouseUpDown, 0, 0);
    }

    private void PlayerAnimation()
    {

        animator.SetFloat("ForwardVelocity", GetForwardVelocity());
        animator.SetFloat("BackVelocity", GetBackVelocity());
        animator.SetFloat("RightVelocity", GetRightVelocity());
        animator.SetFloat("LeftVelocity", GetLeftVelocity());

        if (Input.GetButton("Jump") && jumpTime <= 0 && crouchScript.isCrouch == false)
        {
            animator.SetTrigger("Jump");
            jumpTime = 1.07f;
        }

        if (jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }
    }

    protected float GetForwardVelocity()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            return currentVelocity;
        }
        else if (Input.GetAxis("Vertical") > 0 && Input.GetKeyDown("left shift"))
        {
            return runVelocity;
        }
        else
        {
            return 0;
        }
    }

    protected float GetBackVelocity()
    {
        if (Input.GetAxis("Vertical") < 0)
        {
            return currentVelocity;
        }
        else
        {
            return 0;
        }
    }

    protected float GetRightVelocity()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            return currentVelocity;
        }
        else
        {
            return 0;
        }
    }

    protected float GetLeftVelocity()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            return currentVelocity;
        }
        else
        {
            return 0;
        }
    }

    public void Stamina()
    {

        if (currentStamina <= 0 && isRest == true && healthScript.health > 0)
        {
            isRest = false;
            audioSource.clip = tiredSound;
            audioSource.Play();
        }

        if ((isSprint == false && currentStamina <= maxStamina) || ((Input.GetAxis("Vertical") == 0) && (Input.GetAxis("Horizontal") == 0) && currentStamina <= maxStamina))
        {
            currentStamina += staminaRegenerationFactor * Time.deltaTime;
        }

        if (isRest == false && currentStamina >= 75)
        {
            isRest = true;
        }
    }
}
