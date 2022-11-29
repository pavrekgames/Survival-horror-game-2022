using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour {

    public bool DzwiekPlay_ok = false; // wznawianie i zatrzymywanie dzwiekow

    private Inventory inventoryScript;
	private Tasks tasksScript;
	private TaskWell wellTask;
	private Notifications notificationScript;
	private Animator doorAnimator;
	private GameObject openDoorCollider;
	private GameObject corpse;
    private Flashlight flashlightScript;
    private Health healthScript;
	private Notes notesScript;
	private Menu gameMenuScript;

	private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;

	private Transform player; 
	private Transform houseLight;
    private Transform smallShedLight;
	private Transform well;
    private Cupboard paulWardrobeSoundScript;
    private Door openDoorJumpscareScript;
    public GameObject hutLight;
    private Animator kitchenLampAnimator;
    private Animator deadSimonAnimator;
    private Animator fallTreeAnimator;
    private GameObject treeDust;

    public AudioSource playerAudioSource;
	public AudioSource kitchenLampAudioSource;
	public AudioSource hayAudioSource;
    public AudioSource woodAudioSource;
	public AudioSource rustleAudioSource;
	public AudioSource clockAudioSource;
	public AudioSource wolfAudioSource;
	public AudioSource rustle2AudioSource;
	public AudioSource atmosphereAudioSource;
	public AudioSource whisperAudioSource;
	public AudioSource radioAudioSource;
	public AudioSource wellScreamAudioSource;
	public AudioSource woodShedAudioSource;
	public AudioSource ratAudioSource;
	public AudioSource wellWaterAudioSource;
	public AudioSource radioChoirAudioSource; 
	public AudioSource ZrodloDzwGlowa;
	public AudioSource headAudioSource; 
	public AudioSource factoryAudioSource;
	public AudioSource chainsAudioSource;
	public AudioSource factory2AudioSource;
	public AudioSource meanLaughAudioSource;
	public AudioSource ravenAudioSource;
	public AudioSource girlLaughAudioSource;
	public AudioSource girlScreamAudioSource;
	public AudioSource hitAudioSource;
	public AudioSource musicBoxAudioSource;
	public AudioSource knockAudioSource;
	public AudioSource glassAudioSource;
	public AudioSource starsCreakAudioSource;
	public AudioSource stevenScreamAudioSource;
	public AudioSource doorBellAudioSource;
	public AudioSource paulCreakAudioSource;
	public AudioSource stepsAudioSource;
	public AudioSource paulStairsCreakAudioSource;
	public AudioSource closeDoorAudioSource;
	public AudioSource openDoorAudioSource;
	public AudioSource whisper2AudioSource;
    public AudioSource windAudioSource;
    public AudioSource windEffectAudioSource;
    public AudioSource toolsAudioSource;
    public AudioSource bonesAudioSource;
    public AudioSource thornsAudioSource;
    public AudioSource foodAudioSource;
	public AudioSource dogAudioSource;
	public AudioSource brookAudioSource;
	public AudioSource phoneAudioSource;
	public AudioSource whispersAudioSource;
	public AudioSource whispers2AudioSource;
    public AudioSource dogRoarDzwRykPsa;
    public AudioSource breathBoneShedAudioSource;
    public AudioSource smallShedBulbAudioSource;
    public AudioSource woodBirdAudioSource;
    public AudioSource ganjaLeavesAudioSource;
    public AudioSource shedFurnitureAudioSource;
    public AudioSource brookScreeamAudioSource;
    public AudioSource grandmaGlassAudioSource;
    public AudioSource glassKnockAudioSource;
    public AudioSource aliceShedAudioSource;
    public AudioSource hutLightAudioSource;
    public AudioSource floorCreakAudioSource;
    public AudioSource scaryOwlAudioSource;
    public AudioSource scaryOwl2AudioSource;
    public AudioSource waterSplashAudioSource;
    public AudioSource foxScreamAudioSource;
    public AudioSource shockScreamAudioSource;
    public AudioSource suffocateAudioSource;
    public AudioSource fallTreeAudioSource;


    public AudioClip clockSound; 
	public AudioClip lampSound;
    public AudioClip kitchenLampSound;
	public AudioClip rustleSound;
	public AudioClip haySound;
	public AudioClip woodSound;
	public AudioClip wolfSound;
	public AudioClip rustle2Sound;
	public AudioClip atmopshereSound;
	public AudioClip whisperSound;
	public AudioClip radioSpainSound;
	public AudioClip wellScreamSound;
	public AudioClip woodShedSound;
	public AudioClip ratSound;
	public AudioClip wellWaterSound;
	public AudioClip radioFiresSound;
	public AudioClip factorySound;
	public AudioClip chainsSound;
	public AudioClip factory2Sound;
	public AudioClip meanLaughSound;
	public AudioClip ravenSound;
	public AudioClip girlLaughSound;
	public AudioClip girlScreamSound;
	public AudioClip hitSound;
	public AudioClip musicBoxSound;
	public AudioClip knockSound;
	public AudioClip glassSound;
	public AudioClip stairsCreakSound;
	public AudioClip stevenScreamSound;
	public AudioClip doorBellSound;
	public AudioClip paulCreakSound;
	public AudioClip stepsSound;
	public AudioClip paulStairsCreakSound;
	public AudioClip closeDoorSound;
	public AudioClip openDoorSound;
	public AudioClip whisper2Sound;
    public AudioClip windSound;
    public AudioClip windEffectSound;
    public AudioClip toolsSound;
    public AudioClip bonesSound;
    public AudioClip thornsSound;
    public AudioClip foodSound;
	public AudioClip dogSound;
	public AudioClip brookSound;
	public AudioClip breathSound;
	public AudioClip breath2Sound;
	public AudioClip phoneVoiceSound;
	public AudioClip phoneBeepSound;
	public AudioClip wellWhispersSound;
	public AudioClip shelterWhispersSound;
    public AudioClip dogRoarSound;
    public AudioClip boneShedBreathSound;
    public AudioClip woodBirdSound;
    public AudioClip leavesSound;
    public AudioClip shedFurnitureSound;
    public AudioClip brookScreamSound;
    public AudioClip grandmaGlassSound;
    public AudioClip glassKnockSound;
    public AudioClip aliceShedSound;
    public AudioClip hutLightSound;
    public AudioClip floorScreakSound;
    public AudioClip scaryOwlSound;
    public AudioClip scaryOwl2Sound;
    public AudioClip waterSplashSound;
    public AudioClip foxScreamSound;
    public AudioClip shockScreamSound;
    public AudioClip suffocateSound;
    public AudioClip fallTreeSound;

    public bool isClock = false;
	public bool isKitchenLamp = false;
	public bool isLampBefore = false;
	public bool isLight = false;
	public bool isRustle = false;
	public bool isHay = false;
	public bool isWood = false;
	public bool isWolf = false;
	public bool isRustle2 = false;
	public bool isAtmosphere = false;
	public bool isWhisper = false;
	public bool isRadioSpain = false;
	public bool isWellScream = false;
	public bool isWoodShed = false;
	public bool isRat = false;
	public bool isWellWater = false;
	public bool isRadioFires = false;
	public bool isFactory = false;
	public bool isChains = false;
	public bool isFactory2 = false;
	public bool isMeanLaugh = false;
	public bool isActiveLaugh = false; 
	public bool isRaven = false; 
	public bool isGirlLaugh = false; 
	public bool isGirlScream = false; 
	public bool isMusicBox = false; 
	public bool isKnock = false; 
	public bool isGlass = false;
	public bool isStairsCreak = false;
	public bool isStevenScream = false;
	public bool isDoorBellActive = false;
	public bool isDoorBell = false;
	public bool isPaulCreak = false;
	public bool isSteps = false;
	public bool isPaulStairsCreak = false;
	public bool isCloseDoor = false;
	public bool isOpenDoor = false;
	public bool isCorpse = false;
	public bool isWhisper2 = false;
    public bool isWind = false;
    public bool isWindEffect = false;
    public bool isTool = false;
    public bool isBones = false;
    public bool isThorns = false;
    public bool isFood = false;
	public bool isDog = false;
	public bool isBrook = false;
	public bool isBreath = false;
	public bool isBreath2 = false;
	public bool isPhone = false;
	public bool isPhone2 = false;
	public bool isWellWhispers = false;
	public bool isShelterWhispers = false;
    public bool isDogRoar = false;
    public bool isBoneShedBreath = false;
    public bool isWoodBird = false;
    public bool isLeaves = false;
    public bool isShedFurniture = false;
    public bool isBrookScream = false;
    public bool isGrandmaGlass = false;
    public bool isGlassKnock = false;
    public bool isAliceShed = false;
    public bool isHutLight = false;
    public bool isFloorCreak = false;
    public bool isScaryOwl = false;
    public bool isScaryOwl2 = false;
    public bool isWaterSplash = false;
    public bool isFoxScream = false;
    public bool isShockScream = false;
    public bool isFallTree = false;
    public bool isOpenJumpscareDoor = false;

    private AudioSource audioSource;
    private AudioClip screamerSound;
    public bool isCalled;

    void OnEnable () {
		

		playerAudioSource = GameObject.Find ("ZrodloOddech_s").GetComponent<AudioSource> ();
		kitchenLampAudioSource = GameObject.Find ("LampaKuchnia_s").GetComponent<AudioSource> ();
		hayAudioSource = GameObject.Find ("Siano_s").GetComponent<AudioSource> ();
		woodAudioSource = GameObject.Find ("Drewno_przed").GetComponent<AudioSource> ();
		rustleAudioSource = GameObject.Find ("Szelest_s").GetComponent<AudioSource> ();
		clockAudioSource = GameObject.Find ("Zegar_s").GetComponent<AudioSource> ();
		wolfAudioSource = GameObject.Find ("Wilk_s").GetComponent<AudioSource> ();
		rustle2AudioSource = GameObject.Find ("Szelest2_s").GetComponent<AudioSource> ();
		atmosphereAudioSource = GameObject.Find ("Klimat_s").GetComponent<AudioSource> ();
		whisperAudioSource = GameObject.Find ("Szept_s").GetComponent<AudioSource> ();
		radioAudioSource = GameObject.Find ("Dzw_radio_szum").GetComponent<AudioSource> ();
		wellScreamAudioSource = GameObject.Find ("Studnia_s").GetComponent<AudioSource> ();
		woodShedAudioSource = GameObject.Find ("DrewnoSzopa_s").GetComponent<AudioSource> ();
		ratAudioSource = GameObject.Find ("Szczur_s").GetComponent<AudioSource> ();
		wellWaterAudioSource = GameObject.Find ("StudniaWoda_s").GetComponent<AudioSource> ();
		radioChoirAudioSource  = GameObject.Find ("Dzw_radio_chor").GetComponent<AudioSource> ();
		ZrodloDzwGlowa = GameObject.Find ("Głowa").GetComponent<AudioSource> ();
		headAudioSource = GameObject.Find ("Dzw_radio_strzaly").GetComponent<AudioSource> ();
		factoryAudioSource = GameObject.Find ("OdglosyFabryka_s").GetComponent<AudioSource> ();
		chainsAudioSource = GameObject.Find ("Lancuchy_s").GetComponent<AudioSource> ();
		factory2AudioSource = GameObject.Find ("OdglosyFabryka2_s").GetComponent<AudioSource> ();
		meanLaughAudioSource = GameObject.Find ("WrednySmiech_s").GetComponent<AudioSource> ();
		ravenAudioSource = GameObject.Find ("Kruki_s").GetComponent<AudioSource> ();
		girlLaughAudioSource = GameObject.Find ("SmiechDzw_s").GetComponent<AudioSource> ();
		girlScreamAudioSource = GameObject.Find ("KrzykDzw_s").GetComponent<AudioSource> ();
		hitAudioSource = GameObject.Find ("Uderzenie_s").GetComponent<AudioSource> ();
		musicBoxAudioSource = GameObject.Find ("Pozytywka_s").GetComponent<AudioSource> ();
		knockAudioSource = GameObject.Find ("DrzwiTomGoraO").GetComponent<AudioSource> ();
		glassAudioSource = GameObject.Find ("Szklo_s").GetComponent<AudioSource> ();
		starsCreakAudioSource = GameObject.Find ("SkrzypienieSchody_s").GetComponent<AudioSource> ();
		stevenScreamAudioSource = GameObject.Find ("KrzykSteven_s").GetComponent<AudioSource> ();
		doorBellAudioSource = GameObject.Find ("DzwonekDrzwi_s").GetComponent<AudioSource> ();
		paulCreakAudioSource = GameObject.Find ("SkrzypienieZachod_s").GetComponent<AudioSource> ();
		stepsAudioSource  = GameObject.Find ("Kroki_s").GetComponent<AudioSource> ();
		paulStairsCreakAudioSource = GameObject.Find ("SkrzypienieSchodyZachod_s").GetComponent<AudioSource> ();
		closeDoorAudioSource = GameObject.Find ("DrzwiZamknij_s").GetComponent<AudioSource> ();
		openDoorAudioSource = GameObject.Find ("DrzwiOtworz_s").GetComponent<AudioSource> ();
		whisper2AudioSource = GameObject.Find ("Szept2_s").GetComponent<AudioSource> ();
		windAudioSource = GameObject.Find ("Wiatr_trigger").GetComponent<AudioSource> ();
        windEffectAudioSource = GameObject.Find("WiatrEfekt_s").GetComponent<AudioSource>();
        toolsAudioSource = GameObject.Find ("Narzedzia_s").GetComponent<AudioSource> ();
		bonesAudioSource = GameObject.Find ("Kosci_s").GetComponent<AudioSource> ();
		thornsAudioSource = GameObject.Find ("Ciernie_s").GetComponent<AudioSource> ();
		foodAudioSource = GameObject.Find ("Jedzenie_s").GetComponent<AudioSource> ();
		dogAudioSource  = GameObject.Find ("Pies_s").GetComponent<AudioSource> ();
		brookAudioSource = GameObject.Find ("Potok_s").GetComponent<AudioSource> ();
		phoneAudioSource = GameObject.Find ("TelefonGlos").GetComponent<AudioSource> ();
		whispersAudioSource = GameObject.Find ("ZrodloPrzedmiot3_s").GetComponent<AudioSource> ();
		whispersAudioSource = GameObject.Find ("ZrodloDzwSzepty2").GetComponent<AudioSource> ();
        dogRoarDzwRykPsa = GameObject.Find("RykPsa_s").GetComponent<AudioSource>();
        breathBoneShedAudioSource = GameObject.Find("OddechSzopaKosc_s").GetComponent<AudioSource>();
        woodBirdAudioSource = GameObject.Find("PtakSzalas_s").GetComponent<AudioSource>();
        ganjaLeavesAudioSource = GameObject.Find("LiscieGanja_s").GetComponent<AudioSource>();
        shedFurnitureAudioSource = GameObject.Find("SzopaMeble_s").GetComponent<AudioSource>();
        brookScreeamAudioSource = GameObject.Find("KrzykPotok_s").GetComponent<AudioSource>();
        grandmaGlassAudioSource = GameObject.Find("SzkloBabcia_s").GetComponent<AudioSource>();
        glassKnockAudioSource = GameObject.Find("PukanieSzyba_s").GetComponent<AudioSource>();
        aliceShedAudioSource = GameObject.Find("SzopaAlice_s").GetComponent<AudioSource>();
        hutLightAudioSource = GameObject.Find("SwiatloChatka_s").GetComponent<AudioSource>();
        floorCreakAudioSource = GameObject.Find("SkrzypPodloga_s").GetComponent<AudioSource>();
        scaryOwlAudioSource = GameObject.Find("StrasznaSowa_s").GetComponent<AudioSource>();
        scaryOwl2AudioSource = GameObject.Find("StrasznaSowa2_s").GetComponent<AudioSource>();
        waterSplashAudioSource = GameObject.Find("WodaPlusk_s").GetComponent<AudioSource>();
        smallShedBulbAudioSource = GameObject.Find("ZarowkaMalaSzopa_s").GetComponent<AudioSource>();
        foxScreamAudioSource = GameObject.Find("KrzykLisa_s").GetComponent<AudioSource>();
        shockScreamAudioSource = GameObject.Find("KrzykShock_s").GetComponent<AudioSource>();
        suffocateAudioSource = GameObject.Find("DuszenieShock_s").GetComponent<AudioSource>();
        fallTreeAudioSource = GameObject.Find("DrzewoCzlowiek").GetComponent<AudioSource>();

        player = GameObject.Find("Player").transform;
		houseLight = GameObject.Find("Swiatlo2").transform;
        smallShedLight = GameObject.Find("SwiatloMalaSzopa").transform;
        well = GameObject.Find("WiadroStudnia").transform;
        hutLight = GameObject.Find("SwiatloChatka").gameObject;
        kitchenLampAnimator = GameObject.Find("SwiatloKuchnia").GetComponent<Animator>();
        deadSimonAnimator = GameObject.Find("YoungDead").GetComponent<Animator>();
        fallTreeAnimator = GameObject.Find("DrzewoCzlowiek").GetComponent<Animator>();
        treeDust = GameObject.Find("KurzDrzewoFall").gameObject;

        openDoorCollider = GameObject.Find("KoliderOtworzDrzwi").gameObject;
		openDoorCollider.SetActive (false);
		corpse = GameObject.Find("TrupL").gameObject;
        paulWardrobeSoundScript = GameObject.Find("SzafaPaul").GetComponent<Cupboard>();
        openDoorJumpscareScript = GameObject.Find("DrzwiOtworzJmp").GetComponent<Door>();
        //Trup.SetActive (false);

        gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
		inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();
		tasksScript = GameObject.Find ("Player").GetComponent<Tasks> ();
		notificationScript = GameObject.Find ("Player").GetComponent<Notifications> ();
		wellTask = GameObject.Find ("StudniaTrigger").GetComponent<TaskWell> ();
		notesScript = GameObject.Find ("Player").GetComponent<Notes> ();
		flashlightScript = GameObject.Find ("Latarka").GetComponent<Flashlight> ();
		healthScript = GameObject.Find ("Player").GetComponent<Health> ();
        doorAnimator = GameObject.Find("DrzwiZamknijJmpAnimator").GetComponent<Animator>();

        playerCam = Camera.main;

	}

    void CallScreamer()
    {
        audioSource.clip = screamerSound;
        audioSource.Play();
        audioSource.loop = false;
        isCalled = true;
    }

	void Update () {


		// Zegar z kukulka straszak

		if (isClock == false) { 

            if(notesScript.isNote2 == true && Time.timeScale == 1)
            {
                CallScreamer();
            }

		}

		if (wellTask.enabled == true) {
			float DystansStudnia = Vector3.Distance (player.position, well.position);

			// DystansStudnia <= 7 && 
			if (DystansStudnia <= 7 && isWellScream == false && wellTask.stonesCount == 5) {
				isWellScream = true;
                //ZrodloDzwStudniaKrzyk.PlayOneShot (Dzw_StudniaKrzyk);
                wellScreamAudioSource.clip = wellScreamSound;
                wellScreamAudioSource.Play();

            }
		}

		if (isOpenDoor == true && openDoorCollider.activeSelf == true) {

			float DystansKolider = Vector3.Distance (player.position, openDoorCollider.transform.position);

			if (DystansKolider <= 3) {
				openDoorCollider.SetActive (false);
			}
		}

        // Wylaczenie glos telefonu

		if (phoneAudioSource.isPlaying == false && isPhone == true && isPhone2 == false && Time.timeScale == 1 && phoneAudioSource.time > 16f) {
            //ZrodloDzwTelefon.PlayOneShot (DzwTelefonBeep);
            phoneAudioSource.clip = phoneBeepSound;
            phoneAudioSource.Play();
            isPhone2 = true;
		}

		if (tasksScript.isKitchenWardrobeLocked == false && isRadioSpain == false) {
            CallScreamer();
        }



		if (tasksScript.isCasseteInserted == true && isRadioFires == false) {
            CallScreamer();
        }

		if (headAudioSource.isPlaying == false && isRadioFires == true && Time.timeScale == 1) {
			radioChoirAudioSource.clip = null;
		}

		// screamer wredny smiech

		if (isMeanLaugh == true && isActiveLaugh == false) {
			playerCam = Camera.main;
			Ray playerAim = playerCam.GetComponent<Camera> ().ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit; 

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {
				if (hit.collider.gameObject.name == "WrednySmiech_trigger") { // && WrednySmiech_ok == true && AktywujSmiech_ok == false
                    CallScreamer();
                } 
			} 
		}

		// screamer wiatr opuszczony dom

		if (isWind == false && tasksScript.isCassete4Played == true) {
			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit; 

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {
				if (hit.collider.gameObject.name == "Wiatr_trigger") // && Wiatr_ok == false && Tasks.Kaseta4Odtworzona == true
				{
					WiatrScr();
				} 
			}
		}
			
		// Oddech Tom

		if (hitAudioSource.isPlaying == false && isClock == true && isBreath2 == false && Time.timeScale == 1) {
            CallScreamer();
        }


		// Wlaczanie dzwieku pozytywki lub telefonu

		if (Input.GetMouseButton (0)) {

			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit; 

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {
				
				if (hit.collider.gameObject.name == "Pozytywka_s" && isMusicBox == false) {
                    CallScreamer();
                }

				else if (hit.collider.gameObject.name == "TelefonGlos" && isPhone == false) {
                    CallScreamer();
                }

			}
		} 

        if(windAudioSource.isPlaying == false && isWind == true && isWindEffect == false && Time.timeScale == 1)
        {
            //ZrodloDzwWiatr.PlayOneShot(DzwWiatrEfekt);
            windEffectAudioSource.clip = windEffectSound;
            windEffectAudioSource.Play();
            isWindEffect = true;
        }

		if (notesScript.isNote35 == true && isKnock == false && Time.timeScale == 1) {
            CallScreamer();
        }

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && DzwiekPlay_ok == false)
        {

            thornsAudioSource.Pause();
            woodAudioSource.Pause();
            woodShedAudioSource.Pause();
            openDoorAudioSource.Pause();
            closeDoorAudioSource.Pause();
            doorBellAudioSource.Pause();
            ZrodloDzwGlowa.Pause();
            playerAudioSource.Pause();
            kitchenLampAudioSource.Pause();
            foodAudioSource.Pause();
            atmosphereAudioSource.Pause();
            bonesAudioSource.Pause();
            stepsAudioSource.Pause();
            ravenAudioSource.Pause();
            girlScreamAudioSource.Pause();
            stevenScreamAudioSource.Pause();
            chainsAudioSource.Pause();
            toolsAudioSource.Pause();
            factoryAudioSource.Pause();
            factory2AudioSource.Pause();
            dogAudioSource.Pause();
            brookAudioSource.Pause();
            musicBoxAudioSource.Pause();
            knockAudioSource.Pause();
            radioAudioSource.Pause();
            radioChoirAudioSource.Pause();
            headAudioSource.Pause();
            hayAudioSource.Pause();
            starsCreakAudioSource.Pause();
            paulStairsCreakAudioSource.Pause();
            paulCreakAudioSource.Pause();
            girlLaughAudioSource.Pause();
            wellScreamAudioSource.Pause();
            wellWaterAudioSource.Pause();
            ratAudioSource.Pause();
            rustleAudioSource.Pause();
            rustle2AudioSource.Pause();
            whisperAudioSource.Pause();
            whisper2AudioSource.Pause();
            whispersAudioSource.Pause();
            whispersAudioSource.Pause();
            glassAudioSource.Pause();
            phoneAudioSource.Pause();
            hitAudioSource.Pause();
            windAudioSource.Pause();
            wolfAudioSource.Pause();
            meanLaughAudioSource.Pause();
            clockAudioSource.Pause();
            dogRoarDzwRykPsa.Pause();
            breathBoneShedAudioSource.Pause();
            woodBirdAudioSource.Pause();
            ganjaLeavesAudioSource.Pause();
            shedFurnitureAudioSource.Pause();
            brookScreeamAudioSource.Pause();
            glassKnockAudioSource.Pause();
            aliceShedAudioSource.Pause();
            hutLightAudioSource.Pause();
            floorCreakAudioSource.Pause();
            scaryOwlAudioSource.Pause();
            scaryOwl2AudioSource.Pause();
            waterSplashAudioSource.Pause();
            smallShedBulbAudioSource.Pause();
            foxScreamAudioSource.Pause();
            shockScreamAudioSource.Pause();
            suffocateAudioSource.Pause();
            fallTreeAudioSource.Pause();

            DzwiekPlay_ok = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && DzwiekPlay_ok == true)
        {

            thornsAudioSource.UnPause();
            woodAudioSource.UnPause();
            woodShedAudioSource.UnPause();
            openDoorAudioSource.UnPause();
            closeDoorAudioSource.UnPause();
            doorBellAudioSource.UnPause();
            ZrodloDzwGlowa.UnPause();
            playerAudioSource.UnPause();
            kitchenLampAudioSource.UnPause();
            foodAudioSource.UnPause();
            atmosphereAudioSource.UnPause();
            bonesAudioSource.UnPause();
            stepsAudioSource.UnPause();
            ravenAudioSource.UnPause();
            girlScreamAudioSource.UnPause();
            stevenScreamAudioSource.UnPause();
            chainsAudioSource.UnPause();
            toolsAudioSource.UnPause();
            factoryAudioSource.UnPause();
            factory2AudioSource.UnPause();
            dogAudioSource.UnPause();
            brookAudioSource.UnPause();
            musicBoxAudioSource.UnPause();
            knockAudioSource.UnPause();
            radioAudioSource.UnPause();
            radioChoirAudioSource.UnPause();
            headAudioSource.UnPause();
            hayAudioSource.UnPause();
            starsCreakAudioSource.UnPause();
            paulStairsCreakAudioSource.UnPause();
            paulCreakAudioSource.UnPause();
            girlLaughAudioSource.UnPause();
            wellScreamAudioSource.UnPause();
            wellWaterAudioSource.UnPause();
            ratAudioSource.UnPause();
            rustleAudioSource.UnPause();
            rustle2AudioSource.UnPause();
            whisperAudioSource.UnPause();
            whisper2AudioSource.UnPause();
            whispersAudioSource.UnPause();
            whispersAudioSource.UnPause();
            glassAudioSource.UnPause();
            phoneAudioSource.UnPause();
            hitAudioSource.UnPause();
            windAudioSource.UnPause();
            wolfAudioSource.UnPause();
            meanLaughAudioSource.UnPause();
            clockAudioSource.UnPause();
            dogRoarDzwRykPsa.UnPause();
            breathBoneShedAudioSource.UnPause();
            woodBirdAudioSource.UnPause();
            ganjaLeavesAudioSource.UnPause();
            shedFurnitureAudioSource.UnPause();
            brookScreeamAudioSource.UnPause();
            glassKnockAudioSource.UnPause();
            aliceShedAudioSource.UnPause();
            hutLightAudioSource.UnPause();
            floorCreakAudioSource.UnPause();
            scaryOwlAudioSource.UnPause();
            scaryOwl2AudioSource.UnPause();
            waterSplashAudioSource.UnPause();
            smallShedBulbAudioSource.UnPause();
            foxScreamAudioSource.UnPause();
            shockScreamAudioSource.UnPause();
            suffocateAudioSource.UnPause();
            fallTreeAudioSource.UnPause();

            DzwiekPlay_ok = false;
        }

    }

    void WiatrScr()
    {
        windAudioSource.clip = windSound;
        windAudioSource.Play();
        flashlightScript.TurnOffFlashlight();
        isWind = true;
    }

}
