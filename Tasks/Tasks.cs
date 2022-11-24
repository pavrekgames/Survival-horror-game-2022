using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using TMPro;

public class Tasks : MonoBehaviour {

    public bool DzwiekPlay_ok = false; // wznawianie i zatrzymywanie dzwiekow

    public List<TaskData> tasksList = new List<TaskData>();
	public TextMeshProUGUI[] tasksTextMesh;
	private Inventory inventoryScript;
	private Menu gameMenuScript;
	private FactoryButton taskButtonScript;
	private Animator uiAnimator;
	public Twirl twirlScript;
	private Player playerScript;
	public Canvas axeBlackBackgroundCanvas;
	private Screamer screamerScript;
	private Notes notesScript;
	private TaskWell taskWellScript;
	private TaskBones taskBonesScript;
	private TaskTower taskTowerScript;
	private TaskWheel taskWheelScript;
	private TaskFactory taskFactoryScript;
	private Notifications notificationScript;
    private Music musicScript;
    private RandomJumpscare randomJumpscareScript;
    private GameManager gameManagerScript;
    private OpenCloseObject openCloseObjectsScript;
    private VoiceActing voiceActingScript;
    private Jumpscare jumpscareScript;
    private Compass compassScript;

	private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;

	// boole dotyczace dodawania zadan
	public bool isFirstTask = true;
	public bool isSearchTask = false;
	public bool isWoodKeyTask = false;
	public Text woodenKeyPointer;
	public Text magicWellPointer;
	public bool isMagicWellTask = false;
	public bool isWellStonesTask = false;
	public Image stonesAreaPointer;
	public bool isCassete1Task = false;
    public bool isGardenDoorTask = false;
    public Text gardenDoorPointer;
    public bool isBonesTask = false;
	public Image bonesAreaPointer;
	public bool isGoToAliceTask = false;
	public Image aliceHousePointer;
	public bool isAliceSearchTask = false;
	public bool isSimonElementTask = false;
	public Text simonElementPointer;
    public bool isWorkshopTask = false;
    public Text workshopPointer;
	public bool isBrokenKeyTask = false;
	public Text brokenKeyPointer;
	public bool isFixKeyTask = false;
	public bool isAnimalCemetaryTask = false;
    public Image animalCemetaryArrowPointer;
    public Text animalCemetaryPointer;
	public bool isVictorBrookTask = false;
	public Image victorArrowPointer;
    public Image victorArrowPointer2;
    public bool isAliceRoomTask = false;
	public bool isCornfieldTask = false;
	public Text cornfieldPointer;
	public bool isAxeTask = false;
	public Text axePointer;
	public bool isCorridorWardrobeTask = false;
	public Text corridorWardrobePointer;
	public bool isEdwardCupboardTask = false;
	public bool isCassete2Task = false;
	public Text cassete2Pointer;
	public bool isGoToTrialTask = false;
	public Text goTrailPointer;
	public bool isGoTrailTask = false;
	public Image trailArrowPointer;
	public bool isGetToTomRoadTask = false;
	public Text getToTomRoadPointer;
	public bool isTomSearchTask = false;
	public Image tomHousePointer;
	public bool isTomCornifieldTask = false;
	public Image cornfieldAreaPointer;
	public bool isCassete3Task = false;
	public bool isTompCampTask = false;
	public Text tomCampPointer;
	public bool isTomPumpkinTask = false;
	public Image pumpkinAreaPointer;
	public bool isTomChipTask = false;
	public bool isRavineTask = false; // wąwóz
	public Text ravinePointer; // wąwóz
	public bool isGoRavineTask = false;
	public Image goRavineArrowPointer;
	public bool isAbandonedSearchTask = false;
	public Image abandonedPointer;
	public bool isCassete4Task = false;
	public bool isStevenSearchTask = false;
	public Image stevenHousePointer;
	public bool isStevenKeyTask = false;
	public Image stevenKeyAreaPointer;
	public Text stevenMeatPointer;
	public bool isStevenMushroomTask = false;
	public Text stevenMushroomPointer;
	public bool isStevenPlantTask = false;
	public Text stevenPlantPointer;
	public bool isStevenSkullTask = false;
	public Text stevenSkullPointer;
	public bool isStevenAcidTask = false;
	public bool isStevenShedTask = false;
	public Text stevenShedPointer;
	public bool isStevenNoteTask = false;
	public bool isStevenBrookTask = false;
	public Text stevenBrookPointer;
	public bool isPaulSearchTask = false;
	public Image PaulHousePointer;
	public bool isPaulDoorTask = false;
	public bool isHutTask = false;
	public Text hutPointer;
	public bool isDevilsBrookTask = false;
	public Text devilsBrookPointer;
    public bool isDevilsShelterTask = false;
    public Image KryjowkaDiablyObszar;
    public bool isShelterFamilyTask = false;

    // Dodatkowe pointery

    public Text EdwardCupboardPointer;
    public Text boneShedPointer;
    public Text boneStablePointer;
    public Text toolShedPointer;
    public Text keyToiletPointer;
    public Text secretRoomPointer;

    // boole dotyczace usuwania zadan

    public bool isFirstTaskRemoved = false;
	public bool isSearchTaskRemoved = false;
	public bool isWoodKeyTaskRemoved = false;
	public bool isMagicWellTaskRemoved = false;
	public bool isWellStonesTaskRemoved = false;
	public bool isCassete1TaskRemoved = false;
    public bool isGardenDoorTaskRemoved = false;
    public bool isBonesTaskRemoved = false;
	public bool isGoToAliceTaskRemoved = false;
	public bool isAliceSearchTaskRemoved = false;
	public bool isSimonElementTaskRemoved = false;
	public bool isBrokenKeyTaskRemoved = false;
	public bool isFixKeyTaskRemoved = false;
    public bool isWorkshopTaskRemoved = false;
	public bool isAnimalCemetaryTaskRemoved = false;
	public bool isVictorBrookTaskRemoved = false;
	public bool isAliceRoomTaskRemoved = false;
	public bool isCornfieldTaskRemoved = false;
	public bool isAxeTaskRemoved = false;
	public bool isCorridorWardrobeTaskRemoved = false;
	public bool isEdwardCupboardTaskRemoved = false;
	public bool isCassete2TaskRemoved = false;
	public bool isGoToTrialTaskRemoved = false;
	public bool isGoTrailTaskRemoved = false;
	public bool isGetToTomRoadTaskRemoved = false;
	public bool isTomSearchTaskRemoved = false;
	public bool isTomCornifieldTaskRemoved = false;
	public bool isCassete3TaskRemoved = false;
	public bool isTompCampTaskRemoved = false;
	public bool isTomPumpkinTaskRemoved = false;
	public bool isTomChipTaskRemoved = false;
	public bool isRavineTaskRemoved = false;
	public bool isGoRavineTaskRemoved = false;
	public bool isAbandonedSearchTaskRemoved = false;
	public bool isCassete4TaskRemoved = false;
	public bool isStevenSearchTaskRemoved = false;
	public bool isStevenKeyTaskRemoved = false;
	public bool isStevenMushroomTaskRemoved = false;
	public bool isStevenPlantTaskRemoved = false;
	public bool isStevenSkullTaskRemoved = false;
	public bool isStevenAcidTaskRemoved = false;
	public bool isStevenShedTaskRemoved = false;
	public bool isStevenNoteTaskRemoved = false;
	public bool isStevenBrookTaskRemoved = false;
	public bool isPaulSearchTaskRemoved = false;
	public bool isPaulDoorTaskRemoved = false;
	public bool isHutTaskRemoved = false;
	public bool isDevilsBrookTaskRemoved = false;
    public bool isDevilsShelterTaskRemoved = false;
    public bool isShelterFamilyTaskRemoved = false;

    // zmienne potrzebne do rzeczy, przy wykonywaniu zadan
    private Transform gardenCollider;
	private Transform cornfieldCollider;
	private Transform stableCollider;
	private Transform corridorWardrobeCollider;
	private Transform uncleRoomCollider;
	private Transform kitchenWardrobeCollider;
	private Transform secretRoomCollider;
	private Transform planksCollider;
	private Transform toolShedCollider;
	private Transform nicheCollider;
	private Transform aliceRoomCollider;
	private Transform factoryMetalDoorCollider;
	private Transform woodenWheelCollider;
	private Transform factoryWoodenDoorCollider;
	private Transform shedCupboardCollider;
	private Transform tomRoomCollider;
	private Transform tomUpstairsCollider;
	private Transform oldWardrobeCollider;
	private Transform stevenDoorCollider;
	private Transform stevenGrille;
	private Transform paulDoorCollider;
	private Transform paulRoomDoorCollider;

	private Transform aliceHouseCollider;
	private Transform tomHouseCollider;
	private Transform tomBooksCollider;
	private Transform tomHallCollider;
	private Transform abandonedCollider;
	private Transform stevenHouseCollider;
	private Transform paulHouseCollider;
	private Transform paulBackCollider;
	private Transform hutCollider;

	private Transform stone1;
	private Transform stone2;
	private Transform stone3;
	private Transform stone4;
	private Transform stone5;

	public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource cassete1_AudioSource;
	public AudioSource cassete3_AudioSource;
	public AudioSource cassete4_AudioSource;
	public AudioSource cassete5_AudioSource;
	private VoiceActing voiceActingAudioSourceScript;
	public AudioClip keyOpenSound;
	public AudioClip keyOpenWardrobeSound;
	public AudioClip newTaskSound;
	public AudioClip oilSound;
	public AudioClip insertCasseteSound;
	public AudioClip putBatteriesSound;
	public AudioClip hallunsSound;
	public AudioClip wheelSound;
	public AudioClip crowbarOpenSound;
	public AudioClip usePliersSound;
	public AudioClip useAxeSound;
    public AudioClip useAcidSound;

	public AudioClip recording1;
	public AudioClip recording2;
	public AudioClip recording3;
	public AudioClip recording4;
	public AudioClip recording5;
	//public AudioClip GlosIdzSzlak;
	public bool isGoTrailVoice = false;

	public bool isGardenDoorLocked = true;
	public bool isCornfieldDoorLocked = true;
	public bool isStableDoorLocked = true;
	public bool isCorridorWardrobeLocked = true;
	public bool isUncleDoorLocked = true;
	public bool isKitchenWardrobeLocked = true;
	public bool isSecretRoomDoorLocked = true;
	public bool isPlanksLocked = true;
	public bool isPlanksDestroyed = false;
	public bool isToolShedDoorLocked = true;
	public bool isNicheDoorLocked = true;
	public bool isCasseteInserted = false;
	public bool isBatteriesPut = false;
	public bool isAliceRoomDoorLocked = true;
	public bool isHalluns = false;
	public bool isFactoryMetalDoorLocked = true;
	public bool isBrokenKey = false;
	public bool isWheel = false;
	public bool isFixedKey = false;
	public bool isFactoryWoodenDoorLocked = true;
	public bool isShedCupboardLocked = true;
	public bool isCassete2Inserted = false;
	public bool isTomRoomDoorLocked = true;
	public bool isTomUpstairsDoorLocked = true;
	public bool isCassete3Inserted = false;
	public bool isLackChip = false;
	public bool isChipPut = false;
	public bool isOldWardrobeLocked = true;
	public bool isCassete4Inserted = false;
	public bool isStevenDoorLocked = true;
	public bool isStevenGrille = true;
	public bool isPaulDoorLocked = true;
	public bool isCassete1Played = false;
	public bool isCassete2Played = false;
	public bool isCassete3Played = false;
	public bool isCassete4Played = false;
	public bool isCassete5Played = false;
	public bool isStevenShedLocked = false;

    // Halucynacje marihuna ogrod

	public float hallunsTimer = 0;
    private Canvas hallunsCanvas;
    private Animator hallunsAnimator;
    public bool isHallunsFlashback = false;
    private HallunsGarden hallunsScreenScript;

    // do zadania z drutem kukurydzy

    private GameObject cornfieldWire;

	// do zadania z obrazem

	private Transform tomPainting;

	// Do zadania z dynią

	public GameObject mainPumpkin;
	public GameObject pumpkinKey;
	public bool isPumpkin = false;
	public AudioClip pumpkinKeySound;
	public AudioSource pumpkinKeyAudioSource;

    // do zadania z miesem

    private Transform meat1;
    private Transform meat2;
    private Transform meat3;

    // Do zadania z labolatorium

    public bool isLabPlant = false;
	public bool isLabMushroom = false;
	public bool isLabSkull = false;
	public bool isLab = false;
	public bool isLabPot = false;
	public AudioSource labAudioSource;
	public AudioClip componentSound;
	public AudioClip potSound;
	public GameObject acid;

	// Do zniszczenia krat Stevena

	private string grilleColorString = "#0F5118";
	private Color grilleColor;
	public bool isGrilleDestroyed = false;


    // Do zniszczenia cierni

    private GameObject thorn1;
    private GameObject thorn2;
    private GameObject thorn3;
    public GameObject flame1;
    public GameObject flame2;
    public GameObject flame3;
    public bool isThornsAcid = false;
    public bool isAcid = false;
    public AudioSource flameAudioSource;
    public AudioSource fireAudioSource;
    public AudioClip flameSound;
    public AudioClip fireSound;

    // teksty do zadan

    public string beginTaskText = "# Go to your grandma's house";
    public string searchTaskText = "# Look for information about your family members";
    public string woodKeyTaskText = "# Find the key lost by Arthur" + " " + "<color=#280DF6FF>MAP</color>";
    public string magicWellTaskText = "# Look for the key next to the well in the forest" + " " + "<color=#280DF6FF>MAP</color>";
    public string wellStonesTaskText = "# Throw to the magic wooden well heavy stones to take the key" + " " + "<color=#280DF6FF>MAP</color>";
    public string casseteTaskText = "# Find the device to listen to the cassette"; 
    public string gardenDoorTaskText = "# Repair the metal door to the garden";
    public string bonesTaskText = "# Find other bones and put them on the wall finishing a word to take the key." + " " + "<color=#280DF6FF>MAP</color>";
    public string ZadanieIdzAliceT = "# Go to the Alice's House" + " " + "<color=#280DF6FF>MAP</color>";
    public string goToAliceTaskText = "# Search the Alice's farm to get information";
    public string simonElementTaskText = "# Find the missing element hidden by Simon" + " " + "<color=#280DF6FF>MAP</color>";
    public string workshopTaskText = "# Get to the Victor's workshop" + " " + "<color=#280DF6FF>MAP</color>";
    public string brokenKeyTaskText = "# Find the key to Victor's workshop" + " " + "<color=#280DF6FF>MAP</color>";
    public string fixKeyTaskText = "# Find the way to fix the key";
    public string animalCemetaryTaskText = "# Find secret Victor's cemetery" + " " + "<color=#280DF6FF>MAP</color>";
    public string victorBrookTaskText = "# Follow Victor and get the key" + " " + "<color=#280DF6FF>MAP</color>";
    public string aliceRoomTaskText = "# Get to the Alice's living room";
    public string cornfieldTaskText = "# Search the corn field" + " " + "<color=#280DF6FF>MAP</color>";
    public string axeTaskText = "# Get to the old shed" + " " + "<color=#280DF6FF>MAP</color>";
    public string corridorWardrobeTaskText = "# Open the wardrobe in corridor" + " " + "<color=#280DF6FF>MAP</color>";
    public string edwardCupboardTaskText = "# Find the key to Edward's cupboard";
    public string Cassete2TaskText = "# Listen to cassette 2" + " " + "<color=#280DF6FF>MAP</color>";
    public string goToTrialTaskText = "# Go to the place of the trail" + " " + "<color=#280DF6FF>MAP</color>";
    public string goTrailTaskText = "# Follow the trail" + " " + "<color=#280DF6FF>MAP</color>";
    public string getToTomRoadTaskText = "# Get to the other side" + " " + "<color=#280DF6FF>MAP</color>";
    public string tomSearchTaskText = "# Look for information on the Tom's farm" + " " + "<color=#280DF6FF>MAP</color>";
    public string ZadanieTomKukurydzaT = "# Search the Tom's corn field" + " " + "<color=#280DF6FF>MAP</color>";
    public string cassete3TaskText = "# Find the device to listen to the cassette";
    public string tomCampTaskText = "# Find the Tom's camp" + " " + "<color=#280DF6FF>MAP</color>";
    public string tomPumpkinTaskText = "# Find a lost pumpkin and put it on the pile" + " " + "<color=#280DF6FF>MAP</color>";
    public string tomChipTaskText = "# Find the lost chip";
    public string ravineTaskText = "# Go to the place indicated by Arthur" + " " + "<color=#280DF6FF>MAP</color>";
    public string goTrialTaskText = "# Follow the ravine" + " " + "<color=#280DF6FF>MAP</color>";
    public string abandonedSearchTaskText = "# Search the abandoned hause to find the information" + " " + "<color=#280DF6FF>MAP</color>";
    public string cassete4TaskText = "# Find the device to listen to the cassette";
    public string stevenSearchTaskText = "# Search the Steven's hause to find the information" + " " + "<color=#280DF6FF>MAP</color>";
    public string stevenKeyTaskText = "# Find the key to Steven's room" + " " + "<color=#280DF6FF>MAP</color>";
    public string stevenMushroomTaskText = "# Find the blue mushroom" + " " + "<color=#280DF6FF>MAP</color>";
    public string stevenPlantTaskText = "# Find the sharp plant" + " " + "<color=#280DF6FF>MAP</color>";
    public string stevenSkullTaskText = "# Find the skull with meat" + " " + "<color=#280DF6FF>MAP</color>";
    public string acidTaskText = "# Create acid in the laboratory";
    public string stevenShedTaskText = "# Search the Steven's shed" + " " + "<color=#280DF6FF>MAP</color>";
    public string stevenNoteTaskText = "# Get to the note by appropriate chests";
    public string stevenBrookTaskText = "# Go to the place indicated by Steven" + " " + "<color=#280DF6FF>MAP</color>";
    public string paulSearchTaskText = "# Search the Scientist's house to find information" + " " + "<color=#280DF6FF>MAP</color>";
    public string paulDoorTaskText = "# Find the key to scientist's room";
    public string hutTaskText = "# Go to the scientist's hut" + " " + "<color=#280DF6FF>MAP</color>";
    public string devilsBrookTaskText = "# Go to the Devil's brook" + " " + "<color=#280DF6FF>MAP</color>";
    public string devilsShelterTaskText = "# Find the Devil's hide" + " " + "<color=#280DF6FF>MAP</color>";
    public string endTaskText = "# Find the family members";

    // dzwi wymagajace klucza

    private Door DrzwiKukurydzaS;
    private Door DrzwiOgrodS;
    private Door DrzwiStajniaS;
    private Door DrzwiPokojTomS;
    private Door DrzwiSzopaNarzedziaS;
    private Door DrzwiPokojWS;
    private Door DrzwiFabrykaDrewnoS;
    private Door DrzwiWnekaS;
    private Door DrzwiKampingS;
    private Door DrzwiFabrykaMetalS;
    private Door DrzwiZachodS;
    private Door DrzwiSalonPoludnieS;
    private Door DrzwiTomGoraS;
    private Door DrzwiStevenS;
    private Cupboard SzafaKorytarzS;
    private Cupboard SzafaKuchniaS;
    private Cupboard SzafkaSzopaS;
    private Cupboard SzafkaSzopa2S;
    private Cupboard SzafaStaryDomS;

    // drzwi wymagajace kolidera

    private Door DrzwiDomAliceS;
    private Door DrzwiDomTomS;
    private Door DrzwiKsiazkiTomS;
    private Door DrzwiSalaTomS;
    private Door DrzwiOpuszczonyS;
    private Door DrzwiDomStevenS;
    private Door DrzwiDomPaulS;
    private Door DrzwiMonsterS;
    private Door DrzwiDomekS;


    void Start () {

    }
		
	void OnEnable(){

		playerCam = Camera.main;

		tasksTextMesh = new TextMeshProUGUI[5];
		tasksTextMesh[0] = GameObject.Find("TasksZadanie1").GetComponent<TextMeshProUGUI>();
		tasksTextMesh[1] = GameObject.Find("TasksZadanie2").GetComponent<TextMeshProUGUI>();
		tasksTextMesh[2] = GameObject.Find("TasksZadanie3").GetComponent<TextMeshProUGUI>();
		tasksTextMesh[3] = GameObject.Find("TasksZadanie4").GetComponent<TextMeshProUGUI>();
		tasksTextMesh[4] = GameObject.Find("TasksZadanie5").GetComponent<TextMeshProUGUI>();

		inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
		gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
		taskButtonScript = GameObject.Find("PrzyciskZad").GetComponent<FactoryButton>();
		uiAnimator = GameObject.Find("ZadanieKomunikat").GetComponent<Animator>();
		twirlScript = GameObject.Find("Kamera").GetComponent<Twirl>();
		playerScript = GameObject.Find("Player").GetComponent<Player>();
		axeBlackBackgroundCanvas = GameObject.Find("CanvasCzynnoscSiekiera").GetComponent<Canvas>();
		screamerScript = GameObject.Find("Player").GetComponent<Screamer>();
		notesScript = GameObject.Find("Player").GetComponent<Notes>();
		taskWellScript = GameObject.Find("StudniaTrigger").GetComponent<TaskWell>();
		taskBonesScript = GameObject.Find("KoliderKosci").GetComponent<TaskBones>();
		taskTowerScript = GameObject.Find("PalAmbona").GetComponent<TaskTower>();
		taskFactoryScript = GameObject.Find("DzwigniaZad").GetComponent<TaskFactory>();
		taskWheelScript = GameObject.Find("BrakujaceDrewnianeKolo").GetComponent<TaskWheel>();
		notificationScript = GameObject.Find("Player").GetComponent<Notifications>();
		voiceActingAudioSourceScript = GameObject.Find("Player").GetComponent<VoiceActing>();
        musicScript = GameObject.Find("Player").GetComponent<Music>();
        randomJumpscareScript = GameObject.Find("Player").GetComponent<RandomJumpscare>();
        gameManagerScript = GameObject.Find("Player").GetComponent<GameManager>();
        openCloseObjectsScript = GameObject.Find("Player").GetComponent<OpenCloseObject>();
        voiceActingScript = GameObject.Find("Player").GetComponent<VoiceActing>();
        jumpscareScript = GameObject.Find("Player").GetComponent<Jumpscare>();
        compassScript = GameObject.Find("Player").GetComponent<Compass>();


        woodenKeyPointer = GameObject.Find ("KluczDrewnoPointer").GetComponent<Text> ();
		magicWellPointer = GameObject.Find ("MagicznaStudniaPointer").GetComponent<Text> ();
        gardenDoorPointer = GameObject.Find("DrzwiOgrodPointer").GetComponent<Text>();
        simonElementPointer = GameObject.Find ("SimonElementPointer").GetComponent<Text> ();
        workshopPointer = GameObject.Find("WarsztatPointer").GetComponent<Text>();
        brokenKeyPointer = GameObject.Find ("ZepsutyKluczPointer").GetComponent<Text> ();
		animalCemetaryPointer = GameObject.Find ("CmentarzZwierzPointer").GetComponent<Text> ();
		cornfieldPointer = GameObject.Find ("KukurydzaPointer").GetComponent<Text> ();
		axePointer = GameObject.Find ("SiekieraPointer").GetComponent<Text> ();
		corridorWardrobePointer = GameObject.Find ("SzafaKorytarzPointer").GetComponent<Text> ();
		cassete2Pointer = GameObject.Find ("Kaseta2Pointer").GetComponent<Text> ();
		goTrailPointer = GameObject.Find ("IdzSzlakPointer").GetComponent<Text> ();
		getToTomRoadPointer = GameObject.Find ("PrzedostanSiePointer").GetComponent<Text> ();
		tomCampPointer = GameObject.Find ("TomObozPointer").GetComponent<Text> ();
		ravinePointer = GameObject.Find ("WawozPointer").GetComponent<Text> ();
		stevenMeatPointer = GameObject.Find ("StevenMiesoPointer").GetComponent<Text> ();
		stevenMushroomPointer = GameObject.Find ("StevenGrzybPointer").GetComponent<Text> ();
		stevenPlantPointer = GameObject.Find ("StevenRoslinaPointer").GetComponent<Text> ();
		stevenSkullPointer = GameObject.Find ("StevenCzaszkaPointer").GetComponent<Text> ();
		stevenShedPointer = GameObject.Find ("StevenSzopaPointer").GetComponent<Text> ();
		stevenBrookPointer = GameObject.Find ("StevenPotokPointer").GetComponent<Text> ();
		hutPointer = GameObject.Find ("ChatkaPointer").GetComponent<Text> ();
		devilsBrookPointer = GameObject.Find ("PotokDiablyPointer").GetComponent<Text> ();

		stonesAreaPointer = GameObject.Find ("KamienieObszar").GetComponent<Image> ();
		bonesAreaPointer = GameObject.Find ("KosciObszar").GetComponent<Image> ();
		aliceHousePointer = GameObject.Find ("DomAlicePointer").GetComponent<Image> ();
		victorArrowPointer = GameObject.Find ("StrzalkaVictorPointer").GetComponent<Image> ();
        victorArrowPointer2 = GameObject.Find("StrzalkaVictorPointer2").GetComponent<Image>();
        animalCemetaryArrowPointer = GameObject.Find("StrzalkaCmentarzZwierzPointer").GetComponent<Image>();
        trailArrowPointer = GameObject.Find ("StrzalkaSzlakPointer").GetComponent<Image> ();
		tomHousePointer = GameObject.Find ("DomTomPointer").GetComponent<Image> ();
		cornfieldAreaPointer = GameObject.Find ("KukurydzaObszar").GetComponent<Image> ();
		pumpkinAreaPointer = GameObject.Find ("DyniaObszar").GetComponent<Image> ();
		goRavineArrowPointer = GameObject.Find ("StrzalkaIdzWawoz").GetComponent<Image> ();
		abandonedPointer = GameObject.Find ("DomOpuszczonyPointer").GetComponent<Image> ();
		stevenHousePointer = GameObject.Find ("DomStevenPointer").GetComponent<Image> ();
		stevenKeyAreaPointer = GameObject.Find ("StevenKluczObszar").GetComponent<Image> ();
		PaulHousePointer = GameObject.Find ("DomNaukowcaPointer").GetComponent<Image> ();
		KryjowkaDiablyObszar = GameObject.Find ("KryjowkaDiablyObszar").GetComponent<Image> ();

        EdwardCupboardPointer = GameObject.Find("SzafkaEdwardPointer").GetComponent<Text>();
        boneShedPointer = GameObject.Find("KoscSzopaPointer").GetComponent<Text>();
        boneStablePointer = GameObject.Find("KoscStajniaPointer").GetComponent<Text>();
        toolShedPointer = GameObject.Find("SzopaNarzedziaPointer").GetComponent<Text>();
        keyToiletPointer = GameObject.Find("KluczWychodekPointer").GetComponent<Text>();
        secretRoomPointer = GameObject.Find("SekretnyPokojPointer").GetComponent<Text>();

        audioSource = GameObject.Find ("MuzykaCzynnosc").GetComponent<AudioSource> ();
		audioSource2 = GameObject.Find ("ZrodloPrzedmiot2_s").GetComponent<AudioSource> ();
		audioSource3 = GameObject.Find ("ZrodloPrzedmiot4_s").GetComponent<AudioSource> ();
        audioSource4 = GameObject.Find("ZrodloPrzedmiot3_s").GetComponent<AudioSource>();
        cassete1_AudioSource = GameObject.Find ("Odtwarzacz_s").GetComponent<AudioSource> ();
		cassete3_AudioSource = GameObject.Find ("Odtwarzacz2_s").GetComponent<AudioSource> ();
		cassete4_AudioSource = GameObject.Find ("Odtwarzacz3_s").GetComponent<AudioSource> ();
		cassete5_AudioSource = GameObject.Find ("Odtwarzacz4_s").GetComponent<AudioSource> ();

        hallunsCanvas = GameObject.Find("CanvasHalunyOgrod").GetComponent<Canvas>();
        hallunsAnimator = GameObject.Find("ObrazHalunyOgrod").GetComponent<Animator>();
        hallunsScreenScript = GameObject.Find("ObrazHalunyOgrod").GetComponent<HallunsGarden>();

        tomPainting = GameObject.Find("ObrazKapturek").transform;

		mainPumpkin = GameObject.Find("DyniaMisjaWstaw").gameObject;
		pumpkinKey = GameObject.Find("KluczTomGora").gameObject;
		//DzwKluczeDynia = Resources.Load<AudioClip>("Muzyka/KluczeDynia");
		pumpkinKeyAudioSource = GameObject.Find("DyniaDzwiek").GetComponent<AudioSource>();

		labAudioSource = GameObject.Find("Labolatorium").GetComponent<AudioSource>();
		//DzwSkladnik = Resources.Load<AudioClip>("Muzyka/LabSkladnik");
		//DzwMikstura = Resources.Load<AudioClip>("Muzyka/LabMikstura");
		flameAudioSource = GameObject.Find("Plomien_s").GetComponent<AudioSource>();
        fireAudioSource = GameObject.Find("Ogienkryjowka_s").GetComponent<AudioSource>();
        //DzwPlomien = Resources.Load<AudioClip> ("Muzyka/Ogien");

        stone1 = GameObject.Find ("KamienStudnia1").transform;
		stone2 = GameObject.Find ("KamienStudnia2").transform;
		stone3 = GameObject.Find ("KamienStudnia3").transform;
		stone4 = GameObject.Find ("KamienStudnia4").transform;
		stone5 = GameObject.Find ("KamienStudnia5").transform;

		//ZrodloDzwieku = ZrodloDzwieku.GetComponent<AudioSource>();
		gardenCollider = GameObject.Find("KoliderDrzwiOgrod").transform;
		cornfieldCollider = GameObject.Find("KoliderDrzwiKukurydza").transform;
		stableCollider = GameObject.Find("KoliderDrzwiStajnia").transform;
		corridorWardrobeCollider = GameObject.Find("KoliderSzafkaKorytarz").transform;
		uncleRoomCollider = GameObject.Find("KoliderDrzwiPokojW").transform;
		kitchenWardrobeCollider = GameObject.Find("KoliderSzafkaKuchnia").transform;
		secretRoomCollider = GameObject.Find("KoliderDrzwiKamping").transform;
		planksCollider = GameObject.Find("DeskiSzopa").transform;
		toolShedCollider = GameObject.Find("KoliderDrzwiSzopaNarzedzia").transform;
		nicheCollider = GameObject.Find("KoliderDrzwiWneka").transform;
		aliceRoomCollider = GameObject.Find("KoliderDrzwiSalonPoludnie").transform;
		factoryMetalDoorCollider = GameObject.Find("KoliderDrzwiFabrykaMetal").transform;
		woodenWheelCollider = GameObject.Find("BrakujaceDrewnianeKolo").transform;
		//DrewnianeKolo.gameObject.SetActive(false);
		factoryWoodenDoorCollider = GameObject.Find("KoliderDrzwiFabrykaDrewno").transform;
		shedCupboardCollider = GameObject.Find("KoliderSzafkaSzopa").transform;
		tomRoomCollider = GameObject.Find("KoliderDrzwiPokojTom").transform;
		tomUpstairsCollider = GameObject.Find("KoliderDrzwiTomGora").transform;
		oldWardrobeCollider = GameObject.Find("KoliderSzafaStaryDom").transform;
		stevenDoorCollider = GameObject.Find("KoliderDrzwiSteven").transform;
		stevenGrille = GameObject.Find("KratySteven").transform;
		paulDoorCollider = GameObject.Find("KoliderDrzwiZachod").transform;
		paulRoomDoorCollider = GameObject.Find("KoliderDrzwiPokojZachod").transform;
		aliceHouseCollider = GameObject.Find("KoliderDomAlice").transform;
		tomHouseCollider = GameObject.Find("KoliderDomTom").transform;
		tomBooksCollider = GameObject.Find("KoliderTomKsiazki").transform;
		tomHallCollider = GameObject.Find("KoliderTomSala").transform;
		abandonedCollider = GameObject.Find("KoliderOpuszczonyDom").transform;
		stevenHouseCollider = GameObject.Find("KoliderDomStevena").transform;
		paulHouseCollider = GameObject.Find("KoliderDomPaul").transform;
		paulBackCollider = GameObject.Find("KoliderPaulTyl").transform;
		hutCollider = GameObject.Find("KoliderChatka").transform;
		//Ciernie1 = GameObject.Find("CiernieKryjowka1").gameObject;
		//Ciernie2 = GameObject.Find("CiernieKryjowka2").gameObject;
		//Ciernie3 = GameObject.Find("CiernieKryjowka3").gameObject;
		flame1 = GameObject.Find("Plomien1").gameObject;
		flame2 = GameObject.Find("Plomien2").gameObject;
		flame3 = GameObject.Find("Plomien3").gameObject;
		flame1.SetActive(false);
		flame2.SetActive(false);
		flame3.SetActive(false);

		acid = GameObject.Find("Mikstura").gameObject;

		mainPumpkin.SetActive (false);
		ColorUtility.TryParseHtmlString (grilleColorString, out grilleColor);
        //Mikstura.SetActive (false);

        // drzwi wymagajce klucza

        DrzwiKukurydzaS = GameObject.Find("DrzwiKukurydza").GetComponent<Door>();
        DrzwiOgrodS = GameObject.Find("DrzwiOgrod").GetComponent<Door>();
        DrzwiStajniaS = GameObject.Find("DrzwiStajnia").GetComponent<Door>();
        DrzwiPokojTomS = GameObject.Find("DrzwiPokojTom").GetComponent<Door>();
        DrzwiSzopaNarzedziaS = GameObject.Find("DrzwiSzopaNarzedzia").GetComponent<Door>();
        DrzwiPokojWS = GameObject.Find("DrzwiPokojW").GetComponent<Door>();
        DrzwiFabrykaDrewnoS = GameObject.Find("DrzwiFabrykaDrewno").GetComponent<Door>();
        DrzwiWnekaS = GameObject.Find("DrzwiWneka").GetComponent<Door>();
        DrzwiKampingS = GameObject.Find("DrzwiKamping").GetComponent<Door>();
        DrzwiFabrykaMetalS = GameObject.Find("DrzwiFabrykaMetal").GetComponent<Door>();
        DrzwiZachodS = GameObject.Find("DrzwiZachod").GetComponent<Door>();
        DrzwiSalonPoludnieS = GameObject.Find("DrzwiSalonPoludnie").GetComponent<Door>();
        DrzwiTomGoraS = GameObject.Find("DrzwiTomGora").GetComponent<Door>(); 
        DrzwiStevenS = GameObject.Find("DrzwiSteven").GetComponent<Door>();
        SzafaKorytarzS = GameObject.Find("SzafaKorytarz").GetComponent<Cupboard>();
        SzafaKuchniaS = GameObject.Find("SzafaKuchnia").GetComponent<Cupboard>();
        SzafkaSzopaS = GameObject.Find("SzafkaSzopa").GetComponent<Cupboard>();
        SzafkaSzopa2S = GameObject.Find("SzafkaSzopa2").GetComponent<Cupboard>();
        SzafaStaryDomS = GameObject.Find("SzafaStaryDom").GetComponent<Cupboard>();

        // drzwi wymagajace kolidera

        DrzwiDomAliceS = GameObject.Find("DrzwiDomAlice").GetComponent<Door>();
        DrzwiDomTomS = GameObject.Find("DrzwiDomTom").GetComponent<Door>();
        DrzwiKsiazkiTomS = GameObject.Find("DrzwiKsiazkiTom").GetComponent<Door>();
        DrzwiSalaTomS = GameObject.Find("DrzwiSalaTom").GetComponent<Door>();
        DrzwiOpuszczonyS = GameObject.Find("DrzwiOpuszczony").GetComponent<Door>();
        DrzwiDomStevenS = GameObject.Find("DrzwiDomSteven").GetComponent<Door>();
        DrzwiDomPaulS = GameObject.Find("DrzwiDomPaul").GetComponent<Door>();
        DrzwiMonsterS = GameObject.Find("DrzwiMonster").GetComponent<Door>();
        DrzwiDomekS = GameObject.Find("DrzwiDomek").GetComponent<Door>();

        // drut kukurydza

        cornfieldWire = GameObject.Find("DrutKukurydza").gameObject;

        // miesa Steven klucz

        meat1 = GameObject.Find("MiesoDlaPotwora1").transform;
        meat2 = GameObject.Find("MiesoDlaPotwora2").transform;
        meat3 = GameObject.Find("MiesoDlaPotwora3").transform;

    }

    void OnDisable()
    {

        hallunsScreenScript.enabled = false;

    }

	void Update () {

	/*	playerCam = Camera.main;
		Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit; */


		//--------------ZADANIA Z INTERACKJA------------------------


		if (Input.GetMouseButtonDown (0) && inventoryScript.items.Count >= 0 && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1) {
															// tu bylo count > 0

			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {
                //Debug.Log(hit.collider.gameObject.name);
                // Otwieranie drzwi do pokoju W

                if (hit.collider.gameObject.name == "DrzwiPokojW") {
					DrzwiPokojW ();
				}

				// Otwieranie drzwi do szafki w kuchni
				else if (hit.collider.gameObject.name == "SzafaKuchnia") {
					SzafaKuchnia ();
				}

				// Otwieranie drzwi do stajni

				else if (hit.collider.gameObject.name == "DrzwiStajnia") {
					DrzwiStajnia ();
				}

				// Otwieranie drzwi do szopy

				else if (hit.collider.gameObject.name == "DrzwiSzopaNarzedzia") {
					DrzwiSzopaNarzedzia ();
				}

				// Otwieranie drzwi w ogrodzie

				else if (hit.collider.gameObject.name == "DrzwiOgrod") {
					DrzwiOgrod ();
				}

				// Otwieranie drzwi wneki

				else if (hit.collider.gameObject.name == "DrzwiWneka") {
					DrzwiWneka ();
				}

				// Otwieranie drzwi kampingu

				else if (hit.collider.gameObject.name == "DrzwiKamping") {
					DrzwiKamping ();
				}

				// Wkladanie kasety 1 

				else if (hit.collider.gameObject.name == "Odtwarzacz" && isCasseteInserted == false) {
					OdtwarzaczKaseta ();
				}

                // wkladanie baterii

                else if (hit.collider.gameObject.name == "Odtwarzacz" && isCasseteInserted == true && isBatteriesPut == false)
                {
                    
                    OdtwarzaczBateria();
                }

                // wkladanie kasety 2

                else if (hit.collider.gameObject.name == "Odtwarzacz" && isCasseteInserted == true && isCassete2Inserted == false)
                {
                    OdtwarzaczKaseta2();
                }

                // Wkladanie zepsutego klucza

                else if ((hit.collider.gameObject.name == "UrzadzenieVictora" || hit.collider.gameObject.name == "BrakujaceDrewnianeKolo") ) {
					UrzadzenieVictoraKlucz ();
				}

				// Umieszczanie drewnianego kola

				if (hit.collider.gameObject.name == "UrzadzenieVictora" && isBrokenKey == true) {
					UrzadzenieVictoraKolo ();
				}

				// Otwieranie drewnianych drzwi fabryki

				else if (hit.collider.gameObject.name == "DrzwiFabrykaDrewno") {
					DrzwiFabrykaDrewno ();
				}

				// Otwieranie metalowych drzwi fabryki

				else if (hit.collider.gameObject.name == "DrzwiFabrykaMetal") {
					DrzwiFabrykaMetal ();
				}

				// Wlaczanie przycisku

				else if (hit.collider.gameObject.name == "PrzyciskZad") {
					taskButtonScript.isButton = true;
				}

				// Otwieranie drzwi salonu na poludniu dom Alice
				else if (hit.collider.gameObject.name == "DrzwiSalonPoludnie") {
					DrzwiSalonPoludnie ();
				}

				// Otwieranie drzwi do pola kukurydzy

				else if (hit.collider.gameObject.name == "DrzwiKukurydza") {
					DrzwiKukurydza ();
				}

				// Niszczenie desek przy szopie

				else if (hit.collider.gameObject.name == "DeskiSzopa") {
					Deski ();
				}

				// Otwieranie drzwi szafy w korytarzu

				else if (hit.collider.gameObject.name == "SzafaKorytarz") {
					SzafaKorytarz ();
				}

				// Otwieranie szafki w szopie
				else if (hit.collider.gameObject.name == "SzafkaSzopa" || hit.collider.gameObject.name == "SzafkaSzopa2") {
					SzafkaSzopa ();
				}

				// Zadanie z dynia
				else if (hit.collider.gameObject.name == "PalDynia") {
					PalDynia ();
				}

				// Otwieranie drzwi do pokoju Toma na gorze

				else if (hit.collider.gameObject.name == "DrzwiTomGora") {
					DrzwiTomGora ();
				}

				// Otwieranie drzwi do pokoju Toma 

				else if (hit.collider.gameObject.name == "DrzwiPokojTom") {
					DrzwiPokojTom ();
				}

				// Wkladanie kasety 3 

				else if (hit.collider.gameObject.name == "Odtwarzacz2" && isCassete3Inserted == false) {
					Odtwarzacz2Kaseta ();
				}

                // Wkladanie chipu

                else if (hit.collider.gameObject.name == "Odtwarzacz2" && isCassete3Inserted == true && isChipPut == false)
                {
                    Odtwarzacz2Chip();
                }

                // Otwieranie szafki w opuszczonym domu

                else if (hit.collider.gameObject.name == "SzafaStaryDom") {
					SzafaStaryDom ();
				}

				// Wkladanie kasety 4

				else if (hit.collider.gameObject.name == "Odtwarzacz3") {
					Odtwarzacz3 ();
				}

				// Otwieranie drzwi w domu Stevena

				else if (hit.collider.gameObject.name == "DrzwiSteven") {
					DrzwiSteven ();
				}

				// Zniszczenie krat szopy Stevena

				else if (hit.collider.gameObject.name == "KratySteven" && isStevenGrille == true) {
					KratyStevena ();
				}
					
				// Dawanie Rosliny, Grzyba lub Czaszki do labolatorium

				else if (hit.collider.gameObject.name == "Labolatorium") {
					LaboratoriumRoslina ();
					LaboratoriumGrzyb ();
					LaboratoriumCzaszka ();
				}

				// Otwieranie drzwi w domu na zachodzie

				else if (hit.collider.gameObject.name == "DrzwiZachod") {
					DrzwiZachod ();
				}

                // Zniszczenie cierni 

                else if (hit.collider.gameObject.name == "CiernieKryjowka1_c" || hit.collider.gameObject.name == "CiernieKryjowka2_c" || hit.collider.gameObject.name == "CiernieKryjowka3_c")
                {
                    CiernieMikstura();
                }
				else if (hit.collider.gameObject.name == "ObrazKapturek") {
					tomPainting.gameObject.AddComponent<Rigidbody>();
				}


                //-------------------- Odtwarzanie kaset---------------------------------

                // kaseta 1

                if (hit.collider.gameObject.name == "Odtwarzacz" && isCasseteInserted == true && isBatteriesPut == true && isCassete1Played == false && audioSource4.isPlaying == false) {
					//ZrodloKaseta1.PlayOneShot (Nagranie1);
					isCassete1Played = true;
					cassete1_AudioSource.clip = recording1;
					cassete1_AudioSource.Play ();
                    musicScript.MuzykaMonsterPoczatekFunction();
                }

				// kaseta 2

				if (hit.collider.gameObject.name == "Odtwarzacz" && isCassete2Inserted == true && isCassete2Played == false && audioSource.isPlaying == false) {
					//ZrodloKaseta1.PlayOneShot (Nagranie2);
					isCassete2Played = true;
					cassete1_AudioSource.clip = recording2;
					cassete1_AudioSource.Play ();
				}

				// kaseta 3

				if (hit.collider.gameObject.name == "Odtwarzacz2" && isCassete3Inserted == true && isCassete3Played == false && isChipPut == true && audioSource4.isPlaying == false) { 
					//ZrodloKaseta3.PlayOneShot (Nagranie3);
					isCassete3Played = true;
					cassete3_AudioSource.clip = recording3;
					cassete3_AudioSource.Play ();
                    musicScript.MuzykaMonsterPoczatekFunction();
				}

				// kaseta 4

				if (hit.collider.gameObject.name == "Odtwarzacz3" && isCassete4Inserted == true && isCassete4Played == false && audioSource4.isPlaying == false) {
					//ZrodloKaseta4.PlayOneShot (Nagranie4);
					isCassete4Played = true;
					cassete4_AudioSource.clip = recording4;
					cassete4_AudioSource.Play ();
				}

				// kaseta 5

				if (hit.collider.gameObject.name == "Odtwarzacz4" && isCassete5Played == false) {
					//ZrodloKaseta5.PlayOneShot (Nagranie5);
					isCassete5Played = true;
					cassete5_AudioSource.clip = recording5;
					cassete5_AudioSource.Play ();
				}

				//----------------------------- Zadania glowne zalezne od fizyki------------------------------------------------

				if (hit.collider.gameObject.name == "DrzwiSalonPoludnie" && isAliceRoomTask == false && isAliceRoomTaskRemoved == false) {
					ZadanieSalonAlice ();
				}

                if (hit.collider.gameObject.name == "DrzwiFabrykaDrewno" && isWorkshopTask == false && isWorkshopTaskRemoved == false && isGoToAliceTask == true)
                {
                    ZadanieWarsztat();
                }

                if (hit.collider.gameObject.name == "DrzwiZachod" && isPaulDoorTask == false && isPaulDoorTaskRemoved == false) {
					ZadaniePaulDrzwi ();
				}

				
			} // klamra ray

		} // Klamra do warunku z przyciskiem
			

		// Halucynacje

		if(isHalluns == true && hallunsTimer < 30){
			hallunsTimer += 1 * Time.deltaTime;
		}else{
			twirlScript.enabled = false;
		}

        if(isHalluns == true && hallunsTimer > 17 && hallunsTimer < 18 && isHallunsFlashback == false)
        {
            hallunsCanvas.enabled = true;
            hallunsScreenScript.enabled = true;
            hallunsAnimator.SetTrigger("HalunyOgrod");
            isHallunsFlashback = true;
        }

		if(screamerScript.isOpenDoor == true){
			paulRoomDoorCollider.gameObject.SetActive(false);
		}

		// Wyłączenie Canvasa czynnosc czarne okno

		if(audioSource4.isPlaying == false && isPlanksDestroyed == true && Time.timeScale == 1){
			isPlanksDestroyed = false;
			axeBlackBackgroundCanvas.enabled = false;
			playerScript.enabled = true;
            audioSource4.clip = null;
            notesScript.isNotes = false;
		}

		// Zadanie labolatorium

		if(isLabMushroom == true && isLabPlant == true && isLabSkull == true && isLab == false){
            labAudioSource.clip = potSound;
            labAudioSource.Play();
			isLab = true;
            musicScript.MuzykaStevenLab();
		}

		if(labAudioSource.isPlaying == false && isLab == true && isLabPot == false && Time.timeScale == 1 && labAudioSource.clip != null){
			acid.SetActive(true);
			isLabPot = true;
		}

        // zniszczenie cierni

        if(flameAudioSource.isPlaying == false && isThornsAcid == true && isAcid == false)
        {
            ZniszczenieCierni();
        }


        // -------------------------Dodawanie zadan-------------------------------------------

        // Dodanie zadania o szukaniu informacji

		if (voiceActingAudioSourceScript.playerAudioSource2.isPlaying == false && voiceActingAudioSourceScript.isKitchenRecording == true && isSearchTask == false && Time.timeScale == 1)
        {
            ZadanieSzukajInfo();
        }


        // Dodanie zadania klucz drewno

        if (notesScript.isNote10 == true && isWoodKeyTask == false && isWoodKeyTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieKluczDrewno ();
		}

		// Dodanie zadania magiczna studnia

		if (notesScript.isNote12 == true && isMagicWellTask == false && isMagicWellTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieMagicznaStudnia ();
		}

		// Dodanie zadania kamienie studnia

		if (notesScript.isNote13 == true && isWellStonesTask == false && isWellStonesTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieKamienieStudnia ();
		}

		// Dodanie zadania kaseta 1 

		if (inventoryScript.isCassete1Taken == true && isCassete1Task == false && isCassete1TaskRemoved == false) {
			ZadanieKaseta1 ();
		}

		// Dodanie zadania idz Alice

		if (voiceActingScript.playerAudioSource1.isPlaying == false && voiceActingScript.isSecretRoomRecording == true && isGoToAliceTask == false && isGoToAliceTaskRemoved == false && Time.timeScale == 1) { // bylo ZrodloKaseta1.isPlaying == false && Kaseta1Odtworzona == true
			ZadanieIdzAlice ();
            RemoveSekretnyPokojPointer();
        } 

		// Dodanie zadania Simon Element

		if (notesScript.isNote16 == true && isSimonElementTask == false && isSimonElementTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieSimonElement ();
		}

		// Dodanie zadania zepsuty klucz

		if (notesScript.isNote19 == true && isBrokenKeyTask == false && isBrokenKeyTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieZepsutyKlucz ();
		}

		// dodanie zadania napraw klucz

		if (inventoryScript.isBrokenFactoryKeyTaken == true && isFixKeyTask == false && isFixKeyTaskRemoved == false) {
			ZadanieNaprawKlucz ();
		}

		// dodanie zadania cmentarz zwierzat

		if (notesScript.isNote23 == true && isAnimalCemetaryTask == false && isAnimalCemetaryTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieCmentarzZwierz ();
		}

		// dodanie zadania victor potok

		if (notesScript.isNote24 == true && isVictorBrookTask == false && isVictorBrookTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieVictorPotok ();
		}

		// dodanie zadania kukurydza

		if (voiceActingAudioSourceScript.playerAudioSource3.isPlaying == false && inventoryScript.isPliersTaken == true && isCornfieldTask == false && isCornfieldTaskRemoved == false && Time.timeScale == 1) {
			ZadanieKukurydza ();
		}

		// dodanie zadania siekiera

		if (voiceActingAudioSourceScript.playerAudioSource3.isPlaying == false && inventoryScript.isAxeTaken == true && isAxeTask == false && isAxeTaskRemoved == false && Time.timeScale == 1) {
			ZadanieSiekiera ();
		}

		// dodanie zadania szafa korytarz

		if (voiceActingScript.playerAudioSource2.isPlaying == false && voiceActingScript.isWardrobeCorridorRecording == true && isCorridorWardrobeTask == false && isCorridorWardrobeTaskRemoved == false) { // bylo Inventory.KluczSzafaKorytarz_ok == true 
			ZadanieSzafaKorytarz ();
		}

		// dodanie zadania szafka edwarda

		if (notesScript.isNote27 == true && isEdwardCupboardTask == false && isEdwardCupboardTaskRemoved == false && notesScript.isNotes == false && isCassete2Task == false && Input.GetMouseButtonDown(0) )  {
			ZadanieSzafkaEdward ();
		}

		// Dodanie zadania kaseta 2

		if (inventoryScript.isCassete2Taken == true && isCassete2Task == false && isCassete2TaskRemoved == false) {
			ZadanieKaseta2 ();
		}

		// Dodanie zadania idz szlak

		if (cassete1_AudioSource.isPlaying == false && isCassete2Played == true && isGoTrailVoice == false && isGoToTrialTask == false && isGoToTrialTaskRemoved == false && Time.timeScale == 1) {
			isGoTrailVoice = true;
			voiceActingAudioSourceScript.GlosNagranie();
		} 

		if (voiceActingAudioSourceScript.playerAudioSource2.isPlaying == false && isGoTrailVoice == true && isGoToTrialTask == false && isGoToTrialTaskRemoved == false) {
			ZadanieIdzSzlak ();
		}
			
		// dodanie zadania tom kukurydza

		if (notesScript.isNote31 == true && isTomCornifieldTask == false && isTomCornifieldTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieTomKukurydza ();
		}

		// Dodanie zadania kaseta 3

		if (inventoryScript.isCassete3Taken == true && isCassete3Task == false && isCassete3TaskRemoved == false) {
			ZadanieKaseta3 ();
		}

		// Dodanie zadania Tom oboz

		if (notesScript.isNote33 == true && isTompCampTask == false && isTompCampTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieTomOboz ();
		}

		// Dodanie zadania Tom dynia

		if (notesScript.isNote34 == true && isTomPumpkinTask == false && isTomPumpkinTaskRemoved == false && isTompCampTask == true && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieTomDynia ();
		}

		// Dodanie zadania Chip

		if (notificationScript.audioSource.isPlaying == false && isLackChip == false && notificationScript.isChipNotification == true && isTomChipTask == false && isTomChipTaskRemoved == false && Time.timeScale == 1) {  
			ZadanieTomChip ();
		}

		// Dodanie zadania wąwóz

		if (cassete3_AudioSource.isPlaying == false && isCassete3Played == true && isRavineTask == false && isRavineTaskRemoved == false && Time.timeScale == 1) {
			ZadanieWawoz ();
		}

        // Dodanie zadania idz wawoz

		if (voiceActingAudioSourceScript.playerAudioSource2.isPlaying == false && isGoRavineTask == false && isGoRavineTaskRemoved == false && isRavineTask == true && voiceActingAudioSourceScript.isRavineRecording == true && Time.timeScale == 1)
        {
            ZadanieIdzWawoz();
        }

        // Dodanie zadania opuszczony dom

        if (notesScript.isNote36 == true && isAbandonedSearchTask == false && isAbandonedSearchTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieOpuszczonyInfo ();
		}

		// Dodanie zadania kaseta 4

		if (inventoryScript.isCassete4Taken == true && isCassete4Task == false && isCassete4TaskRemoved == false) {
			ZadanieKaseta4 ();
		}

		// Dodanie zadania Steven info

		if (cassete4_AudioSource.isPlaying == false && isCassete4Played == true && isStevenSearchTask == false && isStevenSearchTaskRemoved == false && Time.timeScale == 1) {
			ZadanieStevenInfo ();
		} 

		// Dodanie zadania Steven klucz

		if (notesScript.isNote41 == true && isStevenKeyTask == false && isStevenKeyTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieStevenKlucz ();
		}

		// Dodanie zadania Steven grzyb

		if (notesScript.isNote44 == true && isStevenMushroomTask == false && isStevenMushroomTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieStevenGrzyb ();
		}

		// Dodanie zadania Steven roslina

		if (notesScript.isNote44 == true && isStevenPlantTask == false && isStevenPlantTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieStevenRoslina ();
		}

		// Dodanie zadania Steven czaszka

		if (notesScript.isNote44 == true && isStevenSkullTask == false && isStevenSkullTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieStevenCzaszka ();
		}

		// Ddoanie zadania kwas

		if (inventoryScript.isLabMushroomTaken == true && inventoryScript.isLabPlantTaken == true && inventoryScript.isLabSkullTaken == true && isStevenAcidTask == false && isStevenAcidTaskRemoved == false) {
			ZadanieKwas ();
		}

		// dodanie zadania Steven szopa

		if (voiceActingAudioSourceScript.playerAudioSource2.isPlaying == false && inventoryScript.isStrongAcidTaken == true && isStevenShedTask == false && isStevenShedTaskRemoved == false) {
			ZadanieStevenSzopa ();
		}

		// Dodanie zadania Steven potok

		if (notesScript.isNote45 == true && isStevenBrookTask == false && isStevenBrookTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieStevenPotok ();
		}

        // Dodanie zadania Paul info

		if (voiceActingAudioSourceScript.playerAudioSource2.isPlaying == false && isPaulSearchTask == false && isPaulSearchTaskRemoved == false && voiceActingAudioSourceScript.isDevilsBrookRecording == true && isStevenBrookTask == true && Time.timeScale == 1)
        {  
            ZadaniePaulInfo();
        }

        // Dodanie zadania chatka

        if (notesScript.isNote53 == true && isHutTask == false && isHutTaskRemoved == false && notesScript.isNotes == false && Input.GetMouseButtonDown(0)) {
			ZadanieChatka ();
		}

		// Dodanie zadania diably

		if (cassete5_AudioSource.isPlaying == false && isCassete5Played == true && isDevilsBrookTask == false && isDevilsBrookTaskRemoved == false && Time.timeScale == 1) {
			ZadaniePotokDiably ();
		} 

		// -------------------------Usuwanie zadan--------------------------------------------

		if (inventoryScript.isKeyV4Taken == true && isWoodKeyTaskRemoved == false) {
			ZadanieKluczDrewnoUsun ();
		}

		if (inventoryScript.isKeyV3Taken == true && isWellStonesTaskRemoved == false) {
			ZadanieKamienieStudniaUsun ();
		}

        if (isGardenDoorLocked == false && isGardenDoorTaskRemoved == false)
        {
            ZadanieDrzwiOgrodUsun();
        }

		if (inventoryScript.isSecretRoomKeyTaken == true && isBonesTaskRemoved == false) {
			ZadanieKosciUsun ();
		}

		if (inventoryScript.isWoodenWheelTaken == true && isSimonElementTaskRemoved == false) {
			ZadanieSimonElementUsun ();
		}

		if (inventoryScript.isFixedKeyTaken == true && isFixKeyTaskRemoved == false) {
			ZadanieNaprawKluczUsun ();
		}

        if (isFactoryWoodenDoorLocked == false && isWorkshopTaskRemoved == false)
        {
            ZadanieWarsztatUsun();
        }

        if (inventoryScript.isAliceKeyTaken == true && isVictorBrookTaskRemoved == false) {
			ZadanieVictorPotokUsun ();
		}

		if (isAliceRoomDoorLocked == false && isAliceRoomTaskRemoved == false) {
			ZadanieSalonAliceUsun ();
		}

        if(inventoryScript.isShedCupboardKeyTaken == true && isCorridorWardrobeTaskRemoved == false)
        {
            ZadanieSzafaKorytarzUsun();
        }

		if (inventoryScript.isTomUpstairsKeyTaken == true && isTomPumpkinTaskRemoved == false) {
			ZadanieTomDyniaUsun ();
		}

		if (isChipPut == true && isTomChipTaskRemoved == false) {
			ZadanieTomChipUsun ();
		}

        if(inventoryScript.isStevenKeyTaken == true && isStevenKeyTaskRemoved == false)
        {
            ZadanieStevenKluczUsun();
        }

        if(inventoryScript.isLabMushroomTaken == true && isStevenMushroomTaskRemoved == false)
        {
            ZadanieStevenGrzybUsun();
        }

        if (inventoryScript.isLabPlantTaken == true && isStevenPlantTaskRemoved == false)
        {
            ZadanieStevenRoslinaUsun();
        }

        if (inventoryScript.isLabSkullTaken && isStevenSkullTaskRemoved == false)
        {
            ZadanieStevenCzaszkaUsun();
        }

        if ( isPaulDoorLocked == false && isPaulDoorTaskRemoved == false)
        {
            ZadaniePaulDrzwiUsun();
        }

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && DzwiekPlay_ok == false)
        {

            audioSource.Pause();
            audioSource2.Pause();
            audioSource3.Pause();
            audioSource4.Pause();
            pumpkinKeyAudioSource.Pause();
            labAudioSource.Pause();
            flameAudioSource.Pause();
            labAudioSource.Pause();
            fireAudioSource.Pause();

            DzwiekPlay_ok = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && DzwiekPlay_ok == true)
        {

            audioSource.UnPause();
            audioSource2.UnPause();
            audioSource3.UnPause();
            audioSource4.UnPause();
            pumpkinKeyAudioSource.UnPause();
            labAudioSource.UnPause();
            flameAudioSource.UnPause();
            labAudioSource.UnPause();
            fireAudioSource.UnPause();

            DzwiekPlay_ok = false;
        }


    } // klamra Update


	void OnTriggerExit(Collider other){

		// Dodanie zadania o zebraniu kosci

		if(other.gameObject.CompareTag("ZadanieKosci_trigger") && isBonesTask == false){
			ZadanieKosci ();
		}

		// Dodanie zadania o informcji Alice

		else if(other.gameObject.CompareTag("ZadanieAliceInfo_trigger") && isAliceSearchTask == false && isGoToAliceTask == true){
			ZadanieAliceInfo ();
		}

		// Wywolanie halucynacji

		else if(other.gameObject.CompareTag("Halucynacje_trigger") && isHalluns == false && isSimonElementTask == true){
			HalucynacjeWywolanie ();
		}

		// Dodanie zadania przedostan sie

		else if(other.gameObject.CompareTag("PrzedostanSie_trigger") && isGetToTomRoadTask == false && isGetToTomRoadTaskRemoved == false && isGoTrailTask == true){
			ZadaniePrzedostanSie ();
		}


	 /*	// Dodanie zadania o zebraniu kosci

		if(other.gameObject.GetComponent<Collider>().gameObject.name == "ZadanieKosci_trigger" && ZadanieKosci_ok == false){
			ZadanieKosci ();
		}

		// Dodanie zadania o informcji Alice

		if(other.gameObject.GetComponent<Collider>().gameObject.name == "ZadanieAliceInfo_trigger" && ZadanieAliceInfo_ok == false){
			ZadanieAliceInfo ();
		}

		// Wywolanie halucynacji

		if(other.gameObject.GetComponent<Collider>().gameObject.name == "Halucynacje_trigger" && Halucynacje_ok == false && ZadanieSimonElement_ok == true){
			HalucynacjeWywolanie ();
		}

		// Dodanie zadania kieruj szlak

		if(other.gameObject.GetComponent<Collider>().gameObject.name == "KierujSzlak_trigger" && ZadanieKierujSzlak_ok == false && ZadanieKierujSzlak_Usun == false && ZadanieIdzSzlak_ok == true){
			ZadanieKierujSzlak ();
		}

		// Dodanie zadania przedostan sie

		if(other.gameObject.GetComponent<Collider>().gameObject.name == "PrzedostanSie_trigger" && ZadaniePrzedostanSie_ok == false && ZadaniePrzedostanSie_Usun == false && ZadanieKierujSzlak_ok == true){
			ZadaniePrzedostanSie ();
		} */


	} // klamra do Exit

	void OnTriggerEnter(Collider other){
	

		// Dodanie zadania kieruj szlak

		if(other.gameObject.CompareTag("IdzWawoz_trigger") && isGoTrailTask == false && isGoTrailTaskRemoved == false && isGoToTrialTask == true){
			ZadanieKierujSzlak ();
		}

		// Dodanie zadania Tom info

		else if(other.gameObject.CompareTag("TomInfo_trigger") && isTomSearchTask == false && isTomSearchTaskRemoved == false && isGetToTomRoadTask == true){
			ZadanieTomInfo ();
		}

		// Dodanie zadania Steven notatka

		else if(other.gameObject.CompareTag("StevenNotatka_trigger") && isStevenNoteTask == false && isStevenNoteTaskRemoved == false && isStevenShedTask == true){
			ZadanieStevenNotatka ();
		}

		// Atak potworow

		else if(other.gameObject.CompareTag("StevenNotatka_trigger") && notesScript.isNote45 == true && isStevenShedLocked == false){
			isStevenShedLocked = true;
		}

        // Dodanie zadania kryjowka diably

		else if (other.gameObject.CompareTag("KryjowkaDiably_trigger") && isDevilsShelterTask == false && isDevilsShelterTaskRemoved == false && isDevilsBrookTask == true)
        {
            ZadanieKryjowkaDiably();
        }

        // Dodanie zadania kryjowka rodzina

		else if (other.gameObject.CompareTag("KryjowkaDiablow_trigger") && isShelterFamilyTask == false && isShelterFamilyTaskRemoved == false && isDevilsShelterTask == true)
        {
            ZadanieKryjowkaRodzina();
        }



	/*	// Dodanie zadania Tom info

		if(other.gameObject.GetComponent<Collider>().gameObject.name == "TomInfo_trigger" && ZadanieTomInfo_ok == false && ZadanieTomInfo_Usun == false && ZadaniePrzedostanSie_ok == true){
			ZadanieTomInfo ();
		}

		// Dodanie zadania Steven notatka

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "StevenNotatka_trigger" && ZadanieStevenNotatka_ok == false && ZadanieStevenNotatka_Usun == false && ZadanieStevenSzopa_ok == true){
			ZadanieStevenNotatka ();
		}

		// Atak potworow

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "StevenNotatka_trigger" && Notes.Notatka45_ok == true && SzopaStevenMonster_ok == false){
			SzopaStevenMonster_ok = true;
		}

		// Dodanie zadania kryjowka diably

		else if (other.gameObject.GetComponent<Collider>().gameObject.name == "KryjowkaDiably_trigger" && ZadanieKryjowkaDiably_ok == false && ZadanieKryjowkaDiably_Usun == false && ZadaniePotokDiably_ok == true)
		{
			ZadanieKryjowkaDiably();
		}

		// Dodanie zadania kryjowka rodzina

		else if (other.gameObject.GetComponent<Collider>().gameObject.name == "KryjowkaDiablow_trigger" && ZadanieKryjowkaRodzina_ok == false && ZadanieKryjowkaRodzina_Usun == false && ZadanieKryjowkaDiably_ok == true)
		{
			ZadanieKryjowkaRodzina();
		} */

    }


	//--------------ZADANIA Z INTERACKJA------------------------


	void DrzwiPokojW(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczPokojW" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                uncleRoomCollider.gameObject.SetActive(false);
				isUncleDoorLocked = false;
                DrzwiPokojWS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void SzafaKuchnia(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczSzafkaKuchnia" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeySzafaOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenWardrobeSound;
                audioSource4.Play();
                kitchenWardrobeCollider.gameObject.SetActive(false);
				isKitchenWardrobeLocked = false;
                SzafaKuchniaS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void DrzwiStajnia(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczStajnia" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                stableCollider.gameObject.SetActive(false);
				isStableDoorLocked = false;
                DrzwiStajniaS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void DrzwiSzopaNarzedzia(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczSzopa" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                toolShedCollider.gameObject.SetActive(false);
				isToolShedDoorLocked = false;
                DrzwiSzopaNarzedziaS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}

        RemoveSzopaNarzedziaPointer();

	}

	void DrzwiOgrod(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Oliwa" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku3.PlayOneShot(DzwOliwa);
                openCloseObjectsScript.enabled = false;
                audioSource3.clip = oilSound;
                audioSource3.Play();
                gardenCollider.gameObject.SetActive(false);
				isGardenDoorLocked = false;
                DrzwiOgrodS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void DrzwiWneka(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczWneka" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                nicheCollider.gameObject.SetActive(false);
				isNicheDoorLocked = false;
                DrzwiWnekaS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void DrzwiKamping(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczKamping" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                secretRoomCollider.gameObject.SetActive(false);
				isSecretRoomDoorLocked = false;
                DrzwiKampingS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void OdtwarzaczKaseta(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Kaseta1" && inventoryScript.items[i].isUsed == true){
                audioSource2.PlayOneShot(insertCasseteSound);
                isCasseteInserted = true;
				break;
			}
		}
	}

	void OdtwarzaczBateria(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Baterie" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwBaterieWloz);
                audioSource3.clip = putBatteriesSound;
                audioSource3.Play();
                isBatteriesPut = true;
				break;
			}
		}

        //RemoveSekretnyPokojPointer();

	}

	void UrzadzenieVictoraKlucz(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczFabryka" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwBaterieWloz);
                audioSource4.clip = putBatteriesSound;
                audioSource4.Play();
                isBrokenKey = true;
				break;
			}
		}
	}

	void UrzadzenieVictoraKolo(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "DrewnianeKolo" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKolo);
                audioSource4.clip = wheelSound;
                audioSource4.Play();
                isWheel = true;
				woodenWheelCollider.gameObject.SetActive(true);
				break;
			}
		}
	}

	void DrzwiFabrykaDrewno(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "FixedKey" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                factoryWoodenDoorCollider.gameObject.SetActive(false);
				isFactoryWoodenDoorLocked = false;
				taskFactoryScript.enabled = true;
                DrzwiFabrykaDrewnoS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void DrzwiFabrykaMetal(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Lom" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwLomOtworz);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = crowbarOpenSound;
                audioSource4.Play();
                factoryMetalDoorCollider.gameObject.SetActive(false);
				isFactoryMetalDoorLocked = false;
                DrzwiFabrykaMetalS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void DrzwiSalonPoludnie(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczSalonPoludnie" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                aliceRoomCollider.gameObject.SetActive(false);
				isAliceRoomDoorLocked = false;
                DrzwiSalonPoludnieS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void DrzwiKukurydza(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Kombinerki" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKombinerki);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = usePliersSound;
                audioSource4.Play();
                cornfieldCollider.gameObject.SetActive(false);
                cornfieldWire.SetActive(false);
				isCornfieldDoorLocked = false;
                DrzwiKukurydzaS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void Deski(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Siekiera" && inventoryScript.items[i].isUsed == true){
				axeBlackBackgroundCanvas.enabled = true;
				playerScript.enabled = false;
                //ZrodloDzwieku.PlayOneShot(DzwSiekieraUzyj);
                audioSource4.clip = useAxeSound;
                audioSource4.Play();
                planksCollider.gameObject.SetActive(false);
				isPlanksLocked = false;
				isPlanksDestroyed = true;
                notesScript.isNotes = true;
				break;
			}
		}
	}

	void SzafaKorytarz(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczSzafaKorytarz" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                corridorWardrobeCollider.gameObject.SetActive(false);
				isCorridorWardrobeLocked = false;
                SzafaKorytarzS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void SzafkaSzopa(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczSzafkaSzopa" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                shedCupboardCollider.gameObject.SetActive(false);
				isShedCupboardLocked = false;
                DrzwiKukurydzaS.isNeedKey = false;
                SzafkaSzopaS.isNeedKey = false;
                SzafkaSzopa2S.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void OdtwarzaczKaseta2(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Kaseta2" && inventoryScript.items[i].isUsed == true){
				audioSource.PlayOneShot(insertCasseteSound);
				isCassete2Inserted = true;
				break;
			}
		}
	}

	void PalDynia(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Dynia" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKolo);
                audioSource4.clip = wheelSound;
                audioSource4.Play();
                //ZrodloDzwKluczeDynia.PlayOneShot(DzwKluczeDynia);
                pumpkinKeyAudioSource.clip = pumpkinKeySound;
                pumpkinKeyAudioSource.Play();
                mainPumpkin.SetActive(true);
				pumpkinKey.SetActive(true);
				isPumpkin = true;
				break;
			}
		}
	}

	void DrzwiTomGora(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczTomGora" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                tomUpstairsCollider.gameObject.SetActive(false);
				isTomUpstairsDoorLocked = false;
                DrzwiTomGoraS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void DrzwiPokojTom(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczPokojTom" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                tomRoomCollider.gameObject.SetActive(false);
				isTomRoomDoorLocked = false;
                DrzwiPokojTomS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void Odtwarzacz2Kaseta(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Kaseta3" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKasetaWloz);
                audioSource4.clip = insertCasseteSound;
                audioSource4.Play();
                isCassete3Inserted = true;
				break;
			}
		}
	}

	void Odtwarzacz2Chip(){

		if(isTomChipTask == true){

		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Chip" && inventoryScript.items[i].isUsed == true){
				//ZrodloDzwieku.PlayOneShot(DzwBaterieWloz);
                audioSource4.clip = putBatteriesSound;
                audioSource4.Play();
				isChipPut = true;
				break;
			}
		}
	}

	}

	void SzafaStaryDom(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczStaryDom" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                oldWardrobeCollider.gameObject.SetActive(false);
				isOldWardrobeLocked = false;
                SzafaStaryDomS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void Odtwarzacz3(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Kaseta4" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKasetaWloz);
                audioSource4.clip = insertCasseteSound;
                audioSource4.Play();
                isCassete4Inserted = true;
				break;
			}
		}
	}

	void DrzwiSteven(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczSteven" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                stevenDoorCollider.gameObject.SetActive(false);
				isStevenDoorLocked = false;
                DrzwiStevenS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void LaboratoriumRoslina(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "RoslinaLab" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwSkladnik);
                audioSource3.clip = componentSound;
                audioSource3.Play();
                isLabPlant = true;
				break;
			}
		}
	}

	void LaboratoriumGrzyb(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "GrzybLab" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwSkladnik);
                audioSource3.clip = componentSound;
                audioSource3.Play();
                isLabMushroom = true;
				break;
			}
		}
	}

	void LaboratoriumCzaszka(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "CzaszkaLab" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwSkladnik);
                audioSource3.clip = componentSound;
                audioSource3.Play();
                isLabSkull = true;
				break;
			}
		}
	}

	void KratyStevena(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "Mikstura" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku2.PlayOneShot(DzwOliwa);
                audioSource3.clip = useAcidSound;
                audioSource3.Play();
                //KratySteven.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                //KratySteven.GetComponent<Renderer>().material.SetColor("_EmissionColor", KolorKraty);
                stevenGrille.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
				isStevenGrille = false;
				stevenGrille.gameObject.AddComponent<Rigidbody> ();
				break;
			}
		}
	}

	void DrzwiZachod(){
		for(int i=0; i<inventoryScript.items.Count; i++){
			if(inventoryScript.items[i].type == "KluczPokojZachod" && inventoryScript.items[i].isUsed == true){
                //ZrodloDzwieku.PlayOneShot(DzwKeyOpen);
                openCloseObjectsScript.enabled = false;
                audioSource4.clip = keyOpenSound;
                audioSource4.Play();
                paulDoorCollider.gameObject.SetActive(false);
				isPaulDoorLocked = false;
                DrzwiZachodS.isNeedKey = false;
                openCloseObjectsScript.enabled = true;
                break;
			}
		}
	}

	void HalucynacjeWywolanie(){
        //ZrodloDzwieku3.PlayOneShot(DzwHalucynacje);
        audioSource3.clip = hallunsSound;
        audioSource3.Play();
        twirlScript.enabled = true;
		isHalluns = true;
	}

    void CiernieMikstura()
    {
        for (int i = 0; i < inventoryScript.items.Count; i++)
        {
            if (inventoryScript.items[i].type == "Mikstura" && inventoryScript.items[i].isUsed == true)
            {
                // ZrodloDzwPlomien.PlayOneShot(DzwPlomien);
                flameAudioSource.clip = flameSound;
                flameAudioSource.Play();
                fireAudioSource.clip = fireSound;
                fireAudioSource.Play();
                flame1.SetActive(true);
                flame2.SetActive(true);
                flame3.SetActive(true);
                isThornsAcid = true;
                break;
            }
        }
    }

    void ZniszczenieCierni()
    {
		thorn1 = GameObject.Find("CiernieKryjowka1").gameObject;
		thorn2 = GameObject.Find("CiernieKryjowka2").gameObject;
		thorn3 = GameObject.Find ("CiernieKryjowka3").gameObject;
        thorn1.SetActive(false);
        thorn2.SetActive(false);
        thorn3.SetActive(false);
        flame1.SetActive(false);
       // Plomien2.SetActive(false);
       // Plomien3.SetActive(false);
        isAcid = true;
    }


	//-------------------Zadania Glowne ----------------------

	 public void ZadaniePoczatek(){
		for(int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadaniePoczatek", beginTaskText));
                tasksTextMesh[i].text = beginTaskText;
				isFirstTask = true;
				break;
			}
		}
	}

	void ZadanieSzukajInfo(){

		tasksList.RemoveAll (x => x.title == "ZadaniePoczatek");
		isFirstTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        /*	for (int i = 0; i <= ZadanieText.Length; i++) {
                if (ZadanieText[i].text == ZadaniePoczatekT) {
                    ZadanieText[i].text = "";
                    break;
                }
            } */


        isSearchTask = true;
		uiAnimator.SetTrigger("NoweZadanie");

        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        //ListaZadan.RemoveAt(0);
        //ZadanieText[0].text = "";
        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieSzukajInfo", searchTaskText));
                tasksTextMesh[i].text = searchTaskText;
                for(int j=0; j<tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

	}

	void ZadanieKluczDrewno(){
		isWoodKeyTask = true;
		inventoryScript.keyV4.gameObject.SetActive (true);
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        gameManagerScript.MonsterLosowy.gameObject.SetActive(true);
        gameManagerScript.MonsterLosowy2.gameObject.SetActive(true);
        gameManagerScript.MonsterLosowy3.gameObject.SetActive(true);
        randomJumpscareScript.enabled = true;
        compassScript.AddTaskPoint(compassScript.keyWoodPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKluczDrewno", woodKeyTaskText));
                tasksTextMesh[i].text = woodKeyTaskText;
				woodenKeyPointer.enabled = true;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieMagicznaStudnia(){
		isMagicWellTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        notesScript.notes [12].gameObject.SetActive (true);
        compassScript.AddTaskPoint(compassScript.magicWellPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieMagicznaStudnia", magicWellTaskText));
                tasksTextMesh[i].text = magicWellTaskText;
				magicWellPointer.enabled = true;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieKamienieStudnia(){

		tasksList.RemoveAll (x => x.title == "ZadanieMagicznaStudnia");
		isMagicWellTaskRemoved = true;
        //MagicznaStudniaPointer.enabled = false;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        jumpscareScript.Wilk1Function();

		isWellStonesTask = true;
		stone1.gameObject.SetActive (true);
		stone2.gameObject.SetActive (true);
		stone3.gameObject.SetActive (true);
		stone4.gameObject.SetActive (true);
		stone5.gameObject.SetActive (true);
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        taskWellScript.enabled = true;
		//MagicznaStudniaPointer.enabled = false;
		for(int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKamienieStudnia", wellStonesTaskText));
                tasksTextMesh[i].text = wellStonesTaskText;
				stonesAreaPointer.enabled = true;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieKaseta1(){
		isCassete1Task = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKaseta1", casseteTaskText));
                tasksTextMesh[i].text = casseteTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

    public void ZadanieDrzwiOgrod()
    {
        isGardenDoorTask = true;
        uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        gardenDoorPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.gardenDoorPoint);

        for (int i = 0; i < tasksTextMesh.Length; i++)
        {
            if (tasksTextMesh[i].text.Length == 0)
            {
                tasksList.Add(new TaskData("ZadanieDrzwiOgrod", gardenDoorTaskText));
                tasksTextMesh[i].text = gardenDoorTaskText;
                break;
            }
        }

        notificationScript.KomunikatZadanieWskazowka();

    }

    void ZadanieKosci(){
		isBonesTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        taskBonesScript.enabled = true;
		bonesAreaPointer.enabled = true;

		for(int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKosci", bonesTaskText));
                tasksTextMesh[i].text = bonesTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieIdzAlice(){

		tasksList.RemoveAll (x => x.title == "ZadanieKaseta1");
		tasksList.RemoveAll (x => x.title == "ZadanieSzukajInfo");
		isCassete1TaskRemoved = true;
		isSearchTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isGoToAliceTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        aliceHousePointer.enabled = true;
		aliceHouseCollider.gameObject.SetActive (false);
        DrzwiDomAliceS.isNeedKey = false;
        compassScript.AddTaskPoint(compassScript.aliceHousePoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieIdzAlice", ZadanieIdzAliceT));
                tasksTextMesh[i].text = ZadanieIdzAliceT;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieAliceInfo(){
		isAliceSearchTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        notesScript.notes [19].gameObject.SetActive (true);

		tasksList.RemoveAll (x => x.title == "ZadanieIdzAlice");
		isGoToAliceTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		for(int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieAliceInfo", goToAliceTaskText));
                tasksTextMesh[i].text = goToAliceTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieSimonElement(){
		isSimonElementTask = true;
		inventoryScript.woodenWheel.gameObject.SetActive (true);
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        simonElementPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.simonElementPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieSimonElement", simonElementTaskText));
                tasksTextMesh[i].text = simonElementTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

  public void ZadanieWarsztat()
    {
        isWorkshopTask = true;
        uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        workshopPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.workshopPoint);

        for (int i = 0; i < tasksTextMesh.Length; i++)
        {
            if (tasksTextMesh[i].text.Length == 0)
            {
                tasksList.Add(new TaskData("ZadanieWarsztat", workshopTaskText));
                tasksTextMesh[i].text = workshopTaskText;
                break;
            }
        }

        notificationScript.KomunikatZadanieWskazowka();

    }

    void ZadanieZepsutyKlucz(){
		isBrokenKeyTask = true;
		inventoryScript.brokenFactoryKey.gameObject.SetActive (true);
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        taskTowerScript.enabled = true;
		brokenKeyPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.brokenKeyPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieZepsutyKlucz", brokenKeyTaskText));
                tasksTextMesh[i].text = brokenKeyTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieNaprawKlucz(){

		tasksList.RemoveAll (x => x.title == "ZadanieZepsutyKlucz");
		isBrokenKeyTaskRemoved = true;
		taskWheelScript.enabled = true;
        brokenKeyPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.brokenKeyPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isFixKeyTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieNaprawKlucz", fixKeyTaskText));
                tasksTextMesh[i].text = fixKeyTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieCmentarzZwierz(){
		isAnimalCemetaryTask = true;
		notesScript.notes [23].gameObject.SetActive (true);
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        animalCemetaryPointer.enabled = true;
        animalCemetaryArrowPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.animalCementaryPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieCmentarzZwierz", animalCemetaryTaskText));
                tasksTextMesh[i].text = animalCemetaryTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieVictorPotok(){

		tasksList.RemoveAll (x => x.title == "ZadanieCmentarzZwierz");
		isAnimalCemetaryTaskRemoved = true;
        animalCemetaryPointer.enabled = false;
        animalCemetaryArrowPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.animalCementaryPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isVictorBrookTask = true;
		inventoryScript.aliceKey.gameObject.SetActive (true);
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        victorArrowPointer.enabled = true;
        victorArrowPointer2.enabled = true;

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieVictorPotok", victorBrookTaskText));
                tasksTextMesh[i].text = victorBrookTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieSalonAlice(){

		isAliceRoomTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieSalonAlice", aliceRoomTaskText));
                tasksTextMesh[i].text = aliceRoomTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieKukurydza(){

		tasksList.RemoveAll (x => x.title == "ZadanieAliceInfo");
		isAliceSearchTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isCornfieldTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        cornfieldPointer.enabled = true;
        inventoryScript.axe.gameObject.SetActive(true);
        jumpscareScript.staticCornfieldMonster.gameObject.SetActive(true);
        musicScript.isMusicOff = true;
        compassScript.AddTaskPoint(compassScript.cornfieldPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKukurydza", cornfieldTaskText));
                tasksTextMesh[i].text = cornfieldTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieSiekiera(){

        tasksList.RemoveAll (x => x.title == "ZadanieKukurydza");
        isCornfieldTaskRemoved = true;
		cornfieldPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.cornfieldPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isAxeTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        axePointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.axePoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieSiekiera", axeTaskText));
                tasksTextMesh[i].text = axeTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieSzafaKorytarz(){

		tasksList.RemoveAll (x => x.title == "ZadanieSiekiera");
		isAxeTaskRemoved = true;
		axePointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.axePoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isCorridorWardrobeTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        corridorWardrobePointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.wardrobeCorridorPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieSzafaKorytarz", corridorWardrobeTaskText));
                tasksTextMesh[i].text = corridorWardrobeTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieSzafkaEdward(){
		
		isEdwardCupboardTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku3.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieSzafkaEdward", edwardCupboardTaskText));
                tasksTextMesh[i].text = edwardCupboardTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieKaseta2(){

        //

        if (isEdwardCupboardTask == true)
        {

            tasksList.RemoveAll(x => x.title == "ZadanieSzafkaEdward");
            isEdwardCupboardTaskRemoved = true;

            tasksTextMesh[0].text = "";
            tasksTextMesh[1].text = "";
            tasksTextMesh[2].text = "";
            tasksTextMesh[3].text = "";
            tasksTextMesh[4].text = "";

        } 

		isCassete2Task = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        cassete2Pointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.cassete2Point);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKaseta2", Cassete2TaskText));
                tasksTextMesh[i].text = Cassete2TaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieIdzSzlak(){

		tasksList.RemoveAll (x => x.title == "ZadanieKaseta2");
		isCassete2TaskRemoved = true;
		cassete2Pointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.cassete2Point);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isGoToTrialTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        goTrailPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.goTrailPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieIdzSzlak", goToTrialTaskText));
                tasksTextMesh[i].text = goToTrialTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieKierujSzlak(){

		tasksList.RemoveAll (x => x.title == "ZadanieIdzSzlak");
		isGoToTrialTaskRemoved = true;
		goTrailPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.goTrailPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isGoTrailTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        trailArrowPointer.enabled = true;

		for(int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKierujSzlak", goTrailTaskText));
                tasksTextMesh[i].text = goTrailTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadaniePrzedostanSie(){

		tasksList.RemoveAll (x => x.title == "ZadanieKierujSzlak");
		isGoTrailTaskRemoved = true;
		trailArrowPointer.enabled = false;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isGetToTomRoadTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        getToTomRoadPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.getToPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadaniePrzedostanSie", getToTomRoadTaskText));
                tasksTextMesh[i].text = getToTomRoadTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieTomInfo(){

		tasksList.RemoveAll (x => x.title == "ZadaniePrzedostanSie");
		isGetToTomRoadTaskRemoved = true;
		getToTomRoadPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.getToPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isTomSearchTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        tomHousePointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.tomHousePoint);

        tomHouseCollider.gameObject.SetActive (false);
		tomBooksCollider.gameObject.SetActive (false);
		tomHallCollider.gameObject.SetActive (false);

        DrzwiDomTomS.isNeedKey = false;
        DrzwiKsiazkiTomS.isNeedKey = false;
        DrzwiSalaTomS.isNeedKey = false;

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieTomInfo", tomSearchTaskText));
                tasksTextMesh[i].text = tomSearchTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieTomKukurydza(){

		isTomCornifieldTask = true;
		cornfieldAreaPointer.enabled = true;
		inventoryScript.cassete3.gameObject.SetActive (true);
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieTomKukurydza", ZadanieTomKukurydzaT));
                tasksTextMesh[i].text = ZadanieTomKukurydzaT;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieKaseta3(){

		tasksList.RemoveAll (x => x.title == "ZadanieTomKukurydza");
		isTomCornifieldTaskRemoved = true;
		cornfieldAreaPointer.enabled = false;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isCassete3Task = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKaseta3", cassete3TaskText));
                tasksTextMesh[i].text = cassete3TaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieTomOboz(){

		isTompCampTask = true;
		tomCampPointer.enabled = true;
		notesScript.notes [33].gameObject.SetActive (true);
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        compassScript.AddTaskPoint(compassScript.tomCampPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieTomOboz", tomCampTaskText));
                tasksTextMesh[i].text = tomCampTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieTomDynia(){

		tasksList.RemoveAll (x => x.title == "ZadanieTomOboz");
		isTompCampTaskRemoved = true;
		//TomObozPointer.enabled = false;
        //Compass.UsunPunktZadania(Compass.PunktTomOboz);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isTomPumpkinTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
		pumpkinAreaPointer.enabled = true;
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieTomDynia", tomPumpkinTaskText));
                tasksTextMesh[i].text = tomPumpkinTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieTomChip(){

		isTomChipTask = true;
		isLackChip = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieTomChip", tomChipTaskText));
                tasksTextMesh[i].text = tomChipTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieWawoz(){

		tasksList.RemoveAll (x => x.title == "ZadanieKaseta3");
        tasksList.RemoveAll (x => x.title == "ZadanieTomInfo");
        isCassete3TaskRemoved = true;
		isTomSearchTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isRavineTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        ravinePointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.ravibePoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieWawoz", ravineTaskText));
                tasksTextMesh[i].text = ravineTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieIdzWawoz(){

		tasksList.RemoveAll (x => x.title == "ZadanieWawoz");
		isRavineTaskRemoved = true;
		ravinePointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.ravibePoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isGoRavineTask = true;
		notesScript.notes [35].gameObject.SetActive (true);
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        goRavineArrowPointer.enabled = true;

		for(int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieIdzWawoz", goTrialTaskText));
                tasksTextMesh[i].text = goTrialTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieOpuszczonyInfo(){

		tasksList.RemoveAll (x => x.title == "ZadanieIdzWawoz");
		isGoRavineTaskRemoved = true;
		goRavineArrowPointer.enabled = false;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isAbandonedSearchTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        abandonedPointer.enabled = true;
		abandonedCollider.gameObject.SetActive (false);
        DrzwiOpuszczonyS.isNeedKey = false;
        compassScript.AddTaskPoint(compassScript.abandonedHousePoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieOpuszczonyInfo", abandonedSearchTaskText));
                tasksTextMesh[i].text = abandonedSearchTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieKaseta4(){

		isCassete4Task = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKaseta4", cassete4TaskText));
                tasksTextMesh[i].text = cassete4TaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieStevenInfo(){

		tasksList.RemoveAll (x => x.title == "ZadanieKaseta4");
        tasksList.RemoveAll (x => x.title == "ZadanieOpuszczonyInfo");
        isCassete4TaskRemoved = true;
		isAbandonedSearchTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		isStevenSearchTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        stevenHousePointer.enabled = true;
		stevenHouseCollider.gameObject.SetActive (false);
        DrzwiDomStevenS.isNeedKey = false;
        compassScript.AddTaskPoint(compassScript.stevenHousePoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieStevenInfo", stevenSearchTaskText));
                tasksTextMesh[i].text = stevenSearchTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieStevenKlucz(){

		isStevenKeyTask = true;
		stevenKeyAreaPointer.enabled = true;
		stevenMeatPointer.enabled = true;
		inventoryScript.stevenKey.gameObject.SetActive (true);
		notesScript.notes [41].gameObject.SetActive (true);
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        compassScript.AddTaskPoint(compassScript.stevenMeatPoint);
        meat1.gameObject.SetActive(true);
        meat2.gameObject.SetActive(true);
        meat3.gameObject.SetActive(true);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieStevenKlucz", stevenKeyTaskText));
                tasksTextMesh[i].text = stevenKeyTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieStevenGrzyb(){


		isStevenMushroomTask = true;
		inventoryScript.labMushroom.gameObject.SetActive (true);
		stevenMushroomPointer.enabled = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        compassScript.AddTaskPoint(compassScript.stevenMushroomPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieStevenGrzyb", stevenMushroomTaskText));
                tasksTextMesh[i].text = stevenMushroomTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieStevenRoslina(){

		isStevenPlantTask = true;
		inventoryScript.labPlant.gameObject.SetActive (true);
		stevenPlantPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.stevenPlantPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieStevenRoslina", stevenPlantTaskText));
                tasksTextMesh[i].text = stevenPlantTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieStevenCzaszka(){

		isStevenSkullTask = true;
		inventoryScript.labSkull.gameObject.SetActive (true);
		stevenSkullPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.stevenSkullPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieStevenCzaszka", stevenSkullTaskText));
                tasksTextMesh[i].text = stevenSkullTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieKwas(){

        isStevenAcidTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();


        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKwas", acidTaskText));
                tasksTextMesh[i].text = acidTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieStevenSzopa(){

		tasksList.RemoveAll (x => x.title == "ZadanieKwas");
		isStevenAcidTaskRemoved = true;

        tasksList.RemoveAll(x => x.title == "ZadanieStevenInfo");
        isStevenSearchTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        isStevenShedTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        stevenShedPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.stevenShedPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieStevenSzopa", stevenShedTaskText));
                tasksTextMesh[i].text = stevenShedTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieStevenNotatka(){

		isStevenNoteTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
		stevenGrille.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieStevenNotatka", stevenNoteTaskText));
                tasksTextMesh[i].text = stevenNoteTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieStevenPotok(){

        tasksList.RemoveAll (x => x.title == "ZadanieStevenNotatka");
        isStevenNoteTaskRemoved = true;

        tasksList.RemoveAll(x => x.title == "ZadanieStevenSzopa");
        isStevenShedTaskRemoved = true;
        stevenShedPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.stevenShedPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        isStevenBrookTask = true;
		stevenBrookPointer.enabled = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        compassScript.AddTaskPoint(compassScript.stevenBrookPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieStevenPotok", stevenBrookTaskText));
                tasksTextMesh[i].text = stevenBrookTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadaniePaulInfo(){

        tasksList.RemoveAll (x => x.title == "ZadanieStevenPotok");
        stevenBrookPointer.enabled = false;
        isStevenBrookTaskRemoved = true;
        compassScript.RemoveTaskPoint(compassScript.stevenBrookPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        isPaulSearchTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        PaulHousePointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.scientistHousePoint);

        paulHouseCollider.gameObject.SetActive (false);
		paulBackCollider.gameObject.SetActive (false);

        DrzwiDomPaulS.isNeedKey = false;
        DrzwiMonsterS.isNeedKey = false;

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadaniePaulInfo", paulSearchTaskText));
                tasksTextMesh[i].text = paulSearchTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadaniePaulDrzwi(){
		isPaulDoorTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadaniePaulDrzwi", paulDoorTaskText));
                tasksTextMesh[i].text = paulDoorTaskText;
				break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadanieChatka(){


		//ListaZadan.RemoveAll (x => x.ZadanieTytul == "ZadaniePaulDrzwi");
		//ZadaniePaulDrzwi_Usun = true;

        tasksList.RemoveAll(x => x.title == "ZadaniePaulInfo");
        isPaulSearchTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        isHutTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
		hutPointer.enabled = true;
		hutCollider.gameObject.SetActive (false);
        DrzwiDomekS.isNeedKey = false;
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        compassScript.AddTaskPoint(compassScript.hutPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieChatka", hutTaskText));
                tasksTextMesh[i].text = hutTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

	void ZadaniePotokDiably(){

		if(isHutTaskRemoved == false){

        tasksList.RemoveAll (x => x.title == "ZadanieChatka");
		hutPointer.enabled = false;
		isHutTaskRemoved = true;
        compassScript.RemoveTaskPoint(compassScript.hutPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

		}


        isDevilsBrookTask = true;
		uiAnimator.SetTrigger("NoweZadanie");
        //ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        devilsBrookPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.devilsBrookPoint);

        for (int i=0; i<tasksTextMesh.Length; i++){
			if(tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadaniePotokDiably", devilsBrookTaskText));
                tasksTextMesh[i].text = devilsBrookTaskText;
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
			}
		}

        notificationScript.KomunikatZadanieWskazowka();

    }

    void ZadanieKryjowkaDiably()
    {

        tasksList.RemoveAll (x => x.title == "ZadaniePotokDiably");
		devilsBrookPointer.enabled = false;
		isDevilsBrookTaskRemoved = true;
        compassScript.RemoveTaskPoint(compassScript.devilsBrookPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        isDevilsShelterTask = true;
        uiAnimator.SetTrigger("NoweZadanie");
        // ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        KryjowkaDiablyObszar.enabled = true;


		for (int i = 0; i < tasksTextMesh.Length; i++){
			if (tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKryjowkaDiably", devilsShelterTaskText));
                tasksTextMesh[i].text = devilsShelterTaskText; // # Find the Devil's hide
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
            }
        }

        notificationScript.KomunikatZadanieWskazowka();

    }

    void ZadanieKryjowkaRodzina()
    {

        tasksList.RemoveAll(x => x.title == "ZadanieKryjowkaDiably");
        KryjowkaDiablyObszar.enabled = false;
        isDevilsShelterTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        isShelterFamilyTask = true;
        uiAnimator.SetTrigger("NoweZadanie");
        // ZrodloDzwieku.PlayOneShot(DzwNoweZadanie);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        for (int i = 0; i < tasksTextMesh.Length; i++){
			if (tasksTextMesh[i].text.Length == 0){
                tasksList.Add(new TaskData("ZadanieKryjowkaRodzina", endTaskText));
                tasksTextMesh[i].text = endTaskText; // # Find the Devil's hide
                for (int j = 0; j < tasksList.Count; j++)
                {
                    tasksTextMesh[j].text = tasksList[j].content;
                }
                break;
            }
        }

        notificationScript.KomunikatZadanieWskazowka();

    }

    // ----------------------Dodawanie pointerow z notatek a nie zadania-----------------------

    public void AddSzafkaEdwardPointer()
    {
        EdwardCupboardPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.edwardCupboardPoint);

    }

    public void AddKoscSzopaPointer()
    {
        boneShedPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.bonesShedPoint);
    }

    public void AddKoscStajniaPointer()
    {
        boneStablePointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.boneStablePoint);
    }

    public void AddSzopaNarzedziaPointer()
    {
        toolShedPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.toolShedPoint);
    }

    public void AddKluczWychodekPointer()
    {
        keyToiletPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.keyToiletPoint);
    }

    public void AddSekretnyPokojPointer()
    {
        secretRoomPointer.enabled = true;
        compassScript.AddTaskPoint(compassScript.secretRoomPoint);
    }

    // ----------------------Usuwanie pointerow z notatek a nie zadania-----------------------

    public void RemoveSzafkaEdwardPointer()
    {
        EdwardCupboardPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.edwardCupboardPoint);

    }

    public void RemoveKoscSzopaPointer()
    {
        boneShedPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.bonesShedPoint);
    }

    public void RemoveKoscStajniaPointer()
    {
        boneStablePointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.boneStablePoint);
    }

    public void RemoveSzopaNarzedziaPointer()
    {
        toolShedPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.toolShedPoint);
    }

    public void RemoveKluczWychodekPointer()
    {
        keyToiletPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.keyToiletPoint);
    }

    public void RemoveSekretnyPokojPointer()
    {
        secretRoomPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.secretRoomPoint);
    }

    // -----------------------Usuwanie zadan----------------------------------------------------

    // Usuwanie zadania klucz drewno

    /*  void ZadanieKluczDrewnoUsun(){
          ListaZadan.RemoveAll (x => x.ZadanieTytul == "ZadanieKluczDrewno");
          ZadanieKluczDrewno_Usun = true;
          for (int i = 0; i <= ZadanieText.Length; i++) {
              if (ZadanieText [i].text == ZadanieKluczDrewnoT) {
                  ZadanieText [i].text = "";
                  KluczDrewnoPointer.enabled = false;
                  for (int j = 0; j < ListaZadan.Count; j++)
                  {
                      ZadanieText[j].text = ListaZadan[j].ZadanieTresc;
                  }
                  break;
              }

          }
      } */

    void ZadanieKluczDrewnoUsun()
    {
        tasksList.RemoveAll(x => x.title == "ZadanieKluczDrewno");
        isWoodKeyTaskRemoved = true;
        woodenKeyPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.keyWoodPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
                {
                    tasksTextMesh[i].text = tasksList[i].content;
                }
        
    }

    // Usuwanie zadania kamienie studnia

    void ZadanieKamienieStudniaUsun(){
		tasksList.RemoveAll (x => x.title == "ZadanieKamienieStudnia");
		isWellStonesTaskRemoved = true;
		taskWellScript.enabled = false;
        magicWellPointer.enabled = false;
        stonesAreaPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.magicWellPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }
		
	}

	// Usuwanie zadania kosci

	void ZadanieKosciUsun(){
		tasksList.RemoveAll (x => x.title == "ZadanieKosci");
		isBonesTaskRemoved = true;
		taskBonesScript.enabled = false;
        bonesAreaPointer.enabled = false;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }
			
	}

    // Usuwanie zadania drzwi ogrod

    void ZadanieDrzwiOgrodUsun()
    {
        tasksList.RemoveAll(x => x.title == "ZadanieDrzwiOgrod");
        isGardenDoorTaskRemoved = true;
        gardenDoorPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.gardenDoorPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }

    }

    // Usuwanie zadania simon element

    void ZadanieSimonElementUsun(){
		tasksList.RemoveAll (x => x.title == "ZadanieSimonElement");
		isSimonElementTaskRemoved = true;
        simonElementPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.simonElementPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }
		
	}

	// Usuwanie zadania napraw klucz

	void ZadanieNaprawKluczUsun(){
		tasksList.RemoveAll (x => x.title == "ZadanieNaprawKlucz");
		isFixKeyTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }
			
	}

    // Usuwanie zadania drzwi warsztat

    void ZadanieWarsztatUsun()
    {
        tasksList.RemoveAll(x => x.title == "ZadanieWarsztat");
        isWorkshopTaskRemoved = true;
        workshopPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.workshopPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }
            
    }

    // Usuwanie zadania victor potok

    void ZadanieVictorPotokUsun(){
		tasksList.RemoveAll (x => x.title == "ZadanieVictorPotok");
		isVictorBrookTaskRemoved = true;
        victorArrowPointer.enabled = false;
        victorArrowPointer2.enabled = false;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }	
		
	}

	// Usuwanie zadania salon Alice

	void ZadanieSalonAliceUsun(){
		tasksList.RemoveAll (x => x.title == "ZadanieSalonAlice");
		isAliceRoomTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }
			
	}

    // Usuwanie zadania Szafa korytarz

    void ZadanieSzafaKorytarzUsun()
    {

        tasksList.RemoveAll(x => x.title == "ZadanieSzafaKorytarz");
        isCorridorWardrobeTaskRemoved = true;
        corridorWardrobePointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.wardrobeCorridorPoint);

        AddSzafkaEdwardPointer();
        

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }

    }

    // Usuwanie zadania Tom dynia

    void ZadanieTomDyniaUsun(){
        tasksList.RemoveAll (x => x.title == "ZadanieTomDynia");
        isTomPumpkinTaskRemoved = true;
		pumpkinAreaPointer.enabled = false;
        tomCampPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.tomCampPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }
			
	}

	// Usuwanie zadania Tom chip

	void ZadanieTomChipUsun(){
		tasksList.RemoveAll (x => x.title == "ZadanieTomChip");
		isTomChipTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }

	}

    // Usuwanie zadania Steven Klucz

    void ZadanieStevenKluczUsun()
    {

        tasksList.RemoveAll(x => x.title == "ZadanieStevenKlucz");
        isStevenKeyTaskRemoved = true;
        stevenKeyAreaPointer.enabled = false;
        stevenMeatPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.stevenMeatPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }

    }

    // Usuwanie zadania Steven Grzyb

    void ZadanieStevenGrzybUsun()
    {

        tasksList.RemoveAll(x => x.title == "ZadanieStevenGrzyb");
        isStevenMushroomTaskRemoved = true;
        stevenMushroomPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.stevenMushroomPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }

    }

    // Usuwanie zadania Steven Roslina

    void ZadanieStevenRoslinaUsun()
    {

        tasksList.RemoveAll(x => x.title == "ZadanieStevenRoslina");
        isStevenPlantTaskRemoved = true;
        stevenPlantPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.stevenPlantPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }

    }

    // Usuwanie zadania Steven Czaszka

    void ZadanieStevenCzaszkaUsun()
    {

        tasksList.RemoveAll(x => x.title == "ZadanieStevenCzaszka");
        isStevenSkullTaskRemoved = true;
        stevenSkullPointer.enabled = false;
        compassScript.RemoveTaskPoint(compassScript.stevenSkullPoint);

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }

    }

    // Usuwanie zadania Paul drzwi

    void ZadaniePaulDrzwiUsun()
    {
        tasksList.RemoveAll(x => x.title == "ZadaniePaulDrzwi");
        isPaulDoorTaskRemoved = true;

        tasksTextMesh[0].text = "";
        tasksTextMesh[1].text = "";
        tasksTextMesh[2].text = "";
        tasksTextMesh[3].text = "";
        tasksTextMesh[4].text = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            tasksTextMesh[i].text = tasksList[i].content;
        }

    }


}
