using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCollision : MonoBehaviour {

	public float upMargin = 0.1f;
	public Transform player;
	public bool isCollide = false;
	

	void Update () {

		//transform.position = new Vector3(Gracz.transform.position.x, Gracz.transform.position.y + ((Gracz.GetComponent<CharacterController>().height * Gracz.localScale.y) / 2) + (transform.localScale.y / 2),Gracz.transform.position.z) ;
		//transform.position.z = Gracz.transform.position.z;
		//transform.position.y = Gracz.transform.position.y + ((Gracz.GetComponent<Collider>().height * Gracz.localScale.y) / 2) + (transform.localScale.y / 2) + MiejsceNad;

	}

	void OnCollisionStay(Collision col){

		if(col.transform.tag == "KucanieKolizja"){
			isCollide = true;
		}
	}

	void OnCollisionExit(){
		isCollide = false;
	}

}
