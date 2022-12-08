using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTower : MonoBehaviour {

    public bool isPlaySound = false; 

    [SerializeField] private Transform pile;
    [SerializeField] private AudioClip hitSound;
    public AudioSource audioSource;

    public Transform upperBox1;
    public Transform upperBox2;

    public bool isHit = false;
	public float counter = 0;

	void Start () {

		pile = GameObject.Find("TaskTowerPile").transform;
		upperBox1 = GameObject.Find("TaskTowerBoxUp1").transform;
		upperBox2 = GameObject.Find("TaskTowerBoxUp2").transform;
	}
	
	void Update () {

        CheckBoxes();

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
		if(col.gameObject.GetComponent<Collider>().gameObject.name == "TaskTowerBoxUp1" && isHit == false){
            pile.gameObject.GetComponent<Rigidbody>().AddForce(pile.transform.forward * 2000000f);
            isHit = true;
            audioSource.clip = hitSound;
            audioSource.Play();
		}
	}

    void CheckBoxes()
    {
        if (isHit == true && counter <= 5)
        {
            counter += 1 * Time.deltaTime;
        }

        if (counter > 4 && counter <= 5)
        {
            upperBox1.gameObject.GetComponent<Rigidbody>().mass = 700;
            upperBox2.gameObject.GetComponent<Rigidbody>().mass = 700;
        }
    }
}
