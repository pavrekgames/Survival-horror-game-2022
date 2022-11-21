using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour {

    public bool isPlaySound = false; // wznawianie i zatrzymywanie dzwiekow
    private Music musicScript;
    private Map mapScript;

    private Ray playerAim;
    private Camera playerCam;
    public float rayLength = 4f;

    // Pierwszy jumpscare potok

    private Inventory inventoryScript;
	public GameObject brookMonster1;
	public bool isBrookMonster1_On = false;
	public bool isBrookMonster1_Off = false;
	public float counter1 = 0;

	// drugi jumpscare kukurydza

	public GameObject staticCornfieldMonster;
	public GameObject cornfieldMonster;
	public bool isCornfieldMonster = false;
    private Transform cornfieldMonsterPoint;

    // Trzeci jumpscare korytarz

    public GameObject corridorMonster;
	public bool isCorridorMonster = false;
	public AudioSource corridorMonsterAudioSource;
	public AudioClip corridorMonsterSound;

	// Czwarty jumpscare kukurydza Toma
	public GameObject cornfieldMonster2;
    private Transform cornfieldMonster2ResetPoint;
    public bool isCornfieldMonster2 = false;

    // Piąty jumpscare koryto w lesie

    public GameObject channelMonster;
	public bool isChannelMonster = false;
	public AudioSource channelMonsterAudioSource;
	public AudioClip channelMonsterSound;

	// Szosty jumpscare las z miesem

	public GameObject meatMonster1;
	public GameObject meatMonster2;
	public bool isMeatMonsters = false;

	// Siodmy jumpscare pokoj zachod

	public GameObject paulRoomMonster;
	public bool isPaulRoomMonster = false;
	public AudioSource paulRoomMonsterAudioSource;
	public AudioClip paulRoomMonsterSound;

	// Osmy jumpscare drzwi zachod

	public GameObject paulDoorMonster;
    private MonsterDrzwiZachod paulDoorMonsterScript;
    private Door paulDoorSoundScript;
    public bool isPaulDoorMonster = false;

	// Dziewiaty jumpscare ogrod

	public GameObject gardenMonster;
	//private Monster1_v1 KodMonster1_v1;
	public bool isGardenMonster = false;
	private Transform gardenMonsterPoint;

	// Dziesiaty jumpscare warsztat

	public GameObject workshopMonster;
	public bool isWorkshopMonster = false;
	private Transform workshopMonsterPoint;

	// jedenasty jumpscare dynia

	public GameObject pumpkinMonster;
	public bool isPumpkinMonster_On = false;
	public bool isPumpkinMonster_Off = false;
	private Notes notesScript;

    // jumpscare opuszczony dom 1

    public GameObject abandonedMonster;
    private Transform abandonedMonsterPoint1;
    private Transform abandonedMonsterPoint2;
    private Transform abandonedMonsterPoint3;
    public AudioClip abandonedMonsterSound;
    public AudioSource abandonedMonsterAudioSource;
    public bool isAbandonedMonster = false;
    private Transform player;
    private Health healthScript;
    public float abandonedMonsterTime = 0;
    public bool isAbandonedMonsterStop = false;

    // jumpscare Szopa 1

    public GameObject shedMonster1;
    public AudioClip shedMonster1_Sound;
    public AudioSource shedMonster1_AudioSource;
    public AudioClip breathSound;
    public AudioSource breathAudioSource;
    public bool isShedMonster1 = false;

    // jumpscare Tom 

    public GameObject tomMonster;
    public bool isTomMonster = false;
    private Tasks tasksScript;

    // jumpscare Roslina

    public GameObject plantMonster;
    public bool isPlantMonster = false;
    public AudioSource plantMonsterAudioSource;
    public AudioClip plantMonsterSound;
    private Transform plant;

    // jumpscare krzaki 

    public GameObject bushMonster;
    public bool isBushMonster_On = false;
    public bool isBushMonster_Off = false;

    // jumpscare ZachodDol

    public GameObject paulDownstairsMonster;
    public bool isPaulDownstairsMonster = false;
    public AudioSource paulDownstairsMonsterAudioSource;
    public AudioClip paulDownstairsMonsterSound;

    // jumpscare Szopa Steven 1

    public GameObject stevenShedMonster1;
    public bool isStevenShedMonster1 = false;
    private Transform stevenShedMonster1Point;

    // jumpscare Szopa Steven 2

    public GameObject stevenShedMonster2;
    public bool isStevenShedMonster2 = false;
    public AudioSource stevenShedMonster2_AudioSource;
    public AudioClip stevenShedMonster2_sound;
    private Transform stevenShedMonster2Point;
    public bool isPlayerSave = true;

    // jumpscare poczatek

    public GameObject beginMonster;
    public bool isBeginMonster = false;
    public AudioSource beginMonsterAudioSource;
    public AudioClip beginMonsterSound;

    // jumpscare stajnia

    public GameObject stableMonster;
    public bool isStableMonster = false;
    public AudioSource stableMonsterAudioSource;
    public AudioClip stableMonsterSound;
    private Animator stableMonsterAnimator;

    // jumpscare Kamping

    public GameObject secretRoomMonster;
    public bool isSecretRoomMonster = false;
    private Animator secretRoomMonsterAnimator;

    // jumpscare wilki poczatek

    public GameObject beginWolf1;
    public GameObject beginWolf2;
    public bool isBeginWolves = false;
    public AudioSource beginWolfAudioSource;
    public AudioClip beginWolfSound;

    // jumpscare pajak 1

    public GameObject jumpscareSpider1;
    public bool isJumpscareSpider1 = false;

    // jumpscare pajak 2

    public GameObject jumpscareSpider2;
    public Door nicheDoorSoundScript;
    public bool isJumpscareSpider2 = false;

    // jumpscare pajak 3

    public GameObject spider3;
    public bool isSpider3_On = false;
    public bool isSpider3_Off = false;

    // jumpscare pajak 4

    public GameObject spider4;
    public bool isSpider4 = false;
    public AudioSource spider4_AudioSource;
    public AudioClip spider4_Sound;
    public AudioSource spider4_JumpscareAudioSource;
    public AudioClip spider4_JumpscareSound;

    // jumpscare wilki i pajaki na mapie

    public GameObject wolf1;
    public bool isWolf1 = false; 
    public GameObject wolf2;
    public bool isWolf2 = false;
    public GameObject wolf3;
    public bool isWolf3 = false;
    public GameObject spider5;
    public bool isSpider5 = false;


    void OnEnable () {

        isWolf1 = false;
        isWolf2 = false;
        isWolf3 = false;
        isSpider5 = false;

        musicScript = GameObject.Find("Player").GetComponent<Music>();

        staticCornfieldMonster = GameObject.Find("Monster2_Wisi").gameObject;
		gardenMonsterPoint = GameObject.Find("MonsterPunkt4").transform;
		workshopMonsterPoint = GameObject.Find("Monster2Punkt1").transform;
        cornfieldMonsterPoint = GameObject.Find("Monster3Punkt1").transform;
        cornfieldMonster2ResetPoint = GameObject.Find("Monster5Punkt1").transform;
        abandonedMonsterPoint1 = GameObject.Find("MonsterOpuszczonyPunkt2").transform;
        abandonedMonsterPoint2 = GameObject.Find("MonsterOpuszczonyPunkt3").transform;
        abandonedMonsterPoint3 = GameObject.Find("MonsterOpuszczonyPunkt4").transform;
        stevenShedMonster1Point = GameObject.Find("MonsterSzopaStevenPunkt3").transform;
        stevenShedMonster2Point = GameObject.Find("MonsterSzopaSteven2Punkt1").transform;
        player = GameObject.Find("Player").transform;
        healthScript = player.GetComponent<Health>();
        tasksScript = player.GetComponent<Tasks>();
		inventoryScript = player.GetComponent<Inventory>();
		notesScript = player.GetComponent<Notes>();
        mapScript = player.GetComponent<Map>();
        plant = GameObject.Find("RoslinaLab").transform;

		//MonsterSzopaSteven1.SetActive(true);
		//MonsterSzopaSteven1_ok = true;
		brookMonster1 = GameObject.Find("Monster1_Potok1").gameObject;

		// drugi jumpscare kukurydza

		cornfieldMonster = GameObject.Find("Monster2_v1").gameObject;

		// Trzeci jumpscare korytarz

		corridorMonster = GameObject.Find("Monster2_v2").gameObject;
		corridorMonsterAudioSource = GameObject.Find("JumpscareKorytarz_s").GetComponent<AudioSource>();
		//DzwJmpKorytarz = Resources.Load<AudioClip>("Muzyka/Screamer_v8");

		// Czwarty jumpscare kukurydza Toma
		cornfieldMonster2 = GameObject.Find("Monster2_v3").gameObject;

		// Piąty jumpscare koryto w lesie

		channelMonster = GameObject.Find("MonsterKoryto").gameObject;
		channelMonsterAudioSource = GameObject.Find("DzwKoryto_jumpscare").GetComponent<AudioSource>();
		//DzwJmpKoryto = Resources.Load<AudioClip>("Muzyka/Screamer_skrzypce");

		// Szosty jumpscare las z miesem

		meatMonster1 = GameObject.Find("Monster1_v3").gameObject;
		meatMonster2 = GameObject.Find("Monster1_v4").gameObject;

		// Siodmy jumpscare pokoj zachod

		paulRoomMonster = GameObject.Find("MonsterPokojZachod").gameObject;
		paulRoomMonsterAudioSource = GameObject.Find("MonsterPokojZachod_s").GetComponent<AudioSource>();
		//DzwJmpPokojZachod = Resources.Load<AudioClip>("Muzyka/Screamer_v7");

		// Osmy jumpscare drzwi zachod

		paulDoorMonster = GameObject.Find("MonsterDrzwiZachod").gameObject;
        paulDoorMonsterScript = GameObject.Find("MonsterDrzwiZachod").GetComponent<MonsterDrzwiZachod>();
        paulDoorSoundScript = GameObject.Find("DrzwiMonster").GetComponent<Door>(); 

        // Dziewiaty jumpscare ogrod

        gardenMonster = GameObject.Find("Monster1_v1").gameObject;
		//KodMonster1_v1 = GameObject.Find("Monster1_v1").GetComponent<Monster1_v1>();

		// Dziesiaty jumpscare warsztat

		workshopMonster = GameObject.Find("Monster1_v2").gameObject;

		// jumpscare opuszczony dom 1

		abandonedMonster = GameObject.Find("Monster2_Opuszczony").gameObject;
		//DzwMonsterOpuszczonyRyk1 = Resources.Load<AudioClip>("Muzyka/MonsterKlimat_v2L");
		abandonedMonsterAudioSource = GameObject.Find("Dzw_OpuszczonyRyk1").GetComponent<AudioSource>();

		// jumpscare Szopa 1

		shedMonster1 = GameObject.Find("Monster1_Szopa1").gameObject;
		//DzwMonsterSzopa1 = Resources.Load<AudioClip>("Muzyka/GrzmotDrewno");
		shedMonster1_AudioSource = GameObject.Find("DzwMonsterSzopa1").GetComponent<AudioSource>();
		//DzwOddech = Resources.Load<AudioClip>("Muzyka/Oddech_v2");
		breathAudioSource = GameObject.Find("MuzykaOddechy").GetComponent<AudioSource>();

		// jumpscare Tom 

		tomMonster = GameObject.Find("Monster1_Tom").gameObject;

		// jumpscare Roslina

		plantMonster = GameObject.Find("Monster2_Roslina").gameObject;
		plantMonsterAudioSource = GameObject.Find("MonsterRoslina_s").GetComponent<AudioSource>();
		//DzwRoslinaJmp = Resources.Load<AudioClip>("Muzyka/Screamer_v9");

		// jumpscare krzaki 

		bushMonster = GameObject.Find("Monster1_Krzaki").gameObject;

		// jumpscare ZachodDol

		paulDownstairsMonster = GameObject.Find("Monster2_ZachodDol").gameObject;
		paulDownstairsMonsterAudioSource = GameObject.Find("MonsterZachodGora_s").GetComponent<AudioSource>();
		//DzwMonsterJmp = Resources.Load<AudioClip>("Muzyka/Screamer_drzwi_v1L");

		// jumpscare Szopa Steven 1

		stevenShedMonster1 = GameObject.Find("Monster1_SzopaSteven").gameObject;

		// jumpscare Szopa Steven 2

		stevenShedMonster2 = GameObject.Find("Monster1_SzopaSteven2").gameObject;
		stevenShedMonster2_AudioSource = GameObject.Find("MonsterSteven_s").GetComponent<AudioSource>();

        // jumpscare Poczatek

        beginMonster = GameObject.Find("Monster1_Poczatek").gameObject;
        beginMonsterAudioSource = GameObject.Find("MonsterPoczatek_s").GetComponent<AudioSource>();

        // jumpscare stajnia

        stableMonster = GameObject.Find("Monster2_Stajnia").gameObject;
        stableMonsterAnimator = GameObject.Find("Monster2_Stajnia").GetComponent<Animator>();
        stableMonsterAudioSource = GameObject.Find("MonsterStajnia_s").GetComponent<AudioSource>();

        // jumpscare kamping

        secretRoomMonster = GameObject.Find("Monster2_Kamping").gameObject;
        secretRoomMonsterAnimator = GameObject.Find("Monster2_Kamping").GetComponent<Animator>();

        pumpkinMonster = GameObject.Find("Monster1_Dynia").gameObject;
        //AnimatorMonsterStajnia.SetTrigger("MonsterStajniaIdle");

        // jumpscare wilki

        wolf1 = GameObject.Find("Wilk_v1").gameObject;
        wolf2 = GameObject.Find("Wilk_v2").gameObject;
        wolf3 = GameObject.Find("Wilk_v3").gameObject;

        // jumpscare wilki poczatek

        beginWolf1 = GameObject.Find("WilkPoczatek1").gameObject;
        beginWolf2 = GameObject.Find("WilkPoczatek2").gameObject;
        beginWolfAudioSource = GameObject.Find("WilkPoczatek_s").GetComponent<AudioSource>();

        // jumpscare pajak 1

        jumpscareSpider1 = GameObject.Find("PajakJumpscare1").gameObject;

        // jumpscare pajak 2

        jumpscareSpider2 = GameObject.Find("PajakJumpscare2").gameObject;
        nicheDoorSoundScript = GameObject.Find("DrzwiWneka").GetComponent<Door>();

        // jumpscare pajak 3

        spider3 = GameObject.Find("Pajak_v3").gameObject;

        // jumpscare pajak 4

        spider4 = GameObject.Find("Pajak_v4").gameObject;
        spider4_AudioSource = GameObject.Find("Pajak4_s").GetComponent<AudioSource>();
        spider4_JumpscareAudioSource = GameObject.Find("JmpPajak4_s").GetComponent<AudioSource>();

        // jumpscare pajak 5

        spider5 = GameObject.Find("Pajak_v5").gameObject;

    }
	

	void Update () {

		if (inventoryScript.labPlant.gameObject.activeSelf == true) {
			float DystansRoslina = Vector3.Distance (player.position, plant.position);

			if(DystansRoslina <= 40 && isPlantMonster == false && notesScript.isNote44 == true) 
			{
				plantMonster.SetActive(true);
				plantMonster.gameObject.GetComponent<Monster2_Roslina> ().enabled = true;
                //ZrodloDzwRoslinaJmp.PlayOneShot(DzwRoslinaJmp);
                //ZrodloDzwRoslinaJmp.clip = DzwRoslinaJmp;
                //ZrodloDzwRoslinaJmp.Play();
				isPlantMonster = true;
			}

		}

        // jumpscare monster stajnia

        if (inventoryScript.isOilTaken == true && isStableMonster == false)
        {
            playerCam = Camera.main;
            Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            stableMonster.SetActive(true);

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9))
            {
                if (hit.collider.gameObject.name == "MonsterStajnia_trigger")
                { // && WrednySmiech_ok == true && AktywujSmiech_ok == false
                    MonsterStajnia_trigger();
                }
            }
        }

        // jumpscare kamping

        if (inventoryScript.isSecretRoomKeyTaken == true && isSecretRoomMonster == false)
        {

            if (Input.GetMouseButtonUp(0) && Time.timeScale == 1)
            {
                playerCam = Camera.main;
                Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9))
                {

                    if (hit.collider.gameObject.name == "Odtwarzacz" && isSecretRoomMonster == false)
                    {
                        MonsterKampingFunction();
                    }

                }

            }
        }


        // jumpscare potok

        if (inventoryScript.isAliceKeyTaken == true && isBrookMonster1_On == false && counter1 < 2){
			counter1 += 1 * Time.deltaTime;
		}

		if(counter1 >= 2 && isBrookMonster1_On == false){
			brookMonster1.SetActive(true);
			brookMonster1.gameObject.GetComponent<MonsterPotok1> ().enabled = true;
			isBrookMonster1_On = true;
		}

        // jumpscare monster kukurydza babcia

		if(inventoryScript.isAxeTaken == true && isCornfieldMonster == false){
			staticCornfieldMonster.SetActive(false);
			cornfieldMonster.SetActive(true);
			cornfieldMonster.GetComponent<Monster2_v1> ().enabled = true;
			isCornfieldMonster = true;
		}

        // jumpscare monster dynia

		if (notesScript.isNote34 == true && isPumpkinMonster_On == false && isPumpkinMonster_Off == false) {
			pumpkinMonster.SetActive (true);
			pumpkinMonster.gameObject.GetComponent<Monster1_Dynia> ().enabled = true;
			isPumpkinMonster_On = true;
		}

        // potwor opuszczony

		if (isAbandonedMonster == true && abandonedMonsterTime < 3 && isAbandonedMonsterStop == false) {
            abandonedMonsterTime += 1 * Time.deltaTime; 
        }

        if(abandonedMonsterTime >= 1.2f && isAbandonedMonsterStop == false)
        {
            healthScript.health = 40;
            isAbandonedMonsterStop = true;
        }
			
        // Wlaczanie potwora krzaki przy Stevenie

        if(notesScript.isNote44 == true && isBushMonster_On == false)
        {
            bushMonster.SetActive(true);
			bushMonster.gameObject.GetComponent<Monster1_Krzaki> ().enabled = true;
            isBushMonster_On = true;
        }

        // Wylaczanie potwora krzaki przy Stevenie

        if(inventoryScript.isStrongAcidTaken == true && isBushMonster_Off == false)
        {
            bushMonster.SetActive(false);
            isBushMonster_Off = true;
        }

        // jumpscare pajak 2

        if(nicheDoorSoundScript.isOpen == true && isJumpscareSpider2 == false)
        {
            PajakJumpscare2_function();
        }

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isPlaySound == false) {

            corridorMonsterAudioSource.Pause();
            channelMonsterAudioSource.Pause();
            paulDownstairsMonsterAudioSource.Pause();
            stevenShedMonster2_AudioSource.Pause();
            breathAudioSource.Pause();
            paulRoomMonsterAudioSource.Pause();
            plantMonsterAudioSource.Pause();
            abandonedMonsterAudioSource.Pause();
            shedMonster1_AudioSource.Pause();
            beginMonsterAudioSource.Pause();
            beginWolfAudioSource.Pause();
            stableMonsterAudioSource.Pause();
            spider4_AudioSource.Pause();
            spider4_JumpscareAudioSource.Pause();

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && isPlaySound == true) {

            corridorMonsterAudioSource.UnPause();
            channelMonsterAudioSource.UnPause();
            paulDownstairsMonsterAudioSource.UnPause();
            stevenShedMonster2_AudioSource.UnPause();
            breathAudioSource.UnPause();
            paulRoomMonsterAudioSource.UnPause();
            plantMonsterAudioSource.UnPause();
            abandonedMonsterAudioSource.UnPause();
            shedMonster1_AudioSource.UnPause();
            beginMonsterAudioSource.UnPause();
            beginWolfAudioSource.UnPause();
            stableMonsterAudioSource.UnPause();
            spider4_AudioSource.UnPause();
            spider4_JumpscareAudioSource.UnPause();

            isPlaySound = false;
        }
	}

	void OnTriggerExit(Collider other){

		if (other.gameObject.CompareTag("MonsterPotokWylacz_trigger") && isBrookMonster1_Off == false && inventoryScript.isAliceKeyTaken == true) {
			MonsterPotokWylacz_trigger ();
        }

		else if (other.gameObject.CompareTag("MonsterKorytarz_trigger") && isCorridorMonster == false && inventoryScript.isWardrobeCorridorKeyTaken == true) {
			MonsterKorytarz_trigger ();
        }
		else if (other.gameObject.CompareTag("MuzykaKlimat10_trigger") && inventoryScript.isShedCupboardKeyTaken == true && isCorridorMonster == true)
        {
			MuzykaKlimat10Korytarz_trigger ();
        }

		else if (other.gameObject.CompareTag("Monster5Wlacz_trigger") && isCornfieldMonster2 == false && tasksScript.isTomCornifieldTask == true){
			Monster5Wlacz_trigger ();
		}

		else if(other.gameObject.CompareTag("Monster5Wylacz_trigger") && isCornfieldMonster2 == true){
			Monster5Wylacz_trigger ();
		}

		else if(other.gameObject.CompareTag("MonsterKoryto_trigger") && isChannelMonster == false && tasksScript.isGoRavineTask == true){
			MonsterKoryto_trigger ();
		}

		else if(other.gameObject.CompareTag("MonsterPokojZachod_trigger") && isPaulRoomMonster == false && paulDoorMonster.activeSelf == false && paulDownstairsMonster.activeSelf == false){
			MonsterPokojZachod_trigger ();
		}

		else if(other.gameObject.CompareTag("MonsterDrzwiZachod_trigger") && isPaulDoorMonster == false && paulDoorSoundScript.isOpen == false && isPaulDownstairsMonster == false){
			MonsterDrzwiZachod_trigger ();
		}

        else if (other.gameObject.CompareTag("MonsterDrzwiZachodWylacz_trigger") && isPaulDoorMonster == true && paulDoorMonsterScript.DrzwiMonsterZachod_ok == false)
        {
            MonsterDrzwiZachodWylacz_trigger();
        }

		else if(other.gameObject.CompareTag("MonsterWarsztat_trigger") && isWorkshopMonster == false){
			MonsterWarsztat_trigger ();

		}

		else if(other.gameObject.CompareTag("MonsterDyniaWylacz_trigger") && isPumpkinMonster_On == true && inventoryScript.isPumpkinTaken == true && isPumpkinMonster_Off == false){
			MonsterDyniaWylacz_trigger ();
		}

		else if (other.gameObject.CompareTag("MonsterOpuszczony1_trigger") && isAbandonedMonster == false && inventoryScript.isOldWardrobeKeyTaken == true)
        {
			MonsterOpuszczony1_trigger ();
        }
		
		else if (other.gameObject.CompareTag("MonsterSzopa1_trigger") && isShedMonster1 == false && inventoryScript.isShedCupboardKeyTaken == true)
        {
			MonsterSzopa1_trigger ();
        }
		else if (other.gameObject.CompareTag("MuzykaKlimat10_trigger") && inventoryScript.isCassete2Taken == true && isShedMonster1 == true)
        {
			MuzykaKlimat10Szopa_trigger ();
        }
		else if (other.gameObject.CompareTag("MonsterTom_trigger") && isTomMonster == false && tasksScript.isCassete3Played == true)
        {
			MonsterTom_trigger ();
        }
		else if (other.gameObject.CompareTag("IdzWawoz_trigger") && isTomMonster == true)
        {
			IdzWawoz_trigger ();
        }
		
		else if (other.gameObject.CompareTag("MuzykaKlimat22_trigger") && paulDownstairsMonster.activeSelf == true && notesScript.isNote53 == true)
        {
			//MuzykaKlimat22_trigger ();
        }

		else if (other.gameObject.CompareTag("MuzykaKlimat21_trigger") && stevenShedMonster1.activeSelf == false && inventoryScript.isStrongAcidTaken == true)
        {
			MuzykaKlimat21Steven_trigger ();
        }

		else if (other.gameObject.CompareTag("MuzykaKlimat21Wylacz_trigger") && stevenShedMonster1.activeSelf == true && inventoryScript.isStrongAcidTaken == true)
        {
			MuzykaKlimat21StevenWylacz_trigger ();
        }

		else if (other.gameObject.CompareTag("MonsterSzopaSteven_trigger") && stevenShedMonster2.activeSelf == false && inventoryScript.isStrongAcidTaken == true && isStevenShedMonster2 == false)
        {
			MonsterSzopaSteven_trigger ();
        }

		else if (other.gameObject.CompareTag("MuzykaKlimat21_trigger") && stevenShedMonster2.activeSelf == true && inventoryScript.isStrongAcidTaken == true && isStevenShedMonster2 == true)
        {
			MuzykaKlimat21Steven2Wylacz_trigger ();
        }

		else if (other.gameObject.CompareTag("MuzykaKlimat21_trigger") && stevenShedMonster2.activeSelf == false && inventoryScript.isStrongAcidTaken == true && isStevenShedMonster2 == true)
        {
			MuzykaKlimat21Steven2_trigger ();
        }

		else if ((other.gameObject.CompareTag("MonsterSzopaStevenBezpieczny_trigger") || other.gameObject.CompareTag("MonsterSzopaBezpieczny_trigger") || other.gameObject.CompareTag("MonsterOgrodBezpieczny_trigger"))  && isPlayerSave == true)
        {
            isPlayerSave = false;
        }

        else if (other.gameObject.CompareTag("MonsterPoczatek_trigger") && isBeginMonster == false)
        {
            MonsterPoczatek_trigger();
        }

        else if (other.gameObject.CompareTag("Wilk1_trigger") && isWolf1 == true)
        {
            Wilk1Function_wylacz();
        }

        else if (other.gameObject.CompareTag("Wilk2_trigger") && isWolf2 == true)
        {
            Wilk2Function_wylacz();
        }

        else if (other.gameObject.CompareTag("Wilk3_trigger") && isWolf3 == true)
        {
            Wilk3Function_wylacz();
        }

        else if (other.gameObject.CompareTag("Pajak5_trigger") && isSpider5 == true)
        {
            Pajak5Function_wylacz();
        }
    }

    void OnTriggerEnter(Collider other)
    {
		if ((other.gameObject.CompareTag("MonsterSzopaStevenBezpieczny_trigger") || other.gameObject.CompareTag("MonsterSzopaBezpieczny_trigger") || other.gameObject.CompareTag("MonsterOgrodBezpieczny_trigger")) && isPlayerSave == false)
        {
            isPlayerSave = true;
        }

        else if (other.gameObject.CompareTag("MonsterKukurydzaWylacz_trigger"))
        {
            MonsterKukurydzaWylacz_trigger();
        }

        else if (other.gameObject.CompareTag("MonsterOgrod_trigger") && isGardenMonster == false)
        {
            MonsterOgrod_trigger();
        }

        else if (other.gameObject.CompareTag("MonsterOgrodWylacz_trigger") && isGardenMonster == true)
        { // && Inventory.KluczKamping_ok == true
            MonsterOgrodWylacz_trigger();
        }

        else if (other.gameObject.CompareTag("MonsterWarsztatWylacz_trigger") && isWorkshopMonster == true)
        {
            MonsterWarsztatWylacz_trigger();
        }

        else if (other.gameObject.CompareTag("WilkPoczatek_trigger") && isBeginWolves == false)
        { 
            WilkPoczatek_trigger();
        }

        else if (other.gameObject.CompareTag("PajakJmp1_trigger") && isJumpscareSpider1 == false && tasksScript.isSearchTask == true && tasksScript.isWoodKeyTask == false)
        { 
            PajakJumpscare1_trigger();
        }

        else if (other.gameObject.CompareTag("Pajak3_trigger") && isSpider3_On == false)
        {
            Pajak3_trigger();
        }

        else if (other.gameObject.CompareTag("SzopaMeble_trigger") && isSpider3_Off == false)
        {
            Pajak3Wylacz_trigger();
        }

        else if ((other.gameObject.CompareTag("SkrzypienieSchody_trigger") || other.gameObject.CompareTag("MuzykaKlimatStop18_trigger")) && isAbandonedMonster == true && abandonedMonster.activeSelf)
        {
            SkrzypienieSchodyWylacz_trigger();
        }
        else if ((other.gameObject.CompareTag("SkrzypienieSchodyWylacz_trigger") || other.gameObject.CompareTag("MuzykaKlimat18_trigger")) && isAbandonedMonster == true && !abandonedMonster.activeSelf)
        {
            SkrzypienieSchody_trigger(); // na odwrot bo w skrypcie screamer tak wlaczamy/wylaczamy skrzypienie schody i potwora przy wczytaniu gry
        }

        else if (other.gameObject.CompareTag("MonstersLasMieso_trigger") && isMeatMonsters == false && tasksScript.isStevenKeyTask == true)
        {
            MonstersLasMieso_trigger();
        }

        else if (other.gameObject.CompareTag("MonstersLasMiesoWylacz_trigger") && isMeatMonsters == true)
        {
            MonstersLasMiesoWylacz_trigger();
        }

        else if (other.gameObject.CompareTag("ZachodGora_trigger") && isPaulDownstairsMonster == false && notesScript.isNote53 == true)
        {
            ZachodGora_trigger();
        }

        else if (other.gameObject.CompareTag("Pajak4_trigger") && isSpider4 == false && tasksScript.isGoTrailTask == true)
        {
            Pajak4_trigger();
        }

        else if (other.gameObject.CompareTag("Wilk1_trigger") && isWolf1 == false && tasksScript.isWellStonesTask == true)
        {
            Wilk1Function();
        }

        else if (other.gameObject.CompareTag("Wilk2_trigger") && isWolf2 == false && tasksScript.isWellStonesTask == true)
        {
            Wilk2Function();
        }

        else if (other.gameObject.CompareTag("Wilk3_trigger") && isWolf3 == false && tasksScript.isWellStonesTask == true)
        {
            Wilk3Function();
        }

        else if (other.gameObject.CompareTag("Pajak5_trigger") && isSpider5 == false && tasksScript.isTomSearchTask == true)
        {
            Pajak5Function();
        }

    }


	public void MonsterPotokWylacz_trigger(){

		brookMonster1.SetActive(false);
		brookMonster1.gameObject.GetComponent<MonsterPotok1> ().enabled = false;
		isBrookMonster1_Off = true;
        musicScript.isMusicOff = true;
        mapScript.isFastTravel = true;
	}
		

	public void MonsterKukurydzaWylacz_trigger(){

		//MonsterKukurydza.gameObject.transform.position = new Vector3(PunktMonsterKukurydza.transform.position.x, PunktMonsterKukurydza.transform.position.y, PunktMonsterKukurydza.transform.position.z);
		cornfieldMonster.SetActive(false);
		cornfieldMonster.GetComponent<Monster2_v1> ().enabled = false;
        musicScript.isMusicOff = true;
        musicScript.isCornfield1Music = false;
        mapScript.isFastTravel = true;
    }

	public void MonsterKorytarz_trigger(){

		corridorMonster.SetActive(true);
		corridorMonster.GetComponent<Monster2_v2> ().enabled = true;
		isCorridorMonster = true;
        //ZrodloDzwieku.PlayOneShot(DzwJmpKorytarz);
        corridorMonsterAudioSource.clip = corridorMonsterSound;
        corridorMonsterAudioSource.Play();

	}

	public void MuzykaKlimat10Korytarz_trigger(){

		corridorMonster.SetActive(false);
		corridorMonster.GetComponent<Monster2_v2> ().enabled = false;
        mapScript.isFastTravel = true;
    }

	public void Monster5Wlacz_trigger(){

		cornfieldMonster2.SetActive(true);
		cornfieldMonster2.GetComponent<Monster2_v3> ().enabled = true;
		isCornfieldMonster2 = true;
        musicScript.KlimatKukurydza1();

	}

	public void Monster5Wylacz_trigger(){

		cornfieldMonster2.SetActive(false);
		cornfieldMonster2.transform.position = new Vector3(cornfieldMonster2ResetPoint.transform.position.x, cornfieldMonster2ResetPoint.transform.position.y, cornfieldMonster2ResetPoint.transform.position.z);
		isCornfieldMonster2 = false;
		cornfieldMonster2.GetComponent<Monster2_v3> ().enabled = false;
        musicScript.isMusicOff = true;
        mapScript.isFastTravel = true;
    }

	public void MonsterKoryto_trigger(){

		channelMonster.SetActive(true);
		channelMonster.GetComponent<MonsterKoryto> ().enabled = true;
        //ZrodloDzwKoryto.PlayOneShot(DzwJmpKoryto);
        channelMonsterAudioSource.clip = channelMonsterSound;
        channelMonsterAudioSource.Play();
        isChannelMonster = true;

	}

	public void MonstersLasMieso_trigger(){

        meatMonster1.transform.position = new Vector3(2382.1f, 75.56f, 2171.8f);
        meatMonster2.transform.position = new Vector3(2371.73f, 75.77f, 2213.46f);
        meatMonster1.SetActive(true);
		meatMonster1.GetComponent<Monster1_v3> ().enabled = true;
		meatMonster2.SetActive(true);
		meatMonster2.GetComponent<Monster1_v4> ().enabled = true;
		isMeatMonsters = true;

	}

	public void MonstersLasMiesoWylacz_trigger(){

		meatMonster1.SetActive(false);
		meatMonster1.GetComponent<Monster1_v3> ().isSawPlayer = false;
		meatMonster1.GetComponent<Monster1_v3> ().isRayPlayer = false;
		meatMonster1.GetComponent<Monster1_v3> ().isSawLight = false;
		meatMonster1.GetComponent<Monster1_v3> ().enabled = false;
		meatMonster2.SetActive(false);
		meatMonster2.GetComponent<Monster1_v4> ().Widzi_ok = false;
		meatMonster2.GetComponent<Monster1_v4> ().WidzialGracza_ok = false;
		meatMonster2.GetComponent<Monster1_v4> ().WidzialSwiatlo_ok = false;
		meatMonster2.GetComponent<Monster1_v4> ().enabled = false;
        isMeatMonsters = false;
        mapScript.isFastTravel = true;
    }

	public void MonsterPokojZachod_trigger(){

		paulRoomMonster.SetActive(true);
		paulRoomMonster.GetComponent<MonsterPokojZachod> ().enabled = true;
        //ZrodloDzwPokojZachod.PlayOneShot(DzwJmpPokojZachod);
        paulRoomMonsterAudioSource.clip = paulRoomMonsterSound;
        paulRoomMonsterAudioSource.Play();
        isPaulRoomMonster = true;

	}

	public void MonsterDrzwiZachod_trigger(){

		paulDoorMonster.SetActive(true);
		paulDoorMonster.GetComponent<MonsterDrzwiZachod> ().enabled = true;
		//MonsterZachodDol.SetActive (false);
		//MonsterZachodDol.gameObject.GetComponent<MonsterZachod_dol> ().enabled = false;
		isPaulDoorMonster = true;

	}

    public void MonsterDrzwiZachodWylacz_trigger()
    {

        paulDoorMonster.SetActive(false);
        paulDoorMonster.GetComponent<MonsterDrzwiZachod>().enabled = false;
        mapScript.isFastTravel = true;
        //MonsterZachodDol.SetActive(false);
        //MonsterZachodDol.gameObject.GetComponent<MonsterZachod_dol>().enabled = false;

    }

    public void MonsterOgrod_trigger(){

		gardenMonster.SetActive(true);
		gardenMonster.GetComponent<Monster1_v1> ().enabled = true; 
		isGardenMonster = true;

	}

	public void MonsterOgrodWylacz_trigger(){

		gardenMonster.gameObject.transform.position = new Vector3(gardenMonsterPoint.transform.position.x, gardenMonsterPoint.transform.position.y, gardenMonsterPoint.transform.position.z);
		gardenMonster.SetActive(false);
		isGardenMonster = false;
		gardenMonster.GetComponent<Monster1_v1> ().enabled = false;
        mapScript.isFastTravel = true;
    }

	public void MonsterWarsztat_trigger(){

		workshopMonster.SetActive(true);
		workshopMonster.GetComponent<Monster1_v2> ().enabled = true;
		isWorkshopMonster = true;

	}

	public void MonsterWarsztatWylacz_trigger(){

		workshopMonster.gameObject.transform.position = new Vector3(workshopMonsterPoint.transform.position.x, workshopMonsterPoint.transform.position.y, workshopMonsterPoint.transform.position.z);
		workshopMonster.SetActive(false);
		isWorkshopMonster = false;
		workshopMonster.GetComponent<Monster1_v2> ().enabled = false;
        mapScript.isFastTravel = true;
    }

	public void MonsterDyniaWylacz_trigger(){

		pumpkinMonster.SetActive(false);
		isPumpkinMonster_Off = true;
		pumpkinMonster.gameObject.GetComponent<Monster1_Dynia> ().enabled = false;
        mapScript.isFastTravel = true;
    }

	public void MonsterOpuszczony1_trigger(){

		abandonedMonster.SetActive(true);
		abandonedMonster.GetComponent<MonsterOpuszczony> ().enabled = true;
        //ZrodloDzwRyk1.PlayOneShot(DzwMonsterOpuszczonyRyk1);
        abandonedMonsterAudioSource.clip = abandonedMonsterSound;
        abandonedMonsterAudioSource.Play();
        isAbandonedMonster = true;

	}

	public void SkrzypienieSchodyWylacz_trigger(){

		abandonedMonster.SetActive(false);
		//MonsterOpuszczony.gameObject.transform.position = new Vector3(PunktMonsterOpuszczony.transform.position.x, PunktMonsterOpuszczony.transform.position.y, PunktMonsterOpuszczony.transform.position.z);
		abandonedMonster.GetComponent<MonsterOpuszczony> ().enabled = false;
        mapScript.isFastTravel = true;
    }

	public void SkrzypienieSchody_trigger(){

		abandonedMonster.SetActive(true);
		abandonedMonster.GetComponent<MonsterOpuszczony> ().enabled = true;

        int LosujPunktOpuszczony = Random.Range(1, 4);

        if(LosujPunktOpuszczony == 1)
        {
            abandonedMonster.gameObject.transform.position = new Vector3(abandonedMonsterPoint1.transform.position.x, abandonedMonsterPoint1.transform.position.y, abandonedMonsterPoint1.transform.position.z);
        }

        else if (LosujPunktOpuszczony == 2)
        {
            abandonedMonster.gameObject.transform.position = new Vector3(abandonedMonsterPoint2.transform.position.x, abandonedMonsterPoint2.transform.position.y, abandonedMonsterPoint2.transform.position.z);
        }

        else if (LosujPunktOpuszczony == 3)
        {
            abandonedMonster.gameObject.transform.position = new Vector3(abandonedMonsterPoint3.transform.position.x, abandonedMonsterPoint3.transform.position.y, abandonedMonsterPoint3.transform.position.z);
        }


    }

	public void MonsterSzopa1_trigger(){

        //ZrodloDzwSzopa1.PlayOneShot(DzwMonsterSzopa1);
        shedMonster1_AudioSource.clip = shedMonster1_Sound;
        shedMonster1_AudioSource.Play();
        //ZrodloDzwOddech.PlayOneShot(DzwOddech);
        breathAudioSource.clip = breathSound;
        breathAudioSource.Play();
        shedMonster1.SetActive(true);
		shedMonster1.GetComponent<Monster1_Szopa1> ().enabled = true;
		isShedMonster1 = true;

	}

	public void MuzykaKlimat10Szopa_trigger(){

		shedMonster1.SetActive(false);
		shedMonster1.GetComponent<Monster1_Szopa1> ().enabled = false;
        mapScript.isFastTravel = true;
    }

	public void MonsterTom_trigger(){

		tomMonster.SetActive(true);
		tomMonster.GetComponent<Monster1_Tom> ().enabled = true;
		isTomMonster = true;

	}

	public void IdzWawoz_trigger(){

		tomMonster.SetActive(false);
		tomMonster.GetComponent<Monster1_Tom> ().enabled = false;
        mapScript.isFastTravel = true;
    }

	public void ZachodGora_trigger(){

		paulDownstairsMonster.SetActive(true);
		paulDownstairsMonster.gameObject.GetComponent<MonsterZachod_dol> ().enabled = true;
		paulDoorMonster.SetActive (false);
		paulDoorMonster.GetComponent<MonsterDrzwiZachod> ().enabled = false;
        //ZrodloDzwMonsterJmp.PlayOneShot(DzwMonsterJmp);
        paulDownstairsMonsterAudioSource.clip = paulDownstairsMonsterSound;
		paulDownstairsMonsterAudioSource.Play();
		paulDownstairsMonsterAudioSource.time = 0.070f;
		isPaulDownstairsMonster = true;

	}

	public void MuzykaKlimat22_trigger(){

		paulDownstairsMonster.SetActive(false);
		paulDownstairsMonster.gameObject.GetComponent<MonsterZachod_dol> ().enabled = false;
        mapScript.isFastTravel = true;
    }

	public void MuzykaKlimat21Steven_trigger(){

		stevenShedMonster1.SetActive(true);
		stevenShedMonster1.gameObject.GetComponent<Monster1_SzopaSteven1> ().enabled = true;
		isStevenShedMonster1 = true;
        musicScript.KlimatStevenSzopa2();
	}

	public void MuzykaKlimat21StevenWylacz_trigger(){

		stevenShedMonster1.SetActive(false);
		isStevenShedMonster1 = false;
		stevenShedMonster1.gameObject.transform.position = new Vector3(stevenShedMonster1Point.transform.position.x, stevenShedMonster1Point.transform.position.y, stevenShedMonster1Point.transform.position.z);
		stevenShedMonster1.gameObject.GetComponent<Monster1_SzopaSteven1> ().enabled = false;
        musicScript.isMusicOff = true;
        mapScript.isFastTravel = true;
    }

	public void MonsterSzopaSteven_trigger(){

		stevenShedMonster2.SetActive(true);
		stevenShedMonster2.gameObject.GetComponent<Monster1_SzopaSteven2> ().enabled = true;
		isStevenShedMonster2 = true;
        //ZrodloDzwMonsterSteven.PlayOneShot(DzwMonsterSteven);
        stevenShedMonster2_AudioSource.clip = stevenShedMonster2_sound;
        stevenShedMonster2_AudioSource.Play();

    }

	public void MuzykaKlimat21Steven2Wylacz_trigger(){

		stevenShedMonster2.SetActive(false);
		stevenShedMonster2.gameObject.GetComponent<Monster1_SzopaSteven2> ().enabled = false;
        mapScript.isFastTravel = true;
    }

	public void MuzykaKlimat21Steven2_trigger(){

		stevenShedMonster2.SetActive(true);
		stevenShedMonster2.gameObject.GetComponent<Monster1_SzopaSteven2> ().enabled = true;

	}

    public void MonsterPoczatek_trigger()
    {

        beginMonster.SetActive(true);
        beginMonster.gameObject.GetComponent<MonsterPoczatek>().enabled = true;
        isBeginMonster = true;
        beginMonsterAudioSource.clip = beginMonsterSound;
        beginMonsterAudioSource.Play();

    }

    public void MonsterStajnia_trigger()
    {

        //MonsterStajnia.SetActive(true);
        musicScript.KlimatNiepokojStajnia();
        isStableMonster = true;
        stableMonsterAudioSource.clip = stableMonsterSound;
        stableMonsterAudioSource.Play();
        stableMonsterAnimator.SetTrigger("MonsterStajnia");
    }

    public void MonsterKampingFunction()
    {

        secretRoomMonster.SetActive(true);
        isSecretRoomMonster = true;
        secretRoomMonsterAnimator.SetTrigger("MonsterKamping");
    }

    public void Wilk1Function()
    {

        wolf1.SetActive(true);
        wolf1.gameObject.GetComponent<Wolf_v1>().enabled = true;
        wolf2.SetActive(true);
        wolf2.gameObject.GetComponent<Wilk_v2>().enabled = true;
        wolf3.SetActive(true);
        wolf3.gameObject.GetComponent<Wilk_v3>().enabled = true; 

    }

    public void Wilk1Function_wylacz()
    {

        wolf1.SetActive(false);
        wolf1.gameObject.GetComponent<Wolf_v1>().enabled = false;

    }

    public void Wilk2Function()
    {

         wolf2.SetActive(true);
         wolf2.gameObject.GetComponent<Wilk_v2>().enabled = true;

    }

    public void Wilk2Function_wylacz()
    {

        wolf2.SetActive(false);
        wolf2.gameObject.GetComponent<Wilk_v2>().enabled = false;

    }

    public void Wilk3Function()
    {

        wolf3.SetActive(true);
        wolf3.gameObject.GetComponent<Wilk_v3>().enabled = true;

    }

    public void Wilk3Function_wylacz()
    {

        wolf3.SetActive(false);
        wolf3.gameObject.GetComponent<Wilk_v3>().enabled = false;

    }

    public void WilkPoczatek_trigger()
    {

        beginWolf1.SetActive(true);
        beginWolf1.gameObject.GetComponent<WilkPoczatek>().enabled = true;
        beginWolf2.SetActive(true);
        beginWolf2.gameObject.GetComponent<WilkPoczatek>().enabled = true;
        isBeginWolves = true;
        beginWolfAudioSource.clip = beginWolfSound;
        beginWolfAudioSource.Play();

    }

    public void PajakJumpscare1_trigger()
    {

        jumpscareSpider1.SetActive(true);
        jumpscareSpider1.gameObject.GetComponent<PajakJmp1>().enabled = true;
        isJumpscareSpider1 = true;

    }

    public void PajakJumpscare2_function()
    {

        jumpscareSpider2.SetActive(true);
        jumpscareSpider2.gameObject.GetComponent<PajakJmp1>().enabled = true;
        isJumpscareSpider2 = true;

    }

    public void Pajak3_trigger()
    {

        spider3.SetActive(true);
        spider3.gameObject.GetComponent<Spider_v3>().enabled = true;
        isSpider3_On = true;

    }

    public void Pajak3Wylacz_trigger()
    {

        spider3.gameObject.GetComponent<Spider_v3>().isSpiderOff = true;
        isSpider3_On = true;

    }

    public void Pajak4_trigger()
    {

        spider4.SetActive(true);
        spider4.gameObject.GetComponent<Pajak_v4>().enabled = true;
        isSpider4 = true;
        spider4_AudioSource.clip = spider4_Sound;
        spider4_AudioSource.Play();
        spider4_JumpscareAudioSource.clip = spider4_JumpscareSound;
        spider4_JumpscareAudioSource.Play();

    }

    public void Pajak5Function()
    {

        spider5.SetActive(true);
        spider5.gameObject.GetComponent<Pajak_v5>().enabled = true;

    }

    public void Pajak5Function_wylacz()
    {

        spider5.SetActive(true);
        spider5.gameObject.GetComponent<Pajak_v4>().enabled = true;

    }

}
