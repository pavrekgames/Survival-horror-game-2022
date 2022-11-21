using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallunsEvent3 : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip flashbackSound;
    private Image halluns3Image;
    public Sprite flashbackSprite;

    void OnEnable () {

        audioSource = GameObject.Find("GanjaHalucynacje3").GetComponent<AudioSource>();
        halluns3Image = GameObject.Find("ObrazHaluny3").GetComponent<Image>();

    }
	
	
	void Update () {
		
	}


    public void Flashback(){

        audioSource.PlayOneShot(flashbackSound);

    }

    public void Flashback2()
    {

        halluns3Image.sprite = flashbackSprite;
        audioSource.PlayOneShot(flashbackSound);

    }


}
