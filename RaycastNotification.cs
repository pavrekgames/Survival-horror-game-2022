using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastNotification : MonoBehaviour {

    public string notificationText;
    public string doorName;
    public AudioClip notificationSound;
    public Notifications notificationScript;
    public bool notificationOff;

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
                notificationScript.ShowDoorNameNotification(notificationText, doorName, notificationSound);
            }
            else
            {
                if (notificationSound != null)
                {
                    notificationScript.ShowInfoNotification(notificationText, notificationSound);
                }
                else
                {
                    notificationScript.ShowInfoNotification(notificationText);
                }
            }
        }
    }
}
