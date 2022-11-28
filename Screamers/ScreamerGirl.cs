using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerGirl : MonoBehaviour, IScreamer {

    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private AudioSource girlScreamAudioSource;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip girlScreamSound;

    public bool isCalled;

    public void CallScreamer()
    {
        hitAudioSource.clip = hitSound;
        hitAudioSource.Play();
        girlScreamAudioSource.clip = girlScreamSound;
        girlScreamAudioSource.Play();
        isCalled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isCalled == false)
        {
            CallScreamer();
        }
    }
}
