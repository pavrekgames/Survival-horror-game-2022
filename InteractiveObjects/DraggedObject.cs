using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggedObject : MonoBehaviour {

    public AudioSource audioSource;
    public AudioSource waterAudioSource;
    public AudioClip hitSound;
    public AudioClip groundHitSound;
    public AudioClip waterHitSound;
    public bool isHit = false;
    public float objectForce = 18;
    public float objectVelocity = 7;
    private DragObject dragObjectScript;

    public GameObject draggedObject;
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    void Start () {

        defaultPosition = draggedObject.transform.position;
        defaultRotation = draggedObject.transform.localRotation;
        dragObjectScript = GameObject.Find("Player").GetComponent<DragObject>();

    }
	

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Teren") && isHit == false && (draggedObject.layer != 13 || dragObjectScript.objectToDrag == draggedObject))
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(groundHitSound);
            isHit = true;
        }
        else if (col.gameObject.CompareTag("Move") && isHit == false && (draggedObject.layer != 13 || dragObjectScript.objectToDrag == draggedObject))
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(hitSound);
            isHit = true;
        }
        else if (col.gameObject.CompareTag("Untagged") && isHit == false && (draggedObject.layer != 13 || dragObjectScript.objectToDrag == draggedObject))
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(hitSound);
            isHit = true;
        }

        else if (col.gameObject.CompareTag("Push") && isHit == false && (draggedObject.layer != 13 || dragObjectScript.objectToDrag == draggedObject))
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(hitSound);
            isHit = true;
        }

    }

    void OnCollisionExit(Collision col)
    {

        if (col.gameObject.CompareTag("Teren") && isHit == true)
        {
            isHit = false;
        }

        else if (col.gameObject.CompareTag("Move") && isHit == true)
        {
            isHit = false;
        }

        else if (col.gameObject.CompareTag("Untagged") && isHit == true)
        {
            isHit = false;
        }

        else if (col.gameObject.CompareTag("Push") && isHit == true)
        {
            isHit = false;
        }


    }

    void OnTriggerEnter(Collider col)
    {

       if (col.gameObject.CompareTag("Woda") && isHit == false)
        {
            waterAudioSource.pitch = Random.Range(0.8f, 1.5f);
            waterAudioSource.PlayOneShot(waterHitSound);
            isHit = true;
        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.CompareTag("Woda") && isHit == true)
        {
            isHit = false;
        }

    }

    public void DefaultSettings()
    {

        draggedObject.transform.position = defaultPosition;
        draggedObject.transform.localRotation = defaultRotation;
        isHit = false;

    }


}
