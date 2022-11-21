using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallunsGarden : MonoBehaviour {

    private Canvas gardenHallunsCanvas;
    private AudioSource audioSource;
    public AudioClip flashbackSound;
    private Image gardenHallunsImage;

    void OnEnable () {

        audioSource = GameObject.Find("GanjaHalucynacje3").GetComponent<AudioSource>();
        gardenHallunsCanvas = GameObject.Find("CanvasHalunyOgrod").GetComponent<Canvas>();
        gardenHallunsImage = GameObject.Find("ObrazHalunyOgrod").GetComponent<Image>();
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
