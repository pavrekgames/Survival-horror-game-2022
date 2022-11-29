using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerHut : MonoBehaviour, IScreamer {

    [SerializeField] private AudioSource hutLightAudioSource;
    [SerializeField] private AudioClip hutLightSound;
    [SerializeField] private GameObject hutLight;

    public bool isCalled;

    public void CallScreamer()
    {
        hutLightAudioSource.clip = hutLightSound;
        hutLightAudioSource.Play();
        hutLight.GetComponent<Light>().enabled = true;
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
