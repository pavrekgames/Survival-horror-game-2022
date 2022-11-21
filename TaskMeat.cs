using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMeat : MonoBehaviour {

	private Transform meat1; 
	private Transform meat2; 
	private Transform meat3; 
	public bool isDragMeat1 = false;
	public bool isDragMeat2 = false;
	public bool isDragMeat3 = false;
    private Light meat1Light;
    private Light meat2Light;
    private Light meat3Light;
    public float meat1Condition = 100;
	public float meat2Condition = 100;
	public float meat3Condition = 100;
	//public Color KolorMiesa = Color.black;
	//public Color KolorPoczatkowy = Color.red;

	private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;

	void OnEnable () {

		playerCam = Camera.main;

		meat1 = GameObject.Find("MiesoDlaPotwora1").transform;
		meat2 = GameObject.Find("MiesoDlaPotwora2").transform;
		meat3 = GameObject.Find("MiesoDlaPotwora3").transform;

        meat1Light = GameObject.Find("SwiatloMiesa1").GetComponent<Light>();
        meat2Light = GameObject.Find("SwiatloMiesa2").GetComponent<Light>();
        meat3Light = GameObject.Find("SwiatloMiesa3").GetComponent<Light>();

        meat1Condition = 100;
        meat2Condition = 100;
        meat3Condition = 100;

        isDragMeat1 = false;
        isDragMeat2 = false;
        isDragMeat3 = false;

        meat1Light.enabled = true;
        meat2Light.enabled = true;
        meat3Light.enabled = true;

        meat1.transform.position = new Vector3 (2391.53f, 74.65f, 2116.67f);
		meat2.transform.position = new Vector3 (2330.4f, 74.65f, 2171.03f);
		meat3.transform.position = new Vector3 (2344.2f, 74.65f, 2218.89f);

	}
	

	void Update () {

		if (Input.GetMouseButton (0) && Time.timeScale == 1) {

			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 13)) {

                if (hit.collider.gameObject.name == "MiesoDlaPotwora1") { // && Input.GetMouseButtonDown (0)
					isDragMeat1 = true;
				} else if (hit.collider.gameObject.name == "MiesoDlaPotwora2") { // && Input.GetMouseButtonDown (0)
					isDragMeat2 = true;
				} else if (hit.collider.gameObject.name == "MiesoDlaPotwora3") { // && Input.GetMouseButtonDown (0)
					isDragMeat3 = true;
				}
				
			}

		}

		if(Input.GetMouseButtonUp(0) && Time.timeScale == 1)
        {
			isDragMeat1 = false;
			isDragMeat2 = false;
			isDragMeat3 = false;
		}

		if(meat1Condition <= 0){
            meat1Light.enabled = false;
        }

		if(meat2Condition <= 0){ 
            meat2Light.enabled = false;
        }

		if(meat3Condition <= 0){
            meat3Light.enabled = false;
        }
	}
}
