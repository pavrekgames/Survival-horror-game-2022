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


	void Update () {


		// Zegar z kukulka straszak

		if (isClock == false) { 

			/*float Dystans_z = Vector3.Distance (Gracz.position, Zegar.position);

			if (Dystans_z <= 7) {
				ZegarScr ();
			} */

            if(notesScript.isNote2 == true && Time.timeScale == 1)
            {
                ZegarScr();
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
			RadioSpainScr ();
		}



		if (tasksScript.isCasseteInserted == true && isRadioFires == false) {
			RadioStrzalyScr ();
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
					WrednySmiechScr ();
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

		// screamer ciernie

		if (isThorns == false && inventoryScript.isStrongAcidRemoved == false && Input.GetMouseButtonDown (0) && gameMenuScript.isMenu == false && inventoryScript.isPanelActive == false && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1) {
			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit; 

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {
			 	if (hit.collider.gameObject.name == "CiernieKryjowka2_c") 
				{
					Ciernie();
				}
			}
		}
			

		// Oddech Tom

		if (hitAudioSource.isPlaying == false && isClock == true && isBreath2 == false && Time.timeScale == 1) {
			Oddech2 ();
		}


		// Wlaczanie dzwieku pozytywki lub telefonu

		if (Input.GetMouseButton (0)) {

			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit; 

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {
				
				if (hit.collider.gameObject.name == "Pozytywka_s" && isMusicBox == false) {
					PozytywkaScr ();
				}

				else if (hit.collider.gameObject.name == "TelefonGlos" && isPhone == false) {
					TelefonScr ();
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

		//if (Physics.Raycast (playerAim, out hit, RayLength)){
		//if(hit.collider.gameObject.name == "MonsterDrzwiZachod" && DrzwiMonsterZachod_ok == false){
		//	ZrodloDzwDrzwiMonsterZachod.PlayOneShot(DzwDrzwiMonsterZachod);
		//	DrzwiMonsterZachod_ok = true;
		//}

		//}

		if (notesScript.isNote35 == true && isKnock == false && Time.timeScale == 1) {
				PukanieScr ();
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

	void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("Wilk_trigger") && isWolf == false){
			WilkTrigger ();
		}

		else if(other.gameObject.CompareTag("Szelest2_trigger") && isRustle2 == false){
			Szelest2Trigger ();
		}

		else if(other.gameObject.CompareTag("Swiatlo2_trigger") && isLight == false){
			Swiatlo2Trigger ();
		}

		else if(other.gameObject.CompareTag("Klimat_trigger") && isAtmosphere == false && inventoryScript.isKeyV1Taken == false){
			klimatTrigger ();
		}

		else if(other.gameObject.CompareTag("Szept_trigger") && isWhisper == false && inventoryScript.isKeyV1Taken == true){
			SzeptTrigger ();
		}

		else if(other.gameObject.CompareTag("DrewnoSzopa_trigger") && isWoodShed == false){
			DrewnoSzopaTrigger ();
		}

		else if(other.gameObject.CompareTag("Szczur_trigger") && isRat == false){
			SzczurTrigger ();
		}

		else if(other.gameObject.CompareTag("Szelest_trigger") && isRustle == false){
			SzelestTrigger ();
		}

		else if(other.gameObject.CompareTag("LampaPrzed_trigger") && isLampBefore == false){
			isLampBefore = true;
		}

		else if(other.gameObject.CompareTag("Lampa_trigger")&& isKitchenLamp == false && isLampBefore == true){
			LampaKuchniaTrigger ();
		}

		else if(other.gameObject.CompareTag("Siano_trigger") && isHay == false){
			SianoTrigger ();
		}

		else if(other.gameObject.CompareTag("DrewnoPrzed_trigger") && isWood == false){
			DrewnoPrzedTrigger ();
		}

		else if(other.gameObject.CompareTag("OdglosyFabryka_trigger") && isFactory == false){
			OdglosyFabrykaTrigger ();
		}

		else if(other.gameObject.CompareTag("Lancuchy_trigger") && isChains == false){
			LancuchyTrigger ();
		}

		else if(other.gameObject.CompareTag("OdglosyFabryka2_trigger") && isFactory2 == false){
			OdglosyFabryka2Trigger ();
		}

		else if(other.gameObject.CompareTag("WrednySmiech_trigger") && isMeanLaugh == false){
			isMeanLaugh = true;
		}

		else if(other.gameObject.CompareTag("Kruki_trigger") && isRaven == false){
			KrukiTrigger ();
		}

		else if(other.gameObject.CompareTag("SmiechDzw_trigger") && isGirlLaugh == false){
			SmiechDzwTrigger ();
		}

		else if(other.gameObject.CompareTag("KrzykDzw_trigger") && isClock == false){
			KrzykDzwTrigger ();
		}

		else if(other.gameObject.CompareTag("Szklo_trigger") && isGlass == false){
			SzkloTrigger();
		}

        else if(other.gameObject.CompareTag("KrzykSteven_trigger") && isStevenScream == false && tasksScript.isStevenKeyTask == true){
			KrzykStevenTrigger();
		}

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "DzwonekDrzwiWlacz_trigger" && isDoorBell == false && isDoorBellActive == false){
			isDoorBellActive = true;
		}

		else if(other.gameObject.CompareTag("DzwonekDrzwi_trigger") && isDoorBell == false && isDoorBellActive == true){
			DzwonekDrzwiTrigger();
		}

		else if(other.gameObject.CompareTag("SkrzypienieZachod_trigger") && isPaulCreak == false){
			SkrzypienieZachodTrigger();
		}

		else if(other.gameObject.CompareTag("Kroki_trigger") && isSteps == false){
			krokiTrigger();
		}

		else if(other.gameObject.CompareTag("SkrzypienieSchodyZachod_trigger") && isPaulStairsCreak == false){
			SkrzypienieSchodyZachodTrigger();
		}

		else if(other.gameObject.CompareTag("DrzwiZamknij_trigger") && isCloseDoor == false){
			DrzwiZamknijTrigger();
		}

		else if(other.gameObject.CompareTag("DrzwiOtworz_trigger") && isOpenDoor == false && tasksScript.isPaulDoorLocked == false){
			DrzwiOtworzTrigger();
		}

		else if(other.gameObject.CompareTag("Trup_trigger") && isCorpse == false){
			TrupTrigger();
		}

		else if(other.gameObject.CompareTag("Szept2_trigger") && isWhisper2 == false){
			Szept2Trigger();
		}
		else if (other.gameObject.CompareTag("Wiatr_trigger") && isTool == false && isWind == true)
        {
            NarzedziaTrigger();
        }
		else if (other.gameObject.CompareTag("Kosci_trigger") && isBones == false)
        {
            KosciTrigger();
        }
		else if (other.gameObject.CompareTag("Jedzenie_trigger") && isFood == false)
        {
            JedzenieTrigger();
        }
		else if (other.gameObject.CompareTag("Pies_trigger") && isDog == false)
		{
			PiesTrigger();
		}
		else if (other.gameObject.CompareTag("Potok_trigger") && isBrook == false && inventoryScript.isAliceKeyTaken == true)
		{
			PotokTrigger();
		}
		else if (other.gameObject.CompareTag("MonsterPotokWylacz_trigger") && isBreath == false && inventoryScript.isAliceKeyTaken == true)
		{
			Oddech1();
		}
        else if (other.gameObject.CompareTag("RykPsa_trigger") && isDogRoar == false)
        {
            RykPsaTrigger();
        }


    }

	void OnTriggerEnter(Collider other){

		if(other.gameObject.CompareTag("StudniaWoda_trigger") && isWellWater == false){
			StudniaWodaTrigger ();
		} 
		else if(other.gameObject.CompareTag("SzeptyStudnia_trigger") && isWellWhispers == false && tasksScript.isWellStonesTask == true){
			SzeptyStudniaTrigger();
		}
		else if(other.gameObject.CompareTag("Kryjowka_trigger") && isShelterWhispers == false){
			SzeptyKryjowkaTrigger();
		}

        else if (other.gameObject.CompareTag("OddechSzopaKosc_trigger") && isBoneShedBreath == false)
        {
            OddechSzopaKoscTrigger();
        }

        else if (other.gameObject.CompareTag("PtakSzalas_trigger") && isWoodBird == false)
        {
            PtakLasTrigger();
        }
        else if (other.gameObject.CompareTag("Halucynacje_trigger") && isLeaves == false && inventoryScript.isWoodenWheelTaken == true)
        {
            LiscieGanjaTrigger();
        }
        else if (other.gameObject.CompareTag("SzopaMeble_trigger") && isShedFurniture == false)
        {
            SzopaMebleTrigger();
        }

        else if (other.gameObject.CompareTag("KrzykPotok_trigger") && isBrookScream == false && tasksScript.isTompCampTask == true)
        {
            KrzykPotokTrigger();
        }

        else if (other.gameObject.CompareTag("Klimat_trigger") && isGrandmaGlass == false && tasksScript.isWoodKeyTask == true)
        {
            SzkloBabciaTrigger();
        }

        else if (other.gameObject.CompareTag("PukanieSzyba_trigger") && isGlassKnock == false && inventoryScript.isKeyV1Taken == false)
        {
            PukanieSzybaTrigger();
        }

        else if (other.gameObject.CompareTag("SzopaAlice_trigger") && isAliceShed == false && tasksScript.isGoToAliceTask == true)
        {
            SzopaAliceTrigger();
        }

        else if (other.gameObject.CompareTag("SwiatloChatka_trigger") && isHutLight == false)
        {
            SwiatloChatkaTrigger();
        }

        else if (other.gameObject.CompareTag("MonsterKorytarz_trigger") && isFloorCreak == false)
        {
            SkrzypPodlogaTrigger();
        }

        else if (other.gameObject.CompareTag("StrasznaSowa_trigger") && isScaryOwl == false && tasksScript.isSearchTask == false)
        {
            StrasznaSowaTrigger();
        }

        else if (other.gameObject.CompareTag("PtakSzalas_trigger") && isScaryOwl2 == false && tasksScript.isWoodKeyTask == true)
        {
            //StrasznaSowa2Trigger();
        }

        else if (other.gameObject.CompareTag("WodaPlusk_trigger") && isWaterSplash == false)
        {
            WodaPluskTrigger();
        }

        else if (other.gameObject.CompareTag("KrzykLisa_trigger") && isFoxScream == false)
        {
            KrzykLisaTrigger();
        }

        else if (other.gameObject.CompareTag("KrzykShock_trigger") && isShockScream == false)
        {
            KrzykShockTrigger();
        }

        else if (other.gameObject.CompareTag("DrzewoFall_trigger") && isFallTree == false && inventoryScript.isAliceKeyTaken == true)
        {
            DrzewoFallTrigger();
        }

        else if (other.gameObject.CompareTag("SkrzypienieSchodyWylacz_trigger") && isStairsCreak == true)
        {
            isStairsCreak = false;
        }

        else if (other.gameObject.CompareTag("SkrzypienieSchody_trigger") && isStairsCreak == false)
        {
            SkrzypienieSchodyTrigger();
        }

        /*  else if ((other.gameObject.GetComponent<Collider>().gameObject.name == "CiernieKryjowka1_t" || other.gameObject.GetComponent<Collider>().gameObject.name == "CiernieKryjowka2_t" || other.gameObject.GetComponent<Collider>().gameObject.name == "CiernieKryjowka3_t") && Ciernie_ok == false)
          {
              Ciernie();
          }*/

    }
		

	void WilkTrigger(){
        //ZrodloDzwWilk.PlayOneShot(Dzw_wilk);
        wolfAudioSource.clip = wolfSound;
        wolfAudioSource.Play();
        isWolf = true;
	}

	void Szelest2Trigger(){
        //ZrodloDzwWilk.PlayOneShot(Dzw_szelest2);
        rustle2AudioSource.clip = rustle2Sound;
        rustle2AudioSource.Play();
        isRustle2 = true;
	}

	void Swiatlo2Trigger(){
		isLight = true;
		houseLight.gameObject.SetActive(false);
	}

	void klimatTrigger(){
        //ZrodloDzwKlimat.PlayOneShot(Dzw_klimat);
        atmosphereAudioSource.clip = atmopshereSound;
        atmosphereAudioSource.Play();
        isAtmosphere = true;
	}

	void SzeptTrigger(){
        //ZrodloDzwSzept.PlayOneShot(Dzw_Szept);
        whisperAudioSource.clip = whisperSound;
        whisperAudioSource.Play();
        isWhisper = true;
	}

	void DrewnoSzopaTrigger(){
        //ZrodloDzwDrewnoSzopa.PlayOneShot(DzwDrewnoSzopa);
        woodShedAudioSource.clip = woodShedSound;
        woodShedAudioSource.Play();
        isWoodShed = true;
	}

	void SzczurTrigger(){
        //ZrodloDzwSzczur.PlayOneShot(DzwSzczur);
        ratAudioSource.clip = ratSound;
        ratAudioSource.Play();
        isRat = true;
	}

	void SzelestTrigger(){
        //ZrodloDzwSzelest.PlayOneShot(Dzw_szelest);
        rustleAudioSource.clip = rustleSound;
        rustleAudioSource.Play();
        isRustle = true;
	}

	void LampaKuchniaTrigger(){
        //ZrodloDzwieku.PlayOneShot(Dzw_lampa);
        kitchenLampAudioSource.clip = kitchenLampSound;
        kitchenLampAudioSource.Play();
        isKitchenLamp = true;
        kitchenLampAnimator.SetTrigger("Lampa_ok");
	}

	void SianoTrigger(){
        //ZrodloDzwSiano.PlayOneShot(Dzw_siano);
        hayAudioSource.clip = haySound;
        hayAudioSource.Play();
        isHay = true;
	}

	void DrewnoPrzedTrigger(){
        //ZrodloDzwDrewno.PlayOneShot(Dzw_drewno);
        woodAudioSource.clip = woodSound;
        woodAudioSource.Play();
        isWood = true;
	}

	void OdglosyFabrykaTrigger(){
        //ZrodloDzwOdglosyFabryka.PlayOneShot(DzwOdglosyFabryka);
        factoryAudioSource.clip = factorySound;
        factoryAudioSource.Play();
        isFactory = true;
	}

	void LancuchyTrigger(){
        //ZrodloDzwLancuchy.PlayOneShot(DzwLancuchy);
        chainsAudioSource.clip = chainsSound;
        chainsAudioSource.Play();
        isChains = true;
	}

	void OdglosyFabryka2Trigger(){
        //ZrodloDzwOdglosyFabryka2.PlayOneShot(DzwOdglosyFabryka2);
        factory2AudioSource.clip = factory2Sound;
        factory2AudioSource.Play();
        isFactory2 = true;
	}

	void KrukiTrigger(){
        //ZrodloDzwKruki.PlayOneShot(DzwKruki);
        ravenAudioSource.clip = ravenSound;
        ravenAudioSource.Play();
        isRaven = true;
	}

	void SmiechDzwTrigger(){
        //ZrodloDzwSmiechDzw.PlayOneShot(DzwSmiechDzw);
        girlLaughAudioSource.clip = girlLaughSound;
        girlLaughAudioSource.Play();
        isGirlLaugh = true;
	}

	void KrzykDzwTrigger(){
        //ZrodloDzwUderzenie.PlayOneShot(DzwUderzenie);
        hitAudioSource.clip = hitSound;
        hitAudioSource.Play();
        // ZrodloDzwKrzykDzw.PlayOneShot(DzwKrzykDzw);
        girlScreamAudioSource.clip = girlScreamSound;
        girlScreamAudioSource.Play();
        isClock = true;
	}

	void SzkloTrigger(){
        //ZrodloDzwSzklo.PlayOneShot(DzwSzklo);
        glassAudioSource.clip = glassSound;
        glassAudioSource.Play();
        isGlass = true;
	}

	void SkrzypienieSchodyTrigger(){
        //ZrodloDzwSkrzypienieSchody.PlayOneShot(DzwSkrzypienieSchody);
        starsCreakAudioSource.clip = stairsCreakSound;
        starsCreakAudioSource.Play();
        isStairsCreak = true;
	}

	void KrzykStevenTrigger(){
        //ZrodloDzwKrzykSteven.PlayOneShot(DzwKrzykSteven);
        stevenScreamAudioSource.clip = stevenScreamSound;
        stevenScreamAudioSource.Play();
        isStevenScream = true;
	}

	void DzwonekDrzwiTrigger(){
        //ZrodloDzwDzwonekDrzwi.PlayOneShot(DzwDzwonekDrzwi);
        doorBellAudioSource.clip = doorBellSound;
        doorBellAudioSource.Play();
        isDoorBell = true;
	}

	void SkrzypienieZachodTrigger(){
        //ZrodloDzwSkrzypienieZachod.PlayOneShot(DzwSkrzypienieZachod);
        paulCreakAudioSource.clip = paulCreakSound;
        paulCreakAudioSource.Play();
        isPaulCreak = true;
	}

	void krokiTrigger(){
        //ZrodloDzwKroki.PlayOneShot(DzwKroki);
        stepsAudioSource.clip = stepsSound;
        stepsAudioSource.Play();
        isSteps = true;
	}

	void SkrzypienieSchodyZachodTrigger(){
        //ZrodloDzwSkrzypienieSchodyZachod.PlayOneShot(DzwSkrzypienieSchodyZachod);
        paulStairsCreakAudioSource.clip = paulStairsCreakSound;
        paulStairsCreakAudioSource.Play();
        isPaulStairsCreak = true;
	}

	void DrzwiZamknijTrigger(){
        //ZrodloDzwDrzwiZamknij.PlayOneShot(DzwDrzwiZamknij);
        closeDoorAudioSource.clip = closeDoorSound;
        closeDoorAudioSource.Play();
        //Drzwikontroler1.SetTrigger("Zamknij_ok");
		isCloseDoor = true;
	}

	void DrzwiOtworzTrigger(){
        //ZrodloDzwDrzwiOtworz.PlayOneShot(DzwDrzwiOtworz);
        openDoorJumpscareScript.enabled = false;
        openDoorAudioSource.clip = openDoorSound;
        openDoorAudioSource.Play();
        openDoorCollider.SetActive(true); // to bylo zakomentowane
		isOpenDoor = true;
		openDoorCollider.gameObject.AddComponent<Rigidbody>();
		openDoorCollider.gameObject.GetComponent<Rigidbody>().mass = 2;
        openDoorCollider.gameObject.GetComponent<Rigidbody>().AddForce(openDoorCollider.transform.forward * 100);
        //DrzwiOtworzJmp.OtwZam_ok = true;
        openDoorJumpscareScript.isNeedKey = false;
        //KoliderOtworzDrzwi.SetActive(false);
        openDoorJumpscareScript.enabled = true;
        openDoorJumpscareScript.isOpen = false;
        openDoorJumpscareScript.isOpenClose = false;
    }

	void TrupTrigger(){
		//Trup.SetActive(true);
		corpse.gameObject.AddComponent<Rigidbody>();
        corpse.gameObject.GetComponent<Rigidbody>().mass = 2;
        corpse.gameObject.GetComponent<Rigidbody>().AddForce(-corpse.transform.up * 1000f);
        paulWardrobeSoundScript.isCloseOpen = true;
		isCorpse = true;
	}

	void Szept2Trigger(){
        //ZrodloDzwSzept2.PlayOneShot(DzwSzept2);
        whisper2AudioSource.clip = whisper2Sound;
        whisper2AudioSource.Play();
        isWhisper2 = true;
	}

	void StudniaWodaTrigger(){
        //ZrodloDzwStudniaWoda.PlayOneShot(DzwStudniaWoda);
        wellWaterAudioSource.clip = wellWaterSound;
        wellWaterAudioSource.Play();
        //StudniaWoda.gameObject.GetComponent<Collider>().enabled = false;
        isWellWater = true;
	}

	void ZegarScr(){
		isClock = true;
        //ZrodloDzwZegar.PlayOneShot(Dzw_zegar);
        clockAudioSource.clip = clockSound;
        clockAudioSource.Play();
	}

	void RadioSpainScr(){
		radioAudioSource.clip = radioSpainSound;
		radioAudioSource.loop = false;
		isRadioSpain = true;
		radioAudioSource.Play();
	}

	void RadioStrzalyScr(){
		headAudioSource.clip = radioFiresSound;
		headAudioSource.Play ();
		headAudioSource.loop = false;
		isRadioFires = true;
	}

	void WrednySmiechScr(){
        //ZrodloDzwWrednySmiech.PlayOneShot(DzwWrednySmiech);
        meanLaughAudioSource.clip = meanLaughSound;
        meanLaughAudioSource.Play();
        isActiveLaugh = true;
	}

	void PozytywkaScr(){
        //ZrodloDzwPozytywka.PlayOneShot(DzwPozytywka);
        musicBoxAudioSource.clip = musicBoxSound;
        musicBoxAudioSource.Play();
        isMusicBox = true;
	}

	void PukanieScr(){
        //ZrodloDzwPukanie.PlayOneShot (DzwPukanie);
        knockAudioSource.clip = knockSound;
        knockAudioSource.Play();
        isKnock = true;
	}

    void WiatrScr()
    {
        windAudioSource.clip = windSound;
        windAudioSource.Play();
        //ZrodloDzwWiatr.time = 0.070f;
        flashlightScript.TurnOffFlashlight();
        isWind = true;
    }

    void NarzedziaTrigger()
    {
        //ZrodloDzwNarzedzia.PlayOneShot(DzwNarzedzia);
        toolsAudioSource.clip = toolsSound;
        toolsAudioSource.Play();
        isTool = true;
    }

    void KosciTrigger()
    {
        //ZrodloDzwKosci.PlayOneShot(DzwKosci);
        bonesAudioSource.clip = bonesSound;
        bonesAudioSource.Play();
        isBones = true;
    }

    void JedzenieTrigger()
    {
        // ZrodloDzwJedzenie.PlayOneShot(DzwJedzenie);
        foodAudioSource.clip = foodSound;
        foodAudioSource.Play();
        isFood = true;
    }

    void Ciernie()
    {
        //ZrodloDzwCiernie.PlayOneShot(DzwCiernie);

        for (int i = 0; i < inventoryScript.items.Count; i++)
        {
            if (inventoryScript.items[i].type == "Mikstura" && inventoryScript.items[i].isUsed == true)
            {
                isThorns = true;
                break;
            }else
            {
                thornsAudioSource.clip = thornsSound;
                thornsAudioSource.Play();
                isThorns = true;
                healthScript.health = 25;
                break;
            }
        }


        
    }

	void PiesTrigger()
	{
        //ZrodloDzwPies.PlayOneShot(DzwPies);
        dogAudioSource.clip = dogSound;
        dogAudioSource.Play();
        isDog = true;
	}

	void PotokTrigger()
	{
        //ZrodloDzwPotok.PlayOneShot(DzwPotok);
        brookAudioSource.clip = brookSound;
        brookAudioSource.Play();
        isBrook = true;
	}

	void Oddech1()
	{
        //ZrodloDzwGracz.PlayOneShot(DzwOddech1);
        playerAudioSource.clip = breathSound;
        playerAudioSource.Play();
        isBreath = true;
        treeDust.SetActive(false);
	}

	void Oddech2()
	{
        //ZrodloDzwGracz.PlayOneShot(DzwOddech2);
        playerAudioSource.clip = breath2Sound;
        playerAudioSource.Play();
        isBreath2 = true;
	}

	void TelefonScr()
	{
        //ZrodloDzwTelefon.PlayOneShot(DzwTelefonGlos);
        phoneAudioSource.clip = phoneVoiceSound;
        phoneAudioSource.Play();
        isPhone = true;
	}

	void SzeptyStudniaTrigger()
	{
        //ZrodloDzwSzepty.PlayOneShot(DzwSzeptyStudnia);
        whispersAudioSource.clip = wellWhispersSound;
        whispersAudioSource.Play();
        isWellWhispers = true;
	}

	void SzeptyKryjowkaTrigger()
	{
        //ZrodloDzwSzepty2.PlayOneShot(DzwSzeptyKryjowka);
        whispersAudioSource.clip = shelterWhispersSound;
        whispersAudioSource.Play();
        isShelterWhispers = true;
	}

    void RykPsaTrigger()
    {
        dogRoarDzwRykPsa.clip = dogRoarSound;
        dogRoarDzwRykPsa.Play();
        isDogRoar = true;
    }

    void OddechSzopaKoscTrigger()
    {
        breathBoneShedAudioSource.clip = boneShedBreathSound;
        breathBoneShedAudioSource.Play();
        smallShedBulbAudioSource.clip = lampSound;
        smallShedBulbAudioSource.Play();
        isBoneShedBreath = true;
        smallShedLight.gameObject.SetActive(false);
    }

    void PtakLasTrigger()
    {
        woodBirdAudioSource.clip = woodBirdSound;
        woodBirdAudioSource.Play();
        isWoodBird = true;
    }

    void LiscieGanjaTrigger()
    {
        ganjaLeavesAudioSource.clip = leavesSound;
        ganjaLeavesAudioSource.Play();
        isLeaves = true;
    }

    void SzopaMebleTrigger()
    {
        shedFurnitureAudioSource.clip = shedFurnitureSound;
        shedFurnitureAudioSource.Play();
        isShedFurniture = true;
    }

    void KrzykPotokTrigger()
    {
        brookScreeamAudioSource.clip = brookScreamSound;
        brookScreeamAudioSource.Play();
        isBrookScream = true;
    }

    void SzkloBabciaTrigger()
    {
        grandmaGlassAudioSource.clip = grandmaGlassSound;
        grandmaGlassAudioSource.Play();
        isGrandmaGlass = true;
    }

    void PukanieSzybaTrigger()
    {
        glassKnockAudioSource.clip = glassKnockSound;
        glassKnockAudioSource.Play();
        isGlassKnock = true;
    }

    void SzopaAliceTrigger()
    {
        aliceShedAudioSource.clip = aliceShedSound;
        aliceShedAudioSource.Play();
        isAliceShed = true;
    }

    void SwiatloChatkaTrigger()
    {
        hutLightAudioSource.clip = hutLightSound;
        hutLightAudioSource.Play();
        hutLight.GetComponent<Light>().enabled = true;
        isHutLight = true;
    }

    void SkrzypPodlogaTrigger()
    {
        floorCreakAudioSource.clip = floorScreakSound;
        floorCreakAudioSource.Play();
        isFloorCreak = true;
    }

    void StrasznaSowaTrigger()
    {
        scaryOwlAudioSource.clip = scaryOwlSound;
        scaryOwlAudioSource.Play();
        isScaryOwl = true;
    }

    void StrasznaSowa2Trigger()
    {
        scaryOwl2AudioSource.clip = scaryOwl2Sound;
        scaryOwl2AudioSource.Play();
        isScaryOwl2 = true;
    }

    void WodaPluskTrigger()
    {
        waterSplashAudioSource.clip = waterSplashSound;
        waterSplashAudioSource.Play();
        isWaterSplash = true;
    }

    void KrzykLisaTrigger()
    {
        foxScreamAudioSource.clip = foxScreamSound;
        foxScreamAudioSource.Play();
        isFoxScream = true;
    }

    void KrzykShockTrigger()
    {
        shockScreamAudioSource.clip = shockScreamSound;
        shockScreamAudioSource.Play();
        suffocateAudioSource.clip = suffocateSound;
        suffocateAudioSource.Play();
        isShockScream = true;
        deadSimonAnimator.SetTrigger("Shock");
    }

    void DrzewoFallTrigger()
    {
        fallTreeAudioSource.clip = fallTreeSound;
        fallTreeAudioSource.Play();
        isFallTree = true;
        fallTreeAnimator.SetTrigger("DrzewoFall");
        //KurzDrzewoFall.SetActive(true);
    }

}
