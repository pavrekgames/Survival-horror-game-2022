using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerSound : MonoBehaviour, IScreamer
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip screamerSound;
    public bool isCalled;

    public void CallScreamer()
    {
        audioSource.clip = screamerSound;
        audioSource.Play();
        audioSource.loop = false;
        isCalled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && isCalled == false)
        {
            CallScreamer();
        }
    }

}
