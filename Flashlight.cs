using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
	
    private PlayerManager playerManagerScript;
	private Light flashlightLight;
	public AudioClip flashlightOnSound;
	public AudioClip flashlightOffSound;
	public bool isFlashlightOn;
	private Transform player;
	public int lightRange = 40;

    [SerializeField]
    private AudioSource audioSource;

    void OnEnable () {
		
        playerManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
        player = GameObject.Find("Player").transform;
        flashlightLight = GameObject.Find ("Flashlight").GetComponent<Light> ();
		audioSource = GameObject.Find ("Flashlight").GetComponent<AudioSource> ();

	}
	
	void Update () {

		if (Input.GetButtonDown ("Flashlight") && isFlashlightOn == false && playerManagerScript.isPlayerCanInput == true) {
			TurnOnFlashlight ();

		} else if (Input.GetButtonDown ("Flashlight") && isFlashlightOn == true && playerManagerScript.isPlayerCanInput == true) {
			TurnOffFlashlight ();
		}
	
		if (Input.GetMouseButton (2) && playerManagerScript.isPlayerCanInput == true) {
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
		flashlightLight.range = 100; 
		flashlightLight.spotAngle = lightRange;
		flashlightLight.intensity = 5.3f;  
	}

	private void TurnOffLongLight(){
		flashlightLight.range = 40f; 
		flashlightLight.spotAngle = 80f; 
		flashlightLight.intensity = 4.5f; 
		} 
}
