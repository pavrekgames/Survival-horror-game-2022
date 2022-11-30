using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerSoundWithEvent : MonoBehaviour {

    public event Action OnCallScreamer;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip screamerSound;
    public bool isCalled;

    public void CallScreamer()
    {
        audioSource.clip = screamerSound;
        audioSource.Play();
        audioSource.loop = false;
        isCalled = true;

        if(OnCallScreamer != null)
        {
            OnCallScreamer.Invoke();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isCalled == false)
        {
            CallScreamer();
        }
    }
}
