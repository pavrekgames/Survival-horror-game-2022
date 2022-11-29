using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObjectItem : MonoBehaviour {

    private Tasks tasksScript;

    public TaskData task;
    public TaskItem taskItem;

	void Start () {

        tasksScript = GameObject.Find("Player").GetComponent<Tasks>();

        taskItem.OnPickUpItem += SendTask;

	}

    public void SendTask()
    {
        tasksScript.AddTask(task);

        taskItem.OnPickUpItem -= SendTask;
    }
}
