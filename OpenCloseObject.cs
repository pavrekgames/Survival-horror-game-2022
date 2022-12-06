using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseObject : MonoBehaviour {

    [SerializeField] private GameObject interactiveObject;
    
    private Ray playerAim;
    private Camera playerCam;
    [SerializeField] private float rayLength = 4f;

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
                    interactiveObject.GetComponent<Drawers>().Open1();
                }else
                {
                    interactiveObject.GetComponent<Drawers>().Close1();
                }

            }
            else if(Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Drawers2"))
            {

                interactiveObject = hit.transform.gameObject;

                if (interactiveObject.GetComponent<Drawers>().isCloseOpen == false)
                {
                    interactiveObject.GetComponent<Drawers>().Open2();
                }
                else
                {
                    interactiveObject.GetComponent<Drawers>().Close2();
                }

            }
            else if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Cupboard"))
            {

                interactiveObject = hit.transform.gameObject;

                if (interactiveObject.GetComponent<Cupboard>().isCloseOpen == false && interactiveObject.GetComponent<Cupboard>().isNeedKey == false)
                {
                    interactiveObject.GetComponent<Cupboard>().Open1();
                    
                }
                else if(interactiveObject.GetComponent<Cupboard>().isCloseOpen == true && interactiveObject.GetComponent<Cupboard>().isNeedKey == false)
                {
                    interactiveObject.GetComponent<Cupboard>().Close1();
                }

            }

            else if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Door"))
            {

                interactiveObject = hit.transform.gameObject;

                if (interactiveObject.GetComponent<Door>().isOpenClose == false && interactiveObject.GetComponent<Door>().isNeedKey == false)
                {
                    interactiveObject.GetComponent<Door>().Open1();

                }
                else if(interactiveObject.GetComponent<Door>().isOpenClose == true && interactiveObject.GetComponent<Door>().isNeedKey == false)
                {
                    interactiveObject.GetComponent<Door>().Close1();
                }

            }

            else if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Object1"))
            {

                interactiveObject = hit.transform.gameObject;

                if (interactiveObject.GetComponent<BoxSuitcaseObject>().isOpenClose == false)
                {
                    interactiveObject.GetComponent<BoxSuitcaseObject>().Open1();

                }
                else
                {
                    interactiveObject.GetComponent<BoxSuitcaseObject>().Close1();
                }

            }

            else if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Object2"))
            {

                interactiveObject = hit.transform.gameObject;

                if (interactiveObject.GetComponent<BoxSuitcaseObject>().isOpenClose == false)
                {
                    interactiveObject.GetComponent<BoxSuitcaseObject>().Open2();

                }
                else
                {
                    interactiveObject.GetComponent<BoxSuitcaseObject>().Close2();
                }

            }

        }
    }


}
