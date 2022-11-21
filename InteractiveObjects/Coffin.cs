using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip hitSound;
    public bool isHit = false;
    public bool isOpen = false;
    private DragObject dragObjectScript;

    public GameObject usedObject;
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    void Start()
    {

        defaultPosition = usedObject.transform.position;
        defaultRotation = usedObject.transform.localRotation;
        dragObjectScript = GameObject.Find("Player").GetComponent<DragObject>();

    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Teren") && isHit == false && (usedObject.layer != 13 || dragObjectScript.objectToDrag == usedObject) && !Input.GetMouseButton(0))
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(hitSound);
            isHit = true;
        }
        else if (col.gameObject.CompareTag("Move") && isHit == false && (usedObject.layer != 13 || dragObjectScript.objectToDrag == usedObject) && !Input.GetMouseButton(0))
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(hitSound);
            isHit = true;
        }
        else if (col.gameObject.CompareTag("Untagged") && isHit == false && (usedObject.layer != 13 || dragObjectScript.objectToDrag == usedObject) && !Input.GetMouseButton(0))
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(hitSound);
            isHit = true;
        }

        else if (col.gameObject.CompareTag("Push") && isHit == false && (usedObject.layer != 13 || dragObjectScript.objectToDrag == usedObject) && !Input.GetMouseButton(0))
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(hitSound);
            isHit = true;
        }

    }

    void OnCollisionExit(Collision col)
    {

        if (col.gameObject.CompareTag("Teren") && isHit == true && Input.GetMouseButton(0))
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
        if ((other.gameObject.GetComponent<Collider>().gameObject.name == "Trigger_trumna" || other.gameObject.GetComponent<Collider>().gameObject.name == "Trigger_skrzynia") && isOpen == false)
        {
            audioSource.PlayOneShot(openSound);
            isOpen = true;
        }
    }

    public void DefaultSettings()
    {

        usedObject.transform.position = defaultPosition;
        usedObject.transform.localRotation = defaultRotation;
        isOpen = false;

    }

}
