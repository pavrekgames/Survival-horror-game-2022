using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using TMPro;

public class Tasks : MonoBehaviour {

    public bool DzwiekPlay_ok = false; // wznawianie i zatrzymywanie dzwiekow

    // tasks
    public List<TaskData> tasksList = new List<TaskData>();
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
    public PlayerManager playerManagerScript;

    // boole dotyczace dodawania zadan
    public bool isFirstTask = true;
    public bool isSearchTask = false;
    public bool isWoodKeyTask = false;
    public bool isMagicWellTask = false;
    public bool isWellStonesTask = false;
    public bool isCassete1Task = false;
    public bool isGardenDoorTask = false;
    public bool isBonesTask = false;
    public bool isGoToAliceTask = false;
    public bool isAliceSearchTask = false;
    public bool isSimonElementTask = false;
    public bool isWorkshopTask = false;
    public bool isBrokenKeyTask = false;
    public bool isFixKeyTask = false;
    public bool isAnimalCemetaryTask = false;
    public bool isVictorBrookTask = false;
    public bool isAliceRoomTask = false;
    public bool isCornfieldTask = false;
    public bool isAxeTask = false;
    public bool isCorridorWardrobeTask = false;
    public bool isEdwardCupboardTask = false;
    public bool isCassete2Task = false;
    public bool isGoToTrialTask = false;
    public bool isGoTrailTask = false;
    public bool isGetToTomRoadTask = false;
    public bool isTomSearchTask = false;
    public bool isTomCornifieldTask = false;
    public bool isCassete3Task = false;
    public bool isTompCampTask = false;
    public bool isTomPumpkinTask = false;
    public bool isTomChipTask = false;
    public bool isRavineTask = false;
    public bool isGoRavineTask = false;
    public bool isAbandonedSearchTask = false;
    public bool isCassete4Task = false;
    public bool isStevenSearchTask = false;
    public bool isStevenKeyTask = false;
    public bool isStevenMushroomTask = false;
    public bool isStevenPlantTask = false;
    public bool isStevenSkullTask = false;
    public bool isStevenAcidTask = false;
    public bool isStevenShedTask = false;
    public bool isStevenNoteTask = false;
    public bool isStevenBrookTask = false;
    public bool isPaulSearchTask = false;
    public bool isPaulDoorTask = false;
    public bool isHutTask = false;
    public bool isDevilsBrookTask = false;
    public bool isDevilsShelterTask = false;
    public bool isShelterFamilyTask = false;

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


    private Ray playerAim;
    private Camera playerCam;
    public float rayLength = 4f;

    // tasks UI
    public TextMeshProUGUI[] tasksTextMesh;

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

   // task well
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
    public bool isThorns = false;
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

		if (Input.GetMouseButtonDown (0) && inventoryScript.items.Count >= 0 && playerManagerScript.isPlayerCanInput == true) {

			Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {

                if (hit.collider.gameObject.tag == "Door" || hit.collider.gameObject.tag == "Hand") {

                    IRaycastTask raycastTask = hit.transform.GetComponent<IRaycastTask>() as IRaycastTask;
                    if(raycastTask != null)
                    {
                        raycastTask.Execute();
                    }
				}
			} 
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
    } 


    public void AddTask(TaskData task)
    {
        task.isAdded = true;
        tasksList.Add(task);
        audioSource.clip = newTaskSound;
        audioSource.Play();
        uiAnimator.SetTrigger("NewTask");
        notificationScript.TaskHintNotification();
    }

    public void RemoveTask(TaskData task)
    {
        task.isRemoved = true;
        tasksList.Remove(task);
    }

}
