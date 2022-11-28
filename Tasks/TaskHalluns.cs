using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class TaskHalluns : MonoBehaviour {

   [SerializeField] private AudioSource audioSource;
   [SerializeField] private AudioClip hallunsSound;
   [SerializeField] private Twirl twirlScript;
   [SerializeField] private Canvas hallunsCanvas;
   [SerializeField] private HallunsGarden hallunsScreenScript;
   [SerializeField] private Animator hallunsAnimator;

    public float hallunsTimer;
    public bool isHalluns;
    public bool isHallunsFlashback;

    void Start () {
		
	}
	
	void Update () {

        if (isHalluns == true && hallunsTimer < 30)
        {
            hallunsTimer += 1 * Time.deltaTime;
        }
        else
        {
            twirlScript.enabled = false;
        }

        if (isHalluns == true && hallunsTimer > 17 && hallunsTimer < 18 && isHallunsFlashback == false)
        {
            hallunsCanvas.enabled = true;
            hallunsScreenScript.enabled = true;
            hallunsAnimator.SetTrigger("HallunsGarden");
            isHallunsFlashback = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isHalluns == false)
        {
            CallHalluns();
        }
    }

    void CallHalluns()
    {
        audioSource.clip = hallunsSound;
        audioSource.Play();
        twirlScript.enabled = true;
        isHalluns = true;
    }

}
