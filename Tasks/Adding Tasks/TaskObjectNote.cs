using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObjectNote : MonoBehaviour {

    private Tasks tasksScript;

    public TaskData task;
    public Note note;

    void Start()
    {
        tasksScript = GameObject.Find("Player").GetComponent<Tasks>();

        note.OnPickUpNote += SendTask;
    }

    public void SendTask()
    {
        tasksScript.AddTask(task);

        note.OnPickUpNote -= SendTask;
    }

}
