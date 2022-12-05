using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionBadgesUI : MonoBehaviour {

    public static bool isCollectionActive = false;

    private Player playerScript;
    private CrosshairGUI cursorScript;

    [SerializeField] private Canvas badgeCollectionCanvas;
    [SerializeField] private AudioSource itemAudioSource;
    [SerializeField] private AudioSource pauseAudioSource;
    [SerializeField] private AudioClip menuButtonSound;
    [SerializeField] private AudioClip openInventorySound;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        cursorScript = GameObject.Find("PlayerCamera").GetComponent<CrosshairGUI>();
    }

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isCollectionActive == true)
        {
            CollectionBackFunction();
        }
    }

    public void ShowBadgeCollection()
    {
        InventoryUIManager.ResetUI();
        itemAudioSource.PlayOneShot(menuButtonSound);
        badgeCollectionCanvas.enabled = true;
        isCollectionActive = true;
    }

    public void CollectionBackFunction()
    {
        InventoryUIManager.ResetUI();

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;

    }


}
