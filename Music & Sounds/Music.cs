using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	private Jumpscare jumpscareScript;
	public Monster2_v3 cornfieldMonsterScript;
    public Monster1_SzopaSteven1 stevenMonster1_Script;
    public Monster1_SzopaSteven2 stevenMonster2_Script;
	public Monster1_v3 meatMonsterScript;

    public AudioSource[] musicAudioSources;
    public AudioSource backgroundAudioSource1;
	public AudioSource backgroundAudioSource2;
	public AudioSource backgroundAudioSource3;
	public AudioSource monsterBackgroundAudioSource1;
	public AudioSource monsterBackgroundAudioSource2;

	public float randomMusicDuration = 0;
	public bool isMusicOff = false;


    public AudioClip[] actionMusics;
    public int randomMusicActionIndex;

    public AudioClip cornfieldMusic;
    public AudioClip monsterMusic1;
	public AudioClip monsterMusic2;
	public AudioClip monsterMusic3;
	public AudioClip monsterMusic4;
	public AudioClip monsterMusic5;
	public AudioClip monsterMusic6;

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

    public delegate void PlayMonsterMusicDelegate();
    public PlayMonsterMusicDelegate PlayMonsterMusic; 

    void OnEnable () {

		jumpscareScript = GameObject.Find ("Player").GetComponent<Jumpscare> ();
		
        cornfieldMonsterScript = GameObject.Find("Monster2_v3").GetComponent<Monster2_v3>();
		stevenMonster1_Script = GameObject.Find("Monster1_SzopaSteven").GetComponent<Monster1_SzopaSteven1>();
		stevenMonster2_Script = GameObject.Find("Monster1_SzopaSteven2").GetComponent<Monster1_SzopaSteven2>();
		meatMonsterScript = GameObject.Find("Monster1_v3").GetComponent<Monster1_v3>();

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

        // Zwiekszanie glosnosci muzyki

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
            if (backgroundAudioSource1.clip != null)
            {
                backgroundAudioSource1.Pause();
            }
            else if (backgroundAudioSource2.clip != null)
            {
                backgroundAudioSource2.Pause();
            }
            else if (backgroundAudioSource3.clip != null)
            {
                backgroundAudioSource3.Pause();
            }
            else if (monsterBackgroundAudioSource1.clip != null)
            {
                monsterBackgroundAudioSource1.Pause();
            }
            else if (monsterBackgroundAudioSource2.clip != null)
            {
                monsterBackgroundAudioSource2.Pause();
            }
        }

		// Wznawianie muzyki

		if (Time.timeScale == 1) {
            if (backgroundAudioSource1.clip != null)
            {
                backgroundAudioSource1.UnPause();
            }
            else if (backgroundAudioSource2.clip != null)
            {
                backgroundAudioSource2.UnPause();
            }
            else if (backgroundAudioSource3.clip != null)
            {
                backgroundAudioSource3.UnPause();
            }
            else if (monsterBackgroundAudioSource1.clip != null)
            {
                monsterBackgroundAudioSource1.UnPause();
            }
            else if (monsterBackgroundAudioSource2.clip != null)
            {
                monsterBackgroundAudioSource2.UnPause();
            }
        }

			
		// muzyka bez zadania

		if(backgroundAudioSource1.clip == null && backgroundAudioSource2.clip == null && backgroundAudioSource3.clip == null && randomMusicDuration <= 120){
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

        PlayMonsterMusic();

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
    }	

    void PlayMonsterGardenMusic(){
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

	void PlayMonsterWorkshopMusic(){
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

	void PlayMonsterLeftBrookMusic(){
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

	void PlayMonsterCorridorMusic(){
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

	void PlayMonsterCornfieldMusic(){
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

	void PlayMonsterPumpkinMusic(){
		if (jumpscareScript.pumpkinMonster.activeSelf) {
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

	void PlayMonsterAbandonedMusic(){
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

	void PlayMonsterMeatMusic(){
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

    void PlayMonsterBasementMusic()
    {
        monsterBackgroundAudioSource1.volume = 0;
        monsterBackgroundAudioSource1.clip = cornfieldMusic;
        monsterBackgroundAudioSource1.Play();
        isBasementMonsterMusic = true;
    }

    void PlayMonsterPlantMusic()
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

    void PlayMonsterStevenMusic()
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
