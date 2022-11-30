using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObjectNote : MonoBehaviour {

    private Tasks tasksScript;

    public TaskData taskToAdd;
    public TaskData taskToRemove;

    public Note note;

    void Start()
    {
        tasksScript = GameObject.Find("Player").GetComponent<Tasks>();

        note.OnPickUpNote += AddTask;
        note.OnPickUpNote += RemoveTask;
    }

    public void AddTask()
    {
        tasksScript.AddTask(taskToAdd);

        note.OnPickUpNote -= AddTask;
    }

    public void RemoveTask()
    {
        if (taskToRemove != null)
        {
            tasksScript.RemoveTask(taskToRemove);

            note.OnPickUpNote -= RemoveTask;
        }
    }

}
