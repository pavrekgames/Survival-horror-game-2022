using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {

	public float couchFactor = 0.6f;
	public float couchTime = 5f;
	public float currentHeight;
	public float getUpHeight;
	public float crouchHeight;
	public bool isCrouch = false;
	public CrouchCollision crouchCollisionScript;
	private Transform player;
    private Map mapScript;
	private Health healthScript;
	private Inventory inventoryScript;
	private Notes notesScript;
    private Notifications notificationScript;
    public Menu gameMenuScript;
	private Animator animator;
    private AudioSource audioSource;
    public AudioClip crouchSound;

	void Awake(){

		animator = GetComponent<Animator>();

	}

	void OnEnable(){

		player = GameObject.Find("Player").transform;
        mapScript = GameObject.Find("Player").GetComponent<Map>();
        healthScript = player.GetComponent<Health>();
		inventoryScript = player.GetComponent<Inventory>();
		notesScript = player.GetComponent<Notes>();
        notificationScript = GameObject.Find("Player").GetComponent<Notifications>();
        currentHeight = transform.localScale.y;
		getUpHeight = transform.localScale.y;
		crouchHeight = transform.localScale.y * couchFactor;
		animator = GetComponent<Animator>();
		gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        audioSource = GameObject.Find("ZrodloDzwKucanie").GetComponent<AudioSource>();

    }
			

	void Update () {


		if(Input.GetButtonDown("Kucanie") && healthScript.health > 0 && isCrouch == false && inventoryScript.isPanelActive == false && inventoryScript.isInventoryActive == false && inventoryScript.isNotesActive == false && notesScript.isNotes == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && notificationScript.isTutorialNotification == false && mapScript.isMap == false)
        {

			CrouchFunc ();

		}else if(Input.GetButtonDown("Kucanie") && healthScript.health > 0 && isCrouch == true && crouchCollisionScript.isCollide == false && inventoryScript.isPanelActive == false && inventoryScript.isInventoryActive == false && inventoryScript.isNotesActive == false && notesScript.isNotes == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && notificationScript.isTutorialNotification == false && mapScript.isMap == false)
        {
			
			GetUp ();
		}

		transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, currentHeight, 5 * Time.deltaTime), transform.localScale.z);

	}

	void CrouchFunc(){
		currentHeight = crouchHeight;
		isCrouch = true;
		animator.SetBool("kucanie", true);
		animator.SetBool("wstawanie", false);
        audioSource.pitch = Random.Range(0.8f, 1.5f);
        audioSource.PlayOneShot(crouchSound);
	}
		
	public void GetUp(){
		currentHeight = getUpHeight;
		isCrouch = false;
		animator.SetBool("kucanie", false);
		animator.SetBool("wstawanie", true);
        audioSource.pitch = Random.Range(0.8f, 1.5f);
        audioSource.PlayOneShot(crouchSound);
    }

}
