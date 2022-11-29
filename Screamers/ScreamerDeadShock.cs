using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerDeadShock : MonoBehaviour, IScreamer {

    [SerializeField] private AudioSource shockAudioSource;
    [SerializeField] private AudioClip shockSound;
    [SerializeField] private AudioSource suffocateAudioSource;
    [SerializeField] private AudioClip suffocateSound;
    [SerializeField] private Animator deadAnimator;

    public bool isCalled;

    public void CallScreamer()
    {
        shockAudioSource.clip = shockSound;
        shockAudioSource.Play();
        suffocateAudioSource.clip = suffocateSound;
        suffocateAudioSource.Play();
        isCalled = true;
        deadAnimator.SetTrigger("Shock");
    }
}
