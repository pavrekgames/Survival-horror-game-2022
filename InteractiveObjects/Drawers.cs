using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawers : MonoBehaviour, IOpenCloseObject {

    [Header("Audio")]
    private AudioSource audioSource;
    private AudioClip openSound;
    private AudioClip closeSound;

    [Header("Object")]
    [SerializeField] private GameObject usedObject;
    private int openForce = 9000;
    private int closeForce = 9000;
    private bool isOpen = false;
    private bool isBlocked = false;
    private bool isReverse = false;
    public bool isCloseOpen = false;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    void Start()
    {
        usedObject = this.gameObject;
        defaultPosition = usedObject.transform.position;
        defaultRotation = usedObject.transform.localRotation;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Collider_back" && isOpen == false)
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(openSound);
            isOpen = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Collider_back" && isOpen == true)
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(closeSound);
            isOpen = false;
            isBlocked = false;
            isCloseOpen = false;
        }
    }

    void OnColliderEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Collider_front" && isOpen == true)
        {
            isBlocked = true;
        }
    }

    public void Open1()
    {
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

    public void Close1()
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

    public void Open2()
    {
        if (isReverse == false)
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

    public void Close2()
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
