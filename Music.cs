using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	private Notes notesScript;
	private Inventory inventoryScript;
	private Screamer screamerScript;
	private Tasks tasksScript;
	private Jumpscare jumpscareScript;
	public Monster2_v3 cornfieldMonsterScript;
    public Monster1_SzopaSteven1 stevenMonster1_Script;
    public Monster1_SzopaSteven2 stevenMonster2_Script;
	public Monster1_v3 meatMonsterScript;
	private VoiceActing voiceActingScript;
	private TaskBones bonesTaskScript;
	private TaskBooks booksTaskScript;
    private MonsterPotok1 brookMonsterScript;
    private Map mapScript;

    public AudioSource[] musicAudioSources;
    public AudioSource backgroundAudioSource1;
	public AudioSource backgroundAudioSource2;
	public AudioSource backgroundAudioSource3;
	public AudioSource monsterBackgroundAudioSource1;
	public AudioSource monsterBackgroundAudioSource2;

	public float randomMusicDuration = 0;
	public bool isMusicOff = false;

	public bool isHouseLightMusicOff = false;
	public bool isSimonWorkshopMusicOff = false;
    public bool isOldShedMusicOff = false;
    public bool isOldShedMusic2Off = false;
	public bool isAfterTomMusicOff = false;

	public AudioClip bacgroundMusic1;
	public AudioClip bacgroundMusic2;
	public AudioClip bacgroundMusic3;
	public AudioClip bacgroundMusic4;
	public AudioClip bacgroundMusic5;
	public AudioClip bacgroundMusic6;
	public AudioClip bacgroundMusic7;
	public AudioClip bacgroundMusic8;
	public AudioClip bacgroundMusic9;
	public AudioClip bacgroundMusic10;
	public AudioClip bacgroundMusic11;
	public AudioClip bacgroundMusic12;
	public AudioClip bacgroundMusic13;
	public AudioClip bacgroundMusic14;
	public AudioClip bacgroundMusic15;
	public AudioClip bacgroundMusic16;
    public AudioClip bacgroundMusic17;
    public AudioClip bacgroundMusic18;
    public AudioClip bacgroundMusic19;
    public AudioClip bacgroundMusic20;
	public AudioClip bacgroundMusic21;
	public AudioClip bacgroundMusic22;
	public AudioClip bacgroundMusic23;
	public AudioClip bacgroundMusic24;
	public AudioClip bacgroundMusic25;
	public AudioClip bacgroundMusic26;
	public AudioClip bacgroundMusic27;
	public AudioClip bacgroundMusic28;
	public AudioClip bacgroundMusic29;
    public AudioClip beginMusic;
    public AudioClip beginMonsterMusic;
    public AudioClip mysteryMusic;
    public AudioClip violinMusic;
    public AudioClip cornfieldMusic;
    public AudioClip shudderMusic;
    public AudioClip epicMusic;
    public AudioClip longEpicMusic;
    public AudioClip anxiousMusic;
    public AudioClip anxiousMusic2;
    public AudioClip deepAmbienceMusic;

    public AudioClip[] actionMusics;
    public int randomMusicActionIndex;


    public AudioClip monsterMusic1;
	public AudioClip monsterMusic2;
	public AudioClip monsterMusic3;
	public AudioClip monsterMusic4;
	public AudioClip monsterMusic5;
	public AudioClip monsterMusic6;

    public bool isBeginMusic = false;
    public bool isBeginMonsterMusic = false;
    public bool isBeginMonsterMusicStop = false;
    public bool isAfterWolfMusic = false;
    public bool isBehindHouseMusic = false;
	public bool isKitchenMusic = false;
	public bool isUncleRoomMusic = false;
	public bool isMusicStop = false;
	public bool isToolShedMusic = false;
	public bool isWellMusic = false;
	public bool isWellAnxiousMusic = false;
	public bool isStableMusic = false;
	public bool isGardenMusic = false;
	public bool isBonesMusic = false;
	public bool isAliceMusic = false;
	public bool isAliceShedMusic = false;
	public bool isWorkshopMusic = false;
	public bool isWorkshopSimonMusic = false;
	public bool isAnimalCemetaryMusic = false;
	public bool isAliceRoomMusic = false;
	public bool isShedMusic = false;
	public bool isOldShedMusic = false;
	public bool isBeforeTomMusic = false;
	public bool isTomMusic = false;
	public bool isTomHallMusic = false;
	public bool isTom2Music = false;
	public bool isBooksMusic = false;
	public bool isTom3Music = false;
	public bool isCornfieldMusic = false;
	public bool isTomCampMusic = false;
	//public bool KlimatOboz2_ok = false;
	public bool isTomUpstairsMusic = false;
	public bool isTomUpstairs2Music = false;
	public bool isAfterTomMusic = false;
	public bool isFeederMusic = false;
	public bool isBeforeStevenMusic = false;
	public bool isStevenMusic = false;
	public bool isMeatMusic = false;
	public bool isStevenUpstairsMusic = false;
	public bool isStevenShedMusic = false;
	public bool isBeforePaulMusic = false;
	public bool isPaulMusic = false;
	public bool isPaulUpstairsMusic = false;
	public bool isHutMusic = false;
    public bool isMonsterUpstairsMusic = false;
    public bool isMonsterUpstairs2Music = false;
	public bool isBeforeShelterMusic = false;
    public bool isShelterMusic = false;
    public bool isShelter2Music = false;
	public bool isEndGameMusic = false;
    public bool isBigRoomMusic = false;
    public bool isLeftBrookMusic = false;
    public bool isCornfield1Music = false;
    public bool isAfterFlashlightMusic = false;
    public bool isGrandmaDoorMusic = false;

    public bool isGardenMonsterMusic = false;
	public bool isGardenMonsterMusic_On = false;
	public bool isWorkshopMonsterMusic = false;
	public bool isWorkshopMonsterMusic_On = false;
	public bool isLeftBrookMonsterMusic = false;
	public bool isLeftBrookMonsterMusic_On = false;
	public bool isCorridorMonsterMusic = false;
	public bool isCorridorMonsterMusic_On = false;
	public bool isCornfieldMonsterMusic = false;
	public bool isCornfieldMonsterMusic_On = false;
	public bool isPumpkinMonsterMusic = false;
	public bool isPumpkinMonsterMusic_On = false;
	public bool isAbandonedMonsterMusic = false;
	public bool isAbandonedMonsterMusic_On = false;
	public bool isMeatMonsterMusic = false;
	public bool isMeatMonsterMusic_On = false;
    public bool isBasementMonsterMusic = false;
    public bool isPlantMonsterMusic = false;
    public bool isStevenMonsterMusic = false;




    void OnEnable () {

		notesScript = GameObject.Find ("Player").GetComponent<Notes> ();
		inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();
		screamerScript = GameObject.Find ("Player").GetComponent<Screamer> ();
		tasksScript = GameObject.Find ("Player").GetComponent<Tasks> ();
		jumpscareScript = GameObject.Find ("Player").GetComponent<Jumpscare> ();
		voiceActingScript = GameObject.Find ("Player").GetComponent<VoiceActing> ();
		bonesTaskScript = GameObject.Find ("KoliderKosci").GetComponent<TaskBones> ();
		booksTaskScript = GameObject.Find ("Player").GetComponent<TaskBooks> ();
        mapScript = GameObject.Find("Player").GetComponent<Map>();

        cornfieldMonsterScript = GameObject.Find("Monster2_v3").GetComponent<Monster2_v3>();
		stevenMonster1_Script = GameObject.Find("Monster1_SzopaSteven").GetComponent<Monster1_SzopaSteven1>();
		stevenMonster2_Script = GameObject.Find("Monster1_SzopaSteven2").GetComponent<Monster1_SzopaSteven2>();
		meatMonsterScript = GameObject.Find("Monster1_v3").GetComponent<Monster1_v3>();
        brookMonsterScript = GameObject.Find("Monster1_Potok1").GetComponent<MonsterPotok1>();

        backgroundAudioSource1 = GameObject.Find ("MuzykaTlo").GetComponent<AudioSource> (); // ciche
		backgroundAudioSource2 = GameObject.Find ("MuzykaTlo2").GetComponent<AudioSource> (); // srednie
		backgroundAudioSource3 = GameObject.Find ("MuzykaTlo3").GetComponent<AudioSource> (); // glosna
		monsterBackgroundAudioSource1 = GameObject.Find ("MuzykaTloPotwory").GetComponent<AudioSource> (); // cicha
		monsterBackgroundAudioSource2 = GameObject.Find ("MuzykaTloPotwory2").GetComponent<AudioSource> (); // srednia

		cornfieldMonsterScript.gameObject.SetActive (false);
		stevenMonster1_Script.gameObject.SetActive (false);
		stevenMonster2_Script.gameObject.SetActive (false);
		meatMonsterScript.gameObject.SetActive (false);

	}
	

	void Update () {

        if (voiceActingScript.isGameBegin == true && isBeginMusic == false)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);

        }

        if(isBeginMusic == true && voiceActingScript.playerAudioSource2.isPlaying == false && isBeginMonsterMusicStop == false)
        {
            isBeginMonsterMusicStop = true;
            isMusicOff = true;

        }

        // potok lewy skrzypce

        if(jumpscareScript.isBrookMonster1_On == true && isLeftBrookMusic == false && brookMonsterScript.enabled == true)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);

        }

		if (screamerScript.wolfAudioSource.isPlaying == false && isAfterWolfMusic == false && screamerScript.isWolf == true) {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		if (notesScript.isNote13 == true && isWellMusic == false) {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		if (notesScript.isNote36 == true && isFeederMusic == false) {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		if (screamerScript.wellScreamAudioSource.isPlaying == false && screamerScript.isWellScream == true && isWellAnxiousMusic == false) {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		if(screamerScript.isKnock == true && isTomUpstairs2Music == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		if(backgroundAudioSource1.isPlaying == false && backgroundAudioSource1.clip == null && isMonsterUpstairsMusic == true && isMonsterUpstairs2Music == false)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		if (backgroundAudioSource1.isPlaying == false && backgroundAudioSource1.clip == null && isShelterMusic == true && isShelter2Music == false)
        {
            //KlimatKryjowka2();
        }

		if (jumpscareScript.isShedMonster1 == true && jumpscareScript.shedMonster1_AudioSource.isPlaying == false && isOldShedMusic == false) {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

        // Zwiekszanie glosnosci muzyki

        if (monsterBackgroundAudioSource1.volume < 0.5) {
			monsterBackgroundAudioSource1.volume = monsterBackgroundAudioSource1.volume += (Time.deltaTime / 25);
		}

		if (monsterBackgroundAudioSource2.volume < 0.5) {
			monsterBackgroundAudioSource2.volume = monsterBackgroundAudioSource1.volume += (Time.deltaTime / 25);
		}

		if (backgroundAudioSource1.volume < 1 && Time.timeScale == 1 && isMusicOff == false && backgroundAudioSource2.clip == null) {
			backgroundAudioSource1.volume = backgroundAudioSource1.volume += (Time.deltaTime / 25);
		}

		 else if (backgroundAudioSource2.volume < 1 && Time.timeScale == 1 && isMusicOff == false && backgroundAudioSource1.clip == null) {
			backgroundAudioSource2.volume = backgroundAudioSource2.volume += (Time.deltaTime / 25);
		}

		// Zmniejszanie glosnosci muzyki

		if (isMusicOff == true && Time.timeScale == 1 && backgroundAudioSource1.clip != null) {
			backgroundAudioSource1.volume = backgroundAudioSource1.volume -= (Time.deltaTime / 4);
			backgroundAudioSource1.loop = false;
		}

		if (isMusicOff == true && Time.timeScale == 1 && backgroundAudioSource2.clip != null) {
			backgroundAudioSource2.volume = backgroundAudioSource2.volume -= (Time.deltaTime / 4);
			backgroundAudioSource2.loop = false;
		}

		if (isMusicOff == true && Time.timeScale == 1 && backgroundAudioSource3.clip != null) {
			backgroundAudioSource3.volume = backgroundAudioSource3.volume -= (Time.deltaTime / 4);
			backgroundAudioSource3.loop = false;
		}

        if (isMusicOff == true && Time.timeScale == 1 && monsterBackgroundAudioSource1.clip != null)
        {
            monsterBackgroundAudioSource1.volume = monsterBackgroundAudioSource1.volume -= (Time.deltaTime / 4);
        }

        if (backgroundAudioSource1.volume <= 0 && isMusicOff == true) {
			backgroundAudioSource1.clip = null;
			isMusicOff = false;
		}

		if (backgroundAudioSource2.volume <= 0 && isMusicOff == true) {
			backgroundAudioSource2.clip = null;
			isMusicOff = false;
		}

		if (backgroundAudioSource3.volume <= 0 && isMusicOff == true) {
			backgroundAudioSource3.clip = null;
			isMusicOff = false;
		}

        if (monsterBackgroundAudioSource1.volume <= 0 && isMusicOff == true)
        {
            monsterBackgroundAudioSource1.clip = null;
            isMusicOff = false;
        }

        // Zatrzymywanie muzyki

        if (Time.timeScale == 0) {
			if (backgroundAudioSource1.clip != null) {
				backgroundAudioSource1.Pause ();
			} else if (backgroundAudioSource2.clip != null) {
				backgroundAudioSource2.Pause ();
			} else if (backgroundAudioSource3.clip != null) {
				backgroundAudioSource3.Pause ();
			}
		}

		// Wznawianie muzyki

		if (Time.timeScale == 1) {
			if (backgroundAudioSource1.clip != null) {
				backgroundAudioSource1.UnPause ();
			} else if (backgroundAudioSource2.clip != null) {
				backgroundAudioSource2.UnPause ();
			} else if (backgroundAudioSource3.clip != null) {
				backgroundAudioSource3.UnPause ();
			}
		}

		// Zatrzymawanie muzyki powtorow

		if (Time.timeScale == 0) {
			if (monsterBackgroundAudioSource1.clip != null) {
				monsterBackgroundAudioSource1.Pause ();
			} else if (monsterBackgroundAudioSource2.clip != null) {
				monsterBackgroundAudioSource2.Pause ();
			} 
		}

		// Wznawianie muzyki potworow

		if (Time.timeScale == 1) {
			if (monsterBackgroundAudioSource1.clip != null) {
				monsterBackgroundAudioSource1.UnPause ();
			} else if (monsterBackgroundAudioSource2.clip != null) {
				monsterBackgroundAudioSource2.UnPause ();
			} 
		}
			
		// muzyka bez zadania

		if(backgroundAudioSource1.clip == null && backgroundAudioSource2.clip == null && backgroundAudioSource3.clip == null && notesScript.isNote10 == true && randomMusicDuration <= 120){
			randomMusicDuration += 1 * Time.deltaTime;
		}

		if (randomMusicDuration >= 120) {
			PlayRandomMusic ();
		}

		// Danie clipu na null 

		if (backgroundAudioSource1.isPlaying == false && backgroundAudioSource1.clip != null && Time.timeScale == 1) {
			backgroundAudioSource1.clip = null;
		}

		else if (backgroundAudioSource2.isPlaying == false && backgroundAudioSource2.clip != null && Time.timeScale == 1) {
			backgroundAudioSource2.clip = null;
		}

		else if (backgroundAudioSource3.isPlaying == false && backgroundAudioSource3.clip != null && Time.timeScale == 1) {
			backgroundAudioSource3.clip = null;
		}


		// Klimat kosci

		if (bonesTaskScript.isGrille == true && isBonesMusic == false) {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }
			

		// Klimat Potwor Piwnica

        if(tasksScript.isCassete4Played == true && tasksScript.cassete4_AudioSource.isPlaying == false && isBasementMonsterMusic == false)
        {
            PotworOpuszczonyPiwnica();
        } 


		// Wylaczanie muzyki

		if (voiceActingScript.isHouseLightRecording == true && voiceActingScript.playerAudioSource2.clip == null && isHouseLightMusicOff == false) {
			isMusicOff = true;
			isHouseLightMusicOff = true;
		}

        if(inventoryScript.isWardrobeCorridorKeyTaken == true && isOldShedMusicOff == false)
        {
            isMusicOff = true;
            isOldShedMusicOff = true;
        }

	/*	if (Inventory.KluczSalonPoludnie_ok == true && WylaczWarsztatSimon_ok == false) {
			WylaczMuzyke_ok = true;
			WylaczWarsztatSimon_ok = true;
		} */

		// Muzyka potwor ogrod

		PotworOgrod ();

		// Muzyka potwor warsztat

		PotworWarsztat ();

		// Muzyka potwor potok lewy

		PotworPotokLewy ();

		// Muzyka potwor korytarz

		PotworKorytarz ();

		// Muzyka potwor kukurydza

		PotworKukurydza ();

		// Muzyka potwor dynia

		PotworDynia ();

		// Muzyka potwor opuszczony dom

		PotworOpuszczonyDom ();

		// Muzyka potwor mieso

		PotworMieso ();

        // Muzyka potwor roslina

        PotworRoslina();

        // Muzyka potwor Steven

        PotworSteven();


    }

	void OnTriggerExit(Collider other){
		
		if(other.gameObject.CompareTag("Swiatlo2_trigger") && isBehindHouseMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat1_trigger") && isUncleRoomMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat2_trigger") && isToolShedMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat3_trigger") && isStableMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat4_trigger") && isGardenMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaPotwor1_trigger") && isGardenMonsterMusic == false && tasksScript.isBonesTask == true){
			isGardenMonsterMusic = true;
		}
	
		else if(other.gameObject.CompareTag("MuzykaPotworStop1_trigger") && isGardenMonsterMusic == true && tasksScript.isBonesTask == true){
			isGardenMonsterMusic = false;
		}

		else if(other.gameObject.CompareTag("MonsterOgrod_trigger") && isGardenMonsterMusic == false && tasksScript.isBonesTask == true){
			isGardenMonsterMusic = true;
		}

		else if(other.gameObject.CompareTag("MonsterOgrodStop_trigger") && isGardenMonsterMusic == true && tasksScript.isBonesTask == true){
			isGardenMonsterMusic = false;
            mapScript.isFastTravel = true;
		}

		else if(other.gameObject.CompareTag("MuzykaKlimat6_trigger") && isAliceShedMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		if(other.gameObject.CompareTag("MuzykaKlimat7_trigger") && isWorkshopMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaPotwor2_trigger") && isWorkshopMonsterMusic == false){
			isWorkshopMonsterMusic = true;
		}

		else if(other.gameObject.CompareTag("MuzykaPotworStop2_trigger") && isWorkshopMonsterMusic == true){
			isWorkshopMonsterMusic = false;
            mapScript.isFastTravel = true;
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat8_trigger") && isWorkshopSimonMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat9_trigger") && isAliceRoomMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }
			
		else if(other.gameObject.CompareTag("MuzykaKlimat10_trigger") && isShedMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat10_trigger") && jumpscareScript.isShedMonster1 == true && isOldShedMusic2Off == false && isMusicOff == false){
			isMusicOff = true;
			isOldShedMusic2Off = true;
            mapScript.isFastTravel = true;
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat10_trigger") && jumpscareScript.isShedMonster1 == true && inventoryScript.isCassete2Taken == false && isOldShedMusic2Off == true){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
            isOldShedMusic2Off = false;
		}

		else if (other.gameObject.CompareTag("MonsterTom_trigger") && isBeforeTomMusic == false)
		{
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
            isBeforeTomMusic = true;
		}

		else if(other.gameObject.CompareTag("MuzykaKlimat11_trigger") && isTomMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat12_trigger") && isTomHallMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("KrzykDzw_trigger") && isTom2Music == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat13_trigger") && isBooksMusic == false && inventoryScript.isChipTaken == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
            inventoryScript.chip.gameObject.SetActive (true);
			booksTaskScript.enabled = true;
            isMusicOff = false;
            mapScript.isFastTravel = false;
        }

		else if(other.gameObject.CompareTag("MuzykaKlimatStop13_trigger") && isBooksMusic == true && inventoryScript.isChipTaken == false){
			isMusicOff = true;
			isBooksMusic = false;
			booksTaskScript.enabled = false;
            mapScript.isFastTravel = true;
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat14_trigger") && isTom3Music == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		//else if(other.gameObject.CompareTag("MuzykaKlimat15_trigger") && KlimatKukurydza_ok == false){
			//KlimatKukurydza ();
		//}

		//else if(other.gameObject.CompareTag("MuzykaKlimatStop15_trigger") && KlimatKukurydza_ok == true){
			//ZrodloDzwTlo.Stop ();
			//KlimatKukurydza_ok = false;
		//}

		else if(other.gameObject.CompareTag("MuzykaKlimat16_trigger") && isTomCampMusic == false && notesScript.isNote34 == true){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat17_trigger") && isTomUpstairsMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if (other.gameObject.CompareTag("MonsterTom_trigger") && isAfterTomMusic == false && tasksScript.isCassete3Played == true)
		{
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

	/*	else if (other.gameObject.CompareTag("PrzedostanSie_trigger") && KlimatPoTom_ok == true && WylaczPoTom_ok == false)
		{
			WylaczMuzyke_ok = true;
			WylaczPoTom_ok = true;
		} */

		

		else if(other.gameObject.CompareTag("MuzykaKlimatStop18_trigger") && isAbandonedMonsterMusic == true){
			isAbandonedMonsterMusic = false;
			monsterBackgroundAudioSource1.Stop ();
		}

		else if(other.gameObject.CompareTag("MuzykaPrzedSteven_trigger") && isBeforeStevenMusic == false && tasksScript.isCassete4Played == true){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat19_trigger") && isStevenMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat20_trigger") && isStevenUpstairsMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat21_trigger") && isStevenShedMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("PaulInfo_trigger") && isBeforePaulMusic == false && notesScript.isNote45 == true){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
            isBeforePaulMusic = true;
		}

		else if(other.gameObject.CompareTag("MuzykaKlimat22_trigger") && isPaulMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat23_trigger") && isPaulUpstairsMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if(other.gameObject.CompareTag("MuzykaKlimat24_trigger") && isHutMusic == false){
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if (other.gameObject.CompareTag("ZachodGora_trigger") && isMonsterUpstairsMusic == false && notesScript.isNote53 == true)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if (other.gameObject.CompareTag("Chatka_trigger") && isBeforeShelterMusic == false && tasksScript.isDevilsBrookTask == true)
		{
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

		else if (other.gameObject.CompareTag("Kryjowka_trigger") && isShelterMusic == false)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

        else if (other.gameObject.CompareTag("MonsterPoczatek_trigger") && isBeginMonsterMusic == false)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

        else if (other.gameObject.CompareTag("GlosDuzyPokoj_trigger") && isBigRoomMusic == false)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

    }

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag("GlosKryjowka_trigger") && isEndGameMusic == false)
		{
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

        else if (other.gameObject.CompareTag("GlosKuchnia_trigger") && isKitchenMusic == false)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

        else if (other.gameObject.CompareTag("GlosKukurydza_trigger") && isCornfield1Music == false && inventoryScript.isAxeTaken == false)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

        else if (other.gameObject.CompareTag("GlosDomAlice_trigger") && isAliceMusic == false)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

        else if ((other.gameObject.CompareTag("MuzykaKlimat18_trigger") || other.gameObject.CompareTag("Piwnica_trigger")) && isAbandonedMonsterMusic == false)
        {
            isAbandonedMonsterMusic = true;
        }

        else if (other.gameObject.CompareTag("MuzykaKlimat22Wylacz_trigger") && isPaulMusic == true && tasksScript.isHutTask == false)
        {
            KlimatWylaczPaul();
            mapScript.isFastTravel = true;
        }

        else if (other.gameObject.CompareTag("KomunikatLatarka") && isAfterFlashlightMusic == false)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

        else if (other.gameObject.CompareTag("KomunikatDrzwiWskazowka") && isGrandmaDoorMusic == false)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

        else if (other.gameObject.CompareTag("MonstersLasMieso_trigger") && isMeatMonsterMusic == false && tasksScript.isStevenKeyTask == true)
        {
            PlayMusic(backgroundAudioSource1, mysteryMusic, 1, false);
        }

        else if (other.gameObject.CompareTag("MonstersLasMiesoWylacz_trigger") && isMeatMonsterMusic == true)
        {
            isMeatMonsterMusic = false;
            isMusicOff = true;
            monsterBackgroundAudioSource1.Stop();
            monsterBackgroundAudioSource1.clip = null;
            isMeatMonsterMusic_On = false;
            mapScript.isFastTravel = true;
        }

    }

	void PlayRandomMusic(){

        randomMusicActionIndex = Random.Range(0, 3);

		backgroundAudioSource1.clip = actionMusics[randomMusicActionIndex]; 
		backgroundAudioSource1.Play ();
		backgroundAudioSource1.volume = 0;
		backgroundAudioSource1.loop = true;
		randomMusicDuration = 0;
	}

   public void PlayMusic(AudioSource musicAudioSource, AudioClip music, float musicVolume, bool musicLoopState)
    {
        randomMusicDuration = 0;
        isMusicOff = false;
        
        foreach(var audioSource in musicAudioSources)
        {
            audioSource.Stop();
        }

        musicAudioSource.clip = music;
        musicAudioSource.Play();
        musicAudioSource.volume = musicVolume;
        musicAudioSource.loop = musicLoopState;
        isBehindHouseMusic = true;
    }	

    void KlimatWylaczPaul()
    {
        isMusicOff = true;
        isPaulMusic = false;

    }

    // funkcje muzyka potwory

    void PotworOgrod(){
		if (isGardenMonsterMusic == true && isGardenMonsterMusic_On == false) {
			monsterBackgroundAudioSource1.volume = 0;
			monsterBackgroundAudioSource1.clip = monsterMusic1;
			monsterBackgroundAudioSource1.Play ();
			isGardenMonsterMusic_On = true;
		} 

		if(isGardenMonsterMusic == false && isGardenMonsterMusic_On == true){
			monsterBackgroundAudioSource1.Stop ();
			isGardenMonsterMusic_On = false;
		}
	}

	void PotworWarsztat(){
		if (isWorkshopMonsterMusic == true && isWorkshopMonsterMusic_On == false) {
			monsterBackgroundAudioSource1.volume = 0;
			monsterBackgroundAudioSource1.clip = monsterMusic2;
			monsterBackgroundAudioSource1.Play ();
			isWorkshopMonsterMusic_On = true;
		} 

		if(isWorkshopMonsterMusic == false && isWorkshopMonsterMusic_On == true){
			monsterBackgroundAudioSource1.Stop ();
			isWorkshopMonsterMusic_On = false;
		}
	}

	void PotworPotokLewy(){
		if (jumpscareScript.brookMonster1.activeSelf) {
			isLeftBrookMonsterMusic = true;
		}

		if (isLeftBrookMonsterMusic == true && isLeftBrookMonsterMusic_On == false) {
            monsterBackgroundAudioSource1.volume = 0;
			monsterBackgroundAudioSource1.clip = monsterMusic3;
			monsterBackgroundAudioSource1.Play ();
			isLeftBrookMonsterMusic_On = true;
		} 

		if(isLeftBrookMonsterMusic == false && isLeftBrookMonsterMusic_On == true){
			monsterBackgroundAudioSource1.Stop ();
			isLeftBrookMonsterMusic_On = false;
		}

		if (!jumpscareScript.brookMonster1.activeSelf) {
			isLeftBrookMonsterMusic = false;
		}
	}

	void PotworKorytarz(){
		if (jumpscareScript.corridorMonster.activeSelf) {
			isCorridorMonsterMusic = true;
		}

		if (isCorridorMonsterMusic == true && isCorridorMonsterMusic_On == false) {
			monsterBackgroundAudioSource1.volume = 0;
			monsterBackgroundAudioSource1.clip = monsterMusic4;
			monsterBackgroundAudioSource1.Play ();
			isCorridorMonsterMusic_On = true;
		} 

		if(isCorridorMonsterMusic == false && isCorridorMonsterMusic_On == true){
			monsterBackgroundAudioSource1.Stop ();
			isCorridorMonsterMusic_On = false;
		}

		if (!jumpscareScript.corridorMonster.activeSelf) {
			isCorridorMonsterMusic = false;
		}
	}

	void PotworKukurydza(){
		if ((cornfieldMonsterScript.Widzi_ok == true || cornfieldMonsterScript.WidzialSwiatlo_ok == true || cornfieldMonsterScript.WidzialGracza_ok == true) && jumpscareScript.cornfieldMonster2.activeSelf) {
			isCornfieldMonsterMusic = true;
		}

		if (isCornfieldMonsterMusic == true && isCornfieldMonsterMusic_On == false) {
			monsterBackgroundAudioSource1.volume = 0;
			monsterBackgroundAudioSource1.clip = monsterMusic5;
			monsterBackgroundAudioSource1.Play ();
			isCornfieldMonsterMusic_On = true;
		}

		if(isCornfieldMonsterMusic == false && isCornfieldMonsterMusic_On == true){
			monsterBackgroundAudioSource1.Stop ();
			isCornfieldMonsterMusic_On = false;
		}

		if (!jumpscareScript.cornfieldMonster2.activeSelf) {
			isCornfieldMonsterMusic = false;
		}
	}

	void PotworDynia(){
		if (inventoryScript.isPumpkinTaken == true && jumpscareScript.pumpkinMonster.activeSelf) {
			isPumpkinMonsterMusic = true;
		}

		if (isPumpkinMonsterMusic == true && isPumpkinMonsterMusic_On == false) {
			monsterBackgroundAudioSource1.volume = 0;
			monsterBackgroundAudioSource1.clip = monsterMusic1;
			monsterBackgroundAudioSource1.Play ();
			isPumpkinMonsterMusic_On = true;
		}

		if(isPumpkinMonsterMusic == false && isPumpkinMonsterMusic_On == true){
			monsterBackgroundAudioSource1.Stop ();
			isPumpkinMonsterMusic_On = false;
		}

		if (!jumpscareScript.pumpkinMonster.activeSelf) {
			isPumpkinMonsterMusic = false;
		}
	}

	void PotworOpuszczonyDom(){
		if (isAbandonedMonsterMusic == true && isAbandonedMonsterMusic_On == false) {
			monsterBackgroundAudioSource2.volume = 0;
			monsterBackgroundAudioSource2.clip = monsterMusic6;
			monsterBackgroundAudioSource2.Play ();
			isAbandonedMonsterMusic_On = true;
		} 

		if(isAbandonedMonsterMusic == false && isAbandonedMonsterMusic_On == true){
			monsterBackgroundAudioSource2.Stop ();
			isAbandonedMonsterMusic_On = false;
		}
	}

	void PotworMieso(){
		if ((meatMonsterScript.isSawPlayer == true || meatMonsterScript.isRayPlayer == true || meatMonsterScript.isSawLight == true) && isMeatMonsterMusic_On == false) {
			monsterBackgroundAudioSource1.volume = 0.5f;
			monsterBackgroundAudioSource1.clip = monsterMusic1;
			monsterBackgroundAudioSource1.Play ();
			isMeatMonsterMusic_On = true;
		} 

		if((meatMonsterScript.isSawPlayer == false && meatMonsterScript.isRayPlayer == false && meatMonsterScript.isSawLight == false) && isMeatMonsterMusic_On == true){
			monsterBackgroundAudioSource1.Stop ();
			isMeatMonsterMusic_On = false;
		}
	}

    void PotworOpuszczonyPiwnica()
    {
        monsterBackgroundAudioSource1.volume = 0;
        monsterBackgroundAudioSource1.clip = cornfieldMusic;
        monsterBackgroundAudioSource1.Play();
        isBasementMonsterMusic = true;
    }

    void PotworRoslina()
    {
        if (jumpscareScript.plantMonster.activeSelf == true && isPlantMonsterMusic == false) {
            monsterBackgroundAudioSource1.volume = 0;
            monsterBackgroundAudioSource1.clip = monsterMusic4;
            monsterBackgroundAudioSource1.Play();
            isPlantMonsterMusic = true;
        }

        if (isPlantMonsterMusic == true && jumpscareScript.plantMonster.activeSelf == false)
        {
            monsterBackgroundAudioSource1.Stop();
            isPlantMonsterMusic = false;
        }

    }

    void PotworSteven()
    {
        if ((stevenMonster1_Script.Widzi_ok == true || stevenMonster2_Script.Widzi_ok == true) && isStevenMonsterMusic == false)
        {
            monsterBackgroundAudioSource1.volume = 0;
            monsterBackgroundAudioSource1.clip = monsterMusic5;
            monsterBackgroundAudioSource1.Play();
            isStevenMonsterMusic = true;
        }

        if (jumpscareScript.stevenShedMonster1.activeSelf == false && isStevenMonsterMusic == true)
        {
            //ZrodloDzwPotwory.Stop();
            isMusicOff = true;
            isStevenMonsterMusic = false;
        }

    }

}
