using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggedObject : MonoBehaviour {

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource waterAudioSource;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip groundHitSound;
    [SerializeField] private AudioClip waterHitSound;

    [Header("Object")]
    [SerializeField] private GameObject draggedObject;
    [SerializeField] private bool isHit = false;
    public float objectForce = 18;
    public float objectVelocity = 7;
    private DragObject dragObjectScript;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    void Start () {

        defaultPosition = draggedObject.transform.position;
        defaultRotation = draggedObject.transform.localRotation;
        dragObjectScript = GameObject.Find("Player").GetComponent<DragObject>();

    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Teren") && isHit == false && (draggedObject.layer != 13 || dragObjectScript.objectToDrag == draggedObject))
        {
            PlayHitSound(groundHitSound);
        }
        else if (col.gameObject.CompareTag("Move") && isHit == false && (draggedObject.layer != 13 || dragObjectScript.objectToDrag == draggedObject))
        {
            PlayHitSound(hitSound);
        }
        else if (col.gameObject.CompareTag("Untagged") && isHit == false && (draggedObject.layer != 13 || dragObjectScript.objectToDrag == draggedObject))
        {
            PlayHitSound(hitSound);
        }

        else if (col.gameObject.CompareTag("Push") && isHit == false && (draggedObject.layer != 13 || dragObjectScript.objectToDrag == draggedObject))
        {
            PlayHitSound(hitSound);
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
            PlayHitSound(waterHitSound);
        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.CompareTag("Woda") && isHit == true)
        {
            isHit = false;
        }

    }

    void PlayHitSound(AudioClip hitSound)
    {
        audioSource.pitch = Random.Range(0.8f, 1.5f);
        audioSource.PlayOneShot(hitSound);
        isHit = true;
    }

    public void DefaultSettings()
    {

        draggedObject.transform.position = defaultPosition;
        draggedObject.transform.localRotation = defaultRotation;
        isHit = false;

    }

}
