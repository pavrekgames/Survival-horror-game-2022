using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerWind : MonoBehaviour, IScreamer {

    [SerializeField] private Flashlight flashlightScript;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip windSound;

    public bool isCalled;

    public void CallScreamer()
    {
        audioSource.clip = windSound;
        audioSource.Play();
        flashlightScript.TurnOffFlashlight();
        isCalled = true;
    }
}
