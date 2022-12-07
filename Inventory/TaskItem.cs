﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItem : MonoBehaviour {

    public event Action OnPickUpItem;

    [SerializeField] private Item item;
    [SerializeField] private AudioClip itemSound;

    private Inventory inventoryScript;

    void Start()
    {
        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void PickUpItem()
    {
        inventoryScript.AddItem(item, itemSound);
        gameObject.SetActive(false);

        if(OnPickUpItem != null)
        {
            OnPickUpItem.Invoke();
        }
    }

}
