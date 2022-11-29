using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour {

    private Map mapScript;
    private PlayerManager playerManagerScript;
    public Canvas mapCanvas;
    public RectTransform resolutionRect;
    private Menu gameMenuScript;
    private Inventory inventoryScript;
    private Tasks tasksScript;
    public bool isMap = false;
    public AudioSource audioSource;
    public AudioClip mapSound;
    public AudioClip buttonSound;
    public AudioClip fastTravelSound;
    public Camera mapCamera;
    private Transform player;
    private Player playerScript;
    private Health healthScript;
    private Notes notesScript;
    private Notifications notificationScript;
    private StraszakScarecrow scarecrowJumpscareScript;

    private RectTransform wholeMapRect;
    private RectTransform pointerRect;

    private Camera playerCam;
    private CrosshairGUI cursorScript;

    // Szybka podroz

    public bool isFastTravel = true;
    private Canvas fastTravleCanvas;
    private Button fastTravelButon;

    private Image aliceHouseTravelImage;
    private Image tomHouseTravelImage;
    private Image abandonedHouseTravelImage;
    private Image stevenHouseTravelImage;
    private Image PaulHouseTravelImage;

    private Transform grandmaHousePoint;
    private Transform aliceHousePoint;
    private Transform tomHousePoint;
    private Transform abandonedHousePoint;
    private Transform stevenHousePoint;
    private Transform paulHousePoint;

    // map UI
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
		
	}
	

	void Update () {
		
	}

    public void FastTravel()
    {
        fastTravleCanvas.enabled = true;
        audioSource.PlayOneShot(buttonSound);

        // czy mozliwa podroz do domu Alice

        if (tasksScript.isAliceSearchTask == true)
        {
            aliceHouseTravelImage.enabled = true;
        }
        else
        {
            aliceHouseTravelImage.enabled = false;
        }

        // czy mozliwa podroz do domu Tom

        if (tasksScript.isTomPumpkinTask == true || tasksScript.isTomCornifieldTask == true)
        {
            tomHouseTravelImage.enabled = true;
        }
        else
        {
            tomHouseTravelImage.enabled = false;
        }

        // czy mozliwa podroz do domu Opuszczony

        if (tasksScript.isStevenSearchTask == true)
        {
            abandonedHouseTravelImage.enabled = true;
        }
        else
        {
            abandonedHouseTravelImage.enabled = false;
        }

        // czy mozliwa podroz do domu Steven

        if (tasksScript.isStevenKeyTask == true)
        {
            stevenHouseTravelImage.enabled = true;
        }
        else
        {
            stevenHouseTravelImage.enabled = false;
        }

        // czy mozliwa podroz do domu Paul

        if (tasksScript.isHutTask == true)
        {
            PaulHouseTravelImage.enabled = true;
        }
        else
        {
            PaulHouseTravelImage.enabled = false;
        }

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
