using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public bool isPlayerCanInput;

    private Health healthScript;
    private Menu gameMenuScript;
	
	void Start () {

        gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        healthScript = GameObject.Find("Player").GetComponent<Health>();

    }
	

	void Update () {

        IsPlayerCanInput();
        isPlayerCanInput = IsPlayerCanInput();
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
