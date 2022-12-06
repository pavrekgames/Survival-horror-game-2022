using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class DragObject : MonoBehaviour {

    private Transform player;
    public GameObject objectToDrag;
    public bool isDragged = false;

    private Ray playerAim;
    [SerializeField] private Camera playerCam;
    [SerializeField] private float rayLength = 4f;

    [Header("Dragged object")]
    [SerializeField] private float defaultValue = 28f;
    [SerializeField] private float velocityValue = 18;
    [SerializeField] private float forceValue = 5;
    [SerializeField] private float objectToDragWeight = 100;

    public enum ObjectType
    {
        None,
        MoveObject,
        MoveTaskObject
    }

    public ObjectType objectType;

    void Start() {

        player = GameObject.Find("Player").transform;

    }

    void FixedUpdate() {

        if (Input.GetMouseButton(0) && Time.timeScale == 1)
        {

            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("Move") && isDragged == false)
            {
                objectToDrag = hit.transform.gameObject;
                SetDrag(ObjectType.MoveObject, objectToDrag);
            }

            else if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && hit.transform.gameObject.CompareTag("MoveTask") && isDragged == false)
            {
                objectToDrag = hit.transform.gameObject;
                SetDrag(ObjectType.MoveTaskObject, objectToDrag);
            }

            if (isDragged == true && objectType == ObjectType.MoveObject)
            {
                DragMoveObject();
            }

            else if (isDragged == true && objectType == ObjectType.MoveTaskObject)
            {
                DragMoveTaskObject();
            }
        }
    }

    void Update() {

        if ((Input.GetMouseButtonUp(0) && objectToDrag != null && isDragged == true) || (Time.timeScale == 0 && objectToDrag != null))
        {
            objectToDrag.layer = 9;
            
            if (objectType == ObjectType.MoveObject)
            {
                DropMoveObject();

            } else if (objectType == ObjectType.MoveTaskObject)
            {
                DropMoveTaskObject();
            }
        }
    }

    private void SetDrag(ObjectType objectType, GameObject objectToDrag)
    {
        isDragged = true;
        objectToDrag.layer = 13;
        this.objectType = objectType;
        forceValue = objectToDrag.gameObject.GetComponent<DraggedObject>().objectForce;
        velocityValue = objectToDrag.gameObject.GetComponent<DraggedObject>().objectVelocity;
    }

    private void Drag()
    {
        Vector3 objectToDragPosition = objectToDrag.transform.position;
        Vector3 nextPosition = playerCam.transform.position + playerAim.direction * rayLength;
        objectToDrag.GetComponent<Rigidbody>().AddForce(nextPosition * 0.1f);
        objectToDrag.GetComponent<Rigidbody>().velocity = (nextPosition - objectToDragPosition) * defaultValue;
        objectToDrag.GetComponent<Rigidbody>().useGravity = false;
        objectToDrag.GetComponent<Rigidbody>().mass = 3;
    }

    private void DragMoveObject()
    {
        Drag();
        Vector3 objectToDragRotation = new Vector3(objectToDrag.transform.rotation.x, player.transform.rotation.y, 90f);
        objectToDrag.gameObject.transform.LookAt(player.transform.position);
        objectToDrag.gameObject.transform.Rotate(objectToDragRotation);
    }

    private void DragMoveTaskObject()
    {
        Drag();
        objectToDrag.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Drop()
    {
        isDragged = false;
        objectType = ObjectType.None;
        objectToDrag.GetComponent<Rigidbody>().velocity = objectToDrag.GetComponent<Rigidbody>().velocity / velocityValue;
        objectToDrag.GetComponent<Rigidbody>().useGravity = true;
        objectToDrag.GetComponent<Rigidbody>().mass = objectToDragWeight;
        objectToDrag.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    void DropMoveObject()
    {
        Drop();
        objectToDrag.GetComponent<Rigidbody>().AddForce(-objectToDrag.transform.right * forceValue);
        objectToDrag.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        objectToDrag.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;

    }

    void DropMoveTaskObject()
    {
        Drop();
        objectToDrag.GetComponent<Rigidbody>().AddForce(objectToDrag.transform.forward * forceValue);
        objectToDrag.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void SetDefaultValues()
    {
        if(objectToDrag != null)
        {
            isDragged = false;
            objectType = ObjectType.None;
            objectToDrag.GetComponent<Rigidbody>().useGravity = true;
            objectToDrag.layer = 9;
            objectToDrag = null;
        }
    }
}
