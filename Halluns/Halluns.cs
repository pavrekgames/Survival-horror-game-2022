using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Halluns : MonoBehaviour {

    public bool isPlaySound = false;
    private PlayerManager playerManager;

    private AudioSource fireAudioSource;
    private AudioSource ganjaAudioSource;
    public AudioClip fireSound;

    public bool isStartGanja1 = false;
    public bool isStartGanja2 = false;
    public bool isStartGanja3 = false;
    public bool isStartGanja4 = false;
    public bool isStartGanja5 = false;

    public bool isEndGanja1 = false;
    public bool isEndGanja2 = false;
    public bool isEndGanja3 = false;
    public bool isEndGanja4 = false;
    public bool isEndGanja5 = false;

    private Canvas ganja1Canvas;
    private Canvas ganja2Canvas;
    private Canvas ganja3Canvas;
    private Canvas ganja4Canvas;
    private Canvas ganja5Canvas;

    public AudioClip whistleSound;
    public AudioClip flashbackSound;
    public AudioClip backgroundSound;

    public Image halluns3Image;
    public Image halluns4Image;
    public Image halluns5Image;

    public Sprite halluns3Sprite;
    public Sprite halluns4Sprite;
    public Sprite halluns5Sprite;

    private Animator halluns1Animator;
    private Animator halluns2Animator;
    private Animator halluns3Animator;
    private Animator halluns4Animator;
    private Animator halluns5Animator;

    private Animator fire1Animator;
    private Animator fire2Animator;
    private Animator fire3Animator;
    private Animator fire4Animator;
    private Animator fire5Animator;

    public bool isStartCount = false;
    public float counter = 0;

    private Ray playerAim;
    private Camera playerCam;
    public float rayLength = 4f;

    public static int fireCount = 0;

    void OnEnable () {

        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();

        ganja1Canvas = GameObject.Find("CanvasHaluny1").GetComponent<Canvas>();
        ganja2Canvas = GameObject.Find("CanvasHaluny2").GetComponent<Canvas>();
        ganja3Canvas = GameObject.Find("CanvasHaluny3").GetComponent<Canvas>();
        ganja4Canvas = GameObject.Find("CanvasHaluny4").GetComponent<Canvas>();
        ganja5Canvas = GameObject.Find("CanvasHaluny5").GetComponent<Canvas>();
        fireAudioSource = GameObject.Find("ZrodloPrzedmiot3_s").GetComponent<AudioSource>();
        ganjaAudioSource = GameObject.Find("GanjaHalucynacje2").GetComponent<AudioSource>();

        halluns1Animator = GameObject.Find("ObrazHaluny1").GetComponent<Animator>();
        halluns2Animator = GameObject.Find("ObrazHaluny2").GetComponent<Animator>();
        halluns3Animator = GameObject.Find("ObrazHaluny3").GetComponent<Animator>();
        halluns4Animator = GameObject.Find("ObrazHaluny4").GetComponent<Animator>();
        halluns5Animator = GameObject.Find("ObrazHaluny5").GetComponent<Animator>();
        fire1Animator = GameObject.Find("SwiatloGanja1").GetComponent<Animator>();
        fire2Animator = GameObject.Find("SwiatloGanja2").GetComponent<Animator>();
        fire3Animator = GameObject.Find("SwiatloGanja3").GetComponent<Animator>();
        fire4Animator = GameObject.Find("SwiatloGanja4").GetComponent<Animator>();
        fire5Animator = GameObject.Find("SwiatloGanja5").GetComponent<Animator>();

        fireAudioSource.clip = null;
        ganjaAudioSource.clip = null;

        halluns1Animator.SetTrigger("Haluny1Restart");
        halluns2Animator.SetTrigger("Haluny2Restart");
        halluns3Animator.SetTrigger("Haluny3Restart");
        halluns4Animator.SetTrigger("Haluny4Restart");
        halluns5Animator.SetTrigger("Haluny5Restart");

        halluns3Image.GetComponent<HallunsEvent3>().enabled = true;
        halluns4Image.GetComponent<HallunsEvent4>().enabled = true;
        halluns5Image.GetComponent<HallunsEvent5>().enabled = true;

        halluns3Image.sprite = halluns3Sprite;
        halluns4Image.sprite = halluns4Sprite;
        halluns5Image.sprite = halluns5Sprite;

        playerCam = Camera.main;

    }

    void OnDisable()
    {

        halluns3Image.GetComponent<HallunsEvent3>().enabled = true;
        halluns4Image.GetComponent<HallunsEvent4>().enabled = true;
        halluns5Image.GetComponent<HallunsEvent5>().enabled = true;

    }
	
	
	void Update () {

        if (Input.GetMouseButtonUp(0) && playerManager.isPlayerCanInput == true)
        {

            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9))
            {
                if (hit.collider.gameObject.tag == "Hand")
                {
                    if (hit.transform.gameObject.GetComponent<HallunsBush>())
                    {
                        hit.transform.gameObject.GetComponent<HallunsBush>().FireBush();
                    }
                }
            }
        } 

        // pauza dzwieku haluny

        if(Time.timeScale == 0 && isPlaySound == false)
        {
            ganjaAudioSource.Pause();

            isPlaySound = true;
        }
        else if (Time.timeScale == 1 && isPlaySound == true)
        {
            ganjaAudioSource.UnPause();

            isPlaySound = false;
        }

        } // klamra do update


    public void DefaultScriptSettings()
    {

        fireAudioSource.clip = null;
        ganjaAudioSource.clip = null;

        halluns1Animator.SetTrigger("Haluny1Restart");
        halluns2Animator.SetTrigger("Haluny2Restart");
        halluns3Animator.SetTrigger("Haluny3Restart");
        halluns4Animator.SetTrigger("Haluny4Restart");
        halluns5Animator.SetTrigger("Haluny5Restart");

        halluns3Image.GetComponent<HallunsEvent3>().enabled = true;
        halluns4Image.GetComponent<HallunsEvent4>().enabled = true;
        halluns5Image.GetComponent<HallunsEvent5>().enabled = true;

        halluns3Image.sprite = halluns3Sprite;
        halluns4Image.sprite = halluns4Sprite;
        halluns5Image.sprite = halluns5Sprite;

    }

}
