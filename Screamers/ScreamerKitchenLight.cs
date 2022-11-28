using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerKitchenLight : MonoBehaviour, IScreamer {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip screamerSound;
    [SerializeField ]private Animator screamerAnimator;

    public bool isCalled;

    public void CallScreamer()
    {
        audioSource.clip = screamerSound;
        audioSource.Play();
        isCalled = true;
        screamerAnimator.SetTrigger("Lamp");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isCalled == false)
        {
            CallScreamer();
        }
    }

}
