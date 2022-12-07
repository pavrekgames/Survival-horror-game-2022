using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitlesLines4 : MonoBehaviour, ISubtitles {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip recording;
    [SerializeField] private SubData4 subtitlesData;

    private Menu gameMenuScript;
    private TextMeshProUGUI subtitlesTextMesh;

    void Start()
    {
        gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        subtitlesTextMesh = GameObject.Find("SubtitlesTextMesh").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

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
        if (audioSource.time > subtitlesData.startSub1 && audioSource.time < subtitlesData.endSub1)
        {
            subtitlesTextMesh.text = subtitlesData.subtitles1;
        }
        else if (audioSource.time >= subtitlesData.startSub2 && audioSource.time < subtitlesData.endSub2)
        {
            subtitlesTextMesh.text = subtitlesData.subtitles2;
        }
        else if (audioSource.time >= subtitlesData.startSub3 && audioSource.time < subtitlesData.endSub3)
        {
            subtitlesTextMesh.text = subtitlesData.subtitles3;
        }

        else if (audioSource.time >= subtitlesData.startSub4)
        {
            subtitlesTextMesh.text = subtitlesData.subtitles4;
        }

        if (audioSource.isPlaying == false)
        {
            audioSource.clip = null;
            subtitlesTextMesh.text = "";
        }
    }

}
