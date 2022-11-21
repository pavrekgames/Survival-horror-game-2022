using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Utility;

public class Health : MonoBehaviour {

    public bool isPlaySound = false;

    public AudioClip[] damageSounds;
    public int randomSound = 0;

    public int maxHealth = 100;
	public float health;
	public Canvas playerInjuredCanvas;
	public Canvas playerDamageCanvas1;
	public Canvas playerDamageCanvas2;
	public Canvas playerDamageCanvas3;
	public AudioSource audioSource;
	public AudioSource audioSource2;
    public AudioSource damageAudioSource;
    public AudioClip playerInjuredSound;
	public AudioClip playerDeadSound;
	public bool isPlayerInjured = false;
	public NoiseAndScratches noisesScreenScript;
	public ColorCorrectionRamp deadScreenScript;
	public bool isStartCount = false;
	public bool isDead = false;
	public bool isPass = false;
	public bool isGameLoaded = false;
	public float counter = 0;
	private Transform player;
	private Player playerScript;
	private Animator animator;
	private Inventory inventoryScript;
	private SaveGame saveGameScript;
	private Animator passAnimator;
	private Menu gameMenuScript;
    private Map mapScript;

    public bool isTravel = false;


    void OnEnable () {
		health = maxHealth;
		player = GameObject.Find("Player").transform;
		playerScript = player.GetComponent<Player>();
		//Sterowanie.enabled = true;
		animator = GetComponent<Animator>();
		inventoryScript = player.GetComponent<Inventory>();
		passAnimator = GameObject.Find ("Przejscie").GetComponent<Animator> ();

		playerInjuredCanvas = GameObject.Find ("CanvasGraczRanny").GetComponent<Canvas> ();
		playerDamageCanvas1 = GameObject.Find ("CanvasGraczObrazenia").GetComponent<Canvas> ();
		playerDamageCanvas2 = GameObject.Find ("CanvasGraczObrazenia2").GetComponent<Canvas> ();
		playerDamageCanvas3 = GameObject.Find ("CanvasGraczObrazenia3").GetComponent<Canvas> ();
		audioSource = GameObject.Find ("Głowa").GetComponent<AudioSource> ();
		audioSource2 = GameObject.Find ("ZrodloRanny_s").GetComponent<AudioSource>();
        damageAudioSource = GameObject.Find("ZrodloObrazenia_s").GetComponent<AudioSource>();
        //DzwRanny = Resources.Load<AudioClip>("Muzyka/GraczRanny_v1");
        //DzwCios = Resources.Load<AudioClip>("Muzyka/Gracz_bol");
        //DzwMartwy = Resources.Load<AudioClip>("Muzyka/GraczSmierc_v1");
        noisesScreenScript = GameObject.Find ("Kamera").GetComponent<NoiseAndScratches> (); 
		deadScreenScript = GameObject.Find ("Kamera").GetComponent<ColorCorrectionRamp> ();
		deadScreenScript.enabled = false;
		saveGameScript = GameObject.Find ("Player").GetComponent<SaveGame> ();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
        mapScript = GameObject.Find("Player").GetComponent<Map>();

        isTravel = false;
    }

	void Update () {
		
		HealtCondition ();

		if(health <= 0 && isDead == false){
			PlayerDead ();
		}
			
		if (isDead == true && isGameLoaded == false) { // animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && animator.GetCurrentAnimatorStateInfo(0).IsName("Smierc") && !animator.IsInTransition(0) && 
			isGameLoaded = true;
			gameMenuScript.passCanvas.enabled = true;
			gameMenuScript.isLoadedGame = true;
			passAnimator.SetTrigger("Przejscie1");
			gameMenuScript.isPass2 = true;
			player.GetComponent<PlayerSounds> ().enabled = false;
			//Player.GetComponent<Kucanie> ().enabled = false;
			player.GetComponent<EndGame> ().enabled = false;
            player.GetComponent<RandomJumpscare>().enabled = false;
            player.GetComponent<Halluns>().enabled = false;
            player.GetComponent<OpenCloseObject>().enabled = false;
            player.GetComponent<DragObject>().SetDefaultValues();
            player.GetComponent<DragObject>().enabled = false;
            player.GetComponent<DragRigidbody>().enabled = false;
            gameMenuScript.voiceActingScript.retroEffectScript.intensity = 0;
			//MenuGlowne.enabled = true;
			gameMenuScript.playerScript.enabled = false;
			gameMenuScript.headbobberScript.enabled = false;
			gameMenuScript.inventoryScript.enabled = false;
			gameMenuScript.mapScript.enabled = false;
			gameMenuScript.screamerScript.enabled = false;
			gameMenuScript.tasksScript.enabled = false;
			gameMenuScript.notificationScript.enabled = false;
			gameMenuScript.flashlightScript.enabled = false;
			gameMenuScript.notesScript.enabled = false;
			gameMenuScript.voiceActingScript.enabled = false;
			gameMenuScript.gameManagerScript.enabled = false;
			gameMenuScript.jumpscareScript.enabled = false;
			gameMenuScript.musicScript.enabled = false;
			gameMenuScript.taskBooksScript.enabled = false;
			gameMenuScript.taskMeatScript.enabled = false;
			gameMenuScript.cursorScript.enabled = false;
			gameMenuScript.flashlightLight.enabled = false;
			gameMenuScript.KomNapisy.text = "";
			gameMenuScript.KomGlowny.text = "";
			gameMenuScript.KomInfo.text = "";
			gameMenuScript.KomItem.text = "";
			gameMenuScript.KomPlace.text = "";
			gameMenuScript.healthScript.enabled = false;

			saveGameScript.Wczytano_ok = false;

            // czy mozna uzyc szybkiej podrozy

            if(health > 50 && isTravel == false)
            {
                mapScript.isFastTravel = true;
                isTravel = true;
            }

		}

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isPlaySound == false)
        {

            audioSource2.Pause();

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && isPlaySound == true)
        {

            audioSource2.UnPause();

            isPlaySound = false;
        }

    }

	public void PlayerDamage(){

        if (randomSound < 4)
        {
            randomSound = Random.Range(4, 9);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }
        else
        {
            randomSound = Random.Range(0, 4);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }

        playerDamageCanvas1.enabled = true;
		isStartCount = true;
		health = health - 20;
	}

	public void PlayerDamage2(){

        if (randomSound < 4)
        {
            randomSound = Random.Range(4, 9);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }
        else
        {
            randomSound = Random.Range(0, 4);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }

        playerDamageCanvas1.enabled = true;
		isStartCount = true;
		health = health - 50;
	}
		
	public void PlayerDamage3(){

        if (randomSound < 4)
        {
            randomSound = Random.Range(4, 9);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }
        else
        {
            randomSound = Random.Range(0, 4);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }

        playerDamageCanvas2.enabled = true;
		isStartCount = true;
		health = health - 35;
	}

	public void PlayerDamage4(){

        if (randomSound < 4)
        {
            randomSound = Random.Range(4, 9);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }
        else
        {
            randomSound = Random.Range(0, 4);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }

        playerDamageCanvas3.enabled = true;
		isStartCount = true;
		health = health - 20;
	}

    public void PlayerDamage5()
    {

        if (randomSound < 4)
        {
            randomSound = Random.Range(4, 9);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }
        else
        {
            randomSound = Random.Range(0, 4);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }

        playerDamageCanvas3.enabled = true;
        isStartCount = true;
        health = health - 110;
    }

    public void PlayerDamage6()
    {

        if(randomSound < 4)
        {
            randomSound = Random.Range(4, 9);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }else
        {
            randomSound = Random.Range(0, 4);
            damageAudioSource.pitch = Random.Range(0.8f, 1.5f);
            damageAudioSource.PlayOneShot(damageSounds[randomSound]);
        }

        playerDamageCanvas3.enabled = true;
        isStartCount = true;
        health = health - 10;
    }


    public void HealtCondition(){
		if(health < maxHealth && health > 0 && (!Input.GetKey("left shift") || inventoryScript.isSkill4_Unlocked == true) ){
			health += 2 * Time.deltaTime;
		}

		if(health > maxHealth){
			health = maxHealth;
		}

		if(health <= 50 && isDead == false){
			noisesScreenScript.enabled = true;
            isTravel = false;
            mapScript.isFastTravel = false;
		}else{
			noisesScreenScript.enabled = false;
		} 

		//if(AktualneZdrowie <= 30){
			//ObrazGracza.grainIntensityMin = 0.9f;
		//}

		if(health <= 30 && isPlayerInjured == false && isDead == false){
			isPlayerInjured = true;
			playerInjuredCanvas.enabled = true;
			audioSource2.clip = playerInjuredSound;
			audioSource2.Play();
			audioSource2.loop = true;
            noisesScreenScript.grainIntensityMin = 0.9f;
        }
        else if(health > 30 || isDead == true){
			isPlayerInjured = false;
			playerInjuredCanvas.enabled = false;
			noisesScreenScript.grainIntensityMin = 0.3f;
			audioSource2.clip = null;
			audioSource2.loop = false;
		} 


		if(isStartCount == true && counter < 5){
			counter +=  1 * Time.deltaTime;
		}else{
			isStartCount = false;
			counter = 0;
			playerDamageCanvas1.enabled = false;
			playerDamageCanvas2.enabled = false;
			playerDamageCanvas3.enabled = false;
		}
	}

	public void PlayerDead(){
		player.GetComponent<Crouch> ().GetUp();
		playerScript.enabled = false;
        damageAudioSource.PlayOneShot(playerDeadSound);
		isDead = true;
		animator.SetTrigger("Smierc");
		deadScreenScript.enabled = true;
	}
		
}
