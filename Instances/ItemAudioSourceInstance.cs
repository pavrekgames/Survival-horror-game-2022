using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAudioSourceInstance : MonoBehaviour {

	public static ItemAudioSourceInstance instance;


	void Awake () {
		
		if (!instance) {
			
			DontDestroyOnLoad(this.gameObject) ;
			
			instance = this;
		} else {
			Destroy(gameObject) ;
		}

	}


}
