using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IOpenCloseObject {

	public AudioSource audioSource;
	public AudioClip openSound;
	public AudioClip closeSound;
	public bool isOpen = false;
    public bool isOpenClose = false;
    public bool isNeedKey = false;

    public bool isDestroyed = false;

    public GameObject door;
    public int openForce = 9000;
    public int closeForce = 9000;
    public bool isReverse = false;

    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    void Start () {

        defaultPosition = door.transform.position;
        defaultRotation = door.transform.localRotation;

    }
		

	void OnTriggerExit(Collider col){
		if(col.gameObject.GetComponent<Collider>().gameObject.name == "Drzwi_kolider" && isOpen == false && isDestroyed == false){
            //ZrodloDzwieku = GetComponent<AudioSource>();
            //ZrodloDzwieku.PlayOneShot(Otwieranie);
            audioSource.clip = openSound;
            audioSource.Play();
			isOpen = true;
            isOpenClose = true;
        }
	}


	void OnTriggerEnter (Collider col) {
		if((col.gameObject.name == "Drzwi_kolider" || col.gameObject.name == "Kolider_tyl") && isOpen == true && isDestroyed == false)
		{
            //ZrodloDzwieku = GetComponent<AudioSource>();
            //ZrodloDzwieku.PlayOneShot(Zamykanie);
            audioSource.clip = closeSound;
            audioSource.Play();
            isOpen = false;
            isOpenClose = false;
		}
	}

    public void Open1()
    {
        if (isReverse == false && isNeedKey == false && isDestroyed == false)
        {
            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(door.transform.right * openForce);
            //OtwZam_ok = !OtwZam_ok;
            isOpenClose = true;
            Debug.Log("OtworzDrzwi");

        }
        else if(isReverse == true && isNeedKey == false && isDestroyed == false)
        {
            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(-door.transform.right * openForce);
            //OtwZam_ok = !OtwZam_ok;
            isOpenClose = true;
        }

    }

    public void Close1()
    {

        if (isReverse == false && isNeedKey == false && isDestroyed == false)
        {

            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(-door.transform.right * openForce);
            //OtwZam_ok = !OtwZam_ok;
            isOpenClose = false;
            Debug.Log("ZamknijDrzwi");

        }
        else if(isReverse == true && isNeedKey == false && isDestroyed == false)
        {
            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(door.transform.right * openForce);
            //OtwZam_ok = !OtwZam_ok;
            isOpenClose = false;
        }


    }

    public void Open2()
    {

        if (isReverse == false && isNeedKey == false && isDestroyed == false)
        {
            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(-door.transform.right * openForce);
            isOpenClose = !isOpenClose;
        }
        else if (isReverse == true && isNeedKey == false && isDestroyed == false)
        {
            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(door.transform.right * openForce);
            isOpenClose = !isOpenClose;
        }

    }

    public void Close2()
    {

        if (isReverse == false && isNeedKey == false && isDestroyed == false)
        {
            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(door.transform.right * closeForce);
            isOpenClose = !isOpenClose;
        }
        else if (isReverse == true && isNeedKey == false && isDestroyed == false)
        {
            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(-door.transform.right * closeForce);
            isOpenClose = !isOpenClose;
        }

    }

    public void DefaultSettings()
    {

        door.transform.position = defaultPosition;
        door.transform.localRotation = defaultRotation;
        isOpen = false;
        isOpenClose = false;
        isDestroyed = false;

    }

}
