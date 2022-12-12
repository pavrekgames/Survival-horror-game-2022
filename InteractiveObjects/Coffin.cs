using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour {

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip hitSound;

    [Header("Object")]
    [SerializeField] private GameObject usedObject;
    [SerializeField] private bool isHit = false;
    [SerializeField] private bool isOpen = false;
    private DragObject dragObjectScript;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    void Start()
    {
        defaultPosition = usedObject.transform.position;
        defaultRotation = usedObject.transform.localRotation;
        dragObjectScript = GameObject.Find("Player").GetComponent<DragObject>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Terrain") && isHit == false && (usedObject.layer != 13 || dragObjectScript.objectToDrag == usedObject) && !Input.GetMouseButton(0))
        {
            PlayHitSound();
        }
        else if (col.gameObject.CompareTag("Move") && isHit == false && (usedObject.layer != 13 || dragObjectScript.objectToDrag == usedObject) && !Input.GetMouseButton(0))
        {
            PlayHitSound();
        }
        else if (col.gameObject.CompareTag("Untagged") && isHit == false && (usedObject.layer != 13 || dragObjectScript.objectToDrag == usedObject) && !Input.GetMouseButton(0))
        {
            PlayHitSound();
        }
        else if (col.gameObject.CompareTag("Push") && isHit == false && (usedObject.layer != 13 || dragObjectScript.objectToDrag == usedObject) && !Input.GetMouseButton(0))
        {
            PlayHitSound();
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Terrain") && isHit == true && Input.GetMouseButton(0))
        {
            isHit = false;
        }

        else if (col.gameObject.CompareTag("Move") && isHit == true && Input.GetMouseButton(0))
        {
            isHit = false;
        }

        else if (col.gameObject.CompareTag("Untagged") && isHit == true && Input.GetMouseButton(0))
        {
            isHit = false;
        }

        else if (col.gameObject.CompareTag("Push") && isHit == true && Input.GetMouseButton(0))
        {
            isHit = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.GetComponent<Collider>().gameObject.name == "Trigger_coffin" || other.gameObject.GetComponent<Collider>().gameObject.name == "Trigger_box") && isOpen == false)
        {
            audioSource.PlayOneShot(openSound);
            isOpen = true;
        }
    }

    void PlayHitSound()
    {
        audioSource.pitch = Random.Range(0.8f, 1.5f);
        audioSource.PlayOneShot(hitSound);
        isHit = true;
    }

    public void DefaultSettings()
    {
        usedObject.transform.position = defaultPosition;
        usedObject.transform.localRotation = defaultRotation;
        isOpen = false;
    }
}
