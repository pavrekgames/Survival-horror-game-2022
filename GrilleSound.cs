using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleSound : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip grilleSound;

    public bool isOpen = false;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Grille_trigger" && isOpen == false)
        {
            audioSource.PlayOneShot(grilleSound);
            isOpen = true;
        }
    }
}
