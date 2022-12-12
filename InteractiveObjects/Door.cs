using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IOpenCloseObject {

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    [Header("Object")]
    [SerializeField] private GameObject door;
    [SerializeField] private int openForce = 9000;
    [SerializeField] private int closeForce = 9000;
    [SerializeField] private bool isReverse = false;
    public bool isOpen = false;
    public bool isOpenClose = false;
    public bool isNeedKey = false;
    public bool isDestroyed = false;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    void Start()
    {
        defaultPosition = door.transform.position;
        defaultRotation = door.transform.localRotation;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<Collider>().gameObject.name == "Door_collider" && isOpen == false && isDestroyed == false)
        {
            audioSource.clip = openSound;
            audioSource.Play();
            isOpen = true;
            isOpenClose = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.name == "Door_collider" || col.gameObject.name == "Collider_back") && isOpen == true && isDestroyed == false)
        {
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
            isOpenClose = true;
        }
        else if (isReverse == true && isNeedKey == false && isDestroyed == false)
        {
            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(-door.transform.right * openForce);
            isOpenClose = true;
        }
    }

    public void Close1()
    {
        if (isReverse == false && isNeedKey == false && isDestroyed == false)
        {
            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(-door.transform.right * openForce);
            isOpenClose = false;
        }
        else if (isReverse == true && isNeedKey == false && isDestroyed == false)
        {
            door.GetComponent<Rigidbody>().Sleep();
            door.GetComponent<Rigidbody>().AddForce(door.transform.right * openForce);
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
