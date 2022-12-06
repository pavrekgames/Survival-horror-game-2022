using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerNotification : MonoBehaviour {

    public bool isTrigger;
    public string notificationText;
    public Canvas notifactionCanvas;
    public Text pointer;
    public NotificationUI notificationUIScript;

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
                    notificationUIScript.ShowMainNotification(notificationText);
                    break;
                case NotificationType.SecretPlace:
                    notificationUIScript.ShowSecretPlaceNotification(notificationText, pointer);
                    break;
                case NotificationType.Tutorial:
                    notificationUIScript.ShowTutorialNotification(notifactionCanvas);
                    break;
            }
            isTrigger = true;
        }
    }
}
