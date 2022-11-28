using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockGrille : MonoBehaviour, IRaycastTask {

    private Inventory inventoryScript;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip acidSound;
    [SerializeField] private GameObject grille;

    public bool isLocked;
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
                audioSource.clip = acidSound;
                audioSource.Play();
                grille.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                grille.gameObject.AddComponent<Rigidbody>();
                isLocked = false;
                
                inventoryScript.RemoveItem(inventoryScript.items[i], true);
                break;
            }
        }
    }
}
