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
            //Panel.enabled = true;

            ShowInventory();

			Time.timeScale = 0;
			//Panel_ok = true;
			cursorScript.m_ShowCursor = true; // !Kursor.m_ShowCursor
            playerScript.audioSource.Pause();
			playerScript.enabled = false;
            pauseAudioSource.pitch = 1;
            pauseAudioSource.PlayOneShot (openInventorySound);
			//Ekwpnk.enabled = false;
			//Ekwipunek_ok = false;
		}//else if((Input.GetButtonDown("Ekwipunek") || Input.GetButtonDown("Cancel"))  && Panel_ok == true){
         //BackFunction();
         //}

        else if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isInventoryActive == true)
        {
            InventoryBackFunction();
        }

        else if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isTasksActive == true)
        {
            TasksBackFunction();
        }

        else if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isNotesActive == true)
        {
            NotesBackFunction();
        }

        else if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isTreatmentActive == true)
        {
            TreatmentBackFunction();
        }

        else if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isCollectionActive == true)
        {
            CollectionBackFunction();
        }

        else if(gameMenuScript.isMenu == true){
			cursorScript.m_ShowCursor = true; // !Kursor.m_ShowCursor
		}


        //------------------PODNOSZENIE PRZEDMIOTOW----------------------

        if (Input.GetMouseButtonDown(0) && playerManagerScript.isPlayerCanInput == true)
        {

			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)){
	    // Debug.Log (hit.collider.gameObject.name);

			// Podnoszenie klucza do drzwi pokoju U


			if(hit.collider.gameObject.name == "KluczPokojW"){
				AddKeyV1 ();
			}

			// Podnoszenie oliwy do drzwi w ogrodzie

			else if(hit.collider.gameObject.name == "Oliwa"){
				AddOil ();
			}

			// Podnoszenie klucza do Szafki w kuchni

			else if(hit.collider.gameObject.name == "KluczSzafkaKuchnia"){
				AddKitchenWardrobeKey ();
			}

			// Podnoszenie klucza do stajni

			else if(hit.collider.gameObject.name == "KluczStajnia"){
				AddStableKey ();
			}

			// Podnoszenie klucza do szopy obok kampingu

			else if(hit.collider.gameObject.name == "KluczSzopa"){
				AddShedKey ();
			}

			// Podnoszenie baterii w szopie z narzedziami

			else if(hit.collider.gameObject.name == "BaterieO"){
				AddBatteries ();
			}

			// Podnoszenie kasety z pokoju U

			else if(hit.collider.gameObject.name == "KasetaVideo1"){
				AddCassete1 ();
			}

			// Podnoszenie kosci nr 1

			else if(hit.collider.gameObject.name == "KoscZad1"){
				AddBone1 ();
			}

			// Podnoszenie kosci nr 2

			else if(hit.collider.gameObject.name == "KoscZad2"){
				AddBone2 ();
			}

			// Podnoszenie kosci nr 3

			else if(hit.collider.gameObject.name == "KoscZad3"){
				AddBone3 ();
			}

			// Podnoszenie kosci nr 4

			else if(hit.collider.gameObject.name == "KoscZad4"){
				AddBone4 ();
			}

			// Podnoszenie kosci nr 5

			else if(hit.collider.gameObject.name == "KoscZad5"){
				AddBone5 ();
			}

			// Podnoszenie klucza do wneki

			else if(hit.collider.gameObject.name == "KluczWneka"){
				AddNicheKey ();
			}

			// Podnoszenie klucza do kampingu

			else if(hit.collider.gameObject.name == "KluczKamping"){
				AddSecretRoomKey ();
			}

			// Podnoszenie zepsutego klucza do fabryki

			else if(hit.collider.gameObject.name == "KluczFabrykaBroken"){
				AddBrokenFactoryKey ();
			}

			// Podnoszenie Brakujace kola

			else if(hit.collider.gameObject.name == "BrakujaceDrewnianeKoloItem"){
				AddWoodenWheel ();
			}

			// Podnoszenie Naprawionego klucza

			else if(hit.collider.gameObject.name == "KluczNaprawiony" && isFixedKeyTaken == false){ // && Zdnia.NaprawionyKlucz_ok == true
				AddFixedKey ();
			}

			// Podnoszenie lomu

			else if(hit.collider.gameObject.name == "Lom"){
				AddCrowbar ();
			}

			// Podnoszenie klucza do salonu domu Alice na poludniu

			else if(hit.collider.gameObject.name == "KluczSalonPoludnie"){
				AddAliceKey ();
			}

			// Podnoszenie kombinerek

			else if(hit.collider.gameObject.name == "KombinerkiO"){
				AddPliers ();
			}

			// Podnoszenie siekiery

			else if(hit.collider.gameObject.name == "SiekieraZadanie"){
				AddAxe ();
			}

			// Podnoszenie klucza do szafy w korytarzu


			else if(hit.collider.gameObject.name == "KluczSzafaKorytarz"){
				AddWardrobeCorridorKey ();
			}

			// Podnoszenie klucza do szafki w szopie


			else if(hit.collider.gameObject.name == "KluczSzafkaSzopa"){
				AddShedCupboardKey ();
			}

			// Podnoszenie kasety 2 z szopy

			else if(hit.collider.gameObject.name == "KasetaVideo2"){
				AddCassete2 ();
			}

			// Podnoszenie dyni z głowy potwora

			else if(hit.collider.gameObject.name == "DyniaMisja"){
				AddPumpkin ();
			}
				
			// Podnoszenie klucza do pokoju Toma na gorze

			else if(hit.collider.gameObject.name == "KluczTomGora"){
				AddTomUpstairsKey ();
			}

			// Podnoszenie klucza do pokoju Toma

			else if(hit.collider.gameObject.name == "KluczPokojTom"){
				AddTomRoomKey ();
			}

			// Podnoszenie kasety nr 3 z pola kukurydzy

			else if(hit.collider.gameObject.name == "KasetaVideo3"){
				AddCassete3 ();
			}

			// Podnoszenie chipu

			else if(hit.collider.gameObject.name == "Chip"){
				AddChip ();
			}

			// Podnoszenie klucza do szafy w opuszczonym domu

			else if(hit.collider.gameObject.name == "KluczSzafaStaryDom"){
				AddOldWardobeKey ();
			}

			// Podnoszenie kasety nr 4 z opuszczonego domu

			else if(hit.collider.gameObject.name == "KasetaVideo4"){
				AddCassete4 ();
			}

			// Podnoszenie klucza do pokoju Stevena

			else if(hit.collider.gameObject.name == "KluczStevena"){
				AddStevenKey ();
			}

			// Podnoszenie rosliny

			else if(hit.collider.gameObject.name == "RoslinaLab"){
				AddLabPlant ();
			}

			// Podnoszenie grzyba

			else if(hit.collider.gameObject.name == "GrzybLab"){
				AddLabMushroom ();
			}

			// Podnoszenie czaszki

			else if(hit.collider.gameObject.name == "CzaszkaLabO"){
				AddLabSkull ();
			}

			// Podnoszenie mikstury

			else if(hit.collider.gameObject.name == "Mikstura"){
				AddStrongAcid ();
			}

			// Podnoszenie klucza do w domu na zachodzie

			else if(hit.collider.gameObject.name == "KluczPokojZachod"){
				AddPaulKey ();
			}

			// Podnoszenie secret items


			else if (hit.collider.gameObject.name == "SecretItem1_1") {
				secretItem1.gameObject.SetActive(false);
				isSecretIem1 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem2_1") {
				secretItem2.gameObject.SetActive(false);
				isSecretIem2 = true;
				AddSecretItem2();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_2") {
				secretItem3.gameObject.SetActive(false);
				isSecretIem3 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_3") {
				secretItem4.gameObject.SetActive(false);
				isSecretIem4 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem2_2") {
				secretItem5.gameObject.SetActive(false);
				isSecretIem5 = true;
				AddSecretItem2();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_4") {
				secretItem6.transform.gameObject.SetActive(false);
				isSecretIem6 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem2_3") {
				secretItem7.gameObject.SetActive(false);
				isSecretIem7 = true;
				AddSecretItem2();
			}

			else if (hit.collider.gameObject.name == "SecretItem2_4") {
				secretItem8.gameObject.SetActive(false);
				isSecretIem8 = true;
				AddSecretItem2();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_5") {
				secretItem9.gameObject.SetActive(false);
				isSecretIem9 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_6") {
				secretItem10.gameObject.SetActive(false);
				isSecretIem10 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem2_5") {
				secretItem11.gameObject.SetActive(false);
				isSecretIem11 = true;
				AddSecretItem2();
			}

			else if (hit.collider.gameObject.name == "SecretItem2_6") {
				secretItem12.gameObject.SetActive(false);
				isSecretIem12 = true;
				AddSecretItem2();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_7") {
				secretItem13.gameObject.SetActive(false);
				isSecretIem13 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem2_7") {
				secretItem14.gameObject.SetActive(false);
				isSecretIem14 = true;
				AddSecretItem2();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_8") {
				secretItem15.transform.gameObject.SetActive(false);
				isSecretIem15 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_9") {
				secretItem16.transform.gameObject.SetActive(false);
				isSecretIem16 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem2_8") {
				secretItem17.transform.gameObject.SetActive(false);
				isSecretIem17 = true;
				AddSecretItem2();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_10") {
				secretItem18.transform.gameObject.SetActive(false);
				isSecretIem18 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_11") {
				secretItem19.transform.gameObject.SetActive(false);
				isSecretIem19 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem1_12") {
				secretItem20.transform.gameObject.SetActive(false);
				isSecretIem20 = true;
				AddSecretItem1();
			}

			else if (hit.collider.gameObject.name == "SecretItem2_9") {
				secretItem21.transform.gameObject.SetActive(false);
				isSecretIem21 = true;
				AddSecretItem2();
			}

            else if (hit.collider.gameObject.name == "SecretItem1_13")
                {
                    secretItem22.transform.gameObject.SetActive(false);
                    isSecretIem22 = true;
                    AddSecretItem1();
                }

            else if (hit.collider.gameObject.name == "SecretItem2_10")
                {
                    secretItem23.transform.gameObject.SetActive(false);
                    isSecretIem23 = true;
                    AddSecretItem2();
                }

            else if (hit.collider.gameObject.name == "SecretItem1_14")
                {
                    secretItem24.transform.gameObject.SetActive(false);
                    isSecretIem24 = true;
                    AddSecretItem1();
                }

            else if (hit.collider.gameObject.name == "SecretItem1_15")
                {
                    secretItem25.transform.gameObject.SetActive(false);
                    isSecretIem25 = true;
                    AddSecretItem1();
                }

                else if (hit.collider.gameObject.name == "SecretItem1_16")
                {
                    secretItem26.transform.gameObject.SetActive(false);
                    isSecretIem26 = true;
                    AddSecretItem1();
                }

                else if (hit.collider.gameObject.name == "SecretItem1_17")
                {
                    secretItem27.transform.gameObject.SetActive(false);
                    isSecretIem27 = true;
                    AddSecretItem1();
                }

                else if (hit.collider.gameObject.name == "SecretItem2_11")
                {
                    secretItem28.transform.gameObject.SetActive(false);
                    isSecretIem28 = true;
                    AddSecretItem1();
                }

                else if (hit.collider.gameObject.name == "SecretItem2_12")
                {
                    secretItem29.transform.gameObject.SetActive(false);
                    isSecretIem29 = true;
                    AddSecretItem1();
                }

                else if (hit.collider.gameObject.name == "SecretItem2_13")
                {
                    secretItem30.transform.gameObject.SetActive(false);
                    isSecretIem30 = true;
                    AddSecretItem1();
                }
                else if (hit.collider.gameObject.name == "SecretItem2_14")
                {
                    secretItem31.transform.gameObject.SetActive(false);
                    isSecretIem31 = true;
                    AddSecretItem1();
                }

                else if (hit.collider.gameObject.name == "SecretItem2_15")
                {
                    secretItem32.transform.gameObject.SetActive(false);
                    isSecretIem32 = true;
                    AddSecretItem1();
                }

                // podnoszenie ziola

                else if (hit.collider.gameObject.name == "ZieloneZiolo1") {
				greenHerb1.transform.gameObject.SetActive(false);
				isGreenHerb1 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo2") {
				greenHerb2.transform.gameObject.SetActive(false);
				isGreenHerb2 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo3") {
				greenHerb3.transform.gameObject.SetActive(false);
				isGreenHerb3 = true;
				AddGreenHerb();
				}

			else if (hit.collider.gameObject.name == "ZieloneZiolo4") {
				greenHerb4.transform.gameObject.SetActive(false);
				isGreenHerb4 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo5") {
				greenHerb5.transform.gameObject.SetActive(false);
				isGreenHerb5 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo6") {
				greenHerb6.transform.gameObject.SetActive(false);
				isGreenHerb6 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo7") {
				greenHerb7.transform.gameObject.SetActive(false);
				isGreenHerb7 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo8") {
				greenHerb8.transform.gameObject.SetActive(false);
				isGreenHerb8 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo9") {
				greenHerb9.transform.gameObject.SetActive(false);
				isGreenHerb9 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo10") {
				greenHerb10.transform.gameObject.SetActive(false);
				isGreenHerb10 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo11") {
				greenHerb11.transform.gameObject.SetActive(false);
				isGreenHerb11 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo12") {
				greenHerb12.transform.gameObject.SetActive(false);
				isGreenHerb12 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo13") {
				greenHerb13.transform.gameObject.SetActive(false);
				isGreenHerb13 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo14") {
				greenHerb14.transform.gameObject.SetActive(false);
				isGreenHerb14 = true;
				AddGreenHerb();
				}

			else if (hit.collider.gameObject.name == "ZieloneZiolo15") {
				greenHerb15.transform.gameObject.SetActive(false);
				isGreenHerb15 = true;
				AddGreenHerb();
				}

			else if (hit.collider.gameObject.name == "ZieloneZiolo16") {
				greenHerb16.transform.gameObject.SetActive(false);
				isGreenHerb16 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo17") {
				greenHerb17.transform.gameObject.SetActive(false);
				isGreenHerb17 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo18") {
				greenHerb18.transform.gameObject.SetActive(false);
				isGreenHerb18 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo19") {
				greenHerb19.transform.gameObject.SetActive(false);
				isGreenHerb19 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo20") {
				greenHerb20.transform.gameObject.SetActive(false);
				isGreenHerb20 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo21") {
				greenHerb21.transform.gameObject.SetActive(false);
				isGreenHerb21 = true;
				AddGreenHerb();
			}

			else if (hit.collider.gameObject.name == "ZieloneZiolo22") {
				greenHerb22.transform.gameObject.SetActive(false);
				isGreenHerb22 = true;
				AddGreenHerb();
			}

                else if (hit.collider.gameObject.name == "ZieloneZiolo23")
                {
                    greenHerb23.transform.gameObject.SetActive(false);
                    isGreenHerb23 = true;
                    AddGreenHerb();
                }

                else if (hit.collider.gameObject.name == "ZieloneZiolo24")
                {
                    greenHerb24.transform.gameObject.SetActive(false);
                    isGreenHerb24 = true;
                    AddGreenHerb();
                }

                else if (hit.collider.gameObject.name == "ZieloneZiolo25")
                {
                    greenHerb25.transform.gameObject.SetActive(false);
                    isGreenHerb25 = true;
                    AddGreenHerb();
                }

                else if (hit.collider.gameObject.name == "ZieloneZiolo26")
                {
                    greenHerb26.transform.gameObject.SetActive(false);
                    isGreenHerb26 = true;
                    AddGreenHerb();
                }

                else if (hit.collider.gameObject.name == "ZieloneZiolo27")
                {
                    greenHerb27.transform.gameObject.SetActive(false);
                    isGreenHerb27 = true;
                    AddGreenHerb();
                }

                else if (hit.collider.gameObject.name == "ZieloneZiolo28")
                {
                    greenHerb28.transform.gameObject.SetActive(false);
                    isGreenHerb28 = true;
                    AddGreenHerb();
                }

                else if (hit.collider.gameObject.name == "ZieloneZiolo29")
                {
                    greenHerb29.transform.gameObject.SetActive(false);
                    isGreenHerb29 = true;
                    AddGreenHerb();
                }

                else if (hit.collider.gameObject.name == "ZieloneZiolo30")
                {
                    greenHerb30.transform.gameObject.SetActive(false);
                    isGreenHerb30 = true;
                    AddGreenHerb();
                }

                else if (hit.collider.gameObject.name == "ZieloneZiolo31")
                {
                    greenHerb31.transform.gameObject.SetActive(false);
                    isGreenHerb31 = true;
                    AddGreenHerb();
                }

                else if (hit.collider.gameObject.name == "ZieloneZiolo32")
                {
                    greenHerb32.transform.gameObject.SetActive(false);
                    isGreenHerb32 = true;
                    AddGreenHerb();
                }

                else if (hit.collider.gameObject.name == "NiebieskieZiolo1") {
				blueHerb1.transform.gameObject.SetActive(false);
				isBlueHerb1 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo2") {
				blueHerb2.transform.gameObject.SetActive(false);
				isBlueHerb2 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo3") {
				blueHerb3.transform.gameObject.SetActive(false);
				isBlueHerb3 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo4") {
				blueHerb4.transform.gameObject.SetActive(false);
				isBlueHerb4 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo5") {
				blueHerb5.transform.gameObject.SetActive(false);
				isBlueHerb5 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo6") {
				blueHerb5.transform.gameObject.SetActive(false);
				isBlueHerb6 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo7") {
				blueHerb7.transform.gameObject.SetActive(false);
				isBlueHerb7 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo8") {
				blueHerb8.transform.gameObject.SetActive(false);
				isBlueHerb8 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo9") {
				blueHerb9.transform.gameObject.SetActive(false);
				isBlueHerb9 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo10") {
				blueHerb10.transform.gameObject.SetActive(false);
				isBlueHerb10 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo11") {
				blueHerb11.transform.gameObject.SetActive(false);
				isBlueHerb11 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo12") {
				blueHerb12.transform.gameObject.SetActive(false);
				isBlueHerb12 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo13") {
				blueHerb13.transform.gameObject.SetActive(false);
				isBlueHerb13 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo14") {
				blueHerb14.transform.gameObject.SetActive(false);
				isBlueHerb14 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo15") {
				blueHerb15.transform.gameObject.SetActive(false);
				isBlueHerb15 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo16") {
				blueHerb16.transform.gameObject.SetActive(false);
				isBlueHerb16 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo17") {
				blueHerb17.transform.gameObject.SetActive(false);
				isBlueHerb17 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo18") {
				blueHerb18.transform.gameObject.SetActive(false);
				isBlueHerb18 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo19") {
				blueHerb19.transform.gameObject.SetActive(false);
				isBlueHerb19 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo20") {
				blueHerb20.transform.gameObject.SetActive(false);
				isBlueHerb20 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo21") {
				blueHerb21.transform.gameObject.SetActive(false);
				isBlueHerb21 = true;
				AddBlueHerb();
			}

			else if (hit.collider.gameObject.name == "NiebieskieZiolo22") {
				blueHerb22.transform.gameObject.SetActive(false);
				isBlueHerb22 = true;
				AddBlueHerb();
			}

            else if (hit.collider.gameObject.name == "NiebieskieZiolo23") {
				blueHerb23.transform.gameObject.SetActive(false);
				isBlueHerb23 = true;
				AddBlueHerb();
			}

            else if (hit.collider.gameObject.name == "NiebieskieZiolo24") {
				blueHerb24.transform.gameObject.SetActive(false);
				isBlueHerb24 = true;
				AddBlueHerb();
			}

            else if (hit.collider.gameObject.name == "NiebieskieZiolo25") {
				blueHerb25.transform.gameObject.SetActive(false);
				isBlueHerb25 = true;
				AddBlueHerb();
			}

            else if (hit.collider.gameObject.name == "NiebieskieZiolo26") {
				blueHerb26.transform.gameObject.SetActive(false);
				isBlueHerb26 = true;
				AddBlueHerb();
			}

            else if (hit.collider.gameObject.name == "NiebieskieZiolo27") {
				blueHerb27.transform.gameObject.SetActive(false);
				isBlueHerb27 = true;
				AddBlueHerb();
			}

            else if (hit.collider.gameObject.name == "NiebieskieZiolo28") {
				blueHerb28.transform.gameObject.SetActive(false);
				isBlueHerb28 = true;
				AddBlueHerb();
			}

            else if (hit.collider.gameObject.name == "NiebieskieZiolo29") {
				blueHerb29.transform.gameObject.SetActive(false);
				isBlueHerb29 = true;
				AddBlueHerb();
			}

            else if (hit.collider.gameObject.name == "NiebieskieZiolo30") {
				blueHerb30.transform.gameObject.SetActive(false);
				isBlueHerb30 = true;
				AddBlueHerb();
			}

            else if (hit.collider.gameObject.name == "NiebieskieZiolo31") {
				blueHerb31.transform.gameObject.SetActive(false);
				isBlueHerb31 = true;
				AddBlueHerb();
			}

            else if (hit.collider.gameObject.name == "NiebieskieZiolo32") {
				blueHerb32.transform.gameObject.SetActive(false);
				isBlueHerb32 = true;
				AddBlueHerb();
			}

            // podnoszenie fiolek

            else if (hit.collider.gameObject.name == "Fiolka1") {
				vial1.transform.gameObject.SetActive(false);
				isVial1 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka2") {
				vial2.transform.gameObject.SetActive(false);
				isVial2 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka3") {
				vial3.transform.gameObject.SetActive(false);
				isVial3 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka4") {
				vial4.transform.gameObject.SetActive(false);
				isVial4 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka5") {
				vial5.transform.gameObject.SetActive(false);
				isVial5 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka6") {
				vial6.transform.gameObject.SetActive(false);
				isVial6 = true;
				AddVial();
			}
            
            else if (hit.collider.gameObject.name == "Fiolka7") {
				vial7.transform.gameObject.SetActive(false);
				isVial7 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka8") {
				vial8.transform.gameObject.SetActive(false);
				isVial8 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka9") {
				vial9.transform.gameObject.SetActive(false);
				isVial9 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka10") {
				vial10.transform.gameObject.SetActive(false);
				isVial10 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka11") {
				vial11.transform.gameObject.SetActive(false);
				isVial11 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka12") {
				vial12.transform.gameObject.SetActive(false);
				isVial12 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka13") {
				vial13.transform.gameObject.SetActive(false);
				isVial13 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka14") {
				vial14.transform.gameObject.SetActive(false);
				isVial14 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka15") {
				vial15.transform.gameObject.SetActive(false);
				isVial15 = true;
				AddVial();
			}

            else if (hit.collider.gameObject.name == "Fiolka16") {
				vial16.transform.gameObject.SetActive(false);
				isVial16 = true;
				AddVial();
			}
            
            // podnoszenie eliksirów

            else if (hit.collider.gameObject.name == "EliksirStamina1") {
				staminaPot1.transform.gameObject.SetActive(false);
				isStaminaPot1 = true;
				AddStaminaPot();
			}

            else if (hit.collider.gameObject.name == "EliksirStamina2") {
				staminaPot2.transform.gameObject.SetActive(false);
				isStaminaPot2 = true;
				AddStaminaPot();
			}

            else if (hit.collider.gameObject.name == "EliksirStamina3") {
				staminaPot3.transform.gameObject.SetActive(false);
				isStaminaPot3 = true;
				AddStaminaPot();
			}

            else if (hit.collider.gameObject.name == "EliksirStamina4") {
				staminaPot4.transform.gameObject.SetActive(false);
				isStaminaPot4 = true;
				AddStaminaPot();
			}

            else if (hit.collider.gameObject.name == "EliksirStamina5") {
				staminaPot5.transform.gameObject.SetActive(false);
				isStaminaPot5 = true;
				AddStaminaPot();
			}

            else if (hit.collider.gameObject.name == "EliksirZdrowie1") {
				healthPot1.transform.gameObject.SetActive(false);
				isHealthPot1 = true;
				AddHealthPot();
			}

             else if (hit.collider.gameObject.name == "EliksirZdrowie2") {
				healthPot2.transform.gameObject.SetActive(false);
				isHealthPot2 = true;
				AddHealthPot();
			}

             else if (hit.collider.gameObject.name == "EliksirZdrowie3") {
				healthPot3.transform.gameObject.SetActive(false);
				isHealthPot3 = true;
				AddHealthPot();
			}

             else if (hit.collider.gameObject.name == "EliksirZdrowie4") {
				healthPot4.transform.gameObject.SetActive(false);
				isHealthPot4 = true;
				AddHealthPot();
			}

             else if (hit.collider.gameObject.name == "EliksirZdrowie5") {
				healthPot5.transform.gameObject.SetActive(false);
				isHealthPot5 = true;
				AddHealthPot();
			}

            else if (hit.collider.gameObject.name == "EliksirZdrowie6") {
				healthPot6.transform.gameObject.SetActive(false);
				isHealthPot6 = true;
				AddHealthPot();
			}
            
            // podnoszenie odznak do kolekcji

            else if (hit.collider.gameObject.name == "Odznaka1") {
                AddBadge1();
			}  
            
            else if (hit.collider.gameObject.name == "Odznaka2") {
                AddBadge2();
			}
            
            else if (hit.collider.gameObject.name == "Odznaka3") {
                AddBadge3();
			}        

            else if (hit.collider.gameObject.name == "Odznaka4") {
                AddBadge4();
			} 

            else if (hit.collider.gameObject.name == "Odznaka5") {
                AddBadge5();
			} 

            else if (hit.collider.gameObject.name == "Odznaka6") {
                AddBadge6();
			}
            
            else if (hit.collider.gameObject.name == "Odznaka7") {
                AddBadge7();
			}
            
            else if (hit.collider.gameObject.name == "Odznaka8") {
                AddBadge8();
			}
            
            else if (hit.collider.gameObject.name == "Odznaka9") {
                AddBadge9();
			}
            
            else if (hit.collider.gameObject.name == "Odznaka10") {
                AddBadge10();
			}
            
            else if (hit.collider.gameObject.name == "Odznaka11") {
                AddBadge11();
			}
            
            else if (hit.collider.gameObject.name == "Odznaka12") {
                AddBadge12();
			}
            
            else if (hit.collider.gameObject.name == "Foto1") {
                AddPhoto1();
			}  
            
            else if (hit.collider.gameObject.name == "Foto2") {
                AddPhoto2();
			}      
       
            else if (hit.collider.gameObject.name == "Foto3") {
                AddPhoto3();
			}
            
            else if (hit.collider.gameObject.name == "Foto4") {
                AddPhoto4();
			}
            
            else if (hit.collider.gameObject.name == "Foto5") {
                AddPhoto5();
			}
            
            else if (hit.collider.gameObject.name == "Foto6") {
                AddPhoto6();
			}
            
            else if (hit.collider.gameObject.name == "Foto7") {
                AddPhoto7();
			}
            
            else if (hit.collider.gameObject.name == "Foto8") {
                AddPhoto8();
			}
            
            else if (hit.collider.gameObject.name == "Foto9") {
                AddPhoto9();
			}
            
            else if (hit.collider.gameObject.name == "Foto10") {
                AddPhoto10();
			}        

            else if (hit.collider.gameObject.name == "Foto11") {
                AddPhoto11();
			} 

            else if (hit.collider.gameObject.name == "Foto12") {
                AddPhoto12();
			} 

            else if (hit.collider.gameObject.name == "Wskazowka1") {
                AddTip1();
			}
            
            else if (hit.collider.gameObject.name == "Wskazowka2") {
                AddTip2();
			}  

            else if (hit.collider.gameObject.name == "Wskazowka3") {
                AddTip3();
			} 

            else if (hit.collider.gameObject.name == "Wskazowka4") {
                AddTip4();
			} 

            else if (hit.collider.gameObject.name == "Wskazowka5") {
                AddTip5();
			} 

            else if (hit.collider.gameObject.name == "Wskazowka6") {
                AddTip6();
			} 

            else if (hit.collider.gameObject.name == "Wskazowka7") {
                AddTip7();
			} 

            else if (hit.collider.gameObject.name == "Wskazowka8") {
                AddTip8();
			} 

            else if (hit.collider.gameObject.name == "Wskazowka9") {
                AddTip9();
			} 

            else if (hit.collider.gameObject.name == "Wskazowka10") {
                AddTip10();
			} 

            else if (hit.collider.gameObject.name == "Wskazowka11") {
                AddTip11();
			} 

            else if (hit.collider.gameObject.name == "Wskazowka12") {
                AddTip12();
			} 

			if (hit.collider.gameObject.tag == "Zapis") {
					SaveGameScript.Zapisz ();
			}
	


		} // Klamra do Raycast

	} // Klamra do warunku przycisku	

		//-------------USUWANIE PRZEDMIOTOW Z EKWIPUNKU----------------------------------

		// Usuwanie klucza do pokoju U
		if(tasksScript.isUncleDoorLocked == false && isKeyV1Removed == false){
			RemoveKeyV1 ();
		}

		// Usuwanie klucza do szafki w kuchni
		if(tasksScript.isKitchenWardrobeLocked == false && isKeyV2Removed == false){
			UsunKluczSzafkaKuchnia ();
		}

		// Usuwanie klucza do drzwi stajni

		if(tasksScript.isStableDoorLocked == false && isKeyV3Removed == false){
			UsunKluczStajnia ();
		}

		// Usuwanie klucza do drzwi szopy

		if(tasksScript.isToolShedDoorLocked == false && isKeyV4Removed == false){
			UsunKluczSzopa ();
		}

		// Usuwanie Oliwy przy drzwiach w ogrodzie

		if(tasksScript.isGardenDoorLocked == false && isOilRemoved == false){
			RemoveOil ();
		}

		// Usuwanie klucza do wneki

		if(tasksScript.isNicheDoorLocked == false && isNicheKeyRemoved == false){
			UsunKluczWnekaItem ();
		}

		// Usuwanie kosci 1

		if(bonesTaskScript.isBone1 == true && isBone1Removed == false){
			UsunKoscZad1 ();
		}

		// Usuwanie kosci 2

		if(bonesTaskScript.isBone2 == true && isBone2Removed == false){
			UsunKoscZad2 ();
		}

		// Usuwanie kosci 3

		if(bonesTaskScript.isBone3 == true && isBone3Removed == false){
			UsunKoscZad3 ();
		}

		// Usuwanie kosci 4

		if(bonesTaskScript.isBone4 == true && isBone4Removed == false){
			UsunKoscZad4 ();
		}

		// Usuwanie kosci 5

		if(bonesTaskScript.isBone5 == true && isBone5Removed == false){
			UsunKoscZad5 ();
		}

		// Usuwanie klucza do kampingu

		if(tasksScript.isSecretRoomDoorLocked == false && isSecretRoomKeyRemoved == false){
			UsunKluczKampingItem ();
		}

		// Usuwanie kasety 1

		if(tasksScript.isCasseteInserted == true && isCassete1Removed == false){
			UsunKasetaVideo1 ();
		}

		// Usuwanie baterii

		if(tasksScript.isBatteriesPut == true && isBatteriesRemoved == false){
			UsunBateria ();
		}

		// Usuwanie zepsutego klucza

		if(tasksScript.isBrokenKey == true && isBrokenFactoryKeyRemoved == false){
			UsunKluczFabrykaBrokenItem ();
		}

		// Usuwanie brakujacego kola

		if(tasksScript.isWheel == true && isWoodenWheelRemoved == false){
			UsunDrewnianeKolo ();
		}

		// Usuwanie naprawionego klucza

		if(tasksScript.isFactoryWoodenDoorLocked == false && isFixedKeyRemoved == false){
			UsunNaprawionyKlucz ();
		}

		// Usuwanie lomu

		if(tasksScript.isFactoryMetalDoorLocked == false && isCrowbarRemoved == false){
			UsunLomItem ();
		}

		// Usuwanie klucza do salonu na poludniu domu Alice

		if(tasksScript.isAliceRoomDoorLocked == false && isAliceKeyRemoved == false){
			UsunKluczSalonPoludnieItem ();
		}

		// Usuwanie kombinerek

		if(tasksScript.isCornfieldDoorLocked == false && isPliersRemoved == false){
			UsunKombinerkiItem ();
		}

		// Usuwanie Siekiery

		if(tasksScript.isPlanksLocked == false && isAxeRemoved == false){
			UsunSiekieraZadanie ();
		}

		// Usuwanie klucza do szafy w korytarzu

		if(tasksScript.isCorridorWardrobeLocked == false && isWardrobeCorridorKeyRemoved == false){
			UsunKluczSzafaKorytarzItem ();
		}

		// Usuwanie klucza do szafki w szopie

		if(tasksScript.isShedCupboardLocked == false && isShedCupboardKeyRemoved == false){
			UsunKluczSzafkaSzopaItem ();
		}

		// Usuwanie kasety 2

		if(tasksScript.isCassete2Inserted == true && isCassete2Removed == false){
			UsunKasetaVideo2 ();
		}

		// Usuwanie dyni

		if(tasksScript.isPumpkin == true && isPumpkinRemoved == false){
			UsunDyniaItem ();
		}

		// Usuwanie klucza do pokoju Toma na gorze

		if(tasksScript.isTomUpstairsDoorLocked == false && isTomUpstairsKeyRemoved == false){
			UsunKluczTomGoraItem ();
		}

		// Usuwanie klucza do pokoju Toma

		if(tasksScript.isTomRoomDoorLocked == false && isTomRoomKeyRemoved == false){
			UsunKluczPokojTomItem ();
		}

		// Usuwanie kasety 3

		if(tasksScript.isCassete3Inserted == true && isCassete3Removed == false){
			UsunKasetaVideo3 ();
		}

		// Usuwanie chipu

		if(tasksScript.isChipPut == true && isChipRemoved == false){
			UsunChipItem ();
		}

		// Usuwanie klucza do szafy w opuszczonym domu

		if(tasksScript.isOldWardrobeLocked == false && isOldWardrobeKeyRemoved == false){
			UsunKluczSzafaStaryDomItem ();
		}

		// Usuwanie kasety 4

		if(tasksScript.isCassete4Inserted == true && isCassete4Removed == false){
			UsunKasetaVideo4 ();
		}

		// Usuwanie klucza do pokoju Stevena

		if(tasksScript.isStevenDoorLocked == false && isStevenKeyRemoved == false){
			UsunKluczStevenaItem ();
		}

		// Usuwanie rosliny

		if(tasksScript.isLabPlant == true && isLabPlantRemoved == false){
			UsunRoslinaLabItem ();
		}

		// Usuwanie grzyba

		if(tasksScript.isLabMushroom == true && isLabMushroomRemoved == false){
			UsunGrzybLabItem ();
		}

		// Usuwanie czaszki

		if(tasksScript.isLabSkull == true && isLabSkullRemoved == false){
			UsunCzaszkaLabItem ();
		}

		// Usuwanie klucza w pokoju na zachodzie

		if(tasksScript.isPaulDoorLocked == false && isPaulKeyRemoved== false){
			UsunKluczPokojZachodItem ();
		}

        // Usuwanie mikstury

		if (tasksScript.isThornsAcid == true && isStrongAcidRemoved == false)
        {
            UsunMiksturaItem();
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

    void PanelF()
    {

    }

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

	void AddKeyV1(){
		keyV1.gameObject.SetActive(false);
		isKeyV1Taken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i+1, "KluczPokojW", uncleKeyName, uncleKeyDescription, keyV1Icon, false));
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
				items.Add(new Item(i+1, "Oliwa", oilName, oilDescription, oilIcon, false));
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
				items.Add(new Item(i + 1, "KluczSzafkaKuchnia", kitchenWardrobeKeyName, kitchenWardrobeKeyDescription, keyV2Icon, false));
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

	void AddStableKey(){
		keyV3.gameObject.SetActive(false);
		isKeyV3Taken = true;
		itemAudioSource1.PlayOneShot(keySound2);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczStajnia", stableKeyName, stableKeyDescription, keyV3Icon, false));
				itemIcons[i].sprite = keyV3Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddShedKey(){
		keyV4.gameObject.SetActive(false);
		isKeyV4Taken = true;
		itemAudioSource1.PlayOneShot(keySound2);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczSzopa", shedKeyName, shedKeyDescription, keyV4Icon, false));
				itemIcons[i].sprite = keyV4Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}


        tasksScript.AddSzopaNarzedziaPointer();
        

    }

	void AddBatteries(){
		batteries.gameObject.SetActive(false);
		isBatteriesTaken = true;
		itemAudioSource1.PlayOneShot(batteriesSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Baterie", batteriesName, batteriesDescription, batteriesIcon, false));
				itemIcons[i].sprite = batteriesIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddCassete1(){
		cassete1.gameObject.SetActive(false);
		isCassete1Taken = true;
		itemAudioSource1.PlayOneShot(casseteSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kaseta1", cassete1Name, cassete1Description, cassete1Icon, false));
				itemIcons[i].sprite = cassete1Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddBone1(){
		bone1.gameObject.SetActive(false);
		isBone1Taken = true;
		itemAudioSource1.PlayOneShot(boneSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kosc1", bone1Name, boneDescription, bone1Icon, false));
				itemIcons[i].sprite = bone1Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddBone2(){
		bone2.gameObject.SetActive(false);
		isBone2Taken = true;
		itemAudioSource1.PlayOneShot(boneSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kosc2", bone2Name, boneDescription, bone2Icon, false));
				itemIcons[i].sprite = bone2Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddBone3(){
		bone3.gameObject.SetActive(false);
		isBone3Taken = true;
		itemAudioSource1.PlayOneShot(boneSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kosc3", bone3Name, boneDescription, bone3Icon, false));
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
				items.Add(new Item(i + 1, "Kosc4", bone3Name, boneDescription, bone4Icon, false));
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

	void AddBone5(){
		bone5.gameObject.SetActive(false);
		isBone5Taken = true;
		itemAudioSource1.PlayOneShot(boneSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kosc5", bone5Name, boneDescription, bone5Icon, false));
				itemIcons[i].sprite = bone5Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddNicheKey(){
		nicheKey.gameObject.SetActive(false);
		isNicheKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczWneka", nicheKeyName, nicheKeyDescription, nicheKeyIcon, false));
				itemIcons[i].sprite = nicheKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddSecretRoomKey(){
		secretRoomKey.gameObject.SetActive(false);
		isSecretRoomKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczKamping", secretRoomKeyName, secretRoomKeyDescription, secretRoomKeyIcon, false));
				itemIcons[i].sprite = secretRoomKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        tasksScript.AddSekretnyPokojPointer();

	}

	void AddBrokenFactoryKey(){
		brokenFactoryKey.gameObject.SetActive(false);
		isBrokenFactoryKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczFabryka", factoryKeyName, factoryKeyDescription, brokenFactoryKeyIcon, false));
				itemIcons[i].sprite = brokenFactoryKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddWoodenWheel(){
		woodenWheel.gameObject.SetActive(false);
		isWoodenWheelTaken = true;
		itemAudioSource3.PlayOneShot(woodenWheelSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "DrewnianeKolo", woodenWheelName, woodenWheelDescription, woodenWheelIcon, false));
				itemIcons[i].sprite = woodenWheelIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddFixedKey(){
        fixedKey.gameObject.SetActive(false);
        isFixedKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "FixedKey", fixedKeyName, fixedKeyDescription, fixedKeyIcon, false));
				itemIcons[i].sprite = fixedKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddCrowbar(){
		crowbar.gameObject.SetActive(false);
		isCrowbarTaken = true;
		itemAudioSource3.PlayOneShot(crowbarSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Lom", crowbarName, crowbarDescription, crowbarIcon, false));
				itemIcons[i].sprite = crowbarIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddAliceKey(){
		aliceKey.gameObject.SetActive(false);
		isAliceKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound2);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczSalonPoludnie", aliceKeyName, aliceKeyDescription, aliceKeyIcon, false));
				itemIcons[i].sprite = aliceKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddPliers(){
		itemAudioSource3.PlayOneShot(pliersSound);
		voiceActingScript.GlosKombinerki();
		pliers.transform.gameObject.SetActive(false);
		isPliersTaken = true;
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kombinerki", pliersName, pliersDescription, pliersIcon, false));
				itemIcons[i].sprite = pliersIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddAxe(){
		itemAudioSource1.PlayOneShot(axeSound);
		voiceActingScript.GlosSiekiera();
		axe.gameObject.SetActive(false);
		isAxeTaken = true;
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Siekiera", axeName, axeDescription, axeIcon, false));
				itemIcons[i].sprite = axeIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddWardrobeCorridorKey(){
		wardrobeCorridorKey.gameObject.SetActive(false);
		isWardrobeCorridorKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczSzafaKorytarz", wardrobeCorridorKeyName, wardrobeCorridorKeyDescription, wardrobeCorridorKeyIcon, false));
				itemIcons[i].sprite = wardrobeCorridorKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddShedCupboardKey(){
		shedCupboardKey.gameObject.SetActive(false);
		isShedCupboardKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczSzafkaSzopa", shedCupboardName, shedCupboardDescription, shedCupboardKeyIcon, false));
				itemIcons[i].sprite = shedCupboardKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddCassete2(){
		cassete2.gameObject.SetActive(false);
		isCassete2Taken = true;
		itemAudioSource1.PlayOneShot(casseteSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kaseta2", cassete2Name, cassete2Description, cassete2Icon, false));
				itemIcons[i].sprite = cassete2Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}

        tasksScript.RemoveSzafkaEdwardPointer();

	}

	void AddPumpkin(){
		pumpkin.SetActive(false);
		isPumpkinTaken = true;
		itemAudioSource1.PlayOneShot(woodenWheelSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Dynia", pumpkinName, pumpkinDescription, pumpkinIcon, false));
				itemIcons[i].sprite = pumpkinIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddTomUpstairsKey(){
		tomUpstairsKey.gameObject.SetActive(false);
		isTomUpstairsKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczTomGora", tomUpstairsKeyName, tomUpstairsKeyDescription, tomUpstairsKeyIcon, false));
				itemIcons[i].sprite = tomUpstairsKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddTomRoomKey(){
		tomRoomKey.gameObject.SetActive(false);
		isTomRoomKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczPokojTom", tomRoomKeyName, tomRoomKeyDescription, tomRoomKeyIcon, false));
				itemIcons[i].sprite = tomRoomKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddCassete3(){
		cassete3.gameObject.SetActive(false);
		isCassete3Taken = true;
		itemAudioSource1.PlayOneShot(casseteSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kaseta3", cassete3Name, cassete3Description, cassete3Icon, false));
				itemIcons[i].sprite = cassete3Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddChip(){
		chip.gameObject.SetActive(false);
		isChipTaken = true;
		itemAudioSource1.PlayOneShot(casseteSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Chip", chipName, chipDescription, chipIcon, false));
				itemIcons[i].sprite = chipIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddOldWardobeKey(){
		oldWardrobeKey.gameObject.SetActive(false);
		isOldWardrobeKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczStaryDom", oldWardrobeKeyName, oldWardrobeKeyDescription, oldWardrobeKeyIcon, false));
				itemIcons[i].sprite = oldWardrobeKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddCassete4(){
		cassete4.gameObject.SetActive(false);
		isCassete4Taken = true;
		itemAudioSource1.PlayOneShot(casseteSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Kaseta4", cassete4Name, cassete4Description, cassete4Icon, false));
				itemIcons[i].sprite = cassete4Icon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddStevenKey(){
		stevenKey.gameObject.SetActive(false);
		isStevenKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczSteven", stevenKeyName, stevenKeyDescription, stevenKeyIcon, false));
				itemIcons[i].sprite = stevenKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddLabPlant(){
		labPlant.gameObject.SetActive(false);
		isLabPlantTaken = true;
		itemAudioSource1.PlayOneShot(labPlantSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "RoslinaLab", labPlantName, labPlantDescription, labPlantIcon, false));
				itemIcons[i].sprite = labPlantIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddLabMushroom(){
		labMushroom.gameObject.SetActive(false);
		isLabMushroomTaken = true;
		itemAudioSource1.PlayOneShot(labPlantSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "GrzybLab", labMushroomName, labMushroomDescription, labMushroomIcon, false));
				itemIcons[i].sprite = labMushroomIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddLabSkull(){
		labSkull.gameObject.SetActive(false);
		isLabSkullTaken = true;
		itemAudioSource1.PlayOneShot(boneSound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "CzaszkaLab", labSkullName, labSkullDescription, labSkullIcon, false));
				itemIcons[i].sprite = labSkullIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddStrongAcid(){
		strongAcid.gameObject.SetActive(false);
		isStrongAcidTaken = true;
		itemAudioSource1.PlayOneShot(oilSound);
		voiceActingScript.GlosEliksir();
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "Mikstura", strongAcidName, strongAcidDescription, strongAcidIcon, false));
				itemIcons[i].sprite = strongAcidIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddPaulKey(){
		paulKey.gameObject.SetActive(false);
		isPaulKeyTaken = true;
		itemAudioSource1.PlayOneShot(keySound);
		animator.SetTrigger("Podnies");

		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == null){
				items.Add(new Item(i + 1, "KluczPokojZachod", paulKeyName, paulKeyDescription, paulKeyIcon, false));
				itemIcons[i].sprite = paulKeyIcon;
				itemIcons[i].color = Color.white;
				break;
			}
		}
	}

	void AddSecretItem1(){
		itemAudioSource1.PlayOneShot (secretItemSound);
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
        animator.SetTrigger ("Podnies");
		//secretItemsText.text = secretItemsCount + "/32";
	}

	void AddSecretItem2(){
		itemAudioSource1.PlayOneShot (secretItemSound2);
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
        animator.SetTrigger ("Podnies");
		//secretItemsText.text = secretItemsCount + "/32";
	}

	void AddGreenHerb(){
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
        animator.SetTrigger ("Podnies");
		greenHerbsText.text = greenHerbsCount + "";
	}

	void AddBlueHerb(){
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
        animator.SetTrigger ("Podnies");
		blueHerbsText.text = blueHerbsCount + "";
	}

    void AddVial() {

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
        animator.SetTrigger("Podnies");
        vialsCountText.text = vialsCount + "";
    }

    void AddStaminaPot()
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
        animator.SetTrigger("Podnies");
        staminaPotsText.text = staminaPotsCount + "";
    }

    void AddHealthPot()
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
        animator.SetTrigger("Podnies");
        healthPotsText.text = healthPotsCount + "";
    }

    void AddBadge1() {

        badge1.transform.gameObject.SetActive(false);
        isBadge1 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[0].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge2()
    {

        badge2.transform.gameObject.SetActive(false);
        isBadge2 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[1].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge3()
    {

        badge3.transform.gameObject.SetActive(false);
        isBadge3 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[2].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge4()
    {

        badge4.transform.gameObject.SetActive(false);
        isBadge4 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[3].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge5()
    {

        badge5.transform.gameObject.SetActive(false);
        isBadge5 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[4].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge6()
    {

        badge6.transform.gameObject.SetActive(false);
        isBadge6 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[5].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge7()
    {

        badge7.transform.gameObject.SetActive(false);
        isBadge7 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[6].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge8()
    {

        badge7.transform.gameObject.SetActive(false);
        isBadge8 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[7].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge9()
    {

        badge9.transform.gameObject.SetActive(false);
        isBadge9 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[8].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge10()
    {

        badge10.transform.gameObject.SetActive(false);
        isBadge10 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[9].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge11()
    {

        badge11.transform.gameObject.SetActive(false);
        isBadge11 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[10].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddBadge12()
    {

        badge12.transform.gameObject.SetActive(false);
        isBadge12 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[11].sprite = badgeOKSprite;
        badgesCount++;
    }

    void AddPhoto1()
    {

        photo1.transform.gameObject.SetActive(false);
        isPhoto1 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[12].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto2()
    {

        photo2.transform.gameObject.SetActive(false);
        isPhoto2 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[13].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto3()
    {

        photo3.transform.gameObject.SetActive(false);
        isPhoto3 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[14].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto4()
    {

        photo4.transform.gameObject.SetActive(false);
        isPhoto4 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[15].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto5()
    {

        photo5.transform.gameObject.SetActive(false);
        isPhoto5 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[16].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto6()
    {

        photo6.transform.gameObject.SetActive(false);
        isPhoto6 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[17].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto7()
    {

        photo7.transform.gameObject.SetActive(false);
        isPhoto7 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[18].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto8()
    {

        photo8.transform.gameObject.SetActive(false);
        isPhoto8 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[19].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto9()
    {

        photo9.transform.gameObject.SetActive(false);
        isPhoto9 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[20].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto10()
    {

        photo10.transform.gameObject.SetActive(false);
        isPhoto10 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[21].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto11()
    {

        photo11.transform.gameObject.SetActive(false);
        isPhoto11 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[22].sprite = photoOKSprite;
        photosCount++;
    }

    void AddPhoto12()
    {

        photo12.transform.gameObject.SetActive(false);
        isPhoto12 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[23].sprite = photoOKSprite;
        photosCount++;
    }

    void AddTip1()
    {

        tip1.transform.gameObject.SetActive(false);
        isTip1 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[24].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip2()
    {

        tip2.transform.gameObject.SetActive(false);
        isTip2 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[25].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip3()
    {

        tip3.transform.gameObject.SetActive(false);
        isTip3 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[26].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip4()
    {

        tip4.transform.gameObject.SetActive(false);
        isTip4 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[27].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip5()
    {

        tip5.transform.gameObject.SetActive(false);
        isTip5 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[28].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip6()
    {

        tip6.transform.gameObject.SetActive(false);
        isTip6 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[29].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip7()
    {

        tip7.transform.gameObject.SetActive(false);
        isTip7 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[30].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip8()
    {

        tip8.transform.gameObject.SetActive(false);
        isTip8 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[31].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip9()
    {

        tip9.transform.gameObject.SetActive(false);
        isTip9 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[32].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip10()
    {

        tip10.transform.gameObject.SetActive(false);
        isTip10 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[33].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip11()
    {

        tip11.transform.gameObject.SetActive(false);
        isTip11 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[34].sprite = tipOKSprite;
        tipsCount++;
    }

    void AddTip12()
    {

        tip12.transform.gameObject.SetActive(false);
        isTip12 = true;
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
        animator.SetTrigger("Podnies");
        collectionTextures[35].sprite = tipOKSprite;
        tipsCount++;
    }

    // ------------- Funkcje do usuwania przedmiotow----------------------

    void RemoveKeyV1(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == keyV1Icon){
				items.RemoveAll(x=>x.type =="KluczPokojW");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
				isKeyV1Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void RemoveOil(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == oilIcon){
				items.RemoveAll(x=>x.type == "Oliwa");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
				isOilRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczSzafkaKuchnia(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == keyV2Icon){
				items.RemoveAll(x=>x.type == "KluczSzafkaKuchnia");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
				isKeyV2Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczStajnia(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == keyV3Icon){
				items.RemoveAll(x=>x.type == "KluczStajnia");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
               // itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isKeyV3Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczSzopa(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == keyV4Icon){
				items.RemoveAll(x=>x.type == "KluczSzopa");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
               // usedItemText.text = defaultUsingItemText;
                isKeyV4Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunBateria(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == batteriesIcon){
				items.RemoveAll(x=>x.type == "Baterie");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isBatteriesRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKasetaVideo1(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == cassete1Icon){
				items.RemoveAll(x=>x.type == "Kaseta1");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isCassete1Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKoscZad1(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == bone1Icon){
				items.RemoveAll(x=>x.type == "Kosc1");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
				//itemDescriptionText.text = defaultDescription;
				//usedItemText.text = defaultUsingItemText;
                isBone1Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKoscZad2(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == bone2Icon){
				items.RemoveAll(x=>x.type == "Kosc2");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
				//itemDescriptionText.text = defaultDescription;
				//usedItemText.text = defaultUsingItemText;
                isBone2Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKoscZad3(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == bone3Icon){
				items.RemoveAll(x=>x.type == "Kosc3");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
				//itemDescriptionText.text = defaultDescription;
				//usedItemText.text = defaultUsingItemText;
				isBone3Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKoscZad4(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == bone4Icon){
				items.RemoveAll(x=>x.type == "Kosc4");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
				//itemDescriptionText.text = defaultDescription;
				//usedItemText.text = defaultUsingItemText;
                isBone4Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKoscZad5(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == bone5Icon){
				items.RemoveAll(x=>x.type == "Kosc5");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
				//itemDescriptionText.text = defaultDescription;
				//usedItemText.text = defaultUsingItemText;
                isBone5Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczWnekaItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == nicheKeyIcon){
				items.RemoveAll(x=>x.type == "KluczWneka");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isNicheKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczKampingItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == secretRoomKeyIcon){
				items.RemoveAll(x=>x.type == "KluczKamping");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isSecretRoomKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczFabrykaBrokenItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == brokenFactoryKeyIcon){
				items.RemoveAll(x=>x.type == "KluczFabryka");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isBrokenFactoryKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunDrewnianeKolo(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == woodenWheelIcon){
				items.RemoveAll(x=>x.type == "DrewnianeKolo");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isWoodenWheelRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunNaprawionyKlucz(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == fixedKeyIcon){
				items.RemoveAll(x=>x.type == "FixedKey");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isFixedKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunLomItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == crowbarIcon){
				items.RemoveAll(x=>x.type == "Lom");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
               // usedItemText.text = defaultUsingItemText;
                isCrowbarRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczSalonPoludnieItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == aliceKeyIcon){
				items.RemoveAll(x=>x.type == "KluczSalonPoludnie");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isAliceKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKombinerkiItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == pliersIcon){
				items.RemoveAll(x=>x.type == "Kombinerki");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isPliersRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunSiekieraZadanie(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == axeIcon){
				items.RemoveAll(x=>x.type == "Siekiera");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
               // usedItemText.text = defaultUsingItemText;
                isAxeRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczSzafaKorytarzItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == wardrobeCorridorKeyIcon){
				items.RemoveAll(x=>x.type == "KluczSzafaKorytarz");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
               // usedItemText.text = defaultUsingItemText;
                isWardrobeCorridorKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczSzafkaSzopaItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == shedCupboardKeyIcon){
				items.RemoveAll(x=>x.type == "KluczSzafkaSzopa");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isShedCupboardKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKasetaVideo2(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == cassete2Icon){
				items.RemoveAll(x=>x.type == "Kaseta2");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
               // usedItemText.text = defaultUsingItemText;
                isCassete2Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunDyniaItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == pumpkinIcon){
				items.RemoveAll(x=>x.type == "Dynia");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isPumpkinRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczTomGoraItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == tomUpstairsKeyIcon){
				items.RemoveAll(x=>x.type == "KluczTomGora");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isTomUpstairsKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczPokojTomItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == tomRoomKeyIcon){
				items.RemoveAll(x=>x.type == "KluczPokojTom");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isTomRoomKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKasetaVideo3(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == cassete3Icon){
				items.RemoveAll(x=>x.type == "Kaseta3");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isCassete3Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunChipItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == chipIcon){
				items.RemoveAll(x=>x.type == "Chip");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isChipRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczSzafaStaryDomItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == oldWardrobeKeyIcon){
				items.RemoveAll(x=>x.type == "KluczStaryDom");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isOldWardrobeKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKasetaVideo4(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == cassete4Icon){
				items.RemoveAll(x=>x.type == "Kaseta4");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isCassete4Removed = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunKluczStevenaItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == stevenKeyIcon){
				items.RemoveAll(x=>x.type == "KluczSteven");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isStevenKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunRoslinaLabItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == labPlantIcon){
				items.RemoveAll(x=>x.type == "RoslinaLab");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isLabPlantRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunGrzybLabItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == labMushroomIcon){
				items.RemoveAll(x=>x.type == "GrzybLab");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isLabMushroomRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunCzaszkaLabItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == labSkullIcon){
				items.RemoveAll(x=>x.type == "CzaszkaLab");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isLabSkullRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	void UsunMiksturaItem(){
        for (int i = 0; i < itemIcons.Length; i++)
        {
            if (itemIcons[i].sprite == strongAcidIcon)
            {
                items.RemoveAll(x => x.type == "Mikstura");
                itemIcons[i].sprite = null;
                itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isStrongAcidRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
            }
        }
    }

	void UsunKluczPokojZachodItem(){
		for(int i=0; i<itemIcons.Length; i++){
			if(itemIcons[i].sprite == paulKeyIcon){
				items.RemoveAll(x=>x.type == "KluczPokojZachod");
				itemIcons[i].sprite = null;
				itemIcons[i].color = Color.black;
                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isPaulKeyRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;

                break;
			}
		}
	}

	// ------------- Funkcje GUI Canvas ----------------------------------

	

	

	public void ShowTasks(){
		
		itemAudioSource3.PlayOneShot (menuButtonSound);

        inventoryCanvas.enabled = false;
        isInventoryActive = false;
        tasksCanvas.enabled = true;
        isTasksActive = true;
        notesCanvas.enabled = false;
        isNotesActive = false;
        treatmentCanvas.enabled = false;
        isTreatmentActive = false;
        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;
        isCollectionActive = false;

        noteDefaultCanvas.enabled = false;

    }

	public void ShowNotes(){

        StartCoroutine(ShowNotesIE());

    }

    public IEnumerator ShowNotesIE()
    {

        itemAudioSource3.PlayOneShot(menuButtonSound);

        inventoryCanvas.enabled = false;
        isInventoryActive = false;
        tasksCanvas.enabled = false;
        isTasksActive = false;
        notesCanvas.enabled = true;
        isNotesActive = true;
        treatmentCanvas.enabled = false;
        isTreatmentActive = false;
        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;
        isCollectionActive = false;

        noteDefaultCanvas.enabled = true;

        yield return new WaitForSecondsRealtime(0.01f);

        notesScrollRect.GetComponent<ScrollRect>().enabled = true;
        notesScrollbar.value = 1;
        StopCoroutine(ShowNotesIE());


    }

	public void TasksBackFunction(){

		//Panel.enabled = true;
		//Panel_ok = true;
		tasksCanvas.enabled = false;
		isTasksActive = false;
        //ZrodloDzwieku3.PlayOneShot (PrzyciskMenu);

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        noteDefaultCanvas.enabled = false;

        for (int i = 0; i < notesScript.notesCanvas2.Length; i++)
        {
            notesScript.notesCanvas2[i].enabled = false;
        }

        for (int i = 0; i < collectionCanvas.Length; i++)
        {
            collectionCanvas[i].enabled = false;
        }

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;
    }

	public void NotesBackFunction(){

		//Panel.enabled = true;
		//Panel_ok = true;
		notesCanvas.enabled = false;
		isNotesActive = false;
		noteDefaultCanvas.enabled = false;
        //ZrodloDzwieku3.PlayOneShot (PrzyciskMenu);

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        for (int i = 0; i < notesScript.notesCanvas2.Length; i++) {
			notesScript.notesCanvas2 [i].enabled = false;
		}

        for (int i = 0; i < collectionCanvas.Length; i++)
        {
            collectionCanvas[i].enabled = false;
        }

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;


    }

    public void InventoryBackFunction()
    {

        //Panel.enabled = true;
        //Panel_ok = true;
        inventoryCanvas.enabled = false;
        isInventoryActive = false;
        //ZrodloDzwieku3.PlayOneShot (PrzyciskMenu);

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        noteDefaultCanvas.enabled = false;

        for (int i = 0; i < notesScript.notesCanvas2.Length; i++)
        {
            notesScript.notesCanvas2[i].enabled = false;
        }

        for (int i = 0; i < collectionCanvas.Length; i++)
        {
            collectionCanvas[i].enabled = false;
        }

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;

    }

    public void TreatmentBackFunction()
    {

        //Panel.enabled = true;
        //Panel_ok = true;
        treatmentCanvas.enabled = false;
        isTreatmentActive = false;
        //ZrodloDzwieku3.PlayOneShot (PrzyciskMenu);

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        noteDefaultCanvas.enabled = false;

        for (int i = 0; i < notesScript.notesCanvas2.Length; i++)
        {
            notesScript.notesCanvas2[i].enabled = false;
        }

        for (int i = 0; i < collectionCanvas.Length; i++)
        {
            collectionCanvas[i].enabled = false;
        }

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;
    }

    public void CollectionBackFunction()
    {
        //Panel.enabled = true;
        //Panel_ok = true;
        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;
        isCollectionActive = false;
        //ZrodloDzwieku3.PlayOneShot(PrzyciskMenu);

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        noteDefaultCanvas.enabled = false;

        for (int i = 0; i < notesScript.notesCanvas2.Length; i++)
        {
            notesScript.notesCanvas2[i].enabled = false;
        }

        for (int i = 0; i < collectionCanvas.Length; i++)
        {
            collectionCanvas[i].enabled = false;
        }

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;

    }

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
        collectionCanvas[0].enabled = true;
        collectionCanvas[1].enabled = false;
        collectionCanvas[2].enabled = false;
        collectionCanvas[3].enabled = false;
        collectionCanvas[4].enabled = false;
        collectionCanvas[5].enabled = false;
        collectionCanvas[6].enabled = false;
        collectionCanvas[7].enabled = false;
        collectionCanvas[8].enabled = false;
        collectionCanvas[9].enabled = false;
        collectionCanvas[10].enabled = false;
        collectionCanvas[11].enabled = false;
        collectionCanvas[12].enabled = false;
        collectionCanvas[13].enabled = false;
        collectionCanvas[14].enabled = false;
        collectionCanvas[15].enabled = false;
        collectionCanvas[16].enabled = false;
        collectionCanvas[17].enabled = false;
        collectionCanvas[18].enabled = false;
        collectionCanvas[19].enabled = false;
        collectionCanvas[20].enabled = false;
        collectionCanvas[21].enabled = false;
        collectionCanvas[22].enabled = false;
        collectionCanvas[23].enabled = false;
        collectionCanvas[24].enabled = false;
        collectionCanvas[25].enabled = false;
        collectionCanvas[26].enabled = false;
        collectionCanvas[27].enabled = false;
        collectionCanvas[28].enabled = false;
        collectionCanvas[29].enabled = false;
        collectionCanvas[30].enabled = false;
        collectionCanvas[31].enabled = false;
        collectionCanvas[32].enabled = false;
        collectionCanvas[33].enabled = false;
        collectionCanvas[34].enabled = false;
        collectionCanvas[35].enabled = false;
        collectionCanvas[36].enabled = false;
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
        collectionCanvas[0].enabled = true;
        collectionCanvas[1].enabled = false;
        collectionCanvas[2].enabled = false;
        collectionCanvas[3].enabled = false;
        collectionCanvas[4].enabled = false;
        collectionCanvas[5].enabled = false;
        collectionCanvas[6].enabled = false;
        collectionCanvas[7].enabled = false;
        collectionCanvas[8].enabled = false;
        collectionCanvas[9].enabled = false;
        collectionCanvas[10].enabled = false;
        collectionCanvas[11].enabled = false;
        collectionCanvas[12].enabled = false;
        collectionCanvas[13].enabled = false;
        collectionCanvas[14].enabled = false;
        collectionCanvas[15].enabled = false;
        collectionCanvas[16].enabled = false;
        collectionCanvas[17].enabled = false;
        collectionCanvas[18].enabled = false;
        collectionCanvas[19].enabled = false;
        collectionCanvas[20].enabled = false;
        collectionCanvas[21].enabled = false;
        collectionCanvas[22].enabled = false;
        collectionCanvas[23].enabled = false;
        collectionCanvas[24].enabled = false;
        collectionCanvas[25].enabled = false;
        collectionCanvas[26].enabled = false;
        collectionCanvas[27].enabled = false;
        collectionCanvas[28].enabled = false;
        collectionCanvas[29].enabled = false;
        collectionCanvas[30].enabled = false;
        collectionCanvas[31].enabled = false;
        collectionCanvas[32].enabled = false;
        collectionCanvas[33].enabled = false;
        collectionCanvas[34].enabled = false;
        collectionCanvas[35].enabled = false;
        collectionCanvas[36].enabled = false;
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
        collectionCanvas[0].enabled = true;
        collectionCanvas[1].enabled = false;
        collectionCanvas[2].enabled = false;
        collectionCanvas[3].enabled = false;
        collectionCanvas[4].enabled = false;
        collectionCanvas[5].enabled = false;
        collectionCanvas[6].enabled = false;
        collectionCanvas[7].enabled = false;
        collectionCanvas[8].enabled = false;
        collectionCanvas[9].enabled = false;
        collectionCanvas[10].enabled = false;
        collectionCanvas[11].enabled = false;
        collectionCanvas[12].enabled = false;
        collectionCanvas[13].enabled = false;
        collectionCanvas[14].enabled = false;
        collectionCanvas[15].enabled = false;
        collectionCanvas[16].enabled = false;
        collectionCanvas[17].enabled = false;
        collectionCanvas[18].enabled = false;
        collectionCanvas[19].enabled = false;
        collectionCanvas[20].enabled = false;
        collectionCanvas[21].enabled = false;
        collectionCanvas[22].enabled = false;
        collectionCanvas[23].enabled = false;
        collectionCanvas[24].enabled = false;
        collectionCanvas[25].enabled = false;
        collectionCanvas[26].enabled = false;
        collectionCanvas[27].enabled = false;
        collectionCanvas[28].enabled = false;
        collectionCanvas[29].enabled = false;
        collectionCanvas[30].enabled = false;
        collectionCanvas[31].enabled = false;
        collectionCanvas[32].enabled = false;
        collectionCanvas[33].enabled = false;
        collectionCanvas[34].enabled = false;
        collectionCanvas[35].enabled = false;
        collectionCanvas[36].enabled = false;
        tipCollectionTitleText.text = collectionTitles[2];

    }

   

   

    

   
    public void CollectionWskazowka1()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip1 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = true;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[27];

        }

    }

    public void CollectionWskazowka2()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip2 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = true;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[28];

        }

    }

    public void CollectionWskazowka3()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip3 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = true;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[29];

        }

    }

    public void CollectionWskazowka4()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip4 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = true;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[30];

        }

    }

    public void CollectionWskazowka5()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip5 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = true;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[31];

        }

    }

    public void CollectionWskazowka6()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip6 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = true;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[32];

        }

    }

    public void CollectionWskazowka7()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip7 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = true;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[33];

        }

    }

    public void CollectionWskazowka8()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip8 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = true;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[34];

        }

    }

    public void CollectionWskazowka9()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip9 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = true;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[35];

        }

    }

    public void CollectionWskazowka10()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip10 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = true;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[36];

        }

    }

    public void CollectionWskazowka11()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip11 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = true;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[37];

        }

    }

    public void CollectionWskazowka12()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip12 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = true;
            tipCollectionTitleText.text = collectionTitles[38];

        }

    }




    public void HoverButton(){

		itemAudioSource3.PlayOneShot (itemDesciptionSound);

	}

}


