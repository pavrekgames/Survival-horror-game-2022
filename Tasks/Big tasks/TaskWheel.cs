using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWheel : MonoBehaviour {

    public GameObject fixedKey;
	public Transform woodenWheel;
	private Tasks tasksScript;
	public AudioSource audioSource;
	public AudioClip halfCounterSound;
	public AudioClip fullCounterSound;
	public int counter = 0;
	public bool isHalfCounter = false;
	public bool isFullCounter = false;
	public float x;

	void Start () {

		woodenWheel = GameObject.Find("BrakujaceDrewnianeKolo").transform;
		tasksScript = GameObject.Find ("Player").GetComponent<Tasks> ();
	}
	

	void Update () {

		x = woodenWheel.transform.eulerAngles.x;

		if(x > 300 && x < 310 && isFullCounter == false && tasksScript.isBrokenKey == true){
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
		tasksScript.isFixedKey = true;
        fixedKey.SetActive(true);

        if(tasksScript.isWorkshopTask == false)
        {
            //tasksScript.ZadanieWarsztat();
        }

    }

}
