using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMeat : MonoBehaviour {

    public struct Meat
    {
        public Transform meatObject;
        public string meatName;
        public Light meatLight;
        public float meatCondition;
        public bool isDragMeat;
    }

    public Meat[] meats;

	private Ray playerAim;
	private Camera playerCam;
    [SerializeField] private float rayLength = 4f;

	void OnEnable () {

		playerCam = Camera.main;

        meats[0].meatCondition = 100;
        meats[1].meatCondition = 100;
        meats[2].meatCondition = 100;

        meats[0].isDragMeat = false;
        meats[1].isDragMeat = false;
        meats[2].isDragMeat = false;

        meats[0].meatLight.enabled = true;
        meats[1].meatLight.enabled = true;
        meats[2].meatLight.enabled = true;

        meats[0].meatObject.transform.position = new Vector3 (2391.53f, 74.65f, 2116.67f);
        meats[1].meatObject.transform.position = new Vector3 (2330.4f, 74.65f, 2171.03f);
        meats[2].meatObject.transform.position = new Vector3 (2344.2f, 74.65f, 2218.89f);

	}
	

	void Update () {

        CheckMeats();

		if (Input.GetMouseButton (0) && Time.timeScale == 1) {

			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 13)) {

                if (hit.collider.gameObject.name == meats[0].meatName) {
                    meats[0].isDragMeat = true;
				} else if (hit.collider.gameObject.name == meats[1].meatName) {
                    meats[1].isDragMeat = true;
                } else if (hit.collider.gameObject.name == meats[2].meatName) {
                    meats[2].isDragMeat = true;
                }
			}
		}

		if(Input.GetMouseButtonUp(0) && Time.timeScale == 1)
        {
            meats[0].isDragMeat = false;
            meats[1].isDragMeat = false;
            meats[2].isDragMeat = false;
        }

	}

    void CheckMeats()
    {
        if (meats[0].meatCondition <= 0)
        {
            meats[0].meatLight.enabled = false;
        }

        if (meats[1].meatCondition <= 0)
        {
            meats[1].meatLight.enabled = false;
        }

        if (meats[2].meatCondition <= 0)
        {
            meats[2].meatLight.enabled = false;
        }
    }

}
