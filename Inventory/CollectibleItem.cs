using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip itemSound;
    public Inventory inventoryScript;

    public NotificationType itemType;

    public void PickUpItem()
    {
        switch (itemType)
        {
            case NotificationType.SecretItem:
                inventoryScript.AddCollectibleItem(audioSource, itemSound, inventoryScript.secretItemsCount, itemType);
                break;
            case NotificationType.GreenHerb:
                inventoryScript.AddCollectibleItem(audioSource, itemSound, inventoryScript.greenHerbsCount, itemType);
                break;
            case NotificationType.BlueHerb:
                inventoryScript.AddCollectibleItem(audioSource, itemSound, inventoryScript.blueHerbsCount, itemType);
                break;
            case NotificationType.HealthPot:
                inventoryScript.AddCollectibleItem(audioSource, itemSound, inventoryScript.healthPotsCount, itemType);
                break;
            case NotificationType.StaminaPot:
                inventoryScript.AddCollectibleItem(audioSource, itemSound, inventoryScript.staminaPotsCount, itemType);
                break;
            case NotificationType.Badge:
                inventoryScript.AddCollectibleItem(audioSource, itemSound, inventoryScript.badgesCount, itemType);
                break;
            case NotificationType.Photo:
                inventoryScript.AddCollectibleItem(audioSource, itemSound, inventoryScript.photosCount, itemType);
                break;
            case NotificationType.Tip:
                inventoryScript.AddCollectibleItem(audioSource, itemSound, inventoryScript.tipsCount, itemType);
                break;
        }

        gameObject.SetActive(false);
    }
}
