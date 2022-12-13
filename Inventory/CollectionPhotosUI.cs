using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPhotosUI : MonoBehaviour {

    private InventoryUIManager inventoryUIManager;
    private Player playerScript;
    private CrosshairGUI cursorScript;

    [SerializeField] private Canvas photoCollectionCanvas;
    [SerializeField] private AudioSource itemAudioSource;
    [SerializeField] private AudioSource pauseAudioSource;
    [SerializeField] private AudioClip menuButtonSound;
    [SerializeField] private AudioClip openInventorySound;
    
    public string[] collectionTitles;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        cursorScript = GameObject.Find("PlayerCamera").GetComponent<CrosshairGUI>();
    }

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && CollectionBadgesUI.isCollectionActive == true)
        {
            CollectionBackFunction();
        }
    }

    public void ShowPhotoCollection()
    {
        inventoryUIManager.ResetUI();
        itemAudioSource.PlayOneShot(menuButtonSound);
        photoCollectionCanvas.enabled = true;
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
