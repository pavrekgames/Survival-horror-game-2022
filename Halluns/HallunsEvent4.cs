using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HallunsEvent4 : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flashbackSound;
    [SerializeField]
    private Image halluns4Image;
    [SerializeField]
    private Sprite flashbackSprite;

    void OnEnable()
    {

        audioSource = GameObject.Find("GanjaHaluns3").GetComponent<AudioSource>();
        halluns4Image = GameObject.Find("HallunsImage4").GetComponent<Image>();
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
