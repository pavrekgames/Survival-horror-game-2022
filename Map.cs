using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Map : MonoBehaviour {

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

    void OnEnable () {

        playerCam = Camera.main;
        player = GameObject.Find("Player").transform;
        playerManagerScript = player.GetComponent<PlayerManager>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        healthScript = GameObject.Find("Player").GetComponent<Health>();
		notesScript = GameObject.Find("Player").GetComponent<Notes>();
		gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
		inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
        tasksScript = GameObject.Find("Player").GetComponent<Tasks>();
        notificationScript = GameObject.Find("Player").GetComponent<Notifications>();
        scarecrowJumpscareScript = GameObject.Find("Player").GetComponent<StraszakScarecrow>();
        mapCanvas = GameObject.Find("CanvasMapa").GetComponent<Canvas>();
        resolutionRect = GameObject.Find("CanvasKomunikaty").GetComponent<RectTransform>();
        pointerRect = GameObject.Find("PointerGracz").GetComponent<RectTransform>();
        wholeMapRect = mapCanvas.GetComponent<RectTransform>();

        audioSource = GameObject.Find("ZrodloMapa_s").GetComponent<AudioSource>();
		//DzwMapy = Resources.Load<AudioClip>("Muzyka/Mapa");
		mapCamera = GameObject.Find("MapaKamera").GetComponent<Camera>();
		//Gui = GameObject.Find("Kamera").GetComponent<CrosshairGUI>();

        cursorScript = GameObject.Find("Kamera").GetComponent<CrosshairGUI>();

        SetPointer();

        mapCamera.gameObject.SetActive (false);

        // szybka podroz

        fastTravleCanvas = GameObject.Find("CanvasFastTravel").GetComponent<Canvas>();
        fastTravelButon = GameObject.Find("SzybkaPodrozTextButton").GetComponent<Button>();

        aliceHouseTravelImage = GameObject.Find("MiejsciePodrozyDomAlice").GetComponent<Image>();
        tomHouseTravelImage = GameObject.Find("MiejsciePodrozyDomTom").GetComponent<Image>();
        abandonedHouseTravelImage = GameObject.Find("MiejsciePodrozyDomOpuszczony").GetComponent<Image>();
        stevenHouseTravelImage = GameObject.Find("MiejsciePodrozyDomSteven").GetComponent<Image>();
        PaulHouseTravelImage = GameObject.Find("MiejsciePodrozyDomPaul").GetComponent<Image>();

        grandmaHousePoint = GameObject.Find("PunktZadaniaDomBabci").transform;
        aliceHousePoint = GameObject.Find("PunktZadaniaDomAlice").transform;
        tomHousePoint = GameObject.Find("PunktZadaniaDomTom").transform;
        abandonedHousePoint = GameObject.Find("PunktZadaniaOpuszczonyDom").transform;
        stevenHousePoint = GameObject.Find("PunktZadaniaDomSteven").transform;
        paulHousePoint = GameObject.Find("PunktZadaniaDomNaukowca").transform;

        isFastTravel = true;

    }

	void Update () {

		if(Input.GetButtonDown("Map") && isMap == false && playerManagerScript.isPlayerCanInput == true)
        {
			ShowMap ();
		}

		else if((Input.GetButtonDown("Map") || Input.GetButtonDown("Cancel")) && isMap == true)
        {
			HideMap ();
		}

    }

	void ShowMap(){
		
		mapCanvas.enabled = true;
		isMap = true;
        playerScript.enabled = false;
		Time.timeScale = 0;
		mapCamera.gameObject.SetActive(true);
		audioSource.PlayOneShot(mapSound);
        SetPointer();
        cursorScript.m_ShowCursor = true;
        Cursor.visible = true;

        if(scarecrowJumpscareScript.MonsterSzalasSchowal_ok == true && isFastTravel == true)
        {
            fastTravelButon.interactable = true;
        }else
        {
            fastTravelButon.interactable = false;
        }
        

	}

	void HideMap(){
		
		mapCanvas.enabled = false;
		isMap = false;
        playerScript.enabled = true;
        Time.timeScale = 1;
        mapCamera.gameObject.SetActive(false);
		Cursor.visible = true;
		audioSource.PlayOneShot(mapSound);
        cursorScript.m_ShowCursor = false;
        Cursor.visible = false;
        fastTravleCanvas.enabled = false;
    }

    void SetPointer()
    {

        Vector2 position = mapCamera.WorldToViewportPoint(player.transform.position);

        Vector2 mapPosition = new Vector2(
        ((position.x * resolutionRect.sizeDelta.x) - (resolutionRect.sizeDelta.x * 0.5f)),
        ((position.y * resolutionRect.sizeDelta.y) - (resolutionRect.sizeDelta.y * 0.5f)));

        pointerRect.anchoredPosition = mapPosition;

        Vector3 playerRotation = player.eulerAngles;
        playerRotation = new Vector3(0, 0, 360 - playerRotation.y);
        pointerRect.localRotation = Quaternion.Euler(playerRotation);

    }

    public void FastTravel()
    {
        fastTravleCanvas.enabled = true;
        audioSource.PlayOneShot(buttonSound);

        // czy mozliwa podroz do domu Alice

        if(tasksScript.isAliceSearchTask == true)
        {
            aliceHouseTravelImage.enabled = true;
        }else
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
        HideMap();
    }

    public void TravelToAliceHouse()
    {
        player.transform.position = new Vector3(aliceHousePoint.transform.position.x, aliceHousePoint.transform.position.y, aliceHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        HideMap();
    }

    public void TravelToTomHouse()
    {
        player.transform.position = new Vector3(tomHousePoint.transform.position.x, tomHousePoint.transform.position.y, tomHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        HideMap();
    }

    public void TravelToAbandonedHouse()
    {
        player.transform.position = new Vector3(abandonedHousePoint.transform.position.x, abandonedHousePoint.transform.position.y, abandonedHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        HideMap();
    }

    public void TravelToStevenHouse()
    {
        player.transform.position = new Vector3(stevenHousePoint.transform.position.x, stevenHousePoint.transform.position.y, stevenHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        HideMap();
    }

    public void TravelToPaulHouse()
    {
        player.transform.position = new Vector3(paulHousePoint.transform.position.x, paulHousePoint.transform.position.y, paulHousePoint.transform.position.z);
        audioSource.PlayOneShot(fastTravelSound);
        HideMap();
    }

}
