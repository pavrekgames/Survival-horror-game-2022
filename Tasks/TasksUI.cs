using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TasksUI : MonoBehaviour {

    public static bool isTasksActive = false;

    private Tasks tasksScript;
    private Player playerScript;
    private CrosshairGUI cursorScript;

    [SerializeField] private Canvas tasksCanvas;
    [SerializeField] private TextMeshProUGUI[] tasksTextMesh;
    [SerializeField] private AudioClip menuButtonSound;
    [SerializeField] private AudioSource itemAudioSource3;
    [SerializeField] private AudioSource pauseAudioSource;
    [SerializeField] private AudioClip openInventorySound;

    void Start()
    {
        tasksScript = GameObject.Find("Player").GetComponent<Tasks>();
        playerScript = GameObject.Find("Player").GetComponent < Player>();
        cursorScript = GameObject.Find("PlayerCamera").GetComponent<CrosshairGUI>();

        tasksScript.OnAddedTask += UpdateTasksUI;
        tasksScript.OnRemovedTask += UpdateTasksUI;
    }

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isTasksActive == true)
        {
            TasksBackFunction();
        }
    }

    public void UpdateTasksUI()
    {
        for (int i = 0; i < tasksScript.tasksList.Count; i++)
        {
             tasksTextMesh[i].text = tasksScript.tasksList[i].content;   
        }
    }

    public void ShowTasks()
    {
        InventoryUIManager.ResetUI();
        itemAudioSource3.PlayOneShot(menuButtonSound);
        tasksCanvas.enabled = true;
        isTasksActive = true;
    }

    public void TasksBackFunction()
    {

        InventoryUIManager.ResetUI();

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;
    }
}
