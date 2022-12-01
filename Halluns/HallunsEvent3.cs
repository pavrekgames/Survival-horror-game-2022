using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallunsEvent3 : MonoBehaviour {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flashbackSound;
    [SerializeField] private Image halluns3Image;
    [SerializeField ]private Sprite flashbackSprite;

    void OnEnable () {

        audioSource = GameObject.Find("GanjaHaluns3").GetComponent<AudioSource>();
        halluns3Image = GameObject.Find("HallunsImage3").GetComponent<Image>();

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
