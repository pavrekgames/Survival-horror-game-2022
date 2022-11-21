using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
	
	private Inventory inventoryScript;
	private Menu gameMenuScript;
	public Light flashlightLight;
	public AudioSource audioSource;
	public AudioClip flashlightOnSound;
	public AudioClip flashlightOffSound;
	public bool isFlashlightOn;
	private Transform player;
	private Health healthScript;
	private Notes notesScript;
    private Notifications notificationScript;
	public int lightRange = 40;

	void OnEnable () {
		
		gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
		inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
		player = GameObject.Find("Player").transform;
		healthScript = GameObject.Find("Player").GetComponent<Health>();
		notesScript = GameObject.Find("Player").GetComponent<Notes>();
        notificationScript = GameObject.Find("Player").GetComponent<Notifications>();

        flashlightLight = GameObject.Find ("Latarka").GetComponent<Light> ();
		audioSource = GameObject.Find ("Latarka").GetComponent<AudioSource> ();
		//DzwiekWlacz = Resources.Load<AudioClip>("Muzyka/Latarka_wlacz");
		//DzwiekWylacz = Resources.Load<AudioClip>("Muzyka/Latarka_wylacz");

	}
	

	void Update () {

		if (Input.GetButtonDown ("Latarka") && isFlashlightOn == false && healthScript.health > 0 && gameMenuScript.isMenu == false && inventoryScript.isPanelActive == false && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && notesScript.isNotes == false && inventoryScript.isTreatmentActive == false && gameMenuScript.isLoadedGame == false && inventoryScript.isCollectionActive == false && notificationScript.isTutorialNotification == false && Time.timeScale == 1) {
			TurnOnFlashlight ();

		} else if (Input.GetButtonDown ("Latarka") && isFlashlightOn == true && healthScript.health > 0 && gameMenuScript.isMenu == false && inventoryScript.isPanelActive == false && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && notesScript.isNotes == false && inventoryScript.isTreatmentActive == false && gameMenuScript.isLoadedGame == false && inventoryScript.isCollectionActive == false && notificationScript.isTutorialNotification == false && Time.timeScale == 1) {
			TurnOffFlashlight ();

		}
	
		if (Input.GetMouseButton (2) && healthScript.health > 0 && gameMenuScript.isMenu == false && inventoryScript.isPanelActive == false && inventoryScript.isPanelActive == false && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && notesScript.isNotes == false && inventoryScript.isTreatmentActive == false && gameMenuScript.isLoadedGame == false && inventoryScript.isCollectionActive == false && notificationScript.isTutorialNotification == false) {
			TurnOnLongLight ();

		} else {
			TurnOffLongLight ();

		}
}

	public void TurnOnFlashlight(){
		audioSource.PlayOneShot(flashlightOnSound);
		flashlightLight.enabled = true;
		isFlashlightOn = true;
	}
	public void TurnOffFlashlight(){
		audioSource.PlayOneShot(flashlightOffSound);
		flashlightLight.enabled = false;
		isFlashlightOn = false;
	}

	private void TurnOnLongLight(){
		//Swiatlo.type = LightType.Spot;
		flashlightLight.range = 100; // wczesniej bylo 150, 100 jest optymalne
		flashlightLight.spotAngle = lightRange;
		flashlightLight.intensity = 5.3f;  // 1.5f // bylo 3.3 i 4.3
	}

	private void TurnOffLongLight(){
		//Swiatlo.type = LightType.Point;
		flashlightLight.range = 40f; // 123.04f // bylo 50
		flashlightLight.spotAngle = 80f; // wczesniej 102 // 90 // 70
		flashlightLight.intensity = 4.5f; // bylo 2.2 // 3.3
		} 
	
}
