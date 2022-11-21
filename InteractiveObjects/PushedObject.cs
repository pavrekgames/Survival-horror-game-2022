using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushedObject : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip pushSound;
    public bool isPush = false;
    public bool isDone = false;
    public bool isPause = false;

    public GameObject pushedObject;
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;


    void Start () {

        defaultPosition = pushedObject.transform.position;
        defaultRotation = pushedObject.transform.localRotation;

    }
	
	
	void Update () {
		
        if(isPush == true && isDone == false && isPause == false)
        {
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.clip = pushSound;
            audioSource.Play();
            isDone = true;
        }

        else if(isPush == false && isDone == true && isPause == false)
        {
            audioSource.Pause();
            //Wykonano_ok = false;
            isPause = true;
        }

        else if (isPush == true && isDone == true && isPause == true)
        {
            audioSource.UnPause();
            isPause = false;
            //Wykonano_ok = true;
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
