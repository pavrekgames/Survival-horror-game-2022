using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryButton : MonoBehaviour
{

    [SerializeField] private TaskFactory factoryTaskScript;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonSound;

    public bool isButton = false;

    void Update()
    {
        if (factoryTaskScript.isHasEnergy == false && isButton == true)
        {
            audioSource = audioSource.GetComponent<AudioSource>();
            audioSource.PlayOneShot(buttonSound);
            factoryTaskScript.isHasEnergy = true;
        }
    }
}
