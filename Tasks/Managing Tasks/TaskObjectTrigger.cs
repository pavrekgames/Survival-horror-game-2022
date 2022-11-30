using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObjectTrigger : MonoBehaviour {

    private Tasks tasksScript;

    public TaskData previousTask;
    public TaskData taskToAdd;
    public TaskData taskToRemove;
    public bool isAdded;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && previousTask.isAdded == true && isAdded == false)
        {
            tasksScript.AddTask(taskToAdd);
            isAdded = true;

            if(taskToRemove != null)
            {
                tasksScript.RemoveTask(taskToRemove);
            }

        }
    }

}
