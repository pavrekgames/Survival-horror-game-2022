using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {

    private Transform player;
    private CrosshairGUI cursorScript;

    [SerializeField] private float pushForce = 3f;
    [SerializeField] private GameObject pushedObject;

    private Ray playerAim;
    private Camera playerCam;
    [SerializeField] private float rayLength = 4f;

    void Start()
    {
        playerCam = Camera.main;
        player = GameObject.Find("Player").transform;
        cursorScript = GameObject.Find("PlayerCamera").GetComponent<CrosshairGUI>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.timeScale == 1)
        {

            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Push") && Input.GetAxis("Vertical") >= 0)
            {
                pushedObject = hit.transform.gameObject;
                pushedObject.transform.position += player.transform.forward * Time.deltaTime * pushForce;
                pushedObject.GetComponent<PushedObject>().isPush = true;
            }
        }
        else if (!Input.GetMouseButton(0) && pushedObject != null)
        {
            pushedObject.GetComponent<PushedObject>().isPush = false;
        }
    }

    public void DefaultSettings()
    {
        if (pushedObject != null)
        {
            pushedObject.GetComponent<PushedObject>().isPush = false;
        }
    }
}
