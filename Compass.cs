using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

    public RawImage compassImage;
    private Transform player;
    public GameObject iconPrefab;

    public List<TaskPoint> tasksPoints = new List<TaskPoint>();

    float compassUnit;

    // Punkty do mapy

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

    // Dodatkowe punkty do notatek nie zadan

    public TaskPoint edwardCupboardPoint;
    public TaskPoint bonesShedPoint;
    public TaskPoint boneStablePoint;
    public TaskPoint toolShedPoint;
    public TaskPoint keyToiletPoint;
    public TaskPoint secretRoomPoint;

    void OnEnable () {

        compassUnit = compassImage.rectTransform.rect.width / 360f;
        player = GameObject.Find("Player").transform;

        keyWoodPoint = GameObject.Find("PunktZadaniaKluczDrewno").GetComponent<TaskPoint>();
        magicWellPoint = GameObject.Find("PunktZadaniaMagicznaStudnia").GetComponent<TaskPoint>();
        gardenDoorPoint = GameObject.Find("PunktZadaniaDrzwiOgrod").GetComponent<TaskPoint>();
        simonElementPoint = GameObject.Find("PunktZadaniaSimonElement").GetComponent<TaskPoint>();
        workshopPoint = GameObject.Find("PunktZadaniaWarsztat").GetComponent<TaskPoint>();
        brokenKeyPoint = GameObject.Find("PunktZadaniaZepsutyKlucz").GetComponent<TaskPoint>();
        animalCementaryPoint = GameObject.Find("PunktZadaniaCmentarzZwierzat").GetComponent<TaskPoint>();
        cornfieldPoint = GameObject.Find("PunktZadaniaKukurydza").GetComponent<TaskPoint>();
        axePoint = GameObject.Find("PunktZadaniaSiekiera").GetComponent<TaskPoint>();
        wardrobeCorridorPoint = GameObject.Find("PunktZadaniaSzafaKorytarz").GetComponent<TaskPoint>();
        cassete2Point = GameObject.Find("PunktZadaniaKaseta2").GetComponent<TaskPoint>();
        goTrailPoint = GameObject.Find("PunktZadaniaIdzSzlak").GetComponent<TaskPoint>();
        getToPoint = GameObject.Find("PunktZadaniaPrzedostanSie").GetComponent<TaskPoint>();
        tomCampPoint = GameObject.Find("PunktZadaniaTomOboz").GetComponent<TaskPoint>();
        ravibePoint = GameObject.Find("PunktZadaniaWawoz").GetComponent<TaskPoint>();
        stevenMeatPoint = GameObject.Find("PunktZadaniaStevenMieso").GetComponent<TaskPoint>();
        stevenMushroomPoint = GameObject.Find("PunktZadaniaStevenGrzyb").GetComponent<TaskPoint>();
        stevenPlantPoint = GameObject.Find("PunktZadaniaStevenRoslina").GetComponent<TaskPoint>();
        stevenSkullPoint = GameObject.Find("PunktZadaniaStevenCzaszka").GetComponent<TaskPoint>();
        stevenShedPoint = GameObject.Find("PunktZadaniaStevenSzopa").GetComponent<TaskPoint>();
        stevenBrookPoint = GameObject.Find("PunktZadaniaStevenPotok").GetComponent<TaskPoint>();
        hutPoint = GameObject.Find("PunktZadaniaChatka").GetComponent<TaskPoint>();
        devilsBrookPoint = GameObject.Find("PunktZadaniaPotokDiably").GetComponent<TaskPoint>();
        grandmaHousePoint = GameObject.Find("PunktZadaniaDomBabci").GetComponent<TaskPoint>();
        aliceHousePoint = GameObject.Find("PunktZadaniaDomAlice").GetComponent<TaskPoint>();
        tomHousePoint = GameObject.Find("PunktZadaniaDomTom").GetComponent<TaskPoint>();
        abandonedHousePoint = GameObject.Find("PunktZadaniaOpuszczonyDom").GetComponent<TaskPoint>();
        stevenHousePoint = GameObject.Find("PunktZadaniaDomSteven").GetComponent<TaskPoint>();
        scientistHousePoint = GameObject.Find("PunktZadaniaDomNaukowca").GetComponent<TaskPoint>();

        edwardCupboardPoint = GameObject.Find("PunktZadaniaSzafkaEdward").GetComponent<TaskPoint>();
        bonesShedPoint = GameObject.Find("PunktZadaniaKoscSzopa").GetComponent<TaskPoint>();
        boneStablePoint = GameObject.Find("PunktZadaniaKoscStajnia").GetComponent<TaskPoint>();
        toolShedPoint = GameObject.Find("PunktZadaniaSzopaNarzedzia").GetComponent<TaskPoint>();
        keyToiletPoint = GameObject.Find("PunktZadaniaKluczWychodek").GetComponent<TaskPoint>();
        secretRoomPoint = GameObject.Find("PunktZadaniaSekretnyPokoj").GetComponent<TaskPoint>();

    }
	
	
	void Update () {

        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);

        foreach(TaskPoint Punkt in tasksPoints)
        {
            Punkt.pointImage.rectTransform.anchoredPosition = GetPointPosition(Punkt);
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

}
