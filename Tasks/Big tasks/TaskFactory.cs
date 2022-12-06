using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFactory : MonoBehaviour {

    public bool isPlaySound = false; // wznawianie i zatrzymywanie dzwiekow

    private Transform player;
	private Transform lever;
	public Transform grilles;
	public AudioSource leverAudioSource;
	public AudioSource grillesAudioSource;
	public AudioClip leverSound;
	public AudioClip grillesSound;
	public bool isHasEnergy = false;
	public bool isLever = false;
	public bool isNotification = false;
	private Light energyLight;
	private Notifications notificationScript;
	public Animator grillesAnimator;
	public string notificationString = "No energy...";


	void Start () {

		player = GameObject.Find("Player").transform;
		lever = GameObject.Find("Dzwignia").transform;
		//Kraty = GameObject.Find("KratyFabryka").transform;
		//ZrodloDzwKraty = GameObject.Find ("KratyFabryka").GetComponent<AudioSource> ();
		energyLight = GameObject.Find ("SwiatloEnergii").GetComponent<Light> ();
		notificationScript = GameObject.Find ("Player").GetComponent<Notifications> ();
		//AnimatorKraty = GameObject.Find ("KratyFabryka").GetComponent<Animator> ();
	}
	

	void Update () {

		float distance = Vector3.Distance(player.position, lever.position);
	
		if(isHasEnergy == false && leverAudioSource.isPlaying == false && isNotification == true && distance <= 11){ // 
			
			
		}else if(distance > 11 && isNotification == true){ // 
			isNotification = false;
		}else if(isHasEnergy == true){
			energyLight.color = Color.green;
		}

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isPlaySound == false)
        {

            leverAudioSource.Pause();
            grillesAudioSource.Pause();

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && isPlaySound == true)
        {

            leverAudioSource.UnPause();
            grillesAudioSource.UnPause();

            isPlaySound = false;
        }


    }

	void OnTriggerEnter(Collider other){
		
		if(other.gameObject.GetComponent<Collider>().gameObject.name == "TriggerDzwignia" && isHasEnergy == false){
			LeverNotification ();
		}else if(other.gameObject.GetComponent<Collider>().gameObject.name == "TriggerDzwignia" && isHasEnergy == true && isLever == false){
			OpenGate ();
		}
	}


	void LeverNotification(){
        leverAudioSource.clip = leverSound;
        leverAudioSource.Play();
		isNotification = true;
	}

	void OpenGate(){
        leverAudioSource.clip = leverSound;
        leverAudioSource.Play();
        grillesAudioSource.clip = grillesSound;
        grillesAudioSource.Play();
        isLever = true;
		grillesAnimator.SetTrigger("BramaTrigger");
	}
}
