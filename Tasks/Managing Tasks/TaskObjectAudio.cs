using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObjectAudio : MonoBehaviour {

    private Tasks tasksScript;

    public TaskData taskToAdd;
    public TaskData taskToRemove;
    public TaskData previosTask;

    public VoiceActing voiceActingScript;

    void Start()
    {
        tasksScript = GameObject.Find("Player").GetComponent<Tasks>();

        voiceActingScript.OnStopTalking += AddTask;
        voiceActingScript.OnStopTalking += RemoveTask;
    }

    public void AddTask()
    {
        tasksScript.AddTask(taskToAdd);

        voiceActingScript.OnStopTalking -= AddTask;
    }

    public void RemoveTask()
    {
        if (taskToRemove != null)
        {
            tasksScript.RemoveTask(taskToRemove);

            voiceActingScript.OnStopTalking -= RemoveTask;
        }
    }

}
