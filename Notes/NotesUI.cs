using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotesUI : MonoBehaviour {

    public static bool isNotesActive = false;

    private Player playerScript;
    private CrosshairGUI cursorScript;

    [Header("UI")]
    [SerializeField] private Canvas[] notesCanvas2;
    [SerializeField] private Canvas defaultNoteCanvas;
    [SerializeField] private TextMeshProUGUI noteTitleTextMesh;
    [SerializeField] private Canvas notesCanvas;
    [SerializeField] private Canvas noteDefaultCanvas;
    [SerializeField] private ScrollRect notesScrollRect;
    [SerializeField] private Scrollbar notesScrollbar;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource hoverAudioSource;
    [SerializeField] private AudioSource itemAudioSource;
    [SerializeField] private AudioSource pauseAudioSource;
    [SerializeField] private AudioClip notesSound;
    [SerializeField] private AudioClip hoverNoteSound;
    [SerializeField] private AudioClip menuButtonSound;
    [SerializeField] private AudioClip openInventorySound;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        cursorScript = GameObject.Find("PlayerCamera").GetComponent<CrosshairGUI>();
    }

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isNotesActive == true)
        {
            NotesBackFunction();
        }
    }

    public void ShowNotes()
    {
        StartCoroutine(ShowNotesIE());
    }

    public IEnumerator ShowNotesIE()
    {
        InventoryUIManager.ResetUI();
        itemAudioSource.PlayOneShot(menuButtonSound);
       
        notesCanvas.enabled = true;
        isNotesActive = true;

        yield return new WaitForSecondsRealtime(0.01f);

        notesScrollRect.GetComponent<ScrollRect>().enabled = true;
        notesScrollbar.value = 1;
        StopCoroutine(ShowNotesIE());

    }

    public void NotesBackFunction()
    {

        InventoryUIManager.ResetUI();

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;

    }

    public void ShowNote(int id)
    {
        defaultNoteCanvas.enabled = false;

        for (int i = 0; i < notesCanvas2.Length; i++)
        {
            if (i == id)
            {
                notesCanvas2[i].enabled = true;
                audioSource.pitch = Random.Range(0.8f, 1.5f);
                audioSource.PlayOneShot(notesSound);
            }
            else
            {
                notesCanvas2[i].enabled = false;
            }
        }
    }

    public void ShowNoteTitle(string noteTitle)
    {
        noteTitleTextMesh.text = noteTitle;
        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }
}
