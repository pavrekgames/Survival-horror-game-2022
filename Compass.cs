using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

    private Transform player;
    [SerializeField] private RawImage compassImage;
    [SerializeField] private GameObject iconPrefab;

    public List<TaskPoint> tasksPoints = new List<TaskPoint>();

    float compassUnit;

    public TaskPoint[] taskPointsArray;

    public TaskPoint keyWoodPoint;
    public TaskPoint magicWellPoint;
    public TaskPoint gardenDoorPoint;
    public TaskPoint simonElementPoint;
    public TaskPoint workshopPoint;
    public TaskPoint brokenKeyPoint;
    public TaskPoint animalCementaryPoint;
    public TaskPoint cornfieldPoint;
    public TaskPoint axePoint;
    public TaskPoint wardrobeCorridorPoint;
    public TaskPoint cassete2Point;
    public TaskPoint goTrailPoint;
    public TaskPoint getToPoint;
    public TaskPoint tomCampPoint;
    public TaskPoint ravibePoint;
    public TaskPoint stevenMeatPoint;
    public TaskPoint stevenMushroomPoint;
    public TaskPoint stevenPlantPoint;
    public TaskPoint stevenSkullPoint;
    public TaskPoint stevenShedPoint;
    public TaskPoint stevenBrookPoint;
    public TaskPoint hutPoint;
    public TaskPoint devilsBrookPoint;
    public TaskPoint grandmaHousePoint;
    public TaskPoint aliceHousePoint;
    public TaskPoint tomHousePoint;
    public TaskPoint abandonedHousePoint;
    public TaskPoint stevenHousePoint;
    public TaskPoint scientistHousePoint;
    public TaskPoint edwardCupboardPoint;
    public TaskPoint bonesShedPoint;
    public TaskPoint boneStablePoint;
    public TaskPoint toolShedPoint;
    public TaskPoint keyToiletPoint;
    public TaskPoint secretRoomPoint;

    void OnEnable () {

        compassUnit = compassImage.rectTransform.rect.width / 360f;
        player = GameObject.Find("Player").transform;

        AddPointsToArray();
    }
	
	
	void Update () {

        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);

        foreach(TaskPoint point in tasksPoints)
        {
            point.pointImage.rectTransform.anchoredPosition = GetPointPosition(point);
        }

	}

    public void AddTaskPoint(TaskPoint point)
    {
        GameObject NewPoint = Instantiate(iconPrefab, compassImage.transform);
        NewPoint.transform.SetParent(compassImage.transform, false);
        NewPoint.transform.localScale = new Vector3(1, 1, 1);
        point.pointImage = NewPoint.GetComponent<Image>();
        point.pointImage.sprite = point.pointIcon;

        tasksPoints.Add(point);
    }

    public void RemoveTaskPoint(TaskPoint point)
    {
        Destroy(point.pointImage);
        tasksPoints.Remove(point);
    }

    Vector2 GetPointPosition(TaskPoint point)
    {

        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 forwardPosition = new Vector2(player.transform.forward.x, player.transform.forward.z);

        Vector2 rotationPosition = point.PointPosition - playerPosition;

        float angle = Vector2.Angle(point.PointPosition - playerPosition, forwardPosition);

        return new Vector2(compassUnit * angle, 0f);
    }

    void AddPointsToArray()
    {

        taskPointsArray = new TaskPoint[35];

        taskPointsArray[0] = GameObject.Find("KeyWoodPoint").GetComponent<TaskPoint>();
        taskPointsArray[1] = GameObject.Find("MagicWellPoint").GetComponent<TaskPoint>();
        taskPointsArray[2] = GameObject.Find("GardenDoorPoint").GetComponent<TaskPoint>();
        taskPointsArray[3] = GameObject.Find("SimonElementPoint").GetComponent<TaskPoint>();
        taskPointsArray[4] = GameObject.Find("WorkshopPoint").GetComponent<TaskPoint>();
        taskPointsArray[5] = GameObject.Find("BrokenKeyPoint").GetComponent<TaskPoint>();
        taskPointsArray[6] = GameObject.Find("animalCementaryPoint").GetComponent<TaskPoint>();
        taskPointsArray[7] = GameObject.Find("CornfieldPoint").GetComponent<TaskPoint>();
        taskPointsArray[8] = GameObject.Find("AxePoint").GetComponent<TaskPoint>();
        taskPointsArray[9] = GameObject.Find("WardrobeCorridorPoint").GetComponent<TaskPoint>();
        taskPointsArray[10] = GameObject.Find("Cassete2Point").GetComponent<TaskPoint>();
        taskPointsArray[11] = GameObject.Find("GoTrailPoint").GetComponent<TaskPoint>();
        taskPointsArray[12] = GameObject.Find("GetToPoint").GetComponent<TaskPoint>();
        taskPointsArray[13] = GameObject.Find("TomCampPoint").GetComponent<TaskPoint>();
        taskPointsArray[14] = GameObject.Find("RavibePoint").GetComponent<TaskPoint>();
        taskPointsArray[15] = GameObject.Find("StevenMeatPoint").GetComponent<TaskPoint>();
        taskPointsArray[16] = GameObject.Find("StevenMushroomPoint").GetComponent<TaskPoint>();
        taskPointsArray[17] = GameObject.Find("StevenPlantPoint").GetComponent<TaskPoint>();
        taskPointsArray[18] = GameObject.Find("StevenSkullPoint").GetComponent<TaskPoint>();
        taskPointsArray[19] = GameObject.Find("StevenShedPoint").GetComponent<TaskPoint>();
        taskPointsArray[20] = GameObject.Find("StevenBrookPoint").GetComponent<TaskPoint>();
        taskPointsArray[21] = GameObject.Find("HutPoint").GetComponent<TaskPoint>();
        taskPointsArray[22] = GameObject.Find("DevilsBrookPoint").GetComponent<TaskPoint>();
        taskPointsArray[23] = GameObject.Find("GrandmaHousePoint").GetComponent<TaskPoint>();
        taskPointsArray[24] = GameObject.Find("AliceHousePoint").GetComponent<TaskPoint>();
        taskPointsArray[25] = GameObject.Find("TomHousePoint").GetComponent<TaskPoint>();
        taskPointsArray[26] = GameObject.Find("AbandonedHousePoint").GetComponent<TaskPoint>();
        taskPointsArray[27] = GameObject.Find("StevenHousePoint").GetComponent<TaskPoint>();
        taskPointsArray[28] = GameObject.Find("ScientistHousePoint").GetComponent<TaskPoint>();
        taskPointsArray[29] = GameObject.Find("EdwardCupboardPoint").GetComponent<TaskPoint>();
        taskPointsArray[30] = GameObject.Find("BonesShedPoint").GetComponent<TaskPoint>();
        taskPointsArray[31] = GameObject.Find("BoneStablePoint").GetComponent<TaskPoint>();
        taskPointsArray[32] = GameObject.Find("ToolShedPoint").GetComponent<TaskPoint>();
        taskPointsArray[33] = GameObject.Find("KeyToiletPoint").GetComponent<TaskPoint>();
        taskPointsArray[34] = GameObject.Find("SecretRoomPoint").GetComponent<TaskPoint>();
    }

}
