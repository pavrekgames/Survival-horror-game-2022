using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallunsEvent5 : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip flashbackSound;
    private Image halluns5Image;
    public Sprite flashbackSprite;


    void OnEnable () {

        audioSource = GameObject.Find("GanjaHalucynacje3").GetComponent<AudioSource>();
        halluns5Image = GameObject.Find("ObrazHaluny5").GetComponent<Image>();

    }


    public void Flashback5()
    {

        audioSource.PlayOneShot(flashbackSound);

    }

    public void Flashback6()
    {

        halluns5Image.sprite = flashbackSprite;
        audioSource.PlayOneShot(flashbackSound);

    }


}
