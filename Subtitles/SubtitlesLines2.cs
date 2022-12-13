using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitlesLines2 : MonoBehaviour, ISubtitles {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip recording;
    [SerializeField] private SubData2 subtitlesData;

    private Menu gameMenuScript;
    private TextMeshProUGUI subtitlesTextMesh;

    public bool isSubtitles;

    void Start()
    {
        gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        subtitlesTextMesh = GameObject.Find("SubtitlesTextMesh").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

        CheckAudio();

        if (gameMenuScript.subtitlesToggle.isOn == true && isSubtitles == false)
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
        if (audioSource.time > subtitlesData.startSub1 && audioSource.time < subtitlesData.endSub1)
        {
            subtitlesTextMesh.text = subtitlesData.subtitles1;
        }
        else if (audioSource.time >= subtitlesData.startSub2)
        {
            subtitlesTextMesh.text = subtitlesData.subtitles2;
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
