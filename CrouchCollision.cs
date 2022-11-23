using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCollision : MonoBehaviour {

	public bool isCollide = false;

	void OnCollisionStay(Collision col){

		if(col.transform.tag == "CrouchCollision"){
			isCollide = true;
		}
	}

	void OnCollisionExit(){
		isCollide = false;
	}

}
