using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public CharacterController characterControler;
	private Camera playerCamera;

    public bool isSoundPlay = false;

    private Animator animator;
	private Transform player;
	private Inventory inventoryScript;
	private Notes notesScript;
	private Headbobber headbobberScript;
	public Menu gameMenuScript;
	private Crouch crouchScript;
	private CrouchCollision crouchCollisionScript;
	public AudioSource audioSource;
    public AudioClip tiredSound;
	private Health healthScript;
	public ScreenOverlay screenOverlayScript; 

	private float playerHeight;

    public float walkVelocity = 5f;
	public float currentVelocity = 4.0f;
	public float crouchVelocity = 4f;
    public float runVelocity = 12.0f;

    public float jumpHeight = 2.0f;
	public float currentJumpHeight = 0f;
	private float jumpTime = 0;

	public float mouseSensitivity = 10f;  
	public float mouseUpDown = 0.0f;
	public float mouseUpDownRange = 89.0f;

	// stamina
	public float maxStamina = 150f;
	public float currentStamina = 150f;
	public int staminaRegenerationFactor = 8;
	public bool isRest = true;
	public bool isSprint = false;
	public bool isSprintEffect = false;
    private Image staminaBar;

	private bool isCrouch = false;

    // Kolory staminy

    private string defaultStaminaString = "#D2D7D7A7";
    private string tiredStaminaString = "#FF5A5ABA";
    private Color defaultStaminaColor;
    private Color tiredStaminaColour;

	void OnEnable(){

        screenOverlayScript = GameObject.Find("Kamera").GetComponent<ScreenOverlay>();
        player = GameObject.Find("Player").transform;
		playerCamera = Camera.main;
		characterControler = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		playerHeight = characterControler.height;
		inventoryScript = player.GetComponent<Inventory>();
		notesScript = player.GetComponent<Notes>();
		headbobberScript = GameObject.Find("Kamera").GetComponent<Headbobber>();
		crouchScript = GameObject.Find("Player").GetComponent<Crouch>();
		crouchCollisionScript = GameObject.Find("KoliderKucanie").GetComponent<CrouchCollision>();
		healthScript = GameObject.Find("Player").GetComponent<Health>();
		audioSource = GameObject.Find ("ZrodloZmeczenie_s").GetComponent<AudioSource> ();
		//Zmeczenie = Resources.Load<AudioClip>("Muzyka/Oddychanie_v1");
		gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();

        staminaBar = GameObject.Find("PasekStamina").GetComponent<Image>();
        //PasekStamina.color = Color.magenta;

        ColorUtility.TryParseHtmlString(defaultStaminaString, out defaultStaminaColor);
        ColorUtility.TryParseHtmlString(tiredStaminaString, out tiredStaminaColour);

        staminaBar.color = defaultStaminaColor;

    }

	void Update() {
		
		KeyboardInput();
		MouseInput();
		PlayerAnimation();
		Stamina ();

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isSoundPlay == false)
        {

            audioSource.Pause();

            isSoundPlay = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && isSoundPlay == true)
        {

            audioSource.UnPause();

            isSoundPlay = false;
        }

    }
		
	private void KeyboardInput(){
		
		float moveForwardBack = Input.GetAxis("Vertical") * currentVelocity;
		
		float moveLeftRight = Input.GetAxis("Horizontal") * currentVelocity;

		//Skakanie
		
		if(characterControler.isGrounded && Input.GetButton("Jump") && crouchScript.isCrouch == false){
			currentJumpHeight = jumpHeight;
		} else if (!characterControler.isGrounded ){
			//Fizyka grawitacja osi Y
			currentJumpHeight += Physics.gravity.y * Time.deltaTime;
		}

		//Bieganie
		if(Input.GetKey("left shift") && crouchScript.isCrouch == false && Input.GetAxis("Vertical") > 0 && isRest == true && screenOverlayScript.intensity == 0) {
			currentVelocity = runVelocity;
			currentStamina -= 4 * Time.deltaTime;
			isSprint = true;

		} else if(!Input.GetKey("left shift") || crouchScript.isCrouch == true || isRest == false || screenOverlayScript.intensity != 0) {
			currentVelocity = walkVelocity;
			isSprint = false;
		}
			
		Vector3 movement = new Vector3(moveLeftRight, currentJumpHeight, moveForwardBack);
		
		movement = transform.rotation * movement;

		characterControler.Move(movement * Time.deltaTime);
	}

	private void MouseInput(){
		
		float mouseLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity; 
		transform.Rotate(0, mouseLeftRight, 0);

		mouseUpDown -= Input.GetAxis("Mouse Y") * mouseSensitivity;

		mouseUpDown = Mathf.Clamp(mouseUpDown, -mouseUpDownRange, mouseUpDownRange);

		playerCamera.transform.localRotation = Quaternion.Euler(mouseUpDown, 0, 0);
	}

	private void PlayerAnimation(){

		animator.SetFloat("predkoscPoruszania" , GetForwardVelocity());
		animator.SetFloat("predkoscPoruszaniaTyl" , GetBackVelocity());
		animator.SetFloat("predkoscPoruszaniaPrawo" , GetRightVelocity());
		animator.SetFloat("predkoscPoruszaniaLewo" , GetLeftVelocity());


		if(Input.GetButton("Jump") && jumpTime <= 0 && crouchScript.isCrouch == false)
        {
			animator.SetTrigger("skok");
			jumpTime = 1.07f;
		}

		if (jumpTime > 0) {
			jumpTime -= Time.deltaTime;
		}

	} 

	protected float GetForwardVelocity(){
		if(Input.GetAxis("Vertical") > 0){
		return currentVelocity;
		}
		else if(Input.GetAxis("Vertical") > 0 && Input.GetKeyDown("left shift")){
			return runVelocity;
		}else{
			return 0;
		}
	}

	protected float GetBackVelocity(){
		if(Input.GetAxis("Vertical") < 0){
			return currentVelocity;
		}else{
			return 0;
		}
	}

	protected float GetRightVelocity(){
		if(Input.GetAxis("Horizontal") > 0){
			return currentVelocity;
		}else{
			return 0;
		}
	}

	protected float GetLeftVelocity(){
		if(Input.GetAxis("Horizontal") < 0){
			return currentVelocity;
		}else{
			return 0;
		}
	}

	public void Stamina(){

        staminaBar.fillAmount = currentStamina / maxStamina;
		
		if (currentStamina <= 0 && isRest == true && healthScript.health > 0) {
			isRest = false;
			audioSource.clip = tiredSound;
            audioSource.Play();
            //PasekStamina.color = Color.red;
            staminaBar.color = tiredStaminaColour;
		}

        if ((isSprint == false && currentStamina <= maxStamina) || ((Input.GetAxis("Vertical") == 0) && (Input.GetAxis("Horizontal") == 0) && currentStamina <= maxStamina)) 
        { // bylo to w pierwszym warunku !Input.GetKey("left shift")
			currentStamina += staminaRegenerationFactor * Time.deltaTime;
		}

		if (isRest == false && currentStamina >= 75) {
			isRest = true;
            //PasekStamina.color = Color.magenta;
            staminaBar.color = defaultStaminaColor;
        }
	}
		

}
