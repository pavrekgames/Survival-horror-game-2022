using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallunsEvent5 : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flashbackSound;
    [SerializeField]
    private Image halluns5Image;
    [SerializeField]
    private Sprite flashbackSprite;

    void OnEnable()
    {

        audioSource = GameObject.Find("GanjaHaluns3").GetComponent<AudioSource>();
        halluns5Image = GameObject.Find("HallunsImage5").GetComponent<Image>();

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
