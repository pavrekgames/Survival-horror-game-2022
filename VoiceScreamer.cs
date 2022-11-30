﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceScreamer : MonoBehaviour {

    private VoiceActing voiceActingScript;
    private ScreamerSoundWithEvent screamer;

    private AudioSource audioSource;
    private AudioClip recording;

    void Start () {
        voiceActingScript = GameObject.Find("Player").GetComponent<VoiceActing>();

        screamer.OnCallScreamer += PlayVoice;
    }
	
	public void PlayVoice()
    {
        voiceActingScript.PlayVoice(audioSource, recording);

        screamer.OnCallScreamer -= PlayVoice;
    }

}
