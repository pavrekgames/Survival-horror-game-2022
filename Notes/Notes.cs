using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using TMPro;

public class Notes : MonoBehaviour {

    public bool isPlaySound = false; 

    private PlayerManager playerManagerScript;
    private Blur blurScript;
    private Menu gameMenuScript;
    private CrosshairGUI cursorScript;
    private Player playerScript;

    private Ray playerAim;
    private Camera playerCam;
    [SerializeField] private float rayLength = 4f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip notesSound;
    public bool isNotes = false;
    public Canvas[] notesCanvas;

    public int notesCount = 0;

    void OnEnable()
    {
        playerCam = Camera.main;

        blurScript = GameObject.Find("PlayerCamera").GetComponent<Blur>();
        gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        playerManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
        cursorScript = GameObject.Find("PlayerCamera").GetComponent<CrosshairGUI>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isNotes == false && playerManagerScript.isPlayerCanInput == true)
        {
            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9))
            {

                if (hit.collider.gameObject.tag == "Note")
                {
                    hit.transform.gameObject.GetComponent<Note>().PickUpNote();
                }
            }
        }
        else if ((Input.GetMouseButtonDown(0)) && isNotes == true && notesCanvas.Length > 0 && gameMenuScript.isMenu == false && Time.timeScale == 0)
        {
            HideNote();
        }
    }

    public void HideNote()
    {
        Time.timeScale = 1;
        blurScript.enabled = false;
        isNotes = false;
        Cursor.visible = true;
        cursorScript.enabled = true;
        playerScript.enabled = true;

        if (notesCanvas.Length > 0)
        {
            for (int i = 0; i < notesCanvas.Length; i++)
            {
                notesCanvas[i].enabled = false;
            }
        }
    }

    public void ReadNote(Canvas noteCanvas)
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
        noteCanvas.enabled = true;
        isNotes = true;
        blurScript.enabled = true;
        Cursor.visible = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
        playerScript.enabled = false;
        notesCount++;
    }
}

