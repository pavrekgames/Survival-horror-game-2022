using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour, IOpenCloseObject {

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    [Header("Object")]
    [SerializeField] private GameObject usedObject;
    [SerializeField] private int openForce = 9000;
    [SerializeField] private int closeForce = 9000;
    [SerializeField] private bool isReverse = false;
    [SerializeField] private bool isOpen = false;
    public bool isCloseOpen = false;
    public bool isNeedKey = false;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    void Start()
    {

        defaultPosition = usedObject.transform.position;
        defaultRotation = usedObject.transform.localRotation;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Collider_open" && isOpen == false)
        {
            audioSource.pitch = Random.Range(0.8f, 1f);
            audioSource.PlayOneShot(openSound);
            isOpen = true;
            isCloseOpen = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Collider_open" && isOpen == true)
        {
            audioSource.PlayOneShot(closeSound);
            isOpen = false;
            isCloseOpen = false;
        }
    }

    public void Open1()
    {
        if (isReverse == false && isNeedKey == false)
        {
            usedObject.GetComponent<Rigidbody>().Sleep();
            usedObject.GetComponent<Rigidbody>().AddForce(usedObject.transform.right * openForce);
            isCloseOpen = !isCloseOpen;
        }
        else if (isReverse == true && isNeedKey == false)
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

        }
        else if (isReverse == true && isNeedKey == false)
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
        else if (isReverse == true && isNeedKey == false)
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
        else if (isReverse == true && isNeedKey == false)
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


