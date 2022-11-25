using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerNotification : MonoBehaviour {

    public bool isTrigger;
    public string notificationText;
    public Canvas notifactionCanvas;
    public Text pointer;
    public Notifications notificationScript;

    public enum NotificationType
    {
        Main,
        SecretPlace,
        Tutorial
    }

    public NotificationType notificationType;

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && isTrigger == false)
        {
            switch (notificationType)
            {
                case NotificationType.Main:
                    notificationScript.ShowMainNotification(notificationText);
                    break;
                case NotificationType.SecretPlace:
                    notificationScript.ShowSecretPlaceNotification(notificationText, pointer);
                    break;
                case NotificationType.Tutorial:
                    notificationScript.ShowTutorialNotification(notifactionCanvas);
                    break;
            }
            isTrigger = true;
        }
    }
}
