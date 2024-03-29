﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTipsUI : MonoBehaviour {

    private InventoryUIManager inventoryUIManager;
    private Player playerScript;
    private CrosshairGUI cursorScript;

    [SerializeField] private Canvas tipCollectionCanvas;
    [SerializeField] private AudioSource itemAudioSource;
    [SerializeField] private AudioSource pauseAudioSource;
    [SerializeField] private AudioClip menuButtonSound;
    [SerializeField] private AudioClip openInventorySound;

    public string[] collectionTitles;

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && CollectionBadgesUI.isCollectionActive == true)
        {
            CollectionBackFunction();
        }
    }

    public void ShowTipCollection()
    {
        inventoryUIManager.ResetUI();
        itemAudioSource.PlayOneShot(menuButtonSound);
        tipCollectionCanvas.enabled = true;
        CollectionBadgesUI.isCollectionActive = true;
    }

    public void CollectionBackFunction()
    {
        inventoryUIManager.ResetUI();

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;
    }
}
