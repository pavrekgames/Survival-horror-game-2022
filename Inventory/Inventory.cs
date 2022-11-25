using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Inventory : MonoBehaviour {

    // inventory
    public Image[] itemIcons;
    private PlayerManager playerManagerScript;
    public List<Item> items = new List<Item>();
    public Item[] allItems;
    private Animator animator;
    private Transform player;
    private Map mapScript;
    private BeginGame beginGameScript;
    private CrosshairGUI cursorScript;
    private Player playerScript;
    public Flashlight flashlightScript;
    private SaveGame SaveGameScript;
    private Canvas uiCanvas;
    public TextMeshProUGUI currenntItemTitle;
    public Image currentItemIcon;
    public bool isInventoryActive = false;
    private Menu gameMenuScript;
    public Notifications notificationScript;
    public Tasks tasksScript;
    public TaskBones bonesTaskScript;
    public AudioSource itemAudioSource1;
    public AudioSource itemAudioSource2;
    public AudioSource itemAudioSource3;
    public AudioSource itemAudioSource4;
    public AudioSource pauseAudioSource;
    public Health healthScript;
    public Notes notesScript;
    public VoiceActing voiceActingScript;
    public AudioClip menuButtonSound;
    public Canvas inventoryCanvas;
    public AudioClip itemDesciptionSound;

    public InventoryUI inventoryUI;
    public TasksUI tasksUI;
    public NotesUI notesUI;
    public TreatmentUI treatmentUI;
    public CollectionBadgesUI collectionBadgesUI;

    public int secretItemsCount = 0;
    public int secretPlacesCount = 0;
    public int blueHerbsCount = 0;
    public int greenHerbsCount = 0;
    public int healthPotsCount = 0;
    public int staminaPotsCount = 0;
    public int vialsCount = 0;

    public AudioClip secretItemSound;
    public AudioClip secretItemSound2;
    public AudioClip secretPlaceSound;
    public AudioClip collectHerbSound;
    public AudioClip collectVialSound;
    public AudioClip collectItemSound;
    public AudioClip openInventorySound;

   

    // Umiejetnosci
    public bool isSkill1_Unlocked = false;
    public AudioClip skillUnlockedSound;
    public Image skill1_Icon;

    public bool isSkill2_Unlocked = false;
    public Image skill2_Icon;

    public bool isSkill3_Unlocked = false;
    public Image skill3_Icon;

    public bool isSkill4_Unlocked = false;
    public Image skill4_Icon;

    // tasks UI

    public Canvas tasksCanvas;
    public bool isTasksActive = false;
    // notes UI

    public Canvas notesCanvas;
    public Canvas noteDefaultCanvas;
    public bool isNotesActive = false;

    private ScrollRect notesScrollRect;
    private Scrollbar notesScrollbar;

    // treatment

    // treatment UI

    public Canvas treatmentCanvas;
    public TextMeshProUGUI mixturesText;
    public TextMeshProUGUI vialsText;
    public Text blueHerbsText;
    public Text greenHerbsText;
    public Text vialsCountText;
    public Text healthPotsText;
    public Text staminaPotsText;
    private TextMeshProUGUI healthConditionText;
    public bool isTreatmentActive = false;
    public AudioClip createPotSound;
    public AudioClip usePotSound;
    public AudioClip lackVialsSound;

    // teksty do apteczki
    public string defaultPotDescription = "Hover over the mixture to get more information.";
    public string healthPotDescription = "Health Mixture  - Increase your health. You need 2 green herbs and 2 blue herbs to create it.";
    public string staminaPotDescription = "Stamina Mixture  - Increase your Stamina. You need 1 green herb and 2 blue herbs to create it.";
    public string stateGoodText = "<color=#08FF5BFF>Good</color>";
    public string stateInjuredText = "<color=#FFC117FF>Injured</color>";
    public string stateCriticalText = "<color=#FF4E26FF>Critical</color>";
    public string stateTiredText = "<color=#BF42C7FF>Tired</color>";
    public string lackComponentsText = "<color=#FF0000FF>You don't have enough herbs or a vial</color>";

    // collection badges


    // collection badges UI

    public Canvas badgeCollectionCanvas;
    public Canvas[] collectionCanvas;
    private TextMeshProUGUI badgeCollectionTitleText;
    public bool isCollectionActive = false;

    public Sprite badgeSprite;
    public Sprite badgeOKSprite;
    public Image[] collectionTextures;

    // collection photos


    // collection photos UI

    public Canvas photoCollectionCanvas;
    private TextMeshProUGUI photoCollectionTitleText;
    public Sprite photoSprite;
    public Sprite photoOKSprite;

    // collection tips


    // collection tips UI

    public Canvas tipCollectionCanvas;
    private TextMeshProUGUI tipCollectionTitleText;
    public Sprite tipSprite;
    public Sprite tipOKSprite;

    // Notification

    public bool isRockyGraveSP = false;
	public Text rockyGraveTextPointer;
	public bool isAnimalCementarySP = false;
	public Text animalCementaryTextPointer;
	public bool isSimonGardenSP = false;
	public Text simonGardenTextPointer;
	public bool isTomCampSP = false;
	public Text tomCampTextPointer;
	public bool isDevilsShelterSP = false;
	public bool isWarCementarySP = false;
	public Text warCementaryTextPointer;
	public bool isHutSP = false;
	public Text hutTextPointer;
	public bool isBasementSP = false;
	public Text basementTextPointer;
	public bool isMushroomFieldSP = false;
	public Text mushroomFieldTextPointer;
	public bool isDarkForestSP = false;
	public Text darkForestTextPointer;
	public bool isBonesTowerSP = false;
	public Text bonesTowerTextPointer;
	public bool isKnifeArenaSP = false;
	public Text knifeArenaTextPointer;
	public bool isCaveSP = false;
	public Text caveTextPointer;
	public bool isMonumentSP = false;
	public Text monumentTextPointer;
	public bool isSpaceshipSP = false;
	public Text spaceshipTextPointer;

    // teskty do secret places
    public string rockyGraveText = "Secret Place: Rocky's Grave";
    public string animalCemeteryText = "Secret Place: Animals's Cemetery";
    public string simonGardenText = "Secret Place: Simon's Garden";
    public string tomCampText = "Secret Place: Tom's Camp";
    public string devilsShelterText = "Secret Place: Devils Hide";
    public string warCemeteryText = "Secret Place: War Cemetery";
    public string hutText = "Secret Place: Scientist's Hut";
    public string abandonedBasementText = "Secret Place: Abandoned Basement";
    public string mushroomFieldText = "Secret Place: Mushroom Field";
    public string darkForestText = "Secret Place: Dark Forest";
    public string bonesTowerText = "Secret Place: Bones Tower";
    public string knifeArenaText = "Secret Place: Knife Arena";
    public string caveText = "Secret Place: Cave";
    public string monumentText = "Secret Place: Old Monument";
    public string spaceshipText = "Secret Place: Spececraft";

    //------------------------------------------------------------------------

    private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;

    // przedmioty do pondoszenia

	private Transform keyV1;
	public bool isKeyV1Taken = false;
	public bool isKeyV1Removed = false;
	public AudioClip keySound;
	public Sprite keyV1Icon;

	private Transform oil;
	public bool isOilTaken = false;
	public bool isOilRemoved = false;
	public AudioClip oilSound;
	public Sprite oilIcon;

	private Transform keyV2;
	public bool isKeyV2Taken = false;
	public bool isKeyV2Removed = false;
	public AudioClip keySound2;
	public Sprite keyV2Icon;

	private Transform keyV3;
	public bool isKeyV3Taken = false;
	public bool isKeyV3Removed = false;
	public Sprite keyV3Icon;

	public Transform keyV4;
	public bool isKeyV4Taken = false;
	public bool isKeyV4Removed = false;
	public Sprite keyV4Icon;

	private Transform batteries;
	public bool isBatteriesTaken = false;
	public bool isBatteriesRemoved = false;
	public AudioClip batteriesSound;
	public Sprite batteriesIcon;

	private Transform cassete1;
	public bool isCassete1Taken = false;
	public bool isCassete1Removed = false;
	public AudioClip casseteSound;
	public Sprite cassete1Icon;

	private Transform bone1;
	public bool isBone1Taken = false;
	public bool isBone1Removed = false;
	public AudioClip boneSound;
	public Sprite bone1Icon;

	private Transform bone2;
	public bool isBone2Taken = false;
	public bool isBone2Removed = false;
	public Sprite bone2Icon;

	private Transform bone3;
	public bool isBone3Taken = false;
	public bool isBone3Removed = false;
	public Sprite bone3Icon;

	private Transform bone4;
	public bool isBone4Taken = false;
	public bool isBone4Removed = false;
	public Sprite bone4Icon;

	private Transform bone5;
	public bool isBone5Taken = false;
	public bool isBone5Removed = false;
	public Sprite bone5Icon;

	private Transform nicheKey;
	public bool isNicheKeyTaken = false;
	public bool isNicheKeyRemoved = false;
	public Sprite nicheKeyIcon;

	private Transform secretRoomKey;
	public bool isSecretRoomKeyTaken = false;
	public bool isSecretRoomKeyRemoved = false;
	public Sprite secretRoomKeyIcon;

	public Transform brokenFactoryKey;
	public bool isBrokenFactoryKeyTaken = false;
	public bool isBrokenFactoryKeyRemoved = false;
	public Sprite brokenFactoryKeyIcon;

	public Transform woodenWheel;
	public bool isWoodenWheelTaken = false;
	public bool isWoodenWheelRemoved = false;
	public AudioClip woodenWheelSound;
	public Sprite woodenWheelIcon;

    public Transform fixedKey;
	public bool isFixedKeyTaken = false;
	public bool isFixedKeyRemoved = false;
	public Sprite fixedKeyIcon;

	private Transform crowbar;
	public bool isCrowbarTaken = false;
	public bool isCrowbarRemoved = false;
	public AudioClip crowbarSound;
	public Sprite crowbarIcon;

	public Transform aliceKey;
	public bool isAliceKeyTaken = false;
	public bool isAliceKeyRemoved = false;
	public Sprite aliceKeyIcon;

	private Transform pliers;
	public bool isPliersTaken = false;
	public bool isPliersRemoved = false;
	public AudioClip pliersSound;
	public Sprite pliersIcon;

	public Transform axe;
	public bool isAxeTaken = false;
	public bool isAxeRemoved = false;
	public AudioClip axeSound;
	public Sprite axeIcon;

	private Transform wardrobeCorridorKey;
	public bool isWardrobeCorridorKeyTaken = false;
	public bool isWardrobeCorridorKeyRemoved = false;
	public Sprite wardrobeCorridorKeyIcon;

	private Transform shedCupboardKey;
	public bool isShedCupboardKeyTaken = false;
	public bool isShedCupboardKeyRemoved = false;
	public Sprite shedCupboardKeyIcon;

	private Transform cassete2;
	public bool isCassete2Taken = false;
	public bool isCassete2Removed = false;
	public Sprite cassete2Icon;

	public GameObject pumpkin;
	public bool isPumpkinTaken = false;
	public bool isPumpkinRemoved = false;
	public Sprite pumpkinIcon;

	public Transform tomUpstairsKey;
	public bool isTomUpstairsKeyTaken = false;
	public bool isTomUpstairsKeyRemoved = false;
	public Sprite tomUpstairsKeyIcon;

	private Transform tomRoomKey;
	public bool isTomRoomKeyTaken = false;
	public bool isTomRoomKeyRemoved = false;
	public Sprite tomRoomKeyIcon;

	public Transform cassete3;
	public bool isCassete3Taken = false;
	public bool isCassete3Removed = false;
	public Sprite cassete3Icon;

	public Transform chip;
	public bool isChipTaken = false;
	public bool isChipRemoved = false;
	public Sprite chipIcon;

	private Transform oldWardrobeKey;
	public bool isOldWardrobeKeyTaken = false;
	public bool isOldWardrobeKeyRemoved = false;
	public Sprite oldWardrobeKeyIcon;

	private Transform cassete4;
	public bool isCassete4Taken = false;
	public bool isCassete4Removed = false;
	public Sprite cassete4Icon;

	public Transform stevenKey;
	public bool isStevenKeyTaken = false;
	public bool isStevenKeyRemoved = false;
	public Sprite stevenKeyIcon;

	public Transform labPlant;
	public bool isLabPlantTaken = false;
	public bool isLabPlantRemoved = false;
	public AudioClip labPlantSound;
	public Sprite labPlantIcon;

	public Transform labMushroom;
	public bool isLabMushroomTaken = false;
	public bool isLabMushroomRemoved = false;
	public Sprite labMushroomIcon;

	public Transform labSkull;
	public bool isLabSkullTaken = false;
	public bool isLabSkullRemoved = false;
	public Sprite labSkullIcon;

	public Transform strongAcid;
	public bool isStrongAcidTaken = false;
	public bool isStrongAcidRemoved = false;
	public Sprite strongAcidIcon;

	private Transform paulKey;
	public bool isPaulKeyTaken = false;
	public bool isPaulKeyRemoved = false;
	public Sprite paulKeyIcon;

	// Secret items

	private Transform secretItem1;
	private Transform secretItem2;
	private Transform secretItem3;
	private Transform secretItem4;
	private Transform secretItem5;
	private Transform secretItem6;
	private Transform secretItem7;
	private Transform secretItem8;
	private Transform secretItem9;
	private Transform secretItem10;
	private Transform secretItem11;
	private Transform secretItem12;
	private Transform secretItem13;
	private Transform secretItem14;
	private Transform secretItem15;
	private Transform secretItem16;
	private Transform secretItem17;
	private Transform secretItem18;
	private Transform secretItem19;
	private Transform secretItem20;
	private Transform secretItem21;
	private Transform secretItem22;
	private Transform secretItem23;
	private Transform secretItem24;
	private Transform secretItem25;
    private Transform secretItem26;
    private Transform secretItem27;
    private Transform secretItem28;
    private Transform secretItem29;
    private Transform secretItem30;
    private Transform secretItem31;
    private Transform secretItem32;
    public bool isSecretIem1 = false;
	public bool isSecretIem2 = false;
	public bool isSecretIem3 = false;
	public bool isSecretIem4 = false;
	public bool isSecretIem5 = false;
	public bool isSecretIem6 = false;
	public bool isSecretIem7 = false;
	public bool isSecretIem8 = false;
	public bool isSecretIem9 = false;
	public bool isSecretIem10 = false;
	public bool isSecretIem11 = false;
	public bool isSecretIem12 = false;
	public bool isSecretIem13 = false;
	public bool isSecretIem14 = false;
	public bool isSecretIem15 = false;
	public bool isSecretIem16 = false;
	public bool isSecretIem17 = false;
	public bool isSecretIem18 = false;
	public bool isSecretIem19 = false;
	public bool isSecretIem20 = false;
	public bool isSecretIem21 = false;
	public bool isSecretIem22 = false;
	public bool isSecretIem23 = false;
	public bool isSecretIem24 = false;
	public bool isSecretIem25 = false;
    public bool isSecretIem26 = false;
    public bool isSecretIem27 = false;
    public bool isSecretIem28 = false;
    public bool isSecretIem29 = false;
    public bool isSecretIem30 = false;
    public bool isSecretIem31 = false;
    public bool isSecretIem32 = false;

    //  zielone ziola
    private Transform greenHerb1;
	public bool isGreenHerb1 = false;
	private Transform greenHerb2;
	public bool isGreenHerb2 = false;
	private Transform greenHerb3;
	public bool isGreenHerb3 = false;
	private Transform greenHerb4;
	public bool isGreenHerb4 = false;
	private Transform greenHerb5;
	public bool isGreenHerb5 = false;
	private Transform greenHerb6;
	public bool isGreenHerb6 = false;
	private Transform greenHerb7;
	public bool isGreenHerb7 = false;
	private Transform greenHerb8;
	public bool isGreenHerb8 = false;
	private Transform greenHerb9;
	public bool isGreenHerb9 = false;
	private Transform greenHerb10;
	public bool isGreenHerb10 = false;
	private Transform greenHerb11;
	public bool isGreenHerb11 = false;
	private Transform greenHerb12;
	public bool isGreenHerb12 = false;
	private Transform greenHerb13;
	public bool isGreenHerb13 = false;
	private Transform greenHerb14;
	public bool isGreenHerb14 = false;
	private Transform greenHerb15;
	public bool isGreenHerb15 = false;
	private Transform greenHerb16;
	public bool isGreenHerb16 = false;
	private Transform greenHerb17;
	public bool isGreenHerb17 = false;
	private Transform greenHerb18;
	public bool isGreenHerb18 = false;
	private Transform greenHerb19;
	public bool isGreenHerb19 = false;
	private Transform greenHerb20;
	public bool isGreenHerb20 = false;
	private Transform greenHerb21;
	public bool isGreenHerb21 = false;
	private Transform greenHerb22;
	public bool isGreenHerb22 = false;
    private Transform greenHerb23;
    public bool isGreenHerb23 = false;
    private Transform greenHerb24;
    public bool isGreenHerb24 = false;
    private Transform greenHerb25;
    public bool isGreenHerb25 = false;
    private Transform greenHerb26;
    public bool isGreenHerb26 = false;
    private Transform greenHerb27;
    public bool isGreenHerb27 = false;
    private Transform greenHerb28;
    public bool isGreenHerb28 = false;
    private Transform greenHerb29;
    public bool isGreenHerb29 = false;
    private Transform greenHerb30;
    public bool isGreenHerb30 = false;
    private Transform greenHerb31;
    public bool isGreenHerb31 = false;
    private Transform greenHerb32;
    public bool isGreenHerb32 = false;

    // niebieskie ziola

    private Transform blueHerb1;
	public bool isBlueHerb1 = false;
	private Transform blueHerb2;
	public bool isBlueHerb2 = false;
	private Transform blueHerb3;
	public bool isBlueHerb3 = false;
	private Transform blueHerb4;
	public bool isBlueHerb4 = false;
	private Transform blueHerb5;
	public bool isBlueHerb5 = false;
	private Transform blueHerb6;
	public bool isBlueHerb6 = false;
	private Transform blueHerb7;
	public bool isBlueHerb7 = false;
	private Transform blueHerb8;
	public bool isBlueHerb8 = false;
	private Transform blueHerb9;
	public bool isBlueHerb9 = false;
	private Transform blueHerb10;
	public bool isBlueHerb10 = false;
	private Transform blueHerb11;
	public bool isBlueHerb11 = false;
	private Transform blueHerb12;
	public bool isBlueHerb12 = false;
	private Transform blueHerb13;
	public bool isBlueHerb13 = false;
	private Transform blueHerb14;
	public bool isBlueHerb14 = false;
	private Transform blueHerb15;
	public bool isBlueHerb15 = false;
	private Transform blueHerb16;
	public bool isBlueHerb16 = false;
	private Transform blueHerb17;
	public bool isBlueHerb17 = false;
	private Transform blueHerb18;
	public bool isBlueHerb18 = false;
	private Transform blueHerb19;
	public bool isBlueHerb19 = false;
	private Transform blueHerb20;
	public bool isBlueHerb20 = false;
	private Transform blueHerb21;
	public bool isBlueHerb21 = false;
	private Transform blueHerb22;
	public bool isBlueHerb22 = false;
    private Transform blueHerb23;
    public bool isBlueHerb23 = false;
    private Transform blueHerb24;
    public bool isBlueHerb24 = false;
    private Transform blueHerb25;
    public bool isBlueHerb25 = false;
    private Transform blueHerb26;
    public bool isBlueHerb26 = false;
    private Transform blueHerb27;
    public bool isBlueHerb27 = false;
    private Transform blueHerb28;
    public bool isBlueHerb28 = false;
    private Transform blueHerb29;
    public bool isBlueHerb29 = false;
    private Transform blueHerb30;
    public bool isBlueHerb30 = false;
    private Transform blueHerb31;
    public bool isBlueHerb31 = false;
    private Transform blueHerb32;
    public bool isBlueHerb32 = false;

    // Fiolki

    private Transform vial1;
    public bool isVial1 = false;
    private Transform vial2;
    public bool isVial2 = false;
    private Transform vial3;
    public bool isVial3 = false;
    private Transform vial4;
    public bool isVial4 = false;
    private Transform vial5;
    public bool isVial5 = false;
    private Transform vial6;
    public bool isVial6 = false;
    private Transform vial7;
    public bool isVial7 = false;
    private Transform vial8;
    public bool isVial8 = false;
    private Transform vial9;
    public bool isVial9 = false;
    private Transform vial10;
    public bool isVial10 = false;
    private Transform vial11;
    public bool isVial11 = false;
    private Transform vial12;
    public bool isVial12 = false;
    private Transform vial13;
    public bool isVial13 = false;
    private Transform vial14;
    public bool isVial14 = false;
    private Transform vial15;
    public bool isVial15 = false;
    private Transform vial16;
    public bool isVial16 = false;

    // eliksiry

    private Transform staminaPot1;
    public bool isStaminaPot1 = false;
    private Transform staminaPot2;
    public bool isStaminaPot2 = false;
    private Transform staminaPot3;
    public bool isStaminaPot3 = false;
    private Transform staminaPot4;
    public bool isStaminaPot4 = false;
    private Transform staminaPot5;
    public bool isStaminaPot5 = false;

    private Transform healthPot1;
    public bool isHealthPot1 = false;
    private Transform healthPot2;
    public bool isHealthPot2 = false;
    private Transform healthPot3;
    public bool isHealthPot3 = false;
    private Transform healthPot4;
    public bool isHealthPot4 = false;
    private Transform healthPot5;
    public bool isHealthPot5 = false;
    private Transform healthPot6;
    public bool isHealthPot6 = false;

    // Odznaki

    private Transform badge1;
    public bool isBadge1 = false;
    private Transform badge2;
    public bool isBadge2 = false;
    private Transform badge3;
    public bool isBadge3 = false;
    private Transform badge4;
    public bool isBadge4 = false;
    private Transform badge5;
    public bool isBadge5 = false;
    private Transform badge6;
    public bool isBadge6 = false;
    private Transform badge7;
    public bool isBadge7 = false;
    private Transform badge8;
    public bool isBadge8 = false;
    private Transform badge9;
    public bool isBadge9 = false;
    private Transform badge10;
    public bool isBadge10 = false;
    private Transform badge11;
    public bool isBadge11 = false;
    private Transform badge12;
    public bool isBadge12 = false;

    // Fotografie

    private Transform photo1;
    public bool isPhoto1 = false;
    private Transform photo2;
    public bool isPhoto2 = false;
    private Transform photo3;
    public bool isPhoto3 = false;
    private Transform photo4;
    public bool isPhoto4 = false;
    private Transform photo5;
    public bool isPhoto5 = false;
    private Transform photo6;
    public bool isPhoto6 = false;
    private Transform photo7;
    public bool isPhoto7 = false;
    private Transform photo8;
    public bool isPhoto8 = false;
    private Transform photo9;
    public bool isPhoto9 = false;
    private Transform photo10;
    public bool isPhoto10 = false;
    private Transform photo11;
    public bool isPhoto11 = false;
    private Transform photo12;
    public bool isPhoto12 = false;

    // Wskazowki

    private Transform tip1;
    public bool isTip1 = false;
    private Transform tip2;
    public bool isTip2 = false;
    private Transform tip3;
    public bool isTip3 = false;
    private Transform tip4;
    public bool isTip4 = false;
    private Transform tip5;
    public bool isTip5 = false;
    private Transform tip6;
    public bool isTip6 = false;
    private Transform tip7;
    public bool isTip7 = false;
    private Transform tip8;
    public bool isTip8 = false;
    private Transform tip9;
    public bool isTip9 = false;
    private Transform tip10;
    public bool isTip10 = false;
    private Transform tip11;
    public bool isTip11 = false;
    private Transform tip12;
    public bool isTip12 = false;

    // teksty do jezykow
    public string uncleKeyName = "The Uncle's key"; // id 1
    public string uncleKeyDescription = "This key opens Uncle's room door next to bathroom";
    public string oilName = "Oil"; // 2
    public string oilDescription = "Helps fix a metal door";
    public string kitchenWardrobeKeyName = "Wardrobe Key"; //3
    public string kitchenWardrobeKeyDescription = "This key opens wardrobe in the kitchen";
    public string stableKeyName = "Stable Key"; //4
    public string stableKeyDescription = "Opens the door to Stable near big wooden shed";
    public string shedKeyName = "Shed Key"; //5
    public string shedKeyDescription = "Opens the door to wooden shed";
    public string batteriesName = "Batteries"; //6
    public string batteriesDescription = "Restore the power";
    public string cassete1Name = "Video Cassette 1"; //7
    public string cassete1Description = "#1"; 
    public string bone1Name = "Bone 1"; //8
    public string boneDescription = "It's Creepy...";
    public string nicheKeyName = "Old Key"; //9
    public string nicheKeyDescription = "Opens old wooden door in house";
    public string secretRoomKeyName = "Gold Key"; //10
    public string secretRoomKeyDescription = "Opens secret room in front of the hause";
    public string factoryKeyName = "Broken Key"; //11
    public string factoryKeyDescription = "Needs device to fix this";
    public string woodenWheelName = "Wooden Wheel"; //12
    public string woodenWheelDescription = "Part of a device";
    public string fixedKeyName = "Fixed Key"; //13
    public string fixedKeyDescription = "Opens the door to Victor's workshop";
    public string crowbarName = "Crowbar"; //14
    public string crowbarDescription = "Deal with metal";
    public string aliceKeyName = "Living Room Key"; //15
    public string aliceKeyDescription = "Opens door to living room in Alice's hause";
    public string pliersName = "Pliers"; //16
    public string pliersDescription = "Cuts wires";
    public string axeName = "Ax"; //17
    public string axeDescription = "Can destroy wooden boards";
    public string wardrobeCorridorKeyName = "Reliable Key"; //18
    public string wardrobeCorridorKeyDescription = "This key opens wardrobe in corridor";
    public string shedCupboardName = "Edward's Key"; //19
    public string shedCupboardDescription = "Opens a cupboard in Edward's shed";
    public string pumpkinName = "Pumpkin"; //20
    public string pumpkinDescription = "Missing element in Tom's camp";
    public string tomUpstairsKeyName = "Office Key"; //21
    public string tomUpstairsKeyDescription = "Opens door to Tom's Office";
    public string tomRoomKeyName = "Tom's Key"; //22
    public string tomRoomKeyDescription = "Opens door to Tom's room";
    public string chipName = "Electronic chip"; //23
    public string chipDescription = "Required in Player";
    public string oldWardrobeKeyName = "Thin key"; //24
    public string oldWardrobeKeyDescription = "Opens old wardrobe";
    public string stevenKeyName = "Steven's Key"; //25
    public string stevenKeyDescription = "Opens door to Steven's room";
    public string labPlantName = "Greenax plant"; //26
    public string labPlantDescription = "Can cut a human skin";
    public string labMushroomName = "Blue mushroom"; //27
    public string labMushroomDescription = "???";
    public string labSkullName = "Skull with meat"; //28
    public string labSkullDescription = "Disgusting...";
    public string strongAcidName = "Strong Acid"; //29
    public string strongAcidDescription = "Helps destroy monsters's gate";
    public string paulKeyName = "Secret Key"; //30
    public string paulKeyDescription = "Opens door in scientist's house";
    public string cassete2Name = "Video Cassette 2"; //31
    public string cassete2Description = "#2";
    public string cassete3Name = "Video Cassette 3"; //32
    public string cassete3Description = "#3";
    public string cassete4Name = "Video Cassette 4"; //33
    public string cassete4Description = "#4";
    public string bone2Name = "Bone 2"; //34
    public string bone3Name = "Bone 3"; //35
    public string bone4Name = "Bone 4"; //36
    public string bone5Name = "Bone 5"; //37
    public string defaultDescription = "Hover on an item to see the description"; 
    public string usingItemText = " is using now!";
    public string defaultUsingItemText = "Click on the item you want to use";
    
    // teksty do kolekcji

    public string[] collectionTitles;

    // tekst aktualny item

    public string currentItemText = "Item";

    // Do osiagniec Steam

    public int badgesCount = 0;
    public int tipsCount = 0;
    public int photosCount = 0;
    public int skillsCount = 0;

	void OnEnable(){

        itemIcons = new Image[9];
        itemIcons[0] = GameObject.Find("InventoryItem1").GetComponent<Image>();
        itemIcons[1] = GameObject.Find("InventoryItem2").GetComponent<Image>();
        itemIcons[2] = GameObject.Find("InventoryItem3").GetComponent<Image>();
        itemIcons[3] = GameObject.Find("InventoryItem4").GetComponent<Image>();
        itemIcons[4] = GameObject.Find("InventoryItem5").GetComponent<Image>();
        itemIcons[5] = GameObject.Find("InventoryItem6").GetComponent<Image>();
        itemIcons[6] = GameObject.Find("InventoryItem7").GetComponent<Image>();
        itemIcons[7] = GameObject.Find("InventoryItem8").GetComponent<Image>();
        itemIcons[8] = GameObject.Find("InventoryItem9").GetComponent<Image>();

        playerCam = Camera.main;

        playerManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
        player = GameObject.Find("Player").transform;
        mapScript = GameObject.Find("Player").GetComponent<Map>();
        beginGameScript = GameObject.Find("Player").GetComponent<BeginGame>();
        flashlightScript = GameObject.Find ("Latarka").GetComponent<Flashlight>();
		cursorScript = GameObject.Find ("Kamera").GetComponent<CrosshairGUI>();
		playerScript = GameObject.Find ("Player").GetComponent<Player>();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu>();
		animator = GameObject.Find ("Player").GetComponent<Animator>();
		tasksScript = GameObject.Find ("Player").GetComponent<Tasks>();
		bonesTaskScript = GameObject.Find ("KoliderKosci").GetComponent<TaskBones>();
		healthScript = GameObject.Find ("Player").GetComponent<Health>();
		notesScript = GameObject.Find ("Player").GetComponent<Notes>();
		SaveGameScript = GameObject.Find ("Player").GetComponent<SaveGame>();
		voiceActingScript = GameObject.Find ("Player").GetComponent<VoiceActing>();
		notificationScript = GameObject.Find ("Player").GetComponent<Notifications>();
		mixturesText = GameObject.Find ("OpisMikstur").GetComponent<TextMeshProUGUI> ();
		greenHerbsText = GameObject.Find ("ZieloneZiolaIlosc").GetComponent<Text>();
		blueHerbsText = GameObject.Find ("NiebieskieZiolaIlosc").GetComponent<Text>();
        vialsCountText = GameObject.Find("FiolkaIlosc").GetComponent<Text>();
        healthPotsText = GameObject.Find ("MiksturaZdrowieIlosc").GetComponent<Text> ();
		staminaPotsText = GameObject.Find ("MiksturaStaminaIlosc").GetComponent<Text> ();
		healthConditionText = GameObject.Find ("StanZdrowiaWartosc").GetComponent<TextMeshProUGUI> ();

		
		tasksCanvas = GameObject.Find ("CanvasTasks").GetComponent<Canvas>();
		notesCanvas = GameObject.Find ("CanvasNotatki").GetComponent<Canvas>();
		treatmentCanvas = GameObject.Find ("CanvasTreatment").GetComponent<Canvas>();
		noteDefaultCanvas = GameObject.Find ("CanvasNotatkaDefault").GetComponent<Canvas>();
        badgeCollectionCanvas = GameObject.Find("CanvasCollectionOdznaki").GetComponent<Canvas>();
        photoCollectionCanvas = GameObject.Find("CanvasCollectionFoto").GetComponent<Canvas>();
        tipCollectionCanvas = GameObject.Find("CanvasCollectionWskazowki").GetComponent<Canvas>();
        

		itemAudioSource1 = GameObject.Find ("ZrodloPrzedmiot_s").GetComponent<AudioSource>();      // klucze
		itemAudioSource2 = GameObject.Find ("ZrodloPrzedmiot2_s").GetComponent<AudioSource>();    // glosne
		itemAudioSource3 = GameObject.Find ("ZrodloPrzedmiot3_s").GetComponent<AudioSource>();    // srednie
		itemAudioSource4 = GameObject.Find ("ZrodloPrzedmiot4_s").GetComponent<AudioSource>();    // ciche
        pauseAudioSource = GameObject.Find("ZrodloPrzedmiotPause_s").GetComponent<AudioSource>();


        rockyGraveTextPointer = GameObject.Find ("SPGrobRockyPointer").GetComponent<Text>();
		animalCementaryTextPointer = GameObject.Find ("SPCmentarzZwierzatPointer").GetComponent<Text>();
		simonGardenTextPointer = GameObject.Find ("SPOgrodSimonaPointer").GetComponent<Text>();
		tomCampTextPointer = GameObject.Find ("SPObozTomaPointer").GetComponent<Text>();
		warCementaryTextPointer = GameObject.Find ("SPCmentarzWojnaPointer").GetComponent<Text>();
		hutTextPointer = GameObject.Find ("SPDomekPointer").GetComponent<Text>();
		basementTextPointer = GameObject.Find ("SPPiwnicaPointer").GetComponent<Text>();
		mushroomFieldTextPointer = GameObject.Find ("SPPoleGrzybowePointer").GetComponent<Text>();
		darkForestTextPointer = GameObject.Find ("SPCiemnyLasPointer").GetComponent<Text>();
		bonesTowerTextPointer = GameObject.Find ("SPWiezaKosciPointer").GetComponent<Text>();
		knifeArenaTextPointer = GameObject.Find ("SPNozowaArenaPointer").GetComponent<Text>();
		caveTextPointer = GameObject.Find ("SPJaskiniaPointer").GetComponent<Text>();
		monumentTextPointer = GameObject.Find ("SPPomnikPointer").GetComponent<Text>();
		spaceshipTextPointer = GameObject.Find ("SPStatekKosmicznyPointer").GetComponent<Text>();

		//DzwSkill1 = Resources.Load<AudioClip>("Muzyka/Skill");
		skill1_Icon = GameObject.Find ("InventorySkill1").GetComponent<Image>();
		skill2_Icon = GameObject.Find ("InventorySkill2").GetComponent<Image>();
		skill3_Icon = GameObject.Find ("InventorySkill3").GetComponent<Image>();
		skill4_Icon = GameObject.Find ("InventorySkill4").GetComponent<Image>();

		keyV1 = GameObject.Find("KluczPokojWO").transform;
		oil = GameObject.Find("OliwaItem").transform;
		keyV2 = GameObject.Find("KluczSzafkaKuchniaO").transform;
		keyV3 = GameObject.Find("KluczStajnia").transform;
		keyV4 = GameObject.Find("KluczSzopa").transform;
		batteries = GameObject.Find("BaterieO").transform;
		cassete1 = GameObject.Find("KasetaVideo1").transform;
		bone1 = GameObject.Find("KoscZad1").transform;
		bone2 = GameObject.Find("KoscZad2").transform;
		bone3 = GameObject.Find("KoscZad3").transform;
		bone4 = GameObject.Find("KoscZad4").transform;
		bone5 = GameObject.Find("KoscZad5").transform;
		nicheKey = GameObject.Find("KluczWneka").transform;
		secretRoomKey = GameObject.Find("KluczKamping").transform;
		brokenFactoryKey = GameObject.Find("KluczFabrykaBroken").transform;
		woodenWheel = GameObject.Find("BrakujaceDrewnianeKoloItem").transform;
        fixedKey = GameObject.Find("KluczNaprawiony").transform;
        aliceKey = GameObject.Find("KluczSalonPoludnie").transform;
		crowbar = GameObject.Find("Lom").transform;
		pliers = GameObject.Find("KombinerkiO").transform;
		axe = GameObject.Find("SiekieraZadanieO").transform;
		wardrobeCorridorKey = GameObject.Find("KluczSzafaKorytarz").transform;
		shedCupboardKey = GameObject.Find("KluczSzafkaSzopa").transform;
		cassete2 = GameObject.Find("KasetaVideo2").transform;
		tomRoomKey = GameObject.Find("KluczPokojTomO").transform;
		cassete3 = GameObject.Find("KasetaVideo3").transform;
		oldWardrobeKey = GameObject.Find("KluczSzafaStaryDom").transform;
		cassete4 = GameObject.Find("KasetaVideo4").transform;
		stevenKey = GameObject.Find("KluczStevena").transform;
		labPlant = GameObject.Find("RoslinaLab").transform;
		labMushroom = GameObject.Find("GrzybLab").transform;
		labSkull = GameObject.Find("CzaszkaLab").transform;
		paulKey = GameObject.Find("KluczPokojZachod").transform;
		pumpkin = GameObject.Find ("DyniaMisja").gameObject;
		tomUpstairsKey = GameObject.Find ("KluczTomGora").transform;
		chip = GameObject.Find ("ChipO").transform;
		strongAcid = GameObject.Find ("Mikstura").transform;

		//KluczTomGora.gameObject.SetActive (false);
		//Chip.gameObject.SetActive (false);

        // secret items

		secretItem1 = GameObject.Find("SecretItem1_1").transform;
		secretItem2 = GameObject.Find("SecretItem2_1").transform;
		secretItem3 = GameObject.Find("SecretItem1_2").transform;
		secretItem4 = GameObject.Find("SecretItem1_3").transform;
		secretItem5 = GameObject.Find("SecretItem2_2").transform;
		secretItem6 = GameObject.Find("SecretItem1_4").transform;
		secretItem7 = GameObject.Find("SecretItem2_3").transform;
		secretItem8 = GameObject.Find("SecretItem2_4").transform;
		secretItem9 = GameObject.Find("SecretItem1_5").transform;
		secretItem10 = GameObject.Find("SecretItem1_6").transform;
		secretItem11 = GameObject.Find("SecretItem2_5").transform;
		secretItem12 = GameObject.Find("SecretItem2_6").transform;
		secretItem13 = GameObject.Find("SecretItem1_7").transform;
		secretItem14 = GameObject.Find("SecretItem2_7").transform;
		secretItem15 = GameObject.Find("SecretItem1_8").transform;
		secretItem16 = GameObject.Find("SecretItem1_9").transform;
		secretItem17 = GameObject.Find("SecretItem2_8").transform;
		secretItem18 = GameObject.Find("SecretItem1_10").transform;
		secretItem19 = GameObject.Find("SecretItem1_11").transform;
		secretItem20 = GameObject.Find("SecretItem1_12").transform;
		secretItem21 = GameObject.Find("SecretItem2_9").transform;
		secretItem22 = GameObject.Find("SecretItem1_13").transform;
		secretItem23 = GameObject.Find("SecretItem2_10").transform;
		secretItem24 = GameObject.Find("SecretItem1_14").transform;
		secretItem25 = GameObject.Find("SecretItem1_15").transform;
        secretItem26 = GameObject.Find("SecretItem1_16").transform;
        secretItem27 = GameObject.Find("SecretItem1_17").transform;
        secretItem28 = GameObject.Find("SecretItem2_11").transform;
        secretItem29 = GameObject.Find("SecretItem2_12").transform;
        secretItem30 = GameObject.Find("SecretItem2_13").transform;
        secretItem31 = GameObject.Find("SecretItem2_14").transform;
        secretItem32 = GameObject.Find("SecretItem2_15").transform;

        // zioła

        greenHerb1 = GameObject.Find("ZieloneZiolo1").transform;
		greenHerb2 = GameObject.Find("ZieloneZiolo2").transform;
		greenHerb3 = GameObject.Find("ZieloneZiolo3").transform;
		greenHerb4 = GameObject.Find("ZieloneZiolo4").transform;
		greenHerb5 = GameObject.Find("ZieloneZiolo5").transform;
		greenHerb6 = GameObject.Find("ZieloneZiolo6").transform;
		greenHerb7 = GameObject.Find("ZieloneZiolo7").transform;
		greenHerb8 = GameObject.Find("ZieloneZiolo8").transform;
		greenHerb9 = GameObject.Find("ZieloneZiolo9").transform;
		greenHerb10 = GameObject.Find("ZieloneZiolo10").transform;
		greenHerb11 = GameObject.Find("ZieloneZiolo11").transform;
		greenHerb12 = GameObject.Find("ZieloneZiolo12").transform;
		greenHerb13 = GameObject.Find("ZieloneZiolo13").transform;
		greenHerb14 = GameObject.Find("ZieloneZiolo14").transform;
		greenHerb15 = GameObject.Find("ZieloneZiolo15").transform;
		greenHerb16 = GameObject.Find("ZieloneZiolo16").transform;
		greenHerb17 = GameObject.Find("ZieloneZiolo17").transform;
		greenHerb18 = GameObject.Find("ZieloneZiolo18").transform;
		greenHerb19 = GameObject.Find("ZieloneZiolo19").transform;
		greenHerb20 = GameObject.Find("ZieloneZiolo20").transform;
		greenHerb21 = GameObject.Find("ZieloneZiolo21").transform;
		greenHerb22 = GameObject.Find("ZieloneZiolo22").transform;
        greenHerb23 = GameObject.Find("ZieloneZiolo23").transform;
        greenHerb24 = GameObject.Find("ZieloneZiolo24").transform;
        greenHerb25 = GameObject.Find("ZieloneZiolo25").transform;
        greenHerb26 = GameObject.Find("ZieloneZiolo26").transform;
        greenHerb27 = GameObject.Find("ZieloneZiolo27").transform;
        greenHerb28 = GameObject.Find("ZieloneZiolo28").transform;
        greenHerb29 = GameObject.Find("ZieloneZiolo29").transform;
        greenHerb30 = GameObject.Find("ZieloneZiolo30").transform;
        greenHerb31 = GameObject.Find("ZieloneZiolo31").transform;
        greenHerb32 = GameObject.Find("ZieloneZiolo32").transform;

        blueHerb1 = GameObject.Find("NiebieskieZiolo1").transform;
		blueHerb2 = GameObject.Find("NiebieskieZiolo2").transform;
		blueHerb3 = GameObject.Find("NiebieskieZiolo3").transform;
		blueHerb4 = GameObject.Find("NiebieskieZiolo4").transform;
		blueHerb5 = GameObject.Find("NiebieskieZiolo5").transform;
		blueHerb5 = GameObject.Find("NiebieskieZiolo6").transform;
		blueHerb7 = GameObject.Find("NiebieskieZiolo7").transform;
		blueHerb8 = GameObject.Find("NiebieskieZiolo8").transform;
		blueHerb9 = GameObject.Find("NiebieskieZiolo9").transform;
		blueHerb10 = GameObject.Find("NiebieskieZiolo10").transform;
		blueHerb11 = GameObject.Find("NiebieskieZiolo11").transform;
		blueHerb12 = GameObject.Find("NiebieskieZiolo12").transform;
		blueHerb13 = GameObject.Find("NiebieskieZiolo13").transform;
		blueHerb14 = GameObject.Find("NiebieskieZiolo14").transform;
		blueHerb15 = GameObject.Find("NiebieskieZiolo15").transform;
		blueHerb16 = GameObject.Find("NiebieskieZiolo16").transform;
		blueHerb17 = GameObject.Find("NiebieskieZiolo17").transform;
		blueHerb18 = GameObject.Find("NiebieskieZiolo18").transform;
		blueHerb19 = GameObject.Find("NiebieskieZiolo19").transform;
		blueHerb20 = GameObject.Find("NiebieskieZiolo20").transform;
		blueHerb21 = GameObject.Find("NiebieskieZiolo21").transform;
		blueHerb22 = GameObject.Find("NiebieskieZiolo22").transform;
        blueHerb23 = GameObject.Find("NiebieskieZiolo23").transform;
        blueHerb24 = GameObject.Find("NiebieskieZiolo24").transform;
        blueHerb25 = GameObject.Find("NiebieskieZiolo25").transform;
        blueHerb26 = GameObject.Find("NiebieskieZiolo26").transform;
        blueHerb27 = GameObject.Find("NiebieskieZiolo27").transform;
        blueHerb28 = GameObject.Find("NiebieskieZiolo28").transform;
        blueHerb29 = GameObject.Find("NiebieskieZiolo29").transform;
        blueHerb30 = GameObject.Find("NiebieskieZiolo30").transform;
        blueHerb31 = GameObject.Find("NiebieskieZiolo31").transform;
        blueHerb32 = GameObject.Find("NiebieskieZiolo32").transform;


        // fiolki

        vial1 = GameObject.Find("Fiolka1").transform;
        vial2 = GameObject.Find("Fiolka2").transform;
        vial3 = GameObject.Find("Fiolka3").transform;
        vial4 = GameObject.Find("Fiolka4").transform;
        vial5 = GameObject.Find("Fiolka5").transform;
        vial6 = GameObject.Find("Fiolka6").transform;
        vial7 = GameObject.Find("Fiolka7").transform;
        vial8 = GameObject.Find("Fiolka8").transform;
        vial9 = GameObject.Find("Fiolka9").transform;
        vial10 = GameObject.Find("Fiolka10").transform;
        vial11 = GameObject.Find("Fiolka11").transform;
        vial12 = GameObject.Find("Fiolka12").transform;
        vial13 = GameObject.Find("Fiolka13").transform;
        vial14 = GameObject.Find("Fiolka14").transform;
        vial15 = GameObject.Find("Fiolka15").transform;
        vial16 = GameObject.Find("Fiolka16").transform;


        // mikstury

        staminaPot1 = GameObject.Find("EliksirStamina1").transform;
        staminaPot2 = GameObject.Find("EliksirStamina2").transform;
        staminaPot3 = GameObject.Find("EliksirStamina3").transform;
        staminaPot4 = GameObject.Find("EliksirStamina4").transform;
        staminaPot5 = GameObject.Find("EliksirStamina5").transform;

        healthPot1 = GameObject.Find("EliksirZdrowie1").transform;
        healthPot2 = GameObject.Find("EliksirZdrowie2").transform;
        healthPot3 = GameObject.Find("EliksirZdrowie3").transform;
        healthPot4 = GameObject.Find("EliksirZdrowie4").transform;
        healthPot5 = GameObject.Find("EliksirZdrowie5").transform;
        healthPot6 = GameObject.Find("EliksirZdrowie6").transform;

        // kolekcja tekstury

        collectionTextures = new Image[36];
        collectionTextures[0] = GameObject.Find("Odznaka1Image").GetComponent<Image>();
        collectionTextures[1] = GameObject.Find("Odznaka2Image").GetComponent<Image>();
        collectionTextures[2] = GameObject.Find("Odznaka3Image").GetComponent<Image>();
        collectionTextures[3] = GameObject.Find("Odznaka4Image").GetComponent<Image>();
        collectionTextures[4] = GameObject.Find("Odznaka5Image").GetComponent<Image>();
        collectionTextures[5] = GameObject.Find("Odznaka6Image").GetComponent<Image>();
        collectionTextures[6] = GameObject.Find("Odznaka7Image").GetComponent<Image>();
        collectionTextures[7] = GameObject.Find("Odznaka8Image").GetComponent<Image>();
        collectionTextures[8] = GameObject.Find("Odznaka9Image").GetComponent<Image>();
        collectionTextures[9] = GameObject.Find("Odznaka10Image").GetComponent<Image>();
        collectionTextures[10] = GameObject.Find("Odznaka11Image").GetComponent<Image>();
        collectionTextures[11] = GameObject.Find("Odznaka12Image").GetComponent<Image>();
        collectionTextures[12] = GameObject.Find("Foto1Image").GetComponent<Image>();
        collectionTextures[13] = GameObject.Find("Foto2Image").GetComponent<Image>();
        collectionTextures[14] = GameObject.Find("Foto3Image").GetComponent<Image>();
        collectionTextures[15] = GameObject.Find("Foto4Image").GetComponent<Image>();
        collectionTextures[16] = GameObject.Find("Foto5Image").GetComponent<Image>();
        collectionTextures[17] = GameObject.Find("Foto6Image").GetComponent<Image>();
        collectionTextures[18] = GameObject.Find("Foto7Image").GetComponent<Image>();
        collectionTextures[19] = GameObject.Find("Foto8Image").GetComponent<Image>();
        collectionTextures[20] = GameObject.Find("Foto9Image").GetComponent<Image>();
        collectionTextures[21] = GameObject.Find("Foto10Image").GetComponent<Image>();
        collectionTextures[22] = GameObject.Find("Foto11Image").GetComponent<Image>();
        collectionTextures[23] = GameObject.Find("Foto12Image").GetComponent<Image>();
        collectionTextures[24] = GameObject.Find("Wskazowki1Image").GetComponent<Image>();
        collectionTextures[25] = GameObject.Find("Wskazowki2Image").GetComponent<Image>();
        collectionTextures[26] = GameObject.Find("Wskazowki3Image").GetComponent<Image>();
        collectionTextures[27] = GameObject.Find("Wskazowki4Image").GetComponent<Image>();
        collectionTextures[28] = GameObject.Find("Wskazowki5Image").GetComponent<Image>();
        collectionTextures[29] = GameObject.Find("Wskazowki6Image").GetComponent<Image>();
        collectionTextures[30] = GameObject.Find("Wskazowki7Image").GetComponent<Image>();
        collectionTextures[31] = GameObject.Find("Wskazowki8Image").GetComponent<Image>();
        collectionTextures[32] = GameObject.Find("Wskazowki9Image").GetComponent<Image>();
        collectionTextures[33] = GameObject.Find("Wskazowki10Image").GetComponent<Image>();
        collectionTextures[34] = GameObject.Find("Wskazowki11Image").GetComponent<Image>();
        collectionTextures[35] = GameObject.Find("Wskazowki12Image").GetComponent<Image>();

        // odznaki

        badge1 = GameObject.Find("Odznaka1").transform;
        badge2 = GameObject.Find("Odznaka2").transform;
        badge3 = GameObject.Find("Odznaka3").transform;
        badge4 = GameObject.Find("Odznaka4").transform;
        badge5 = GameObject.Find("Odznaka5").transform;
        badge6 = GameObject.Find("Odznaka6").transform;
        badge7 = GameObject.Find("Odznaka7").transform;
        badge7 = GameObject.Find("Odznaka8").transform;
        badge9 = GameObject.Find("Odznaka9").transform;
        badge10 = GameObject.Find("Odznaka10").transform;
        badge11 = GameObject.Find("Odznaka11").transform;
        badge12 = GameObject.Find("Odznaka12").transform;

        // fotografie

        photo1 = GameObject.Find("Foto1").transform;
        photo2 = GameObject.Find("Foto2").transform;
        photo3 = GameObject.Find("Foto3").transform;
        photo4 = GameObject.Find("Foto4").transform;
        photo5 = GameObject.Find("Foto5").transform;
        photo6 = GameObject.Find("Foto6").transform;
        photo7 = GameObject.Find("Foto7").transform;
        photo8 = GameObject.Find("Foto8").transform;
        photo9 = GameObject.Find("Foto9").transform;
        photo10 = GameObject.Find("Foto10").transform;
        photo11 = GameObject.Find("Foto11").transform;
        photo12 = GameObject.Find("Foto12").transform;

        // wkazowki

        tip1 = GameObject.Find("Wskazowka1").transform;
        tip2 = GameObject.Find("Wskazowka2").transform;
        tip3 = GameObject.Find("Wskazowka3").transform;
        tip4 = GameObject.Find("Wskazowka4").transform;
        tip5 = GameObject.Find("Wskazowka5").transform;
        tip6 = GameObject.Find("Wskazowka6").transform;
        tip7 = GameObject.Find("Wskazowka7").transform;
        tip8 = GameObject.Find("Wskazowka8").transform;
        tip9 = GameObject.Find("Wskazowka9").transform;
        tip10 = GameObject.Find("Wskazowka10").transform;
        tip11 = GameObject.Find("Wskazowka11").transform;
        tip12 = GameObject.Find("Wskazowka12").transform;

        // Canvasy kolekcje z tablicy

        collectionCanvas = new Canvas[37];
        collectionCanvas[0] = GameObject.Find("CanvasCollectionDefault").GetComponent<Canvas>();
        collectionCanvas[1] = GameObject.Find("CanvasCollectionOdznaka1").GetComponent<Canvas>();
        collectionCanvas[2] = GameObject.Find("CanvasCollectionOdznaka2").GetComponent<Canvas>();
        collectionCanvas[3] = GameObject.Find("CanvasCollectionOdznaka3").GetComponent<Canvas>();
        collectionCanvas[4] = GameObject.Find("CanvasCollectionOdznaka4").GetComponent<Canvas>();
        collectionCanvas[5] = GameObject.Find("CanvasCollectionOdznaka5").GetComponent<Canvas>();
        collectionCanvas[6] = GameObject.Find("CanvasCollectionOdznaka6").GetComponent<Canvas>();
        collectionCanvas[7] = GameObject.Find("CanvasCollectionOdznaka7").GetComponent<Canvas>();
        collectionCanvas[8] = GameObject.Find("CanvasCollectionOdznaka8").GetComponent<Canvas>();
        collectionCanvas[9] = GameObject.Find("CanvasCollectionOdznaka9").GetComponent<Canvas>();
        collectionCanvas[10] = GameObject.Find("CanvasCollectionOdznaka10").GetComponent<Canvas>();
        collectionCanvas[11] = GameObject.Find("CanvasCollectionOdznaka11").GetComponent<Canvas>();
        collectionCanvas[12] = GameObject.Find("CanvasCollectionOdznaka12").GetComponent<Canvas>();
        collectionCanvas[13] = GameObject.Find("CanvasCollectionFoto1").GetComponent<Canvas>();
        collectionCanvas[14] = GameObject.Find("CanvasCollectionFoto2").GetComponent<Canvas>();
        collectionCanvas[15] = GameObject.Find("CanvasCollectionFoto3").GetComponent<Canvas>();
        collectionCanvas[16] = GameObject.Find("CanvasCollectionFoto4").GetComponent<Canvas>();
        collectionCanvas[17] = GameObject.Find("CanvasCollectionFoto5").GetComponent<Canvas>();
        collectionCanvas[18] = GameObject.Find("CanvasCollectionFoto6").GetComponent<Canvas>();
        collectionCanvas[19] = GameObject.Find("CanvasCollectionFoto7").GetComponent<Canvas>();
        collectionCanvas[20] = GameObject.Find("CanvasCollectionFoto8").GetComponent<Canvas>();
        collectionCanvas[21] = GameObject.Find("CanvasCollectionFoto9").GetComponent<Canvas>();
        collectionCanvas[22] = GameObject.Find("CanvasCollectionFoto10").GetComponent<Canvas>();
        collectionCanvas[23] = GameObject.Find("CanvasCollectionFoto11").GetComponent<Canvas>();
        collectionCanvas[24] = GameObject.Find("CanvasCollectionFoto12").GetComponent<Canvas>();
        collectionCanvas[25] = GameObject.Find("CanvasCollectionWskazowka1").GetComponent<Canvas>();
        collectionCanvas[26] = GameObject.Find("CanvasCollectionWskazowka2").GetComponent<Canvas>();
        collectionCanvas[27] = GameObject.Find("CanvasCollectionWskazowka3").GetComponent<Canvas>();
        collectionCanvas[28] = GameObject.Find("CanvasCollectionWskazowka4").GetComponent<Canvas>();
        collectionCanvas[29] = GameObject.Find("CanvasCollectionWskazowka5").GetComponent<Canvas>();
        collectionCanvas[30] = GameObject.Find("CanvasCollectionWskazowka6").GetComponent<Canvas>();
        collectionCanvas[31] = GameObject.Find("CanvasCollectionWskazowka7").GetComponent<Canvas>();
        collectionCanvas[32] = GameObject.Find("CanvasCollectionWskazowka8").GetComponent<Canvas>();
        collectionCanvas[33] = GameObject.Find("CanvasCollectionWskazowka9").GetComponent<Canvas>();
        collectionCanvas[34] = GameObject.Find("CanvasCollectionWskazowka10").GetComponent<Canvas>();
        collectionCanvas[35] = GameObject.Find("CanvasCollectionWskazowka11").GetComponent<Canvas>();
        collectionCanvas[36] = GameObject.Find("CanvasCollectionWskazowka12").GetComponent<Canvas>();

        badgeCollectionTitleText = GameObject.Find("TytulCollectionOdznaki").GetComponent<TextMeshProUGUI>();
        photoCollectionTitleText = GameObject.Find("TytulCollectionFoto").GetComponent<TextMeshProUGUI>();
        tipCollectionTitleText = GameObject.Find("TytulCollectionWskazowki").GetComponent<TextMeshProUGUI>();

        // tablica tekstow do kolekcji
        collectionTitles = new string[39];
        collectionTitles[0] = "Badges";
        collectionTitles[1] = "Photos";
        collectionTitles[2] = "Tips";
        collectionTitles[3] = "Fresh Blood Badge";
        collectionTitles[4] = "Sun Badge ";
        collectionTitles[5] = "Nature Badge";
        collectionTitles[6] = "A Badge Of Endurance";
        collectionTitles[7] = "Heaven Badge";
        collectionTitles[8] = "War Badge";
        collectionTitles[9] = "Infinity Badge";
        collectionTitles[10] = "A Badge Of Holiness";
        collectionTitles[11] = "Death Badge";
        collectionTitles[12] = "Badge Of Life ";
        collectionTitles[13] = "Combat Badge";
        collectionTitles[14] = "Fire Badge";
        collectionTitles[15] = "Old photo 1";
        collectionTitles[16] = "Old photo 2";
        collectionTitles[17] = "Old photo 3";
        collectionTitles[18] = "Old photo 4";
        collectionTitles[19] = "Old photo 5";
        collectionTitles[20] = "Old photo 6";
        collectionTitles[21] = "Old photo 7";
        collectionTitles[22] = "Old photo 8";
        collectionTitles[23] = "Old photo 9";
        collectionTitles[24] = "Old photo 10";
        collectionTitles[25] = "Old photo 11";
        collectionTitles[26] = "Old photo 12";
        collectionTitles[27] = "Tip 1";
        collectionTitles[28] = "Tip 2";
        collectionTitles[29] = "Tip 3";
        collectionTitles[30] = "Tip 4";
        collectionTitles[31] = "Tip 5";
        collectionTitles[32] = "Tip 6";
        collectionTitles[33] = "Tip 7";
        collectionTitles[34] = "Tip 8";
        collectionTitles[35] = "Tip 9";
        collectionTitles[36] = "Tip 10";
        collectionTitles[37] = "Tip 11";
        collectionTitles[38] = "Tip 12";

        mixturesText.text = defaultPotDescription;

        // aktualny przedmiot

        uiCanvas = GameObject.Find("CanvasUI").GetComponent<Canvas>();
        currenntItemTitle = GameObject.Find("AktualnyItemTytul").GetComponent<TextMeshProUGUI>();
        currentItemIcon = GameObject.Find("AktualnyItem").GetComponent<Image>();

        // do scrollbara notatek

        notesScrollRect = GameObject.Find("ListaNotatek").GetComponent<ScrollRect>();
        notesScrollbar = GameObject.Find("NotatkiScrollbar").GetComponent<Scrollbar>();

    }

	void Update () {

        if (Time.timeScale == 0)
        {
            uiCanvas.enabled = false;
        }
        else if(Time.timeScale == 1 && beginGameScript.enabled == false)
        {
            uiCanvas.enabled = true;
        }

        CheckHealthCondition ();

		if(Input.GetButtonDown("Inventory") && playerManagerScript.isPlayerCanInput == true)
        {

            ShowInventory();

			Time.timeScale = 0;
			cursorScript.m_ShowCursor = true; 
            playerScript.audioSource.Pause();
			playerScript.enabled = false;
            pauseAudioSource.pitch = 1;
            pauseAudioSource.PlayOneShot (openInventorySound);
			
		}
         

        else if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isInventoryActive == true)
        {
            inventoryUI.InventoryBackFunction();
        }

        else if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isTasksActive == true)
        {
            tasksUI.TasksBackFunction();
        }

        else if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isNotesActive == true)
        {
            notesUI.NotesBackFunction();
        }

        else if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isTreatmentActive == true)
        {
            treatmentUI.TreatmentBackFunction();
        }

        else if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isCollectionActive == true)
        {
            collectionBadgesUI.CollectionBackFunction();
        }

        else if(gameMenuScript.isMenu == true){
			cursorScript.m_ShowCursor = true; // !Kursor.m_ShowCursor
		}


        //------------------PODNOSZENIE PRZEDMIOTOW----------------------

        if (Input.GetMouseButtonDown(0) && playerManagerScript.isPlayerCanInput == true)
        {
			Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)){

			// Podnoszenie klucza do drzwi pokoju U


			if(hit.collider.gameObject.tag == "TaskItem"){
                    hit.transform.gameObject.GetComponent<TaskItem>().PickUpItem();
			}

			else if (hit.collider.gameObject.tag == "CollectibleItem") {
                    hit.transform.gameObject.GetComponent<CollectibleItem>().PickUpItem();
                }

			if (hit.collider.gameObject.tag == "Save") {
					SaveGameScript.Zapisz ();
			}

		} // Klamra do Raycast

	} // Klamra do warunku przycisku	

		//-------------USUWANIE PRZEDMIOTOW Z EKWIPUNKU----------------------------------

		// Usuwanie klucza do pokoju U
		if(tasksScript.isUncleDoorLocked == false && isKeyV1Removed == false){
			RemoveItem(allItems[0], isKeyV1Removed);
		}

		// Usuwanie klucza do szafki w kuchni
		if(tasksScript.isKitchenWardrobeLocked == false && isKeyV2Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do drzwi stajni

		if(tasksScript.isStableDoorLocked == false && isKeyV3Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do drzwi szopy

		if(tasksScript.isToolShedDoorLocked == false && isKeyV4Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed); ;
		}

		// Usuwanie Oliwy przy drzwiach w ogrodzie

		if(tasksScript.isGardenDoorLocked == false && isOilRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do wneki

		if(tasksScript.isNicheDoorLocked == false && isNicheKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie kosci 1

		if(bonesTaskScript.isBone1 == true && isBone1Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie kosci 2

		if(bonesTaskScript.isBone2 == true && isBone2Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie kosci 3

		if(bonesTaskScript.isBone3 == true && isBone3Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie kosci 4

		if(bonesTaskScript.isBone4 == true && isBone4Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie kosci 5

		if(bonesTaskScript.isBone5 == true && isBone5Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do kampingu

		if(tasksScript.isSecretRoomDoorLocked == false && isSecretRoomKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie kasety 1

		if(tasksScript.isCasseteInserted == true && isCassete1Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie baterii

		if(tasksScript.isBatteriesPut == true && isBatteriesRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie zepsutego klucza

		if(tasksScript.isBrokenKey == true && isBrokenFactoryKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie brakujacego kola

		if(tasksScript.isWheel == true && isWoodenWheelRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie naprawionego klucza

		if(tasksScript.isFactoryWoodenDoorLocked == false && isFixedKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie lomu

		if(tasksScript.isFactoryMetalDoorLocked == false && isCrowbarRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do salonu na poludniu domu Alice

		if(tasksScript.isAliceRoomDoorLocked == false && isAliceKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie kombinerek

		if(tasksScript.isCornfieldDoorLocked == false && isPliersRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie Siekiery

		if(tasksScript.isPlanksLocked == false && isAxeRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do szafy w korytarzu

		if(tasksScript.isCorridorWardrobeLocked == false && isWardrobeCorridorKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do szafki w szopie

		if(tasksScript.isShedCupboardLocked == false && isShedCupboardKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie kasety 2

		if(tasksScript.isCassete2Inserted == true && isCassete2Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie dyni

		if(tasksScript.isPumpkin == true && isPumpkinRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do pokoju Toma na gorze

		if(tasksScript.isTomUpstairsDoorLocked == false && isTomUpstairsKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do pokoju Toma

		if(tasksScript.isTomRoomDoorLocked == false && isTomRoomKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie kasety 3

		if(tasksScript.isCassete3Inserted == true && isCassete3Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie chipu

		if(tasksScript.isChipPut == true && isChipRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do szafy w opuszczonym domu

		if(tasksScript.isOldWardrobeLocked == false && isOldWardrobeKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie kasety 4

		if(tasksScript.isCassete4Inserted == true && isCassete4Removed == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza do pokoju Stevena

		if(tasksScript.isStevenDoorLocked == false && isStevenKeyRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie rosliny

		if(tasksScript.isLabPlant == true && isLabPlantRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie grzyba

		if(tasksScript.isLabMushroom == true && isLabMushroomRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie czaszki

		if(tasksScript.isLabSkull == true && isLabSkullRemoved == false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

		// Usuwanie klucza w pokoju na zachodzie

		if(tasksScript.isPaulDoorLocked == false && isPaulKeyRemoved== false){
            RemoveItem(allItems[0], isKeyV1Removed);
        }

        // Usuwanie mikstury

		if (tasksScript.isThornsAcid == true && isStrongAcidRemoved == false)
        {
            RemoveItem(allItems[0], isKeyV1Removed);
        }


    } // Klamra do Update
		
	void OnTriggerEnter(Collider other){

		// secret place grob rocky

		if(other.gameObject.CompareTag("GrobRocky_trigger") && isRockyGraveSP == false ){
			DiscoverRockyGrave ();
		}

		// secret place cmentarz zwierzat

		else if(other.gameObject.CompareTag("CmentarzZwierzat_trigger") && isAnimalCementarySP == false ){
			DiscoverAnimalCemetery ();
		}

		// secret place ogrod simona

		else if(other.gameObject.CompareTag("OgrodSimona_trigger") && isSimonGardenSP == false ){
			DiscoverSimonGarden ();
		}

		// secret place oboz Toma

		else if(other.gameObject.CompareTag("ObozToma_trigger") && isTomCampSP == false ){
			DiscoverTomCamp ();
		}

		// secret place kryjowka diablow

		else if(other.gameObject.CompareTag("KryjowkaDiablow_trigger") && isDevilsShelterSP == false ){
			DiscoverDevilsShelter ();
		}

		// secret place cmentarz wojna

		else if(other.gameObject.CompareTag("CmentarzWojna_trigger") && isWarCementarySP == false ){
			DiscoverWarCemetery ();
		}

		// secret place domek 

		else if(other.gameObject.CompareTag("Domek_trigger") && isHutSP == false ){
			DiscoverHut ();
		}

		// secret place opuszczona piwnica 

		else if(other.gameObject.CompareTag("Piwnica_trigger") && isBasementSP == false ){
			DiscoverAbandonedBasement ();
		}

		// secret place pole grzybowe 

		else if(other.gameObject.CompareTag("PoleGrzybowe_trigger") && isMushroomFieldSP == false ){
			DiscoverMushroomField ();
		}

		// secret place ciemny las 

		else if(other.gameObject.CompareTag("CiemnyLas_trigger") && isDarkForestSP == false ){
			DiscoverDarkForest ();
		}

		// secret place wieza kosci 

		else if(other.gameObject.CompareTag("WiezaKosci_trigger") && isBonesTowerSP == false ){
			DiscoverBonesTower ();
		}

		// secret place Nozowa arena 

		else if(other.gameObject.CompareTag("NozowaArena_trigger") && isKnifeArenaSP == false ){
			DiscoverKnifeArena ();
		}

		// secret place jaskinia

		else if(other.gameObject.CompareTag("Jaskinia_trigger") && isCaveSP == false ){
			DiscoverCave ();
		}

		// secret stary pomnik

		else if(other.gameObject.CompareTag("Pomnik_trigger") && isMonumentSP == false ){
			DiscoverMonument ();
		}

		// secret statek kosmiczny

		else if(other.gameObject.CompareTag("StatekKosmiczny_trigger") && isSpaceshipSP == false ){
			DiscoverSpaceship ();
		}

	}

    // Wlaczanie panelu

    public void ShowInventory()
    {

        if (Time.timeScale == 0)
        {
            itemAudioSource3.PlayOneShot(menuButtonSound);
        }


        inventoryCanvas.enabled = true;
        isInventoryActive = true;
        tasksCanvas.enabled = false;
        isTasksActive = false;
        notesCanvas.enabled = false;
        isNotesActive = false;
        treatmentCanvas.enabled = false;
        isTreatmentActive = false;
        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;
        isCollectionActive = false;

        noteDefaultCanvas.enabled = false;

        for (int i = 0; i < notesScript.notesCanvas2.Length; i++)
        {
            notesScript.notesCanvas2[i].enabled = false;
        }

        for (int i = 0; i < collectionCanvas.Length; i++)
        {
            collectionCanvas[i].enabled = false;
        }

        notificationScript.taskHintTime = 5f;

    }

    //-------------- Funkcje do Secret Places----------------------------

    void DiscoverRockyGrave(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = rockyGraveText;
		rockyGraveTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
		secretPlacesCount++;
		isRockyGraveSP = true;
		
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverAnimalCemetery(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = animalCemeteryText;
		animalCementaryTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isAnimalCementarySP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverSimonGarden(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = simonGardenText;
		simonGardenTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isSimonGardenSP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverTomCamp(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = tomCampText;
		tomCampTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isTomCampSP = true;
		//secretPlacesText.text = secretPlacesCount + "/15";
		
	}

	void DiscoverDevilsShelter(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = devilsShelterText;
        //SPKryjowkaDiablyPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isDevilsShelterSP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverWarCemetery(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = warCemeteryText;
		warCementaryTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isWarCementarySP = true;
		//secretPlacesText.text = secretPlacesCount + "/15";

	}

	void DiscoverHut(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = hutText;
		hutTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isHutSP = true;
		//secretPlacesText.text = secretPlacesCount + "/15";
		
	}

	void DiscoverAbandonedBasement(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = abandonedBasementText;
		basementTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isBasementSP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverMushroomField(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = mushroomFieldText;
		mushroomFieldTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isMushroomFieldSP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverDarkForest(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = darkForestText;
		darkForestTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isDarkForestSP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverBonesTower(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = bonesTowerText;
		bonesTowerTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isBonesTowerSP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverKnifeArena(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = knifeArenaText;
		knifeArenaTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isKnifeArenaSP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverCave(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = caveText;
		caveTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isCaveSP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverMonument(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = monumentText;
		monumentTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isMonumentSP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}

	void DiscoverSpaceship(){
		notificationScript.secretPlacesTime = 0f;
		notificationScript.secretPlacesNotificationTextMesh.text = spaceshipText;
		spaceshipTextPointer.enabled = true;
        itemAudioSource4.clip = secretPlaceSound;
        itemAudioSource4.Play();
        secretPlacesCount++;
		isSpaceshipSP = true;
		SaveGameScript.Zapisz ();
		//secretPlacesText.text = secretPlacesCount + "/15";
	}


	//-------------- Funckje dodawania przedmiotow-----------------------

   public void AddItem(Item item, AudioClip pickUpSound)
    {
        //itemTransform.gameObject.SetActive(false);
        animator.SetTrigger("PickUp");
        itemAudioSource1.PlayOneShot(pickUpSound);

        for (int i = 0; i < itemIcons.Length; i++)
        {
            if (itemIcons[i].sprite == null)
            {
                items.Add(item);
                item.isTaken = true;
                item.id = i + 1;
                itemIcons[i].sprite = item.icon;
                itemIcons[i].color = Color.white;
                break;
            }
        }
    }

	void AddKeyV1(){
		keyV1.gameObject.SetActive(false);
		isKeyV1Taken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i+1, "KluczPokojW", uncleKeyName, uncleKeyDescription, keyV1Icon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = keyV1Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        if(notificationScript.isInventoryNotification == false)
        {
            notificationScript.KomunikatSamouczekInventory();
        }

	}

	void AddOil(){
		oil.gameObject.SetActive(false);
		isOilTaken = true;
		itemAudioSource1.PlayOneShot(oilSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i+1, "Oliwa", oilName, oilDescription, oilIcon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = oilIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        tasksScript.ZadanieDrzwiOgrod();

	}

	void AddKitchenWardrobeKey(){
		keyV2.gameObject.SetActive(false);
		isKeyV2Taken = true;
		itemAudioSource1.PlayOneShot(keySound2);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczSzafkaKuchnia", kitchenWardrobeKeyName, kitchenWardrobeKeyDescription, keyV2Icon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = keyV2Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        if (notificationScript.isInventoryNotification == false)
        {
            notificationScript.KomunikatSamouczekInventory();
        }

        tasksScript.RemoveKluczWychodekPointer();

    }

	void AddShedKey(){
		keyV4.gameObject.SetActive(false);
		isKeyV4Taken = true;
		itemAudioSource1.PlayOneShot(keySound2);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczSzopa", shedKeyName, shedKeyDescription, keyV4Icon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = keyV4Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}


        tasksScript.AddSzopaNarzedziaPointer();
        

    }

	void AddBone3(){
		bone3.gameObject.SetActive(false);
		isBone3Taken = true;
		itemAudioSource1.PlayOneShot(boneSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kosc3", bone3Name, boneDescription, bone3Icon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = bone3Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        if (notificationScript.isInventoryNotification == false)
        {
            notificationScript.KomunikatSamouczekInventory();
        }

        tasksScript.RemoveKoscSzopaPointer();

    }

	void AddBone4(){
		bone4.gameObject.SetActive(false);
		isBone4Taken = true;
		itemAudioSource1.PlayOneShot(boneSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kosc4", bone3Name, boneDescription, bone4Icon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = bone4Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        if (notificationScript.isInventoryNotification == false)
        {
            notificationScript.KomunikatSamouczekInventory();
        }

        tasksScript.RemoveKoscStajniaPointer();

    }

	void AddSecretRoomKey(){
		secretRoomKey.gameObject.SetActive(false);
		isSecretRoomKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczKamping", secretRoomKeyName, secretRoomKeyDescription, secretRoomKeyIcon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = secretRoomKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        tasksScript.AddSekretnyPokojPointer();

	}

	void AddPliers(){
		itemAudioSource3.PlayOneShot(pliersSound);
		pliers.transform.gameObject.SetActive(false);
		isPliersTaken = true;
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kombinerki", pliersName, pliersDescription, pliersIcon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = pliersIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        voiceActingScript.GlosKombinerki();

    }

	void AddAxe(){
		itemAudioSource1.PlayOneShot(axeSound);
		axe.gameObject.SetActive(false);
		isAxeTaken = true;
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Siekiera", axeName, axeDescription, axeIcon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = axeIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        voiceActingScript.GlosSiekiera();
    }


	void AddCassete2(){
		cassete2.gameObject.SetActive(false);
		isCassete2Taken = true;
		itemAudioSource1.PlayOneShot(casseteSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kaseta2", cassete2Name, cassete2Description, cassete2Icon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = cassete2Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        tasksScript.RemoveSzafkaEdwardPointer();

	}

	void AddStrongAcid(){
		strongAcid.gameObject.SetActive(false);
		isStrongAcidTaken = true;
		itemAudioSource1.PlayOneShot(oilSound);
		
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Mikstura", strongAcidName, strongAcidDescription, strongAcidIcon, false, isKeyV1Taken, isKeyV1Taken));
				itemIcons[i].sprite = strongAcidIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        voiceActingScript.GlosEliksir();

    }

   public void AddSecretItem(AudioClip secretItemSound)
    {
        itemAudioSource1.PlayOneShot(secretItemSound);
        secretItemsCount++;
        notificationScript.secretItemsTime = 0;
        notificationScript.isSecretItemNotification = true;
        notificationScript.isGreenHerbNotification = false;
        notificationScript.isBlueHerbNotification = false;
        notificationScript.isVialNotification = false;
        notificationScript.isBadgeNotification = false;
        notificationScript.isPhotoNotification = false;
        notificationScript.isTipNotification = false;
        notificationScript.isStaminaPotNotification = false;
        notificationScript.isHealthPotNotification = false;
        animator.SetTrigger("PickUp");
    }

	public void AddGreenHerb(AudioClip greenHerbSound){
		itemAudioSource2.PlayOneShot (collectHerbSound);
		greenHerbsCount++;
		notificationScript.secretItemsTime = 0;
		notificationScript.isGreenHerbNotification = true;
		notificationScript.isSecretItemNotification = false;
		notificationScript.isBlueHerbNotification = false;
        notificationScript.isVialNotification = false;
        notificationScript.isBadgeNotification = false;
        notificationScript.isPhotoNotification = false;
        notificationScript.isTipNotification = false;
        notificationScript.isStaminaPotNotification = false;
        notificationScript.isHealthPotNotification = false;
        animator.SetTrigger ("PickUp");
		greenHerbsText.text = greenHerbsCount + "";
	}

	public void AddBlueHerb(AudioClip blueHerbSound)
    {
		itemAudioSource2.PlayOneShot (collectHerbSound);
		blueHerbsCount++;
		notificationScript.secretItemsTime = 0;
		notificationScript.isBlueHerbNotification = true;
		notificationScript.isSecretItemNotification = false;
		notificationScript.isGreenHerbNotification = false;
        notificationScript.isVialNotification = false;
        notificationScript.isBadgeNotification = false;
        notificationScript.isPhotoNotification = false;
        notificationScript.isTipNotification = false;
        notificationScript.isStaminaPotNotification = false;
        notificationScript.isHealthPotNotification = false;
        animator.SetTrigger ("PickUp");
		blueHerbsText.text = blueHerbsCount + "";
	}

    public void AddVial(AudioClip vialSound) {

        itemAudioSource2.PlayOneShot(collectVialSound);
        vialsCount++;
        notificationScript.secretItemsTime = 0;
        notificationScript.isVialNotification = true;
        notificationScript.isSecretItemNotification = false;
        notificationScript.isGreenHerbNotification = false;
        notificationScript.isBlueHerbNotification = false;
        notificationScript.isBadgeNotification = false;
        notificationScript.isPhotoNotification = false;
        notificationScript.isTipNotification = false;
        notificationScript.isStaminaPotNotification = false;
        notificationScript.isHealthPotNotification = false;
        animator.SetTrigger("PickUp");
        vialsCountText.text = vialsCount + "";
    }

    public void AddStaminaPot(AudioClip staminaPotSound)
    {

        itemAudioSource2.PlayOneShot(collectVialSound);
        staminaPotsCount++;
        notificationScript.secretItemsTime = 0;
        notificationScript.isVialNotification = false;
        notificationScript.isSecretItemNotification = false;
        notificationScript.isGreenHerbNotification = false;
        notificationScript.isBlueHerbNotification = false;
        notificationScript.isBadgeNotification = false;
        notificationScript.isPhotoNotification = false;
        notificationScript.isTipNotification = false;
        notificationScript.isStaminaPotNotification = true;
        notificationScript.isHealthPotNotification = false;
        animator.SetTrigger("PickUp");
        staminaPotsText.text = staminaPotsCount + "";
    }

    public void AddHealthPot(AudioClip HealthPotSound)
    {

        itemAudioSource2.PlayOneShot(collectVialSound);
        healthPotsCount++;
        notificationScript.secretItemsTime = 0;
        notificationScript.isVialNotification = false;
        notificationScript.isSecretItemNotification = false;
        notificationScript.isGreenHerbNotification = false;
        notificationScript.isBlueHerbNotification = false;
        notificationScript.isBadgeNotification = false;
        notificationScript.isPhotoNotification = false;
        notificationScript.isTipNotification = false;
        notificationScript.isStaminaPotNotification = false;
        notificationScript.isHealthPotNotification = true;
        animator.SetTrigger("PickUp");
        healthPotsText.text = healthPotsCount + "";
    }

    public void AddBadge(AudioClip badgeSound, Image badgeTexture)
    {
        itemAudioSource3.pitch = Random.Range(0.8f, 1.5f);
        itemAudioSource3.PlayOneShot(collectItemSound);
        itemAudioSource3.pitch = 1;
        notificationScript.secretItemsTime = 0;
        notificationScript.isVialNotification = false;
        notificationScript.isSecretItemNotification = false;
        notificationScript.isGreenHerbNotification = false;
        notificationScript.isBlueHerbNotification = false;
        notificationScript.isBadgeNotification = true;
        notificationScript.isPhotoNotification = false;
        notificationScript.isTipNotification = false;
        notificationScript.isStaminaPotNotification = false;
        notificationScript.isHealthPotNotification = false;
        animator.SetTrigger("PickUp");
        badgeTexture.sprite = badgeOKSprite;
        badgesCount++;
    }

   public void AddPhoto(AudioClip photoSound, Image photoTexture)
    {
        itemAudioSource3.pitch = Random.Range(0.8f, 1.5f);
        itemAudioSource3.PlayOneShot(collectItemSound);
        itemAudioSource3.pitch = 1;
        notificationScript.secretItemsTime = 0;
        notificationScript.isVialNotification = false;
        notificationScript.isSecretItemNotification = false;
        notificationScript.isGreenHerbNotification = false;
        notificationScript.isBlueHerbNotification = false;
        notificationScript.isBadgeNotification = false;
        notificationScript.isPhotoNotification = true;
        notificationScript.isTipNotification = false;
        notificationScript.isStaminaPotNotification = false;
        notificationScript.isHealthPotNotification = false;
        animator.SetTrigger("PickUp");
        photoTexture.sprite = photoOKSprite;
        photosCount++;
    }

    public void AddTip(AudioClip TipSound, Image tipTexture)
    {
        itemAudioSource3.pitch = Random.Range(0.8f, 1.5f);
        itemAudioSource3.PlayOneShot(collectItemSound);
        itemAudioSource3.pitch = 1;
        notificationScript.secretItemsTime = 0;
        notificationScript.isVialNotification = false;
        notificationScript.isSecretItemNotification = false;
        notificationScript.isGreenHerbNotification = false;
        notificationScript.isBlueHerbNotification = false;
        notificationScript.isBadgeNotification = false;
        notificationScript.isPhotoNotification = false;
        notificationScript.isTipNotification = true;
        notificationScript.isStaminaPotNotification = false;
        notificationScript.isHealthPotNotification = false;
        animator.SetTrigger("PickUp");
        tipTexture.sprite = tipOKSprite;
        tipsCount++;
    }

    // ------------- Funkcje do usuwania przedmiotow----------------------

    void RemoveItem(Item item, bool isItemRemoved)
    {
        for (int i = 0; i < itemIcons.Length; i++)
        {
            if (itemIcons[i].sprite == item.icon)
            {
                items.Remove(item);
                itemIcons[i].sprite = null;
                itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isItemRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
            }
        }
    }

	// ------------- Funkcje GUI Canvas ----------------------------------

    // do health script ?

    public void CheckHealthCondition()
    {

        if (healthScript.health >= 70 && playerScript.isRest == true)
        {
            healthConditionText.text = stateGoodText;
        }
        else if (healthScript.health > 40 && healthScript.health < 70)
        {
            healthConditionText.text = stateInjuredText;
        }
        else if (healthScript.health <= 40)
        {
            healthConditionText.text = stateCriticalText;
        }
        else if (healthScript.health >= 70 && playerScript.isRest == false)
        {
            healthConditionText.text = stateTiredText;
        }

    }

    // Funkcje do kolekcji

    public void CollectionOdznaki() {

        collectionCanvas[0].enabled = false;

        inventoryCanvas.enabled = false;
        isInventoryActive = false;
        tasksCanvas.enabled = false;
        isTasksActive = false;
        notesCanvas.enabled = false;
        isNotesActive = false;
        treatmentCanvas.enabled = false;
        isTreatmentActive = false;
        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;
        isCollectionActive = true;

        noteDefaultCanvas.enabled = false;

        itemAudioSource3.PlayOneShot(menuButtonSound);

        foreach(var collCanvas in collectionCanvas)
        {
            collCanvas.enabled = false;
        }

        collectionCanvas[0].enabled = true;
        badgeCollectionTitleText.text = collectionTitles[0];

    }

    public void CollectionFoto()
    {

        collectionCanvas[0].enabled = false;

        isCollectionActive = true;

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        itemAudioSource3.PlayOneShot(menuButtonSound);

        foreach (var collCanvas in collectionCanvas)
        {
            collCanvas.enabled = false;
        }

        collectionCanvas[0].enabled = true;
        photoCollectionTitleText.text = collectionTitles[1];

    }

    public void CollectionWskazowki()
    {

        collectionCanvas[0].enabled = false;

        isCollectionActive = true;

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        itemAudioSource3.PlayOneShot(menuButtonSound);

        foreach (var collCanvas in collectionCanvas)
        {
            collCanvas.enabled = false;
        }

        collectionCanvas[0].enabled = true;
        tipCollectionTitleText.text = collectionTitles[2];

    }

    public void HoverButton(){

		itemAudioSource3.PlayOneShot (itemDesciptionSound);

	}

}


