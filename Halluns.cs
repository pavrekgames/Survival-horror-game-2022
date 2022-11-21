using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Halluns : MonoBehaviour {

    public bool DzwiekPlay_ok = false; // wznawianie i zatrzymywanie dzwiekow

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
    private Menu gameMenuScript;
    private Inventory inventoryScript;
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

    public int fireCount = 0;

    void OnEnable () {

        ganja1Canvas = GameObject.Find("CanvasHaluny1").GetComponent<Canvas>();
        ganja2Canvas = GameObject.Find("CanvasHaluny2").GetComponent<Canvas>();
        ganja3Canvas = GameObject.Find("CanvasHaluny3").GetComponent<Canvas>();
        ganja4Canvas = GameObject.Find("CanvasHaluny4").GetComponent<Canvas>();
        ganja5Canvas = GameObject.Find("CanvasHaluny5").GetComponent<Canvas>();
        fireAudioSource = GameObject.Find("ZrodloPrzedmiot3_s").GetComponent<AudioSource>();
        ganjaAudioSource = GameObject.Find("GanjaHalucynacje2").GetComponent<AudioSource>();
        gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();

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
        //Debug.Log("WylaczonyHaluny");

    }
	
	
	void Update () {

        if (Input.GetMouseButtonUp(0) && gameMenuScript.isMenu == false && inventoryScript.isPanelActive == false && inventoryScript.isInventoryActive == false && inventoryScript.isNotesActive == false && inventoryScript.isTreatmentActive == false && gameMenuScript.isLoadedGame == false && inventoryScript.isCollectionActive == false)
        {
            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9))
            {
                if (hit.collider.gameObject.name == "GanjaHalucynacje1" && isStartGanja1 == false)
                {
                    FireGanja1();
                }

                else if (hit.collider.gameObject.name == "GanjaHalucynacje2" && isStartGanja2 == false)
                {
                    FireGanja2();
                }

                else if (hit.collider.gameObject.name == "GanjaHalucynacje3" && isStartGanja3 == false)
                {
                    FireGanja3();
                }

                else if (hit.collider.gameObject.name == "GanjaHalucynacje4" && isStartGanja4 == false)
                {
                    FireGanja4();
                }

               else if (hit.collider.gameObject.name == "GanjaHalucynacje5" && isStartGanja5 == false)
                {
                    FireGanja5();
                }

            } // klamra do raya


            } // klamra do ifa z przyciskiem

        if (isStartCount == true)
        {

            counter = counter += 1 * Time.deltaTime;

            if (isStartGanja1 == true && isEndGanja1 == false && counter >= 30)
            {
                ganja1Canvas.enabled = false;
                isEndGanja1 = true;
                isStartCount = false;
                counter = 0;
            }

            if (isStartGanja2 == true && isEndGanja2 == false && counter >= 30)
            {
                ganja2Canvas.enabled = false;
                isEndGanja2 = true;
                isStartCount = false;
                counter = 0;
            }

            if (isStartGanja2 == true && isEndGanja2 == false && counter  > 4 && counter < 5) {
                ganjaAudioSource.clip = whistleSound;
                ganjaAudioSource.Play();
            }

            if (isStartGanja3 == true && isEndGanja3 == false && counter >= 30)
            {
                ganja3Canvas.enabled = false;
                isEndGanja3 = true;
                isStartCount = false;
                counter = 0;
            }

            if (isStartGanja4 == true && isEndGanja4 == false && counter >= 30)
            {
                ganja4Canvas.enabled = false;
                isEndGanja4 = true;
                isStartCount = false;
                counter = 0;
            }

            if (isStartGanja4 == true && isEndGanja4 == false && counter > 4 && counter < 5)
            {
                ganjaAudioSource.clip = whistleSound;
                ganjaAudioSource.Play();
            }

            if (isStartGanja5 == true && isEndGanja5 == false && counter > 4 && counter < 5)
            {
                ganjaAudioSource.clip = backgroundSound;
                ganjaAudioSource.Play();
            }

            if (isStartGanja5 == true && isEndGanja5 == false && counter >= 30)
            {
                ganja5Canvas.enabled = false;
                isEndGanja5 = true;
                isStartCount = false;
                counter = 0;
                ganjaAudioSource.Stop();
            }


        }

        // pauza dzwieku haluny

        if(Time.timeScale == 0 && DzwiekPlay_ok == false)
        {
            ganjaAudioSource.Pause();

            DzwiekPlay_ok = true;
        }
        else if (Time.timeScale == 1 && DzwiekPlay_ok == true)
        {
            ganjaAudioSource.UnPause();

            DzwiekPlay_ok = false;
        }

        } // klamra do update

    public void FireGanja1() {

        isStartCount = true;
        isStartGanja1 = true;
        fireAudioSource.PlayOneShot(fireSound);
        ganja1Canvas.enabled = true;
        halluns1Animator.SetTrigger("Haluny1");
        fire1Animator.SetTrigger("OdpalanieGanji");
        fireCount++;
    }

    public void FireGanja2()
    {
        isStartCount = true;
        isStartGanja2 = true;
        fireAudioSource.PlayOneShot(fireSound);
        ganja2Canvas.enabled = true;
        halluns2Animator.SetTrigger("Haluny2");
        fire2Animator.SetTrigger("OdpalanieGanji");
        fireCount++;
    }

    public void FireGanja3()
    {
        isStartCount = true;
        isStartGanja3 = true;
        fireAudioSource.PlayOneShot(fireSound);
        ganja3Canvas.enabled = true;
        halluns3Animator.SetTrigger("Haluny3");
        fire3Animator.SetTrigger("OdpalanieGanji");
        fireCount++;
    }

    public void FireGanja4()
    {

        isStartCount = true;
        isStartGanja4 = true;
        fireAudioSource.PlayOneShot(fireSound);
        ganja4Canvas.enabled = true;
        halluns4Animator.SetTrigger("Haluny4");
        fire4Animator.SetTrigger("OdpalanieGanji");
        fireCount++;
    }

    public void FireGanja5()
    {

        isStartCount = true;
        isStartGanja5 = true;
        fireAudioSource.PlayOneShot(fireSound);
        ganja5Canvas.enabled = true;
        halluns5Animator.SetTrigger("Haluny5");
        fire5Animator.SetTrigger("OdpalanieGanji");
        fireCount++;
    }

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
