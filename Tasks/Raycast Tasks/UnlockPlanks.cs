using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPlanks : MonoBehaviour, IRaycastTask {

    private Inventory inventoryScript;
    private Player playerScript;
    private Notes notesScript;

    [SerializeField] private Canvas blackScreenCanvas;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip putItemSound;
    [SerializeField] private GameObject planksCollider;

    public bool isLocked;
    public string itemType;


    void Start () {
        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        notesScript = GameObject.Find("Player").GetComponent<Notes>();
    }

    public void Execute()
    {
        for (int i = 0; i < inventoryScript.items.Count; i++)
        {
            if (inventoryScript.items[i].type == itemType && inventoryScript.items[i].isUsed == true)
            {
                blackScreenCanvas.enabled = true;
                playerScript.enabled = false;
                audioSource.clip = putItemSound;
                audioSource.Play();
                planksCollider.gameObject.SetActive(false);
                isLocked = false;
                notesScript.isNotes = true;

                inventoryScript.RemoveItem(inventoryScript.items[i], true);
                break;
            }
        }
    }

    void Update()
    {
        if (audioSource.isPlaying == false && isLocked == false && Time.timeScale == 1)
        {
            blackScreenCanvas.enabled = false;
            playerScript.enabled = true;
            audioSource.clip = null;
            notesScript.isNotes = false;
        }
    }

}
