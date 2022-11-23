using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityStandardAssets.ImageEffects;
using System;
using System.Runtime.Serialization.Formatters.Binary;


public class Menu : MonoBehaviour {

    // kursor rozdzielczosc

    public Texture2D[] resolution1920;
    public Texture2D[] resolution1680;
    public Texture2D[] resolution1366_60;
    public Texture2D[] resolution1280;
    public Texture2D[] resolution1152;

    private SaveMenu saveMenuScript;
	private SaveGame saveGameScript;
	public GameManager gameManagerScript;
	private Transform playerCamera;
	public Animator passAnimator;
	public CrosshairGUI cursorScript;
	public Headbobber headbobberScript;
	public Player playerScript;
	public Inventory inventoryScript;
	public Tasks tasksScript;
	public Notes notesScript;
	private Transform flashlight;
	public Flashlight flashlightScript;
	public Screamer screamerScript;
	public Notifications notificationScript;
	public VoiceActing voiceActingScript;
	public Jumpscare jumpscareScript;
	public Music musicScript;
	public TaskBooks taskBooksScript;
	public TaskMeat taskMeatScript;
	public Map mapScript;
    public StraszakScarecrow scarecrowJumpscareScript;
	private TerrainSurface terrainSurfaceScript;
    public Brightness brightnessScript;
	public BeginGame beginGameScript;
	public Canvas menuCanvas;
	public Canvas mainMenuCanvas;
	public Canvas optionsCanvas;
	public Canvas optionsGraphicsCanvas;
	public Canvas optionsAudioCanvas;
	public Canvas optionsInputCanvas;
	public Canvas optionsLanguageCanvas;
	public Canvas exitCanvas;
	public Canvas exitToMenuCanvas;
	public Canvas newGameCanvas;
	public Canvas loadGameCanvas;
	public Canvas passCanvas;
	public Canvas loadingScreenCanvas;
	public Canvas darkImageNewspaperCanvas;
    public Canvas uiCanvas;
    public Image passBeginGameImage;
    private Tonemapping tonemapScript;

    // credits

    private Canvas creticsCanvas;
    public GameObject creditsBackButton;
    private Animator subtitlesAnimator;

    public AudioListener playerAudioListener;
	public Light flashlightLight;
	public TextMeshProUGUI KomNapisy;
	public TextMeshProUGUI KomGlowny;
	private TextMeshProUGUI KomZadanie;
	private TextMeshProUGUI KomZapis;
	public TextMeshProUGUI KomInfo;
	public TextMeshProUGUI KomItem;
	public TextMeshProUGUI KomPlace;
    public TextMeshProUGUI KomDrzwiInfo;

    //public Button Resume;
    public Button loadGameButton;
    //public Button Options;
    //public Button Exit;
    public bool isMenu = false;
	public bool isOptions = false;
	private Transform player;
	public Health healthScript;
	public AudioSource audioSource;
    public AudioSource pauseAudioSource;
    public AudioClip menuSound;
	public AudioClip hoverButtonSound;
    public AudioClip pauseMenuSound;
    public AudioMixerSnapshot pauseSoundSnapshot;
	public AudioMixerSnapshot unPauseSoundSnapshot;
	public AudioMixer mainAudioMixer;
	public AudioMixer soundsAudioMixer;
	public bool isDropdown1 = false;
	public bool isDropdown2 = true;
	public Slider mouseSensitivitySlider;
	public bool isPass1 = false;
	public bool isPass2 = false;
	public bool isComponentsEnabled = false;

	public bool isNewGame = true;
	public bool isMenuNewGame = false;
	public bool isLoadedGame = false;
	public bool isToMenu = false;
	public bool isToGame = false;

	// opcje grafiki

	public Resolution[] resolutions;
	//public Dropdown DropdownCienie;
	public TMP_Dropdown shadowsDropdown;
	//public Dropdown DropdownAliasing;
	public TMP_Dropdown aliasingDropdown;
	//public Dropdown DropdownRozdzielczosc;
	public TMP_Dropdown resolutionDropdown;
	//public Dropdown DropdownTekstury;
	public TMP_Dropdown texturesDropdown;
	//public Dropdown DropdownVsync;
	public TMP_Dropdown vsyncDropdown;
	public Toggle fullScreenToggle;
    public Slider brigtnessSlider;
    public ScrollRect keyboardScrollRect;
    public Scrollbar keyboardScrollbar;

    public Toggle subtitlesToggle;
	//public bool Subtitles_ok = true;
	//public Dropdown JezykDropdown;
	public TMP_Dropdown languageDropdown;

	void Awake(){

		saveMenuScript = GameObject.Find ("CanvasMenu").GetComponent<SaveMenu> ();
		playerScript = GameObject.Find ("Player").GetComponent<Player> ();
        cursorScript = GameObject.Find("Kamera").GetComponent<CrosshairGUI>();
        tonemapScript = GameObject.Find("Kamera").GetComponent<Tonemapping>();

    }


	void Start () {

        saveMenuScript.Wczytaj();

    }

	void OnEnable(){

        // sprawdzanie czy mozna wczytac grę

        if (File.Exists(Application.persistentDataPath + "/PlayerSave.pav"))
        {
            loadGameButton.interactable = true;
        }else
        {
            loadGameButton.interactable = false;
        }

        Cursor.visible = true;

        isMenu = false;
        isPass1 = false;

		player = GameObject.Find("Player").transform;
		//Player.transform.eulerAngles = new Vector3(0,4798.431f,0);
		playerCamera = GameObject.Find("Kamera").transform;
		flashlightLight = GameObject.Find ("Latarka").GetComponent<Light> ();
		KomNapisy = GameObject.Find ("NapisyNagrania").GetComponent<TextMeshProUGUI> ();
		KomGlowny = GameObject.Find ("GlownyKomunikat").GetComponent<TextMeshProUGUI> ();
		KomZadanie = GameObject.Find ("ZadanieKomunikat").GetComponent<TextMeshProUGUI> ();
		KomZapis = GameObject.Find ("ZapisKomunikat").GetComponent<TextMeshProUGUI> ();
		KomInfo = GameObject.Find ("InfoKomunikat").GetComponent<TextMeshProUGUI> ();
		KomItem = GameObject.Find ("SecretItemKomunikat").GetComponent<TextMeshProUGUI> ();
		KomPlace = GameObject.Find ("SecretPlaceKomunikat").GetComponent<TextMeshProUGUI> ();
        KomDrzwiInfo = GameObject.Find("DrzwiInfoKomunikat").GetComponent<TextMeshProUGUI>();

        passBeginGameImage = GameObject.Find("PrzejsciePoczatekGry").GetComponent<Image>();
        creticsCanvas = GameObject.Find("CanvasCredits").GetComponent<Canvas>();
        subtitlesAnimator = GameObject.Find("CreditsAll").GetComponent<Animator>();

        //MenuGlowne = GameObject.Find ("CanvasMenuGlowne").GetComponent<Canvas> ();

        healthScript = player.GetComponent<Health>();
		flashlight = GameObject.Find("Latarka").transform;
		gameManagerScript = GameObject.Find ("Player").GetComponent<GameManager> ();
		//Kursor = GameObject.Find ("Kamera").GetComponent<CrosshairGUI> ();
		playerScript = GameObject.Find ("Player").GetComponent<Player> ();
		screamerScript = GameObject.Find ("Player").GetComponent<Screamer> ();
		inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();
		tasksScript = GameObject.Find ("Player").GetComponent<Tasks> ();
		notificationScript = GameObject.Find ("Player").GetComponent<Notifications> ();
		notesScript = GameObject.Find ("Player").GetComponent<Notes> ();
		voiceActingScript = GameObject.Find ("Player").GetComponent<VoiceActing> ();
		terrainSurfaceScript = GameObject.Find ("Player").GetComponent<TerrainSurface> ();
		mapScript = GameObject.Find ("Player").GetComponent<Map> ();
        scarecrowJumpscareScript = GameObject.Find("Player").GetComponent<StraszakScarecrow>();
        flashlightScript = GameObject.Find ("Latarka").GetComponent<Flashlight> ();
		jumpscareScript = GameObject.Find ("Player").GetComponent<Jumpscare> ();
		musicScript = GameObject.Find ("Player").GetComponent<Music> ();
		taskBooksScript = GameObject.Find ("Player").GetComponent<TaskBooks> ();
		taskMeatScript = GameObject.Find ("Player").GetComponent<TaskMeat> ();
		headbobberScript = GameObject.Find("Kamera").GetComponent<Headbobber>();
		saveGameScript = GameObject.Find ("Player").GetComponent<SaveGame> ();
		beginGameScript = GameObject.Find ("Player").GetComponent<BeginGame> ();
        //GryJasnosc = GameObject.Find("Kamera").GetComponent<Brightness>();

        // Blokada gracza

        if (SceneManager.GetActiveScene().name == "ScenaGlowna" && player.GetComponent<EndGame> ().enabled == false) { //&& WlaczKomponenty_ok == false
            AudioListener.volume = 1;
            isComponentsEnabled = true;
			mainMenuCanvas.enabled = false;
            player.GetComponent<Animator>().enabled = true;
            player.gameObject.GetComponent<TerrainSurface> ().enabled = true;
			player.gameObject.GetComponent<Player> ().enabled = true;
            playerCamera.gameObject.GetComponent<Headbobber> ().enabled = true;
			player.gameObject.GetComponent<Inventory> ().enabled = true;
			player.gameObject.GetComponent<Screamer> ().enabled = true;
			player.gameObject.GetComponent<Notifications> ().enabled = true;
			player.gameObject.GetComponent<Map> ().enabled = true;
            scarecrowJumpscareScript.enabled = true;
			player.gameObject.GetComponent<Health> ().enabled = true;
			flashlight.gameObject.GetComponent<Flashlight> ().enabled = true;
			player.gameObject.GetComponent<Notes> ().enabled = true;
			player.gameObject.GetComponent<VoiceActing> ().enabled = true;
			player.gameObject.GetComponent<Jumpscare> ().enabled = true;
			player.gameObject.GetComponent<Music> ().enabled = true;
			//Player.gameObject.GetComponent<ZadanieKsiazki> ().enabled = true;
			player.gameObject.GetComponent<TaskMeat> ().enabled = true;
			player.GetComponent<Crouch> ().enabled = true;
			player.GetComponent<PlayerSounds> ().enabled = true;
			player.gameObject.GetComponent<Tasks> ().enabled = true;
            player.gameObject.GetComponent<Halluns>().enabled = true;
            player.gameObject.GetComponent<OpenCloseObject>().enabled = true;
            player.gameObject.GetComponent<Compass>().enabled = true;
            tonemapScript.enabled = true;

            uiCanvas.enabled = true;

            //ManagerGry.enabled = true;
            cursorScript.enabled = true;
			cursorScript.m_ShowCursor = false;
			isToGame = false;
		}


		if(SceneManager.GetActiveScene().name == "MenuGlowne"){ // && WlaczKomponenty_ok == true

			if (gameManagerScript.enabled == true) {
				gameManagerScript.WartosciPoczatkowe ();
			}

            AudioListener.volume = 1;
            darkImageNewspaperCanvas.enabled = false;
            uiCanvas.enabled = false;

            tonemapScript.enabled = false;
			playerCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
			player.transform.rotation = Quaternion.Euler(0, 4798.431f, 0);
			//Player.transform.eulerAngles = new Vector3(0, 4798.431f, 0);
			isComponentsEnabled = false;
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<PlayerSounds> ().enabled = false;
			player.GetComponent<Crouch> ().enabled = false;
			player.GetComponent<EndGame> ().enabled = false;
            player.gameObject.GetComponent<RandomJumpscare>().enabled = false;
            player.gameObject.GetComponent<Halluns>().enabled = false;
            player.gameObject.GetComponent<OpenCloseObject>().enabled = false;
            player.gameObject.GetComponent<Push>().enabled = false;
            player.gameObject.GetComponent<DragObject>().enabled = false;
            player.gameObject.GetComponent<Compass>().enabled = false;
            voiceActingScript.retroEffectScript.intensity = 0;
			mainMenuCanvas.enabled = true;
			playerScript.enabled = false;
			headbobberScript.enabled = false;
			inventoryScript.enabled = false;
			mapScript.enabled = false;
            scarecrowJumpscareScript.enabled = false;
			screamerScript.enabled = false;
			tasksScript.enabled = false;
			notificationScript.enabled = false;
			flashlightScript.enabled = false;
			notesScript.enabled = false;
			voiceActingScript.enabled = false;
			gameManagerScript.enabled = false;
			jumpscareScript.enabled = false;
			musicScript.enabled = false;
            taskBooksScript.enabled = false;
            //TaskKsiazki.enabled = false;
            taskMeatScript.enabled = false;
			healthScript.enabled = false;
			cursorScript.enabled = false;
			flashlightLight.enabled = false;
			KomNapisy.text = "";
			KomGlowny.text = "";
			//KomZadanie.text = "";
			KomInfo.text = "";
			KomItem.text = "";
			KomPlace.text = "";
            KomDrzwiInfo.text = "";
            healthScript.playerDamageCanvas1.enabled = false;
            healthScript.playerDamageCanvas2.enabled = false;
            healthScript.playerDamageCanvas3.enabled = false;
            healthScript.playerInjuredCanvas.enabled = false;
            healthScript.noisesScreenScript.enabled = false;
            healthScript.deadScreenScript.enabled = false;
            tasksScript.twirlScript.enabled = false;
            isToMenu = false;
		}
			



		passAnimator.SetTrigger("Przejscie2");

		if (SceneManager.GetActiveScene ().name == "MenuGlowne") {
			playerAudioListener.enabled = true;
		}

		if (isNewGame == false && SceneManager.GetActiveScene ().name == "ScenaGlowna") {
            //Blokada_gracza.gameObject.AddComponent<PoczatekGry> ();
            passBeginGameImage.color = Color.black;
            beginGameScript.enabled = true;
			isNewGame = true;
		}

		loadingScreenCanvas.enabled = false;

	}


	void Update () {


		FixGraphicsDropdown ();
		FixLanguageDropdown ();
			
		if (passAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && passAnimator.GetCurrentAnimatorStateInfo(0).IsName("UI_Przejscie2") && !passAnimator.IsInTransition(0) && isPass1 == false) {
			passCanvas.enabled = false;
			isPass1 = true;
		}

		if (passAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && passAnimator.GetCurrentAnimatorStateInfo(0).IsName("UI_Przejscie2") && !passAnimator.IsInTransition(0) && SceneManager.GetActiveScene().name == "ScenaGlowna") {
			//PlayerListener.enabled = true;
		}

		if (passAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && passAnimator.GetCurrentAnimatorStateInfo(0).IsName("UI_Przejscie1") && !passAnimator.IsInTransition(0) && isPass2 == true && SceneManager.GetActiveScene().name == "MenuGlowne") {
			isPass2 = false;
			menuCanvas.GetComponent<Menu> ().enabled = false;
			playerAudioListener.enabled = false;
			loadingScreenCanvas.enabled = true;
		}

		if (passAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && passAnimator.GetCurrentAnimatorStateInfo(0).IsName("UI_Przejscie1") && !passAnimator.IsInTransition(0) && isPass2 == true && SceneManager.GetActiveScene().name == "ScenaGlowna") {
			isPass2 = false;
			menuCanvas.GetComponent<Menu> ().enabled = false;
			playerAudioListener.enabled = false;
			loadingScreenCanvas.enabled = true;
		}

	
			

		//Debug.Log (SceneManager.GetActiveScene().name);

		if(Input.GetButtonDown("Cancel") && isMenu == false && healthScript.health > 0 && inventoryScript.isInventoryActive == false && inventoryScript.isPanelActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && mapScript.isMap == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && SceneManager.GetActiveScene().name == "ScenaGlowna" && isMenuNewGame == false && isLoadedGame == false && loadingScreenCanvas.enabled == false && isToMenu == false)
        {
			PauseGame ();

		}else if (Input.GetButtonDown("Cancel") && isMenu == true && isOptions == false && isToMenu == false){
			ResumeGame();
		}

		if (Input.GetButtonDown ("Cancel") && isOptions == true) {
			OptionsBack ();
		}

		if (Time.timeScale == 0) {
			pauseSoundSnapshot.TransitionTo (0.01f);
		} else {
			unPauseSoundSnapshot.TransitionTo (0.01f);
		}


	}

	public void ResumeGame(){
        /*	CaleMenu.enabled = false;
            Time.timeScale = 1;
            Menu_ok = false;
            Blokada_gracza.enabled = true;
            //if(Panel.Panel_ok == true){
            //Kursor.m_ShowCursor = !Kursor.m_ShowCursor;
            Kursor.m_ShowCursor = false; */
        //}

        if (loadGameCanvas.enabled == false && exitToMenuCanvas.enabled == false)
        {

            if (notesScript.isNotes == true && tasksScript.axeBlackBackgroundCanvas.enabled == false)
            {
                pauseAudioSource.pitch = 0.9f;
                pauseAudioSource.PlayOneShot(pauseMenuSound, 0.7f);
                menuCanvas.enabled = false;
                Time.timeScale = 0;
                isMenu = false;
                playerScript.audioSource.Pause();
                playerScript.enabled = false;
                cursorScript.m_ShowCursor = false;
                Cursor.visible = false;
                headbobberScript.enabled = true;
                playerScript.currentVelocity = playerScript.walkVelocity;
            }

            else if (notesScript.isNotes == true && tasksScript.axeBlackBackgroundCanvas.enabled == true)
            {
                menuCanvas.enabled = false;
                Time.timeScale = 1;
                isMenu = false;
                playerScript.audioSource.UnPause();
                cursorScript.m_ShowCursor = false;
                headbobberScript.enabled = true;

            }

            else if (notesScript.isNotes == false && notificationScript.isTutorialNotification == false)
            {
                pauseAudioSource.pitch = 0.9f;
                pauseAudioSource.PlayOneShot(pauseMenuSound, 0.7f);
                menuCanvas.enabled = false;
                Time.timeScale = 1;
                isMenu = false;
                playerScript.enabled = true;
                playerScript.audioSource.UnPause();
                //if(Panel.Panel_ok == true){
                //Kursor.m_ShowCursor = !Kursor.m_ShowCursor;
                cursorScript.m_ShowCursor = false;
                headbobberScript.enabled = true;
                playerScript.currentVelocity = playerScript.walkVelocity;

            }

            if (notificationScript.isTutorialNotification == true)
            {

                menuCanvas.enabled = false;
                Time.timeScale = 0;
                isMenu = false;
                playerScript.audioSource.Pause();
                playerScript.enabled = false;
                cursorScript.m_ShowCursor = true;
                Cursor.visible = true;
                headbobberScript.enabled = true;
                playerScript.currentVelocity = playerScript.walkVelocity;
            }

        }

        else if(loadGameCanvas.enabled == true)
        {
            HideLoadGameCanvas();

        }

        else if (exitToMenuCanvas.enabled == true)
        {
            ExitMenuNoFunction();
        }

	}

	public void PauseGame(){
        pauseAudioSource.pitch = 1;
        pauseAudioSource.PlayOneShot(pauseMenuSound);
        menuCanvas.enabled = true;
		Time.timeScale = 0;
		isMenu = true;
		//Kursor.m_ShowCursor = !Kursor.m_ShowCursor;
		cursorScript.m_ShowCursor = true;
        playerScript.audioSource.Pause();
        playerScript.enabled = false;
		Cursor.visible = true;
        headbobberScript.enabled = false;
    }

	public void ShowGameOptions(){
		mainMenuCanvas.enabled = false;
		menuCanvas.enabled = false;
		optionsCanvas.enabled = true;
		optionsGraphicsCanvas.enabled = true;
		isOptions = true;
		audioSource.PlayOneShot (menuSound);
	}

	public void OptionsBack(){
		optionsCanvas.enabled = false;
		optionsGraphicsCanvas.enabled = false;
		optionsAudioCanvas.enabled = false;
		optionsInputCanvas.enabled = false;
		optionsLanguageCanvas.enabled = false;
		isOptions = false;
        isDropdown1 = false;
        isDropdown2 = false;
        audioSource.PlayOneShot (menuSound);

        shadowsDropdown.Hide();
        aliasingDropdown.Hide();
        resolutionDropdown.Hide();
        texturesDropdown.Hide();
        vsyncDropdown.Hide();
        languageDropdown.Hide();

        if (SceneManager.GetActiveScene().name == "MenuGlowne") {
			mainMenuCanvas.enabled = true;
		} else {
			menuCanvas.enabled = true;
		}

	}

	public void ShowGraphicsOptions(){
		optionsGraphicsCanvas.enabled = true;
		optionsAudioCanvas.enabled = false;
		optionsInputCanvas.enabled = false;
		optionsLanguageCanvas.enabled = false;
		audioSource.PlayOneShot (menuSound);
	}

	public void ShowAudioOptions(){
		optionsGraphicsCanvas.enabled = false;
		optionsAudioCanvas.enabled = true;
		optionsInputCanvas.enabled = false;
		optionsLanguageCanvas.enabled = false;
		audioSource.PlayOneShot (menuSound);
	}

	public void ShowInputOptions(){

        StartCoroutine(InputOptionsIE());

    }

    public IEnumerator InputOptionsIE()
    {
        optionsGraphicsCanvas.enabled = false;
        optionsAudioCanvas.enabled = false;
        optionsInputCanvas.enabled = true;
        optionsLanguageCanvas.enabled = false;
        audioSource.PlayOneShot(menuSound);

        yield return new WaitForSeconds(0.01f);

        keyboardScrollRect.GetComponent<ScrollRect>().enabled = true;
        keyboardScrollbar.value = 1;
        StopCoroutine(InputOptionsIE());

    }

    public void ShowLanguageOptions(){
		optionsGraphicsCanvas.enabled = false;
		optionsAudioCanvas.enabled = false;
		optionsInputCanvas.enabled = false;
		optionsLanguageCanvas.enabled = true;
		audioSource.PlayOneShot (menuSound);
	}


    public void SetSoundsVolume(float PoziomDzwieku){
		mainAudioMixer.SetFloat ("DzwiekiVol", PoziomDzwieku);
	}

	public void SetMusicVolume(float PoziomMuzyki){
		mainAudioMixer.SetFloat ("MuzykaVol", PoziomMuzyki);
	}

	public void SetMouseSensitivity(float Intensywnosc = 10f){
		playerScript.mouseSensitivity = Intensywnosc;
	}

	public void FixGraphicsDropdown(){
		
		if(optionsGraphicsCanvas.transform.Find("Blocker") && isDropdown1 == false){
			isDropdown1 = true;
            optionsCanvas.enabled = false;
            optionsCanvas.enabled = true;
		}

		if((Input.GetMouseButtonUp(0)) && isDropdown1 == true){ //|| Input.GetButtonDown("Cancel")
			optionsGraphicsCanvas.enabled = false;
            optionsGraphicsCanvas.enabled = true;
            isDropdown1 = false;
        }

	}

	public void FixLanguageDropdown(){

		if(optionsLanguageCanvas.transform.Find("Blocker") && isDropdown2 == false){
			isDropdown2 = true;
            optionsCanvas.enabled = false;
            optionsCanvas.enabled = true;
        }

		if((Input.GetMouseButtonUp(0)) && isDropdown2 == true){ //|| Input.GetButtonDown("Cancel")
			optionsLanguageCanvas.enabled = false;
            optionsLanguageCanvas.enabled = true;
            isDropdown2 = false;
        }

	}

	public void SetFullScreen(bool Ekran_ok = true){
        //Screen.fullScreen = Ekran_ok;
        Screen.fullScreen = fullScreenToggle.isOn;
    }

	public void SetTextureQuality(){
		//QualitySettings.masterTextureLimit = PoziomTekstur;

		if (texturesDropdown.value == 0) {
			QualitySettings.masterTextureLimit = 0;
		} else if (texturesDropdown.value == 1) {
			QualitySettings.masterTextureLimit = 1;
		} else if (texturesDropdown.value == 2) {
			QualitySettings.masterTextureLimit = 2;
		}

	}

	public void SetShadows(){

		if (shadowsDropdown.value == 0) {
			QualitySettings.shadows = ShadowQuality.All;
		} else if (shadowsDropdown.value == 1) {
			QualitySettings.shadows = ShadowQuality.HardOnly;
		} else {
			QualitySettings.shadows = ShadowQuality.Disable;
		}

	}

	public void SetVsync(int PoziomVsync = 1){
		QualitySettings.vSyncCount = PoziomVsync;
	}

	public void SetAliasing(){

		if (aliasingDropdown.value == 0) {
			QualitySettings.antiAliasing = 0;
		} else if (aliasingDropdown.value == 1) {
			QualitySettings.antiAliasing = 2;
		} else if(aliasingDropdown.value == 2){
			QualitySettings.antiAliasing = 4;
		}else if(aliasingDropdown.value == 3){
			QualitySettings.antiAliasing = 8;
		}

	}

	public void SetResoulution(){

		if (resolutionDropdown.value == 0) {
			Screen.SetResolution(1920, 1080, true);
            SetCursorTo1920();
            fullScreenToggle.isOn = true;
        } else if (resolutionDropdown.value == 1){
			Screen.SetResolution(1680, 1050, true);
            SetCursorTo1680();
            fullScreenToggle.isOn = true;
        } else if (resolutionDropdown.value == 2){
			Screen.SetResolution(1366, 768, true);
            SetCursorTo1366_60();
            fullScreenToggle.isOn = true;
        } else if (resolutionDropdown.value == 3){
			Screen.SetResolution(1360, 768, true);
            SetCursorTo1366_60();
            fullScreenToggle.isOn = true;
        } else if (resolutionDropdown.value == 4){
			Screen.SetResolution(1280, 1024, true);
            SetCursorTo1280();
            fullScreenToggle.isOn = true;
        } else if (resolutionDropdown.value == 5){
			Screen.SetResolution(1280, 800, true);
            SetCursorTo1280();
            fullScreenToggle.isOn = true;
        } else if (resolutionDropdown.value == 6){
			Screen.SetResolution(1280, 768, true);
            SetCursorTo1280();
            fullScreenToggle.isOn = true;
        } else if (resolutionDropdown.value == 7){
			Screen.SetResolution(1280, 720, true);
            SetCursorTo1280();
            fullScreenToggle.isOn = true;
        } else if (resolutionDropdown.value == 8){
			Screen.SetResolution(1152, 864, true);
            SetCursorTo1152();
            fullScreenToggle.isOn = true;
        } 
         
			
	}

    public void SetBrightness(float brightness = 1f)
    {
        brightnessScript.brightness = brightness;

    }

    public void SetDefaultGraphics(){
		
		Screen.fullScreen = true;
		fullScreenToggle.isOn = true;
		QualitySettings.masterTextureLimit = 0;
		texturesDropdown.value = 0;
		QualitySettings.shadows = ShadowQuality.All;
		shadowsDropdown.value = 0;
		QualitySettings.vSyncCount = 0;
		vsyncDropdown.value = 0;
		QualitySettings.antiAliasing = 0;
		aliasingDropdown.value = 0;
		Screen.SetResolution(1920, 1080, true);
		resolutionDropdown.value = 0;
        brightnessScript.brightness = 1.4f;
        brigtnessSlider.value = 1.4f;

	}

	public void SetDefaultInput(){
		playerScript.mouseSensitivity = 10f;
		mouseSensitivitySlider.value = 10;
		audioSource.PlayOneShot (menuSound);
	}

	public void SetDefaultLanguage(){

		languageDropdown.value = 0;
		audioSource.PlayOneShot (menuSound);
        subtitlesToggle.isOn = true;

	}

	public void ExitFunction(){
		exitCanvas.enabled = true;
		audioSource.PlayOneShot (menuSound);
	}

	public void ExitMenuFunction(){
		exitToMenuCanvas.enabled = true;
		audioSource.PlayOneShot (menuSound);
	}

	public void ExitNoFunction(){
		exitCanvas.enabled = false;
		audioSource.PlayOneShot (menuSound);
	}

	public void ExitMenuNoFunction(){
		exitToMenuCanvas.enabled = false;
		audioSource.PlayOneShot (menuSound);
	}

	public void NewGameFunction(){
		newGameCanvas.enabled = true;
		audioSource.PlayOneShot (menuSound);
	}

	public void NewGameNoFunction(){
		newGameCanvas.enabled = false;
		audioSource.PlayOneShot (menuSound);
	}

	public void NewGameYesFunction(){
		PlayerInstance.isRespown = true;
		PlayerInstance.startNr = "ScenaGlowna";
		passCanvas.enabled = true;
		newGameCanvas.enabled = false;
		audioSource.PlayOneShot (menuSound);
		passAnimator.SetTrigger ("Przejscie1");
		isPass2 = true;
		isNewGame = false;
		isMenuNewGame = true;
		isToGame = true;
        //Destroy(Blokada_gracza);

        Cursor.visible = false;

	}

	public void ShowLoadGameCanvas(){
		loadGameCanvas.enabled = true;
		audioSource.PlayOneShot (menuSound);
	}

	public void HideLoadGameCanvas(){
		loadGameCanvas.enabled = false;
		audioSource.PlayOneShot (menuSound);
	}

	public void LoadGame(){
        //GraczInstancja.startNr = "ScenaGlowna";

        loadGameCanvas.enabled = false;

        if (SceneManager.GetActiveScene ().name == "ScenaGlowna") {
            //PlayerListener.enabled = false;
            AudioListener.volume = 0;
            ResumeGame ();
            notificationScript.KomunikatSamouczekZiolaOk();
            notificationScript.KomunikatSamouczekZapisOk();
            notificationScript.KomunikatSamouczekPchanieOk();
            notificationScript.KomunikatSamouczekSecretOk();
            notificationScript.KomunikatSamouczekItemsOk();
            notificationScript.KomunikatSamouczekInventoryOk();
            player.GetComponent<Crouch>().GetUp();

        }

        passCanvas.enabled = true;
		isLoadedGame = true;
		audioSource.PlayOneShot (menuSound);
		passAnimator.SetTrigger ("Przejscie1");
		isPass2 = true;

        player.GetComponent<Animator>().enabled = true;
		player.GetComponent<PlayerSounds> ().enabled = false;
		//Player.GetComponent<Kucanie> ().enabled = false;
		player.GetComponent<EndGame> ().enabled = false;
        player.GetComponent<RandomJumpscare>().enabled = false;
        player.GetComponent<Halluns>().enabled = false;
        player.GetComponent<OpenCloseObject>().enabled = false;
        voiceActingScript.retroEffectScript.intensity = 0;
		playerScript.enabled = false;
		headbobberScript.enabled = false;
		inventoryScript.enabled = false;
		mapScript.enabled = false;
        scarecrowJumpscareScript.enabled = false;
		screamerScript.enabled = false;
		tasksScript.enabled = false;
		notificationScript.enabled = false;
		flashlightScript.enabled = false;
		notesScript.enabled = false;
		voiceActingScript.enabled = false;
		gameManagerScript.enabled = false;
		jumpscareScript.enabled = false;
		musicScript.enabled = false;
		taskBooksScript.enabled = false;
		taskMeatScript.enabled = false;
		cursorScript.enabled = false;
		flashlightLight.enabled = false;
		KomNapisy.text = "";
		KomGlowny.text = "";
		KomInfo.text = "";
		KomItem.text = "";
		KomPlace.text = "";
		healthScript.enabled = false;

        healthScript.playerDamageCanvas1.enabled = false;
        healthScript.playerDamageCanvas2.enabled = false;
        healthScript.playerDamageCanvas3.enabled = false;
        healthScript.playerInjuredCanvas.enabled = false;

        Cursor.visible = false;

        saveGameScript.Wczytano_ok = false;

		//Destroy(Blokada_gracza);
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void ExitToMenu(){

        AudioListener.volume = 0;
        player.GetComponent<Crouch> ().GetUp();

        if(notificationScript.herbsNotificationCanvas.enabled == true)
        {
            notificationScript.KomunikatSamouczekZiolaOk();
        }

        if (notificationScript.saveGameNotificationCanvas.enabled == true)
        {
            notificationScript.KomunikatSamouczekZapisOk();
        }

        if (notificationScript.pushNotificationCanvas.enabled == true)
        {
            notificationScript.KomunikatSamouczekPchanieOk();
        }

        if (notificationScript.secretNotificationCanvas.enabled == true)
        {
            notificationScript.KomunikatSamouczekSecretOk();
        }

        if (notificationScript.itemsNotificationCanvas.enabled == true)
        {
            notificationScript.KomunikatSamouczekItemsOk();
        }

        if (notificationScript.inventoryNotificationCanvas.enabled == true)
        {
            notificationScript.KomunikatSamouczekInventoryOk();
        }

        player.GetComponent<Halluns>().DefaultScriptSettings();
        terrainSurfaceScript.enabled = false;
		ResumeGame ();
        player.GetComponent<Crouch>().GetUp();
        player.GetComponent<Crouch>().enabled = false;
        player.GetComponent<OpenCloseObject>().enabled = false;
        player.GetComponent<Compass>().tasksPoints.Clear();
        notesScript.WylaczNotatke();
        playerScript.enabled = false;
		PlayerInstance.isRespown = true;
		PlayerInstance.startNr = "MenuGlowne";
		passCanvas.enabled = true;
		exitToMenuCanvas.enabled = false;
		audioSource.PlayOneShot (menuSound);
		passAnimator.SetTrigger ("Przejscie1");
		isPass2 = true;
		//Kursor.m_ShowCursor = !Kursor.m_ShowCursor;
		cursorScript.m_ShowCursor = true;
		isToMenu = true;
        //ManagerGry.WartosciPoczatkowe ();


        //if (Player.GetComponent<PoczatekGry> ()) {
        //	Destroy (Player.GetComponent<PoczatekGry> ());
        //}

        headbobberScript.enabled = false;
        inventoryScript.enabled = false;
        mapScript.enabled = false;
        scarecrowJumpscareScript.enabled = false;
        screamerScript.enabled = false;
        tasksScript.enabled = false;
        notificationScript.enabled = false;
        flashlightScript.enabled = false;
        notesScript.enabled = false;
        voiceActingScript.enabled = false;
        gameManagerScript.enabled = false;
        jumpscareScript.enabled = false;
        musicScript.enabled = false;
        flashlightLight.enabled = false;
        taskBooksScript.enabled = false;
        KomNapisy.text = "";
        KomGlowny.text = "";
        KomInfo.text = "";
        KomItem.text = "";
        KomPlace.text = "";
        healthScript.enabled = false;

        healthScript.playerDamageCanvas1.enabled = false;
        healthScript.playerDamageCanvas2.enabled = false;
        healthScript.playerDamageCanvas3.enabled = false;
        healthScript.playerInjuredCanvas.enabled = false;

        //CaleMenu.gameObject.GetComponent<Menu>().enabled = false;
        menuCanvas.enabled = false;
        Cursor.visible = false;

    }

	public void HoverButton(){

		audioSource.PlayOneShot (hoverButtonSound);

	}

    public void ShowCredits()
    {

        creticsCanvas.enabled = true;
        creditsBackButton.SetActive(true);
        audioSource.PlayOneShot(menuSound);
        subtitlesAnimator.SetTrigger("Napisy");

    }

    public void CreditsBack()
    {
        creditsBackButton.SetActive(false);
        creticsCanvas.enabled = false;
        audioSource.PlayOneShot(menuSound);
        subtitlesAnimator.SetTrigger("NapisyDefault");

    }

    // rozdzielczosc kursora

    public void SetCursorTo1920()
    {

        
        cursorScript.m_doorTexture = resolution1920[0];
        cursorScript.m_useHandTexture = resolution1920[1];
        cursorScript.m_useNoteTexture = resolution1920[2];
        cursorScript.m_usePushTexture = resolution1920[3];
        cursorScript.m_useSaveTexture = resolution1920[4];
        cursorScript.m_useDrawersTexture = resolution1920[5];
        cursorScript.m_useWardrobeTexture = resolution1920[6];
        cursorScript.m_useMoveTexture = resolution1920[7];
        

    }

    public void SetCursorTo1680()
    {
       
        cursorScript.m_doorTexture = resolution1680[0];
        cursorScript.m_useHandTexture = resolution1680[1];
        cursorScript.m_useNoteTexture = resolution1680[2];
        cursorScript.m_usePushTexture = resolution1680[3];
        cursorScript.m_useSaveTexture = resolution1680[4];
        cursorScript.m_useDrawersTexture = resolution1680[5];
        cursorScript.m_useWardrobeTexture = resolution1680[6];
        cursorScript.m_useMoveTexture = resolution1680[7];
    }

    public void SetCursorTo1366_60()
    {

        cursorScript.m_doorTexture = resolution1366_60[0];
        cursorScript.m_useHandTexture = resolution1366_60[1];
        cursorScript.m_useNoteTexture = resolution1366_60[2];
        cursorScript.m_usePushTexture = resolution1366_60[3];
        cursorScript.m_useSaveTexture = resolution1366_60[4];
        cursorScript.m_useDrawersTexture = resolution1366_60[5];
        cursorScript.m_useWardrobeTexture = resolution1366_60[6];
        cursorScript.m_useMoveTexture = resolution1366_60[7];

    }

    public void SetCursorTo1280()
    {

        cursorScript.m_doorTexture = resolution1280[0];
        cursorScript.m_useHandTexture = resolution1280[1];
        cursorScript.m_useNoteTexture = resolution1280[2];
        cursorScript.m_usePushTexture = resolution1280[3];
        cursorScript.m_useSaveTexture = resolution1280[4];
        cursorScript.m_useDrawersTexture = resolution1280[5];
        cursorScript.m_useWardrobeTexture = resolution1280[6];
        cursorScript.m_useMoveTexture = resolution1280[7];

    }

    public void SetCursorTo1152()
    {

        cursorScript.m_doorTexture = resolution1152[0];
        cursorScript.m_useHandTexture = resolution1152[1];
        cursorScript.m_useNoteTexture = resolution1152[2];
        cursorScript.m_usePushTexture = resolution1152[3];
        cursorScript.m_useSaveTexture = resolution1152[4];
        cursorScript.m_useDrawersTexture = resolution1152[5];
        cursorScript.m_useWardrobeTexture = resolution1152[6];
        cursorScript.m_useMoveTexture = resolution1152[7];

    }


}

