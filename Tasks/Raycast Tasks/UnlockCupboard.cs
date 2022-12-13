using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCupboard : MonoBehaviour, IRaycastTask {

    private Inventory inventoryScript;
    private OpenCloseObject openCloseObjectsScript;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip keyOpenSound;
    [SerializeField] private GameObject doorCollider;
    [SerializeField] private GameObject additionalObject;
    [SerializeField] private Door doorScript;
    [SerializeField] private Door doorScript2;

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
                doorScript2.isNeedKey = false;
                openCloseObjectsScript.enabled = true;

                inventoryScript.RemoveItem(inventoryScript.items[i], true);
                break;
            }
        }
    }
}
