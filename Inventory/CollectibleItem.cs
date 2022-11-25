using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour {

    public AudioClip itemSound;
    public Inventory inventoryScript;
    public Image itemTexture;

    public enum ItemType
    {
        SecretItem,
        GreenHerb,
        BlueHerb,
        HealthPot,
        StaminaPot,
        Badge,
        Photo,
        Tip
    }

    public ItemType itemType;

    public void PickUpItem()
    {
        switch (itemType)
        {
            case ItemType.SecretItem:
                inventoryScript.AddSecretItem(itemSound);
                break;
            case ItemType.GreenHerb:
                inventoryScript.AddGreenHerb(itemSound);
                break;
            case ItemType.BlueHerb:
                inventoryScript.AddBlueHerb(itemSound);
                break;
            case ItemType.HealthPot:
                inventoryScript.AddHealthPot(itemSound);
                break;
            case ItemType.StaminaPot:
                inventoryScript.AddStaminaPot(itemSound);
                break;
            case ItemType.Badge:
                inventoryScript.AddBadge(itemSound, itemTexture);
                break;
            case ItemType.Photo:
                inventoryScript.AddPhoto(itemSound, itemTexture);
                break;
            case ItemType.Tip:
                inventoryScript.AddTip(itemSound, itemTexture);
                break;
        }

        gameObject.SetActive(false);
    }
}
