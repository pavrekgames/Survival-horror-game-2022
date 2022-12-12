using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitlesLine1 : MonoBehaviour, ISubtitles {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip recording;
    [SerializeField] private SubData1 subtitlesData;

    public bool isSubtitles;

    private Menu gameMenuScript;
    private TextMeshProUGUI subtitlesTextMesh;

    void Start()
    {
        gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        subtitlesTextMesh = GameObject.Find("SubtitlesTextMesh").GetComponent<TextMeshProUGUI>();
    }

    void Update () {

        CheckAudio();

        if(gameMenuScript.subtitlesToggle.isOn == true && isSubtitles == false)
        {
            if (audioSource.isPlaying == true && audioSource.clip == recording)
            {
                ShowSubtitles();
            }
        }
        else if (isSubtitles == true)
        {
            subtitlesTextMesh.text = "";
            isSubtitles = false;
        }
    }

    public void ShowSubtitles()
    {
        if (audioSource.time > subtitlesData.startTime && audioSource.isPlaying == true)
        {
            subtitlesTextMesh.text = subtitlesData.subtitles;
        }
    }

    void CheckAudio()
    {
        if (audioSource.isPlaying == false && audioSource.clip == recording && isSubtitles == false)
        {
            audioSource.clip = null;
            isSubtitles = true;
        }
    }

}
