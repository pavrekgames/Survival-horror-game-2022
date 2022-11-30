using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeginGame : MonoBehaviour {

	private Animator PrzejscieAnimator;
	private Animator LogoAnimator;
	private Animator PrezentujeAnimator;
	private Animator LastVisitAnimator;
	private VoiceActing BohaterGlos;
	private CrosshairGUI Kursor;
	private Menu MenuGlowne;
	private Player Player;
	private Map MapaGracza;
	private Crouch Kuca;
	private Flashlight SwiatloLatarki;
	private PlayerSounds DzwiekiPlayer;
	private GameManager ManagerGry;
	private AudioListener Listener;
	public AudioSource ZrodloDzwBohater;
	public AudioSource ZrodloDzwBrama;
	public AudioClip DzwBramy;
	public AudioClip DzwTelefonu;
	private Canvas CanvasPoczatekGry;
    private Canvas CanvasUI;
	public bool PoczatekGry_ok = false;
	public bool PoczatekGryWlacz_ok = false;
	public bool Logo_ok = false;
	public bool Prezentuje_ok = false;
	public bool LastVisit_ok = false;
	public bool Koniec_ok = false;
	public bool Canvas_ok = false;
	public bool Listener_ok = false;

	private Screamer Straszak;
	private Inventory Inventory;
	private Tasks Tasks;
	private Notifications Kom;
	private Notes Notes;
	private Jumpscare JumpScare;
	private Music MuzykaGry;
	private SaveGame Saving;
	private TaskBooks ZadKsiazki;
    private TaskMeat ZadMieso;
    private EndGame KoniecGry;
    private Halluns Halucynacje;
    private StraszakScarecrow ScarecrowStraszak;
	private Health ZdrowieGracza;

	private Text SPGrobRockyPointer;
	private Text SPCmentarzZwierzatPointer;
	private Text SPOgrodSimonaPointer;
	private Text SPObozTomaPointer;
	private Text SPCmentarzWojnaPointer;
	private Text SPDomekPointer;
	private Text SPPiwnicaPointer;
	private Text SPPoleGrzybowePointer;
	private Text SPCiemnyLasPointer;
	private Text SPWiezaKosciPointer;
	private Text SPNozowaArenaPointer;
	private Text SPJaskiniaPointer;
	private Text SPPomnikPointer;
	private Text SPStatekKosmicznyPointer;

	private Image Skill1Icon;
	private Image Skill2Icon;
	private Image Skill3Icon;
	private Image Skill4Icon;

	private Text KluczDrewnoPointer;
	private Text MagicznaStudniaPointer;
	private Image KamienieObszar;
    private Text DrzwiOgrodPointer;
    private Image KosciObszar;
	private Image DomAlicePointer;
	private Text SimonElementPointer;
    private Text WarsztatPointer;
    private Text ZepsutyKluczPointer;
	private Text CmentarzZwierzPointer;
    private Image StrzalkaCmentarzZwierzPointer;
    private Image StrzalkaVictorPointer;
    private Image StrzalkaVictorPointer2;
    private Text KukurydzaPointer;
	private Text SiekieraPointer;
	private Text SzafaKorytarzPointer;
	private Text Kaseta2Pointer;
	private Text IdzSzlakPointer;
	private Image StrzalkaSzlakPointer;
	private Text PrzedostanSiePointer;
	private Image DomTomPointer;
	private Image KukurydzaObszar;
	private Text TomObozPointer;
	private Image DyniaObszar;
	private Text WawozPointer; 
	private Image StrzalkaIdzWawoz;
	private Image DomOpuszczonyPointer;
	private Image DomStevenPointer;
	private Image ObszarStevenKlucz;
	private Text StevenMiesoPointer;
	private Text StevenGrzybPointer;
	private Text StevenRoslinaPointer;
	private Text StevenCzaszkaPointer;
	private Text StevenSzopaPointer;
	private Text StevenPotokPointer;
	private Image DomNaukowcaPointer;
	private Text ChatkaPointer;
	private Text PotokDiablyPointer;
	private Image KryjowkaDiablyObszar;

    private Text SzafkaEdwardPointer;
    private Text KoscSzopaPointer;
    private Text KoscStajniaPointer;
    private Text SzopaNarzedziaPointer;
    private Text KluczWychodekPointer;
    private Text SekretnyPokojPointer;

    private Image InventoryItem1;
	private Image InventoryItem2;
	private Image InventoryItem3;
	private Image InventoryItem4;
	private Image InventoryItem5;
	private Image InventoryItem6;
	private Image InventoryItem7;
	private Image InventoryItem8;
	private Image InventoryItem9;
	private TextMeshProUGUI InventoryOpis;
	private TextMeshProUGUI InventoryUsing;

	private TextMeshProUGUI TasksZadanie1;
	private TextMeshProUGUI TasksZadanie2;
	private TextMeshProUGUI TasksZadanie3;
	private TextMeshProUGUI TasksZadanie4;
	private TextMeshProUGUI TasksZadanie5;



	void OnEnable () {

		BohaterGlos = GameObject.Find ("Player").GetComponent<VoiceActing> ();
		PrzejscieAnimator = GameObject.Find ("PrzejsciePoczatekGry").GetComponent<Animator> ();
		LogoAnimator = GameObject.Find ("LogoPavrek").GetComponent<Animator> ();
		PrezentujeAnimator = GameObject.Find ("PrezentujeText").GetComponent<Animator> ();
		LastVisitAnimator = GameObject.Find ("LogoLastVisit").GetComponent<Animator> ();
		CanvasPoczatekGry = GameObject.Find ("CanvasPoczatekGry").GetComponent<Canvas> ();
        CanvasUI = GameObject.Find("CanvasUI").GetComponent<Canvas>();
        //DzwBramy = Resources.Load<AudioClip>("Muzyka/Brama");
        //DzwTelefonu = Resources.Load<AudioClip>("Muzyka/Telefon");
        ZrodloDzwBrama = GameObject.Find ("ZrodloPrzedmiot4_s").GetComponent<AudioSource> ();
		ZrodloDzwBohater = GameObject.Find ("MuzykaGlosBohatera2").GetComponent<AudioSource> ();
		Listener = GameObject.Find ("Kamera").GetComponent<AudioListener> ();
		Kursor = GameObject.Find ("Kamera").GetComponent<CrosshairGUI> ();
		MenuGlowne = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
		Player = GameObject.Find ("Player").GetComponent<Player> ();
		MapaGracza = GameObject.Find ("Player").GetComponent<Map> ();
		Kuca = GameObject.Find ("Player").GetComponent<Crouch> ();
		SwiatloLatarki = GameObject.Find ("Latarka").GetComponent<Flashlight> ();
		DzwiekiPlayer = GameObject.Find ("Player").GetComponent<PlayerSounds> ();
		ManagerGry = GameObject.Find ("Player").GetComponent<GameManager> ();

		Straszak = GameObject.Find ("Player").GetComponent<Screamer> ();
		Inventory= GameObject.Find ("Player").GetComponent<Inventory> ();
		Tasks = GameObject.Find ("Player").GetComponent<Tasks> ();
		Kom = GameObject.Find ("Player").GetComponent<Notifications> ();
		Notes = GameObject.Find ("Player").GetComponent<Notes> ();
		JumpScare = GameObject.Find ("Player").GetComponent<Jumpscare> ();
		MuzykaGry = GameObject.Find ("Player").GetComponent<Music> ();
		Saving = GameObject.Find ("Player").GetComponent<SaveGame> ();
		ZadKsiazki = GameObject.Find ("Player").GetComponent<TaskBooks> ();
        ZadMieso = GameObject.Find("Player").GetComponent<TaskMeat>();
        KoniecGry = GameObject.Find("Player").GetComponent<EndGame>();
        Halucynacje = GameObject.Find("Player").GetComponent<Halluns>();
        ScarecrowStraszak = GameObject.Find("Player").GetComponent<StraszakScarecrow>();
        ZdrowieGracza = GameObject.Find ("Player").GetComponent<Health> ();

		SPGrobRockyPointer = GameObject.Find ("SPGrobRockyPointer").GetComponent<Text>();
		SPCmentarzZwierzatPointer = GameObject.Find ("SPCmentarzZwierzatPointer").GetComponent<Text>();
		SPOgrodSimonaPointer = GameObject.Find ("SPOgrodSimonaPointer").GetComponent<Text>();
		SPObozTomaPointer = GameObject.Find ("SPObozTomaPointer").GetComponent<Text>();
		SPCmentarzWojnaPointer = GameObject.Find ("SPCmentarzWojnaPointer").GetComponent<Text>();
		SPDomekPointer = GameObject.Find ("SPDomekPointer").GetComponent<Text>();
		SPPiwnicaPointer = GameObject.Find ("SPPiwnicaPointer").GetComponent<Text>();
		SPPoleGrzybowePointer = GameObject.Find ("SPPoleGrzybowePointer").GetComponent<Text>();
		SPCiemnyLasPointer = GameObject.Find ("SPCiemnyLasPointer").GetComponent<Text>();
		SPWiezaKosciPointer = GameObject.Find ("SPWiezaKosciPointer").GetComponent<Text>();
		SPNozowaArenaPointer = GameObject.Find ("SPNozowaArenaPointer").GetComponent<Text>();
		SPJaskiniaPointer = GameObject.Find ("SPJaskiniaPointer").GetComponent<Text>();
		SPPomnikPointer = GameObject.Find ("SPPomnikPointer").GetComponent<Text>();
		SPStatekKosmicznyPointer = GameObject.Find ("SPStatekKosmicznyPointer").GetComponent<Text>();

		Skill1Icon = GameObject.Find("InventorySkill1").GetComponent<Image>();
		Skill2Icon = GameObject.Find("InventorySkill2").GetComponent<Image>();
		Skill3Icon = GameObject.Find("InventorySkill3").GetComponent<Image>();
		Skill4Icon = GameObject.Find("InventorySkill4").GetComponent<Image>();

		KluczDrewnoPointer = GameObject.Find ("KluczDrewnoPointer").GetComponent<Text> ();
		MagicznaStudniaPointer = GameObject.Find ("MagicznaStudniaPointer").GetComponent<Text> ();
        DrzwiOgrodPointer = GameObject.Find("DrzwiOgrodPointer").GetComponent<Text>();
        SimonElementPointer = GameObject.Find ("SimonElementPointer").GetComponent<Text> ();
        WarsztatPointer = GameObject.Find("WarsztatPointer").GetComponent<Text>();
        ZepsutyKluczPointer = GameObject.Find ("ZepsutyKluczPointer").GetComponent<Text> ();
		CmentarzZwierzPointer = GameObject.Find ("CmentarzZwierzPointer").GetComponent<Text> ();
		KukurydzaPointer = GameObject.Find ("KukurydzaPointer").GetComponent<Text> ();
		SiekieraPointer = GameObject.Find ("SiekieraPointer").GetComponent<Text> ();
		SzafaKorytarzPointer = GameObject.Find ("SzafaKorytarzPointer").GetComponent<Text> ();
		Kaseta2Pointer = GameObject.Find ("Kaseta2Pointer").GetComponent<Text> ();
		IdzSzlakPointer = GameObject.Find ("IdzSzlakPointer").GetComponent<Text> ();
		PrzedostanSiePointer = GameObject.Find ("PrzedostanSiePointer").GetComponent<Text> ();
		TomObozPointer = GameObject.Find ("TomObozPointer").GetComponent<Text> ();
		WawozPointer = GameObject.Find ("WawozPointer").GetComponent<Text> ();
		StevenMiesoPointer = GameObject.Find ("StevenMiesoPointer").GetComponent<Text> ();
		StevenGrzybPointer = GameObject.Find ("StevenGrzybPointer").GetComponent<Text> ();
		StevenRoslinaPointer = GameObject.Find ("StevenRoslinaPointer").GetComponent<Text> ();
		StevenCzaszkaPointer = GameObject.Find ("StevenCzaszkaPointer").GetComponent<Text> ();
		StevenSzopaPointer = GameObject.Find ("StevenSzopaPointer").GetComponent<Text> ();
		StevenPotokPointer = GameObject.Find ("StevenPotokPointer").GetComponent<Text> ();
		ChatkaPointer = GameObject.Find ("ChatkaPointer").GetComponent<Text> ();
		PotokDiablyPointer = GameObject.Find ("PotokDiablyPointer").GetComponent<Text> ();

		KamienieObszar = GameObject.Find ("KamienieObszar").GetComponent<Image> ();
		KosciObszar = GameObject.Find ("KosciObszar").GetComponent<Image> ();
		DomAlicePointer = GameObject.Find ("DomAlicePointer").GetComponent<Image> ();
        StrzalkaCmentarzZwierzPointer = GameObject.Find("StrzalkaCmentarzZwierzPointer").GetComponent<Image>();
        StrzalkaVictorPointer = GameObject.Find ("StrzalkaVictorPointer").GetComponent<Image> ();
        StrzalkaVictorPointer2 = GameObject.Find("StrzalkaVictorPointer2").GetComponent<Image>();
        StrzalkaSzlakPointer = GameObject.Find ("StrzalkaSzlakPointer").GetComponent<Image> ();
		DomTomPointer = GameObject.Find ("DomTomPointer").GetComponent<Image> ();
		KukurydzaObszar = GameObject.Find ("KukurydzaObszar").GetComponent<Image> ();
		DyniaObszar = GameObject.Find ("DyniaObszar").GetComponent<Image> ();
		StrzalkaIdzWawoz = GameObject.Find ("StrzalkaIdzWawoz").GetComponent<Image> ();
		DomOpuszczonyPointer = GameObject.Find ("DomOpuszczonyPointer").GetComponent<Image> ();
		DomStevenPointer = GameObject.Find ("DomStevenPointer").GetComponent<Image> ();
		ObszarStevenKlucz = GameObject.Find ("StevenKluczObszar").GetComponent<Image> ();
		DomNaukowcaPointer = GameObject.Find ("DomNaukowcaPointer").GetComponent<Image> ();
		KryjowkaDiablyObszar = GameObject.Find ("KryjowkaDiablyObszar").GetComponent<Image> ();

        SzafkaEdwardPointer = GameObject.Find("SzafkaEdwardPointer").GetComponent<Text>();
        KoscSzopaPointer = GameObject.Find("KoscSzopaPointer").GetComponent<Text>();
        KoscStajniaPointer = GameObject.Find("KoscStajniaPointer").GetComponent<Text>();
        SzopaNarzedziaPointer = GameObject.Find("SzopaNarzedziaPointer").GetComponent<Text>();
        KluczWychodekPointer = GameObject.Find("KluczWychodekPointer").GetComponent<Text>();
        SekretnyPokojPointer = GameObject.Find("SekretnyPokojPointer").GetComponent<Text>();

        InventoryItem1 = GameObject.Find ("InventoryItem1").GetComponent<Image> ();
		InventoryItem2 = GameObject.Find ("InventoryItem2").GetComponent<Image> ();
		InventoryItem3 = GameObject.Find ("InventoryItem3").GetComponent<Image> ();
		InventoryItem4 = GameObject.Find ("InventoryItem4").GetComponent<Image> ();
		InventoryItem5 = GameObject.Find ("InventoryItem5").GetComponent<Image> ();
		InventoryItem6 = GameObject.Find ("InventoryItem6").GetComponent<Image> ();
		InventoryItem7 = GameObject.Find ("InventoryItem7").GetComponent<Image> ();
		InventoryItem8 = GameObject.Find ("InventoryItem8").GetComponent<Image> ();
		InventoryItem9 = GameObject.Find ("InventoryItem9").GetComponent<Image> ();
		InventoryOpis = GameObject.Find ("InventoryOpis").GetComponent<TextMeshProUGUI> ();
		InventoryUsing = GameObject.Find ("InventoryUsing").GetComponent<TextMeshProUGUI> ();

		TasksZadanie1 = GameObject.Find ("TasksZadanie1").GetComponent<TextMeshProUGUI> ();
		TasksZadanie2 = GameObject.Find ("TasksZadanie2").GetComponent<TextMeshProUGUI> ();
		TasksZadanie3 = GameObject.Find ("TasksZadanie3").GetComponent<TextMeshProUGUI> ();
		TasksZadanie4 = GameObject.Find ("TasksZadanie4").GetComponent<TextMeshProUGUI> ();
		TasksZadanie5 = GameObject.Find ("TasksZadanie5").GetComponent<TextMeshProUGUI> ();

		// ustawienie poczatkowych wartosci

        // poczatek gry

		PoczatekGry_ok = false;
		PoczatekGryWlacz_ok = false;
		Logo_ok = false;
		Prezentuje_ok = false;
		LastVisit_ok = false;
		Koniec_ok = false;
		Canvas_ok = false;
		Listener_ok = false;

        // punkty zapisu

		Saving.PoczatekZapis_ok = false;
		Saving.DomZapis_ok = false;
		Saving.StudniaZapis_ok = false;
		Saving.OgrodZapis_ok = false;
		Saving.KosciZapis_ok = false;
		Saving.IdzAliceZapis_ok = false;
		Saving.DomAliceZapis_ok = false;
		Saving.BrakujaceKoloZapis_ok = false;
		Saving.NaprawionyKluczZapis_ok = false;
		Saving.FabrykaZapis_ok = false;
		Saving.FabrykaZapis2_ok = false;
		Saving.LewyPotokZapis_ok = false;
		Saving.KombinerkiZapis_ok = false;
		Saving.KukurydzaZapis_ok = false;
		Saving.KluczSzafaKorytarzZapis_ok = false;
		Saving.IdzSzlakZapis_ok = false;
        Saving.PrzedPajakJumpscareZapis_ok = false;
		Saving.PrzedostanSieZapis_ok = false;
		Saving.ObozTomZapis_ok = false;
		Saving.TomGoraZapis_ok = false;
		Saving.MonsterTomZapis_ok = false;
		Saving.IdzWawozZapis_ok = false;
		Saving.PrzedStevenZapis_ok = false;
		Saving.MonsterMiesoZapis_ok = false;
		Saving.GrzybZapis_ok = false;
		Saving.SzopaStevenZapis_ok = false;
		Saving.PaulZapis_ok = false;
		Saving.PaulGoraZapis_ok = false;
		Saving.ChatkaZapis_ok = false;
		Saving.KryjowkaZapis_ok = false;

        // Gracz

		Player.maxStamina = 150f;
		Player.currentStamina = 150f;
		Player.staminaRegenerationFactor = 8;
        Player.isRest = true;
        Player.isSprint = false;
        Player.isSprintEffect = false;

        // ekwipunek

		Inventory.secretItemsCount = 0;
		Inventory.secretPlacesCount = 0;
		Inventory.blueHerbsCount = 0;
		Inventory.greenHerbsCount = 0;
		Inventory.healthPotsCount = 0;
		Inventory.staminaPotsCount = 0;
        Inventory.vialsCount = 0;

		Inventory.isRockyGraveSP = false;
		Inventory.isAnimalCementarySP = false;
		Inventory.isSimonGardenSP = false;
		Inventory.isTomCampSP = false;
		Inventory.isDevilsShelterSP = false;
		Inventory.isWarCementarySP = false;
		Inventory.isHutSP = false;
		Inventory.isBasementSP = false;
		Inventory.isMushroomFieldSP = false;
		Inventory.isDarkForestSP = false;
		Inventory.isBonesTowerSP = false;
		Inventory.isKnifeArenaSP = false;
		Inventory.isCaveSP = false;
		Inventory.isMonumentSP = false;
		Inventory.isSpaceshipSP = false;

		Inventory.isKeyV1Taken = false;
		Inventory.isOilTaken = false;
		Inventory.isKeyV2Taken = false;
		Inventory.isKeyV3Taken = false;
		Inventory.isKeyV4Taken = false;
		Inventory.isBatteriesTaken = false;
		Inventory.isCassete1Taken = false;
		Inventory.isBone1Taken = false;
		Inventory.isBone2Taken = false;
		Inventory.isBone3Taken = false;
		Inventory.isBone4Taken = false;
		Inventory.isBone5Taken = false;
		Inventory.isNicheKeyTaken = false;
		Inventory.isSecretRoomKeyTaken = false;
		Inventory.isBrokenFactoryKeyTaken = false;
		Inventory.isWoodenWheelTaken = false;
		Inventory.isFixedKeyTaken = false;
		Inventory.isCrowbarTaken = false;
		Inventory.isAliceKeyTaken = false;
		Inventory.isPliersTaken = false;
		Inventory.isAxeTaken = false;
		Inventory.isWardrobeCorridorKeyTaken = false;
		Inventory.isShedCupboardKeyTaken = false;
		Inventory.isCassete2Taken = false;
		Inventory.isPumpkinTaken = false;
		Inventory.isTomUpstairsKeyTaken = false;
		Inventory.isTomRoomKeyTaken = false;
		Inventory.isCassete3Taken = false;
		Inventory.isChipTaken = false;
		Inventory.isOldWardrobeKeyTaken = false;
		Inventory.isCassete4Taken = false;
		Inventory.isStevenKeyTaken = false;
		Inventory.isLabPlantTaken = false;
		Inventory.isLabMushroomTaken = false;
		Inventory.isLabSkullTaken = false;
		Inventory.isStrongAcidTaken = false;
		Inventory.isPaulKeyTaken = false;

		Inventory.isKeyV1Removed = false;
		Inventory.isOilRemoved= false;
		Inventory.isKeyV2Removed = false;
		Inventory.isKeyV3Removed = false;
		Inventory.isKeyV4Removed = false;
		Inventory.isBatteriesRemoved = false;
		Inventory.isCassete1Removed = false;
		Inventory.isBone1Removed = false;
		Inventory.isBone2Removed = false;
		Inventory.isBone3Removed = false;
		Inventory.isBone4Removed = false;
		Inventory.isBone5Removed = false;
		Inventory.isNicheKeyRemoved = false;
		Inventory.isSecretRoomKeyRemoved = false;
		Inventory.isBrokenFactoryKeyRemoved = false;
		Inventory.isWoodenWheelRemoved = false;
		Inventory.isFixedKeyRemoved = false;
		Inventory.isCrowbarRemoved = false;
		Inventory.isAliceKeyRemoved = false;
		Inventory.isPliersRemoved = false;
		Inventory.isAxeRemoved = false;
		Inventory.isWardrobeCorridorKeyRemoved = false;
		Inventory.isShedCupboardKeyRemoved = false;
		Inventory.isCassete2Removed = false;
		Inventory.isPumpkinRemoved = false;
		Inventory.isTomUpstairsKeyRemoved = false;
		Inventory.isTomRoomKeyRemoved = false;
		Inventory.isCassete3Removed = false;
		Inventory.isChipRemoved = false;
		Inventory.isOldWardrobeKeyRemoved = false;
		Inventory.isCassete4Removed = false;
		Inventory.isStevenKeyRemoved = false;
		Inventory.isLabPlantRemoved = false;
		Inventory.isLabMushroomRemoved = false;
		Inventory.isLabSkullRemoved = false;
		Inventory.isStrongAcidRemoved = false;
		Inventory.isPaulKeyRemoved = false;

		Inventory.isSecretIem1 = false;
		Inventory.isSecretIem2 = false;
		Inventory.isSecretIem3 = false;
		Inventory.isSecretIem4 = false;
		Inventory.isSecretIem5 = false;
		Inventory.isSecretIem6 = false;
		Inventory.isSecretIem7 = false;
		Inventory.isSecretIem8 = false;
		Inventory.isSecretIem9 = false;
		Inventory.isSecretIem10 = false;
		Inventory.isSecretIem11 = false;
		Inventory.isSecretIem12 = false;
		Inventory.isSecretIem13 = false;
		Inventory.isSecretIem14 = false;
		Inventory.isSecretIem15 = false;
		Inventory.isSecretIem16 = false;
		Inventory.isSecretIem17 = false;
		Inventory.isSecretIem18 = false;
		Inventory.isSecretIem19 = false;
		Inventory.isSecretIem20 = false;
		Inventory.isSecretIem21 = false;
		Inventory.isSecretIem22 = false;
		Inventory.isSecretIem23 = false;
		Inventory.isSecretIem24 = false;
		Inventory.isSecretIem25 = false;
        Inventory.isSecretIem26 = false;
        Inventory.isSecretIem27 = false;
        Inventory.isSecretIem28 = false;
        Inventory.isSecretIem29 = false;
        Inventory.isSecretIem30 = false;
        Inventory.isSecretIem31 = false;
        Inventory.isSecretIem32 = false;

        Inventory.isGreenHerb1 = false;
		Inventory.isGreenHerb2 = false;
		Inventory.isGreenHerb3 = false;
		Inventory.isGreenHerb4 = false;
		Inventory.isGreenHerb5 = false;
		Inventory.isGreenHerb6 = false;
		Inventory.isGreenHerb7 = false;
		Inventory.isGreenHerb8 = false;
		Inventory.isGreenHerb9 = false;
		Inventory.isGreenHerb10 = false;
		Inventory.isGreenHerb11 = false;
		Inventory.isGreenHerb12 = false;
		Inventory.isGreenHerb13 = false;
		Inventory.isGreenHerb14 = false;
		Inventory.isGreenHerb15 = false;
		Inventory.isGreenHerb16 = false;
		Inventory.isGreenHerb17 = false;
		Inventory.isGreenHerb18 = false;
		Inventory.isGreenHerb19 = false;
		Inventory.isGreenHerb20 = false;
		Inventory.isGreenHerb21 = false;
		Inventory.isGreenHerb22 = false;
        Inventory.isGreenHerb23 = false;
        Inventory.isGreenHerb24 = false;
        Inventory.isGreenHerb25 = false;
        Inventory.isGreenHerb26 = false;
        Inventory.isGreenHerb27 = false;
        Inventory.isGreenHerb28 = false;
        Inventory.isGreenHerb29 = false;
        Inventory.isGreenHerb30 = false;
        Inventory.isGreenHerb31 = false;
        Inventory.isGreenHerb32 = false;

        Inventory.isBlueHerb1 = false;
		Inventory.isBlueHerb2 = false;
		Inventory.isBlueHerb3 = false;
		Inventory.isBlueHerb4 = false;
		Inventory.isBlueHerb5 = false;
		Inventory.isBlueHerb6 = false;
		Inventory.isBlueHerb7 = false;
		Inventory.isBlueHerb8 = false;
		Inventory.isBlueHerb9 = false;
		Inventory.isBlueHerb10 = false;
		Inventory.isBlueHerb11 = false;
		Inventory.isBlueHerb12 = false;
		Inventory.isBlueHerb13 = false;
		Inventory.isBlueHerb14 = false;
		Inventory.isBlueHerb15 = false;
		Inventory.isBlueHerb16 = false;
		Inventory.isBlueHerb17 = false;
		Inventory.isBlueHerb18 = false;
		Inventory.isBlueHerb19 = false;
		Inventory.isBlueHerb20 = false;
		Inventory.isBlueHerb21 = false;
		Inventory.isBlueHerb22 = false;
        Inventory.isBlueHerb23 = false;
        Inventory.isBlueHerb24 = false;
        Inventory.isBlueHerb25 = false;
        Inventory.isBlueHerb26 = false;
        Inventory.isBlueHerb27 = false;
        Inventory.isBlueHerb28 = false;
        Inventory.isBlueHerb29 = false;
        Inventory.isBlueHerb30 = false;
        Inventory.isBlueHerb31 = false;
        Inventory.isBlueHerb32 = false;

        Inventory.isVial1 = false;
        Inventory.isVial2 = false;
        Inventory.isVial3 = false;
        Inventory.isVial4 = false;
        Inventory.isVial5 = false;
        Inventory.isVial6 = false;
        Inventory.isVial7 = false;
        Inventory.isVial8 = false;
        Inventory.isVial9 = false;
        Inventory.isVial10 = false;
        Inventory.isVial11 = false;
        Inventory.isVial12 = false;
        Inventory.isVial13 = false;
        Inventory.isVial14 = false;
        Inventory.isVial15 = false;
        Inventory.isVial16 = false;

        Inventory.isStaminaPot1 = false;
        Inventory.isStaminaPot2 = false;
        Inventory.isStaminaPot3 = false;
        Inventory.isStaminaPot4 = false;
        Inventory.isStaminaPot5 = false;

        Inventory.isHealthPot1 = false;
        Inventory.isHealthPot2 = false;
        Inventory.isHealthPot3 = false;
        Inventory.isHealthPot4 = false;
        Inventory.isHealthPot5 = false;
        Inventory.isHealthPot6 = false;

        Inventory.isBadge1 = false;
        Inventory.isBadge2 = false;
        Inventory.isBadge3 = false;
        Inventory.isBadge4 = false;
        Inventory.isBadge5 = false;
        Inventory.isBadge6 = false;
        Inventory.isBadge7 = false;
        Inventory.isBadge8 = false;
        Inventory.isBadge9 = false;
        Inventory.isBadge10 = false;
        Inventory.isBadge11 = false;
        Inventory.isBadge12 = false;

        Inventory.isPhoto1 = false;
        Inventory.isPhoto2 = false;
        Inventory.isPhoto3 = false;
        Inventory.isPhoto4 = false;
        Inventory.isPhoto5 = false;
        Inventory.isPhoto6 = false;
        Inventory.isPhoto7 = false;
        Inventory.isPhoto8 = false;
        Inventory.isPhoto9 = false;
        Inventory.isPhoto10 = false;
        Inventory.isPhoto11 = false;
        Inventory.isPhoto12 = false;

        Inventory.isTip1 = false;
        Inventory.isTip2 = false;
        Inventory.isTip3 = false;
        Inventory.isTip4 = false;
        Inventory.isTip5 = false;
        Inventory.isTip6 = false;
        Inventory.isTip7 = false;
        Inventory.isTip8 = false;
        Inventory.isTip9 = false;
        Inventory.isTip10 = false;
        Inventory.isTip11 = false;
        Inventory.isTip12 = false;

        Inventory.isSkill1_Unlocked = false;
		Inventory.isSkill2_Unlocked = false;
		Inventory.isSkill3_Unlocked = false;
		Inventory.isSkill4_Unlocked = false;

        Inventory.badgesCount = 0;
        Inventory.tipsCount = 0;
        Inventory.photosCount = 0;
        Inventory.skillsCount = 0;

        // Glos bohatera

        BohaterGlos.isGameBegin = false;

		BohaterGlos.isBeginGameRecording = false;
		BohaterGlos.isFenceRecording = false;
		BohaterGlos.isHouseLightRecording = false;
		BohaterGlos.isKitchenRecording = false;
		BohaterGlos.isBigRoomRecording = false;
		BohaterGlos.isArthurRoomRecording = false;
		BohaterGlos.isToolShedRecording = false;
		BohaterGlos.isAliceHouseRecording = false;
		BohaterGlos.isHallunsRecording = false;
		BohaterGlos.isWorkshopRecording = false;
		BohaterGlos.isLeftBrookRecording = false;
		BohaterGlos.isAnnaNoteRecording = false;
		BohaterGlos.isPliersRecording = false;
		BohaterGlos.isCornfieldRecording = false;
		BohaterGlos.isOldShedRecording = false;
		BohaterGlos.isAxeRecording = false;
		BohaterGlos.isAfterCasseteRecording = false;
		BohaterGlos.isBooksRecording = false;
		BohaterGlos.isRavineRecording = false;
		BohaterGlos.isStevenHouseRecording = false;
		BohaterGlos.isAcidRecording = false;
		BohaterGlos.isStevenShedRecording = false;
		BohaterGlos.isDevilsBrookRecording = false;
		BohaterGlos.isDevilsShelterRecording = false;

        BohaterGlos.isWellRecording = false;
        BohaterGlos.isStableRecording = false;
        BohaterGlos.isGardenRecording = false;
        BohaterGlos.isGardenRecording = false;
        BohaterGlos.isSecretRoomRecording = false;
        BohaterGlos.isInventionRecording = false;
        BohaterGlos.isWardrobeCorridorRecording = false;
        BohaterGlos.isChipRecording = false;
        BohaterGlos.isArthurTipRecording = false;
        BohaterGlos.isMonstersPlantsRecording = false;
        BohaterGlos.isZenoRecording = false;

        BohaterGlos.isRetroBigRoomRecording = false;
		BohaterGlos.isRetroArthurRoomRecording = false;
		BohaterGlos.isRetroToolShedRecording = false;
		BohaterGlos.isRetroAliceHouseRecording = false;
		BohaterGlos.isRetroWorkshopRecording = false;
		BohaterGlos.isRetroCornfieldRecording = false;
		BohaterGlos.isRetroOldShedRecording = false;
		BohaterGlos.isRetroBooksRecording = false;
		BohaterGlos.isRetroStevenHouseRecording = false;
		BohaterGlos.isRetroStevenShedRecording = false;

        BohaterGlos.isStartRetro = false;
        BohaterGlos.isMidRetro = false;
        BohaterGlos.isEndRetro = false;
        BohaterGlos.isResetRetro = false;

        BohaterGlos.isBeginGameSubtitles = false;
		BohaterGlos.isFenceSubtitles = false;
		BohaterGlos.isHouseLightSubtitles = false;
		BohaterGlos.isKitchenSubtitles = false;
		BohaterGlos.isBigRoomSubtitles = false;
		BohaterGlos.isArthurRoomSubtitles = false;
		BohaterGlos.isToolShedSubtitles = false;
		BohaterGlos.isCassete1Subtitles = false;
		BohaterGlos.isAliceHouseSubtitles = false;
		BohaterGlos.isHallunsSubtitles = false;
		BohaterGlos.isWorkshopSubtitles = false;
		BohaterGlos.isLeftBrookSubtitles = false;
		BohaterGlos.isAnnaNoteSubtitles = false;
		BohaterGlos.isPliersSubtitles = false;
		BohaterGlos.isCornfieldSubtitles = false;
		BohaterGlos.isAxeSubtitles = false;
		BohaterGlos.isOldShedSubtitles = false;
		BohaterGlos.isCassete2Subtitles = false;
		BohaterGlos.isAfterCasseteSubtitles = false;
		BohaterGlos.isBooksSubtitles = false;
		BohaterGlos.isCassete3Subtitles = false;
		BohaterGlos.isRavineSubtitles = false;
		BohaterGlos.isCassete4Subtitles = false;
		BohaterGlos.isStevenHouseSubtitles = false;
		BohaterGlos.isAcidSubtitles = false;
		BohaterGlos.isStevenShedSubtitles = false;
		BohaterGlos.isDevilsBrookSubtitles = false;
		BohaterGlos.isCassete5Subtitles = false;
		BohaterGlos.isDevilsShelterSubtitles = false;

        BohaterGlos.isWoodSubtitles = false;
        BohaterGlos.isWellSubtitles = false;
        BohaterGlos.isStableSubtitles = false;
        BohaterGlos.isGardenSubtitles = false;
        BohaterGlos.isSecretRoomSubtitles = false;
        BohaterGlos.isInventionSubtitles = false;
        BohaterGlos.isWardrobeCorridorSubtitles = false;
        BohaterGlos.isChipSubtitles = false;
        BohaterGlos.isArthurTipSubtitles = false;
        BohaterGlos.isMonstersPlantsSubtitles = false;
        BohaterGlos.isZenoSubtitles = false;

        BohaterGlos.isEndGame = false;
        BohaterGlos.isMonster = false;
        BohaterGlos.isDead = false;
        BohaterGlos.isWhisper = false;

        // jumpscare

        JumpScare.isBrookMonster1_On = false;
        JumpScare.isBrookMonster1_Off = false;
        JumpScare.counter1 = 0;
		JumpScare.isCornfieldMonster = false;
		JumpScare.isCorridorMonster = false;
		JumpScare.isCornfieldMonster2 = false;
		JumpScare.isChannelMonster = false;
		JumpScare.isMeatMonsters = false;
		JumpScare.isPaulRoomMonster = false;
		JumpScare.isPaulDoorMonster = false;
		JumpScare.isGardenMonster = false;
		JumpScare.isWorkshopMonster = false;
		JumpScare.isPumpkinMonster_On = false;
		JumpScare.isPumpkinMonster_Off = false;
		JumpScare.isAbandonedMonster = false;
        JumpScare.abandonedMonsterTime = 0;
        JumpScare.isAbandonedMonsterStop = false;
		JumpScare.isShedMonster1 = false;
		JumpScare.isTomMonster = false;
		JumpScare.isPlantMonster = false;
		JumpScare.isBushMonster_On = false;
		JumpScare.isBushMonster_Off = false;
		JumpScare.isPaulDownstairsMonster = false;
		JumpScare.isStevenShedMonster1 = false;
		JumpScare.isStevenShedMonster2 = false;
        JumpScare.isPlayerSave = false;
        JumpScare.isBeginMonster = false;
        JumpScare.isStableMonster = false;
        JumpScare.isSecretRoomMonster = false;
        JumpScare.isWolf1 = false;
        JumpScare.isBeginWolves = false;
        JumpScare.isJumpscareSpider1 = false;
        JumpScare.isJumpscareSpider2 = false;
        JumpScare.isSpider3_On = false;
        JumpScare.isSpider3_Off = false;
        JumpScare.isSpider4 = false;
        JumpScare.isWolf1 = false;
        JumpScare.isWolf2 = false;
        JumpScare.isWolf3 = false;
        JumpScare.isSpider5 = false;

        // komunikaty

        Kom.notificationTime = 3f;
        Kom.collectibleTime = 3f;
        Kom.secretPlacesTime = 3f;
        Kom.taskHintTime = 5f;
        Kom.isNotificationTimeOn = false;
        Kom.isSecretItemNotification = false;
        Kom.isGreenHerbNotification = false;
        Kom.isBlueHerbNotification = false;
        Kom.isVialNotification = false;
        Kom.isBadgeNotification = false;
        Kom.isPhotoNotification = false;
        Kom.isTipNotification = false;
        Kom.isTutorialNotification = false;

        Kom.isLightNotification = false;
        Kom.isLight2Notification = false;
        Kom.isTaskInfoNotification = false;
        Kom.isSprintNotification = false;
		Kom.isMapNotification = false;
		Kom.isCrouchNotification = false;
        Kom.isDoorNotification = false;
        Kom.isHerbsNotification = false;
        Kom.isSaveNotification = false;
        Kom.isDragNotification = false;
        Kom.isPushNotification = false;
        Kom.isSecretNotification = false;
        Kom.isItemsNotification = false;
        Kom.isInventoryNotification = false;
        Kom.isBatteriesNotification = false;
		Kom.isChipNotification = false;
		Kom.isCasseteNotification = false;
		Kom.isCassete3Notification = false;

        Kom.isGardenDoor = false;
        Kom.isCornfieldDoor = false;
        Kom.isStableDoor = false;
        Kom.isCorridorWardrobe = false;
        Kom.isUncleDoor = false;
        Kom.isKitchenWardrobe = false;
        Kom.isSecretRoomDoor = false;
        Kom.isPlanks = false;
        Kom.isToolShedDoor = false;
        Kom.isNicheDoor = false;
        Kom.isCassetePlayer = false;
        Kom.isAliceRoomDoor = false;
        Kom.isFactoryMetalDoor = false;
        Kom.isVictorInvention = false;
        Kom.isFactoryWoodenDoor = false;
        Kom.isShedCupboard = false;
        Kom.isTomRoomDoor = false;
        Kom.isTomUpstairsDoor = false;
        Kom.isPumpkinPile = false;
        Kom.isCassetePlayer2 = false;
        Kom.isOldWardrobe = false;
        Kom.isCassetePlayer3 = false;
        Kom.isStevenDoor = false;
        Kom.isStevenGrille = false;
        Kom.isPaulDoor = false;
        Kom.isPaulJumpscareDoor = false;
        Kom.isThorns = false;

        // Latarka

        SwiatloLatarki.lightRange = 40;
		SwiatloLatarki.isFlashlightOn = false;

        // Muzyka

        MuzykaGry.randomMusicDuration = 0;
		MuzykaGry.isMusicOff = false;

		MuzykaGry.isHouseLightMusicOff = false;
		MuzykaGry.isSimonWorkshopMusicOff = false;
        MuzykaGry.isOldShedMusicOff = false;
		MuzykaGry.isOldShedMusic2Off = false;
		MuzykaGry.isAfterTomMusicOff = false;

        MuzykaGry.isBeginMusic = false;
        MuzykaGry.isBeginMonsterMusic = false;
        MuzykaGry.isBeginMonsterMusicStop = false;
        MuzykaGry.isAfterWolfMusic = false;
		MuzykaGry.isBehindHouseMusic = false;
		MuzykaGry.isKitchenMusic = false;
		MuzykaGry.isUncleRoomMusic = false;
		MuzykaGry.isMusicStop = false;
		MuzykaGry.isToolShedMusic = false;
		MuzykaGry.isWellMusic = false;
		MuzykaGry.isWellAnxiousMusic = false;
		MuzykaGry.isStableMusic = false;
		MuzykaGry.isGardenMusic = false;
		MuzykaGry.isBonesMusic = false;
		MuzykaGry.isAliceMusic = false;
		MuzykaGry.isAliceShedMusic = false;
		MuzykaGry.isWorkshopMusic = false;
		MuzykaGry.isWorkshopSimonMusic = false;
		MuzykaGry.isAnimalCemetaryMusic = false;
		MuzykaGry.isAliceRoomMusic = false;
		MuzykaGry.isShedMusic = false;
		MuzykaGry.isOldShedMusic = false;
		MuzykaGry.isBeforeTomMusic = false;
		MuzykaGry.isTomMusic = false;
		MuzykaGry.isTomHallMusic = false;
		MuzykaGry.isTom2Music = false;
		MuzykaGry.isBooksMusic = false;
		MuzykaGry.isTom3Music = false;
		MuzykaGry.isCornfieldMusic = false;
		MuzykaGry.isTomCampMusic = false;
		MuzykaGry.isTomUpstairsMusic = false;
		MuzykaGry.isTomUpstairs2Music = false;
		MuzykaGry.isAfterTomMusic = false;
		MuzykaGry.isFeederMusic = false;
		MuzykaGry.isBeforeStevenMusic = false;
		MuzykaGry.isStevenMusic = false;
		MuzykaGry.isMeatMusic = false;
		MuzykaGry.isStevenUpstairsMusic = false;
		MuzykaGry.isStevenShedMusic = false;
		MuzykaGry.isBeforePaulMusic = false;
		MuzykaGry.isPaulMusic = false;
		MuzykaGry.isPaulUpstairsMusic = false;
		MuzykaGry.isHutMusic = false;
		MuzykaGry.isMonsterUpstairsMusic = false;
		MuzykaGry.isMonsterUpstairs2Music = false;
		MuzykaGry.isBeforeShelterMusic = false;
		MuzykaGry.isShelterMusic = false;
		MuzykaGry.isShelter2Music = false;
		MuzykaGry.isEndGameMusic = false;
        MuzykaGry.isBigRoomMusic = false;
        MuzykaGry.isLeftBrookMusic = false;
        MuzykaGry.isCornfield1Music = false;
        MuzykaGry.isAfterFlashlightMusic = false;
        MuzykaGry.isGrandmaDoorMusic = false;

        MuzykaGry.isGardenMonsterMusic = false;
		MuzykaGry.isGardenMonsterMusic_On = false;
		MuzykaGry.isWorkshopMonsterMusic = false;
		MuzykaGry.isWorkshopMonsterMusic_On = false;
		MuzykaGry.isLeftBrookMonsterMusic = false;
		MuzykaGry.isLeftBrookMonsterMusic_On = false;
		MuzykaGry.isCorridorMonsterMusic = false;
		MuzykaGry.isCorridorMonsterMusic_On = false;
		MuzykaGry.isCornfieldMonsterMusic = false;
		MuzykaGry.isCornfieldMonsterMusic_On = false;
		MuzykaGry.isPumpkinMonsterMusic = false;
		MuzykaGry.isPumpkinMonsterMusic_On = false;
		MuzykaGry.isAbandonedMonsterMusic = false;
		MuzykaGry.isAbandonedMonsterMusic_On = false;
		MuzykaGry.isMeatMonsterMusic = false;
		MuzykaGry.isMeatMonsterMusic_On = false;
		MuzykaGry.isBasementMonsterMusic = false;
		MuzykaGry.isPlantMonsterMusic = false;
		MuzykaGry.isStevenMonsterMusic = false;

        // Notatki

        Notes.notesCount = 0;
		Notes.isNote1 = false;
		Notes.isNote2 = false;
		Notes.isNote3 = false;
		Notes.isNote4 = false;
		Notes.isNote5 = false;
		Notes.isNote6 = false;
		Notes.isNote7 = false;
		Notes.isNote8 = false;
		Notes.isNote9 = false;
		Notes.isNote10 = false;
		Notes.isNote11 = false;
		Notes.isNote12 = false;
		Notes.isNote13 = false;
		Notes.isNote14 = false;
		Notes.isNote15 = false;
		Notes.isNote16 = false;
		Notes.isNote17 = false;
		Notes.isNote18 = false;
		Notes.isNote19 = false;
		Notes.isNote20 = false;
		Notes.isNote21 = false;
		Notes.isNote22 = false;
		Notes.isNote23 = false;
		Notes.isNote24 = false;
		Notes.isNote25 = false;
		Notes.isNote26 = false;
		Notes.isNote27 = false;
		Notes.isNote28 = false;
		Notes.isNote29 = false;
		Notes.isNote30 = false;
		Notes.isNote31 = false;
		Notes.isNote32 = false;
		Notes.isNote33 = false;
		Notes.isNote34 = false;
		Notes.isNote35 = false;
		Notes.isNote36 = false;
		Notes.isNote37 = false;
		Notes.isNote38 = false;
		Notes.isNote39 = false;
		Notes.isNote40 = false;
		Notes.isNote41 = false;
		Notes.isNote42 = false;
		Notes.isNote43 = false;
		Notes.isNote44 = false;
		Notes.isNote45 = false;
		Notes.isNote46 = false;
		Notes.isNote47 = false;
		Notes.isNote48 = false;
		Notes.isNote49 = false;
		Notes.isNote50 = false;
		Notes.isNote51 = false;
		Notes.isNote52 = false;
		Notes.isNote53 = false;
		Notes.isNote54 = false;
		Notes.isFoxNote = false;
		Notes.isWoodPhoto = false;
		Notes.isZenoPhoto = false;
		Notes.isShoppingNote = false;
		Notes.isQuote1Note = false;
		Notes.isCornfieldPicture = false;
		Notes.isLeftBrookNote = false;
		Notes.isMushroomNote = false;
		Notes.isBrookPhoto3 = false;
		Notes.isBrookPhoto2 = false;
		Notes.isBrookPhoto1 = false;
		Notes.isSimonPicture = false;
		Notes.isRapNote = false;
		Notes.isTowerPhoto = false;
		Notes.isWellPhoto = false;
		Notes.isQuote2Note = false;
		Notes.isMonumentPhoto = false;
		Notes.isInventionNote = false;
		Notes.isWorkshopPhoto = false;
		Notes.isDarkForestNote = false;
		Notes.isAnimalsNote = false;
		Notes.isNightNote = false;
		Notes.isWardrobePhoto = false;
		Notes.isShedPhoto = false;
		Notes.isCampPhoto = false;
		Notes.isMaryNote = false;
		Notes.isDaughterPicture = false;
		Notes.isDiplomaNote = false;
		Notes.isTomPicture = false;
		Notes.isQuote3Note = false;
		Notes.isMonsterPicture = false;
		Notes.iswhisperNote = false;
		Notes.isQuote4Note = false;
		Notes.isPlantPicture = false;
		Notes.isFieldNote = false;
		Notes.isArenaNote = false;
		Notes.isQuote5Note = false;
		Notes.isBrookPhoto4 = false;
		Notes.isAliensNote = false;
		Notes.isQuote6Note = false;
        Notes.isDemonNote = false;

        // Screamery

		Straszak.isClock = false;
		Straszak.isKitchenLamp = false;
		Straszak.isLampBefore = false;
		Straszak.isLight = false;
		Straszak.isRustle = false;
		Straszak.isHay = false;
		Straszak.isWood = false;
		Straszak.isWolf = false;
		Straszak.isRustle2 = false;
		Straszak.isAtmosphere = false;
		Straszak.isWhisper = false;
		Straszak.isRadioSpain = false;
		Straszak.isWellScream = false;
		Straszak.isWoodShed = false;
		Straszak.isRat = false;
		Straszak.isWellWater = false;
		Straszak.isRadioFires = false;
		Straszak.isFactory = false;
		Straszak.isChains = false;
		Straszak.isFactory2 = false;
		Straszak.isMeanLaugh = false;
		Straszak.isActiveLaugh = false; 
		Straszak.isRaven = false; 
		Straszak.isGirlLaugh = false; 
		Straszak.isClock = false; 
		Straszak.isMusicBox = false; 
		Straszak.isKnock = false; 
		Straszak.isGlass = false;
		Straszak.isStairsCreak = false;
		Straszak.isStevenScream = false;
		Straszak.isDoorBellActive = false;
		Straszak.isDoorBell = false;
		Straszak.isPaulCreak = false;
		Straszak.isSteps = false;
		Straszak.isPaulStairsCreak = false;
		Straszak.isCloseDoor = false;
		Straszak.isOpenDoor = false;
		Straszak.isCorpse = false;
		Straszak.isWhisper2 = false;
		Straszak.isWind = false;
		Straszak.isWindEffect = false;
		Straszak.isTool = false;
		Straszak.isBones = false;
		Straszak.isThorns = false;
		Straszak.isFood = false;
		Straszak.isDog = false;
		Straszak.isBrook = false;
		Straszak.isBreath = false;
		Straszak.isBreath2 = false;
		Straszak.isPhone = false;
		Straszak.isPhone2 = false;
		Straszak.isWellWhispers = false;
        Straszak.isShelterWhispers = false;
        Straszak.isDogRoar = false;
        Straszak.isBoneShedBreath = false;
        Straszak.isWoodBird = false;
        Straszak.isLeaves = false;
        Straszak.isShedFurniture = false;
        Straszak.isBrookScream = false;
        Straszak.isGrandmaGlass = false;
        Straszak.isGlassKnock = false;
        Straszak.isAliceShed = false;
        Straszak.isHutLight = false;
        Straszak.isFloorCreak = false;
        Straszak.isScaryOwl = false;
        Straszak.isScaryOwl2 = false;
        Straszak.isWaterSplash = false;
        Straszak.isFoxScream = false;
        Straszak.isShockScream = false;
        Straszak.isFallTree = false;
        Straszak.isOpenJumpscareDoor = false;

        // Zadania

        Tasks.isFirstTask = true;
		Tasks.isSearchTask = false;
		Tasks.isWoodKeyTask = false;
		Tasks.isMagicWellTask = false;
		Tasks.isWellStonesTask = false;
		Tasks.isCassete1Task = false;
        Tasks.isGardenDoorTask = false;
		Tasks.isBonesTask = false;
		Tasks.isGoToAliceTask = false;
		Tasks.isAliceSearchTask = false;
		Tasks.isSimonElementTask = false;
        Tasks.isWorkshopTask = false;
		Tasks.isBrokenKeyTask = false;
		Tasks.isFixKeyTask = false;
		Tasks.isAnimalCemetaryTask = false;
		Tasks.isVictorBrookTask = false;
		Tasks.isAliceRoomTask = false;
		Tasks.isCornfieldTask = false;
		Tasks.isAxeTask = false;
		Tasks.isCorridorWardrobeTask = false;
		Tasks.isEdwardCupboardTask = false;
		Tasks.isCassete2Task = false;
		Tasks.isGoToTrialTask = false;
		Tasks.isGoTrailTask = false;
		Tasks.isGetToTomRoadTask = false;
		Tasks.isTomSearchTask = false;
		Tasks.isTomCornifieldTask = false;
		Tasks.isCassete3Task = false;
		Tasks.isTompCampTask = false;
		Tasks.isTomPumpkinTask = false;
		Tasks.isTomChipTask = false;
		Tasks.isRavineTask = false; 
		Tasks.isGoRavineTask = false;
		Tasks.isAbandonedSearchTask = false;
		Tasks.isCassete4Task = false;
		Tasks.isStevenSearchTask = false;
		Tasks.isStevenKeyTask = false;
		Tasks.isStevenMushroomTask = false;
		Tasks.isStevenPlantTask = false;
		Tasks.isStevenSkullTask = false;
		Tasks.isStevenAcidTask = false;
		Tasks.isStevenShedTask = false;
		Tasks.isStevenNoteTask = false;
		Tasks.isStevenBrookTask = false;
		Tasks.isPaulSearchTask = false;
		Tasks.isPaulDoorTask = false;
		Tasks.isHutTask = false;
		Tasks.isDevilsBrookTask = false;
		Tasks.isDevilsShelterTask = false;
		Tasks.isShelterFamilyTask = false;

		Tasks.isFirstTaskRemoved = false;
		Tasks.isSearchTaskRemoved = false;
		Tasks.isWoodKeyTaskRemoved = false;
		Tasks.isMagicWellTaskRemoved = false;
		Tasks.isWellStonesTaskRemoved = false;
		Tasks.isCassete1TaskRemoved = false;
        Tasks.isGardenDoorTaskRemoved = false;
        Tasks.isBonesTaskRemoved = false;
		Tasks.isGoToAliceTaskRemoved = false;
		Tasks.isAliceSearchTaskRemoved = false;
		Tasks.isSimonElementTaskRemoved = false;
        Tasks.isWorkshopTaskRemoved = false;
		Tasks.isBrokenKeyTaskRemoved = false;
		Tasks.isFixKeyTaskRemoved = false;
		Tasks.isAnimalCemetaryTaskRemoved = false;
		Tasks.isVictorBrookTaskRemoved = false;
		Tasks.isAliceRoomTaskRemoved = false;
		Tasks.isCornfieldTaskRemoved = false;
		Tasks.isAxeTaskRemoved = false;
		Tasks.isCorridorWardrobeTaskRemoved = false;
		Tasks.isEdwardCupboardTaskRemoved = false;
		Tasks.isCassete2TaskRemoved = false;
		Tasks.isGoToTrialTaskRemoved = false;
		Tasks.isGoTrailTaskRemoved = false;
		Tasks.isGetToTomRoadTaskRemoved = false;
		Tasks.isTomSearchTaskRemoved = false;
		Tasks.isTomCornifieldTaskRemoved = false;
		Tasks.isCassete3TaskRemoved = false;
		Tasks.isTompCampTaskRemoved = false;
		Tasks.isTomPumpkinTaskRemoved = false;
		Tasks.isTomChipTaskRemoved = false;
		Tasks.isRavineTaskRemoved = false; 
		Tasks.isGoRavineTaskRemoved = false;
		Tasks.isAbandonedSearchTaskRemoved = false;
		Tasks.isCassete4TaskRemoved = false;
		Tasks.isStevenSearchTaskRemoved = false;
		Tasks.isStevenKeyTaskRemoved = false;
		Tasks.isStevenMushroomTaskRemoved = false;
		Tasks.isStevenPlantTaskRemoved = false;
		Tasks.isStevenSkullTaskRemoved = false;
		Tasks.isStevenAcidTaskRemoved = false;
		Tasks.isStevenShedTaskRemoved = false;
		Tasks.isStevenNoteTaskRemoved = false;
		Tasks.isStevenBrookTaskRemoved = false;
		Tasks.isPaulSearchTaskRemoved = false;
		Tasks.isPaulDoorTaskRemoved = false;
		Tasks.isHutTaskRemoved = false;
		Tasks.isDevilsBrookTaskRemoved = false;
		Tasks.isDevilsShelterTaskRemoved = false;
		Tasks.isShelterFamilyTaskRemoved = false;

		Tasks.isGoTrailVoice = false;

		Tasks.isGardenDoorLocked = true;
		Tasks.isCornfieldDoorLocked = true;
		Tasks.isStableDoorLocked = true;
		Tasks.isCorridorWardrobeLocked = true;
		Tasks.isUncleDoorLocked = true;
		Tasks.isKitchenWardrobeLocked = true;
		Tasks.isSecretRoomDoorLocked = true;
		Tasks.isPlanksLocked = true;
		Tasks.isPlanksDestroyed = false;
		Tasks.isToolShedDoorLocked = true;
		Tasks.isNicheDoorLocked = true;
		Tasks.isCasseteInserted = false;
		Tasks.isBatteriesPut = false;
		Tasks.isAliceRoomDoorLocked = true;
		Tasks.isHalluns = false;
		Tasks.isFactoryMetalDoorLocked = true;
		Tasks.isBrokenKey = false;
		Tasks.isWheel = false;
		Tasks.isFixedKey = false;
		Tasks.isFactoryWoodenDoorLocked = true;
		Tasks.isShedCupboardLocked = true;
		Tasks.isCassete2Inserted = false;
		Tasks.isTomRoomDoorLocked = true;
		Tasks.isTomUpstairsDoorLocked = true;
		Tasks.isCassete3Inserted = false;
		Tasks.isLackChip = false;
		Tasks.isChipPut = false;
		Tasks.isOldWardrobeLocked = true;
		Tasks.isCassete4Inserted = false;
		Tasks.isStevenDoorLocked = true;
		Tasks.isStevenGrille = true;
		Tasks.isPaulDoorLocked = true;
		Tasks.isCassete1Played = false;
		Tasks.isCassete2Played = false;
		Tasks.isCassete3Played = false;
		Tasks.isCassete4Played = false;
		Tasks.isCassete5Played = false;
		Tasks.isStevenShedLocked = false;
        Tasks.hallunsTimer = 0;

        Tasks.isHallunsFlashback = false;
		Tasks.isPumpkin = false;
		Tasks.isLabPlant = false;
		Tasks.isLabMushroom = false;
		Tasks.isLabSkull = false;
		Tasks.isLab = false;
        Tasks.isLabPot = false;
		Tasks.isGrilleDestroyed = false;
		Tasks.isThornsAcid = false;
		Tasks.isThorns = false;

        // Zdrowie

        ZdrowieGracza.health = ZdrowieGracza.maxHealth;
        ZdrowieGracza.isPlayerInjured = false;
        ZdrowieGracza.isStartCount = false;
        ZdrowieGracza.isDead = false;
        ZdrowieGracza.isPass = false;
        ZdrowieGracza.isGameLoaded = false;
        ZdrowieGracza.counter = 0;

    // Zadanie ksiazki

        ZadKsiazki.isTaskDone = false;
        ZadKsiazki.isBookTaken = false;
        ZadKsiazki.isButterflyBook = false;
        ZadKsiazki.isWaterBook = false;
        ZadKsiazki.isComputerBook = false;
        ZadKsiazki.isSpaceBook = false;
        ZadKsiazki.isSkyBook = false;
        ZadKsiazki.isTaskDone = false;

        // Zadanie Mieso

        ZadMieso.isDragMeat1 = false;
        ZadMieso.isDragMeat2 = false;
        ZadMieso.isDragMeat3 = false;
        ZadMieso.meat1Condition = 100;
        ZadMieso.meat2Condition = 100;
        ZadMieso.meat3Condition = 100;

        // Zakonczenie gry

        KoniecGry.Muzyka_ok = false;
        KoniecGry.Gazeta1_ok = false;
        KoniecGry.Gazeta2_ok = false;
        KoniecGry.Przejscie1_ok = false;
        KoniecGry.Przejscie2_ok = false;
        KoniecGry.Licznik = 0;
        KoniecGry.Credits_ok = false;

        // Halucynacje

        Halucynacje.isStartGanja1 = false;
        Halucynacje.isStartGanja2 = false;
        Halucynacje.isStartGanja3 = false;
        Halucynacje.isStartGanja4 = false;
        Halucynacje.isStartGanja5 = false;
        Halucynacje.isEndGanja1 = false;
        Halucynacje.isEndGanja2 = false;
        Halucynacje.isEndGanja3 = false;
        Halucynacje.isEndGanja4 = false;
        Halucynacje.isEndGanja5 = false;
        Halucynacje.isStartCount = false;
        Halucynacje.counter = 0;
        Halucynacje.fireCount = 0;

        // scarecrow straszak

        ScarecrowStraszak.MonsterKorytarzScarecrow_ok = false;
        ScarecrowStraszak.MonsterStajniaScarecrow_ok = false;
        ScarecrowStraszak.MonsterWychodekScarecrow_ok = false;
        ScarecrowStraszak.MonsterSzalasScarecrow_ok = false;
        ScarecrowStraszak.MonsterSzalasSchowal_ok = false;
        ScarecrowStraszak.MonsterSzopaScarecrow_ok = false;

        // Canvasy

        // Pointery Secret places

        SPGrobRockyPointer.enabled = false;
		SPCmentarzZwierzatPointer.enabled = false;
		SPOgrodSimonaPointer.enabled = false;
		SPObozTomaPointer.enabled = false;
		SPCmentarzWojnaPointer.enabled = false;
		SPDomekPointer.enabled = false;
		SPPiwnicaPointer.enabled = false;
		SPPoleGrzybowePointer.enabled = false;
		SPCiemnyLasPointer.enabled = false;
		SPWiezaKosciPointer.enabled = false;
		SPNozowaArenaPointer.enabled = false;
		SPJaskiniaPointer.enabled = false;
		SPPomnikPointer.enabled = false;
		SPStatekKosmicznyPointer.enabled = false;

        // Inventory Skills

		Skill1Icon.color = Color.white;
		Skill2Icon.color = Color.white;
		Skill3Icon.color = Color.white;
		Skill4Icon.color = Color.white;

        // Pointery Zadan na mapie

		KluczDrewnoPointer.enabled = false;
		MagicznaStudniaPointer.enabled = false;
		KamienieObszar.enabled = false;
        DrzwiOgrodPointer.enabled = false;
        KosciObszar.enabled = false;
		DomAlicePointer.enabled = false;
		SimonElementPointer.enabled = false;
        WarsztatPointer.enabled = false;
		ZepsutyKluczPointer.enabled = false;
		CmentarzZwierzPointer.enabled = false;
        StrzalkaCmentarzZwierzPointer.enabled = false;
        StrzalkaVictorPointer.enabled = false;
        StrzalkaVictorPointer2.enabled = false;
        KukurydzaPointer.enabled = false;
		SiekieraPointer.enabled = false;
		SzafaKorytarzPointer.enabled = false;
		Kaseta2Pointer.enabled = false;
		IdzSzlakPointer.enabled = false;
		StrzalkaSzlakPointer.enabled = false;
		PrzedostanSiePointer.enabled = false;
		DomTomPointer.enabled = false;
		KukurydzaObszar.enabled = false;
		TomObozPointer.enabled = false;
		DyniaObszar.enabled = false;
		WawozPointer.enabled = false; 
		StrzalkaIdzWawoz.enabled = false;
		DomOpuszczonyPointer.enabled = false;
		DomStevenPointer.enabled = false;
		ObszarStevenKlucz.enabled = false;
		StevenMiesoPointer.enabled = false;
		StevenGrzybPointer.enabled = false;
		StevenRoslinaPointer.enabled = false;
		StevenCzaszkaPointer.enabled = false;
		StevenSzopaPointer.enabled = false;
		StevenPotokPointer.enabled = false;
		DomNaukowcaPointer.enabled = false;
		ChatkaPointer.enabled = false;
		PotokDiablyPointer.enabled = false;
		KryjowkaDiablyObszar.enabled = false;

        SzafkaEdwardPointer.enabled = false;
        KoscSzopaPointer.enabled = false;
        KoscStajniaPointer.enabled = false;
        SzopaNarzedziaPointer.enabled = false;
        KluczWychodekPointer.enabled = false;
        SekretnyPokojPointer.enabled = false;

        if (Inventory.items.Count > 0) {
			Inventory.items.Clear();
		}

		InventoryItem1.sprite = null;
		InventoryItem1.color = Color.black;
		InventoryItem2.sprite = null;
		InventoryItem2.color = Color.black;
		InventoryItem3.sprite = null;
		InventoryItem3.color = Color.black;
		InventoryItem4.sprite = null;
		InventoryItem4.color = Color.black;
		InventoryItem5.sprite = null;
		InventoryItem5.color = Color.black;
		InventoryItem6.sprite = null;
		InventoryItem6.color = Color.black;
		InventoryItem7.sprite = null;
		InventoryItem7.color = Color.black;
		InventoryItem8.sprite = null;
		InventoryItem8.color = Color.black;
		InventoryItem9.sprite = null;
		InventoryItem9.color = Color.black;
		InventoryOpis.text = Inventory.defaultDescription;
        InventoryUsing.text = Inventory.defaultUsingItemText;

        Inventory.currentItemIcon.sprite = null;
        Inventory.currentItemIcon.color = Color.black;
        Inventory.currenntItemTitle.text = Inventory.currentItemText;

        if (Tasks.tasksList.Count > 0){
			Tasks.tasksList.Clear();
		}

		TasksZadanie1.text = "";
		TasksZadanie2.text = "";
		TasksZadanie3.text = "";
		TasksZadanie4.text = "";
		TasksZadanie5.text = "";

		// dodatkowe ustawienia

		CanvasPoczatekGry.enabled = true;
		Player.enabled = false;
		MapaGracza.enabled = false;
		Kuca.enabled = false;
		SwiatloLatarki.enabled = false;
		Kursor.enabled = false;
		DzwiekiPlayer.enabled = false;
        Kom.enabled = false;
        Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		ManagerGry.enabled = true;
        CanvasUI.enabled = false;

	}
	

	void Update () {

		if (Listener.enabled == true && Listener_ok == false) {
			ZrodloDzwBrama.PlayOneShot (DzwTelefonu);
			Listener_ok = true;
			PoczatekGry_ok = true;
		}

		if (ZrodloDzwBrama.isPlaying == false && PoczatekGry_ok == true && PoczatekGryWlacz_ok == false) {
			BohaterGlos.isGameBegin = true;
			PoczatekGryWlacz_ok = true;
		}

		if (ZrodloDzwBohater.time > 1.3f && Logo_ok == false) {
			Logo_ok = true;
			LogoAnimator.SetTrigger ("LogoPavrek");
		} 

		else if (ZrodloDzwBohater.time > 11f && Prezentuje_ok == false) {
			PrezentujeAnimator.SetTrigger ("Prezentuje");
			Prezentuje_ok = true;
		}  

		if (ZrodloDzwBohater.isPlaying == false && Prezentuje_ok == true && LastVisit_ok == false && ZrodloDzwBrama.isPlaying == false) {
			ZrodloDzwBrama.clip = DzwBramy;
			ZrodloDzwBrama.Play ();
		}

		if (ZrodloDzwBrama.time > 3.2f && LastVisit_ok == false) {
			LastVisitAnimator.SetTrigger ("LastVisit");
			LastVisit_ok = true;
		}

		if (ZrodloDzwBrama.isPlaying == false && LastVisit_ok == true && Koniec_ok == false) {
			ZrodloDzwBrama.clip = null;
			PrzejscieAnimator.SetTrigger ("Przejscie2");
			Player.enabled = true;
			MapaGracza.mapCamera.gameObject.SetActive (true);
			MapaGracza.enabled = true;
			Kuca.enabled = true;
			SwiatloLatarki.enabled = true;
			Kursor.enabled = true;
			DzwiekiPlayer.enabled = true;
            Kom.enabled = true;
            Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			Koniec_ok = true;
			Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z);
		}

		if (PrzejscieAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && PrzejscieAnimator.GetCurrentAnimatorStateInfo(0).IsName("UI_Przejscie2") && !PrzejscieAnimator.IsInTransition(0) && Canvas_ok == false) {
			CanvasPoczatekGry.enabled = false;
			MenuGlowne.isMenuNewGame = false;
			Canvas_ok = true;
			//Destroy (Player.GetComponent<PoczatekGry> ());
			MenuGlowne.beginGameScript.enabled = false;
            PrzejscieAnimator.SetTrigger("Przejscie1");
        }

	}
}
