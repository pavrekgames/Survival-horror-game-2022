using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBones : MonoBehaviour, IRaycastTask {

    public bool isPlaySound = false; 

    private PlayerManager playerManagerScript;
    private Inventory inventoryScript;

    [Header("Objects")]
    [SerializeField] private GameObject bone1;
    [SerializeField] private GameObject bone2;
    [SerializeField] private GameObject bone3;
    [SerializeField] private GameObject bone4;
    [SerializeField] private GameObject bone5;
    [SerializeField] private Transform grille;
    [SerializeField] private Light lampLight;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource grilleAudioSource;
    [SerializeField] private AudioClip boneSound;
    [SerializeField] private AudioClip grilleSound;

    [Header("Objects states")]
    public int bonesCount = 0;
    public bool isBone1 = false;
	public bool isBone2 = false;
	public bool isBone3 = false;
	public bool isBone4 = false;
	public bool isBone5 = false;

	public bool isGrille = false;
    public string itemType;

	void OnEnable () {

        playerManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
        inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();
        grilleAudioSource.clip = null;

	}

	void Update () {

        CheckBones();
        TaskDone();
        
        if (Time.timeScale == 0 && isPlaySound == false)
        {
            grilleAudioSource.Pause();
            isPlaySound = true;

        }

        else if(Time.timeScale == 1 && isPlaySound == true)
        {
            grilleAudioSource.UnPause();
            isPlaySound = false;
        }

    }

    public void Execute()
    {
        for (int i = 0; i < inventoryScript.items.Count; i++)
        {
            if (inventoryScript.items[i].type == itemType && inventoryScript.items[i].isUsed == true)
            {
                audioSource.PlayOneShot(boneSound);
                bonesCount++;
                inventoryScript.RemoveItem(inventoryScript.items[i], true);
                break;
            }
        }
    }

    void CheckBones()
    {
        switch (bonesCount)
        {
            case 1:
                isBone1 = true;
                bone1.SetActive(true);
                break;
            case 2:
                isBone2 = true;
                bone2.SetActive(true);
                break;
            case 3:
                isBone3 = true;
                bone3.SetActive(true);
                break;
            case 4:
                isBone4 = true;
                bone4.SetActive(true);
                break;
            case 5:
                isBone5 = true;
                bone5.SetActive(true);
                break;
        }
    }

    void TaskDone()
    {
        if (bonesCount == 5 && isGrille == false)
        {
            lampLight.color = Color.red;
            grille.transform.position = new Vector3(grille.transform.position.x, grille.transform.position.y - 5, grille.transform.position.z);
            isGrille = true;
            grilleAudioSource.clip = grilleSound;
            grilleAudioSource.Play();
        }

    }

}
