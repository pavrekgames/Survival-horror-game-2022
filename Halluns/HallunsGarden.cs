using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallunsGarden : MonoBehaviour
{

    [SerializeField]
    private Canvas gardenHallunsCanvas;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flashbackSound;
    [SerializeField]
    private Image gardenHallunsImage;

    void OnEnable()
    {

        audioSource = GameObject.Find("GanjaHaluns3").GetComponent<AudioSource>();
        gardenHallunsCanvas = GameObject.Find("CanvasHallunsGarden").GetComponent<Canvas>();
        gardenHallunsImage = GameObject.Find("HallunsGardenImage5").GetComponent<Image>();
    }

    public void FlashbackGarden()
    {

        audioSource.PlayOneShot(flashbackSound);

    }

    public void DisableGardenHallunsCanvas()
    {

        gardenHallunsCanvas.enabled = false;

    }

}
