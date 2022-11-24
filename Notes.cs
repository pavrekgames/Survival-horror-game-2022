using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using TMPro;

public class Notes : MonoBehaviour {

    public bool isPlaySound = false; // wznawianie i zatrzymywanie dzwiekow

    public AudioSource audioSource;
    public AudioSource hoverAudioSource;
    private AudioSource audioSource4;
    public AudioClip notesSound;
    public AudioClip hoverNoteSound;
	public bool isNotes = false;
	public bool isMenuNotes = false;
	public Transform[] notes;
	public Canvas[] notesCanvas;
	public Canvas[] notesCanvas2;
	public Canvas defaultNoteCanvas;
	public Button[] notesIcons;
	private Blur blurScript;
	private Menu gameMenuScript;
	private Inventory inventoryScript;
    //private Jezyk Language;
	private CrosshairGUI cursorScript;
	private Player playerScript;
	public Sprite noteIcon1;
	public Sprite noteIcon2;
	public Sprite noteIcon3;
	public Sprite noteIcon4;
	public Sprite noteIcon5;
	public Sprite noteIcon6;
	public Sprite noteIcon7;
	public Sprite noteIcon8;
	public Sprite noteDefaultIcon;
	public TextMeshProUGUI noteTitleTextMesh;
    public int notesCount = 0;

	private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;

	public bool isNote1 = false;
	public bool isNote2 = false;
	public bool isNote3 = false;
	public bool isNote4 = false;
	public bool isNote5 = false;
	public bool isNote6 = false;
	public bool isNote7 = false;
	public bool isNote8 = false;
	public bool isNote9 = false;
	public bool isNote10 = false;
	public bool isNote11 = false;
	public bool isNote12 = false;
	public bool isNote13 = false;
	public bool isNote14 = false;
	public bool isNote15 = false;
	public bool isNote16 = false;
	public bool isNote17 = false;
	public bool isNote18 = false;
	public bool isNote19 = false;
	public bool isNote20 = false;
	public bool isNote21 = false;
	public bool isNote22 = false;
	public bool isNote23 = false;
	public bool isNote24 = false;
	public bool isNote25 = false;
	public bool isNote26 = false;
	public bool isNote27 = false;
	public bool isNote28 = false;
	public bool isNote29 = false;
	public bool isNote30 = false;
	public bool isNote31 = false;
	public bool isNote32 = false;
	public bool isNote33 = false;
	public bool isNote34 = false;
	public bool isNote35 = false;
	public bool isNote36 = false;
	public bool isNote37 = false;
	public bool isNote38 = false;
	public bool isNote39 = false;
	public bool isNote40 = false;
	public bool isNote41 = false;
	public bool isNote42 = false;
	public bool isNote43 = false;
	public bool isNote44 = false;
	public bool isNote45 = false;
	public bool isNote46 = false;
	public bool isNote47 = false;
	public bool isNote48 = false;
	public bool isNote49 = false;
	public bool isNote50 = false;
	public bool isNote51 = false;
	public bool isNote52 = false;
	public bool isNote53 = false;
	public bool isNote54 = false;
	public bool isFoxNote = false;
	public bool isWoodPhoto = false;
	public bool isZenoPhoto = false;
	public bool isShoppingNote = false;
	public bool isQuote1Note = false;
	public bool isCornfieldPicture = false;
	public bool isLeftBrookNote = false;
	public bool isMushroomNote = false;
	public bool isBrookPhoto3 = false;
	public bool isBrookPhoto2 = false;
	public bool isBrookPhoto1 = false;
	public bool isSimonPicture = false;
	public bool isRapNote = false;
	public bool isTowerPhoto = false;
	public bool isWellPhoto = false;
	public bool isQuote2Note = false;
	public bool isMonumentPhoto = false;
	public bool isInventionNote = false;
	public bool isWorkshopPhoto = false;
	public bool isDarkForestNote = false;
	public bool isAnimalsNote = false;
	public bool isNightNote = false;
	public bool isWardrobePhoto = false;
	public bool isShedPhoto = false;
	public bool isCampPhoto = false;
	public bool isMaryNote = false;
	public bool isDaughterPicture = false;
	public bool isDiplomaNote = false;
	public bool isTomPicture = false;
	public bool isQuote3Note = false;
	public bool isMonsterPicture = false;
	public bool iswhisperNote = false;
	public bool isQuote4Note = false;
	public bool isPlantPicture = false;
	public bool isFieldNote = false;
	public bool isArenaNote = false;
	public bool isQuote5Note = false;
	public bool isBrookPhoto4 = false;
	public bool isAliensNote = false;
	public bool isQuote6Note = false;

    // notatki tytul
	private TextMeshProUGUI noteTitleTextMesh1;
	private TextMeshProUGUI noteTitleTextMesh2;
	private TextMeshProUGUI noteTitleTextMesh3;
	private TextMeshProUGUI noteTitleTextMesh4;
	private TextMeshProUGUI noteTitleTextMesh5;
	private TextMeshProUGUI noteTitleTextMesh6;
	private TextMeshProUGUI noteTitleTextMesh7;
	private TextMeshProUGUI noteTitleTextMesh8;
	private TextMeshProUGUI noteTitleTextMesh9;
	private TextMeshProUGUI noteTitleTextMesh10;
	private TextMeshProUGUI noteTitleTextMesh11;
	private TextMeshProUGUI noteTitleTextMesh12;
	private TextMeshProUGUI noteTitleTextMesh13;
	private TextMeshProUGUI noteTitleTextMesh14;
	private TextMeshProUGUI noteTitleTextMesh15;
	private TextMeshProUGUI noteTitleTextMesh16;
	private TextMeshProUGUI noteTitleTextMesh17;
	private TextMeshProUGUI noteTitleTextMesh18;
	private TextMeshProUGUI noteTitleTextMesh19;
	private TextMeshProUGUI noteTitleTextMesh20;
	private TextMeshProUGUI noteTitleTextMesh21;
	private TextMeshProUGUI noteTitleTextMesh22;
	private TextMeshProUGUI noteTitleTextMesh23;
	private TextMeshProUGUI noteTitleTextMesh24;
	private TextMeshProUGUI noteTitleTextMesh25;
	private TextMeshProUGUI noteTitleTextMesh26;
	private TextMeshProUGUI noteTitleTextMesh27;
	private TextMeshProUGUI noteTitleTextMesh28;
	private TextMeshProUGUI noteTitleTextMesh29;
	private TextMeshProUGUI noteTitleTextMesh30;
	private TextMeshProUGUI noteTitleTextMesh31;
	private TextMeshProUGUI noteTitleTextMesh32;
	private TextMeshProUGUI noteTitleTextMesh33;
	private TextMeshProUGUI noteTitleTextMesh34;
	private TextMeshProUGUI noteTitleTextMesh35;
	private TextMeshProUGUI noteTitleTextMesh36;
	private TextMeshProUGUI noteTitleTextMesh37;
	private TextMeshProUGUI noteTitleTextMesh38;
	private TextMeshProUGUI noteTitleTextMesh39;
	private TextMeshProUGUI noteTitleTextMesh40;
	private TextMeshProUGUI noteTitleTextMesh41;
	private TextMeshProUGUI noteTitleTextMesh42;
	private TextMeshProUGUI noteTitleTextMesh43;
	private TextMeshProUGUI noteTitleTextMesh44;
	private TextMeshProUGUI noteTitleTextMesh45;
	private TextMeshProUGUI noteTitleTextMesh46;
	private TextMeshProUGUI noteTitleTextMesh47;
	private TextMeshProUGUI noteTitleTextMesh48;
	private TextMeshProUGUI noteTitleTextMesh49;
	private TextMeshProUGUI noteTitleTextMesh50;
	private TextMeshProUGUI noteTitleTextMesh51;
	private TextMeshProUGUI noteTitleTextMesh52;
	private TextMeshProUGUI noteTitleTextMesh53;
	private TextMeshProUGUI noteTitleTextMesh54;

    // Do podpisania kontraktu demona

    public AudioClip demonSound;
    private Transform player;
    private Health healthScript;
    private Tasks tasksScript;
    public Transform wolf;
    public int randomPunishmentIndex = 0;
    public bool isDemonNote = false;
  

	void OnEnable(){

		playerCam = Camera.main;

        hoverAudioSource = GameObject.Find("ZrodloPrzedmiot3_s").GetComponent<AudioSource>();
        audioSource4 = GameObject.Find("ZrodloPrzedmiot4_s").GetComponent<AudioSource>();    // ciche

        notes = new Transform[95];
		notes [0] = GameObject.Find ("Notatka_v1_1").transform;
		notes [1] = GameObject.Find ("Notatka_v1_2").transform;
		notes [2] = GameObject.Find ("Notatka_v1_3").transform;
		notes [3] = GameObject.Find ("Notatka_v1_4").transform;
		notes [4] = GameObject.Find ("Notatka_v1_5").transform;
		notes [5] = GameObject.Find ("Notatka_v1_6").transform;
		notes [6] = GameObject.Find ("Notatka_v1_7").transform;
		notes [7] = GameObject.Find ("Notatka_v1_8").transform;
		notes [8] = GameObject.Find ("Notatka_v1_9").transform;
		notes [9] = GameObject.Find ("Notatka_v1_10").transform;
		notes [10] = GameObject.Find ("Notatka_v1_11").transform;
		notes [11] = GameObject.Find ("Notatka_v1_12").transform;
		notes [12] = GameObject.Find ("Notatka_v1_13").transform;
		notes [13] = GameObject.Find ("Notatka_v1_14").transform;
		notes [14] = GameObject.Find ("Notatka_v1_15").transform;
		notes [15] = GameObject.Find ("Notatka_v1_16").transform;
		notes [16] = GameObject.Find ("Notatka_v1_17").transform;
		notes [17] = GameObject.Find ("Notatka_v1_18").transform;
		notes [18] = GameObject.Find ("Notatka_v1_19").transform;
		notes [19] = GameObject.Find ("Notatka_v1_20").transform;
		notes [20] = GameObject.Find ("Notatka_v1_21").transform;
		notes [21] = GameObject.Find ("Notatka_v1_22").transform;
		notes [22] = GameObject.Find ("Notatka_v1_23").transform;
		notes [23] = GameObject.Find ("Notatka_v1_24").transform;
		notes [24] = GameObject.Find ("Notatka_v1_25").transform;
		notes [25] = GameObject.Find ("Notatka_v1_26").transform;
		notes [26] = GameObject.Find ("Notatka_v1_27").transform;
		notes [27] = GameObject.Find ("Notatka_v1_28").transform;
		notes [28] = GameObject.Find ("Notatka_v1_29").transform;
		notes [29] = GameObject.Find ("Notatka_v1_30").transform;
		notes [30] = GameObject.Find ("Notatka_v1_31").transform;
		notes [31] = GameObject.Find ("Notatka_v1_32").transform;
		notes [32] = GameObject.Find ("Notatka_v1_33").transform;
		notes [33] = GameObject.Find ("Notatka_v1_34").transform;
		notes [34] = GameObject.Find ("Notatka_v1_35").transform;
		notes [35] = GameObject.Find ("Notatka_v1_36").transform;
		notes [36] = GameObject.Find ("Notatka_v1_37").transform;
		notes [37] = GameObject.Find ("Notatka_v1_38").transform;
		notes [38] = GameObject.Find ("Notatka_v1_39").transform;
		notes [39] = GameObject.Find ("Notatka_v1_40").transform;
		notes [40] = GameObject.Find ("Notatka_v1_41").transform;
		notes [41] = GameObject.Find ("Notatka_v1_42").transform;
		notes [42] = GameObject.Find ("Notatka_v1_43").transform;
		notes [43] = GameObject.Find ("Notatka_v1_44").transform;
		notes [44] = GameObject.Find ("Notatka_v1_45").transform;
		notes [45] = GameObject.Find ("Notatka_v1_46").transform;
		notes [46] = GameObject.Find ("Notatka_v1_47").transform;
		notes [47] = GameObject.Find ("Notatka_v1_48").transform;
		notes [48] = GameObject.Find ("Notatka_v1_49").transform;
		notes [49] = GameObject.Find ("Notatka_v1_50").transform;
		notes [50] = GameObject.Find ("Notatka_v1_51").transform;
		notes [51] = GameObject.Find ("Notatka_v1_52").transform;
		notes [52] = GameObject.Find ("Notatka_v1_53").transform;
		notes [53] = GameObject.Find ("Notatka_v1_54").transform;
		notes [54] = GameObject.Find ("Notatka_v2Lisy").transform;
		notes [55] = GameObject.Find ("ZdjecieDrewno").transform;
		notes [56] = GameObject.Find ("ZdjecieZeno").transform;
		notes [57] = GameObject.Find ("NotatkaZakupy").transform;
		notes [58] = GameObject.Find ("NotatkaCytat1").transform;
		notes [59] = GameObject.Find ("RysunekKukurydza").transform;
		notes [60] = GameObject.Find ("NotatkaPotokLewy").transform;
		notes [61] = GameObject.Find ("NotatkaGrzyby").transform;
		notes [62] = GameObject.Find ("ZdjeciePotok3").transform;
		notes [63] = GameObject.Find ("ZdjeciePotok2").transform;
		notes [64] = GameObject.Find ("ZdjeciePotok1").transform;
		notes [65] = GameObject.Find ("RysunekSimon").transform;
		notes [66] = GameObject.Find ("NotatkaRap").transform;
		notes [67] = GameObject.Find ("ZdjecieAmbona").transform;
		notes [68] = GameObject.Find ("ZdjecieStudnia").transform;
		notes [69] = GameObject.Find ("NotatkaCytat2").transform;
		notes [70] = GameObject.Find ("ZdjeciePomnik").transform;
		notes [71] = GameObject.Find ("NotatkaWynalazki").transform;
		notes [72] = GameObject.Find ("ZdjecieWarsztat").transform;
		notes [73] = GameObject.Find ("NotatkaCiemny").transform;
		notes [74] = GameObject.Find ("NotatkaZwierzeta").transform;
		notes [75] = GameObject.Find ("NotatkaNoc").transform;
		notes [76] = GameObject.Find ("ZdjecieSzafa").transform;
		notes [77] = GameObject.Find ("ZdjecieSzopa").transform;
		notes [78] = GameObject.Find ("ZdjecieOboz").transform;
		notes [79] = GameObject.Find ("NotatkaMary").transform;
		notes [80] = GameObject.Find ("RysunekCorki").transform;
		notes [81] = GameObject.Find ("NotatkaDyplom").transform;
		notes [82] = GameObject.Find ("RysunekTom").transform;
		notes [83] = GameObject.Find ("NotatkaCytat3").transform;
		notes [84] = GameObject.Find ("RysunekPotwor").transform;
		notes [85] = GameObject.Find ("NotatkaSzepty").transform;
		notes [86] = GameObject.Find ("NotatkaCytat4").transform;
		notes [87] = GameObject.Find ("RysunekRosliny").transform;
		notes [88] = GameObject.Find ("NotatkaPole").transform;
		notes [89] = GameObject.Find ("NotatkaArena").transform;
		notes [90] = GameObject.Find ("NotatkaCytat5").transform;
		notes [91] = GameObject.Find ("ZdjeciePotok4").transform;
		notes [92] = GameObject.Find ("NotatkaKosmici").transform;
		notes [93] = GameObject.Find ("NotatkaCytat6").transform;
		notes [94] = GameObject.Find ("NotatkaDemona").transform;

		notesCanvas = new Canvas[95];
		notesCanvas [0] = GameObject.Find ("CanvasNotatka1").GetComponent<Canvas> ();
		notesCanvas [1] = GameObject.Find ("CanvasNotatka2").GetComponent<Canvas> ();
		notesCanvas [2] = GameObject.Find ("CanvasNotatka3").GetComponent<Canvas> ();
		notesCanvas [3] = GameObject.Find ("CanvasNotatka4").GetComponent<Canvas> ();
		notesCanvas [4] = GameObject.Find ("CanvasNotatka5").GetComponent<Canvas> ();
		notesCanvas [5] = GameObject.Find ("CanvasNotatka6").GetComponent<Canvas> ();
		notesCanvas [6] = GameObject.Find ("CanvasNotatka7").GetComponent<Canvas> ();
		notesCanvas [7] = GameObject.Find ("CanvasNotatka8").GetComponent<Canvas> ();
		notesCanvas [8] = GameObject.Find ("CanvasNotatka9").GetComponent<Canvas> ();
		notesCanvas [9] = GameObject.Find ("CanvasNotatka10").GetComponent<Canvas> ();
		notesCanvas [10] = GameObject.Find ("CanvasNotatka11").GetComponent<Canvas> ();
		notesCanvas [11] = GameObject.Find ("CanvasNotatka12").GetComponent<Canvas> ();
		notesCanvas [12] = GameObject.Find ("CanvasNotatka13").GetComponent<Canvas> ();
		notesCanvas [13] = GameObject.Find ("CanvasNotatka14").GetComponent<Canvas> ();
		notesCanvas [14] = GameObject.Find ("CanvasNotatka15").GetComponent<Canvas> ();
		notesCanvas [15] = GameObject.Find ("CanvasNotatka16").GetComponent<Canvas> ();
		notesCanvas [16] = GameObject.Find ("CanvasNotatka17").GetComponent<Canvas> ();
		notesCanvas [17] = GameObject.Find ("CanvasNotatka18").GetComponent<Canvas> ();
		notesCanvas [18] = GameObject.Find ("CanvasNotatka19").GetComponent<Canvas> ();
		notesCanvas [19] = GameObject.Find ("CanvasNotatka20").GetComponent<Canvas> ();
		notesCanvas [20] = GameObject.Find ("CanvasNotatka21").GetComponent<Canvas> ();
		notesCanvas [21] = GameObject.Find ("CanvasNotatka22").GetComponent<Canvas> ();
		notesCanvas [22] = GameObject.Find ("CanvasNotatka23").GetComponent<Canvas> ();
		notesCanvas [23] = GameObject.Find ("CanvasNotatka24").GetComponent<Canvas> ();
		notesCanvas [24] = GameObject.Find ("CanvasNotatka25").GetComponent<Canvas> ();
		notesCanvas [25] = GameObject.Find ("CanvasNotatka26").GetComponent<Canvas> ();
		notesCanvas [26] = GameObject.Find ("CanvasNotatka27").GetComponent<Canvas> ();
		notesCanvas [27] = GameObject.Find ("CanvasNotatka28").GetComponent<Canvas> ();
		notesCanvas [28] = GameObject.Find ("CanvasNotatka29").GetComponent<Canvas> ();
		notesCanvas [29] = GameObject.Find ("CanvasNotatka30").GetComponent<Canvas> ();
		notesCanvas [30] = GameObject.Find ("CanvasNotatka31").GetComponent<Canvas> ();
		notesCanvas [31] = GameObject.Find ("CanvasNotatka32").GetComponent<Canvas> ();
		notesCanvas [32] = GameObject.Find ("CanvasNotatka33").GetComponent<Canvas> ();
		notesCanvas [33] = GameObject.Find ("CanvasNotatka34").GetComponent<Canvas> ();
		notesCanvas [34] = GameObject.Find ("CanvasNotatka35").GetComponent<Canvas> ();
		notesCanvas [35] = GameObject.Find ("CanvasNotatka36").GetComponent<Canvas> ();
		notesCanvas [36] = GameObject.Find ("CanvasNotatka37").GetComponent<Canvas> ();
		notesCanvas [37] = GameObject.Find ("CanvasNotatka38").GetComponent<Canvas> ();
		notesCanvas [38] = GameObject.Find ("CanvasNotatka39").GetComponent<Canvas> ();
		notesCanvas [39] = GameObject.Find ("CanvasNotatka40").GetComponent<Canvas> ();
		notesCanvas [40] = GameObject.Find ("CanvasNotatka41").GetComponent<Canvas> ();
		notesCanvas [41] = GameObject.Find ("CanvasNotatka42").GetComponent<Canvas> ();
		notesCanvas [42] = GameObject.Find ("CanvasNotatka43").GetComponent<Canvas> ();
		notesCanvas [43] = GameObject.Find ("CanvasNotatka44").GetComponent<Canvas> ();
		notesCanvas [44] = GameObject.Find ("CanvasNotatka45").GetComponent<Canvas> ();
		notesCanvas [45] = GameObject.Find ("CanvasNotatka46").GetComponent<Canvas> ();
		notesCanvas [46] = GameObject.Find ("CanvasNotatka47").GetComponent<Canvas> ();
		notesCanvas [47] = GameObject.Find ("CanvasNotatka48").GetComponent<Canvas> ();
		notesCanvas [48] = GameObject.Find ("CanvasNotatka49").GetComponent<Canvas> ();
		notesCanvas [49] = GameObject.Find ("CanvasNotatka50").GetComponent<Canvas> ();
		notesCanvas [50] = GameObject.Find ("CanvasNotatka51").GetComponent<Canvas> ();
		notesCanvas [51] = GameObject.Find ("CanvasNotatka52").GetComponent<Canvas> ();
		notesCanvas [52] = GameObject.Find ("CanvasNotatka53").GetComponent<Canvas> ();
		notesCanvas [53] = GameObject.Find ("CanvasNotatka54").GetComponent<Canvas> ();
		notesCanvas [54] = GameObject.Find ("CanvasNotatkaLisy").GetComponent<Canvas>();
		notesCanvas [55] = GameObject.Find ("CanvasZdjecieDrewno").GetComponent<Canvas>();
		notesCanvas [56] = GameObject.Find ("CanvasZdjecieZeno").GetComponent<Canvas>();
		notesCanvas [57] = GameObject.Find ("CanvasNotatkaZakupy").GetComponent<Canvas>();
		notesCanvas [58] = GameObject.Find ("CanvasNotatkaCytat1").GetComponent<Canvas>();
		notesCanvas [59] = GameObject.Find ("CanvasRysunekKukurydza").GetComponent<Canvas>();
		notesCanvas [60] = GameObject.Find ("CanvasNotatkaPotokLewy").GetComponent<Canvas>();
		notesCanvas [61] = GameObject.Find ("CanvasNotatkaGrzyby").GetComponent<Canvas>();
		notesCanvas [62] = GameObject.Find ("CanvasZdjeciePotok3").GetComponent<Canvas>();
		notesCanvas [63] = GameObject.Find ("CanvasZdjeciePotok2").GetComponent<Canvas>();
		notesCanvas [64] = GameObject.Find ("CanvasZdjeciePotok1").GetComponent<Canvas>();
		notesCanvas [65] = GameObject.Find ("CanvasRysunekSimon").GetComponent<Canvas>();
		notesCanvas [66] = GameObject.Find ("CanvasNotatkaRap").GetComponent<Canvas>();
		notesCanvas [67] = GameObject.Find ("CanvasZdjecieAmbona").GetComponent<Canvas>();
		notesCanvas [68] = GameObject.Find ("CanvasZdjecieStudnia").GetComponent<Canvas>();
		notesCanvas [69] = GameObject.Find ("CanvasNotatkaCytat2").GetComponent<Canvas>();
		notesCanvas [70] = GameObject.Find ("CanvasZdjeciePomnik").GetComponent<Canvas>();
		notesCanvas [71] = GameObject.Find ("CanvasNotatkaWynalazki").GetComponent<Canvas>();
		notesCanvas [72] = GameObject.Find ("CanvasZdjecieWarsztat").GetComponent<Canvas>();
		notesCanvas [73] = GameObject.Find ("CanvasNotatkaCiemny").GetComponent<Canvas>();
		notesCanvas [74] = GameObject.Find ("CanvasNotatkaZwierzeta").GetComponent<Canvas>();
		notesCanvas [75] = GameObject.Find ("CanvasNotatkaNoc").GetComponent<Canvas>();
		notesCanvas [76] = GameObject.Find ("CanvasZdjecieSzafa").GetComponent<Canvas>();
		notesCanvas [77] = GameObject.Find ("CanvasZdjecieSzopa").GetComponent<Canvas>();
		notesCanvas [78] = GameObject.Find ("CanvasZdjecieOboz").GetComponent<Canvas>();
		notesCanvas [79] = GameObject.Find ("CanvasNotatkaMary").GetComponent<Canvas>();
		notesCanvas [80] = GameObject.Find ("CanvasRysunekCorki").GetComponent<Canvas>();
		notesCanvas [81] = GameObject.Find ("CanvasNotatkaDyplom").GetComponent<Canvas>();
		notesCanvas [82] = GameObject.Find ("CanvasRysunekTom").GetComponent<Canvas>();
		notesCanvas [83] = GameObject.Find ("CanvasNotatkaCytat3").GetComponent<Canvas>();
		notesCanvas [84] = GameObject.Find ("CanvasRysunekPotwor").GetComponent<Canvas>();
		notesCanvas [85] = GameObject.Find ("CanvasNotatkaSzepty").GetComponent<Canvas>();
		notesCanvas [86] = GameObject.Find ("CanvasNotatkaCytat4").GetComponent<Canvas>();
		notesCanvas [87] = GameObject.Find ("CanvasRysunekRosliny").GetComponent<Canvas>();
		notesCanvas [88] = GameObject.Find ("CanvasNotatkaPole").GetComponent<Canvas>();
		notesCanvas [89] = GameObject.Find ("CanvasNotatkaArena").GetComponent<Canvas>();
		notesCanvas [90] = GameObject.Find ("CanvasNotatkaCytat5").GetComponent<Canvas>();
		notesCanvas [91] = GameObject.Find ("CanvasZdjeciePotok4").GetComponent<Canvas>();
		notesCanvas [92] = GameObject.Find ("CanvasNotatkaKosmici").GetComponent<Canvas>();
		notesCanvas [93] = GameObject.Find ("CanvasNotatkaCytat6").GetComponent<Canvas>();
		notesCanvas [94] = GameObject.Find ("CanvasNotatkaDemona").GetComponent<Canvas>();

		notesCanvas2 = new Canvas[54];
		notesCanvas2 [0] = GameObject.Find ("CanvasListaNotatek_1").GetComponent<Canvas> ();
		notesCanvas2 [1] = GameObject.Find ("CanvasListaNotatek_2").GetComponent<Canvas> ();
		notesCanvas2 [2] = GameObject.Find ("CanvasListaNotatek_3").GetComponent<Canvas> ();
		notesCanvas2 [3] = GameObject.Find ("CanvasListaNotatek_4").GetComponent<Canvas> ();
		notesCanvas2 [4] = GameObject.Find ("CanvasListaNotatek_5").GetComponent<Canvas> ();
		notesCanvas2 [5] = GameObject.Find ("CanvasListaNotatek_6").GetComponent<Canvas> ();
		notesCanvas2 [6] = GameObject.Find ("CanvasListaNotatek_7").GetComponent<Canvas> ();
		notesCanvas2 [7] = GameObject.Find ("CanvasListaNotatek_8").GetComponent<Canvas> ();
		notesCanvas2 [8] = GameObject.Find ("CanvasListaNotatek_9").GetComponent<Canvas> ();
		notesCanvas2 [9] = GameObject.Find ("CanvasListaNotatek_10").GetComponent<Canvas> ();
		notesCanvas2 [10] = GameObject.Find ("CanvasListaNotatek_11").GetComponent<Canvas> ();
		notesCanvas2 [11] = GameObject.Find ("CanvasListaNotatek_12").GetComponent<Canvas> ();
		notesCanvas2 [12] = GameObject.Find ("CanvasListaNotatek_13").GetComponent<Canvas> ();
		notesCanvas2 [13] = GameObject.Find ("CanvasListaNotatek_14").GetComponent<Canvas> ();
		notesCanvas2 [14] = GameObject.Find ("CanvasListaNotatek_15").GetComponent<Canvas> ();
		notesCanvas2 [15] = GameObject.Find ("CanvasListaNotatek_16").GetComponent<Canvas> ();
		notesCanvas2 [16] = GameObject.Find ("CanvasListaNotatek_17").GetComponent<Canvas> ();
		notesCanvas2 [17] = GameObject.Find ("CanvasListaNotatek_18").GetComponent<Canvas> ();
		notesCanvas2 [18] = GameObject.Find ("CanvasListaNotatek_19").GetComponent<Canvas> ();
		notesCanvas2 [19] = GameObject.Find ("CanvasListaNotatek_20").GetComponent<Canvas> ();
		notesCanvas2 [20] = GameObject.Find ("CanvasListaNotatek_21").GetComponent<Canvas> ();
		notesCanvas2 [21] = GameObject.Find ("CanvasListaNotatek_22").GetComponent<Canvas> ();
		notesCanvas2 [22] = GameObject.Find ("CanvasListaNotatek_23").GetComponent<Canvas> ();
		notesCanvas2 [23] = GameObject.Find ("CanvasListaNotatek_24").GetComponent<Canvas> ();
		notesCanvas2 [24] = GameObject.Find ("CanvasListaNotatek_25").GetComponent<Canvas> ();
		notesCanvas2 [25] = GameObject.Find ("CanvasListaNotatek_26").GetComponent<Canvas> ();
		notesCanvas2 [26] = GameObject.Find ("CanvasListaNotatek_27").GetComponent<Canvas> ();
		notesCanvas2 [27] = GameObject.Find ("CanvasListaNotatek_28").GetComponent<Canvas> ();
		notesCanvas2 [28] = GameObject.Find ("CanvasListaNotatek_29").GetComponent<Canvas> ();
		notesCanvas2 [29] = GameObject.Find ("CanvasListaNotatek_30").GetComponent<Canvas> ();
		notesCanvas2 [30] = GameObject.Find ("CanvasListaNotatek_31").GetComponent<Canvas> ();
		notesCanvas2 [31] = GameObject.Find ("CanvasListaNotatek_32").GetComponent<Canvas> ();
		notesCanvas2 [32] = GameObject.Find ("CanvasListaNotatek_33").GetComponent<Canvas> ();
		notesCanvas2 [33] = GameObject.Find ("CanvasListaNotatek_34").GetComponent<Canvas> ();
		notesCanvas2 [34] = GameObject.Find ("CanvasListaNotatek_35").GetComponent<Canvas> ();
		notesCanvas2 [35] = GameObject.Find ("CanvasListaNotatek_36").GetComponent<Canvas> ();
		notesCanvas2 [36] = GameObject.Find ("CanvasListaNotatek_37").GetComponent<Canvas> ();
		notesCanvas2 [37] = GameObject.Find ("CanvasListaNotatek_38").GetComponent<Canvas> ();
		notesCanvas2 [38] = GameObject.Find ("CanvasListaNotatek_39").GetComponent<Canvas> ();
		notesCanvas2 [39] = GameObject.Find ("CanvasListaNotatek_40").GetComponent<Canvas> ();
		notesCanvas2 [40] = GameObject.Find ("CanvasListaNotatek_41").GetComponent<Canvas> ();
		notesCanvas2 [41] = GameObject.Find ("CanvasListaNotatek_42").GetComponent<Canvas> ();
		notesCanvas2 [42] = GameObject.Find ("CanvasListaNotatek_43").GetComponent<Canvas> ();
		notesCanvas2 [43] = GameObject.Find ("CanvasListaNotatek_44").GetComponent<Canvas> ();
		notesCanvas2 [44] = GameObject.Find ("CanvasListaNotatek_45").GetComponent<Canvas> ();
		notesCanvas2 [45] = GameObject.Find ("CanvasListaNotatek_46").GetComponent<Canvas> ();
		notesCanvas2 [46] = GameObject.Find ("CanvasListaNotatek_47").GetComponent<Canvas> ();
		notesCanvas2 [47] = GameObject.Find ("CanvasListaNotatek_48").GetComponent<Canvas> ();
		notesCanvas2 [48] = GameObject.Find ("CanvasListaNotatek_49").GetComponent<Canvas> ();
		notesCanvas2 [49] = GameObject.Find ("CanvasListaNotatek_50").GetComponent<Canvas> ();
		notesCanvas2 [50] = GameObject.Find ("CanvasListaNotatek_51").GetComponent<Canvas> ();
		notesCanvas2 [51] = GameObject.Find ("CanvasListaNotatek_52").GetComponent<Canvas> ();
		notesCanvas2 [52] = GameObject.Find ("CanvasListaNotatek_53").GetComponent<Canvas> ();
		notesCanvas2 [53] = GameObject.Find ("CanvasListaNotatek_54").GetComponent<Canvas> ();

		notesIcons = new Button[54];
		notesIcons [0] = GameObject.Find ("Notatka1").GetComponent<Button> ();
		notesIcons [1] = GameObject.Find ("Notatka2").GetComponent<Button> ();
		notesIcons [2] = GameObject.Find ("Notatka3").GetComponent<Button> ();
		notesIcons [3] = GameObject.Find ("Notatka4").GetComponent<Button> ();
		notesIcons [4] = GameObject.Find ("Notatka5").GetComponent<Button> ();
		notesIcons [5] = GameObject.Find ("Notatka6").GetComponent<Button> ();
		notesIcons [6] = GameObject.Find ("Notatka7").GetComponent<Button> ();
		notesIcons [7] = GameObject.Find ("Notatka8").GetComponent<Button> ();
		notesIcons [8] = GameObject.Find ("Notatka9").GetComponent<Button> ();
		notesIcons [9] = GameObject.Find ("Notatka10").GetComponent<Button> ();
		notesIcons [10] = GameObject.Find ("Notatka11").GetComponent<Button> ();
		notesIcons [11] = GameObject.Find ("Notatka12").GetComponent<Button> ();
		notesIcons [12] = GameObject.Find ("Notatka13").GetComponent<Button> ();
		notesIcons [13] = GameObject.Find ("Notatka14").GetComponent<Button> ();
		notesIcons [14] = GameObject.Find ("Notatka15").GetComponent<Button> ();
		notesIcons [15] = GameObject.Find ("Notatka16").GetComponent<Button> ();
		notesIcons [16] = GameObject.Find ("Notatka17").GetComponent<Button> ();
		notesIcons [17] = GameObject.Find ("Notatka18").GetComponent<Button> ();
		notesIcons [18] = GameObject.Find ("Notatka19").GetComponent<Button> ();
		notesIcons [19] = GameObject.Find ("Notatka20").GetComponent<Button> ();
		notesIcons [20] = GameObject.Find ("Notatka21").GetComponent<Button> ();
		notesIcons [21] = GameObject.Find ("Notatka22").GetComponent<Button> ();
		notesIcons [22] = GameObject.Find ("Notatka23").GetComponent<Button> ();
		notesIcons [23] = GameObject.Find ("Notatka24").GetComponent<Button> ();
		notesIcons [24] = GameObject.Find ("Notatka25").GetComponent<Button> ();
		notesIcons [25] = GameObject.Find ("Notatka26").GetComponent<Button> ();
		notesIcons [26] = GameObject.Find ("Notatka27").GetComponent<Button> ();
		notesIcons [27] = GameObject.Find ("Notatka28").GetComponent<Button> ();
		notesIcons [28] = GameObject.Find ("Notatka29").GetComponent<Button> ();
		notesIcons [29] = GameObject.Find ("Notatka30").GetComponent<Button> ();
		notesIcons [30] = GameObject.Find ("Notatka31").GetComponent<Button> ();
		notesIcons [31] = GameObject.Find ("Notatka32").GetComponent<Button> ();
		notesIcons [32] = GameObject.Find ("Notatka33").GetComponent<Button> ();
		notesIcons [33] = GameObject.Find ("Notatka34").GetComponent<Button> ();
		notesIcons [34] = GameObject.Find ("Notatka35").GetComponent<Button> ();
		notesIcons [35] = GameObject.Find ("Notatka36").GetComponent<Button> ();
		notesIcons [36] = GameObject.Find ("Notatka37").GetComponent<Button> ();
		notesIcons [37] = GameObject.Find ("Notatka38").GetComponent<Button> ();
		notesIcons [38] = GameObject.Find ("Notatka39").GetComponent<Button> ();
		notesIcons [39] = GameObject.Find ("Notatka40").GetComponent<Button> ();
		notesIcons [40] = GameObject.Find ("Notatka41").GetComponent<Button> ();
		notesIcons [41] = GameObject.Find ("Notatka42").GetComponent<Button> ();
		notesIcons [42] = GameObject.Find ("Notatka43").GetComponent<Button> ();
		notesIcons [43] = GameObject.Find ("Notatka44").GetComponent<Button> ();
		notesIcons [44] = GameObject.Find ("Notatka45").GetComponent<Button> ();
		notesIcons [45] = GameObject.Find ("Notatka46").GetComponent<Button> ();
		notesIcons [46] = GameObject.Find ("Notatka47").GetComponent<Button> ();
		notesIcons [47] = GameObject.Find ("Notatka48").GetComponent<Button> ();
		notesIcons [48] = GameObject.Find ("Notatka49").GetComponent<Button> ();
		notesIcons [49] = GameObject.Find ("Notatka50").GetComponent<Button> ();
		notesIcons [50] = GameObject.Find ("Notatka51").GetComponent<Button> ();
		notesIcons [51] = GameObject.Find ("Notatka52").GetComponent<Button> ();
		notesIcons [52] = GameObject.Find ("Notatka53").GetComponent<Button> ();
		notesIcons [53] = GameObject.Find ("Notatka54").GetComponent<Button> ();

		blurScript = GameObject.Find ("Kamera").GetComponent<Blur> ();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
		inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();
		cursorScript = GameObject.Find ("Kamera").GetComponent<CrosshairGUI> ();
		playerScript = GameObject.Find ("Player").GetComponent<Player> ();

		audioSource = GameObject.Find ("ZrodloPrzedmiotPause_s").GetComponent<AudioSource> ();
		//DzwNotatki = Resources.Load<AudioClip>("Muzyka/Notatka");
		defaultNoteCanvas = GameObject.Find ("CanvasNotatkaDefault").GetComponent<Canvas> ();
	
		noteTitleTextMesh = GameObject.Find ("TytulNotatki").GetComponent<TextMeshProUGUI> ();

		noteTitleTextMesh1 = GameObject.Find("TytulN1").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh2 = GameObject.Find("TytulN2").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh3 = GameObject.Find("TytulN3").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh4 = GameObject.Find("TytulN4").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh5 = GameObject.Find("TytulN5").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh6 = GameObject.Find("TytulN6").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh7 = GameObject.Find("TytulN7").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh8 = GameObject.Find("TytulN8").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh9 = GameObject.Find("TytulN9").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh10 = GameObject.Find("TytulN10").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh11 = GameObject.Find("TytulN11").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh12 = GameObject.Find("TytulN12").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh13 = GameObject.Find("TytulN13").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh14 = GameObject.Find("TytulN14").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh15 = GameObject.Find("TytulN15").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh16 = GameObject.Find("TytulN16").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh17 = GameObject.Find("TytulN17").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh18 = GameObject.Find("TytulN18").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh19 = GameObject.Find("TytulN19").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh20 = GameObject.Find("TytulN20").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh21 = GameObject.Find("TytulN21").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh22 = GameObject.Find("TytulN22").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh23 = GameObject.Find("TytulN23").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh24 = GameObject.Find("TytulN24").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh25 = GameObject.Find("TytulN25").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh26 = GameObject.Find("TytulN26").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh27 = GameObject.Find("TytulN27").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh28 = GameObject.Find("TytulN28").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh29 = GameObject.Find("TytulN29").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh30 = GameObject.Find("TytulN30").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh31 = GameObject.Find("TytulN31").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh32 = GameObject.Find("TytulN32").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh33 = GameObject.Find("TytulN33").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh34 = GameObject.Find("TytulN34").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh35 = GameObject.Find("TytulN35").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh36 = GameObject.Find("TytulN36").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh37 = GameObject.Find("TytulN37").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh38 = GameObject.Find("TytulN38").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh39 = GameObject.Find("TytulN39").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh40 = GameObject.Find("TytulN40").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh41 = GameObject.Find("TytulN41").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh42 = GameObject.Find("TytulN42").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh43 = GameObject.Find("TytulN43").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh44 = GameObject.Find("TytulN44").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh45 = GameObject.Find("TytulN45").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh46 = GameObject.Find("TytulN46").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh47 = GameObject.Find("TytulN47").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh48 = GameObject.Find("TytulN48").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh49 = GameObject.Find("TytulN49").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh50 = GameObject.Find("TytulN50").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh51 = GameObject.Find("TytulN51").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh52 = GameObject.Find("TytulN52").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh53 = GameObject.Find("TytulN53").GetComponent<TextMeshProUGUI>();
		noteTitleTextMesh54 = GameObject.Find("TytulN54").GetComponent<TextMeshProUGUI>();

        // do podpisania kontraktu demona

        player = GameObject.Find("Player").transform;
        healthScript = player.gameObject.GetComponent<Health>();
        tasksScript = player.gameObject.GetComponent<Tasks>();
        randomPunishmentIndex = 0;

}


	void Update () {

	/*	playerCam = Camera.main;
		//Ray playerAim = playerCam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit; */

		if(inventoryScript.isNotesActive == true){
		ZnalezioneNotatki ();
		}

		if (notesCanvas [94].enabled == true && Input.GetKeyDown ("f6")) {
			DemonError ();
		}

		// Zbieranie notatek

		if (Input.GetMouseButtonDown (0) && gameMenuScript.isMenu == false && inventoryScript.isInventoryActive == false && isMenuNotes == false && inventoryScript.isTreatmentActive == false && gameMenuScript.isLoadedGame == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1) {

			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {
				//Debug.Log (hit.collider.name);	
				if (hit.collider.gameObject.name == "Notatka_v1_1" && isNote1 == false) {
					Notatka1 ();
				}
				// Notatka 2

				else if (hit.collider.gameObject.name == "Notatka_v1_2" && isNote2 == false) {
					Notatka2 ();	
				}

				// Notatka 3

				else if (hit.collider.gameObject.name == "Notatka_v1_3" && isNote3 == false) {
					Notatka3 ();
				}

				// Notatka 4

				else if (hit.collider.gameObject.name == "Notatka_v1_4" && isNote4 == false) {
					Notatka4 ();
				}

				// Notatka 5

				else if (hit.collider.gameObject.name == "Notatka_v1_5" && isNote5 == false) {
					Notatka5 ();
				}

				// Notatka 6

				else if (hit.collider.gameObject.name == "Notatka_v1_6" && isNote6 == false) {
					Notatka6 ();
				}

				// Notatka 7

				else if (hit.collider.gameObject.name == "Notatka_v1_7" && isNote7 == false) {
					Notatka7 ();
				}

				// Notatka 8

				else if (hit.collider.gameObject.name == "Notatka_v1_8" && isNote8 == false) {
					Notatka8 ();
				}

				// Notatka 9

				else if (hit.collider.gameObject.name == "Notatka_v1_9" && isNote9 == false) {
					Notatka9 ();
				}

				// Notatka 10

				else if (hit.collider.gameObject.name == "Notatka_v1_10" && isNote10 == false) {
					Notatka10 ();
				}

				// Notatka 11

				else if (hit.collider.gameObject.name == "Notatka_v1_11" && isNote11 == false) {
					Notatka11 ();
				}

				// Notatka 12

				else if (hit.collider.gameObject.name == "Notatka_v1_12" && isNote12 == false) {
					Notatka12 ();
				}

				// Notatka 13

				else if (hit.collider.gameObject.name == "Notatka_v1_13" && isNote13 == false) {
					Notatka13 ();
				}

				// Notatka 14

				else if (hit.collider.gameObject.name == "Notatka_v1_14" && isNote14 == false) {
					Notatka14 ();
				}

				// Notatka 15

				else if (hit.collider.gameObject.name == "Notatka_v1_15" && isNote15 == false) {
					Notatka15 ();
				}

				// Notatka 16

				else if (hit.collider.gameObject.name == "Notatka_v1_16" && isNote16 == false) {
					Notatka16 ();
				}

				// Notatka 17

				else if (hit.collider.gameObject.name == "Notatka_v1_17" && isNote17 == false) {
					Notatka17 ();
				}

				// Notatka 18

				else if (hit.collider.gameObject.name == "Notatka_v1_18" && isNote18 == false) {
					Notatka18 ();
				}

				// Notatka 19

				else if (hit.collider.gameObject.name == "Notatka_v1_19" && isNote19 == false) {
					Notatka19 ();
				}

				// Notatka 20

				else if (hit.collider.gameObject.name == "Notatka_v1_20" && isNote20 == false) {
					Notatka20 ();
				}

				// Notatka 21

				else if (hit.collider.gameObject.name == "Notatka_v1_21" && isNote21 == false) {
					Notatka21 ();
				}

				// Notatka 22

				else if (hit.collider.gameObject.name == "Notatka_v1_22" && isNote22 == false) {
					Notatka22 ();
				}

				// Notatka 23

				else if (hit.collider.gameObject.name == "Notatka_v1_23" && isNote23 == false) {
					Notatka23 ();
				}

				// Notatka 24

				else if (hit.collider.gameObject.name == "Notatka_v1_24" && isNote24 == false) {
					Notatka24 ();
				}

				// Notatka 25

				else if (hit.collider.gameObject.name == "Notatka_v1_25" && isNote25 == false) {
					Notatka25 ();
				}

				// Notatka 26

				else if (hit.collider.gameObject.name == "Notatka_v1_26" && isNote26 == false) {
					Notatka26 ();
				}

				// Notatka 27

				else if (hit.collider.gameObject.name == "Notatka_v1_27" && isNote27 == false) {
					Notatka27 ();
				}

				// Notatka 28

				else if (hit.collider.gameObject.name == "Notatka_v1_28" && isNote28 == false) {
					Notatka28 ();
				}

				// Notatka 29

				else if (hit.collider.gameObject.name == "Notatka_v1_29" && isNote29 == false) {
					Notatka29 ();
				}

				// Notatka 30

				else if (hit.collider.gameObject.name == "Notatka_v1_30" && isNote30 == false) {
					Notatka30 ();
				}

				// Notatka 31

				else if (hit.collider.gameObject.name == "Notatka_v1_31" && isNote31 == false) {
					Notatka31 ();
				}

				// Notatka 32

				else if (hit.collider.gameObject.name == "Notatka_v1_32" && isNote32 == false) {
					Notatka32 ();
				}

				// Notatka 33

				else if (hit.collider.gameObject.name == "Notatka_v1_33" && isNote33 == false) {
					Notatka33 ();
				}

				// Notatka 34

				else if (hit.collider.gameObject.name == "Notatka_v1_34" && isNote34 == false) {
					Notatka34 ();
				}

				// Notatka 35

				else if (hit.collider.gameObject.name == "Notatka_v1_35" && isNote35 == false) {
					Notatka35 ();
				}

				// Notatka 36

				else if (hit.collider.gameObject.name == "Notatka_v1_36" && isNote36 == false) {
					Notatka36 ();
				}

				// Notatka 37

				else if (hit.collider.gameObject.name == "Notatka_v1_37" && isNote37 == false) {
					Notatka37 ();
				}

				// Notatka 38

				else if (hit.collider.gameObject.name == "Notatka_v1_38" && isNote38 == false) {
					Notatka38 ();
				}

				// Notatka 39

				else if (hit.collider.gameObject.name == "Notatka_v1_39" && isNote39 == false) {
					Notatka39 ();
				}

				// Notatka 40

				else if (hit.collider.gameObject.name == "Notatka_v1_40" && isNote40 == false) {
					Notatka40 ();
				}

				// Notatka 41

				else if (hit.collider.gameObject.name == "Notatka_v1_41" && isNote41 == false) {
					Notatka41 ();
				}

				// Notatka 42

				else if (hit.collider.gameObject.name == "Notatka_v1_42" && isNote42 == false) {
					Notatka42 ();
				}

				// Notatka 43

				else if (hit.collider.gameObject.name == "Notatka_v1_43" && isNote43 == false) {
					Notatka43 ();
				}

				// Notatka 44

				else if (hit.collider.gameObject.name == "Notatka_v1_44" && isNote44 == false) {
					Notatka44 ();
				}

				// Notatka 45

				else if (hit.collider.gameObject.name == "Notatka_v1_45" && isNote45 == false) {
					Notatka45 ();
				}

				// Notatka 46

				else if (hit.collider.gameObject.name == "Notatka_v1_46" && isNote46 == false) {
					Notatka46 ();
				}

				// Notatka 47

				else if (hit.collider.gameObject.name == "Notatka_v1_47" && isNote47 == false) {
					Notatka47 ();
				}

				// Notatka 48

				else if (hit.collider.gameObject.name == "Notatka_v1_48" && isNote48 == false) {
					Notatka48 ();
				}

				// Notatka 49

				else if (hit.collider.gameObject.name == "Notatka_v1_49" && isNote49 == false) {
					Notatka49 ();
				}

				// Notatka 50

				else if (hit.collider.gameObject.name == "Notatka_v1_50" && isNote50 == false) {
					Notatka50 ();
				}

				// Notatka 51

				else if (hit.collider.gameObject.name == "Notatka_v1_51" && isNote51 == false) {
					Notatka51 ();
				}

				// Notatka 52

				else if (hit.collider.gameObject.name == "Notatka_v1_52" && isNote52 == false) {
					Notatka52 ();
				}

				// Notatka 53

				else if (hit.collider.gameObject.name == "Notatka_v1_53" && isNote53 == false) {
					Notatka53 ();
				}

				// Notatka 54

				else if (hit.collider.gameObject.name == "Notatka_v1_54" && isNote54 == false) {
					Notatka54 ();
				}

				// notatka lisy

				else if (hit.collider.gameObject.name == "Notatka_v2Lisy" && isFoxNote == false) {
					NotatkaLisy ();
				}

				// zdjecie drewno

				else if (hit.collider.gameObject.name == "ZdjecieDrewno" && isWoodPhoto == false) {
					ZdjecieDrewno ();
				}

				// zdjecie Zeno

				else if (hit.collider.gameObject.name == "ZdjecieZeno" && isZenoPhoto == false) {
					ZdjecieZeno ();
				}

				// notatka Zakupy

				else if (hit.collider.gameObject.name == "NotatkaZakupy" && isShoppingNote == false) {
					NotatkaZakupy ();
				}

				// notatka cytat 1

				else if (hit.collider.gameObject.name == "NotatkaCytat1" && isQuote1Note == false) {
					NotatkaCytat1 ();
				}

				// rysunek kukurydza

				else if (hit.collider.gameObject.name == "RysunekKukurydza" && isCornfieldPicture == false) {
					RysunekKukurydza ();
				}

				// notatka potok lewy

				else if (hit.collider.gameObject.name == "NotatkaPotokLewy" && isLeftBrookNote == false) {
					NotatkaPotokLewy ();
				}

				// notatka grzyby

				else if (hit.collider.gameObject.name == "NotatkaGrzyby" && isMushroomNote == false) {
					NotatkaGrzyby ();
				}

				// zdjecie potok 3

				else if (hit.collider.gameObject.name == "ZdjeciePotok3" && isBrookPhoto3 == false) {
					ZdjeciePotok3 ();
				}

				// zdjecie potok 2

				else if (hit.collider.gameObject.name == "ZdjeciePotok2" && isBrookPhoto2 == false) {
					ZdjeciePotok2 ();
				}

				// zdjecie potok 1

				else if (hit.collider.gameObject.name == "ZdjeciePotok1" && isBrookPhoto1 == false) {
					ZdjeciePotok1 ();
				}

				// rysunek Simon

				else if (hit.collider.gameObject.name == "RysunekSimon" && isSimonPicture == false) {
					RysunekSimon ();
				}

				// notatka rap

				else if (hit.collider.gameObject.name == "NotatkaRap" && isRapNote == false) {
					NotatkaRap ();
				}

				// zdjecie ambona

				else if (hit.collider.gameObject.name == "ZdjecieAmbona" && isTowerPhoto == false) {
					ZdjecieAmbona ();
				}

				// zdjecie studnia

				else if (hit.collider.gameObject.name == "ZdjecieStudnia" && isWellPhoto == false) {
					ZdjecieStudnia ();
				}

				// notatka cytat 2

				else if (hit.collider.gameObject.name == "NotatkaCytat2" && isQuote2Note == false) {
					NotatkaCytat2 ();
				}

				// zdjecie pomnik

				else if (hit.collider.gameObject.name == "ZdjeciePomnik" && isMonumentPhoto == false) {
					ZdjeciePomnik ();
				}

				// notatka wynalazki

				else if (hit.collider.gameObject.name == "NotatkaWynalazki" && isInventionNote == false) {
					NotatkaWynalazki ();
				}

				// zdjecie warsztat

				else if (hit.collider.gameObject.name == "ZdjecieWarsztat" && isWorkshopPhoto == false) {
					ZdjecieWarsztat ();
				}

				// notatka ciemny las

				else if (hit.collider.gameObject.name == "NotatkaCiemny" && isDarkForestNote == false) {
					NotatkaCiemny ();
				}

				// notatka zwierzeta

				else if (hit.collider.gameObject.name == "NotatkaZwierzeta" && isAnimalsNote == false) {
					NotatkaZwierzeta ();
				}

				// notatka noc

				else if (hit.collider.gameObject.name == "NotatkaNoc" && isNightNote == false) {
					NotatkaNoc ();
				}

				// zdjecie szafa

				else if (hit.collider.gameObject.name == "ZdjecieSzafa" && isWardrobePhoto == false) {
					ZdjecieSzafa ();
				}

				// zdjecie szopa

				else if (hit.collider.gameObject.name == "ZdjecieSzopa" && isShedPhoto == false) {
					ZdjecieSzopa ();
				}

				// zdjecie oboz

				else if (hit.collider.gameObject.name == "ZdjecieOboz" && isCampPhoto == false) {
					ZdjecieOboz ();
				}

				// notatka Mary

				else if (hit.collider.gameObject.name == "NotatkaMary" && isMaryNote == false) {
					NotatkaMary ();
				}

				// rysunek corki

				else if (hit.collider.gameObject.name == "RysunekCorki" && isDaughterPicture == false) {
					RysunekCorki ();
				}

				// notatka dyplom

				else if (hit.collider.gameObject.name == "NotatkaDyplom" && isDiplomaNote == false) {
					NotatkaDyplom ();
				}

				// rysunek Tom

				else if (hit.collider.gameObject.name == "RysunekTom" && isTomPicture == false) {
					RysunekTom ();
				}

				// notatka cytat 3

				else if (hit.collider.gameObject.name == "NotatkaCytat3" && isQuote3Note == false) {
					NotatkaCytat3 ();
				}

				// rysunek potwor

				else if (hit.collider.gameObject.name == "RysunekPotwor" && isMonsterPicture == false) {
					RysunekPotwor ();
				}

				// notatka szepty

				else if (hit.collider.gameObject.name == "NotatkaSzepty" && iswhisperNote == false) {
					NotatkaSzepty ();
				}

				// notatka cytat 4

				else if (hit.collider.gameObject.name == "NotatkaCytat4" && isQuote4Note == false) {
					NotatkaCytat4 ();
				}

				// rysunek rosliny

				else if (hit.collider.gameObject.name == "RysunekRosliny" && isPlantPicture == false) {
					RysunekRosliny ();
				}

				// notatka pole

				else if (hit.collider.gameObject.name == "NotatkaPole" && isFieldNote == false) {
					NotatkaPole ();
				}

				// notatka arena

				else if (hit.collider.gameObject.name == "NotatkaArena" && isArenaNote == false) {
					NotatkaArena ();
				}

				// notatka cytat 5

				else if (hit.collider.gameObject.name == "NotatkaCytat5" && isQuote5Note == false) {
					NotatkaCytat5 ();
				}

				// zdjecie potok 4

				else if (hit.collider.gameObject.name == "ZdjeciePotok4" && isBrookPhoto4 == false) {
					ZdjeciePotok4 ();
				}

				// notatka kosmici

				else if (hit.collider.gameObject.name == "NotatkaKosmici" && isAliensNote == false) {
					NotatkaKosmici ();
				}

				// notatka cytat 6

				else if (hit.collider.gameObject.name == "NotatkaCytat6" && isQuote6Note == false) {
					NotatkaCytat6 ();
				}

				// notatka demona

				else if (hit.collider.gameObject.name == "NotatkaDemona") {
					NotatkaDemona ();
				}


			} // klamra do raya

		} // klamra do ifa z przyciskaniem

		else if ((Input.GetMouseButtonDown (0)) && isNotes == true && notesCanvas.Length > 0 && gameMenuScript.isMenu == false && Time.timeScale == 0) { // || Input.GetButtonDown("Cancel")

            WylaczNotatke();


		}

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isPlaySound == false)
        {

            audioSource4.Pause();

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && isPlaySound == true)
        {

            audioSource4.UnPause();

            isPlaySound = false;
        }

    } // klamra do update

    // Wylacz notatki

    public void WylaczNotatke()
    {

        Time.timeScale = 1;
        blurScript.enabled = false;
        isNotes = false;
        Cursor.visible = true;
        cursorScript.enabled = true;
        playerScript.enabled = true;

        for (int i = 0; i < notesCanvas.Length; i++)
        {
            notesCanvas[i].enabled = false;
            //NotatkiCanvas2 [i].enabled = false;
        }

        for (int i = 0; i < notesCanvas2.Length; i++)
        {
            //NotatkiCanvas [i].enabled = false;
            notesCanvas2[i].enabled = false;
        }

    }

    // -----------Funkcje do zbierania notatek-----------------

    void ZnalezioneNotatki(){
		if (isNote1 == true) {
			notesIcons [0].image.sprite = noteIcon1;
		} else {
			notesIcons [0].image.sprite = noteDefaultIcon;
		}

		if (isNote2 == true) {
			notesIcons [1].image.sprite = noteIcon2;
		} else {
			notesIcons [1].image.sprite = noteDefaultIcon;
		}

		if (isNote3 == true) {
			notesIcons [2].image.sprite = noteIcon3;
		} else {
			notesIcons [2].image.sprite = noteDefaultIcon;
		}

		if (isNote4 == true) {
			notesIcons [3].image.sprite = noteIcon4;
		} else {
			notesIcons [3].image.sprite = noteDefaultIcon;
		}

		if (isNote5 == true) {
			notesIcons [4].image.sprite = noteIcon3;
		} else {
			notesIcons [4].image.sprite = noteDefaultIcon;
		}

		if (isNote6 == true) {
			notesIcons [5].image.sprite = noteIcon5;
		} else {
			notesIcons [5].image.sprite = noteDefaultIcon;
		}

		if (isNote7 == true) {
			notesIcons [6].image.sprite = noteIcon6;
		} else {
			notesIcons [6].image.sprite = noteDefaultIcon;
		}

		if (isNote8 == true) {
			notesIcons [7].image.sprite = noteIcon7;
		} else {
			notesIcons [7].image.sprite = noteDefaultIcon;
		}

		if (isNote9 == true) {
			notesIcons [8].image.sprite = noteIcon4;
		} else {
			notesIcons [8].image.sprite = noteDefaultIcon;
		}

		if (isNote10 == true) {
			notesIcons [9].image.sprite = noteIcon1;
		} else {
			notesIcons [9].image.sprite = noteDefaultIcon;
		}

		if (isNote11 == true) {
			notesIcons [10].image.sprite = noteIcon6;
		} else {
			notesIcons [10].image.sprite = noteDefaultIcon;
		}

		if (isNote12 == true) {
			notesIcons [11].image.sprite = noteIcon5;
		} else {
			notesIcons [11].image.sprite = noteDefaultIcon;
		}

		if (isNote13 == true) {
			notesIcons [12].image.sprite = noteIcon2;
		} else {
			notesIcons [12].image.sprite = noteDefaultIcon;
		}

		if (isNote14 == true) {
			notesIcons [13].image.sprite = noteIcon7;
		} else {
			notesIcons [13].image.sprite = noteDefaultIcon;
		}

		if (isNote15 == true) {
			notesIcons [14].image.sprite = noteIcon8;
		} else {
			notesIcons [14].image.sprite = noteDefaultIcon;
		}

		if (isNote16 == true) {
			notesIcons [15].image.sprite = noteIcon3;
		} else {
			notesIcons [15].image.sprite = noteDefaultIcon;
		}

		if (isNote17 == true) {
			notesIcons [16].image.sprite = noteIcon5;
		} else {
			notesIcons [16].image.sprite = noteDefaultIcon;
		}

		if (isNote18 == true) {
			notesIcons [17].image.sprite = noteIcon4;
		} else {
			notesIcons [17].image.sprite = noteDefaultIcon;
		}

		if (isNote19 == true) {
			notesIcons [18].image.sprite = noteIcon7;
		} else {
			notesIcons [18].image.sprite = noteDefaultIcon;
		}

		if (isNote20 == true) {
			notesIcons [19].image.sprite = noteIcon1;
		} else {
			notesIcons [19].image.sprite = noteDefaultIcon;
		}

		if (isNote21 == true) {
			notesIcons [20].image.sprite = noteIcon6;
		} else {
			notesIcons [20].image.sprite = noteDefaultIcon;
		}

		if (isNote22 == true) {
			notesIcons [21].image.sprite = noteIcon8;
		} else {
			notesIcons [21].image.sprite = noteDefaultIcon;
		}

		if (isNote23 == true) {
			notesIcons [22].image.sprite = noteIcon2;
		} else {
			notesIcons [22].image.sprite = noteDefaultIcon;
		}

		if (isNote24 == true) {
			notesIcons [23].image.sprite = noteIcon3;
		} else {
			notesIcons [23].image.sprite = noteDefaultIcon;
		}

		if (isNote25 == true) {
			notesIcons [24].image.sprite = noteIcon4;
		} else {
			notesIcons [24].image.sprite = noteDefaultIcon;
		}

		if (isNote26 == true) {
			notesIcons [25].image.sprite = noteIcon1;
		} else {
			notesIcons [25].image.sprite = noteDefaultIcon;
		}

		if (isNote27 == true) {
			notesIcons [26].image.sprite = noteIcon5;
		} else {
			notesIcons [26].image.sprite = noteDefaultIcon;
		}

		if (isNote28 == true) {
			notesIcons [27].image.sprite = noteIcon2;
		} else {
			notesIcons [27].image.sprite = noteDefaultIcon;
		}

		if (isNote29 == true) {
			notesIcons [28].image.sprite = noteIcon7;
		} else {
			notesIcons [28].image.sprite = noteDefaultIcon;
		}

		if (isNote30 == true) {
			notesIcons [29].image.sprite = noteIcon1;
		} else {
			notesIcons [29].image.sprite = noteDefaultIcon;
		}

		if (isNote31 == true) {
			notesIcons [30].image.sprite = noteIcon6;
		} else {
			notesIcons [30].image.sprite = noteDefaultIcon;
		}

		if (isNote32 == true) {
			notesIcons [31].image.sprite = noteIcon5;
		} else {
			notesIcons [31].image.sprite = noteDefaultIcon;
		}

		if (isNote33 == true) {
			notesIcons [32].image.sprite = noteIcon3;
		} else {
			notesIcons [32].image.sprite = noteDefaultIcon;
		}

		if (isNote34 == true) {
			notesIcons [33].image.sprite = noteIcon4;
		} else {
			notesIcons [33].image.sprite = noteDefaultIcon;
		}

		if (isNote35 == true) {
			notesIcons [34].image.sprite = noteIcon8;
		} else {
			notesIcons [34].image.sprite = noteDefaultIcon;
		}

		if (isNote36 == true) {
			notesIcons [35].image.sprite = noteIcon2;
		} else {
			notesIcons [35].image.sprite = noteDefaultIcon;
		}

		if (isNote37 == true) {
			notesIcons [36].image.sprite = noteIcon8;
		} else {
			notesIcons [36].image.sprite = noteDefaultIcon;
		}

		if (isNote38 == true) {
			notesIcons [37].image.sprite = noteIcon7;
		} else {
			notesIcons [37].image.sprite = noteDefaultIcon;
		}

		if (isNote39 == true) {
			notesIcons [38].image.sprite = noteIcon1;
		} else {
			notesIcons [38].image.sprite = noteDefaultIcon;
		}

		if (isNote40 == true) {
			notesIcons [39].image.sprite = noteIcon6;
		} else {
			notesIcons [39].image.sprite = noteDefaultIcon;
		}

		if (isNote41 == true) {
			notesIcons [40].image.sprite = noteIcon5;
		} else {
			notesIcons [40].image.sprite = noteDefaultIcon;
		}

		if (isNote42 == true) {
			notesIcons [41].image.sprite = noteIcon3;
		} else {
			notesIcons [41].image.sprite = noteDefaultIcon;
		}

		if (isNote43 == true) {
			notesIcons [42].image.sprite = noteIcon8;
		} else {
			notesIcons [42].image.sprite = noteDefaultIcon;
		}

		if (isNote44 == true) {
			notesIcons [43].image.sprite = noteIcon6;
		} else {
			notesIcons [43].image.sprite = noteDefaultIcon;
		}

		if (isNote45 == true) {
			notesIcons [44].image.sprite = noteIcon7;
		} else {
			notesIcons [44].image.sprite = noteDefaultIcon;
		}

		if (isNote46 == true) {
			notesIcons [45].image.sprite = noteIcon4;
		} else {
			notesIcons [45].image.sprite = noteDefaultIcon;
		}

		if (isNote47 == true) {
			notesIcons [46].image.sprite = noteIcon1;
		} else {
			notesIcons [46].image.sprite = noteDefaultIcon;
		}

		if (isNote48 == true) {
			notesIcons [47].image.sprite = noteIcon5;
		} else {
			notesIcons [47].image.sprite = noteDefaultIcon;
		}

		if (isNote49 == true) {
			notesIcons [48].image.sprite = noteIcon7;
		} else {
			notesIcons [48].image.sprite = noteDefaultIcon;
		}

		if (isNote50 == true) {
			notesIcons [49].image.sprite = noteIcon6;
		} else {
			notesIcons [49].image.sprite = noteDefaultIcon;
		}

		if (isNote51 == true) {
			notesIcons [50].image.sprite = noteIcon8;
		} else {
			notesIcons [50].image.sprite = noteDefaultIcon;
		}

		if (isNote52 == true) {
			notesIcons [51].image.sprite = noteIcon3;
		} else {
			notesIcons [51].image.sprite = noteDefaultIcon;
		}

		if (isNote53 == true) {
			notesIcons [52].image.sprite = noteIcon4;
		} else {
			notesIcons [52].image.sprite = noteDefaultIcon;
		}

		if (isNote54 == true) {
			notesIcons [53].image.sprite = noteIcon5;
		} else {
			notesIcons [53].image.sprite = noteDefaultIcon;
		}

	}


	void Notatka1(){
        audioSource.pitch = 1;
		audioSource.PlayOneShot (notesSound);
		isNote1 = true;
		notesCanvas [0].enabled = true;
		notes [0].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
	}

	void Notatka2(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote2 = true;
		notesCanvas[1].enabled = true;
		notes[1].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka3(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote3 = true;
		notesCanvas[2].enabled = true;
		notes[2].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;

        if(inventoryScript.isBone3Taken == false)
        {
            tasksScript.AddKoscSzopaPointer();
        }

        if (inventoryScript.isBone4Taken == false)
        {
            tasksScript.AddKoscStajniaPointer();
        }

    }

	void Notatka4(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote4 = true;
		notesCanvas[3].enabled = true;
		notes [3].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka5(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote5 = true;
		notesCanvas[4].enabled = true;
		notes [4].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka6(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote6 = true;
		notesCanvas[5].enabled = true;
		notes [5].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka7(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote7 = true;
		notesCanvas[6].enabled = true;
		notes [6].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;


        if (inventoryScript.isKeyV2Taken == false)
        {
            tasksScript.AddKluczWychodekPointer();
        }

    }

	void Notatka8(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote8 = true;
		notesCanvas[7].enabled = true;
		notes [7].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka9(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote9 = true;
		notesCanvas[8].enabled = true;
		notes [8].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka10(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote10 = true;
		notesCanvas[9].enabled = true;
		notes [9].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka11(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote11 = true;
		notesCanvas[10].enabled = true;
		notes [10].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka12(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote12 = true;
		notesCanvas[11].enabled = true;
		notes [11].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka13(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote13 = true;
		notesCanvas[12].enabled = true;
		notes [12].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka14(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote14 = true;
		notesCanvas[13].enabled = true;
		notes [13].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka15(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote15 = true;
		notesCanvas[14].enabled = true;
		notes [14].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka16(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote16 = true;
		notesCanvas[15].enabled = true;
		notes [15].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka17(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote17 = true;
		notesCanvas[16].enabled = true;
		notes [16].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka18(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote18 = true;
		notesCanvas[17].enabled = true;
		notes [17].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka19(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote19 = true;
		notesCanvas[18].enabled = true;
		notes [18].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka20(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote20 = true;
		notesCanvas[19].enabled = true;
		notes [19].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka21(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote21 = true;
		notesCanvas[20].enabled = true;
		notes [20].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka22(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote22 = true;
		notesCanvas[21].enabled = true;
		notes [21].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka23(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote23 = true;
		notesCanvas[22].enabled = true;
		notes [22].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka24(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote24 = true;
		notesCanvas[23].enabled = true;
		notes [23].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka25(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote25 = true;
		notesCanvas[24].enabled = true;
		notes [24].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka26(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote26 = true;
		notesCanvas[25].enabled = true;
		notes [25].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka27(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote27 = true;
		notesCanvas[26].enabled = true;
		notes [26].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka28(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote28 = true;
		notesCanvas[27].enabled = true;
		notes [27].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka29(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote29 = true;
		notesCanvas[28].enabled = true;
		notes [28].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka30(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote30 = true;
		notesCanvas[29].enabled = true;
		notes [29].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka31(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote31 = true;
		notesCanvas[30].enabled = true;
		notes [30].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka32(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote32 = true;
		notesCanvas[31].enabled = true;
		notes [31].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka33(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote33 = true;
		notesCanvas[32].enabled = true;
		notes [32].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka34(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote34 = true;
		notesCanvas[33].enabled = true;
		notes [33].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka35(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote35 = true;
		notesCanvas[34].enabled = true;
		notes [34].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka36(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote36 = true;
		notesCanvas[35].enabled = true;
		notes [35].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka37(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote37 = true;
		notesCanvas[36].enabled = true;
		notes [36].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka38(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote38 = true;
		notesCanvas[37].enabled = true;
		notes [37].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka39(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote39 = true;
		notesCanvas[38].enabled = true;
		notes [38].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka40(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote40 = true;
		notesCanvas[39].enabled = true;
		notes [39].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka41(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote41 = true;
		notesCanvas[40].enabled = true;
		notes [40].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka42(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote42 = true;
		notesCanvas[41].enabled = true;
		notes [41].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka43(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote43 = true;
		notesCanvas[42].enabled = true;
		notes [42].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka44(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote44 = true;
		notesCanvas[43].enabled = true;
		notes [43].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka45(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote45 = true;
		notesCanvas[44].enabled = true;
		notes [44].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka46(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote46 = true;
		notesCanvas[45].enabled = true;
		notes [45].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka47(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote47 = true;
		notesCanvas[46].enabled = true;
		notes [46].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka48(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote48 = true;
		notesCanvas[47].enabled = true;
		notes [47].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka49(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote49 = true;
		notesCanvas[48].enabled = true;
		notes [48].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka50(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote50 = true;
		notesCanvas[49].enabled = true;
		notes [49].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka51(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote51 = true;
		notesCanvas[50].enabled = true;
		notes [50].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka52(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote52 = true;
		notesCanvas[51].enabled = true;
		notes [51].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka53(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote53 = true;
		notesCanvas[52].enabled = true;
		notes [52].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void Notatka54(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNote54 = true;
		notesCanvas[53].enabled = true;
		notes [53].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
        notesCount++;
    }

	void NotatkaLisy(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isFoxNote = true;
		notesCanvas[54].enabled = true;
		notes [54].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjecieDrewno(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isWoodPhoto = true;
		notesCanvas[55].enabled = true;
		notes [55].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjecieZeno(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isZenoPhoto = true;
		notesCanvas[56].enabled = true;
		notes [56].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaZakupy(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isShoppingNote = true;
		notesCanvas[57].enabled = true;
		notes [57].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaCytat1(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isQuote1Note = true;
		notesCanvas[58].enabled = true;
		notes [58].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void RysunekKukurydza(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isCornfieldPicture = true;
		notesCanvas[59].enabled = true;
		notes [59].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaPotokLewy(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isLeftBrookNote = true;
		notesCanvas[60].enabled = true;
		notes [60].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaGrzyby(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isMushroomNote = true;
		notesCanvas[61].enabled = true;
		notes [61].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}
		
	void ZdjeciePotok3(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isBrookPhoto3 = true;
		notesCanvas[62].enabled = true;
		notes [62].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjeciePotok2(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isBrookPhoto2 = true;
		notesCanvas[63].enabled = true;
		notes [63].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjeciePotok1(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isBrookPhoto1 = true;
		notesCanvas[64].enabled = true;
		notes [64].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void RysunekSimon(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isSimonPicture = true;
		notesCanvas[65].enabled = true;
		notes [65].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaRap(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isRapNote = true;
		notesCanvas[66].enabled = true;
		notes [66].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjecieAmbona(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isTowerPhoto = true;
		notesCanvas[67].enabled = true;
		notes [67].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjecieStudnia(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isWellPhoto = true;
		notesCanvas[68].enabled = true;
		notes [68].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaCytat2(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isQuote2Note = true;
		notesCanvas[69].enabled = true;
		notes [69].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjeciePomnik(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isMonumentPhoto = true;
		notesCanvas[70].enabled = true;
		notes [70].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaWynalazki(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isInventionNote = true;
		notesCanvas[71].enabled = true;
		notes [71].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjecieWarsztat(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isWorkshopPhoto = true;
		notesCanvas[72].enabled = true;
		notes [72].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaCiemny(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isDarkForestNote = true;
		notesCanvas[73].enabled = true;
		notes [73].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaZwierzeta(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isAnimalsNote = true;
		notesCanvas[74].enabled = true;
		notes [74].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaNoc(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isNightNote = true;
		notesCanvas[75].enabled = true;
		notes [75].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjecieSzafa(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isWardrobePhoto = true;
		notesCanvas[76].enabled = true;
		notes [76].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjecieSzopa(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isShedPhoto = true;
		notesCanvas[77].enabled = true;
		notes [77].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjecieOboz(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isCampPhoto = true;
		notesCanvas[78].enabled = true;
		notes [78].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaMary(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isMaryNote = true;
		notesCanvas[79].enabled = true;
		notes [79].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void RysunekCorki(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isDaughterPicture = true;
		notesCanvas[80].enabled = true;
		notes [80].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaDyplom(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isDiplomaNote = true;
		notesCanvas[81].enabled = true;
		notes [81].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void RysunekTom(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isTomPicture = true;
		notesCanvas[82].enabled = true;
		notes [82].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaCytat3(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isQuote3Note = true;
		notesCanvas[83].enabled = true;
		notes [83].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void RysunekPotwor(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isMonsterPicture = true;
		notesCanvas[84].enabled = true;
		notes [84].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaSzepty(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		iswhisperNote = true;
		notesCanvas[85].enabled = true;
		notes [85].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaCytat4(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isQuote4Note = true;
		notesCanvas[86].enabled = true;
		notes [86].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void RysunekRosliny(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isPlantPicture = true;
		notesCanvas[87].enabled = true;
		notes [87].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaPole(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isFieldNote = true;
		notesCanvas[88].enabled = true;
		notes [88].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaArena(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isArenaNote = true;
		notesCanvas[89].enabled = true;
		notes [89].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaCytat5(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isQuote5Note = true;
		notesCanvas[90].enabled = true;
		notes [90].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void ZdjeciePotok4(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isBrookPhoto4 = true;
		notesCanvas[91].enabled = true;
		notes [91].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaKosmici(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isAliensNote = true;
		notesCanvas[92].enabled = true;
		notes [92].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaCytat6(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		isQuote6Note = true;
		notesCanvas[93].enabled = true;
		notes [93].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void NotatkaDemona(){
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
		notesCanvas[94].enabled = true;
		notes [94].gameObject.SetActive(false);
		isNotes = true;
		blurScript.enabled = true;
		Cursor.visible = false;
        //Kursor.enabled = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
		playerScript.enabled = false;
	}

	void DemonError(){

        if(tasksScript.isWellStonesTask == true)
        {
            randomPunishmentIndex = Random.Range(1, 3);
        }else
        {
            randomPunishmentIndex = Random.Range(3, 5);
        }

        switch (randomPunishmentIndex)
        {
            case 1:
                playerScript.currentStamina = 0;
                wolf = GameObject.Find("Wilk_v3").transform;
                player.transform.position = wolf.transform.position;
                audioSource4.clip = demonSound;
                audioSource4.pitch = 1;
                audioSource4.Play();
                break;
            case 2:
                healthScript.health = 45f;
                wolf = GameObject.Find("Wilk_v3").transform;
                player.transform.position = wolf.transform.position;
                audioSource4.clip = demonSound;
                audioSource4.pitch = 1;
                audioSource4.Play();
                break;
            case 3:
                player.transform.position = new Vector3(1170.099f, 30.443f, 2792.832f);
                player.transform.rotation = Quaternion.Euler(0, 36836.06f, 0);
                audioSource4.clip = demonSound;
                audioSource4.pitch = 1;
                audioSource4.Play();
                break;
            case 4:
                player.transform.position = new Vector3(2039.32f, 57.53f, 1696.63f);
                player.transform.rotation = Quaternion.Euler(0, 36853.02f, 0);
                audioSource4.clip = demonSound;
                audioSource4.pitch = 1;
                audioSource4.Play();
                break;
        }

        isDemonNote = true;
        WylaczNotatke();

	}

	//------------Funckje do GUI Canvas---------------------------------------

	public void NotatkaFunction1(){
		if (isNote1 == true) {
			defaultNoteCanvas.enabled = false;
			//NotatkiCanvas2 [0].enabled = true;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 0) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction1(){
		if (isNote1 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh1.text;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);

	}

	public void NotatkaFunction2(){
		if (isNote2 == true) {
			defaultNoteCanvas.enabled = false;
			//NotatkiCanvas2 [1].enabled = true;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 1) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction2(){
		if (isNote2 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh2.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);

    }

	public void NotatkaFunction3(){
		if (isNote3 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 2) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction3(){
		if (isNote3 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh3.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction4(){
		if (isNote4 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 3) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction4(){
		if (isNote4 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh4.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction5(){
		if (isNote5 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 4) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction5(){
		if (isNote5 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh5.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction6(){
		if (isNote6 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 5) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction6(){
		if (isNote6 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh6.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction7(){
		if (isNote7 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 6) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction7(){
		if (isNote7 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh7.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction8(){
		if (isNote8 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 7) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction8(){
		if (isNote8 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh8.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction9(){
		if (isNote9 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 8) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction9(){
		if (isNote9 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh9.text;;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction10(){
		if (isNote10 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 9) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction10(){
		if (isNote10 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh10.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction11(){
		if (isNote11 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 10) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction11(){
		if (isNote11 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh11.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction12(){
		if (isNote12 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 11) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction12(){
		if (isNote12 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh12.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction13(){
		if (isNote13 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 12) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction13(){
		if (isNote13 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh13.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction14(){
		if (isNote14 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 13) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction14(){
		if (isNote14 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh14.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction15(){
		if (isNote15 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 14) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction15(){
		if (isNote15 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh15.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction16(){
		if (isNote16 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 15) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction16(){
		if (isNote16 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh16.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction17(){
		if (isNote17 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 16) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction17(){
		if (isNote17 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh17.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction18(){
		if (isNote18 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 17) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction18(){
		if (isNote18 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh18.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction19(){
		if (isNote19 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 18) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction19(){
		if (isNote19 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh19.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction20(){
		if (isNote20 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 19) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction20(){
		if (isNote20 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh20.text;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction21(){
		if (isNote21 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 20) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction21(){
		if (isNote21 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh21.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction22(){
		if (isNote22 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 21) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction22(){
		if (isNote22 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh22.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction23(){
		if (isNote23 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 22) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction23(){
		if (isNote23 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh23.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction24(){
		if (isNote24 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 23) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction24(){
		if (isNote24 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh24.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction25(){
		if (isNote25 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 24) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction25(){
		if (isNote25 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh25.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction26(){
		if (isNote26 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 25) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction26(){
		if (isNote26 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh26.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction27(){
		if (isNote27 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 26) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction27(){
		if (isNote27 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh27.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction28(){
		if (isNote28 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 27) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction28(){
		if (isNote28 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh28.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction29(){
		if (isNote29 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 28) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction29(){
		if (isNote29 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh29.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction30(){
		if (isNote30 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 29) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction30(){
		if (isNote30 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh30.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction31(){
		if (isNote31 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 30) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction31(){
		if (isNote31 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh31.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction32(){
		if (isNote32 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 31) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction32(){
		if (isNote32 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh32.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction33(){
		if (isNote33 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 32) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction33(){
		if (isNote33 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh33.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction34(){
		if (isNote34 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 33) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction34(){
		if (isNote34 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh34.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction35(){
		if (isNote35 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 34) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction35(){
		if (isNote35 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh35.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction36(){
		if (isNote36 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 35) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction36(){
		if (isNote36 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh36.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction37(){
		if (isNote37 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 36) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction37(){
		if (isNote37 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh37.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction38(){
		if (isNote38 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 37) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction38(){
		if (isNote38 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh38.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction39(){
		if (isNote39 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 38) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction39(){
		if (isNote39 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh39.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction40(){
		if (isNote40 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 39) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction40(){
		if (isNote40 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh40.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction41(){
		if (isNote41 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 40) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction41(){
		if (isNote41 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh41.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction42(){
		if (isNote42 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 41) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction42(){
		if (isNote42 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh42.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction43(){
		if (isNote43 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 42) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction43(){
		if (isNote43 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh43.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction44(){
		if (isNote44 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 43) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction44(){
		if (isNote44 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh44.text; ;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction45(){
		if (isNote45 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 44) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction45(){
		if (isNote45 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh45.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction46(){
		if (isNote46 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 45) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction46(){
		if (isNote46 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh46.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction47(){
		if (isNote47 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 46) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction47(){
		if (isNote47 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh47.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction48(){
		if (isNote48 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 47) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction48(){
		if (isNote48 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh48.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction49(){
		if (isNote49 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 48) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction49(){
		if (isNote49 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh49.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction50(){
		if (isNote50 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 49) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction50(){
		if (isNote50 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh50.text;
		}

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction51(){
		if (isNote51 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 50) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction51(){
		if (isNote51 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh51.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction52(){
		if (isNote52 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 51) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction52(){
		if (isNote52 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh52.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction53(){
		if (isNote53 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 52) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction53(){
		if (isNote53 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh53.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

	public void NotatkaFunction54(){
		if (isNote54 == true) {
			defaultNoteCanvas.enabled = false;

			for (int i = 0; i < notesCanvas2.Length; i++) {
				if (i == 53) {
					notesCanvas2 [i].enabled = true;
					audioSource.pitch = Random.Range(0.8f, 1.5f);
					audioSource.PlayOneShot (notesSound);
				} else {
					notesCanvas2 [i].enabled = false;
				}
			}
		}
	}

	public void NotatkaTytulFunction54(){
		if (isNote54 == true) {
			noteTitleTextMesh.text = noteTitleTextMesh54.text;
        }

        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }
}

