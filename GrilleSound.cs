using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleSound : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip grilleSound;
	public bool isOpen = false;
	
	void OnTriggerExit(Collider other){
		if(other.gameObject.GetComponent<Collider>().gameObject.name == "Grille_trigger" && isOpen == false){
			audioSource.PlayOneShot(grilleSound);
			isOpen = true;
	}

	}
}
