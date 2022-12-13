using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockThorns : MonoBehaviour, IRaycastTask {

    private Inventory inventoryScript;

    [SerializeField] private AudioSource flameAudioSource;
    [SerializeField] private AudioSource fireAudioSource;
    [SerializeField] private AudioClip flameSound;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private GameObject[] flames;
    [SerializeField] private GameObject[] thorns;

    public bool isAcidUsed;
    public bool isLocked;
    public string itemType;

    void Start()
    {
        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void Execute()
    {
        for (int i = 0; i < inventoryScript.items.Count; i++)
        {
            if (inventoryScript.items[i].type == itemType && inventoryScript.items[i].isUsed == true)
            {
                flameAudioSource.clip = flameSound;
                flameAudioSource.Play();
                fireAudioSource.clip = fireSound;
                fireAudioSource.Play();
                flames[0].SetActive(true);
                flames[1].SetActive(true);
                flames[2].SetActive(true);
                isAcidUsed = true;

                inventoryScript.RemoveItem(inventoryScript.items[i], true);
                break;
            }
        }
    }

    void Update()
    {
        if (flameAudioSource.isPlaying == false && isAcidUsed == true)
        {
            thorns[0].SetActive(false);
            thorns[1].SetActive(false);
            thorns[2].SetActive(false);
            flames[0].SetActive(false);
            isLocked = false;
        }
    }
}
