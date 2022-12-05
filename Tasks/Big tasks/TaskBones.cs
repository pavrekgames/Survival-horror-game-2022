using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBones : MonoBehaviour {

    public bool isPlaySound = false; // wznawianie i zatrzymywanie dzwiekow

    private PlayerManager playerManagerScript;
    public Inventory inventoryScript;
	public Menu gameMenuScript;

	public Transform bone1;
	public Transform bone2;
	public Transform bone3;
	public Transform bone4;
	public Transform bone5;
	private Transform bonesCollider;
	private Transform player;
	public Transform grille;
	public int bonesCount = 0;
	public AudioSource audioSource;
    public AudioSource grilleAudioSource;
	public AudioClip boneSound;
    public AudioClip grilleSound;
	public bool isBone1 = false;
	public bool isBone2 = false;
	public bool isBone3 = false;
	public bool isBone4 = false;
	public bool isBone5 = false;
	public Light lampLight;
	public bool isGrille = false;

	void OnEnable () {

		inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();

        grilleAudioSource.clip = null;

		player = GameObject.Find("Player").transform;
		bonesCollider = GameObject.Find("KoliderKosci").transform;
		grille = GameObject.Find("KratyKosci").transform;


	}


	void Update () {

		//Debug.Log(Wszystkie.name);
		float distance = Vector3.Distance(player.position, bonesCollider.position);

		if(distance <= 8){
			bonesCollider.GetComponent<Collider>().enabled = true;
		}else{
			bonesCollider.GetComponent<Collider>().enabled = false;
		}



		if(distance <= 8 && Input.GetMouseButtonDown(0) && bonesCount < 5 && playerManagerScript.isPlayerCanInput == true)
        {
			
			for(int i=0; i<inventoryScript.items.Count; i++){
				if(inventoryScript.items[i].type == "Kosc1" && inventoryScript.items[i].isUsed == true){
					audioSource = GetComponent<AudioSource>();
					audioSource.PlayOneShot(boneSound);
					isBone1 = true;
					bonesCount++;
					break;

				}
			}

			for(int i=0; i<inventoryScript.items.Count; i++){
				if(inventoryScript.items[i].type == "Kosc2" && inventoryScript.items[i].isUsed == true){
					audioSource = GetComponent<AudioSource>();
					audioSource.PlayOneShot(boneSound);
					isBone2 = true;
					bonesCount++;
					break;

				}
			}

			for(int i=0; i<inventoryScript.items.Count; i++){
				if(inventoryScript.items[i].type == "Kosc3" && inventoryScript.items[i].isUsed == true){
					audioSource = GetComponent<AudioSource>();
					audioSource.PlayOneShot(boneSound);
					isBone3 = true;
					bonesCount++;
					break;

				}
			}

			for(int i=0; i<inventoryScript.items.Count; i++){
				if(inventoryScript.items[i].type == "Kosc4" && inventoryScript.items[i].isUsed == true){
					audioSource = GetComponent<AudioSource>();
					audioSource.PlayOneShot(boneSound);
					isBone4 = true;
					bonesCount++;
					break;

				}
			}

			for(int i=0; i<inventoryScript.items.Count; i++){
				if(inventoryScript.items[i].type == "Kosc5" && inventoryScript.items[i].isUsed == true){
					audioSource = GetComponent<AudioSource>();
					audioSource.PlayOneShot(boneSound);
					isBone5 = true;
					bonesCount++;
					break;

				}
			}

		} // Klamra do pierwszego warunku

		if(isBone3 == true){
			bone3.gameObject.SetActive(true);
		}

		if(isBone5 == true){
			bone5.gameObject.SetActive(true);
		}

		if(isBone2 == true){
			bone2.gameObject.SetActive(true);
		}

		if(isBone1 == true){
			bone1.gameObject.SetActive(true);
		}

		if(isBone4 == true){
			bone4.gameObject.SetActive(true);
		}

		if(bonesCount == 5 && isGrille == false){
			lampLight.color = Color.red;
			grille.transform.position = new Vector3(grille.transform.position.x,  grille.transform.position.y - 5, grille.transform.position.z);
			isGrille = true;
            grilleAudioSource.clip = grilleSound;
            grilleAudioSource.Play();
		}

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isPlaySound == false)
        {
            grilleAudioSource.Pause();
            isPlaySound = true;

        }

        else if(Time.timeScale == 1 && isPlaySound == true)
        {
            grilleAudioSource.UnPause();
            isPlaySound = false;
        }

    }
}
