using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseObject : MonoBehaviour {

    public GameObject interactiveObject;

    private Ray playerAim;
    private Camera playerCam;
    public float rayLength = 4f;

    void Start () {

        playerCam = Camera.main;

    }
	
	
	void Update () {

        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {

            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Drawers1"))
            {
                interactiveObject = hit.transform.gameObject;

                if(interactiveObject.GetComponent<Drawers>().isCloseOpen == false)
                {
                    interactiveObject.GetComponent<Drawers>().OpenDrawers1();
                }else
                {
                    interactiveObject.GetComponent<Drawers>().CloseDrawers2();
                }

            }
            else if(Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Drawers2"))
            {

                interactiveObject = hit.transform.gameObject;

                if (interactiveObject.GetComponent<Drawers>().isCloseOpen == false)
                {
                    interactiveObject.GetComponent<Drawers>().OpenDrawers2();
                }
                else
                {
                    interactiveObject.GetComponent<Drawers>().CloseDrawers2();
                }

            }
            else if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Szafka"))
            {

                interactiveObject = hit.transform.gameObject;

                if (interactiveObject.GetComponent<Cupboard>().isCloseOpen == false && interactiveObject.GetComponent<Cupboard>().isNeedKey == false)
                {
                    interactiveObject.GetComponent<Cupboard>().OpenDoor();
                    
                }
                else if(interactiveObject.GetComponent<Cupboard>().isCloseOpen == true && interactiveObject.GetComponent<Cupboard>().isNeedKey == false)
                {
                    interactiveObject.GetComponent<Cupboard>().CloseDoor();
                }

            }

            else if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Door"))
            {

                interactiveObject = hit.transform.gameObject;

                if (interactiveObject.GetComponent<Door>().isOpenClose == false && interactiveObject.GetComponent<Door>().isNeedKey == false)
                {
                    interactiveObject.GetComponent<Door>().OpenDoor();

                }
                else if(interactiveObject.GetComponent<Door>().isOpenClose == true && interactiveObject.GetComponent<Door>().isNeedKey == false)
                {
                    interactiveObject.GetComponent<Door>().CloseDoor();
                }

            }

            else if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Obiekt"))
            {

                interactiveObject = hit.transform.gameObject;

                if (interactiveObject.GetComponent<BoxSuitcaseObject>().isOpenClose == false)
                {
                    interactiveObject.GetComponent<BoxSuitcaseObject>().OpenObject();

                }
                else
                {
                    interactiveObject.GetComponent<BoxSuitcaseObject>().CloseObject();
                }

            }

            else if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Obiekt2"))
            {

                interactiveObject = hit.transform.gameObject;

                if (interactiveObject.GetComponent<BoxSuitcaseObject>().isOpenClose == false)
                {
                    interactiveObject.GetComponent<BoxSuitcaseObject>().OpenObject2();

                }
                else
                {
                    interactiveObject.GetComponent<BoxSuitcaseObject>().CloseObject2();
                }

            }

        }

    }
}
