using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorJmpTrigger : MonoBehaviour {

    public Door doorScript;
    private Screamer scraemerScript;

    void Start()
    {
        scraemerScript = GameObject.Find("Player").GetComponent<Screamer>();
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Collider>().name == "DrzwiOtwJmpTriggerPo" && scraemerScript.isOpenJumpscareDoor == false)
        {
            doorScript.isOpen = false;
            doorScript.isOpenClose = false;
            scraemerScript.isOpenJumpscareDoor = true;
        }
    }
	
	
}
