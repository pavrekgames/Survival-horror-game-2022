using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour, IRaycastTask {

    private Inventory inventoryScript;
    private OpenCloseObject openCloseObjectsScript;
    public AudioSource audioSource;
    public AudioClip keyOpenSound;
    public GameObject doorCollider;
    public GameObject additionalObject;
    public Door doorScript;
    public bool isLocked;
    public string itemType;

    void Start()
    {
        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
        openCloseObjectsScript = GameObject.Find("Player").GetComponent<OpenCloseObject>();
    }

    public void Execute()
    {
        for (int i = 0; i < inventoryScript.items.Count; i++)
        {
            if (inventoryScript.items[i].type == itemType && inventoryScript.items[i].isUsed == true)
            {
                openCloseObjectsScript.enabled = false;
                audioSource.clip = keyOpenSound;
                audioSource.Play();
                doorCollider.gameObject.SetActive(false);
                isLocked = false;
                doorScript.isNeedKey = false;
                openCloseObjectsScript.enabled = true;

                if(additionalObject != null)
                {
                    additionalObject.SetActive(false);
                }

                inventoryScript.RemoveItem(inventoryScript.items[i], true);
                break;
            }
        }
    }

}
