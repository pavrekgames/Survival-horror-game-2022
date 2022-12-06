using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Utility;

public class Health : MonoBehaviour {

    public bool isPlaySound = false;

    private Transform player;
    private Player playerScript;
    private Animator animator;
    private Inventory inventoryScript;
    private SaveGame saveGameScript;
    private Animator passAnimator;
    private Menu gameMenuScript;
    private Map mapScript;

    private AudioClip[] damageSounds;
    private AudioSource audioSource;
    public AudioSource audioSource2;
    private AudioSource damageAudioSource;
    private AudioClip playerInjuredSound;
    private AudioClip playerDeadSound;
    private int randomSound = 0;

    [HideInInspector] public int maxHealth = 100;
	public float health;
	public Canvas playerInjuredCanvas;
	public Canvas playerDamageCanvas1;
	public Canvas playerDamageCanvas2;
	public Canvas playerDamageCanvas3;
    
	public bool isPlayerInjured = false;
	public NoiseAndScratches noisesScreenScript;
	public ColorCorrectionRamp deadScreenScript;
	public bool isStartCount = false;
	public bool isDead = false;
	public bool isPass = false;
	public bool isGameLoaded = false;
	public float counter = 0;
	

    public bool isTravel = false;


    void OnEnable () {
		health = maxHealth;
		player = GameObject.Find("Player").transform;
		playerScript = player.GetComponent<Player>();
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
        noisesScreenScript = GameObject.Find ("Kamera").GetComponent<NoiseAndScratches> (); 
		deadScreenScript = GameObject.Find ("Kamera").GetComponent<ColorCorrectionRamp> ();
		deadScreenScript.enabled = false;
		saveGameScript = GameObject.Find ("Player").GetComponent<SaveGame> ();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
        mapScript = GameObject.Find("Player").GetComponent<Map>();

        isTravel = false;
    }

	void Update () {
		
		HealthCondition ();
	
		if (isDead == true && isGameLoaded == false) {
            gameMenuScript.LoadGame();
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

    public void ReceiveDamage(float damage, Canvas damageCanvas)
    {
        damageCanvas.enabled = true;
        isStartCount = true;
        health -= damage;
    }

    public void PlayDamageSound()
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
    }

    public void HealthCondition(){

		if(health < maxHealth && health > 0 && (!Input.GetKey("left shift")) ){
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

        if (health <= 0 && isDead == false)
        {
            PlayerDead();
        }

        CriticalHealthEffect();
        CheckDamageCanvas();
	
	}

    public void CriticalHealthEffect()
    {
        if (health <= 30 && isPlayerInjured == false && isDead == false)
        {
            isPlayerInjured = true;
            playerInjuredCanvas.enabled = true;
            audioSource2.clip = playerInjuredSound;
            audioSource2.Play();
            audioSource2.loop = true;
            noisesScreenScript.grainIntensityMin = 0.9f;
        }
        else if (health > 30 || isDead == true)
        {
            isPlayerInjured = false;
            playerInjuredCanvas.enabled = false;
            noisesScreenScript.grainIntensityMin = 0.3f;
            audioSource2.clip = null;
            audioSource2.loop = false;
        }
    }

    public void CheckDamageCanvas()
    {
        if (isStartCount == true && counter < 5)
        {
            counter += 1 * Time.deltaTime;
        }
        else
        {
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
		animator.SetTrigger("Death");
		deadScreenScript.enabled = true;
	}
		
}
