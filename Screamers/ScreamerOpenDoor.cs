using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerOpenDoor : MonoBehaviour, IScreamer {

    [SerializeField] private Door doorScript;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openDoorSound;
    [SerializeField] private GameObject openDoorCollider;

    public bool isCalled;

    public void CallScreamer()
    {
        doorScript.enabled = false;
        audioSource.clip = openDoorSound;
        audioSource.Play();
        openDoorCollider.SetActive(true); 
        isCalled = true;
        openDoorCollider.gameObject.AddComponent<Rigidbody>();
        openDoorCollider.gameObject.GetComponent<Rigidbody>().mass = 2;
        openDoorCollider.gameObject.GetComponent<Rigidbody>().AddForce(openDoorCollider.transform.forward * 100);
        doorScript.isNeedKey = false;
        doorScript.enabled = true;
        doorScript.isOpen = false;
        doorScript.isOpenClose = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isCalled == false)
        {
            CallScreamer();
        }
    }

}
