using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutPumpkin : MonoBehaviour, IRaycastTask {

    private Inventory inventoryScript;

    [SerializeField] private AudioSource pumpkinAudioSource;
    [SerializeField] private AudioSource keyAudioSource;
    [SerializeField] private AudioClip pumpkinSound;
    [SerializeField] private AudioClip keySound;
    [SerializeField] private GameObject pumpkin;
    [SerializeField] private GameObject key;
    
    public bool isDone;
    public string itemType;

    void Start () {
        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void Execute()
    {
        for (int i = 0; i < inventoryScript.items.Count; i++)
        {
            if (inventoryScript.items[i].type == itemType && inventoryScript.items[i].isUsed == true)
            {
                pumpkinAudioSource.clip = pumpkinSound;
                pumpkinAudioSource.Play();
                keyAudioSource.clip = keySound;
                keyAudioSource.Play();
                pumpkin.SetActive(true);
                key.SetActive(true);
                isDone = true;

                inventoryScript.RemoveItem(inventoryScript.items[i], true);
                break;
            }
        }
    }

}
