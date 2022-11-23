using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour, IOpenCloseObject {

	public AudioSource audioSource;
	public AudioClip openSound;
	public AudioClip closeSound;
	public bool isOpen = false;
    public bool isCloseOpen = false;
    public bool isNeedKey = false;

    public GameObject usedObject;
    public int openForce = 9000;
    public int closeForce = 9000;
    public bool isReverse = false;

    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    void Start () {

        defaultPosition = usedObject.transform.position;
        defaultRotation = usedObject.transform.localRotation;

    }


	void OnTriggerExit(Collider other){
		if(other.gameObject.GetComponent<Collider>().gameObject.name == "Kolider_otworz" && isOpen == false){
            audioSource = GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.8f, 1f);
            audioSource.PlayOneShot(openSound);
			isOpen = true;
            isCloseOpen = true;
        }
	}


	void OnTriggerEnter(Collider other){
		if(other.gameObject.GetComponent<Collider>().gameObject.name == "Kolider_otworz" && isOpen == true){
            //ZrodloDzwieku = GetComponent<AudioSource>();
            //ZrodloDzwieku.pitch = Random.Range(0.8f, 1f);
            audioSource.PlayOneShot(closeSound);
			isOpen = false;
            isCloseOpen = false;
        }
	}

    public void Open1()
    {
        if(isReverse == false && isNeedKey == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.right * openForce);
            isCloseOpen = !isCloseOpen;
            Debug.Log("Otworz");

        }
        else if(isReverse == true && isNeedKey == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.right * openForce);
            isCloseOpen = !isCloseOpen;
        }

    }

    public void Close1()
    {

        if (isReverse == false && isNeedKey == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.right * openForce);
            isCloseOpen = !isCloseOpen;
            Debug.Log("Zamknij");

        }
        else if(isReverse == true && isNeedKey == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.right * openForce);
            isCloseOpen = !isCloseOpen;
        }


    }

    public void Open2()
    {

        if (isReverse == false && isNeedKey == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.right * openForce);
            isCloseOpen = !isCloseOpen;
        }
        else if(isReverse == true && isNeedKey == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.right * openForce);
            isCloseOpen = !isCloseOpen;
        }

    }

    public void Close2()
    {

        if (isReverse == false && isNeedKey == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.right * closeForce);
            isCloseOpen = !isCloseOpen;
        }
        else if(isReverse == true && isNeedKey == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.right * closeForce);
            isCloseOpen = !isCloseOpen;
        }

    }

    public void DefaultSettings()
    {

        usedObject.transform.position = defaultPosition;
        usedObject.transform.localRotation = defaultRotation;
        isOpen = false;
        isCloseOpen = false;

    }

 

}


