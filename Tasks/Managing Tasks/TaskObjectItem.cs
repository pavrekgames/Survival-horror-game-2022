using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObjectItem : MonoBehaviour {

    private Tasks tasksScript;

    [SerializeField] private TaskData taskToAdd;
    [SerializeField] private TaskData taskToRemove;
    [SerializeField] private TaskItem taskItem;

	void Start () {

        tasksScript = GameObject.Find("Player").GetComponent<Tasks>();

        taskItem.OnPickUpItem += AddTask;
        taskItem.OnPickUpItem += RemoveTask;

    }

    public void AddTask()
    {
        tasksScript.AddTask(taskToAdd);

        taskItem.OnPickUpItem -= AddTask;
    }

    public void RemoveTask()
    {
        if(taskToRemove != null)
        {
            tasksScript.RemoveTask(taskToRemove);

            taskItem.OnPickUpItem -= RemoveTask;
        }
    }

}
