using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitlesLine1 : MonoBehaviour, ISubtitles {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip recording;
    [SerializeField] private SubData1 subtitlesData;

    private Menu gameMenuScript;
    private TextMeshProUGUI subtitlesTextMesh;

    void Start()
    {
        gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        subtitlesTextMesh = GameObject.Find("SubtitlesTextMesh").GetComponent<TextMeshProUGUI>();
    }

    void Update () {

        if(gameMenuScript.subtitlesToggle.isOn == true)
        {
            if (audioSource.isPlaying == true && audioSource.clip == recording)
            {
                ShowSubtitles();
            }
        }
    }

    public void ShowSubtitles()
    {
        if (audioSource.time > subtitlesData.startTime)
        {
            subtitlesTextMesh.text = subtitlesData.subtitles;
        }

        if(audioSource.isPlaying == false)
        {
            audioSource.clip = null;
            subtitlesTextMesh.text = "";
        }
    }

}
