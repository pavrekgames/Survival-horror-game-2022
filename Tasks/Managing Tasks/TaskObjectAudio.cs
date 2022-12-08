using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObjectAudio : MonoBehaviour {

    private Tasks tasksScript;

    [SerializeField] private TaskData taskToAdd;
    [SerializeField] private TaskData taskToRemove;
    [SerializeField] private TaskData previosTask;
    [SerializeField] private VoiceActing voiceActingScript;

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
