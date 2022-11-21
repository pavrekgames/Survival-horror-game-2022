using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

    private Transform player;
    public GameObject objectToDrag;
    public bool isDragged = false;

    private Menu gameMenu;
    private Inventory inventoryScript;
    private Notifications notificationScript;

    private Ray playerAim;
    public Camera playerCam;
    public float rayLength = 4f;
    public float defaultValue = 28f;
    public float velocityValue = 18;
    public float forceValue = 5;
    public float objectToDragWeight = 100;

    public bool isMoved = false;
    public bool isTaskObjectMoved = false;

    void Start() {

        //playerCam = Camera.main;

        player = GameObject.Find("Player").transform;
        gameMenu = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
        notificationScript = GameObject.Find("Player").GetComponent<Notifications>();

    }


    void FixedUpdate() {

        if (Input.GetMouseButton(0) && Time.timeScale == 1 && gameMenu.isMenu == false && inventoryScript.isPanelActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && notificationScript.isTutorialNotification == false)
        {

            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            //RayLength = 6;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Move") && isDragged == false)
            {
                objectToDrag = hit.transform.gameObject;
                isDragged = true;
                objectToDrag.layer = 13;
                isMoved = true;
                isTaskObjectMoved = false;
                forceValue = objectToDrag.gameObject.GetComponent<DraggedObject>().objectForce;
                velocityValue = objectToDrag.gameObject.GetComponent<DraggedObject>().objectVelocity;
            }

            else if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("MoveZad") && isDragged == false)
            {
                objectToDrag = hit.transform.gameObject;
                isDragged = true;
                objectToDrag.layer = 13;
                isMoved = false;
                isTaskObjectMoved = true;
                forceValue = objectToDrag.gameObject.GetComponent<DraggedObject>().objectForce;
                velocityValue = objectToDrag.gameObject.GetComponent<DraggedObject>().objectVelocity;
            }

            if (isDragged == true && isMoved == true && isTaskObjectMoved == false)
            {
                Vector3 objectToDragPosition = objectToDrag.transform.position;
                Vector3 nextPosition = playerCam.transform.position + playerAim.direction * rayLength; //Vector3 nextPos = playerCam.transform.position + playerAim.direction * distance;
                Vector3 objectToDragRotation = new Vector3(objectToDrag.transform.rotation.x, player.transform.rotation.y, 90f);
                //Obiekt.GetComponent<Rigidbody>().MovePosition(NextPoz);
                //Obiekt.transform.position = playerCam.transform.position + playerAim.direction * Wartosc; // RayLength
                objectToDrag.GetComponent<Rigidbody>().AddForce(nextPosition * 0.1f); //RayLength
                objectToDrag.GetComponent<Rigidbody>().velocity = (nextPosition - objectToDragPosition) * defaultValue;
                //Obiekt.GetComponent<Rigidbody>().velocity = (NextPoz - ObiektPoz) * 0.15f; // 0.15f
                objectToDrag.GetComponent<Rigidbody>().useGravity = false;
                objectToDrag.GetComponent<Rigidbody>().mass = 3;
                //Obiekt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                objectToDrag.gameObject.transform.LookAt(player.transform.position);
                objectToDrag.gameObject.transform.Rotate(objectToDragRotation);
            }

            else if (isDragged == true && isMoved == false && isTaskObjectMoved == true)
            {
                Vector3 objectToDragPosition = objectToDrag.transform.position;
                Vector3 nextPosition = playerCam.transform.position + playerAim.direction * rayLength; //Vector3 nextPos = playerCam.transform.position + playerAim.direction * distance;
                //Obiekt.GetComponent<Rigidbody>().MovePosition(NextPoz);
                //Obiekt.transform.position = playerCam.transform.position + playerAim.direction * Wartosc; // RayLength
                objectToDrag.GetComponent<Rigidbody>().AddForce(nextPosition * 0.1f); //RayLength
                objectToDrag.GetComponent<Rigidbody>().velocity = (nextPosition - objectToDragPosition) * defaultValue;
                //Obiekt.GetComponent<Rigidbody>().velocity = (NextPoz - ObiektPoz) * 0.15f; // 0.15f
                objectToDrag.GetComponent<Rigidbody>().useGravity = false;
                objectToDrag.GetComponent<Rigidbody>().mass = 3;
                objectToDrag.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

        }

    }

    void Update() {

        if ((Input.GetMouseButtonUp(0) && objectToDrag != null && isDragged == true) || (Time.timeScale == 0 && objectToDrag != null))
        {
            objectToDrag.layer = 9;
            //RayLength = 4;
            //Vector3 ObiektPoz = Obiekt.transform.position;
            //Vector3 NextPoz = playerCam.transform.position + playerAim.direction * RayLength;

            if (isMoved == true && isTaskObjectMoved == false) {

                isDragged = false;
                //Obiekt.GetComponent<Rigidbody>().drag = 10;
                objectToDrag.GetComponent<Rigidbody>().velocity = objectToDrag.GetComponent<Rigidbody>().velocity / velocityValue;
                objectToDrag.GetComponent<Rigidbody>().AddForce(-objectToDrag.transform.right * forceValue);
                objectToDrag.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                //Obiekt.GetComponent<Rigidbody>().Sleep();
                objectToDrag.GetComponent<Rigidbody>().useGravity = true;
                objectToDrag.GetComponent<Rigidbody>().mass = objectToDragWeight;
                objectToDrag.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                objectToDrag.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;  // | RigidbodyConstraints.FreezeRotationY;
                //Obiekt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
                isMoved = false;

            } else if (isMoved == false && isTaskObjectMoved == true)
            {

                isDragged = false;
                //Obiekt.GetComponent<Rigidbody>().drag = 10;
                objectToDrag.GetComponent<Rigidbody>().velocity = objectToDrag.GetComponent<Rigidbody>().velocity / velocityValue;
                objectToDrag.GetComponent<Rigidbody>().AddForce(objectToDrag.transform.forward * forceValue);
                //Obiekt.GetComponent<Rigidbody>().Sleep();
                objectToDrag.GetComponent<Rigidbody>().useGravity = true;
                objectToDrag.GetComponent<Rigidbody>().mass = objectToDragWeight;
                objectToDrag.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                objectToDrag.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                isTaskObjectMoved = false;

            }

        }

    }


    public void SetDefaultValues()
    {

        if(objectToDrag != null)
        {
            isDragged = false;
            objectToDrag.GetComponent<Rigidbody>().useGravity = true;
            objectToDrag.layer = 9;
            objectToDrag = null;
        }

    }

}
