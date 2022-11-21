using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryButton : MonoBehaviour {

	public TaskFactory factoryTaskScript;
	public AudioSource audioSource;
	public AudioClip buttonSound;
	public bool isButton = false;
	

	void Update () {

			if(factoryTaskScript.isHasEnergy == false && isButton == true){
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(buttonSound);
				factoryTaskScript.isHasEnergy = true;
			}
		}
		
}
