using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawers : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip openSound;
	public AudioClip closeSound;
    public GameObject usedObject;
	public bool isOpen = false;
    public bool isCloseOpen = false;
    public bool isBlocked = false;

    public bool isReverse = false;
    public int openForce = 9000;
    public int closeForce = 9000;

    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    void Start () {

        defaultPosition = usedObject.transform.position;
        defaultRotation = usedObject.transform.localRotation;

    }
		

	void OnTriggerExit(Collider other){
		if(other.gameObject.GetComponent<Collider>().gameObject.name == "Kolider_tyl" && isOpen == false){
            //ZrodloDzwieku = GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(openSound);
			isOpen = true;
		}
	}


	void OnTriggerEnter(Collider other){
		if(other.gameObject.GetComponent<Collider>().gameObject.name == "Kolider_tyl" && isOpen == true){
            //ZrodloDzwieku = GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(closeSound);
			isOpen = false;
            isBlocked = false;
            isCloseOpen = false;
		}
	}

    void OnColliderEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Kolider_przod" && isOpen == true)
        {
            isBlocked = true;

        }

    }

    public void OpenDrawers1() {

        if (isReverse == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.up * openForce);
            isCloseOpen = !isCloseOpen;
        }
        else
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.up * openForce);
            isCloseOpen = !isCloseOpen;
        }

    }

    public void CloseDrawers1()
    {

        if (isReverse == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.up * closeForce);
            isCloseOpen = !isCloseOpen;
        }
        else
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.up * closeForce);
            isCloseOpen = !isCloseOpen;
        }

    }

    public void OpenDrawers2()
    {

        if(isReverse == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.right * openForce);
            isCloseOpen = !isCloseOpen;
        }
        else
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.right * openForce);
            isCloseOpen = !isCloseOpen;
        }

    }

    public void CloseDrawers2()
    {

        if (isReverse == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.right * closeForce);
            isCloseOpen = !isCloseOpen;
        }
        else
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
