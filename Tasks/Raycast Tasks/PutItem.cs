using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutItem : MonoBehaviour, IRaycastTask {

    private Inventory inventoryScript;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip putItemSound;
    [SerializeField] private GameObject additionalObject;

    public bool isPut;
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
                audioSource.clip = putItemSound;
                audioSource.Play();
                isPut = true;

                if (additionalObject != null)
                {
                    additionalObject.SetActive(true);
                }

                inventoryScript.RemoveItem(inventoryScript.items[i], true);
                break;
            }
        }
    }

}
