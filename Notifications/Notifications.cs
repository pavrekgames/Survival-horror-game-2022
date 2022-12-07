using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notifications : MonoBehaviour {

    private PlayerManager playerManagerScript;

	private Ray playerAim;
	private Camera playerCam;
	[SerializeField] private float rayLength = 4f;

    void OnEnable () {

        playerManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
        playerCam = Camera.main;

    }

	void Update () {

		if (Input.GetMouseButtonDown (0) && playerManagerScript.isPlayerCanInput == true) {

			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit; 

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {

				if (hit.collider.gameObject.tag == "Door" || hit.collider.gameObject.tag == "Hand") {

                    if (hit.transform.gameObject.GetComponent<RaycastNotification>())
                    {
                        hit.transform.gameObject.GetComponent<RaycastNotification>().SendNotification();
                    }
				}
			} 
		} 
} 

	
}

