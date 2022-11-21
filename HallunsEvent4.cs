using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HallunsEvent4 : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip flashbackSound;
    private Image halluns4Image;
    public Sprite flashbackSprite;


    void OnEnable () {

        audioSource = GameObject.Find("GanjaHalucynacje3").GetComponent<AudioSource>();
        halluns4Image = GameObject.Find("ObrazHaluny4").GetComponent<Image>();

    }
	

    public void Flashback3()
    {

        audioSource.PlayOneShot(flashbackSound);

    }

    public void Flashback4()
    {

        halluns4Image.sprite = flashbackSprite;
        audioSource.PlayOneShot(flashbackSound);

    }


}
