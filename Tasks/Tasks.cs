using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using TMPro;

public class Tasks : MonoBehaviour {

    public bool DzwiekPlay_ok = false; 

    private Inventory inventoryScript;
    private Animator uiAnimator;
    private NotificationUI notificationUIScript;
    private PlayerManager playerManagerScript;

    public List<TaskData> tasksList = new List<TaskData>();

    private Ray playerAim;
    private Camera playerCam;
    [SerializeField] private float rayLength = 4f;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip newTaskSound;

    [HideInInspector] public bool isGoToAliceTask;
    [HideInInspector] public bool isStevenSearchTask;
    [HideInInspector] public bool isStevenShedTask;
    [HideInInspector] public bool isVictorBrookTask;

    public event Action OnAddedTask;
    public event Action OnRemovedTask;

    void OnEnable(){

		playerCam = Camera.main;

    }

	void Update () {

		if (Input.GetMouseButtonDown (0) && inventoryScript.items.Count >= 0 && playerManagerScript.isPlayerCanInput == true) {

			Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {

                if (hit.collider.gameObject.tag == "Door" || hit.collider.gameObject.tag == "Hand") {

                    IRaycastTask raycastTask = hit.transform.GetComponent<IRaycastTask>() as IRaycastTask;
                    if(raycastTask != null)
                    {
                        raycastTask.Execute();
                    }
				}
			} 
		} 

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && DzwiekPlay_ok == false)
        {

            audioSource.Pause();
           
         
         
            

            DzwiekPlay_ok = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && DzwiekPlay_ok == true)
        {

            audioSource.UnPause();
           
  
            

            DzwiekPlay_ok = false;
        }
    } 

    public void AddTask(TaskData task)
    {
        task.isAdded = true;
        tasksList.Add(task);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        uiAnimator.SetTrigger("NewTask");
        notificationUIScript.TaskHintNotification();

        if(OnAddedTask != null)
        {
            OnAddedTask.Invoke();
        }

    }

    public void RemoveTask(TaskData task)
    {
        task.isRemoved = true;
        tasksList.Remove(task);

        if (OnRemovedTask != null)
        {
            OnRemovedTask.Invoke();
        }

    }

}
