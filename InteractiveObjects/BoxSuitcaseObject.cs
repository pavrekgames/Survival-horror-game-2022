using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSuitcaseObject : MonoBehaviour, IOpenCloseObject {

    [Header("Audio")]
    private AudioSource audioSource;
    private AudioClip openSound;
    private AudioClip closeSound;

    [Header("Object")]
    private GameObject usedObject;
    private int openForce = 9000;
    private int closeForce = 900;
    private bool isOpen = false;
    private bool isReverse = false;
    public bool isOpenClose = false;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    void Start() {

        defaultPosition = usedObject.transform.position;
        defaultRotation = usedObject.transform.localRotation;

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Trigger_otworz" && isOpen == false)
        {
            audioSource.PlayOneShot(openSound);
            isOpen = true;
            isOpenClose = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Trigger_otworz" && isOpen == true)
        {
            audioSource.PlayOneShot(closeSound);
            isOpen = false;
            isOpenClose = false;
        }
    }

    public void Open1()
    {
        if (isReverse == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.up * openForce); // przy walizkach up
            isOpenClose = !isOpenClose;

        }
        else
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.up * openForce);
            isOpenClose = !isOpenClose;
        }

    }

    public void Close1()
    {

        if (isReverse == false)
        {

            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.up * openForce);
            isOpenClose = !isOpenClose;

        }
        else
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.up * openForce);
            isOpenClose = !isOpenClose;
        }


    }

    public void Open2()
    {
        if (isReverse == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.forward * openForce); // przy walizkach up
            isOpenClose = !isOpenClose;

        }
        else
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.forward * openForce);
            isOpenClose = !isOpenClose;
        }

    }

    public void Close2()
    {

        if (isReverse == false)
        {

            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(-usedObject.transform.forward * openForce);
            isOpenClose = !isOpenClose;

        }
        else
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.forward * openForce);
            isOpenClose = !isOpenClose;
        }


    }

    public void DefaultSettings()
    {

        usedObject.transform.position = defaultPosition;
        usedObject.transform.localRotation = defaultRotation;
        isOpen = false;
        isOpenClose = false;

    }


}
