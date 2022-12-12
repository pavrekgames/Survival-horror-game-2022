using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Halluns : MonoBehaviour
{

    public bool isPlaySound = false;
    private PlayerManager playerManager;

    [SerializeField]
    private AudioSource fireAudioSource;
    [SerializeField]
    private AudioSource ganjaAudioSource;
    [SerializeField]
    private AudioClip fireSound;

    [SerializeField]
    private Image halluns3Image;
    [SerializeField]
    private Image halluns4Image;
    [SerializeField]
    private Image halluns5Image;

    [SerializeField]
    private Sprite halluns3Sprite;
    [SerializeField]
    private Sprite halluns4Sprite;
    [SerializeField]
    private Sprite halluns5Sprite;

    [SerializeField]
    private Animator halluns1Animator;
    [SerializeField]
    private Animator halluns2Animator;
    [SerializeField]
    private Animator halluns3Animator;
    [SerializeField]
    private Animator halluns4Animator;
    [SerializeField]
    private Animator halluns5Animator;

    private Ray playerAim;
    private Camera playerCam;
    public float rayLength = 4f;

    public static int fireCount = 0;

    void OnEnable()
    {

        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();

        fireAudioSource.clip = null;
        ganjaAudioSource.clip = null;

        halluns1Animator.SetTrigger("Haluns1Restart");
        halluns2Animator.SetTrigger("Haluns2Restart");
        halluns3Animator.SetTrigger("Haluns3Restart");
        halluns4Animator.SetTrigger("Haluns4Restart");
        halluns5Animator.SetTrigger("Haluns5Restart");

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

    void Update()
    {

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
    }

    public void DefaultScriptSettings()
    {

        fireAudioSource.clip = null;
        ganjaAudioSource.clip = null;

        halluns3Image.GetComponent<HallunsEvent3>().enabled = true;
        halluns4Image.GetComponent<HallunsEvent4>().enabled = true;
        halluns5Image.GetComponent<HallunsEvent5>().enabled = true;

        halluns3Image.sprite = halluns3Sprite;
        halluns4Image.sprite = halluns4Sprite;
        halluns5Image.sprite = halluns5Sprite;

    }
}
