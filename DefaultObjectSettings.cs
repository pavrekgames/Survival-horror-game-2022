using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultObjectSettings : MonoBehaviour {

    private Menu gameMenuScript;

    public GameObject[] cupboards;
    public GameObject[] drawers1;
    public GameObject[] drawers2;
    public GameObject[] doors;
    public GameObject[] objects1;
    public GameObject[] objects2;
    public GameObject[] movedObjects1;
    public GameObject[] movedObjects2;
    public GameObject[] tasksMovedObjects;
    public GameObject[] pushedObjects;

    void Start () {

        gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();

        cupboards = GameObject.FindGameObjectsWithTag("Szafka");
        drawers1 = GameObject.FindGameObjectsWithTag("Drawers1");
        drawers2 = GameObject.FindGameObjectsWithTag("Drawers2");
        doors = GameObject.FindGameObjectsWithTag("Door");
        objects1 = GameObject.FindGameObjectsWithTag("Obiekt");
        objects2 = GameObject.FindGameObjectsWithTag("Obiekt2");
        movedObjects1 = GameObject.FindGameObjectsWithTag("Move");
        movedObjects2 = GameObject.FindGameObjectsWithTag("Move2");
        pushedObjects = GameObject.FindGameObjectsWithTag("Push");
        tasksMovedObjects = GameObject.FindGameObjectsWithTag("MoveZad");
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
