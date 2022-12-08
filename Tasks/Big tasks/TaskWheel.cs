using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWheel : MonoBehaviour {

    [SerializeField] private GameObject fixedKey;
    [SerializeField] private Transform woodenWheel;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip halfCounterSound;
    [SerializeField] private AudioClip fullCounterSound;

	public int counter = 0;
	public bool isHalfCounter = false;
	public bool isFullCounter = false;
	public float wheel_x;
	
	void Update () {

		wheel_x = woodenWheel.transform.eulerAngles.x;

		if(wheel_x > 300 && wheel_x < 310 && isFullCounter == false){
			counter++;
		}

		if(counter > 20 && isHalfCounter == false){
			HalfCounter ();
		}

		if(counter > 40 && isFullCounter == false){
			FullCounter ();
		}

	}

	void HalfCounter(){
		isHalfCounter = true;
		audioSource = woodenWheel.GetComponent<AudioSource>();
		audioSource.PlayOneShot(halfCounterSound);
	}

	void FullCounter(){
		isFullCounter = true;
		audioSource = woodenWheel.GetComponent<AudioSource>();
		audioSource.PlayOneShot(fullCounterSound);
		woodenWheel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		woodenWheel.GetComponent<SphereCollider>().enabled = false;
		
        fixedKey.SetActive(true);
    }

}
