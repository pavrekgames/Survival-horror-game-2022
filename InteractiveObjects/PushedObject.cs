using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushedObject : MonoBehaviour {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pushSound;
    [SerializeField] private GameObject pushedObject;
    [SerializeField] private bool isDone = false;
    [SerializeField] private bool isPause = false;
    public bool isPush = false;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    void Start()
    {

        defaultPosition = pushedObject.transform.position;
        defaultRotation = pushedObject.transform.localRotation;
    }

    void Update()
    {
        if (isPush == true && isDone == false && isPause == false)
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.clip = pushSound;
            audioSource.Play();
            isDone = true;
        }
        else if (isPush == false && isDone == true && isPause == false)
        {
            audioSource.Pause();
            isPause = true;
        }
        else if (isPush == true && isDone == true && isPause == true)
        {
            audioSource.UnPause();
            isPause = false;
        }
    }

    public void DefaultSettings()
    {
        pushedObject.transform.position = defaultPosition;
        pushedObject.transform.localRotation = defaultRotation;
        isPush = false;
        isDone = false;
        isPause = false;
    }
}
