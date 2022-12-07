using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastNotification : MonoBehaviour {

    [SerializeField] private string notificationText;
    [SerializeField] private string doorName;
    [SerializeField] private AudioClip notificationSound;
    [SerializeField] private NotificationUI notificationUIScript;
    [SerializeField] private bool notificationOff;

    public enum CursorTag
    {
        Door,
        Hand
    }

    public CursorTag cursorTag;

    public void SendNotification()
    {
        if (notificationOff == false) {

            if (cursorTag == CursorTag.Door)
            {
                notificationUIScript.ShowDoorNameNotification(notificationText, doorName, notificationSound);
            }
            else
            {
                if (notificationSound != null)
                {
                    notificationUIScript.ShowInfoNotification(notificationText, notificationSound);
                }
                else
                {
                    notificationUIScript.ShowInfoNotification(notificationText);
                }
            }
        }
    }
}
