using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPainting : MonoBehaviour {

	private Transform player;
	private Transform painting;
	public Menu gameMenuScript;
	public Inventory inventoryScript;
	public bool isPainting = false;

	void Start () {

		player = GameObject.Find("Player").transform;
		painting = GameObject.Find("ObrazKapturek").transform;
	}

	void Update () {

		float distance = Vector3.Distance(player.position, painting.position);

		if(distance <= 11){
			painting.gameObject.GetComponent<Collider>().enabled = true;
		}else{
			painting.gameObject.GetComponent<Collider>().enabled = false;
		}

		if(distance <= 11 && isPainting == false && Input.GetMouseButton(0) && inventoryScript.isPanelActive == false && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false)
        {
			painting.gameObject.AddComponent<Rigidbody>();
			isPainting = true;
		}

	}
}
