using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastTravel : MonoBehaviour {

    private PlayerManager playerManagerScript;
    public Canvas mapCanvas;
    public RectTransform resolutionRect;
    public bool isMap = false;
    private AudioSource audioSource;
    private AudioClip mapSound;
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

    void OnEnable()
    {

        playerCam = Camera.main;
        player = GameObject.Find("Player").transform;
        playerManagerScript = player.GetComponent<PlayerManager>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        scarecrowJumpscareScript = GameObject.Find("Player").GetComponent<StraszakScarecrow>();
        mapCanvas = GameObject.Find("CanvasMapa").GetComponent<Canvas>();
        resolutionRect = GameObject.Find("CanvasKomunikaty").GetComponent<RectTransform>();
        pointerRect = GameObject.Find("PointerGracz").GetComponent<RectTransform>();
        wholeMapRect = mapCanvas.GetComponent<RectTransform>();

        audioSource = GameObject.Find("ZrodloMapa_s").GetComponent<AudioSource>();
        mapCamera = GameObject.Find("MapaKamera").GetComponent<Camera>();

        cursorScript = GameObject.Find("Kamera").GetComponent<CrosshairGUI>();

        mapCamera.gameObject.SetActive(false);

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

}
