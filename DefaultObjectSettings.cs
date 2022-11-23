using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultObjectSettings : MonoBehaviour {

    [SerializeField] private GameObject[] cupboards;
    [SerializeField] private GameObject[] drawers1;
    [SerializeField] private GameObject[] drawers2;
    [SerializeField] private GameObject[] doors;
    [SerializeField] private GameObject[] objects1;
    [SerializeField] private GameObject[] objects2;
    [SerializeField] private GameObject[] movedObjects1;
    [SerializeField] private GameObject[] movedObjects2;
    [SerializeField] private GameObject[] tasksMovedObjects;
    [SerializeField] private GameObject[] pushedObjects;
    
    void Start () {

        cupboards = GameObject.FindGameObjectsWithTag("Cupboard");
        drawers1 = GameObject.FindGameObjectsWithTag("Drawers1");
        drawers2 = GameObject.FindGameObjectsWithTag("Drawers2");
        doors = GameObject.FindGameObjectsWithTag("Door");
        objects1 = GameObject.FindGameObjectsWithTag("Object1");
        objects2 = GameObject.FindGameObjectsWithTag("Object2");
        movedObjects1 = GameObject.FindGameObjectsWithTag("Move1");
        movedObjects2 = GameObject.FindGameObjectsWithTag("Move2");
        pushedObjects = GameObject.FindGameObjectsWithTag("Push");
        tasksMovedObjects = GameObject.FindGameObjectsWithTag("MoveTask");
    }
	

    public void LoadDefaultSettings()
    {

        foreach (GameObject Obiekt in cupboards)
        {
            Obiekt.GetComponent<Cupboard>().DefaultSettings();
        }

        foreach (GameObject Obiekt in drawers1)
        {
            Obiekt.GetComponent<Drawers>().DefaultSettings();
        }

        foreach (GameObject Obiekt in drawers2)
        {
            Obiekt.GetComponent<Drawers>().DefaultSettings();
        }

        foreach (GameObject Obiekt in doors)
        {
            Obiekt.GetComponent<Door>().DefaultSettings();
        }

        foreach (GameObject Obiekt in objects1)
        {
            Obiekt.GetComponent<BoxSuitcaseObject>().DefaultSettings();
        }

        foreach (GameObject Obiekt in objects2)
        {
            Obiekt.GetComponent<BoxSuitcaseObject>().DefaultSettings();
        }

        foreach (GameObject Obiekt in movedObjects1)
        {
            Obiekt.GetComponent<DraggedObject>().DefaultSettings();
        }

        foreach (GameObject Obiekt in movedObjects2)
        {
            Obiekt.GetComponent<Coffin>().DefaultSettings();
        }

        foreach (GameObject Obiekt in pushedObjects)
        {
            Obiekt.GetComponent<PushedObject>().DefaultSettings();
        }


    }


}
