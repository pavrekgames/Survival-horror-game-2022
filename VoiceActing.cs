using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using TMPro;

public class VoiceActing : MonoBehaviour {

    public event Action OnStopTalking;

	public AudioSource playerAudioSource1;
	public AudioSource playerAudioSource2;
	public AudioSource playerAudioSource3;
	public AudioSource playerAudioSource4;
	public AudioSource retrospectionAudioSource;

    private Tasks tasksScript;
	private Map mapScript;
    private Player playerScript;   

    public ScreenOverlay retroEffectScript;  
   
    public enum RetroEffectState
    {
        None,
        StartEffect1,
        StartEffect2,
        EndEffect1,
        EndEffect2
    }

    public RetroEffectState retroEffectState;

    void OnEnable () {

		tasksScript = GameObject.Find("Player").GetComponent<Tasks>();
		retroEffectScript = GameObject.Find("PlayerCamera").GetComponent<ScreenOverlay>();
		mapScript = GameObject.Find ("Player").GetComponent<Map> ();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        playerAudioSource1 = GameObject.Find("PlayerVoice1").GetComponent<AudioSource>(); 
		playerAudioSource2 = GameObject.Find("PlayerVoice2").GetComponent<AudioSource>(); 
		playerAudioSource3 = GameObject.Find("PlayerVoice3").GetComponent<AudioSource>(); 
		playerAudioSource4 = GameObject.Find("PlayerVoice4").GetComponent<AudioSource>(); 
		retrospectionAudioSource = GameObject.Find("PlayerVoiceRetro").GetComponent<AudioSource>();
        
	}
	
	void Update () {

        Retrospection();

        if (Time.timeScale == 0) {
			if (playerAudioSource1.clip != null) {
				playerAudioSource1.Pause ();
			} else if (playerAudioSource2.clip != null) {
				playerAudioSource2.Pause ();
			} else if (playerAudioSource3.clip != null) {
				playerAudioSource3.Pause ();
			} else if (playerAudioSource4.clip != null) {
				playerAudioSource4.Pause ();
			} else if (retrospectionAudioSource.clip != null) {
				retrospectionAudioSource.Pause ();
			} else if (tasksScript.cassete1_AudioSource.clip != null) {
				tasksScript.cassete1_AudioSource.Pause ();
			} else if (tasksScript.cassete3_AudioSource.clip != null) {
				tasksScript.cassete3_AudioSource.Pause ();
			} else if (tasksScript.cassete4_AudioSource.clip != null) {
				tasksScript.cassete4_AudioSource.Pause ();
			} else if (tasksScript.cassete5_AudioSource.clip != null) {
				tasksScript.cassete5_AudioSource.Pause ();
			}
		}

		if (Time.timeScale == 1) {
			if (playerAudioSource1.clip != null) {
				playerAudioSource1.UnPause ();
			} else if (playerAudioSource2.clip != null) {
				playerAudioSource2.UnPause ();
			} else if (playerAudioSource3.clip != null) {
				playerAudioSource3.UnPause ();
			} else if (playerAudioSource4.clip != null) {
				playerAudioSource4.UnPause ();
			} else if (retrospectionAudioSource.clip != null) {
				retrospectionAudioSource.UnPause ();
			} else if (tasksScript.cassete1_AudioSource.clip != null) {
				tasksScript.cassete1_AudioSource.UnPause ();
			} else if (tasksScript.cassete3_AudioSource.clip != null) {
				tasksScript.cassete3_AudioSource.UnPause ();
			} else if (tasksScript.cassete4_AudioSource.clip != null) {
				tasksScript.cassete4_AudioSource.UnPause ();
			} else if (tasksScript.cassete5_AudioSource.clip != null) {
				tasksScript.cassete5_AudioSource.UnPause ();
			}
		}

		if (playerAudioSource1.isPlaying == false && playerAudioSource1.clip != null && Time.timeScale == 1) {
			playerAudioSource1.clip = null;
            StopTalking();
		} else if (playerAudioSource2.isPlaying == false && playerAudioSource2.clip != null && Time.timeScale == 1) {
			playerAudioSource2.clip = null;
            StopTalking();
        } else if (playerAudioSource3.isPlaying == false && playerAudioSource3.clip != null && Time.timeScale == 1) {
			playerAudioSource3.clip = null;
            StopTalking();
        } else if (playerAudioSource4.isPlaying == false && playerAudioSource4.clip != null && Time.timeScale == 1) {
			playerAudioSource4.clip = null;
            StopTalking();
        } else if (retrospectionAudioSource.isPlaying == false && retrospectionAudioSource.clip != null && Time.timeScale == 1) {
			retrospectionAudioSource.clip = null;
		} 

    }

    public void StopTalking()
    {
        if(OnStopTalking != null)
        {
            OnStopTalking.Invoke();
        }
    }

    public void PlayVoice(AudioSource audioSource, AudioClip voiceRecording)
    {
        audioSource.clip = voiceRecording;
        audioSource.Play();
        playerScript.audioSource.Stop();
    }

    public void PlayRetrospection(AudioClip retroRecording)
    {
        retrospectionAudioSource.clip = retroRecording;
        retrospectionAudioSource.Play();
        retroEffectState = RetroEffectState.StartEffect1;
        playerScript.audioSource.Stop();
    }

    void Retrospection()
    {
        RetroStartEffect();
        RetroEndEffect();
    }

    void RetroStartEffect()
    {
        if (retroEffectState == RetroEffectState.StartEffect1)
        {
            mapScript.isFastTravel = false;

            if (retroEffectScript.intensity <= 1.7)
            {
                retroEffectScript.intensity += 1.3f * Time.deltaTime;
            }
            else
            {
                retroEffectState = RetroEffectState.StartEffect2;
            }

        }
        else if (retroEffectState == RetroEffectState.StartEffect2)
        {
            if (retroEffectScript.intensity >= 0.25)
            {
                retroEffectScript.intensity -= 1.3f * Time.deltaTime;
            }
            else
            {
                retroEffectState = RetroEffectState.EndEffect1;
            }
        }
    }

    void RetroEndEffect()
    {
        if (retrospectionAudioSource.isPlaying == false && retroEffectState == RetroEffectState.EndEffect1)
        {
            if (retroEffectScript.intensity <= 1.7)
            {
                retroEffectScript.intensity += 1.3f * Time.deltaTime;
            }
            else
            {
                retroEffectState = RetroEffectState.EndEffect2;
            }
        }
        else if (retrospectionAudioSource.isPlaying == false && retroEffectState == RetroEffectState.EndEffect2)
        {
            if (retroEffectScript.intensity >= 0)
            {
                retroEffectScript.intensity -= 1.3f * Time.deltaTime;
            }
            else
            {
                retroEffectState = RetroEffectState.None;
                retroEffectScript.intensity = 0;
                mapScript.isFastTravel = true;
            }
        }
    }

}
