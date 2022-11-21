using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTower : MonoBehaviour {

    public bool isPlaySound = false; // wznawianie i zatrzymywanie dzwiekow

    private Transform pile;
	public Transform upperBox1;
	public Transform upperBox2;
	public AudioSource audioSource;
	public AudioClip hitSound;
	public bool isHit = false;
	public float counter = 0;


	void Awake () {

		pile = GameObject.Find("PalAmbona").transform;
		upperBox1 = GameObject.Find("SkrzyniaMisjaKojotM_gora1").transform;
		upperBox2 = GameObject.Find("SkrzyniaMisjaKojotM_gora2").transform;
	}
	

	void Update () {
		
		if(isHit == true && counter <= 5){
			counter += 1 * Time.deltaTime;
		}	

		if(counter > 4 && counter <= 5)
        {
			upperBox1.gameObject.GetComponent<Rigidbody>().mass = 700;
			upperBox2.gameObject.GetComponent<Rigidbody>().mass = 700;
		}

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isPlaySound == false)
        {

            audioSource.Pause();

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && isPlaySound == true)
        {

            audioSource.UnPause();

            isPlaySound = false;
        }


    }

	void OnCollisionEnter(Collision col){
		if(col.gameObject.GetComponent<Collider>().gameObject.name == "SkrzyniaMisjaKojotM_gora1" && isHit == false){
            pile.gameObject.GetComponent<Rigidbody>().AddForce(pile.transform.forward * 2000000f);
            isHit = true;
            //ZrodloDzwieku.PlayOneShot(DzwUderzenia);
            audioSource.clip = hitSound;
            audioSource.Play();
		}
	}
}
