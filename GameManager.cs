using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using TMPro;

public class GameManager : MonoBehaviour {

    public GameObject[] IkonyZadan;

    public InventoryUI inventoryUI;
	public Inventory Inventory;
	private Tasks Tasks;
	private Notes Notes;
	private Screamer Straszak;
	private SaveGame Saving;
	private TaskFactory ZadFabryka;
	private FactoryButton ZadPrzycisk;
	private TaskWheel ZadKolo;
	private TaskBones ZadKosci;
	private TaskBooks ZadKsiazki;
	private TaskTower ZadAmbona;
	public Jumpscare Jumpscare;
	private Flashlight Flashlight;
	private TaskWell ZadStudnia;
	private Music Music;
	private CharacterController CharakterKontroler;
	private Transform Player;
	private Notifications Kom;
	private Health ZdrowieGracza;
	private TaskMeat ZadMieso;
	private VoiceActing BohaterGlos;
	private Player Postac;
    public RandomJumpscare StraszakLosowy;
    private Halluns Halucynacje;
	private EndGame KoniecGry;
	public Color32 SwiatloKosci = new Color (255, 239, 204);
	private WlaczKsiazki KsiazkiWlacz;
	private Light SwiatloLatarki;
	private Transform KratyDynia;
    public AudioClip DzwRadio;
    public AudioClip DzwRadioChor;
    private Blur NotatkaEfekt;
    private Compass Compass;
    private DefaultObjectSettings LoadObjects;
    public StraszakScarecrow ScarecrowStraszak;

    public Transform MonsterLosowy;
    public Transform MonsterLosowy2;
    public Transform MonsterLosowy3;
    private Transform ObrazKapturek;

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

	public Transform KluczV1;
	public Transform Oliwa;
	public Transform KluczV2;
	public Transform KluczV3;
	public Transform KluczV4;
	public Transform Baterie;
	public Transform Kaseta1;
	public Transform Kosc1;
	public Transform Kosc2;
	public Transform Kosc3;
	public Transform Kosc4;
	public Transform Kosc5;
	public Transform KluczWneka;
	public Transform KluczKamping;
	public Transform KluczFabrykaBroken;
	public Transform BrakujaceKolo;
    public Transform KluczNaprawiony;
    public Transform Lom;
	public Transform KluczSalonPoludnie;
	public Transform Kombinerki;
	public Transform Siekiera;
	public Transform KluczSzafaKorytarz;
	public Transform KluczSzafkaSzopa;
	public Transform Kaseta2;
	public GameObject Dynia;
	public Transform KluczTomGora;
	public Transform KluczPokojTom;
	public Transform Kaseta3;
	public Transform Chip;
	public Transform KluczSzafaStaryDom;
	public Transform Kaseta4;
	public Transform KluczStevena;
	public Transform RoslinaLab;
	public Transform GrzybLab;
	public Transform CzaszkaLab;
	public Transform Mikstura;
	public Transform KluczPokojZachod;

	public Transform SecretItem1;
	public Transform SecretItem2;
	public Transform SecretItem3;
	public Transform SecretItem4;
	public Transform SecretItem5;
	public Transform SecretItem6;
	public Transform SecretItem7;
	public Transform SecretItem8;
	public Transform SecretItem9;
	public Transform SecretItem10;
	public Transform SecretItem11;
	public Transform SecretItem12;
	public Transform SecretItem13;
	public Transform SecretItem14;
	public Transform SecretItem15;
	public Transform SecretItem16;
	public Transform SecretItem17;
	public Transform SecretItem18;
	public Transform SecretItem19;
	public Transform SecretItem20;
	public Transform SecretItem21;
	public Transform SecretItem22;
	public Transform SecretItem23;
	public Transform SecretItem24;
	public Transform SecretItem25;
    public Transform SecretItem26;
    public Transform SecretItem27;
    public Transform SecretItem28;
    public Transform SecretItem29;
    public Transform SecretItem30;
    public Transform SecretItem31;
    public Transform SecretItem32;

    public Transform ZieloneZiolo1;
	public Transform ZieloneZiolo2;
	public Transform ZieloneZiolo3;
	public Transform ZieloneZiolo4;
	public Transform ZieloneZiolo5;
	public Transform ZieloneZiolo6;
	public Transform ZieloneZiolo7;
	public Transform ZieloneZiolo8;
	public Transform ZieloneZiolo9;
	public Transform ZieloneZiolo10;
	public Transform ZieloneZiolo11;
	public Transform ZieloneZiolo12;
	public Transform ZieloneZiolo13;
	public Transform ZieloneZiolo14;
	public Transform ZieloneZiolo15;
	public Transform ZieloneZiolo16;
	public Transform ZieloneZiolo17;
	public Transform ZieloneZiolo18;
	public Transform ZieloneZiolo19;
	public Transform ZieloneZiolo20;
	public Transform ZieloneZiolo21;
	public Transform ZieloneZiolo22;
    public Transform ZieloneZiolo23;
    public Transform ZieloneZiolo24;
    public Transform ZieloneZiolo25;
    public Transform ZieloneZiolo26;
    public Transform ZieloneZiolo27;
    public Transform ZieloneZiolo28;
    public Transform ZieloneZiolo29;
    public Transform ZieloneZiolo30;
    public Transform ZieloneZiolo31;
    public Transform ZieloneZiolo32;

    public Transform NiebieskieZiolo1;
	public Transform NiebieskieZiolo2;
	public Transform NiebieskieZiolo3;
	public Transform NiebieskieZiolo4;
	public Transform NiebieskieZiolo5;
	public Transform NiebieskieZiolo6;
	public Transform NiebieskieZiolo7;
	public Transform NiebieskieZiolo8;
	public Transform NiebieskieZiolo9;
	public Transform NiebieskieZiolo10;
	public Transform NiebieskieZiolo11;
	public Transform NiebieskieZiolo12;
	public Transform NiebieskieZiolo13;
	public Transform NiebieskieZiolo14;
	public Transform NiebieskieZiolo15;
	public Transform NiebieskieZiolo16;
	public Transform NiebieskieZiolo17;
	public Transform NiebieskieZiolo18;
	public Transform NiebieskieZiolo19;
	public Transform NiebieskieZiolo20;
	public Transform NiebieskieZiolo21;
	public Transform NiebieskieZiolo22;
    public Transform NiebieskieZiolo23;
    public Transform NiebieskieZiolo24;
    public Transform NiebieskieZiolo25;
    public Transform NiebieskieZiolo26;
    public Transform NiebieskieZiolo27;
    public Transform NiebieskieZiolo28;
    public Transform NiebieskieZiolo29;
    public Transform NiebieskieZiolo30;
    public Transform NiebieskieZiolo31;
    public Transform NiebieskieZiolo32;

    public Transform Fiolka1;
    public Transform Fiolka2;
    public Transform Fiolka3;
    public Transform Fiolka4;
    public Transform Fiolka5;
    public Transform Fiolka6;
    public Transform Fiolka7;
    public Transform Fiolka8;
    public Transform Fiolka9;
    public Transform Fiolka10;
    public Transform Fiolka11;
    public Transform Fiolka12;
    public Transform Fiolka13;
    public Transform Fiolka14;
    public Transform Fiolka15;
    public Transform Fiolka16;

    public Transform EliksirStamina1;
    public Transform EliksirStamina2;
    public Transform EliksirStamina3;
    public Transform EliksirStamina4;
    public Transform EliksirStamina5;

    public Transform EliksirZdrowie1;
    public Transform EliksirZdrowie2;
    public Transform EliksirZdrowie3;
    public Transform EliksirZdrowie4;
    public Transform EliksirZdrowie5;
    public Transform EliksirZdrowie6;

    public Transform MiesoDlaPotwora1;
    public Transform MiesoDlaPotwora2;
    public Transform MiesoDlaPotwora3;

    private Image Skill1Icon;
	private Image Skill2Icon;
	private Image Skill3Icon;
	private Image Skill4Icon;

	public Transform KoliderOgrod;
	public Transform KoliderKukurydza;
	public Transform KoliderStajnia;
	public Transform KoliderSzafkaKorytarz;
	public Transform KoliderPokojW;
	public Transform KoliderSzafkaKuchnia;
	public Transform KoliderDrzwiKamping;
	public Transform DeskiSzopa;
	public Transform KoliderDrzwiSzopaNarzedzia;
	public Transform KoliderDrzwiWneka;
	public Transform KoliderDrzwiSalonPoludnie;
	public Transform KoliderDrzwiFabrykaMetal;
	public Transform DrewnianeKolo;
	public Transform KoliderDrzwiFabrykaDrewno;
	public Transform KoliderSzafkaSzopa;
	public Transform KoliderDrzwiPokojTom;
	public Transform KoliderDrzwiTomGora;
	public Transform KoliderSzafaStaryDom;
	public Transform KoliderDrzwiSteven;
	public Transform KratySteven;
	public Transform KoliderDrzwiZachod;
	public Transform KoliderDrzwiPokojZachod;
    public GameObject KoliderOtworzDrzwi;

    // drzwi ktore moze zniszczyc potwor

    private GameObject DrzwiKuchnia;
    private GameObject DrzwiWujki;
    private GameObject DrzwiLazienka;
    private GameObject DrzwiToaleta;
    private GameObject DrzwiWneka;
    private GameObject DrzwiStajnia;
    private GameObject DrzwiDrewutnia;
    private GameObject DrzwiSzopa;
    private GameObject DrzwiKamping;
    private GameObject DrzwiKukurydza;
    private GameObject DrzwiOgrod;
    private GameObject DrzwiDom;

    private GameObject DrzwiGlowneGora;
    private GameObject DrzwiPokojP1;
    private GameObject DrzwiPokojP2;
    private GameObject DrzwiPokojL1;
    private GameObject DrzwiPokojL2;

    private GameObject DrzwiWejsciowe;
    private GameObject DrzwiGaraz;
    private GameObject DrzwiLazienkaZachod;
    private GameObject DrzwiKorytarz;
    private GameObject DrzwiPokojDol;
    private GameObject DrzwiTylne;


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

    public Transform Notatka1;
	public Transform Notatka2;
	public Transform Notatka3;
	public Transform Notatka4;
	public Transform Notatka5;
	public Transform Notatka6;
	public Transform Notatka7;
	public Transform Notatka8;
	public Transform Notatka9;
	public Transform Notatka10;
	public Transform Notatka11;
	public Transform Notatka12;
	public Transform Notatka13;
	public Transform Notatka14;
	public Transform Notatka15;
	public Transform Notatka16;
	public Transform Notatka17;
	public Transform Notatka18;
	public Transform Notatka19;
	public Transform Notatka20;
	public Transform Notatka21;
	public Transform Notatka22;
	public Transform Notatka23;
	public Transform Notatka24;
	public Transform Notatka25;
	public Transform Notatka26;
	public Transform Notatka27;
	public Transform Notatka28;
	public Transform Notatka29;
	public Transform Notatka30;
	public Transform Notatka31;
	public Transform Notatka32;
	public Transform Notatka33;
	public Transform Notatka34;
	public Transform Notatka35;
	public Transform Notatka36;
	public Transform Notatka37;
	public Transform Notatka38;
	public Transform Notatka39;
	public Transform Notatka40;
	public Transform Notatka41;
	public Transform Notatka42;
	public Transform Notatka43;
	public Transform Notatka44;
	public Transform Notatka45;
	public Transform Notatka46;
	public Transform Notatka47;
	public Transform Notatka48;
	public Transform Notatka49;
	public Transform Notatka50;
	public Transform Notatka51;
	public Transform Notatka52;
	public Transform Notatka53;
	public Transform Notatka54;

	public Transform NotatkaLisy;
	public Transform ZdjecieDrewno;
	public Transform ZdjecieZeno;
	public Transform NotatkaZakupy;
	public Transform NotatkaCytat1;
	public Transform RysunekKukurydza;
	public Transform NotatkaPotokLewy;
	public Transform NotatkaGrzyby;
	public Transform ZdjeciePotok3;
	public Transform ZdjeciePotok2;
	public Transform ZdjeciePotok1;
	public Transform RysunekSimon;
	public Transform NotatkaRap;
	public Transform ZdjecieAmbona;
	public Transform ZdjecieStudnia;
	public Transform NotatkaCytat2;
	public Transform ZdjeciePomnik;
	public Transform NotatkaWynalazki;
	public Transform ZdjecieWarsztat;
	public Transform NotatkaCiemny;
	public Transform NotatkaZwierzeta;
	public Transform NotatkaNoc;
	public Transform ZdjecieSzafa;
	public Transform ZdjecieSzopa;
	public Transform ZdjecieOboz;
	public Transform NotatkaMary;
	public Transform RysunekCorki;
	public Transform NotatkaDyplom;
	public Transform RysunekTom;
	public Transform NotatkaCytat3;
	public Transform RysunekPotwor;
	public Transform NotatkaSzepty;
	public Transform NotatkaCytat4;
	public Transform RysunekRosliny;
	public Transform NotatkaPole;
	public Transform NotatkaArena;
	public Transform NotatkaCytat5;
	public Transform ZdjeciePotok4;
	public Transform NotatkaKosmici;
	public Transform NotatkaCytat6;
	public Transform NotatkaDemona;

    // kolekcja

    public Transform Odznaka1;
    public Transform Odznaka2;
    public Transform Odznaka3;
    public Transform Odznaka4;
    public Transform Odznaka5;
    public Transform Odznaka6;
    public Transform Odznaka7;
    public Transform Odznaka8;
    public Transform Odznaka9;
    public Transform Odznaka10;
    public Transform Odznaka11;
    public Transform Odznaka12;

    public Transform Foto1;
    public Transform Foto2;
    public Transform Foto3;
    public Transform Foto4;
    public Transform Foto5;
    public Transform Foto6;
    public Transform Foto7;
    public Transform Foto8;
    public Transform Foto9;
    public Transform Foto10;
    public Transform Foto11;
    public Transform Foto12;

    public Transform Wskazowka1;
    public Transform Wskazowka2;
    public Transform Wskazowka3;
    public Transform Wskazowka4;
    public Transform Wskazowka5;
    public Transform Wskazowka6;
    public Transform Wskazowka7;
    public Transform Wskazowka8;
    public Transform Wskazowka9;
    public Transform Wskazowka10;
    public Transform Wskazowka11;
    public Transform Wskazowka12;

    // straszak

    public Transform SwiatloMalaSzopa;
	public Transform Swiatlo2;
    public Transform Trup;

    // zadanie kosci

    public Transform KoscZad1;
	public Transform KoscZad2;
	public Transform KoscZad3;
	public Transform KoscZad4;
	public Transform KoscZad5;
	private Transform KratyKosci;

	// zadanie studnia

	public Transform Kamien1;
	public Transform Kamien2;
	public Transform Kamien3;
	public Transform Kamien4;
	public Transform Kamien5;

	// zadanie fabryka

	public Transform BramaFabryka;
	private Light SwiatloEnergii;

	// kolidery drzwi

	public Transform KoliderDomAlice;
	public Transform KoliderDomTom;
	public Transform KoliderTomKsiazki;
	public Transform KoliderTomSala;
	public Transform KoliderOpuszczonyDom;
	public Transform KoliderDomStevena;
	public Transform KoliderDomPaul;
	public Transform KoliderPaulTyl;
	public Transform KoliderChatka;

	// zakonczenie gry

	public Transform MonsterStatic1;
	public Transform MonsterStatic2;
	public Transform MonsterGlowny;

	// ikony przedmiotow

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

	// teksty zadan

	private TextMeshProUGUI TasksZadanie1;
	private TextMeshProUGUI TasksZadanie2;
	private TextMeshProUGUI TasksZadanie3;
	private TextMeshProUGUI TasksZadanie4;
	private TextMeshProUGUI TasksZadanie5;

    // kolekcje shaderow

	public ShaderVariantCollection ShaderScenaGlowna;
	public ShaderVariantCollection ShaderScenaGlowna2;
	public ShaderVariantCollection ShaderScenaGlowna3;
    public ShaderVariantCollection ShaderScenaGlowna4;
    public ShaderVariantCollection ShaderScenaGlowna5;

    // triggery do wskazowek

    private GameObject KomunikatZapis;
    private GameObject KomunikatItems;
    // private GameObject KomunikatPodnoszenie;

    // triggery do jumpscarow

    private GameObject DomAliceTerenNonStraszak;
    private GameObject DomTomTerenNonStraszak;
    private GameObject DomOpuszczonyTerenNonStraszak;
    private GameObject DomStevenTerenNonStraszak;
    private GameObject DomPaulTerenNonStraszak;
    private GameObject ChatkaPaulTerenNonStraszak;
    private GameObject StevenMiesoTerenNonStraszak;
    private GameObject Wilk1_trigger;
    private GameObject Wilk2_trigger;
    private GameObject Wilk3_trigger;
    private GameObject Pajak5_trigger;

    // pozostale triggery np glosy bohatera

    private GameObject GlosStudnia_trigger;
    private GameObject GlosIdzWawoz_trigger;

    // canvasy marysia haluny

    private Canvas ObrazMarysia1;
    private Canvas ObrazMarysia2;
    private Canvas ObrazMarysia3;
    private Canvas ObrazMarysia4;
    private Canvas ObrazMarysia5;

    // drzwi wymagajace klucza

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
    private Door DrzwiZachodPokojS;
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

    // audio listener

    public AudioListener PlayerListener;

    // cansvas czarne okno siekiera

    private Canvas CanvasCzynnoscSiekiera;

    // Animator i postac yound dead warsztat

    public Transform YoundDead;
    private Animator AnimatorYoungDead;

    // Animator drzewo fall i kurz z drzewa

    private Animator AnimatorDrzewoFall;
    public GameObject KurzDrzewoFall;

    // drut kukurydza

    public GameObject DrutKukurydza;

    void OnEnable () {

		Debug.Log(ShaderScenaGlowna.variantCount);
		Debug.Log(ShaderScenaGlowna2.variantCount);

		ShaderScenaGlowna.WarmUp ();
		ShaderScenaGlowna2.WarmUp ();
		ShaderScenaGlowna3.WarmUp ();
        ShaderScenaGlowna4.WarmUp();
        ShaderScenaGlowna5.WarmUp();

        // znajdywanie i zerowanie ikon zadan w canvas kompasie

        IkonyZadan = GameObject.FindGameObjectsWithTag("IkonaZadania");

        foreach(GameObject Ikona in IkonyZadan)
        {
            Destroy(Ikona);
        }

        KsiazkiWlacz = GameObject.Find ("Biblioteka_Ksiazki_W").GetComponent<WlaczKsiazki> ();
		KsiazkiWlacz.enabled = true;

		Inventory = GameObject.Find ("Player").GetComponent<Inventory> ();
		Tasks = GameObject.Find ("Player").GetComponent<Tasks> ();
		Notes = GameObject.Find ("Player").GetComponent<Notes> ();
		Saving = GameObject.Find ("Player").GetComponent<SaveGame> ();
		Straszak = GameObject.Find ("Player").GetComponent<Screamer> ();
		ZadFabryka = GameObject.Find ("DzwigniaZad").GetComponent<TaskFactory> ();
		ZadPrzycisk = GameObject.Find ("PrzyciskZad").GetComponent<FactoryButton> ();
		ZadKolo = GameObject.Find ("BrakujaceDrewnianeKolo").GetComponent<TaskWheel> ();
		ZadKosci = GameObject.Find ("KoliderKosci").GetComponent<TaskBones> ();
		ZadKsiazki = GameObject.Find ("Player").GetComponent<TaskBooks> ();
		ZadAmbona = GameObject.Find ("PalAmbona").GetComponent<TaskTower> ();
		Jumpscare = GameObject.Find ("Player").GetComponent<Jumpscare> (); 
		Flashlight = GameObject.Find ("Latarka").GetComponent<Flashlight> ();
		ZadStudnia = GameObject.Find ("StudniaTrigger").GetComponent<TaskWell> ();
		Music = GameObject.Find ("Player").GetComponent<Music> ();
		CharakterKontroler = GameObject.Find ("Player").GetComponent<CharacterController> ();
		Kom = GameObject.Find ("Player").GetComponent<Notifications> ();
		ZdrowieGracza = GameObject.Find ("Player").GetComponent<Health> ();
		ZadMieso = GameObject.Find ("Player").GetComponent<TaskMeat> ();
		BohaterGlos = GameObject.Find ("Player").GetComponent<VoiceActing> ();
		Postac =  GameObject.Find ("Player").GetComponent<Player> ();
		KoniecGry = GameObject.Find ("Player").GetComponent<EndGame> ();
		Player = GameObject.Find ("Player").transform;
        StraszakLosowy = GameObject.Find("Player").GetComponent<RandomJumpscare>();
        Halucynacje = GameObject.Find("Player").GetComponent<Halluns>();
        NotatkaEfekt = GameObject.Find("Kamera").GetComponent<Blur>();
        Compass = GameObject.Find("Player").GetComponent<Compass>();
        LoadObjects = GameObject.Find("WczytajObiekty").GetComponent<DefaultObjectSettings>();
        ScarecrowStraszak = GameObject.Find("Player").GetComponent<StraszakScarecrow>();

        SwiatloLatarki = GameObject.Find ("Latarka").GetComponent<Light> ();

        MonsterLosowy = GameObject.Find("Monster1_Losowy").transform;
        MonsterLosowy2 = GameObject.Find("Monster1_Losowy2").transform;
        MonsterLosowy3 = GameObject.Find("Monster1_Losowy3").transform;
        ObrazKapturek = GameObject.Find("ObrazKapturek").transform;

		KratyDynia = GameObject.Find ("KratyDynia").transform;

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

		KluczV1 = GameObject.Find("KluczPokojWO").transform;
		Oliwa = GameObject.Find("OliwaItem").transform;
		KluczV2 = GameObject.Find("KluczSzafkaKuchniaO").transform;
		KluczV3 = GameObject.Find("KluczStajnia").transform;
		KluczV4 = GameObject.Find("KluczSzopa").transform;
		Baterie = GameObject.Find("BaterieO").transform;
		Kaseta1 = GameObject.Find("KasetaVideo1").transform;
		Kosc1 = GameObject.Find("KoscZad1").transform;
		Kosc2 = GameObject.Find("KoscZad2").transform;
		Kosc3 = GameObject.Find("KoscZad3").transform;
		Kosc4 = GameObject.Find("KoscZad4").transform;
		Kosc5 = GameObject.Find("KoscZad5").transform;
		KluczWneka = GameObject.Find("KluczWneka").transform;
		KluczKamping = GameObject.Find("KluczKamping").transform;
		KluczFabrykaBroken = GameObject.Find("KluczFabrykaBroken").transform;
		BrakujaceKolo = GameObject.Find("BrakujaceDrewnianeKoloItem").transform;
        KluczNaprawiony = GameObject.Find("KluczNaprawiony").transform;
        KluczSalonPoludnie = GameObject.Find("KluczSalonPoludnie").transform;
		Lom = GameObject.Find("Lom").transform;
		Kombinerki = GameObject.Find("KombinerkiO").transform;
		Siekiera = GameObject.Find("SiekieraZadanieO").transform;
		KluczSzafaKorytarz = GameObject.Find("KluczSzafaKorytarz").transform;
		KluczSzafkaSzopa = GameObject.Find("KluczSzafkaSzopa").transform;
		Kaseta2 = GameObject.Find("KasetaVideo2").transform;
		KluczPokojTom = GameObject.Find("KluczPokojTomO").transform;
		Kaseta3 = GameObject.Find("KasetaVideo3").transform;
		KluczSzafaStaryDom = GameObject.Find("KluczSzafaStaryDom").transform;
		Kaseta4 = GameObject.Find("KasetaVideo4").transform;
		KluczStevena = GameObject.Find("KluczStevena").transform;
		RoslinaLab = GameObject.Find("RoslinaLab").transform;
		GrzybLab = GameObject.Find("GrzybLab").transform;
		CzaszkaLab = GameObject.Find("CzaszkaLab").transform;
		KluczPokojZachod = GameObject.Find("KluczPokojZachod").transform;
		Dynia = GameObject.Find ("DyniaMisja").gameObject;
		KluczTomGora = GameObject.Find ("KluczTomGora").transform;
		Chip = GameObject.Find ("ChipO").transform;
		Mikstura = GameObject.Find ("Mikstura").transform;

		SecretItem1 = GameObject.Find("SecretItem1_1").transform;
		SecretItem2 = GameObject.Find("SecretItem2_1").transform;
		SecretItem3 = GameObject.Find("SecretItem1_2").transform;
		SecretItem4 = GameObject.Find("SecretItem1_3").transform;
		SecretItem5 = GameObject.Find("SecretItem2_2").transform;
		SecretItem6 = GameObject.Find("SecretItem1_4").transform;
		SecretItem7 = GameObject.Find("SecretItem2_3").transform;
		SecretItem8 = GameObject.Find("SecretItem2_4").transform;
		SecretItem9 = GameObject.Find("SecretItem1_5").transform;
		SecretItem10 = GameObject.Find("SecretItem1_6").transform;
		SecretItem11 = GameObject.Find("SecretItem2_5").transform;
		SecretItem12 = GameObject.Find("SecretItem2_6").transform;
		SecretItem13 = GameObject.Find("SecretItem1_7").transform;
		SecretItem14 = GameObject.Find("SecretItem2_7").transform;
		SecretItem15 = GameObject.Find("SecretItem1_8").transform;
		SecretItem16 = GameObject.Find("SecretItem1_9").transform;
		SecretItem17 = GameObject.Find("SecretItem2_8").transform;
		SecretItem18 = GameObject.Find("SecretItem1_10").transform;
		SecretItem19 = GameObject.Find("SecretItem1_11").transform;
		SecretItem20 = GameObject.Find("SecretItem1_12").transform;
		SecretItem21 = GameObject.Find("SecretItem2_9").transform;
		SecretItem22 = GameObject.Find("SecretItem1_13").transform;
		SecretItem23 = GameObject.Find("SecretItem2_10").transform;
		SecretItem24 = GameObject.Find("SecretItem1_14").transform;
		SecretItem25 = GameObject.Find("SecretItem1_15").transform;
        SecretItem26 = GameObject.Find("SecretItem1_16").transform;
        SecretItem27 = GameObject.Find("SecretItem1_17").transform;
        SecretItem28 = GameObject.Find("SecretItem2_11").transform;
        SecretItem29 = GameObject.Find("SecretItem2_12").transform;
        SecretItem30 = GameObject.Find("SecretItem2_13").transform;
        SecretItem31 = GameObject.Find("SecretItem2_14").transform;
        SecretItem32 = GameObject.Find("SecretItem2_15").transform;

        ZieloneZiolo1 = GameObject.Find("ZieloneZiolo1").transform;
		ZieloneZiolo2 = GameObject.Find("ZieloneZiolo2").transform;
		ZieloneZiolo3 = GameObject.Find("ZieloneZiolo3").transform;
		ZieloneZiolo4 = GameObject.Find("ZieloneZiolo4").transform;
		ZieloneZiolo5 = GameObject.Find("ZieloneZiolo5").transform;
		ZieloneZiolo6 = GameObject.Find("ZieloneZiolo6").transform;
		ZieloneZiolo7 = GameObject.Find("ZieloneZiolo7").transform;
		ZieloneZiolo8 = GameObject.Find("ZieloneZiolo8").transform;
		ZieloneZiolo9 = GameObject.Find("ZieloneZiolo9").transform;
		ZieloneZiolo10 = GameObject.Find("ZieloneZiolo10").transform;
		ZieloneZiolo11 = GameObject.Find("ZieloneZiolo11").transform;
		ZieloneZiolo12 = GameObject.Find("ZieloneZiolo12").transform;
		ZieloneZiolo13 = GameObject.Find("ZieloneZiolo13").transform;
		ZieloneZiolo14 = GameObject.Find("ZieloneZiolo14").transform;
		ZieloneZiolo15 = GameObject.Find("ZieloneZiolo15").transform;
		ZieloneZiolo16 = GameObject.Find("ZieloneZiolo16").transform;
		ZieloneZiolo17 = GameObject.Find("ZieloneZiolo17").transform;
		ZieloneZiolo18 = GameObject.Find("ZieloneZiolo18").transform;
		ZieloneZiolo19 = GameObject.Find("ZieloneZiolo19").transform;
		ZieloneZiolo20 = GameObject.Find("ZieloneZiolo20").transform;
		ZieloneZiolo21 = GameObject.Find("ZieloneZiolo21").transform;
		ZieloneZiolo22 = GameObject.Find("ZieloneZiolo22").transform;
        ZieloneZiolo23 = GameObject.Find("ZieloneZiolo23").transform;
        ZieloneZiolo24 = GameObject.Find("ZieloneZiolo24").transform;
        ZieloneZiolo25 = GameObject.Find("ZieloneZiolo25").transform;
        ZieloneZiolo26 = GameObject.Find("ZieloneZiolo26").transform;
        ZieloneZiolo27 = GameObject.Find("ZieloneZiolo27").transform;
        ZieloneZiolo28 = GameObject.Find("ZieloneZiolo28").transform;
        ZieloneZiolo29 = GameObject.Find("ZieloneZiolo29").transform;
        ZieloneZiolo30 = GameObject.Find("ZieloneZiolo30").transform;
        ZieloneZiolo31 = GameObject.Find("ZieloneZiolo31").transform;
        ZieloneZiolo32 = GameObject.Find("ZieloneZiolo32").transform;

        NiebieskieZiolo1 = GameObject.Find("NiebieskieZiolo1").transform;
		NiebieskieZiolo2 = GameObject.Find("NiebieskieZiolo2").transform;
		NiebieskieZiolo3 = GameObject.Find("NiebieskieZiolo3").transform;
		NiebieskieZiolo4 = GameObject.Find("NiebieskieZiolo4").transform;
		NiebieskieZiolo5 = GameObject.Find("NiebieskieZiolo5").transform;
		NiebieskieZiolo6 = GameObject.Find("NiebieskieZiolo6").transform;
		NiebieskieZiolo7 = GameObject.Find("NiebieskieZiolo7").transform;
		NiebieskieZiolo8 = GameObject.Find("NiebieskieZiolo8").transform;
		NiebieskieZiolo9 = GameObject.Find("NiebieskieZiolo9").transform;
		NiebieskieZiolo10 = GameObject.Find("NiebieskieZiolo10").transform;
		NiebieskieZiolo11 = GameObject.Find("NiebieskieZiolo11").transform;
		NiebieskieZiolo12 = GameObject.Find("NiebieskieZiolo12").transform;
		NiebieskieZiolo13 = GameObject.Find("NiebieskieZiolo13").transform;
		NiebieskieZiolo14 = GameObject.Find("NiebieskieZiolo14").transform;
		NiebieskieZiolo15 = GameObject.Find("NiebieskieZiolo15").transform;
		NiebieskieZiolo16 = GameObject.Find("NiebieskieZiolo16").transform;
		NiebieskieZiolo17 = GameObject.Find("NiebieskieZiolo17").transform;
		NiebieskieZiolo18 = GameObject.Find("NiebieskieZiolo18").transform;
		NiebieskieZiolo19 = GameObject.Find("NiebieskieZiolo19").transform;
		NiebieskieZiolo20 = GameObject.Find("NiebieskieZiolo20").transform;
		NiebieskieZiolo21 = GameObject.Find("NiebieskieZiolo21").transform;
		NiebieskieZiolo22 = GameObject.Find("NiebieskieZiolo22").transform;
        NiebieskieZiolo23 = GameObject.Find("NiebieskieZiolo23").transform;
        NiebieskieZiolo24 = GameObject.Find("NiebieskieZiolo24").transform;
        NiebieskieZiolo25 = GameObject.Find("NiebieskieZiolo25").transform;
        NiebieskieZiolo26 = GameObject.Find("NiebieskieZiolo26").transform;
        NiebieskieZiolo27 = GameObject.Find("NiebieskieZiolo27").transform;
        NiebieskieZiolo28 = GameObject.Find("NiebieskieZiolo28").transform;
        NiebieskieZiolo29 = GameObject.Find("NiebieskieZiolo29").transform;
        NiebieskieZiolo30 = GameObject.Find("NiebieskieZiolo30").transform;
        NiebieskieZiolo31 = GameObject.Find("NiebieskieZiolo31").transform;
        NiebieskieZiolo32 = GameObject.Find("NiebieskieZiolo32").transform;

        Fiolka1 = GameObject.Find("Fiolka1").transform;
        Fiolka2 = GameObject.Find("Fiolka2").transform;
        Fiolka3 = GameObject.Find("Fiolka3").transform;
        Fiolka4 = GameObject.Find("Fiolka4").transform;
        Fiolka5 = GameObject.Find("Fiolka5").transform;
        Fiolka6 = GameObject.Find("Fiolka6").transform;
        Fiolka7 = GameObject.Find("Fiolka7").transform;
        Fiolka8 = GameObject.Find("Fiolka8").transform;
        Fiolka9 = GameObject.Find("Fiolka9").transform;
        Fiolka10 = GameObject.Find("Fiolka10").transform;
        Fiolka11 = GameObject.Find("Fiolka11").transform;
        Fiolka12 = GameObject.Find("Fiolka12").transform;
        Fiolka13 = GameObject.Find("Fiolka13").transform;
        Fiolka14 = GameObject.Find("Fiolka14").transform;
        Fiolka15 = GameObject.Find("Fiolka15").transform;
        Fiolka16 = GameObject.Find("Fiolka16").transform;

        EliksirStamina1 = GameObject.Find("EliksirStamina1").transform;
        EliksirStamina2 = GameObject.Find("EliksirStamina2").transform;
        EliksirStamina3 = GameObject.Find("EliksirStamina3").transform;
        EliksirStamina4 = GameObject.Find("EliksirStamina4").transform;
        EliksirStamina5 = GameObject.Find("EliksirStamina5").transform;

        EliksirZdrowie1 = GameObject.Find("EliksirZdrowie1").transform;
        EliksirZdrowie2 = GameObject.Find("EliksirZdrowie2").transform;
        EliksirZdrowie3 = GameObject.Find("EliksirZdrowie3").transform;
        EliksirZdrowie4 = GameObject.Find("EliksirZdrowie4").transform;
        EliksirZdrowie5 = GameObject.Find("EliksirZdrowie5").transform;
        EliksirZdrowie6 = GameObject.Find("EliksirZdrowie6").transform;

        Skill1Icon = GameObject.Find("InventorySkill1").GetComponent<Image>();
		Skill2Icon = GameObject.Find("InventorySkill2").GetComponent<Image>();
		Skill3Icon = GameObject.Find("InventorySkill3").GetComponent<Image>();
		Skill4Icon = GameObject.Find("InventorySkill4").GetComponent<Image>();

		KoliderOgrod = GameObject.Find("KoliderDrzwiOgrod").transform;
		KoliderKukurydza = GameObject.Find("KoliderDrzwiKukurydza").transform;
		KoliderStajnia = GameObject.Find("KoliderDrzwiStajnia").transform;
		KoliderSzafkaKorytarz = GameObject.Find("KoliderSzafkaKorytarz").transform;
		KoliderPokojW = GameObject.Find("KoliderDrzwiPokojW").transform;
		KoliderSzafkaKuchnia = GameObject.Find("KoliderSzafkaKuchnia").transform;
		KoliderDrzwiKamping = GameObject.Find("KoliderDrzwiKamping").transform;
		DeskiSzopa = GameObject.Find("DeskiSzopa").transform;
		KoliderDrzwiSzopaNarzedzia = GameObject.Find("KoliderDrzwiSzopaNarzedzia").transform;
		KoliderDrzwiWneka = GameObject.Find("KoliderDrzwiWneka").transform;
		KoliderDrzwiSalonPoludnie = GameObject.Find("KoliderDrzwiSalonPoludnie").transform;
		KoliderDrzwiFabrykaMetal = GameObject.Find("KoliderDrzwiFabrykaMetal").transform;
		DrewnianeKolo = GameObject.Find("BrakujaceDrewnianeKolo").transform;
		DrewnianeKolo.gameObject.SetActive(false);
		KoliderDrzwiFabrykaDrewno = GameObject.Find("KoliderDrzwiFabrykaDrewno").transform;
		KoliderSzafkaSzopa = GameObject.Find("KoliderSzafkaSzopa").transform;
		KoliderDrzwiPokojTom = GameObject.Find("KoliderDrzwiPokojTom").transform;
		KoliderDrzwiTomGora = GameObject.Find("KoliderDrzwiTomGora").transform;
		KoliderSzafaStaryDom = GameObject.Find("KoliderSzafaStaryDom").transform;
		KoliderDrzwiSteven = GameObject.Find("KoliderDrzwiSteven").transform;
		KratySteven = GameObject.Find("KratySteven").transform;
		KoliderDrzwiZachod = GameObject.Find("KoliderDrzwiZachod").transform;
		KoliderDrzwiPokojZachod = GameObject.Find("KoliderDrzwiPokojZachod").transform;
        KoliderOtworzDrzwi = GameObject.Find("KoliderOtworzDrzwi").gameObject;

        DrzwiKuchnia = GameObject.Find("DrzwiKuchnia").gameObject;
        DrzwiWujki = GameObject.Find("DrzwiPokojW").gameObject;
        DrzwiLazienka = GameObject.Find("DrzwiLazienka").gameObject;
        DrzwiToaleta = GameObject.Find("DrzwiToaleta").gameObject;
        DrzwiWneka = GameObject.Find("DrzwiWneka").gameObject;
        DrzwiStajnia = GameObject.Find("DrzwiStajnia").gameObject;
        DrzwiDrewutnia = GameObject.Find("DrzwiDrewutnia").gameObject;
        DrzwiSzopa = GameObject.Find("DrzwiSzopaNarzedzia").gameObject;
        DrzwiKamping = GameObject.Find("DrzwiKamping").gameObject;
        DrzwiKukurydza = GameObject.Find("DrzwiKukurydza").gameObject;
        DrzwiOgrod = GameObject.Find("DrzwiOgrod").gameObject;
        DrzwiDom = GameObject.Find("DrzwiDom").gameObject;

        DrzwiGlowneGora = GameObject.Find("DrzwiOtworzJmp").gameObject;
        DrzwiPokojP1 = GameObject.Find("DrzwiPokojP1").gameObject;
        DrzwiPokojP2 = GameObject.Find("DrzwiZamknijJmp").gameObject;
        DrzwiPokojL1 = GameObject.Find("DrzwiPokojL1").gameObject;
        DrzwiPokojL2 = GameObject.Find("DrzwiZachod").gameObject;

        DrzwiWejsciowe = GameObject.Find("DrzwiDomPaul").gameObject;
        DrzwiGaraz = GameObject.Find("DrzwiZachodGaraz").gameObject;
        DrzwiLazienkaZachod = GameObject.Find("DrzwiZachodLazienka").gameObject;
        DrzwiKorytarz = GameObject.Find("DrzwiZachodKorytarz").gameObject;
        DrzwiPokojDol = GameObject.Find("DrzwiZachodPokojDol").gameObject;
        DrzwiTylne = GameObject.Find("DrzwiMonster").gameObject;

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

        Notatka1 = GameObject.Find ("Notatka_v1_1").transform;
		Notatka2 = GameObject.Find ("Notatka_v1_2").transform;
		Notatka3 = GameObject.Find ("Notatka_v1_3").transform;
		Notatka4 = GameObject.Find ("Notatka_v1_4").transform;
		Notatka5 = GameObject.Find ("Notatka_v1_5").transform;
		Notatka6 = GameObject.Find ("Notatka_v1_6").transform;
		Notatka7 = GameObject.Find ("Notatka_v1_7").transform;
		Notatka8 = GameObject.Find ("Notatka_v1_8").transform;
		Notatka9 = GameObject.Find ("Notatka_v1_9").transform;
		Notatka10 = GameObject.Find ("Notatka_v1_10").transform;
		Notatka11 = GameObject.Find ("Notatka_v1_11").transform;
		Notatka12 = GameObject.Find ("Notatka_v1_12").transform;
		Notatka13 = GameObject.Find ("Notatka_v1_13").transform;
		Notatka14 = GameObject.Find ("Notatka_v1_14").transform;
		Notatka15 = GameObject.Find ("Notatka_v1_15").transform;
		Notatka16 = GameObject.Find ("Notatka_v1_16").transform;
		Notatka17 = GameObject.Find ("Notatka_v1_17").transform;
		Notatka18 = GameObject.Find ("Notatka_v1_18").transform;
		Notatka19 = GameObject.Find ("Notatka_v1_19").transform;
		Notatka20 = GameObject.Find ("Notatka_v1_20").transform;
		Notatka21 = GameObject.Find ("Notatka_v1_21").transform;
		Notatka22 = GameObject.Find ("Notatka_v1_22").transform;
		Notatka23 = GameObject.Find ("Notatka_v1_23").transform;
		Notatka24 = GameObject.Find ("Notatka_v1_24").transform;
		Notatka25 = GameObject.Find ("Notatka_v1_25").transform;
		Notatka26 = GameObject.Find ("Notatka_v1_26").transform;
		Notatka27 = GameObject.Find ("Notatka_v1_27").transform;
		Notatka28 = GameObject.Find ("Notatka_v1_28").transform;
		Notatka29 = GameObject.Find ("Notatka_v1_29").transform;
		Notatka30 = GameObject.Find ("Notatka_v1_30").transform;
		Notatka31 = GameObject.Find ("Notatka_v1_31").transform;
		Notatka32 = GameObject.Find ("Notatka_v1_32").transform;
		Notatka33 = GameObject.Find ("Notatka_v1_33").transform;
		Notatka34 = GameObject.Find ("Notatka_v1_34").transform;
		Notatka35 = GameObject.Find ("Notatka_v1_35").transform;
		Notatka36 = GameObject.Find ("Notatka_v1_36").transform;
		Notatka37 = GameObject.Find ("Notatka_v1_37").transform;
		Notatka38 = GameObject.Find ("Notatka_v1_38").transform;
		Notatka39 = GameObject.Find ("Notatka_v1_39").transform;
		Notatka40 = GameObject.Find ("Notatka_v1_40").transform;
		Notatka41 = GameObject.Find ("Notatka_v1_41").transform;
		Notatka42 = GameObject.Find ("Notatka_v1_42").transform;
		Notatka43 = GameObject.Find ("Notatka_v1_43").transform;
		Notatka44 = GameObject.Find ("Notatka_v1_44").transform;
		Notatka45 = GameObject.Find ("Notatka_v1_45").transform;
		Notatka46 = GameObject.Find ("Notatka_v1_46").transform;
		Notatka47 = GameObject.Find ("Notatka_v1_47").transform;
		Notatka48 = GameObject.Find ("Notatka_v1_48").transform;
		Notatka49 = GameObject.Find ("Notatka_v1_49").transform;
		Notatka50 = GameObject.Find ("Notatka_v1_50").transform;
		Notatka51 = GameObject.Find ("Notatka_v1_51").transform;
		Notatka52 = GameObject.Find ("Notatka_v1_52").transform;
		Notatka53 = GameObject.Find ("Notatka_v1_53").transform;
		Notatka54 = GameObject.Find ("Notatka_v1_54").transform;
		NotatkaLisy = GameObject.Find ("Notatka_v2Lisy").transform;
		ZdjecieDrewno = GameObject.Find ("ZdjecieDrewno").transform;
		ZdjecieZeno = GameObject.Find ("ZdjecieZeno").transform;
		NotatkaZakupy = GameObject.Find ("NotatkaZakupy").transform;
		NotatkaCytat1 = GameObject.Find ("NotatkaCytat1").transform;
		RysunekKukurydza = GameObject.Find ("RysunekKukurydza").transform;
		NotatkaPotokLewy = GameObject.Find ("NotatkaPotokLewy").transform;
		NotatkaGrzyby = GameObject.Find ("NotatkaGrzyby").transform;
		ZdjeciePotok3 = GameObject.Find ("ZdjeciePotok3").transform;
		ZdjeciePotok2 = GameObject.Find ("ZdjeciePotok2").transform;
		ZdjeciePotok1 = GameObject.Find ("ZdjeciePotok1").transform;
		RysunekSimon = GameObject.Find ("RysunekSimon").transform;
		NotatkaRap = GameObject.Find ("NotatkaRap").transform;
		ZdjecieAmbona = GameObject.Find ("ZdjecieAmbona").transform;
		ZdjecieStudnia = GameObject.Find ("ZdjecieStudnia").transform;
		NotatkaCytat2 = GameObject.Find ("NotatkaCytat2").transform;
		ZdjeciePomnik = GameObject.Find ("ZdjeciePomnik").transform;
		NotatkaWynalazki = GameObject.Find ("NotatkaWynalazki").transform;
		ZdjecieWarsztat = GameObject.Find ("ZdjecieWarsztat").transform;
		NotatkaCiemny = GameObject.Find ("NotatkaCiemny").transform;
		NotatkaZwierzeta = GameObject.Find ("NotatkaZwierzeta").transform;
		NotatkaNoc = GameObject.Find ("NotatkaNoc").transform;
		ZdjecieSzafa = GameObject.Find ("ZdjecieSzafa").transform;
		ZdjecieSzopa = GameObject.Find ("ZdjecieSzopa").transform;
		ZdjecieOboz = GameObject.Find ("ZdjecieOboz").transform;
		NotatkaMary = GameObject.Find ("NotatkaMary").transform;
		RysunekCorki = GameObject.Find ("RysunekCorki").transform;
		NotatkaDyplom = GameObject.Find ("NotatkaDyplom").transform;
		RysunekTom = GameObject.Find ("RysunekTom").transform;
		NotatkaCytat3 = GameObject.Find ("NotatkaCytat3").transform;
		RysunekPotwor = GameObject.Find ("RysunekPotwor").transform;
		NotatkaSzepty = GameObject.Find ("NotatkaSzepty").transform;
		NotatkaCytat4 = GameObject.Find ("NotatkaCytat4").transform;
		RysunekRosliny = GameObject.Find ("RysunekRosliny").transform;
		NotatkaPole = GameObject.Find ("NotatkaPole").transform;
		NotatkaArena = GameObject.Find ("NotatkaArena").transform;
		NotatkaCytat5 = GameObject.Find ("NotatkaCytat5").transform;
		ZdjeciePotok4 = GameObject.Find ("ZdjeciePotok4").transform;
		NotatkaKosmici = GameObject.Find ("NotatkaKosmici").transform;
		NotatkaCytat6 = GameObject.Find ("NotatkaCytat6").transform;
		NotatkaDemona = GameObject.Find ("NotatkaDemona").transform;



        // kolekcja

        Odznaka1 = GameObject.Find("Odznaka1").transform;
        Odznaka2 = GameObject.Find("Odznaka2").transform;
        Odznaka3 = GameObject.Find("Odznaka3").transform;
        Odznaka4 = GameObject.Find("Odznaka4").transform;
        Odznaka5 = GameObject.Find("Odznaka5").transform;
        Odznaka6 = GameObject.Find("Odznaka6").transform;
        Odznaka7 = GameObject.Find("Odznaka7").transform;
        Odznaka8 = GameObject.Find("Odznaka8").transform;
        Odznaka9 = GameObject.Find("Odznaka9").transform;
        Odznaka10 = GameObject.Find("Odznaka10").transform;
        Odznaka11 = GameObject.Find("Odznaka11").transform;
        Odznaka12 = GameObject.Find("Odznaka12").transform;

        Foto1 = GameObject.Find("Foto1").transform;
        Foto2 = GameObject.Find("Foto2").transform;
        Foto3 = GameObject.Find("Foto3").transform;
        Foto4 = GameObject.Find("Foto4").transform;
        Foto5 = GameObject.Find("Foto5").transform;
        Foto6 = GameObject.Find("Foto6").transform;
        Foto7 = GameObject.Find("Foto7").transform;
        Foto8 = GameObject.Find("Foto8").transform;
        Foto9 = GameObject.Find("Foto9").transform;
        Foto10 = GameObject.Find("Foto10").transform;
        Foto11 = GameObject.Find("Foto11").transform;
        Foto12 = GameObject.Find("Foto12").transform;

        Wskazowka1 = GameObject.Find("Wskazowka1").transform;
        Wskazowka2 = GameObject.Find("Wskazowka2").transform;
        Wskazowka3 = GameObject.Find("Wskazowka3").transform;
        Wskazowka4 = GameObject.Find("Wskazowka4").transform;
        Wskazowka5 = GameObject.Find("Wskazowka5").transform;
        Wskazowka6 = GameObject.Find("Wskazowka6").transform;
        Wskazowka7 = GameObject.Find("Wskazowka7").transform;
        Wskazowka8 = GameObject.Find("Wskazowka8").transform;
        Wskazowka9 = GameObject.Find("Wskazowka9").transform;
        Wskazowka10 = GameObject.Find("Wskazowka10").transform;
        Wskazowka11 = GameObject.Find("Wskazowka11").transform;
        Wskazowka12 = GameObject.Find("Wskazowka12").transform;

        MiesoDlaPotwora1 = GameObject.Find("MiesoDlaPotwora1").transform;
        MiesoDlaPotwora2 = GameObject.Find("MiesoDlaPotwora2").transform;
        MiesoDlaPotwora3 = GameObject.Find("MiesoDlaPotwora3").transform;

        // straszak

        SwiatloMalaSzopa = GameObject.Find ("SwiatloMalaSzopa").transform;
		Swiatlo2 = GameObject.Find ("Swiatlo2").transform;
        Trup = GameObject.Find("TrupL").transform;

        // zadanie kosci

        KoscZad1 = GameObject.Find("KoscZadanie1").transform;
		KoscZad2 = GameObject.Find("KoscZadanie2").transform;
		KoscZad3 = GameObject.Find("KoscZadanie3").transform;
		KoscZad4 = GameObject.Find("KoscZadanie4").transform;
		KoscZad5 = GameObject.Find("KoscZadanie5").transform;
		KoscZad1.gameObject.SetActive (false);
		KoscZad2.gameObject.SetActive (false);
		KoscZad3.gameObject.SetActive (false);
		KoscZad4.gameObject.SetActive (false);
		KoscZad5.gameObject.SetActive (false);
		KratyKosci = GameObject.Find("KratyKosci").transform;

		// zadanie studnia

		Kamien1 = GameObject.Find ("KamienStudnia1").transform;
		Kamien2 = GameObject.Find ("KamienStudnia2").transform;
		Kamien3 = GameObject.Find ("KamienStudnia3").transform;
		Kamien4 = GameObject.Find ("KamienStudnia4").transform;
		Kamien5 = GameObject.Find ("KamienStudnia5").transform;

		// zadanie fabryka

		BramaFabryka = GameObject.Find ("KratyFabryka").transform;
		SwiatloEnergii = GameObject.Find ("SwiatloEnergii").GetComponent<Light> ();

		// kolidery drzwi

		KoliderDomAlice = GameObject.Find("KoliderDomAlice").transform;
		KoliderDomTom = GameObject.Find("KoliderDomTom").transform;
		KoliderTomKsiazki = GameObject.Find("KoliderTomKsiazki").transform;
		KoliderTomSala = GameObject.Find("KoliderTomSala").transform;
		KoliderOpuszczonyDom = GameObject.Find("KoliderOpuszczonyDom").transform;
		KoliderDomStevena = GameObject.Find("KoliderDomStevena").transform;
		KoliderDomPaul = GameObject.Find("KoliderDomPaul").transform;
		KoliderPaulTyl = GameObject.Find("KoliderPaulTyl").transform;
		KoliderChatka = GameObject.Find("KoliderChatka").transform;

		// zakonczenie gry

		MonsterStatic1 = GameObject.Find ("MonsterKryjowkaStatic").transform;
		MonsterStatic2 = GameObject.Find ("MonsterKryjowkaStatic2").transform;
		MonsterGlowny = GameObject.Find ("MonsterKryjowkaGlowny").transform;

		// ikony przedmiotow

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

		// teksty zadan

		TasksZadanie1 = GameObject.Find ("TasksZadanie1").GetComponent<TextMeshProUGUI> ();
		TasksZadanie2 = GameObject.Find ("TasksZadanie2").GetComponent<TextMeshProUGUI> ();
		TasksZadanie3 = GameObject.Find ("TasksZadanie3").GetComponent<TextMeshProUGUI> ();
		TasksZadanie4 = GameObject.Find ("TasksZadanie4").GetComponent<TextMeshProUGUI> ();
		TasksZadanie5 = GameObject.Find ("TasksZadanie5").GetComponent<TextMeshProUGUI> ();

        // triggery do wskazowek

        KomunikatZapis = GameObject.Find("KomunikatZapis").gameObject;
        KomunikatItems = GameObject.Find("DomBabciaTerenNonStraszak").gameObject;
        //KomunikatPodnoszenie = GameObject.Find("KomunikatPodnoszenie").gameObject;

        // triggery do jumpscarow

        DomAliceTerenNonStraszak = GameObject.Find("DomAliceTerenNonStraszak").gameObject;
        DomTomTerenNonStraszak = GameObject.Find("DomTomTerenNonStraszak").gameObject;
        DomOpuszczonyTerenNonStraszak = GameObject.Find("DomOpuszczonyTerenNonStraszak").gameObject;
        DomStevenTerenNonStraszak = GameObject.Find("DomStevenTerenNonStraszak").gameObject;
        DomPaulTerenNonStraszak = GameObject.Find("DomPaulTerenNonStraszak").gameObject;
        ChatkaPaulTerenNonStraszak = GameObject.Find("ChatkaPaulTerenNonStraszak").gameObject;
        StevenMiesoTerenNonStraszak = GameObject.Find("StevenMiesoTerenNonStraszak").gameObject;

        /*
        Wilk1_trigger = GameObject.Find("Wilk1_trigger").gameObject;
        Wilk2_trigger = GameObject.Find("Wilk2_trigger").gameObject;
        Wilk3_trigger = GameObject.Find("Wilk3_trigger").gameObject;
        Pajak5_trigger = GameObject.Find("Pajak5_trigger").gameObject; */

        // pozostale triggery np glosy bohatera

         GlosStudnia_trigger = GameObject.Find("GlosStudnia_trigger").gameObject;
         GlosIdzWawoz_trigger = GameObject.Find("IdzWawoz_trigger").gameObject;

        // canvasy marysia haluny

        ObrazMarysia1 = GameObject.Find("CanvasHaluny1").GetComponent<Canvas>();
        ObrazMarysia2 = GameObject.Find("CanvasHaluny2").GetComponent<Canvas>();
        ObrazMarysia3 = GameObject.Find("CanvasHaluny3").GetComponent<Canvas>();
        ObrazMarysia4 = GameObject.Find("CanvasHaluny4").GetComponent<Canvas>();
        ObrazMarysia5 = GameObject.Find("CanvasHaluny5").GetComponent<Canvas>();

        // drzwi wymagajace klucza

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
        DrzwiZachodPokojS = GameObject.Find("DrzwiOtworzJmp").GetComponent<Door>();
        DrzwiSalonPoludnieS = GameObject.Find("DrzwiSalonPoludnie").GetComponent<Door>();
        DrzwiTomGoraS = GameObject.Find("DrzwiTomGora").GetComponent<Door>();
        DrzwiStevenS = GameObject.Find("DrzwiSteven").GetComponent<Door>();
        SzafaKorytarzS = GameObject.Find("SzafaKorytarz").GetComponent<Cupboard>();
        SzafaKuchniaS = GameObject.Find("SzafaKuchnia").GetComponent<Cupboard>();
        SzafkaSzopaS = GameObject.Find("SzafkaSzopa").GetComponent<Cupboard>();
        SzafkaSzopa2S = GameObject.Find("SzafkaSzopa2").GetComponent<Cupboard>();
        SzafaStaryDomS = GameObject.Find("SzafaStaryDom").GetComponent<Cupboard>();

        // Drzwi wymagajace kolidera

        DrzwiDomAliceS = GameObject.Find("DrzwiDomAlice").GetComponent<Door>();
        DrzwiDomTomS = GameObject.Find("DrzwiDomTom").GetComponent<Door>();
        DrzwiKsiazkiTomS = GameObject.Find("DrzwiKsiazkiTom").GetComponent<Door>();
        DrzwiSalaTomS = GameObject.Find("DrzwiSalaTom").GetComponent<Door>();
        DrzwiOpuszczonyS = GameObject.Find("DrzwiOpuszczony").GetComponent<Door>();
        DrzwiDomStevenS = GameObject.Find("DrzwiDomSteven").GetComponent<Door>();
        DrzwiDomPaulS = GameObject.Find("DrzwiDomPaul").GetComponent<Door>();
        DrzwiMonsterS = GameObject.Find("DrzwiMonster").GetComponent<Door>();
        DrzwiDomekS = GameObject.Find("DrzwiDomek").GetComponent<Door>();

        // audio listener

        PlayerListener = GameObject.Find("Kamera").GetComponent<AudioListener>();

        // canvas czrne okno siekiera

        CanvasCzynnoscSiekiera = GameObject.Find("CanvasCzynnoscSiekiera").GetComponent<Canvas>();

        // Animator yound dead warsztat

        YoundDead = GameObject.Find("YoungDead").transform;
        AnimatorYoungDead = GameObject.Find("YoungDead").GetComponent<Animator>();

        // Animator drzewo fall i kurze z drzewa

        AnimatorDrzewoFall = GameObject.Find("DrzewoCzlowiek").GetComponent<Animator>();
        KurzDrzewoFall = GameObject.Find("KurzDrzewoFall").gameObject;

        // drut kukurydza

        DrutKukurydza = GameObject.Find("DrutKukurydza").gameObject;

        // --------------------- Wlaczanie i wylaczanie obiektow ------------------------------------------

        WartosciPoczatkowe();

        // wczytanie wartosci fizycznych obiektow

        LoadObjects.LoadDefaultSettings();

        // latarka

        if (Flashlight.isFlashlightOn == true){
			SwiatloLatarki.enabled = true;
		}

        // trup

        if(Straszak.isCorpse == true)
        {
            Trup.gameObject.SetActive(false);
        }
			
		// Mapa

		if (Inventory.isRockyGraveSP == true) {
			SPGrobRockyPointer.enabled = true;
		}

		if (Inventory.isAnimalCementarySP == true) {
			SPCmentarzZwierzatPointer.enabled = true;
		}

		if (Inventory.isSimonGardenSP == true) {
			SPOgrodSimonaPointer.enabled = true;
		}

		if (Inventory.isTomCampSP == true) {
			SPObozTomaPointer.enabled = true;
		}

		if (Inventory.isDevilsShelterSP == true) {
			//SP.enabled = true;
		}

		if (Inventory.isWarCementarySP == true) {
			SPCmentarzWojnaPointer.enabled = true;
		}

		if (Inventory.isHutSP == true) {
			SPDomekPointer.enabled = true;
		}

		if (Inventory.isBasementSP == true) {
			SPPiwnicaPointer.enabled = true;
		}

		if (Inventory.isMushroomFieldSP == true) {
			SPPoleGrzybowePointer.enabled = true;
		}

		if (Inventory.isDarkForestSP == true) {
			SPCiemnyLasPointer.enabled = true;
		}

		if (Inventory.isBonesTowerSP == true) {
			SPWiezaKosciPointer.enabled = true;
		}

		if (Inventory.isKnifeArenaSP == true) {
			SPNozowaArenaPointer.enabled = true;
		}

		if (Inventory.isCaveSP == true) {
			SPJaskiniaPointer.enabled = true;
		}

		if (Inventory.isMonumentSP == true) {
			SPPomnikPointer.enabled = true;
		}

		if (Inventory.isSpaceshipSP == true) {
			SPStatekKosmicznyPointer.enabled = true;
		}

		// przedmioty do zadan

		if (Inventory.isKeyV1Taken == true) {
			KluczV1.gameObject.SetActive(false);
		}

		if(Inventory.isKeyV1Taken == true && Inventory.isKeyV1Removed == false){
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i+1, "KluczPokojW", Inventory.uncleKeyName, Inventory.uncleKeyDescription, Inventory.keyV1Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.keyV1Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isOilTaken == true) {
			Oliwa.gameObject.SetActive(false);
		}

		if(Inventory.isOilTaken == true && Inventory.isOilRemoved == false){
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i+1, "Oliwa", Inventory.oilName, Inventory.oilName, Inventory.oilIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.oilIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isKeyV2Taken == true) {
			KluczV2.gameObject.SetActive(false);
		}

		if (Inventory.isKeyV2Taken == true && Inventory.isKeyV2Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczSzafkaKuchnia", Inventory.kitchenWardrobeKeyName, Inventory.kitchenWardrobeKeyDescription, Inventory.keyV2Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.keyV2Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isKeyV3Taken == true) {
			KluczV3.gameObject.SetActive(false);
		}

		if (Inventory.isKeyV3Taken == true && Inventory.isKeyV3Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczStajnia", Inventory.stableKeyName, Inventory.stableKeyDescription, Inventory.keyV3Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.keyV3Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isKeyV4Taken == true || Tasks.isWoodKeyTask == false) {
			KluczV4.gameObject.SetActive(false);
		}

		if (Inventory.isKeyV4Taken == true && Inventory.isKeyV4Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczSzopa", Inventory.shedKeyName, Inventory.shedKeyDescription, Inventory.keyV4Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.keyV4Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isBatteriesTaken == true) {
			Baterie.gameObject.SetActive(false);
		}

		if (Inventory.isBatteriesTaken == true && Inventory.isBatteriesRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Baterie", Inventory.batteriesName, Inventory.batteriesDescription, Inventory.batteriesIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.batteriesIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isCassete1Taken == true) {
			Kaseta1.gameObject.SetActive(false);
		}

		if (Inventory.isCassete1Taken == true && Inventory.isCassete1Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Kaseta1", Inventory.cassete1Name, Inventory.cassete1Description, Inventory.cassete1Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.cassete1Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isBone1Taken == true) {
			Kosc1.gameObject.SetActive(false);
		}

		if (Inventory.isBone1Taken == true && Inventory.isBone1Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Kosc1", Inventory.bone1Name, Inventory.boneDescription, Inventory.bone1Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.bone1Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isBone2Taken == true) {
			Kosc2.gameObject.SetActive(false);
		}

		if (Inventory.isBone2Taken == true && Inventory.isBone2Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Kosc2", Inventory.bone2Name, Inventory.boneDescription, Inventory.bone2Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.bone2Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isBone3Taken == true) {
			Kosc3.gameObject.SetActive(false);
		}

		if (Inventory.isBone3Taken == true && Inventory.isBone3Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Kosc3", Inventory.bone3Name, Inventory.boneDescription, Inventory.bone3Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.bone3Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isBone4Taken == true) {
			Kosc4.gameObject.SetActive(false);
		}

		if (Inventory.isBone4Taken == true && Inventory.isBone4Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Kosc4", Inventory.bone3Name, Inventory.boneDescription, Inventory.bone4Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.bone4Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isBone5Taken == true) {
			Kosc5.gameObject.SetActive(false);
		}

		if (Inventory.isBone5Taken == true && Inventory.isBone5Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Kosc5", Inventory.bone5Name, Inventory.boneDescription, Inventory.bone5Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.bone5Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isNicheKeyTaken == true) {
			KluczWneka.gameObject.SetActive(false);
		}

		if (Inventory.isNicheKeyTaken == true && Inventory.isNicheKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczWneka", Inventory.nicheKeyName, Inventory.nicheKeyDescription, Inventory.nicheKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.nicheKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isSecretRoomKeyTaken == true) {
			KluczKamping.gameObject.SetActive(false);
		}

		if (Inventory.isSecretRoomKeyTaken == true && Inventory.isSecretRoomKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczKamping", Inventory.secretRoomKeyName, Inventory.secretRoomKeyDescription, Inventory.secretRoomKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.secretRoomKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}
			

		if (Inventory.isBrokenFactoryKeyTaken == true || Tasks.isBrokenKeyTask == false) {
			KluczFabrykaBroken.gameObject.SetActive(false);
		}

		if (Inventory.isBrokenFactoryKeyTaken == true && Inventory.isBrokenFactoryKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczFabryka", Inventory.factoryKeyName, Inventory.factoryKeyDescription, Inventory.brokenFactoryKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.brokenFactoryKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isWoodenWheelTaken == true || Tasks.isSimonElementTask == false) {
			BrakujaceKolo.gameObject.SetActive(false);
		}

		if (Inventory.isWoodenWheelTaken == true && Inventory.isWoodenWheelRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "DrewnianeKolo", Inventory.woodenWheelName, Inventory.woodenWheelDescription, Inventory.woodenWheelIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.woodenWheelIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

        if (Inventory.isFixedKeyTaken == true || Tasks.isFixedKey == false)
        {
            KluczNaprawiony.gameObject.SetActive(false);
        }

        if (Inventory.isFixedKeyTaken == true && Inventory.isFixedKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "FixedKey", Inventory.fixedKeyName, Inventory.fixedKeyDescription, Inventory.fixedKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.fixedKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isCrowbarTaken == true) {
			Lom.gameObject.SetActive(false);
		}

		if (Inventory.isCrowbarTaken == true && Inventory.isCrowbarRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Lom", Inventory.crowbarName, Inventory.crowbarDescription, Inventory.crowbarIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.crowbarIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isAliceKeyTaken == true || Tasks.isVictorBrookTask == false) {
			KluczSalonPoludnie.gameObject.SetActive(false);
		}

		if (Inventory.isAliceKeyTaken == true && Inventory.isAliceKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczSalonPoludnie", Inventory.aliceKeyName, Inventory.aliceKeyDescription, Inventory.aliceKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.aliceKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isPliersTaken == true) {
			Kombinerki.gameObject.SetActive(false);
		}

		if (Inventory.isPliersTaken == true && Inventory.isPliersRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Kombinerki", Inventory.pliersName, Inventory.pliersDescription, Inventory.pliersIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.pliersIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isAxeTaken == true || Tasks.isCornfieldTask == false) {
			Siekiera.gameObject.SetActive(false);
			Jumpscare.staticCornfieldMonster.SetActive (false);
		}

		if (Inventory.isAxeTaken == true && Inventory.isAxeRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Siekiera", Inventory.axeName, Inventory.axeDescription, Inventory.axeIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.axeIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isWardrobeCorridorKeyTaken == true) {
			KluczSzafaKorytarz.gameObject.SetActive(false);
		}

		if (Inventory.isWardrobeCorridorKeyTaken == true && Inventory.isWardrobeCorridorKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczSzafaKorytarz", Inventory.wardrobeCorridorKeyName, Inventory.wardrobeCorridorKeyDescription, Inventory.wardrobeCorridorKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.wardrobeCorridorKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isShedCupboardKeyTaken == true) {
			KluczSzafkaSzopa.gameObject.SetActive(false);
		}

		if (Inventory.isShedCupboardKeyTaken == true && Inventory.isShedCupboardKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczSzafkaSzopa", Inventory.shedCupboardName, Inventory.shedCupboardDescription, Inventory.shedCupboardKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.shedCupboardKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isCassete2Taken == true) {
			Kaseta2.gameObject.SetActive(false);
		}

		if (Inventory.isCassete2Taken == true && Inventory.isCassete2Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Kaseta2", Inventory.cassete2Name, Inventory.cassete2Description, Inventory.cassete2Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.cassete2Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isPumpkinTaken == true && Inventory.isPumpkinRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Dynia", Inventory.pumpkinName, Inventory.pumpkinDescription, Inventory.pumpkinIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.pumpkinIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}


		if (Inventory.isTomUpstairsKeyTaken == true || Tasks.isTomPumpkinTaskRemoved == false) {
			KluczTomGora.gameObject.SetActive(false);
		}

		if (Inventory.isTomUpstairsKeyTaken == true && Inventory.isTomUpstairsKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczTomGora", Inventory.tomUpstairsKeyName, Inventory.tomUpstairsKeyDescription, Inventory.tomUpstairsKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.tomUpstairsKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isTomRoomKeyTaken == true) {
			KluczPokojTom.gameObject.SetActive(false);
		}

		if (Inventory.isTomRoomKeyTaken == true && Inventory.isTomRoomKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczPokojTom", Inventory.tomRoomKeyName, Inventory.tomRoomKeyDescription, Inventory.tomRoomKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.tomRoomKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isCassete3Taken == true || Tasks.isTomCornifieldTask == false) {
			Kaseta3.gameObject.SetActive(false);
		}

		if (Inventory.isCassete3Taken == true && Inventory.isCassete3Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Kaseta3", Inventory.cassete3Name, Inventory.cassete3Description, Inventory.cassete3Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.cassete3Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isChipTaken == true || ZadKsiazki.isTaskDone == false) {
			Chip.gameObject.SetActive(false);
		}

		if (Inventory.isChipTaken == true && Inventory.isChipRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Chip", Inventory.chipName, Inventory.chipDescription, Inventory.chipIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.chipIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isOldWardrobeKeyTaken == true) {
			KluczSzafaStaryDom.gameObject.SetActive(false);
		}

		if (Inventory.isOldWardrobeKeyTaken == true && Inventory.isOldWardrobeKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczStaryDom", Inventory.oldWardrobeKeyName, Inventory.oldWardrobeKeyDescription, Inventory.oldWardrobeKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.oldWardrobeKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isCassete4Taken == true) {
			Kaseta4.gameObject.SetActive(false);
		}

		if (Inventory.isCassete4Taken == true && Inventory.isCassete4Removed == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Kaseta4", Inventory.cassete4Name, Inventory.cassete4Description, Inventory.cassete4Icon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.cassete4Icon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isStevenKeyTaken == true || Tasks.isStevenKeyTask == false) {
			KluczStevena.gameObject.SetActive(false);
		}

		if (Inventory.isStevenKeyTaken == true && Inventory.isStevenKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczSteven", Inventory.stevenKeyName, Inventory.stevenKeyDescription, Inventory.stevenKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.stevenKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isLabPlantTaken == true || Tasks.isStevenPlantTask == false) {
			RoslinaLab.gameObject.SetActive(false);
		}

		if (Inventory.isLabPlantTaken == true && Inventory.isLabPlantRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "RoslinaLab", Inventory.labPlantName, Inventory.labPlantDescription, Inventory.labPlantIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.labPlantIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isLabMushroomTaken == true || Tasks.isStevenMushroomTask == false) {
			GrzybLab.gameObject.SetActive(false);
		}

		if (Inventory.isLabMushroomTaken == true && Inventory.isLabMushroomRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "GrzybLab", Inventory.labMushroomName, Inventory.labMushroomDescription, Inventory.labMushroomIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.labMushroomIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isLabSkullTaken == true || Tasks.isStevenSkullTask == false) {
			CzaszkaLab.gameObject.SetActive(false);
		}

		if (Inventory.isLabSkullTaken == true && Inventory.isLabSkullRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "CzaszkaLab", Inventory.labSkullName, Inventory.labSkullDescription, Inventory.labSkullIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.labSkullIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

		if (Inventory.isStrongAcidTaken == true || (Inventory.isStrongAcidTaken == false && Tasks.isStevenShedTask == false)) {
			Mikstura.gameObject.SetActive(false);
		}

		if (Inventory.isStrongAcidTaken == false && Tasks.isLabPot == true) {
			Mikstura.gameObject.SetActive(true);
		}

		if (Inventory.isStrongAcidTaken== true && Inventory.isStrongAcidRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "Mikstura", Inventory.strongAcidName, Inventory.strongAcidDescription, Inventory.strongAcidIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.strongAcidIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}


		if (Inventory.isPaulKeyTaken == true) {
			KluczPokojZachod.gameObject.SetActive(false);
		}

		if (Inventory.isPaulKeyTaken == true && Inventory.isPaulKeyRemoved == false) {
			for(int i=0; i<Inventory.itemIcons.Length; i++){
				if(Inventory.itemIcons[i].sprite == null){
					Inventory.items.Add(new Item(i + 1, "KluczPokojZachod", Inventory.paulKeyName, Inventory.paulKeyDescription, Inventory.paulKeyIcon, false, true, false));
					Inventory.itemIcons[i].sprite = Inventory.paulKeyIcon;
					Inventory.itemIcons[i].color = Color.white;
					break;
				}
			}
		}

        inventoryUI.secretItemsText.text = Inventory.secretItemsCount + "/25";
        inventoryUI.secretPlacesText.text = Inventory.secretPlacesCount + "/15";
		Inventory.greenHerbsText.text = Inventory.greenHerbsCount + "";
		Inventory.blueHerbsText.text = Inventory.blueHerbsCount + "";
		Inventory.healthPotsText.text = Inventory.healthPotsCount + "";
		Inventory.staminaPotsText.text = Inventory.staminaPotsCount + "";
        Inventory.vialsCountText.text = Inventory.vialsCount + "";

        // Secret items

        if (Inventory.isSecretIem1 == true) {
			SecretItem1.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem2 == true) {
			SecretItem2.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem3 == true) {
			SecretItem3.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem4 == true) {
			SecretItem4.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem5 == true) {
			SecretItem5.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem6 == true) {
			SecretItem6.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem7 == true) {
			SecretItem7.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem8 == true) {
			SecretItem8.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem9 == true) {
			SecretItem9.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem10 == true) {
			SecretItem10.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem11 == true) {
			SecretItem11.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem12 == true) {
			SecretItem12.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem13 == true) {
			SecretItem13.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem14 == true) {
			SecretItem14.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem15 == true) {
			SecretItem15.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem16 == true) {
			SecretItem16.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem17 == true) {
			SecretItem17.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem18 == true) {
			SecretItem18.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem19 == true) {
			SecretItem19.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem20 == true) {
			SecretItem20.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem21 == true) {
			SecretItem21.gameObject.SetActive (false);
		}

		if (Inventory.isSecretIem22 == true) {
			SecretItem22.gameObject.SetActive (false);
		}
		if (Inventory.isSecretIem23 == true) {
			SecretItem23.gameObject.SetActive (false);
		}
		if (Inventory.isSecretIem24 == true) {
			SecretItem24.gameObject.SetActive (false);
		}
		if (Inventory.isSecretIem25 == true) {
			SecretItem25.gameObject.SetActive (false);
		}
        if (Inventory.isSecretIem26 == true)
        {
            SecretItem26.gameObject.SetActive(false);
        }
        if (Inventory.isSecretIem27 == true)
        {
            SecretItem27.gameObject.SetActive(false);
        }
        if (Inventory.isSecretIem28 == true)
        {
            SecretItem28.gameObject.SetActive(false);
        }
        if (Inventory.isSecretIem29 == true)
        {
            SecretItem29.gameObject.SetActive(false);
        }
        if (Inventory.isSecretIem30 == true)
        {
            SecretItem30.gameObject.SetActive(false);
        }
        if (Inventory.isSecretIem31 == true)
        {
            SecretItem31.gameObject.SetActive(false);
        }
        if (Inventory.isSecretIem32 == true)
        {
            SecretItem32.gameObject.SetActive(false);
        }

        // zielone ziola

        if (Inventory.isGreenHerb1 == true) {
			ZieloneZiolo1.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb2 == true) {
			ZieloneZiolo2.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb3 == true) {
			ZieloneZiolo3.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb4 == true) {
			ZieloneZiolo4.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb5 == true) {
			ZieloneZiolo5.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb6 == true) {
			ZieloneZiolo6.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb7 == true) {
			ZieloneZiolo7.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb8 == true) {
			ZieloneZiolo8.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb9 == true) {
			ZieloneZiolo9.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb10 == true) {
			ZieloneZiolo10.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb11 == true) {
			ZieloneZiolo11.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb12 == true) {
			ZieloneZiolo12.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb13 == true) {
			ZieloneZiolo13.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb14 == true) {
			ZieloneZiolo14.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb15 == true) {
			ZieloneZiolo15.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb16 == true) {
			ZieloneZiolo16.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb17 == true) {
			ZieloneZiolo17.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb18 == true) {
			ZieloneZiolo18.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb19 == true) {
			ZieloneZiolo19.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb20 == true) {
			ZieloneZiolo20.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb21 == true) {
			ZieloneZiolo21.gameObject.SetActive (false);
		}

		if (Inventory.isGreenHerb22 == true) {
			ZieloneZiolo22.gameObject.SetActive (false);
		}

        if (Inventory.isGreenHerb20 == true)
        {
            ZieloneZiolo20.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb21 == true)
        {
            ZieloneZiolo21.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb22 == true)
        {
            ZieloneZiolo22.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb23 == true)
        {
            ZieloneZiolo23.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb24 == true)
        {
            ZieloneZiolo24.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb25 == true)
        {
            ZieloneZiolo25.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb26 == true)
        {
            ZieloneZiolo26.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb27 == true)
        {
            ZieloneZiolo27.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb28 == true)
        {
            ZieloneZiolo28.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb29 == true)
        {
            ZieloneZiolo29.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb30 == true)
        {
            ZieloneZiolo30.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb31 == true)
        {
            ZieloneZiolo31.gameObject.SetActive(false);
        }

        if (Inventory.isGreenHerb32 == true)
        {
            ZieloneZiolo32.gameObject.SetActive(false);
        }

        // niebieskie ziola

        if (Inventory.isBlueHerb1 == true) {
			NiebieskieZiolo1.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb2 == true) {
			NiebieskieZiolo2.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb3 == true) {
			NiebieskieZiolo3.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb4 == true) {
			NiebieskieZiolo4.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb5 == true) {
			NiebieskieZiolo5.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb6 == true) {
			NiebieskieZiolo6.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb7 == true) {
			NiebieskieZiolo7.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb8 == true) {
			NiebieskieZiolo8.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb9 == true) {
			NiebieskieZiolo9.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb10 == true) {
			NiebieskieZiolo10.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb11 == true) {
			NiebieskieZiolo11.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb12 == true) {
			NiebieskieZiolo12.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb13 == true) {
			NiebieskieZiolo13.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb14 == true) {
			NiebieskieZiolo14.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb15 == true) {
			NiebieskieZiolo15.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb16 == true) {
			NiebieskieZiolo16.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb17 == true) {
			NiebieskieZiolo17.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb18 == true) {
			NiebieskieZiolo18.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb19 == true) {
			NiebieskieZiolo19.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb20 == true) {
			NiebieskieZiolo20.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb21 == true) {
			NiebieskieZiolo21.gameObject.SetActive (false);
		}

		if (Inventory.isBlueHerb22 == true) {
			NiebieskieZiolo22.gameObject.SetActive (false);
		}

        if (Inventory.isBlueHerb23 == true)
        {
            NiebieskieZiolo23.gameObject.SetActive(false);
        }

        if (Inventory.isBlueHerb24 == true)
        {
            NiebieskieZiolo24.gameObject.SetActive(false);
        }

        if (Inventory.isBlueHerb25 == true)
        {
            NiebieskieZiolo25.gameObject.SetActive(false);
        }

        if (Inventory.isBlueHerb26 == true)
        {
            NiebieskieZiolo26.gameObject.SetActive(false);
        }

        if (Inventory.isBlueHerb27 == true)
        {
            NiebieskieZiolo27.gameObject.SetActive(false);
        }

        if (Inventory.isBlueHerb28 == true)
        {
            NiebieskieZiolo28.gameObject.SetActive(false);
        }

        if (Inventory.isBlueHerb29 == true)
        {
            NiebieskieZiolo29.gameObject.SetActive(false);
        }

        if (Inventory.isBlueHerb30 == true)
        {
            NiebieskieZiolo30.gameObject.SetActive(false);
        }

        if (Inventory.isBlueHerb31 == true)
        {
            NiebieskieZiolo31.gameObject.SetActive(false);
        }

        if (Inventory.isBlueHerb32 == true)
        {
            NiebieskieZiolo32.gameObject.SetActive(false);
        }

        // fiolki

        if (Inventory.isVial1 == true)
        {
            Fiolka1.gameObject.SetActive(false);
        }

        if (Inventory.isVial2 == true)
        {
            Fiolka2.gameObject.SetActive(false);
        }

        if (Inventory.isVial3 == true)
        {
            Fiolka3.gameObject.SetActive(false);
        }

        if (Inventory.isVial4 == true)
        {
            Fiolka4.gameObject.SetActive(false);
        }

        if (Inventory.isVial5 == true)
        {
            Fiolka5.gameObject.SetActive(false);
        }

        if (Inventory.isVial6 == true)
        {
            Fiolka6.gameObject.SetActive(false);
        }

        if (Inventory.isVial7 == true)
        {
            Fiolka7.gameObject.SetActive(false);
        }

        if (Inventory.isVial8 == true)
        {
            Fiolka8.gameObject.SetActive(false);
        }

        if (Inventory.isVial9 == true)
        {
            Fiolka9.gameObject.SetActive(false);
        }

        if (Inventory.isVial10 == true)
        {
            Fiolka10.gameObject.SetActive(false);
        }

        if (Inventory.isVial11 == true)
        {
            Fiolka11.gameObject.SetActive(false);
        }

        if (Inventory.isVial12 == true)
        {
            Fiolka12.gameObject.SetActive(false);
        }

        if (Inventory.isVial13 == true)
        {
            Fiolka13.gameObject.SetActive(false);
        }

        if (Inventory.isVial14 == true)
        {
            Fiolka14.gameObject.SetActive(false);
        }

        if (Inventory.isVial15 == true)
        {
            Fiolka15.gameObject.SetActive(false);
        }

        if (Inventory.isVial16 == true)
        {
            Fiolka16.gameObject.SetActive(false);
        }

        // eliksiry

        if (Inventory.isStaminaPot1 == true)
        {
            EliksirStamina1.gameObject.SetActive(false);
        }

        if (Inventory.isStaminaPot2 == true)
        {
            EliksirStamina2.gameObject.SetActive(false);
        }

        if (Inventory.isStaminaPot3 == true)
        {
            EliksirStamina3.gameObject.SetActive(false);
        }

        if (Inventory.isStaminaPot4 == true)
        {
            EliksirStamina4.gameObject.SetActive(false);
        }

        if (Inventory.isStaminaPot5 == true)
        {
            EliksirStamina5.gameObject.SetActive(false);
        }

        if (Inventory.isHealthPot1 == true)
        {
            EliksirZdrowie1.gameObject.SetActive(false);
        }

        if (Inventory.isHealthPot2 == true)
        {
            EliksirZdrowie2.gameObject.SetActive(false);
        }

        if (Inventory.isHealthPot3 == true)
        {
            EliksirZdrowie3.gameObject.SetActive(false);
        }

        if (Inventory.isHealthPot4 == true)
        {
            EliksirZdrowie4.gameObject.SetActive(false);
        }

        if (Inventory.isHealthPot5 == true)
        {
            EliksirZdrowie5.gameObject.SetActive(false);
        }

        if (Inventory.isHealthPot6 == true)
        {
            EliksirZdrowie6.gameObject.SetActive(false);
        }


        // skille

        if (Inventory.isSkill1_Unlocked == true) {
			Skill1Icon.color = Color.green;
		}

		if (Inventory.isSkill2_Unlocked == true) {
			Skill2Icon.color = Color.green;
		}

		if (Inventory.isSkill3_Unlocked == true) {
			Skill3Icon.color = Color.green;
		}

		if (Inventory.isSkill4_Unlocked == true) {
			Skill4Icon.color = Color.green;
		}

		// kolidery do drzwi itp

		if (Tasks.isUncleDoorLocked == false) {
			KoliderPokojW.gameObject.SetActive (false);
            DrzwiPokojWS.isNeedKey = false;
        }else
        {
            DrzwiPokojWS.isNeedKey = true;
        }

		if (Tasks.isKitchenWardrobeLocked == false) {
			KoliderSzafkaKuchnia.gameObject.SetActive (false);
            SzafaKuchniaS.isNeedKey = false;
        }
        else
        {
            SzafaKuchniaS.isNeedKey = true;
        }

        if (Tasks.isStableDoorLocked == false) {
			KoliderStajnia.gameObject.SetActive (false);
            DrzwiStajniaS.isNeedKey = false;
        }
        else
        {
            DrzwiStajniaS.isNeedKey = true;
        }

        if (Tasks.isToolShedDoorLocked == false) {
			KoliderDrzwiSzopaNarzedzia.gameObject.SetActive (false);
            DrzwiSzopaNarzedziaS.isNeedKey = false;
        }
        else
        {
            DrzwiSzopaNarzedziaS.isNeedKey = true;
        }

        if (Tasks.isGardenDoorLocked == false) {
			KoliderOgrod.gameObject.SetActive (false);
            DrzwiOgrodS.isNeedKey = false;
        }
        else
        {
            DrzwiOgrodS.isNeedKey = true;
        }

        if (Tasks.isNicheDoorLocked == false) {
			KoliderDrzwiWneka.gameObject.SetActive (false);
            DrzwiWnekaS.isNeedKey = false;
        }
        else
        {
            DrzwiWnekaS.isNeedKey = true;
        }

        if (Tasks.isSecretRoomDoorLocked == false) {
			KoliderDrzwiKamping.gameObject.SetActive (false);
            DrzwiKampingS.isNeedKey = false;
        }
        else
        {
            DrzwiKampingS.isNeedKey = true;
        }

        if (Tasks.isFactoryWoodenDoorLocked == false) {
			KoliderDrzwiFabrykaDrewno.gameObject.SetActive (false);
            DrzwiFabrykaDrewnoS.isNeedKey = false;
        }
        else
        {
            DrzwiFabrykaDrewnoS.isNeedKey = true;
        }

        if (Tasks.isFactoryMetalDoorLocked == false) {
			KoliderDrzwiFabrykaMetal.gameObject.SetActive (false);
            DrzwiFabrykaMetalS.isNeedKey = false;
        }
        else
        {
            DrzwiFabrykaMetalS.isNeedKey = true;
        }

        if (Tasks.isAliceRoomDoorLocked == false) {
			KoliderDrzwiSalonPoludnie.gameObject.SetActive (false);
            DrzwiSalonPoludnieS.isNeedKey = false;
        }
        else
        {
            DrzwiSalonPoludnieS.isNeedKey = true;
        }

        if (Tasks.isCornfieldDoorLocked == false) {
			KoliderKukurydza.gameObject.SetActive (false);
            DrzwiKukurydzaS.isNeedKey = false;
            DrutKukurydza.SetActive(false);
        }
        else
        {
            DrzwiKukurydzaS.isNeedKey = true;
        }

        if (Tasks.isPlanksLocked == false) {
			DeskiSzopa.gameObject.SetActive (false);
		}

        if (Tasks.isCorridorWardrobeLocked == false) {
			KoliderSzafkaKorytarz.gameObject.SetActive (false);
            SzafaKorytarzS.isNeedKey = false;
        }
        else
        {
            SzafaKorytarzS.isNeedKey = true;
        }

        if (Tasks.isShedCupboardLocked == false) {
			KoliderSzafkaSzopa.gameObject.SetActive (false);
            SzafkaSzopaS.isNeedKey = false;
            SzafkaSzopa2S.isNeedKey = false;
        }
        else
        {
            SzafkaSzopa2S.isNeedKey = true;
        }

        if (Tasks.isPumpkin == true) {
			Dynia.gameObject.SetActive (true);
		}

		if (Tasks.isTomUpstairsDoorLocked == false) {
			KoliderDrzwiTomGora.gameObject.SetActive (false);
            DrzwiTomGoraS.isNeedKey = false;
        }
        else
        {
            DrzwiTomGoraS.isNeedKey = true;
        }

        if (Tasks.isTomRoomDoorLocked == false) {
			KoliderDrzwiPokojTom.gameObject.SetActive (false);
            DrzwiPokojTomS.isNeedKey = false;
        }
        else
        {
            DrzwiPokojTomS.isNeedKey = true;
        }

        if (Tasks.isOldWardrobeLocked == false) {
			KoliderSzafaStaryDom.gameObject.SetActive (false);
            SzafaStaryDomS.isNeedKey = false;
        }
        else
        {
            SzafaStaryDomS.isNeedKey = true;
        }

        if (Tasks.isStevenDoorLocked == false) {
			KoliderDrzwiSteven.gameObject.SetActive (false);
            DrzwiStevenS.isNeedKey = false;
        }
        else
        {
            DrzwiStevenS.isNeedKey = true;
        }

        if (Tasks.isStevenGrille == false) {
			KratySteven.gameObject.SetActive (false);
		}

        if (Tasks.isPaulDoorLocked == false) {
			KoliderDrzwiZachod.gameObject.SetActive (false);
            DrzwiZachodS.isNeedKey = false;
        }
        else
        {
            DrzwiZachodS.isNeedKey = true;
        }

        if(Straszak.isOpenDoor == true)
        {
            DrzwiZachodPokojS.isNeedKey = false;
        }
        else
        {
            DrzwiZachodPokojS.isNeedKey = true;
        }

        // pointery na mapie i zadania

        if (Tasks.isFirstTask == true && Tasks.isFirstTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadaniePoczatek", Tasks.beginTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.beginTaskText;
					break;
				}
			}
		}

	/*	if(Tasks.ZadaniePoczatek_ok == false){ 
			Tasks.ZadaniePoczatek ();
		}*/
			

		if(Tasks.isSearchTask == true && Tasks.isSearchTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieSzukajInfo", Tasks.searchTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.searchTaskText;
					break;
				}
			}
		}

        if (Tasks.isWoodKeyTask == true)
        {
            StraszakLosowy.enabled = true;
        }

		if(Tasks.isWoodKeyTask == true && Tasks.isWoodKeyTaskRemoved == false){

			KluczDrewnoPointer.enabled = true;
            Compass.AddTaskPoint(Compass.keyWoodPoint);

			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKluczDrewno", Tasks.woodKeyTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.woodKeyTaskText;
					break;
				}
			}
		}
			

		if(Tasks.isMagicWellTask == true && Tasks.isMagicWellTaskRemoved == false){

			MagicznaStudniaPointer.enabled = true;
            Compass.AddTaskPoint(Compass.magicWellPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieMagicznaStudnia", Tasks.magicWellTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.magicWellTaskText;
					break;
				}
			}
		}

		if(Tasks.isWellStonesTask == false || (Tasks.isWellStonesTask == true && Tasks.isWellStonesTaskRemoved == true)){
			Kamien1.gameObject.SetActive (false);
			Kamien2.gameObject.SetActive (false);
			Kamien3.gameObject.SetActive (false);
			Kamien4.gameObject.SetActive (false);
			Kamien5.gameObject.SetActive (false);
		}

		if(Tasks.isWellStonesTask == true && Tasks.isWellStonesTaskRemoved == false){

			ZadStudnia.enabled = true;
            MagicznaStudniaPointer.enabled = true;
            Compass.AddTaskPoint(Compass.magicWellPoint);
            KamienieObszar.enabled = true;
			Kamien1.gameObject.SetActive (true);
			Kamien2.gameObject.SetActive (true);
			Kamien3.gameObject.SetActive (true);
			Kamien4.gameObject.SetActive (true);
			Kamien5.gameObject.SetActive (true);
            Music.KlimatStudnia();

			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKamienieStudnia", Tasks.wellStonesTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.wellStonesTaskText;
					break;
				}
			}
		}

		if(Tasks.isCassete1Task == true && Tasks.isCassete1TaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKaseta1", Tasks.casseteTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.casseteTaskText;
					break;
				}
			}
		}

        if (Tasks.isGardenDoorTask == true && Tasks.isGardenDoorTaskRemoved == false)
        {
            DrzwiOgrodPointer.enabled = true;
            Compass.AddTaskPoint(Compass.gardenDoorPoint);

            for (int i = 0; i < Tasks.tasksTextMesh.Length; i++)
            {
                if (Tasks.tasksTextMesh[i].text.Length == 0)
                {
                    Tasks.tasksList.Add(new TaskData("ZadanieDrzwiOgrod", Tasks.gardenDoorTaskText));
                    Tasks.tasksTextMesh[i].text = Tasks.gardenDoorTaskText;
                    break;
                }
            }

        }

        if (Tasks.isBonesTask == true && Tasks.isBonesTaskRemoved == false){

			KosciObszar.enabled = true;
			Jumpscare.gardenMonster.SetActive (true);
			Jumpscare.gardenMonster.GetComponent<Monster1_v1> ().enabled = true;
            Music.KlimatOgrod();

			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKosci", Tasks.bonesTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.bonesTaskText;
					break;
				}
			}
		}

		if (Tasks.isGoToAliceTask == true) {
			DomAlicePointer.enabled = true;
            Compass.AddTaskPoint(Compass.aliceHousePoint);
            KoliderDomAlice.gameObject.SetActive (false);
            DrzwiDomAliceS.isNeedKey = false;
		}

		if(Tasks.isGoToAliceTask == true && Tasks.isGoToAliceTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieIdzAlice", Tasks.ZadanieIdzAliceT));
					Tasks.tasksTextMesh[i].text = Tasks.ZadanieIdzAliceT;
					break;
				}
			}
		}

		if(Tasks.isAliceSearchTask == true && Tasks.isAliceSearchTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieAliceInfo", Tasks.goToAliceTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.goToAliceTaskText;
					break;
				}
			}
		}

		if(Tasks.isSimonElementTask == true && Tasks.isSimonElementTaskRemoved == false){

			SimonElementPointer.enabled = true;
            Compass.AddTaskPoint(Compass.simonElementPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieSimonElement", Tasks.simonElementTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.simonElementTaskText;
					break;
				}
			}

		}

        if (Tasks.isWorkshopTask == true && Tasks.isWorkshopTaskRemoved == false)
        {
            WarsztatPointer.enabled = true;
            Compass.AddTaskPoint(Compass.workshopPoint);

            for (int i = 0; i < Tasks.tasksTextMesh.Length; i++)
            {
                if (Tasks.tasksTextMesh[i].text.Length == 0)
                {
                    Tasks.tasksList.Add(new TaskData("ZadanieWarsztat", Tasks.workshopTaskText));
                    Tasks.tasksTextMesh[i].text = Tasks.workshopTaskText;
                    break;
                }
            }

        }

        if (Tasks.isBrokenKeyTask == true && Tasks.isBrokenKeyTaskRemoved == false){
			
			ZepsutyKluczPointer.enabled = true;
			ZadAmbona.enabled = true;
            Compass.AddTaskPoint(Compass.brokenKeyPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieZepsutyKlucz", Tasks.brokenKeyTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.brokenKeyTaskText;
					break;
				}
			}

		}

		if(Tasks.isFixKeyTask == true && Tasks.isFixKeyTaskRemoved == false){

			ZadKolo.enabled = true;

			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieNaprawKlucz", Tasks.fixKeyTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.fixKeyTaskText;
					break;
				}
			}
		}
			
		if(Tasks.isAnimalCemetaryTask == true && Tasks.isAnimalCemetaryTaskRemoved == false){
			
			CmentarzZwierzPointer.enabled = true;
            StrzalkaCmentarzZwierzPointer.enabled = true;
            Music.KlimatWarsztatSimon();
            Compass.AddTaskPoint(Compass.animalCementaryPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieCmentarzZwierz", Tasks.animalCemetaryTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.animalCemetaryTaskText;
					break;
				}
			}

		}

		if(Tasks.isVictorBrookTask == true && Tasks.isVictorBrookTaskRemoved == false){
			
			StrzalkaVictorPointer.enabled = true;
            StrzalkaVictorPointer2.enabled = true;
            Music.KlimatWarsztatSimon();

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieVictorPotok", Tasks.victorBrookTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.victorBrookTaskText;
					break;
				}
			}

		}

		if(Tasks.isAliceRoomTask == true && Tasks.isAliceRoomTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieSalonAlice", Tasks.aliceRoomTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.aliceRoomTaskText;
					break;
				}
			}
		}

		if(Tasks.isCornfieldTask == true && Tasks.isCornfieldTaskRemoved == false){
			
			KukurydzaPointer.enabled = true;
            Compass.AddTaskPoint(Compass.cornfieldPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKukurydza", Tasks.cornfieldTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.cornfieldTaskText;
					break;
				}
			}

		}

		if(Tasks.isAxeTask == true && Tasks.isAxeTaskRemoved == false){
			
			SiekieraPointer.enabled = true;
            Compass.AddTaskPoint(Compass.axePoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieSiekiera", Tasks.axeTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.axeTaskText;
					break;
				}
			}

		}

		if(Tasks.isCorridorWardrobeTask == true && Tasks.isCorridorWardrobeTaskRemoved == false){
			
			SzafaKorytarzPointer.enabled = true;
            Compass.AddTaskPoint(Compass.wardrobeCorridorPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieSzafaKorytarz", Tasks.corridorWardrobeTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.corridorWardrobeTaskText;
					break;
				}
			}

		}

		if(Tasks.isEdwardCupboardTask == true && Tasks.isEdwardCupboardTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieSzafkaEdward", Tasks.edwardCupboardTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.edwardCupboardTaskText;
					break;
				}
			}
		}

		if(Tasks.isCassete2Task == true && Tasks.isCassete2TaskRemoved == false){
			
			Kaseta2Pointer.enabled = true;
            Compass.AddTaskPoint(Compass.cassete2Point);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKaseta2", Tasks.Cassete2TaskText));
					Tasks.tasksTextMesh[i].text = Tasks.Cassete2TaskText;
					break;
				}
			}

		}

		if(Tasks.isGoToTrialTask == true && Tasks.isGoToTrialTaskRemoved == false){
			
			IdzSzlakPointer.enabled = true;
            Compass.AddTaskPoint(Compass.goTrailPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieIdzSzlak", Tasks.goToTrialTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.goToTrialTaskText;
					break;
				}
			}

		}

		if(Tasks.isGoTrailTask == true && Tasks.isGoTrailTaskRemoved == false){
			
			StrzalkaSzlakPointer.enabled = true;

			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKierujSzlak", Tasks.goTrailTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.goTrailTaskText;
					break;
				}
			}

		}

		if(Tasks.isGetToTomRoadTask == true && Tasks.isGetToTomRoadTaskRemoved == false){
			
			PrzedostanSiePointer.enabled = true;
            Compass.AddTaskPoint(Compass.getToPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadaniePrzedostanSie", Tasks.getToTomRoadTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.getToTomRoadTaskText;
					break;
				}
			}

		}

		if(Tasks.isTomSearchTask == true){

			DomTomPointer.enabled = true;
            Compass.AddTaskPoint(Compass.tomHousePoint);

            KoliderDomTom.gameObject.SetActive (false);
			KoliderTomKsiazki.gameObject.SetActive (false);
			KoliderTomSala.gameObject.SetActive (false);

            DrzwiDomTomS.isNeedKey = false;
            DrzwiKsiazkiTomS.isNeedKey = false;
            DrzwiSalaTomS.isNeedKey = false;

        }

		if(Tasks.isTomSearchTask== true && Tasks.isTomSearchTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieTomInfo", Tasks.tomSearchTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.tomSearchTaskText;
					break;
				}
			}
		}

		if(Tasks.isTomCornifieldTask == true && Tasks.isTomCornifieldTaskRemoved == false){
			
			KukurydzaObszar.enabled = true;

			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieTomKukurydza", Tasks.ZadanieTomKukurydzaT));
					Tasks.tasksTextMesh[i].text = Tasks.ZadanieTomKukurydzaT;
					break;
				}
			}

		}

		if(Tasks.isCassete3Task== true && Tasks.isCassete3TaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKaseta3", Tasks.cassete3TaskText));
					Tasks.tasksTextMesh[i].text = Tasks.cassete3TaskText;
					break;
				}
			}
		}

		if(Tasks.isTompCampTask == true && Tasks.isTompCampTaskRemoved == false){
			
			TomObozPointer.enabled = true;
            Compass.AddTaskPoint(Compass.tomCampPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieTomOboz", Tasks.tomCampTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.tomCampTaskText;
					break;
				}
			}

		}

		if(Tasks.isTomPumpkinTask == true && Tasks.isTomPumpkinTaskRemoved == false){

            TomObozPointer.enabled = true;
            Compass.AddTaskPoint(Compass.tomCampPoint);
            DyniaObszar.enabled = true;

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieTomDynia", Tasks.tomPumpkinTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.tomPumpkinTaskText;
					break;
				}
			}

		}

		if(Tasks.isTomChipTask == true && Tasks.isTomChipTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieTomChip", Tasks.tomChipTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.tomChipTaskText;
					break;
				}
			}
		}

		if(Tasks.isRavineTask == true && Tasks.isRavineTaskRemoved == false){
			
			WawozPointer.enabled = true;
            Compass.AddTaskPoint(Compass.ravibePoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieWawoz", Tasks.ravineTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.ravineTaskText;
					break;
				}
			}

		}

		if(Tasks.isGoRavineTask == true && Tasks.isGoRavineTaskRemoved == false){
			
			StrzalkaIdzWawoz.enabled = true;

			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieIdzWawoz", Tasks.goTrialTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.goTrialTaskText;
					break;
				}
			}

		}

		if(Tasks.isAbandonedSearchTask == true){
			
			DomOpuszczonyPointer.enabled = true;
            Compass.AddTaskPoint(Compass.abandonedHousePoint);
            KoliderOpuszczonyDom.gameObject.SetActive (false);
            DrzwiOpuszczonyS.isNeedKey = false;

        }

		if(Tasks.isAbandonedSearchTask == true && Tasks.isAbandonedSearchTaskRemoved == false){

			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieOpuszczonyInfo", Tasks.abandonedSearchTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.abandonedSearchTaskText;
					break;
				}
			}

		}


		if(Tasks.isCassete4Task == true && Tasks.isCassete4TaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKaseta4", Tasks.cassete4TaskText));
					Tasks.tasksTextMesh[i].text = Tasks.cassete4TaskText;
					break;
				}
			}
		}


		if(Tasks.isStevenSearchTask == true){

			DomStevenPointer.enabled = true;
            Compass.AddTaskPoint(Compass.stevenHousePoint);
            KoliderDomStevena.gameObject.SetActive (false);
            DrzwiDomStevenS.isNeedKey = false;
        }

		if(Tasks.isStevenSearchTask == true && Tasks.isStevenSearchTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieStevenInfo", Tasks.stevenSearchTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.stevenSearchTaskText;
					break;
				}
			}
		}

        if(Tasks.isStevenKeyTask == false)
        {

            MiesoDlaPotwora1.gameObject.SetActive(false);
            MiesoDlaPotwora2.gameObject.SetActive(false);
            MiesoDlaPotwora3.gameObject.SetActive(false);

        }


		if(Tasks.isStevenKeyTask == true && Tasks.isStevenKeyTaskRemoved == false){
			
			ObszarStevenKlucz.enabled = true;
			StevenMiesoPointer.enabled = true;
            Compass.AddTaskPoint(Compass.stevenMeatPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieStevenKlucz", Tasks.stevenKeyTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.stevenKeyTaskText;
					break;
				}
			}

		}

		if(Tasks.isStevenMushroomTask == true && Tasks.isStevenMushroomTaskRemoved == false){
			
			StevenGrzybPointer.enabled = true;
            Compass.AddTaskPoint(Compass.stevenMushroomPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieStevenGrzyb", Tasks.stevenMushroomTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.stevenMushroomTaskText;
					break;
				}
			}

		}

		if(Tasks.isStevenPlantTask == true && Tasks.isStevenPlantTaskRemoved == false){

			StevenRoslinaPointer.enabled = true;
            Compass.AddTaskPoint(Compass.stevenPlantPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieStevenRoslina", Tasks.stevenPlantTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.stevenPlantTaskText;
					break;
				}
			}

		}

		if(Tasks.isStevenSkullTask == true && Tasks.isStevenSkullTaskRemoved == false){
			
			StevenCzaszkaPointer.enabled = true;
            Compass.AddTaskPoint(Compass.stevenSkullPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieStevenCzaszka", Tasks.stevenSkullTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.stevenSkullTaskText;
					break;
				}
			}

		}

		if(Tasks.isStevenAcidTask == true && Tasks.isStevenAcidTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKwas", Tasks.acidTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.acidTaskText;
					break;
				}
			}
		}

		if(Tasks.isStevenShedTask == true && Tasks.isStevenShedTaskRemoved == false){
			
			StevenSzopaPointer.enabled = true;
            Compass.AddTaskPoint(Compass.stevenShedPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieStevenSzopa", Tasks.stevenShedTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.stevenShedTaskText;
					break;
				}
			}

		}

		if(Tasks.isStevenNoteTask == true && Tasks.isStevenNoteTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieStevenNotatka", Tasks.stevenNoteTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.stevenNoteTaskText;
					break;
				}
			}
		}

		if(Tasks.isStevenBrookTask == true && Tasks.isStevenBrookTaskRemoved == false){
			
			StevenPotokPointer.enabled = true;
            Compass.AddTaskPoint(Compass.stevenBrookPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieStevenPotok", Tasks.stevenBrookTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.stevenBrookTaskText;
					break;
				}
			}

		}

		if(Tasks.isPaulSearchTask == true){

			DomNaukowcaPointer.enabled = true;
            Compass.AddTaskPoint(Compass.scientistHousePoint);

            KoliderDomPaul.gameObject.SetActive (false);
			KoliderPaulTyl.gameObject.SetActive (false);

            DrzwiDomPaulS.isNeedKey = false;
            DrzwiMonsterS.isNeedKey = false;
        }

		if(Tasks.isPaulSearchTask == true && Tasks.isPaulSearchTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadaniePaulInfo", Tasks.paulSearchTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.paulSearchTaskText;
					break;
				}
			}
		}

		if(Tasks.isPaulDoorTask == true && Tasks.isPaulDoorTaskRemoved == false){
			for(int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadaniePaulDrzwi", Tasks.paulDoorTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.paulDoorTaskText;
					break;
				}
			}
		}

        if (Tasks.isHutTask == true) {

            KoliderOtworzDrzwi.SetActive(false);
            DrzwiDomekS.isNeedKey = false;
        }

		if(Tasks.isHutTask == true && Tasks.isHutTaskRemoved == false){
			
			ChatkaPointer.enabled = true;
            Compass.AddTaskPoint(Compass.hutPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieChatka", Tasks.hutTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.hutTaskText;
					break;
				}
			}

		}

		if(Tasks.isHutTask == true){

			KoliderChatka.gameObject.SetActive (false);

		}

		if(Tasks.isDevilsBrookTask == true && Tasks.isDevilsBrookTaskRemoved == false){

			PotokDiablyPointer.enabled = true;
            Compass.AddTaskPoint(Compass.devilsBrookPoint);

            for (int i=0; i<Tasks.tasksTextMesh.Length; i++){
				if(Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadaniePotokDiably", Tasks.devilsBrookTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.devilsBrookTaskText; 
					break;
				}
			}

		}

		if(Tasks.isDevilsShelterTask == true && Tasks.isDevilsShelterTaskRemoved == false){
			
			KryjowkaDiablyObszar.enabled = true;

			for (int i = 0; i < Tasks.tasksTextMesh.Length; i++){
				if (Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKryjowkaDiably", Tasks.devilsShelterTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.devilsShelterTaskText; // # Find the Devil's hide
					break;
				}
			}

		}

		if(Tasks.isShelterFamilyTask == true && Tasks.isShelterFamilyTaskRemoved == false){
			for (int i = 0; i < Tasks.tasksTextMesh.Length; i++){
				if (Tasks.tasksTextMesh[i].text.Length == 0){
					Tasks.tasksList.Add(new TaskData("ZadanieKryjowkaRodzina", Tasks.endTaskText));
					Tasks.tasksTextMesh[i].text = Tasks.endTaskText; // # Find the Devil's hide
					break;
				}
			}
		}

        // pointery z notatek a nie zadan

        if(Inventory.isShedCupboardKeyTaken == true && Inventory.isCassete2Taken == false)
        {
            Tasks.AddSzafkaEdwardPointer();
        }

        if(Notes.isNote3 == true && Inventory.isBone3Taken == false)
        {
            Tasks.AddKoscSzopaPointer();
        }

        if (Notes.isNote3 == true && Inventory.isBone4Taken == false)
        {
            Tasks.AddKoscStajniaPointer();
        }

        if(Notes.isNote7 == true && Inventory.isKeyV2Taken == false)
        {
            Tasks.AddKluczWychodekPointer();
        }

        if(Inventory.isKeyV4Taken == true && Tasks.isToolShedDoorLocked == true)
        {
            Tasks.AddSzopaNarzedziaPointer();
        }

        if(Inventory.isSecretRoomKeyTaken == true && Tasks.isCassete1Played == false)
        {
            Tasks.AddSekretnyPokojPointer();
        }

        // notatki

        if (Notes.isNote1 == true) {
			Notatka1.gameObject.SetActive (false);
		}

		if (Notes.isNote2 == true) {
			Notatka2.gameObject.SetActive (false);
		}

		if (Notes.isNote3 == true) {
			Notatka3.gameObject.SetActive (false);
		}

		if (Notes.isNote4 == true) {
			Notatka4.gameObject.SetActive (false);
		}

		if (Notes.isNote5 == true) {
			Notatka5.gameObject.SetActive (false);
		}

		if (Notes.isNote6 == true) {
			Notatka6.gameObject.SetActive (false);
		}

		if (Notes.isNote7 == true) {
			Notatka7.gameObject.SetActive (false);
		}

		if (Notes.isNote8 == true) {
			Notatka8.gameObject.SetActive (false);
		}

		if (Notes.isNote9 == true) {
			Notatka9.gameObject.SetActive (false);
		}

		if (Notes.isNote10 == true) {
			Notatka10.gameObject.SetActive (false);
		}

		if (Notes.isNote11 == true) {
			Notatka11.gameObject.SetActive (false);
		}

		if (Notes.isNote12 == true) {
			Notatka12.gameObject.SetActive (false);
		}

		if (Notes.isNote13 == true || Tasks.isMagicWellTask == false) {
			Notatka13.gameObject.SetActive (false);
		}

		if (Notes.isNote14 == true) {
			Notatka14.gameObject.SetActive (false);
		}

		if (Notes.isNote15 == true) {
			Notatka15.gameObject.SetActive (false);
		}

		if (Notes.isNote16 == true) {
			Notatka16.gameObject.SetActive (false);
		}

		if (Notes.isNote17 == true) {
			Notatka17.gameObject.SetActive (false);
		}

		if (Notes.isNote18 == true) {
			Notatka18.gameObject.SetActive (false);
		}

		if (Notes.isNote19 == true) {
			Notatka19.gameObject.SetActive (false);
		}

		if (Notes.isNote20 == true || Tasks.isAliceSearchTask == false) {
			Notatka20.gameObject.SetActive (false);
		}

		if (Notes.isNote21 == true) {
			Notatka21.gameObject.SetActive (false);
		}

		if (Notes.isNote22 == true) {
			Notatka22.gameObject.SetActive (false);
		}

		if (Notes.isNote23 == true) {
			Notatka23.gameObject.SetActive (false);
		}

		if (Notes.isNote24 == true || Tasks.isAnimalCemetaryTask == false) {
			Notatka24.gameObject.SetActive (false);
		}

		if (Notes.isNote25 == true) {
			Notatka25.gameObject.SetActive (false);
		}

		if (Notes.isNote26 == true) {
			Notatka26.gameObject.SetActive (false);
		}

		if (Notes.isNote27 == true) {
			Notatka27.gameObject.SetActive (false);
		}

		if (Notes.isNote28 == true) {
			Notatka28.gameObject.SetActive (false);
		}

		if (Notes.isNote29 == true) {
			Notatka29.gameObject.SetActive (false);
		}

		if (Notes.isNote30 == true) {
			Notatka30.gameObject.SetActive (false);
		}

		if (Notes.isNote31 == true) {
			Notatka31.gameObject.SetActive (false);
		}

		if (Notes.isNote32 == true) {
			Notatka32.gameObject.SetActive (false);
		}

		if (Notes.isNote33 == true) {
			Notatka33.gameObject.SetActive (false);
		}

		if (Notes.isNote34 == true || Tasks.isTompCampTask == false) {
			Notatka34.gameObject.SetActive (false);
		}

		if (Notes.isNote35 == true) {
			Notatka35.gameObject.SetActive (false);
		}

		if (Notes.isNote36 == true || Tasks.isGoRavineTask == false) {
			Notatka36.gameObject.SetActive (false);
		}

		if (Notes.isNote37 == true) {
			Notatka37.gameObject.SetActive (false);
		}

		if (Notes.isNote38 == true) {
			Notatka38.gameObject.SetActive (false);
		}

		if (Notes.isNote39 == true) {
			Notatka39.gameObject.SetActive (false);
		}

		if (Notes.isNote40 == true) {
			Notatka40.gameObject.SetActive (false);
		}

		if (Notes.isNote41 == true) {
			Notatka41.gameObject.SetActive (false);
		}

		if (Notes.isNote42 == true || Tasks.isStevenKeyTask == false) {
			Notatka42.gameObject.SetActive (false);
		}

		if (Notes.isNote43 == true) {
			Notatka43.gameObject.SetActive (false);
		}

		if (Notes.isNote44 == true) {
			Notatka44.gameObject.SetActive (false);
		}

		if (Notes.isNote45 == true) {
			Notatka45.gameObject.SetActive (false);
		}

		if (Notes.isNote46 == true) {
			Notatka46.gameObject.SetActive (false);
		}

		if (Notes.isNote47 == true) {
			Notatka47.gameObject.SetActive (false);
		}

		if (Notes.isNote48 == true) {
			Notatka48.gameObject.SetActive (false);
		}

		if (Notes.isNote49 == true) {
			Notatka49.gameObject.SetActive (false);
		}

		if (Notes.isNote50 == true) {
			Notatka50.gameObject.SetActive (false);
		}

		if (Notes.isNote51 == true) {
			Notatka51.gameObject.SetActive (false);
		}

		if (Notes.isNote52 == true) {
			Notatka52.gameObject.SetActive (false);
		}

		if (Notes.isNote53 == true) {
			Notatka53.gameObject.SetActive (false);
		}

		if (Notes.isNote54 == true) {
			Notatka54.gameObject.SetActive (false);
		}

		if (Notes.isFoxNote == true) {
			NotatkaLisy.gameObject.SetActive (false);
		}

		if (Notes.isWoodPhoto == true) {
			ZdjecieDrewno.gameObject.SetActive (false);
		}

		if (Notes.isZenoPhoto == true) {
			ZdjecieZeno.gameObject.SetActive (false);
		}

		if (Notes.isShoppingNote == true) {
			NotatkaZakupy.gameObject.SetActive (false);
		}

		if (Notes.isQuote1Note == true) {
			NotatkaCytat1.gameObject.SetActive (false);
		}

		if (Notes.isCornfieldPicture == true) {
			RysunekKukurydza.gameObject.SetActive (false);
		}

		if (Notes.isLeftBrookNote == true) {
			NotatkaPotokLewy.gameObject.SetActive (false);
		}

		if (Notes.isMushroomNote == true) {
			NotatkaGrzyby.gameObject.SetActive (false);
		}

		if (Notes.isBrookPhoto3 == true) {
			ZdjeciePotok3.gameObject.SetActive (false);
		}

		if (Notes.isBrookPhoto2 == true) {
			ZdjeciePotok2.gameObject.SetActive (false);
		}

		if (Notes.isBrookPhoto1 == true) {
			ZdjeciePotok1.gameObject.SetActive (false);
		}

		if (Notes.isSimonPicture == true) {
			RysunekSimon.gameObject.SetActive (false);
		}

		if (Notes.isRapNote == true) {
			NotatkaRap.gameObject.SetActive (false);
		}

		if (Notes.isTowerPhoto == true) {
			ZdjecieAmbona.gameObject.SetActive (false);
		}

		if (Notes.isWellPhoto == true) {
			ZdjecieStudnia.gameObject.SetActive (false);
		}

		if (Notes.isQuote2Note == true) {
			NotatkaCytat2.gameObject.SetActive (false);
		}

		if (Notes.isMonumentPhoto == true) {
			ZdjeciePomnik.gameObject.SetActive (false);
		}

		if (Notes.isInventionNote == true) {
			NotatkaWynalazki.gameObject.SetActive (false);
		}

		if (Notes.isWorkshopPhoto == true) {
			ZdjecieWarsztat.gameObject.SetActive (false);
		}

		if (Notes.isDarkForestNote == true) {
			NotatkaCiemny.gameObject.SetActive (false);
		}

		if (Notes.isAnimalsNote == true) {
			NotatkaZwierzeta.gameObject.SetActive (false);
		}

		if (Notes.isNightNote == true) {
			NotatkaNoc.gameObject.SetActive (false);
		}

		if (Notes.isWardrobePhoto == true) {
			ZdjecieSzafa.gameObject.SetActive (false);
		}

		if (Notes.isShedPhoto == true) {
			ZdjecieSzopa.gameObject.SetActive (false);
		}

		if (Notes.isCampPhoto == true) {
			ZdjecieOboz.gameObject.SetActive (false);
		}

		if (Notes.isMaryNote == true) {
			NotatkaMary.gameObject.SetActive (false);
		}

		if (Notes.isDaughterPicture == true) {
			RysunekCorki.gameObject.SetActive (false);
		}

		if (Notes.isDiplomaNote == true) {
			NotatkaDyplom.gameObject.SetActive (false);
		}

		if (Notes.isTomPicture == true) {
			RysunekTom.gameObject.SetActive (false);
		}

		if (Notes.isQuote3Note == true) {
			NotatkaCytat3.gameObject.SetActive (false);
		}

		if (Notes.isMonsterPicture == true) {
			RysunekPotwor.gameObject.SetActive (false);
		}

		if (Notes.iswhisperNote == true) {
			NotatkaSzepty.gameObject.SetActive (false);
		}

		if (Notes.isQuote4Note == true) {
			NotatkaCytat4.gameObject.SetActive (false);
		}

		if (Notes.isPlantPicture == true) {
			RysunekRosliny.gameObject.SetActive (false);
		}

		if (Notes.isFieldNote == true) {
			NotatkaPole.gameObject.SetActive (false);
		}

		if (Notes.isArenaNote == true) {
			NotatkaArena.gameObject.SetActive (false);
		}

		if (Notes.isQuote5Note == true) {
			NotatkaCytat5.gameObject.SetActive (false);
		}

		if (Notes.isBrookPhoto4 == true) {
			ZdjeciePotok4.gameObject.SetActive (false);
		}

		if (Notes.isAliensNote== true) {
			NotatkaKosmici.gameObject.SetActive (false);
		}

		if (Notes.isQuote6Note == true) {
			NotatkaCytat6.gameObject.SetActive (false);
		}

        if(Notes.isDemonNote == true)
        {
            NotatkaDemona.gameObject.SetActive(false);
        }

        // kolekcja

        if(Inventory.isBadge1 == true)
        {
            Odznaka1.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[0].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[0].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge2 == true)
        {
            Odznaka2.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[1].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[1].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge3 == true)
        {
            Odznaka3.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[2].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[2].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge4 == true)
        {
            Odznaka4.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[3].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[3].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge5 == true)
        {
            Odznaka5.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[4].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[4].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge6 == true)
        {
            Odznaka6.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[5].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[5].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge7 == true)
        {
            Odznaka7.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[6].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[6].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge8 == true)
        {
            Odznaka8.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[7].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[7].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge9 == true)
        {
            Odznaka9.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[8].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[8].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge10 == true)
        {
            Odznaka10.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[9].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[9].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge11 == true)
        {
            Odznaka11.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[10].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[10].sprite = Inventory.badgeSprite;
        }

        if (Inventory.isBadge12 == true)
        {
            Odznaka12.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[11].sprite = Inventory.badgeOKSprite;
        }else
        {
            Inventory.collectionTextures[11].sprite = Inventory.badgeSprite;
        }


        if(Inventory.isPhoto1 == true)
        {
            Foto1.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[12].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[12].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto2 == true)
        {
            Foto2.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[13].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[13].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto3 == true)
        {
            Foto3.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[14].sprite = Inventory.photoOKSprite;
        }
        else
        {
            Inventory.collectionTextures[14].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto4 == true)
        {
            Foto4.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[15].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[15].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto5 == true)
        {
            Foto5.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[16].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[16].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto6 == true)
        {
            Foto6.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[17].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[17].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto7 == true)
        {
            Foto7.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[18].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[18].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto8 == true)
        {
            Foto8.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[19].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[19].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto9 == true)
        {
            Foto9.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[20].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[20].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto10 == true)
        {
            Foto10.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[21].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[21].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto11 == true)
        {
            Foto11.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[22].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[22].sprite = Inventory.photoSprite;
        }

        if (Inventory.isPhoto12 == true)
        {
            Foto12.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[23].sprite = Inventory.photoOKSprite;
        }else
        {
            Inventory.collectionTextures[23].sprite = Inventory.photoSprite;
        }


        if(Inventory.isTip1 == true)
        {
            Wskazowka1.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[24].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[24].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip2 == true)
        {
            Wskazowka2.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[25].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[25].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip3 == true)
        {
            Wskazowka3.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[26].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[26].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip4 == true)
        {
            Wskazowka4.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[27].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[27].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip5 == true)
        {
            Wskazowka5.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[28].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[28].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip6 == true)
        {
            Wskazowka6.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[29].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[29].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip7 == true)
        {
            Wskazowka7.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[30].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[30].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip8 == true)
        {
            Wskazowka8.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[31].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[31].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip9 == true)
        {
            Wskazowka9.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[32].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[32].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip10 == true)
        {
            Wskazowka10.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[33].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[33].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip11 == true)
        {
            Wskazowka11.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[34].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[34].sprite = Inventory.tipSprite;
        }

        if (Inventory.isTip12 == true)
        {
            Wskazowka12.transform.gameObject.SetActive(false);
            Inventory.collectionTextures[35].sprite = Inventory.tipOKSprite;
        }else
        {
            Inventory.collectionTextures[35].sprite = Inventory.tipSprite;
        }

        // straszak

        if (Straszak.isBoneShedBreath == true) {
			SwiatloMalaSzopa.gameObject.SetActive (false);
		} 

		if (Straszak.isLight == true) {
			Swiatlo2.gameObject.SetActive (false);
		}

        // zadanie kolo nierozwiazane ale z dodanym kolem

        if(Tasks.isWheel == true && Tasks.isFixedKey == false)
        {
            ZadKolo.counter = 0;
            ZadKolo.isFullCounter = false;
            ZadKolo.isHalfCounter = false;
            DrewnianeKolo.gameObject.SetActive(true);
            ZadKolo.woodenWheel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            ZadKolo.woodenWheel.GetComponent<SphereCollider>().enabled = true;
            ZadKolo.enabled = true;
        }

		// zadanie kolo

		if (Tasks.isFixedKey == true) {
			ZadKolo.isHalfCounter = true;
			ZadKolo.isFullCounter = true;
			DrewnianeKolo.gameObject.SetActive (true);
            DrewnianeKolo.GetComponent<Collider>().enabled = false;
			DrewnianeKolo.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		}

		// zadanie kosci

		if(Tasks.isBonesTask == true && Tasks.isBonesTaskRemoved == false){
			ZadKosci.enabled = true;
		}

		if (Inventory.isSecretRoomKeyTaken == true) {
			KoscZad1.gameObject.SetActive (true);
			KoscZad2.gameObject.SetActive (true);
			KoscZad3.gameObject.SetActive (true);
			KoscZad4.gameObject.SetActive (true);
			KoscZad5.gameObject.SetActive (true);
			//KratyKosci.gameObject.SetActive (false);
		}

		// zadanie fabryka

		if (Saving.FabrykaZapis2_ok == true) {
			BramaFabryka.gameObject.SetActive (false);
			SwiatloEnergii.color = Color.green;
			ZadFabryka.isHasEnergy = true;
			ZadFabryka.isLever = true;
        }

		// wlaczanie zadania fabryka
		if(Tasks.isFactoryWoodenDoorLocked == false && Tasks.isAnimalCemetaryTask == false){
			ZadFabryka.enabled = true;
		}

		// kraty dynia

		if (Saving.ObozTomZapis_ok == true) {
			KratyDynia.gameObject.SetActive (false);
		}

		// wylaczanie potworow
		Jumpscare.pumpkinMonster.SetActive(false);
		Jumpscare.pumpkinMonster.gameObject.GetComponent<Monster1_Dynia> ().enabled = false;
		Jumpscare.brookMonster1.SetActive(false);
		Jumpscare.brookMonster1.gameObject.GetComponent<MonsterPotok1> ().enabled = false;
		Jumpscare.cornfieldMonster.SetActive(false);
		Jumpscare.cornfieldMonster.GetComponent<Monster2_v1> ().enabled = false;
		Jumpscare.corridorMonster.SetActive(false);
		Jumpscare.corridorMonster.GetComponent<Monster2_v2> ().enabled = false;
		Jumpscare.cornfieldMonster2.SetActive(false);
		Jumpscare.cornfieldMonster2.GetComponent<Monster2_v3> ().enabled = false;
		Jumpscare.channelMonster.SetActive(false);
		Jumpscare.channelMonster.GetComponent<MonsterKoryto> ().enabled = false;
		Jumpscare.meatMonster1.SetActive(false);
		Jumpscare.meatMonster1.GetComponent<Monster1_v3> ().enabled = false;
		Jumpscare.meatMonster2.SetActive(false);
		Jumpscare.meatMonster2.GetComponent<Monster1_v4> ().enabled = false;
		Jumpscare.paulRoomMonster.SetActive(false);
		Jumpscare.paulRoomMonster.GetComponent<MonsterPokojZachod> ().enabled = false;
		Jumpscare.paulDoorMonster.SetActive(false);
		Jumpscare.paulDoorMonster.GetComponent<MonsterDrzwiZachod> ().enabled = false;
		Jumpscare.gardenMonster.SetActive(false);
		Jumpscare.gardenMonster.GetComponent<Monster1_v1> ().enabled = false; 
		Jumpscare.workshopMonster.SetActive(false);
		Jumpscare.workshopMonster.GetComponent<Monster1_v2> ().enabled = false;
		Jumpscare.abandonedMonster.SetActive(false);
		Jumpscare.abandonedMonster.GetComponent<MonsterOpuszczony> ().enabled = false;
		Jumpscare.shedMonster1.SetActive(false);
		Jumpscare.shedMonster1.GetComponent<Monster1_Szopa1> ().enabled = false;
		Jumpscare.tomMonster.SetActive(false);
		Jumpscare.tomMonster.GetComponent<Monster1_Tom> ().enabled = false;
		Jumpscare.plantMonster.SetActive(false);
		Jumpscare.plantMonster.gameObject.GetComponent<Monster2_Roslina> ().enabled = false;
		Jumpscare.bushMonster.SetActive(false);
		Jumpscare.bushMonster.gameObject.GetComponent<Monster1_Krzaki> ().enabled = false;
		Jumpscare.paulDownstairsMonster.SetActive(false);
		Jumpscare.paulDownstairsMonster.gameObject.GetComponent<MonsterZachod_dol> ().enabled = false;
		Jumpscare.stevenShedMonster1.SetActive(false);
		Jumpscare.stevenShedMonster1.gameObject.GetComponent<Monster1_SzopaSteven1> ().enabled = false;
		Jumpscare.stevenShedMonster2.SetActive(false);
		Jumpscare.stevenShedMonster2.gameObject.GetComponent<Monster1_SzopaSteven2> ().enabled = false;
        Jumpscare.beginMonster.SetActive(false);
        Jumpscare.beginMonster.gameObject.GetComponent<MonsterPoczatek>().enabled = false;
        Jumpscare.stableMonster.SetActive(false);
        Jumpscare.secretRoomMonster.SetActive(false);
        Jumpscare.wolf1.SetActive(false);
        Jumpscare.wolf1.gameObject.GetComponent<Wolf_v1>().enabled = false;
        Jumpscare.wolf2.SetActive(false);
        Jumpscare.wolf2.gameObject.GetComponent<Wilk_v2>().enabled = false;
        Jumpscare.wolf3.SetActive(false);
        Jumpscare.wolf3.gameObject.GetComponent<Wilk_v3>().enabled = false;
        Jumpscare.beginWolf1.gameObject.SetActive(false);
        Jumpscare.beginWolf1.gameObject.GetComponent<WilkPoczatek>().enabled = false;
        Jumpscare.beginWolf2.gameObject.SetActive(false);
        Jumpscare.beginWolf2.gameObject.GetComponent<WilkPoczatek>().enabled = false;
        Jumpscare.jumpscareSpider1.gameObject.SetActive(false);
        Jumpscare.jumpscareSpider1.gameObject.GetComponent<PajakJmp1>().enabled = false;
        Jumpscare.jumpscareSpider2.gameObject.SetActive(false);
        Jumpscare.jumpscareSpider2.gameObject.GetComponent<PajakJmp1>().enabled = false;
        Jumpscare.spider3.gameObject.SetActive(false);
        Jumpscare.spider3.gameObject.GetComponent<Spider_v3>().enabled = false;
        Jumpscare.spider4.gameObject.SetActive(false);
        Jumpscare.spider4.gameObject.GetComponent<Pajak_v4>().enabled = false;
        Jumpscare.spider5.gameObject.SetActive(false);
        Jumpscare.spider5.gameObject.GetComponent<Pajak_v5>().enabled = false;

        // wylaczanie straszakow scarecrow

        ScarecrowStraszak.MonsterKorytarz.SetActive(false);
        ScarecrowStraszak.MonsterStajnia.SetActive(false);
        ScarecrowStraszak.MonsterWychodek.SetActive(false);
        ScarecrowStraszak.MonsterSzalas.SetActive(false);
        ScarecrowStraszak.MonsterSzalas2.SetActive(false);
        ScarecrowStraszak.MonsterSzalas2.GetComponent<MonsterSzalas>().enabled = false;
        ScarecrowStraszak.MonsterSzopa.SetActive(false);
        ScarecrowStraszak.MonsterSzopa.GetComponent<MonsterScarecrowSzopa>().enabled = false;

        // wylaczanie potwora losowego

        MonsterLosowy.gameObject.SetActive(false);
        MonsterLosowy.gameObject.GetComponent<RandomMonster>().enabled = false;
        MonsterLosowy2.gameObject.SetActive(false);
        MonsterLosowy2.gameObject.GetComponent<RandomMonster2>().enabled = false;
        MonsterLosowy3.gameObject.SetActive(false);
        MonsterLosowy3.gameObject.GetComponent<RandomMonster3>().enabled = false;

        // wlaczanie potworow

        if (Tasks.isWellStonesTask == true)
        {

            Jumpscare.Wilk1Function();

        }

        if (Tasks.isBonesTask == true && Tasks.isBonesTaskRemoved == false){

			Jumpscare.gardenMonster.SetActive (true);
			Jumpscare.gardenMonster.GetComponent<Monster1_v1> ().enabled = true;

		}

		if(Tasks.isStevenShedTask == true && Tasks.isStevenShedTaskRemoved == false){

			Jumpscare.stevenShedMonster1.SetActive(true);
			Jumpscare.stevenShedMonster1.gameObject.GetComponent<Monster1_SzopaSteven1> ().enabled = true;
			//Jumpscare.MonsterSzopaSteven1_ok = true;

		}

        if(Jumpscare.isCorridorMonster == true && Inventory.isShedCupboardKeyTaken == false)
        {
            Jumpscare.corridorMonster.SetActive(true);
            Jumpscare.corridorMonster.gameObject.GetComponent<Monster2_v2>().enabled = true;
        }

        if(Tasks.isTomSearchTask == true)
        {
            Jumpscare.Pajak5Function();
        }

        if(Tasks.isTomPumpkinTask == true && Tasks.isTomPumpkinTaskRemoved == false && Inventory.isPumpkinTaken == false)
        {
            Jumpscare.pumpkinMonster.SetActive(true);
            Jumpscare.pumpkinMonster.GetComponent<Monster1_Dynia>().enabled = true;

        }

        if(Jumpscare.isAbandonedMonster == true && Tasks.isStevenSearchTask == false && Straszak.isStairsCreak == false)
        {
            //Jumpscare.MonsterOpuszczony.SetActive(true);
            //Jumpscare.MonsterOpuszczony.GetComponent<MonsterOpuszczony>().enabled = true;
            Jumpscare.SkrzypienieSchody_trigger();
        }

        if(Tasks.isStevenSkullTask == true && Tasks.isStevenSkullTaskRemoved == false)
        {
            Jumpscare.bushMonster.SetActive(true);
            Jumpscare.bushMonster.gameObject.GetComponent<Monster1_Krzaki>().enabled = true;
        }

		// muzyka potwory
		Music.monsterBackgroundAudioSource1.Stop();
		Music.isPlantMonsterMusic = false;

		// zakonczenie gry

		MonsterStatic1.gameObject.SetActive (false);
		MonsterStatic2.gameObject.SetActive (false);
		MonsterGlowny.gameObject.SetActive (false);

		Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z);

        // wlaczanie triggerow do wskazowek

        KomunikatZapis.GetComponent<Collider>().enabled = true;
        KomunikatItems.GetComponent<Collider>().enabled = true;
        //KomunikatPodnoszenie.GetComponent<Collider>().enabled = true;

        // wlaczanie triggerow do jumpscarow

        DomAliceTerenNonStraszak.GetComponent<Collider>().enabled = true;
        DomTomTerenNonStraszak.GetComponent<Collider>().enabled = true;
        DomOpuszczonyTerenNonStraszak.GetComponent<Collider>().enabled = true;
        DomStevenTerenNonStraszak.GetComponent<Collider>().enabled = true;
        DomPaulTerenNonStraszak.GetComponent<Collider>().enabled = true;
        ChatkaPaulTerenNonStraszak.GetComponent<Collider>().enabled = true;
        StevenMiesoTerenNonStraszak.GetComponent<Collider>().enabled = true;

        /*
        Wilk1_trigger.GetComponent<Collider>().enabled = true;
        Wilk2_trigger.GetComponent<Collider>().enabled = true;
        Wilk3_trigger.GetComponent<Collider>().enabled = true;
        Pajak5_trigger.GetComponent<Collider>().enabled = true;*/ 

        // wlaczanie pozostalych triggerow np glosy bohatera

        GlosStudnia_trigger.GetComponent<Collider>().enabled = true;
        GlosIdzWawoz_trigger.GetComponent<Collider>().enabled = true;

        // wlaczanie listenera

        if (!PlayerInstance.isRespown)
        {
            PlayerListener.enabled = true;
        }

        // Dodanie hingejointow do zniszczonych drzwi

        if (!DrzwiDom.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiDom.tag = "Door";
            DrzwiDom.gameObject.AddComponent<HingeJoint>();
            DrzwiDom.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f,0);
            DrzwiDom.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiDom.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1329.995f, 42.66398f, 1985.885f);
            DrzwiDom.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiDom.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 90;
            DrzwiDom.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiWneka.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiWneka.tag = "Door";
            DrzwiWneka.gameObject.AddComponent<HingeJoint>();
            DrzwiWneka.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0, -0.004858255f, 0);
            DrzwiWneka.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 0, -1);
            DrzwiWneka.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1324.306f, 39.4311f, 1976.993f);
            DrzwiWneka.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiWneka.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = -100;
            limits.max =0;
            DrzwiWneka.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiToaleta.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiToaleta.tag = "Door";
            DrzwiToaleta.gameObject.AddComponent<HingeJoint>();
            DrzwiToaleta.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(-0.07f, -2.85f, 0);
            DrzwiToaleta.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiToaleta.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1310.719f, 43.02197f, 1977.182f);
            DrzwiToaleta.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiToaleta.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 90;
            DrzwiToaleta.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiLazienka.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiLazienka.tag = "Door";
            DrzwiLazienka.gameObject.AddComponent<HingeJoint>();
            DrzwiLazienka.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(-0.07f, 2.85f, 0);
            DrzwiLazienka.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            //DrzwiLazienka.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1294.016f, 42.97197f, 1977.275f);
            DrzwiLazienka.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiLazienka.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 90;
            DrzwiLazienka.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiWujki.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiWujki.tag = "Door";
            DrzwiWujki.gameObject.AddComponent<HingeJoint>();
            DrzwiWujki.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(-0.07f, 2.85f, 0);
            DrzwiWujki.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiWujki.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1286.215f, 42.97197f, 1981.001f);
            DrzwiWujki.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiWujki.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 90;
            DrzwiWujki.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiKuchnia.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiKuchnia.tag = "Door";
            DrzwiKuchnia.gameObject.AddComponent<HingeJoint>();
            DrzwiKuchnia.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiKuchnia.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiKuchnia.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1289.074f, 42.68398f, 1991.293f);
            DrzwiKuchnia.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiKuchnia.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 90;
            DrzwiKuchnia.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiStajnia.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiStajnia.tag = "Door";
            DrzwiStajnia.gameObject.AddComponent<HingeJoint>();
            DrzwiStajnia.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(-0.07f, 2.85f, 0);
            DrzwiStajnia.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiStajnia.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1376.586f, 42.95297f, 1925.405f);
            DrzwiStajnia.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiStajnia.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 100;
            DrzwiStajnia.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiDrewutnia.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiDrewutnia.tag = "Door";
            DrzwiDrewutnia.gameObject.AddComponent<HingeJoint>();
            DrzwiDrewutnia.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(-0.07f, 2.85f, 0);
            DrzwiDrewutnia.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiDrewutnia.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1451.153f, 48.88297f, 1900.363f);
            DrzwiDrewutnia.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiDrewutnia.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 90;
            DrzwiDrewutnia.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiSzopa.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiSzopa.tag = "Door";
            DrzwiSzopa.gameObject.AddComponent<HingeJoint>();
            DrzwiSzopa.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(-0.07f, 2.85f, 0);
            DrzwiSzopa.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiSzopa.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1447.662f, 48.91497f, 1935.04f);
            DrzwiSzopa.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiSzopa.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 100;
            DrzwiSzopa.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiKamping.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiKamping.tag = "Door";
            DrzwiKamping.gameObject.AddComponent<HingeJoint>();
            DrzwiKamping.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiKamping.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiKamping.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1444.204f, 48.64398f, 1980.728f);
            DrzwiKamping.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiKamping.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 90;
            DrzwiKamping.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiKukurydza.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiKukurydza.tag = "Door";
            DrzwiKukurydza.gameObject.AddComponent<HingeJoint>();
            DrzwiKukurydza.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0, -0.004858255f, 0);
            DrzwiKukurydza.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 0, -1);
            DrzwiKukurydza.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1290.655f, 39.36128f, 2126.485f);
            DrzwiKukurydza.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiKukurydza.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = -100;
            limits.max = 0;
            DrzwiKukurydza.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiOgrod.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiOgrod.tag = "Door";
            DrzwiOgrod.gameObject.AddComponent<HingeJoint>();
            DrzwiOgrod.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(-0.8f, 0.51f, 0);
            DrzwiOgrod.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiOgrod.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1244.88f, 41.67109f, 2048.728f);
            DrzwiOgrod.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiOgrod.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 120;
            DrzwiOgrod.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiGlowneGora.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiGlowneGora.tag = "Door";
            DrzwiGlowneGora.gameObject.AddComponent<HingeJoint>();
            DrzwiGlowneGora.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiGlowneGora.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiGlowneGora.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1752.124f, 64.50016f, 798.41f);
            DrzwiGlowneGora.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiGlowneGora.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 100;
            DrzwiGlowneGora.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiPokojP1.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiPokojP1.tag = "Door";
            DrzwiPokojP1.gameObject.AddComponent<HingeJoint>();
            DrzwiPokojP1.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiPokojP1.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiPokojP1.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1746.739f, 64.52875f, 788.3808f);
            DrzwiPokojP1.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiPokojP1.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 0;
            limits.max = 100;
            DrzwiPokojP1.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiPokojP2.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiPokojP2.tag = "Door";
            DrzwiPokojP2.gameObject.AddComponent<HingeJoint>();
            DrzwiPokojP2.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiPokojP2.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiPokojP2.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1746.789f, 64.53875f, 782.6008f);
            DrzwiPokojP2.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiPokojP2.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 0;
            limits.max = 100;
            DrzwiPokojP2.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiPokojL1.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiPokojL1.tag = "Door";
            DrzwiPokojL1.gameObject.AddComponent<HingeJoint>();
            DrzwiPokojL1.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiPokojL1.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiPokojL1.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1751.101f, 64.51875f, 786.7392f);
            DrzwiPokojL1.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiPokojL1.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 90;
            DrzwiPokojL1.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiPokojL2.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiPokojL2.tag = "Door";
            DrzwiPokojL2.gameObject.AddComponent<HingeJoint>();
            DrzwiPokojL2.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiPokojL2.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiPokojL2.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1751.161f, 64.54875f, 779.9492f);
            DrzwiPokojL2.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiPokojL2.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 0;
            limits.max = 100;
            DrzwiPokojL2.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiWejsciowe.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiWejsciowe.tag = "Door";
            DrzwiWejsciowe.gameObject.AddComponent<HingeJoint>();
            DrzwiWejsciowe.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiWejsciowe.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiWejsciowe.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1742.878f, 56.07398f, 804.0755f);
            DrzwiWejsciowe.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiWejsciowe.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 100;
            DrzwiWejsciowe.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiKorytarz.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiKorytarz.tag = "Door";
            DrzwiKorytarz.gameObject.AddComponent<HingeJoint>();
            DrzwiKorytarz.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiKorytarz.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiKorytarz.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1750.018f, 55.82016f, 798.41f);
            DrzwiKorytarz.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiKorytarz.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 100;
            DrzwiKorytarz.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiGaraz.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiGaraz.tag = "Door";
            DrzwiGaraz.gameObject.AddComponent<HingeJoint>();
            DrzwiGaraz.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiGaraz.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiGaraz.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1747.493f, 55.82016f, 804.88f);
            DrzwiGaraz.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiGaraz.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 100;
            DrzwiGaraz.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiTylne.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiTylne.tag = "Door";
            DrzwiTylne.gameObject.AddComponent<HingeJoint>();
            DrzwiTylne.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiTylne.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiTylne.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1761.5f, 55.97718f, 801.378f);
            DrzwiTylne.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiTylne.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 100;
            DrzwiTylne.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiLazienkaZachod.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiLazienkaZachod.tag = "Door";
            DrzwiLazienkaZachod.gameObject.AddComponent<HingeJoint>();
            DrzwiLazienkaZachod.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiLazienkaZachod.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiLazienkaZachod.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1754.189f, 55.79875f, 788.5108f);
            DrzwiLazienkaZachod.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiLazienkaZachod.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 100;
            DrzwiLazienkaZachod.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        if (!DrzwiPokojDol.gameObject.GetComponent<HingeJoint>())
        {
            DrzwiPokojDol.tag = "Door";
            DrzwiPokojDol.gameObject.AddComponent<HingeJoint>();
            DrzwiPokojDol.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0.64f, 1.58f, 0);
            DrzwiPokojDol.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0, 1, 0);
            DrzwiPokojDol.gameObject.GetComponent<HingeJoint>().connectedAnchor = new Vector3(1751.615f, 55.82016f, 783.09f);
            DrzwiPokojDol.gameObject.GetComponent<HingeJoint>().useLimits = true;
            JointLimits limits = DrzwiPokojDol.gameObject.GetComponent<HingeJoint>().limits;
            limits.min = 1;
            limits.max = 90;
            DrzwiPokojDol.gameObject.GetComponent<HingeJoint>().limits = limits;

        }

        // Wylaczanie young dead warsztat

        if(Notes.isNote24 == true)
        {
            YoundDead.gameObject.SetActive(false);
        }

        // Przewrocenie drzewa fall

        if(Straszak.isFallTree == true)
        {
            AnimatorDrzewoFall.SetTrigger("DrzewoFall");
        }

        KurzDrzewoFall.SetActive(false);

    }
	

	/*void Update () {
		
	} */

	public void WartosciPoczatkowe(){

        // Wskrzeszanie po smierci

		Player.gameObject.GetComponent<Animator> ().SetTrigger ("Odrodzenie");

        // Skrypt Gracz

        // Postac.PredkoscPoruszania = 4;
        //Postac.PredkoscChodzenia = 6;
        Postac.currentVelocity = Postac.walkVelocity;
        Postac.crouchVelocity = 4;
        Postac.currentStamina = Postac.maxStamina;
        Postac.staminaRegenerationFactor = 8;
        Postac.isRest = true;
        Postac.isSprint = false;
        Postac.isSprintEffect = false;

        // przyciski ekwipunek skills

		Skill1Icon.color = Color.white;
		Skill2Icon.color = Color.white;
		Skill3Icon.color = Color.white;
		Skill4Icon.color = Color.white;

        // aktualny przedmiot canvas UI

        Inventory.currentItemIcon.sprite = null;
        Inventory.currentItemIcon.color = Color.black;
        Inventory.currenntItemTitle.text = Inventory.currentItemText;

        // Sloty w ekwipunku

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

        // zadania

		TasksZadanie1.text = "";
		TasksZadanie2.text = "";
		TasksZadanie3.text = "";
		TasksZadanie4.text = "";
		TasksZadanie5.text = "";

        // pointery na mapie

		KluczDrewnoPointer.enabled = false;
		MagicznaStudniaPointer.enabled = false;
		KamienieObszar.enabled = false;
		KosciObszar.enabled = false;
        DrzwiOgrodPointer.enabled = false;
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

        // pointery sekretnych miejsc

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
        
        // kasowanie listy przedmiotow

        if (Inventory.items.Count > 0) {
			Inventory.items.Clear();
		}

        // kasowanie listy zadan

		if(Tasks.tasksList.Count > 0){
			Tasks.tasksList.Clear();
		}

        // zmienne zadan ktore sie nie zapisuja

		Tasks.hallunsTimer = 0;
		Tasks.isThornsAcid = false;
		Tasks.isThorns = false;

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
        Kom.isStaminaPotNotification = false;
        Kom.isHealthPotNotification = false;
        Kom.isBadgeNotification = false;
        Kom.isPhotoNotification = false;
        Kom.isTipNotification = false;
        Kom.isTutorialNotification = false;

        Kom.mainNotificationTextMesh.text = "";
        Kom.infoNotificationTextMesh.text = "";
        Kom.doorNotificationTextMesh.text = "";
        Kom.collectibleNotificationTextMesh.text = "";
        Kom.secretPlacesNotificationTextMesh.text = "";
        Kom.taskHintTextMesh.text = "";
        Kom.taskHintBackground.enabled = false;

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

        // zdrowie

        ZdrowieGracza.health = 100;
		ZdrowieGracza.isStartCount = false;
		ZdrowieGracza.isDead = false;
		ZdrowieGracza.isPlayerInjured = false;
		ZdrowieGracza.isPass = false;
		ZdrowieGracza.isGameLoaded = false;
		ZdrowieGracza.counter = 0;
		ZdrowieGracza.noisesScreenScript.enabled = false;
		ZdrowieGracza.playerInjuredCanvas.enabled = false;
		ZdrowieGracza.playerDamageCanvas1.enabled = false;
		ZdrowieGracza.playerDamageCanvas2.enabled = false;
		ZdrowieGracza.playerDamageCanvas3.enabled = false;
		ZdrowieGracza.deadScreenScript.enabled = false;

        // Jumpscary

		Jumpscare.counter1 = 0;
		Jumpscare.abandonedMonsterTime = 0;
		Jumpscare.isPlayerSave = false;

        // zadanie ksiazki

		ZadKsiazki.isComputerBook = false;
		ZadKsiazki.isSpaceBook = false;
		ZadKsiazki.isButterflyBook = false;
		ZadKsiazki.isSkyBook = false;
		ZadKsiazki.isWaterBook = false;
		ZadKsiazki.isBookTaken = false;
		ZadKsiazki.isTaskDone = false;

		if (ZadKsiazki.booksList.Count > 0) {
			ZadKsiazki.booksList.Clear ();
		}

        // zadanie mieso

		ZadMieso.isDragMeat1 = false;
		ZadMieso.isDragMeat2 = false;
		ZadMieso.isDragMeat3 = false;
		ZadMieso.meat1Condition = 100;
		ZadMieso.meat2Condition = 100;
		ZadMieso.meat3Condition = 100;

        // muzyka

		Music.randomMusicDuration = 0;
		Music.isMusicOff = false;

		Music.isGardenMonsterMusic = false;
		Music.isGardenMonsterMusic_On = false;
		Music.isWorkshopMonsterMusic = false;
		Music.isWorkshopMonsterMusic_On = false;
		Music.isLeftBrookMonsterMusic = false;
		Music.isLeftBrookMonsterMusic_On = false;
		Music.isCorridorMonsterMusic = false;
		Music.isCorridorMonsterMusic_On = false;
		Music.isCornfieldMonsterMusic = false;
		Music.isCornfieldMonsterMusic_On = false;
		Music.isPumpkinMonsterMusic = false;
		Music.isPumpkinMonsterMusic_On = false;
		Music.isAbandonedMonsterMusic = false;
		Music.isAbandonedMonsterMusic_On = false;
		Music.isMeatMonsterMusic = false;
		Music.isMeatMonsterMusic_On = false;
		Music.isPlantMonsterMusic = false;
		Music.isStevenMonsterMusic = false;

        // glos bohatera

        BohaterGlos.isGameBegin = false;

		BohaterGlos.isStartRetro = false;
		BohaterGlos.isMidRetro = false;
		BohaterGlos.isEndRetro = false;
		BohaterGlos.isResetRetro = false;

		BohaterGlos.isEndGame = false;
		BohaterGlos.isMonster = false;
		BohaterGlos.isDead = false;
		BohaterGlos.isWhisper = false;

        // zakonczenie gry

		KoniecGry.Muzyka_ok = false;
		KoniecGry.Gazeta1_ok = false;
		KoniecGry.Gazeta2_ok = false;
		KoniecGry.Przejscie1_ok = false;
		KoniecGry.Przejscie2_ok = false;
		KoniecGry.Credits_ok = false;
		KoniecGry.Licznik = 0;

        // wylaczanie canvas notatek

       for(int i=0; i < Notes.notesCanvas.Length; i++)
        {
            Notes.notesCanvas[i].enabled = false;
        }

        NotatkaEfekt.enabled = false;
        Notes.isNotes = false;
        Notes.isMenuNotes = false;
        Notes.noteTitleTextMesh.text = "";

        // wylaczanie canvas czarne okno siekiera

        CanvasCzynnoscSiekiera.enabled = false;

        // Usuwanie punktow zadan do kompasu

        Compass.RemoveTaskPoint(Compass.keyWoodPoint);
        Compass.RemoveTaskPoint(Compass.magicWellPoint);
        Compass.RemoveTaskPoint(Compass.gardenDoorPoint);
        Compass.RemoveTaskPoint(Compass.simonElementPoint);
        Compass.RemoveTaskPoint(Compass.workshopPoint);
        Compass.RemoveTaskPoint(Compass.brokenKeyPoint);
        Compass.RemoveTaskPoint(Compass.animalCementaryPoint);
        Compass.RemoveTaskPoint(Compass.cornfieldPoint);
        Compass.RemoveTaskPoint(Compass.axePoint);
        Compass.RemoveTaskPoint(Compass.wardrobeCorridorPoint);
        Compass.RemoveTaskPoint(Compass.cassete2Point);
        Compass.RemoveTaskPoint(Compass.goTrailPoint);
        Compass.RemoveTaskPoint(Compass.getToPoint);
        Compass.RemoveTaskPoint(Compass.tomCampPoint);
        Compass.RemoveTaskPoint(Compass.ravibePoint);
        Compass.RemoveTaskPoint(Compass.stevenMeatPoint);
        Compass.RemoveTaskPoint(Compass.stevenMushroomPoint);
        Compass.RemoveTaskPoint(Compass.stevenPlantPoint);
        Compass.RemoveTaskPoint(Compass.stevenSkullPoint);
        Compass.RemoveTaskPoint(Compass.stevenShedPoint);
        Compass.RemoveTaskPoint(Compass.stevenBrookPoint);
        Compass.RemoveTaskPoint(Compass.hutPoint);
        Compass.RemoveTaskPoint(Compass.devilsBrookPoint);
        Compass.RemoveTaskPoint(Compass.grandmaHousePoint);
        Compass.RemoveTaskPoint(Compass.aliceHousePoint);
        Compass.RemoveTaskPoint(Compass.tomHousePoint);
        Compass.RemoveTaskPoint(Compass.abandonedHousePoint);
        Compass.RemoveTaskPoint(Compass.stevenHousePoint);
        Compass.RemoveTaskPoint(Compass.scientistHousePoint);

        Compass.RemoveTaskPoint(Compass.edwardCupboardPoint);
        Compass.RemoveTaskPoint(Compass.bonesShedPoint);
        Compass.RemoveTaskPoint(Compass.boneStablePoint);
        Compass.RemoveTaskPoint(Compass.toolShedPoint);
        Compass.RemoveTaskPoint(Compass.keyToiletPoint);
        Compass.RemoveTaskPoint(Compass.secretRoomPoint);

        Compass.AddTaskPoint(Compass.grandmaHousePoint);

        // wartosci poczatkowe dla skrypow na scenie glownej

        if (SceneManager.GetActiveScene ().name == "ScenaGlowna") {

            // Zerowanie dzwiekow muzyki

            Music.backgroundAudioSource1.clip = null;
			Music.backgroundAudioSource2.clip = null;
			Music.backgroundAudioSource3.clip = null;
			Music.monsterBackgroundAudioSource1.clip = null;
			Music.monsterBackgroundAudioSource2.clip = null;
			Music.backgroundAudioSource1.loop = false;
			Music.backgroundAudioSource2.loop = false;
			Music.backgroundAudioSource3.loop = false;

            // Zerowanie dzwiekow gracz

            Postac.audioSource.clip = null;

            // Zerowanie dzwiekow jumpscare

            Jumpscare.corridorMonsterAudioSource.clip = null;
            Jumpscare.channelMonsterAudioSource.clip = null;
            Jumpscare.paulDownstairsMonsterAudioSource.clip = null;
            Jumpscare.stevenShedMonster2_AudioSource.clip = null;
            Jumpscare.breathAudioSource.clip = null;
            Jumpscare.paulRoomMonsterAudioSource.clip = null;
            Jumpscare.plantMonsterAudioSource.clip = null;
            Jumpscare.abandonedMonsterAudioSource.clip = null;
            Jumpscare.shedMonster1_AudioSource.clip = null;
            Jumpscare.beginMonsterAudioSource.clip = null;
            Jumpscare.stableMonsterAudioSource.clip = null;
            Jumpscare.beginWolfAudioSource.clip = null;
            Jumpscare.spider4_AudioSource.clip = null;
            Jumpscare.spider4_JumpscareAudioSource.clip = null;

            // zerowanie dzwiekow zadan

            Tasks.audioSource.clip = null;
            Tasks.audioSource2.clip = null;
            Tasks.audioSource3.clip = null;
            Tasks.audioSource4.clip = null;
            Tasks.pumpkinKeyAudioSource.clip = null;
            Tasks.labAudioSource.clip = null;
            Tasks.flameAudioSource.clip = null;
            Tasks.fireAudioSource.clip = null;
            Tasks.cassete1_AudioSource.clip = null;
            Tasks.cassete3_AudioSource.clip = null;
            Tasks.cassete4_AudioSource.clip = null;
            Tasks.cassete5_AudioSource.clip = null;

            // zerowanie dzwiekow screamow

            Straszak.thornsAudioSource.clip = null; 
            Straszak.woodAudioSource.clip = null; 
            Straszak.woodShedAudioSource.clip = null; 
            Straszak.openDoorAudioSource.clip = null; 
            Straszak.closeDoorAudioSource.clip = null; 
            Straszak.doorBellAudioSource.clip = null; 
            Straszak.ZrodloDzwGlowa.clip = null; 
            Straszak.playerAudioSource.clip = null; 
            Straszak.kitchenLampAudioSource.clip = null; 
            Straszak.foodAudioSource.clip = null; 
            Straszak.atmosphereAudioSource.clip = null; 
            Straszak.bonesAudioSource.clip = null; 
            Straszak.stepsAudioSource.clip = null; 
            Straszak.ravenAudioSource.clip = null; 
            Straszak.girlScreamAudioSource.clip = null; 
            Straszak.stevenScreamAudioSource.clip = null; 
            Straszak.chainsAudioSource.clip = null; 
            Straszak.toolsAudioSource.clip = null; 
            Straszak.factoryAudioSource.clip = null; 
            Straszak.factory2AudioSource.clip = null; 
            Straszak.dogAudioSource.clip = null; 
            Straszak.brookAudioSource.clip = null; 
            Straszak.musicBoxAudioSource.clip = null; 
            Straszak.knockAudioSource.clip = null; 
            Straszak.radioAudioSource.clip = DzwRadio; 
            Straszak.radioAudioSource.loop = true; 
            Straszak.radioAudioSource.Play(); 
            Straszak.radioChoirAudioSource.clip = DzwRadioChor; 
            Straszak.radioChoirAudioSource.Play(); 
            Straszak.headAudioSource.clip = null; 
            Straszak.hayAudioSource.clip = null; 
            Straszak.woodAudioSource.clip = null; 
            Straszak.starsCreakAudioSource.clip = null; 
            Straszak.paulStairsCreakAudioSource.clip = null; 
            Straszak.paulCreakAudioSource.clip = null; 
            Straszak.girlLaughAudioSource.clip = null; 
            Straszak.wellScreamAudioSource.clip = null; 
            Straszak.wellWaterAudioSource.clip = null; 
            Straszak.ratAudioSource.clip = null; 
            Straszak.rustleAudioSource.clip = null; 
            Straszak.rustle2AudioSource.clip = null; 
            Straszak.whisperAudioSource.clip = null; 
            Straszak.whisper2AudioSource.clip = null; 
            Straszak.whispersAudioSource.clip = null; 
            Straszak.whispersAudioSource.clip = null; 
            Straszak.glassAudioSource.clip = null; 
            Straszak.phoneAudioSource.clip = null; 
            Straszak.hitAudioSource.clip = null; 
            Straszak.windAudioSource.clip = null; 
            Straszak.windEffectAudioSource.clip = null; 
            Straszak.wolfAudioSource.clip = null; 
            Straszak.meanLaughAudioSource.clip = null; 
            Straszak.clockAudioSource.clip = null; 
            Straszak.dogRoarDzwRykPsa.clip = null; 
            Straszak.breathBoneShedAudioSource.clip = null; 
            Straszak.smallShedBulbAudioSource.clip = null; 
            Straszak.woodBirdAudioSource.clip = null; 
            Straszak.ganjaLeavesAudioSource.clip = null; 
            Straszak.shedFurnitureAudioSource.clip = null; 
            Straszak.brookScreeamAudioSource.clip = null; 
            Straszak.grandmaGlassAudioSource.clip = null; 
            Straszak.glassKnockAudioSource.clip = null;
            Straszak.aliceShedAudioSource.clip = null;
            Straszak.hutLightAudioSource.clip = null;
            Straszak.floorCreakAudioSource.clip = null;
            Straszak.scaryOwlAudioSource.clip = null;
            Straszak.scaryOwl2AudioSource.clip = null;
            Straszak.waterSplashAudioSource.clip = null;
            Straszak.foxScreamAudioSource.clip = null;
            Straszak.shockScreamAudioSource.clip = null;
            Straszak.suffocateAudioSource.clip = null;
            Straszak.fallTreeAudioSource.clip = null;

            // zerowanie dzwiekow komunikaty

            Kom.audioSource.clip = null;
            Kom.audioSource2.clip = null;
            Kom.tutorialAudioSource.clip = null;
            Kom.audioSource4.clip = null;

            // zerowanie dzwiekow ambona i fabryka

            ZadAmbona.audioSource.clip = null;
            ZadFabryka.leverAudioSource.clip = null;
            ZadFabryka.grillesAudioSource.clip = null;

            // zerowanie dzwiekow zdrowie 

			ZdrowieGracza.audioSource2.loop = false;
			ZdrowieGracza.audioSource2.Stop ();

            // zerowanie dzwiekow straszak scarecrow

            ScarecrowStraszak.ZrodloDzwJumpscare.clip = null;
            ScarecrowStraszak.ZrodloDzwMonsterStajnia.clip = null;
            ScarecrowStraszak.ZrodloDzwMonsterSzalas.clip = null;
            ScarecrowStraszak.ZrodloDzwMonsterSzalas2.clip = null;

            // zadanie przycisk

            ZadPrzycisk.isButton = false;
			//ZadPrzycisk.enabled = false;

            // zadanie ambona

			ZadAmbona.counter = 0;
			ZadAmbona.isHit = false;
			ZadAmbona.upperBox1.gameObject.GetComponent<Rigidbody>().mass = 700f;
			ZadAmbona.upperBox2.gameObject.GetComponent<Rigidbody>().mass = 700f;
			ZadAmbona.enabled = false;

            // zadanie fabryka

			ZadFabryka.isLever = false;
			ZadFabryka.isHasEnergy = false;
			ZadFabryka.isNotification = false;
			ZadFabryka.grilles.gameObject.SetActive (true);
            SwiatloEnergii.color = Color.red;
            ZadFabryka.grillesAnimator.SetTrigger ("BramaReset");
			ZadFabryka.enabled = false;

            // zadanie kolo

			ZadKolo.counter = 0;
			ZadKolo.isFullCounter = false;
			ZadKolo.isHalfCounter = false;
			//ZadKolo.Kolo.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			ZadKolo.woodenWheel.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			//ZadKolo.Kolo.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX;
			//ZadKolo.Kolo.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationZ;
			ZadKolo.woodenWheel.GetComponent<SphereCollider>().enabled = true;
			ZadKolo.enabled = false;

            // zadanie kosci

			ZadKosci.bonesCount = 0;
			ZadKosci.isBone1 = false;
			ZadKosci.isBone2 = false;
			ZadKosci.isBone3 = false;
			ZadKosci.isBone4 = false;
			ZadKosci.isBone5 = false;
			ZadKosci.isGrille = false;
			ZadKosci.lampLight.color = SwiatloKosci;
			ZadKosci.grille.transform.position = new Vector3(ZadKosci.grille.transform.position.x, 39.09906f, ZadKosci.grille.transform.position.z);
			ZadKosci.enabled = false;

            // zadanie studnia

			ZadStudnia.stonesCount = 0;
			ZadStudnia.isStone1 = false;
			ZadStudnia.isStone2 = false;
			ZadStudnia.isStone3 = false;
			ZadStudnia.isStone4 = false;
			ZadStudnia.isStone5 = false;
            ZadStudnia.stone1.GetComponent<Collider>().enabled = true;
            ZadStudnia.stone2.GetComponent<Collider>().enabled = true;
            ZadStudnia.stone3.GetComponent<Collider>().enabled = true;
            ZadStudnia.stone4.GetComponent<Collider>().enabled = true;
            ZadStudnia.stone5.GetComponent<Collider>().enabled = true;
            ZadStudnia.bucket.transform.position = new Vector3(ZadStudnia.bucket.transform.position.x, 39.114f, ZadStudnia.bucket.transform.position.z);
			ZadStudnia.key.transform.position = new Vector3(ZadStudnia.key.transform.position.x, 39.86f, ZadStudnia.key.transform.position.z); // wczesniej 39.73f
			ZadStudnia.key.GetComponent<Collider> ().enabled = false;
			ZadStudnia.enabled = false;

            // haluny

            ObrazMarysia1.enabled = false;
            ObrazMarysia2.enabled = false;
            ObrazMarysia3.enabled = false;
            ObrazMarysia4.enabled = false;
            ObrazMarysia5.enabled = false;
            Halucynacje.isStartCount = false;
            Halucynacje.counter = 0;

            // obraz kapturek

            ObrazKapturek.transform.localPosition = new Vector3(1162.258f, 57.132f, 3057.478f);
            ObrazKapturek.transform.localRotation = Quaternion.Euler(0, -7.053f, 0);

            if (ObrazKapturek.gameObject.GetComponent<Rigidbody>()){
                Destroy(ObrazKapturek.gameObject.GetComponent<Rigidbody>());
            }

            // domyslna animacja yound dead warsztat i drzewo fall

            AnimatorYoungDead.SetTrigger("ShockIdle");
            AnimatorDrzewoFall.SetTrigger("DrzewoIdle");

            // Wylaczanie kurzu drzewo fall;

            KurzDrzewoFall.SetActive(false);


        }



	}

}
