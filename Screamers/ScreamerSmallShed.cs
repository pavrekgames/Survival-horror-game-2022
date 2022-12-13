using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerSmallShed : MonoBehaviour, IScreamer {

    [SerializeField] private AudioSource breathAudioSource;
    [SerializeField] private AudioSource bulbAudioSource;
    [SerializeField] private AudioClip breathSound;
    [SerializeField] private AudioClip bulbSound;
    [SerializeField] private GameObject shedLight;

    public bool isCalled;

    public void CallScreamer()
    {
        breathAudioSource.clip = breathSound;
        breathAudioSource.Play();
        bulbAudioSource.clip = bulbSound;
        bulbAudioSource.Play();
        isCalled = true;
        shedLight.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isCalled == false)
        {
            CallScreamer();
        }
    }
}
