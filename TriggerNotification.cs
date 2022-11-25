using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNotification : MonoBehaviour {

    public bool isTrigger;
    public string notificationText;
    public Notifications notificationScript;

    public enum NotificationType
    {
        Main,
        SecretPlace,
        Tutorial
    } 

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && isTrigger == false)
        {
            notificationScript.ShowNotification(notificationText);
            isTrigger = true;
        }
    }

}
