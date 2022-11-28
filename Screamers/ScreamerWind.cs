using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerWind : MonoBehaviour, IScreamer {

    private Flashlight flashlightScript;
    private AudioSource audioSource;
    private AudioClip windSound;

    public bool isCalled;

    public void CallScreamer()
    {
        audioSource.clip = windSound;
        audioSource.Play();
        flashlightScript.TurnOffFlashlight();
        isCalled = true;
    }

}
