using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItem : MonoBehaviour {

    public event Action OnPickUpItem;

    public Item item;
    public AudioClip itemSound;
    public Inventory inventoryScript;

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
