using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerManager : MonoBehaviour {

    public bool isPlayerCanInput;

    private Health healthScript;
    private Menu gameMenuScript;

    public AudioMixerSnapshot pauseSoundSnapshot;
    public AudioMixerSnapshot unPauseSoundSnapshot;

    void Start () {

        gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        healthScript = GameObject.Find("Player").GetComponent<Health>();

    }
	

	void Update () {

        CheckSoundSnapshot();
        IsPlayerCanInput();
        isPlayerCanInput = IsPlayerCanInput();
	}

    public void CheckSoundSnapshot()
    {
        if (Time.timeScale == 0)
        {
            pauseSoundSnapshot.TransitionTo(0.01f);
        }
        else
        {
            unPauseSoundSnapshot.TransitionTo(0.01f);
        }
    }

    public bool IsPlayerCanInput()
    {
        if(Time.timeScale == 1 &&
            healthScript.health > 0 && 
            gameMenuScript.isLoadedGame == false)
        {
            return true;
        }else
        {
            return false;
        }
    }

}
