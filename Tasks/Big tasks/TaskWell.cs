using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWell : MonoBehaviour {

	public Transform bucket;
	public Transform key;
	public AudioSource audioSource;
	public AudioClip bucketSound;
	public bool isStone1;
	public bool isStone2;
	public bool isStone3;
	public bool isStone4;
	public bool isStone5;
    public GameObject stone1;
    public GameObject stone2;
    public GameObject stone3;
    public GameObject stone4;
    public GameObject stone5;
    public int stonesCount = 0;


	void Start () {

		bucket = GameObject.Find("WiadroStudnia").transform;
		key = GameObject.Find("KluczStajnia").transform;

	}
	

	void Update () {

		if(stonesCount == 5){
			key.GetComponent<Collider> ().enabled = true;
		}
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.GetComponent<Collider>().gameObject.name == "KamienStudnia1"  && isStone1 == false){
			//ZrodloDzwiekuStudnia = GetComponent<AudioSource>();
			audioSource.PlayOneShot(bucketSound);
			bucket.transform.position = new Vector3(bucket.transform.position.x, bucket.transform.position.y + 0.5f, bucket.transform.position.z);
			key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y + 0.5f, key.transform.position.z);
			isStone1 = true;
			stonesCount++;
            stone1.GetComponent<Collider>().enabled = false;
            stone1.SetActive(false);
        }

		else if(col.gameObject.GetComponent<Collider>().gameObject.name == "KamienStudnia2"  && isStone2 == false){
			//ZrodloDzwiekuStudnia = GetComponent<AudioSource>();
			audioSource.PlayOneShot(bucketSound);
			bucket.transform.position = new Vector3(bucket.transform.position.x, bucket.transform.position.y + 0.5f, bucket.transform.position.z);
			key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y + 0.5f, key.transform.position.z);
			isStone2 = true;
			stonesCount++;
            stone2.GetComponent<Collider>().enabled = false;
            stone2.SetActive(false);
        }

		else if(col.gameObject.GetComponent<Collider>().gameObject.name == "KamienStudnia3"  && isStone3 == false){
			//ZrodloDzwiekuStudnia = GetComponent<AudioSource>();
			audioSource.PlayOneShot(bucketSound);
			bucket.transform.position = new Vector3(bucket.transform.position.x, bucket.transform.position.y + 0.5f, bucket.transform.position.z);
			key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y + 0.5f, key.transform.position.z);
			isStone3 = true;
			stonesCount++;
            stone3.GetComponent<Collider>().enabled = false;
            stone3.SetActive(false);
        }

		else if(col.gameObject.GetComponent<Collider>().gameObject.name == "KamienStudnia4"  && isStone4 == false){
			//ZrodloDzwiekuStudnia = GetComponent<AudioSource>();
			audioSource.PlayOneShot(bucketSound);
			bucket.transform.position = new Vector3(bucket.transform.position.x, bucket.transform.position.y + 0.5f, bucket.transform.position.z);
			key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y + 0.5f, key.transform.position.z);
			isStone4 = true;
			stonesCount++;
            stone4.GetComponent<Collider>().enabled = false;
            stone4.SetActive(false);
        }

		else if(col.gameObject.GetComponent<Collider>().gameObject.name == "KamienStudnia5"  && isStone5 == false){
			//ZrodloDzwiekuStudnia = GetComponent<AudioSource>();
			audioSource.PlayOneShot(bucketSound);
			bucket.transform.position = new Vector3(bucket.transform.position.x, bucket.transform.position.y + 0.5f, bucket.transform.position.z);
			key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y + 0.5f, key.transform.position.z);
			isStone5 = true;
			stonesCount++;
            stone5.GetComponent<Collider>().enabled = false;
            stone5.SetActive(false);
        }

	}


}
