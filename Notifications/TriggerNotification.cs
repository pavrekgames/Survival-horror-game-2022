using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerNotification : MonoBehaviour {

    [SerializeField] private bool isTrigger;
    [SerializeField] private string notificationText;
    [SerializeField] private Canvas notifactionCanvas;
    [SerializeField] private Text pointer;
    [SerializeField] private NotificationUI notificationUIScript;

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
