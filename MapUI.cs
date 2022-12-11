using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour {

    private Map mapScript;
    private Transform player;
    private Player playerScript;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private AudioClip fastTravelSound;

    [SerializeField] private Transform grandmaHousePoint;
    [SerializeField] private Transform aliceHousePoint;
    [SerializeField] private Transform tomHousePoint;
    [SerializeField] private Transform abandonedHousePoint;
    [SerializeField] private Transform stevenHousePoint;
    [SerializeField] private Transform paulHousePoint;
    
    public bool isFastTravel = true;
    private Canvas fastTravleCanvas;

    private Image aliceHouseTravelImage;
    private Image tomHouseTravelImage;
    private Image abandonedHouseTravelImage;
    private Image stevenHouseTravelImage;
    private Image PaulHouseTravelImage;

    public Text woodenKeyPointer;
    public Text magicWellPointer;
    public Image stonesAreaPointer;
    public Text gardenDoorPointer;
    public Image bonesAreaPointer;
    public Image aliceHousePointer;
    public Text simonElementPointer;
    public Text workshopPointer;
    public Text brokenKeyPointer;
    public Image animalCemetaryArrowPointer;
    public Text animalCemetaryPointer;
    public Image victorArrowPointer;
    public Image victorArrowPointer2;
    public Text cornfieldPointer;
    public Text axePointer;
    public Text corridorWardrobePointer;
    public Text cassete2Pointer;
    public Text goTrailPointer;
    public Image trailArrowPointer;
    public Text getToTomRoadPointer;
    public Image tomHousePointer;
    public Image cornfieldAreaPointer;
    public Text tomCampPointer;
    public Image pumpkinAreaPointer;
    public Text ravinePointer;
    public Image goRavineArrowPointer;
    public Image abandonedPointer;
    public Image stevenHousePointer;
    public Image stevenKeyAreaPointer;
    public Text stevenMeatPointer;
    public Text stevenMushroomPointer;
    public Text stevenPlantPointer;
    public Text stevenSkullPointer;
    public Text stevenShedPointer;
    public Text stevenBrookPointer;
    public Image PaulHousePointer;
    public Text hutPointer;
    public Text devilsBrookPointer;
    public Image KryjowkaDiablyObszar;
    public Text EdwardCupboardPointer;
    public Text boneShedPointer;
    public Text boneStablePointer;
    public Text toolShedPointer;
    public Text keyToiletPointer;
    public Text secretRoomPointer;

    void Start () {
        fastTravleCanvas = GameObject.Find("CanvasFastTravel").GetComponent<Canvas>();

        aliceHouseTravelImage = GameObject.Find("MiejsciePodrozyDomAlice").GetComponent<Image>();
        tomHouseTravelImage = GameObject.Find("MiejsciePodrozyDomTom").GetComponent<Image>();
        abandonedHouseTravelImage = GameObject.Find("MiejsciePodrozyDomOpuszczony").GetComponent<Image>();
        stevenHouseTravelImage = GameObject.Find("MiejsciePodrozyDomSteven").GetComponent<Image>();
        PaulHouseTravelImage = GameObject.Find("MiejsciePodrozyDomPaul").GetComponent<Image>();

        grandmaHousePoint = GameObject.Find("GrandmaHousePoint").transform;
        aliceHousePoint = GameObject.Find("AliceHousePoint").transform;
        tomHousePoint = GameObject.Find("TomHousePoint").transform;
        abandonedHousePoint = GameObject.Find("AbandonedHousePoint").transform;
        stevenHousePoint = GameObject.Find("StevenHousePoint").transform;
        paulHousePoint = GameObject.Find("ScientistHousePoint").transform;
    }
	

    public void FastTravel()
    {
        fastTravleCanvas.enabled = true;
        audioSource.PlayOneShot(buttonSound);

    }

    public void TravelToGrandmaHouse()
    {
        player.transform.position = new Vector3(grandmaHousePoint.transform.position.x, grandmaHousePoint.transform.position.y, grandmaHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        mapScript.HideMap();
    }

    public void TravelToAliceHouse()
    {
        player.transform.position = new Vector3(aliceHousePoint.transform.position.x, aliceHousePoint.transform.position.y, aliceHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        mapScript.HideMap();
    }

    public void TravelToTomHouse()
    {
        player.transform.position = new Vector3(tomHousePoint.transform.position.x, tomHousePoint.transform.position.y, tomHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        mapScript.HideMap();
    }

    public void TravelToAbandonedHouse()
    {
        player.transform.position = new Vector3(abandonedHousePoint.transform.position.x, abandonedHousePoint.transform.position.y, abandonedHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        mapScript.HideMap();
    }

    public void TravelToStevenHouse()
    {
        player.transform.position = new Vector3(stevenHousePoint.transform.position.x, stevenHousePoint.transform.position.y, stevenHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        mapScript.HideMap();
    }

    public void TravelToPaulHouse()
    {
        player.transform.position = new Vector3(paulHousePoint.transform.position.x, paulHousePoint.transform.position.y, paulHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        mapScript.HideMap();
    }
}
