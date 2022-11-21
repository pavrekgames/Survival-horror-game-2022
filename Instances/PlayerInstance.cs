using UnityEngine;
using System.Collections;

public class PlayerInstance : MonoBehaviour {

	
	public static PlayerInstance instance;
    
    public static string startNr;

    
    public static bool isRespown = false;

    
    void Awake () {
		
		if (!instance) {
			
			DontDestroyOnLoad(this.gameObject) ;
            
            instance = this;
		} else {
			Destroy(gameObject) ;
		}

	}


}
