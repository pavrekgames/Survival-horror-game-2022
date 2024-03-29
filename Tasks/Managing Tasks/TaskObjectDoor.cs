﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObjectDoor : MonoBehaviour {

    private Tasks tasksScript;

    [SerializeField] private TaskData taskToRemove;
    [SerializeField] private UnlockDoor unlockDoor;

    void Start()
    {
        tasksScript = GameObject.Find("Player").GetComponent<Tasks>();

        unlockDoor.OnDoorUnlocked += RemoveTask;
    }

    public void RemoveTask()
    {
        if (taskToRemove != null)
        {
            tasksScript.RemoveTask(taskToRemove);

            unlockDoor.OnDoorUnlocked -= RemoveTask;
        }
    }
}
