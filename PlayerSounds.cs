using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerSounds : MonoBehaviour {

    private Transform player;
	private Health healtScript;
	public Crouch crouchScript;
	//Obiekt odpowiedzialny za ruch gracza.
	public CharacterController characterControler;

	public AudioSource audioSource1;
	public AudioSource audioSource2;

	//public AudioClip dzwiekChodzenie;

	/** Dzwięk skoku.*/
	public AudioClip jumpSound;
	/** Dzwięk lądowania.*/
	public AudioClip landSound;
	/** Licznik do następnego odtwarzania.*/
	public float stepCounter = 0f;
    /** Odstęp pomiędzy jednym a drugim krokiem.*/
    public float stepDuration = 0.6f;

	public AudioClip[] dzwiekiLosowe;
	
	/**Zmienna z informacją o tym czy gracz dalej chodzi po ziemi czy podskoczył.*/
	public bool isGround;
	public bool isRun = false;
		
	/** Component gracza odpowiedzialny za poruszanie.*/
	private Player playerControler;

    /** Tablica z obiektami zawierającymi powiązania tekstury z dzwiękiem.*/
    public TextureSound[] sounds;
    /** Obiekt zawierający teksturę terenu z dzwiękiem do odtwarzania.*/
    private TextureSound currentSound;
    /** Zmienna informuje o kolizji z obiektem zawierającym dzwięk.*/
    private bool isCollide = false;

    // Use this for initialization
    void OnEnable () {
        player = GetComponent<Transform>();
        playerControler = GetComponent<Player> ();
        SetDefaultStepWalkSound();
		healtScript = player.GetComponent<Health>();
		audioSource2 = GameObject.Find ("ZrodloUpadanie_s").GetComponent<AudioSource> ();
    }
	
	// Update is called once per frame
	void Update () {
		if (audioSource1 != null ) {//Jeżeli źródło dzwięku nie zostało podpięte to i tak nie ma co odgrywać.
            //pobierzDzwiek();
            PlayStepWalkSound ();
		}
	}

	/**
	 * Metoda odpowiedzialna za oddtwarzanie dzwięku chodzenia gracza.
	 */
	private void PlayStepWalkSound(){

		if((Input.GetKeyDown("left shift") && Input.GetAxis("Vertical") > 0)){
			isRun = true;
		}else if(Input.GetKeyUp("left shift")){
			isRun = false;
		}

		//Zmniejszanie licznika do kolejnego odtworzenia dźwięku.
		if (stepCounter > 0) {
			//Sprawdzenie, jeżeli gracz biegnie to dźwięk kroku będzie odtwarzany szybciej.
			if (isRun == true && characterControler.isGrounded) {
				stepCounter -= Time.deltaTime * 1.3f;
			} else {
				stepCounter -= Time.deltaTime;
			}
		}

		//Jeżeli gracz się porusza to odgrywaj dzwięk poruszania.

		if ((Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)  && characterControler.isGrounded && stepCounter <= 0 && healtScript.health > 0) {
			//zrodloDzwieku = GetComponent<AudioSource>();
			GetSound();
			audioSource1.pitch = Random.Range(0.8f, 1.5f);
			stepCounter = stepDuration;//Czas trwania dzwięku.
			audioSource1.PlayOneShot (currentSound.sound);
		}
			
		//Jeżeli gracz podskoczył i znajduje się na ziemi to odegraj dzwięk skoku.
		if (Input.GetButtonDown("Jump") && crouchScript.isCrouch == false && healtScript.health > 0 && isGround) { // && characterControler.isGrounded
            audioSource2.pitch = Random.Range(0.8f, 1.1f);
            audioSource2.clip = jumpSound;
            //ZrodloDzwieku2.time = 0.150f;
            audioSource2.Play();
            //ZrodloDzwieku2.PlayOneShot (dzwiekSkoku);
		}
		//Jeżeli gracz ostatnio był w powietrzu a teraz na ziemi to znaczy, że wylondował na ziemi
		//zatem odegraj dzwięk londowania.

		if(!isGround && characterControler.isGrounded && healtScript.health > 0) {		
			audioSource1.pitch = Random.Range(0.8f, 1.5f);
			audioSource1.PlayOneShot (landSound);				
		}
		//Na zakończenie sprawdzamy czy gracz ciągle chodzi po ziemi.
		isGround = characterControler.isGrounded;
	}

    /**
     * Metoda pobiera nazwę tekstury a następnie obiekt DzwiekDlaTekstury zawierający nazwę pobranej tekstury.
     * Porany obiekt zwiera dzwięk do odtworzenia.
     */

  /*  private void pobierzDzwiek() {
        if (!kolizjaZObiektem) {//Nie ma kolizji z obiektem więc zostanie pobrany dzwięk dla tekstury.
            bool pobrany = false;//Informuje o pobraniu dzwięku dla tekstury.
            foreach (DzwiekDlaTekstury dzwiek in dzwieki) {
				if (dzwiek.tekstura != null && dzwiek.tekstura.name.Equals(PowierzchniaTerenu.NazwaTeksturyWPozycji(trans.position))) { 
                    aktualnyDzwiek = dzwiek;
                    pobrany = true;
                    break;
                }
            }
            if (!pobrany) {//Dzwięk nie został pobrany, tekstura nie ma przypisanego dzwięku.
                aktualnyDzwiek = dzwieki[0];//Ustawiam dzwięk domyślny.
            }
        }
    } */



	private void GetSound() {
		if (!isCollide) {//Nie ma kolizji z obiektem więc zostanie pobrany dzwięk dla tekstury.
			bool isGot = false;//Informuje o pobraniu dzwięku dla tekstury.
		for (int i=0; i<sounds.Length; i++) {
				TextureSound sound = sounds [i];
			if (sound.texture != null && sound.texture.name.Equals(TerrainSurface.TextureNameInPosition(player.position))) {
					currentSound = sound;
					isGot = true;
					break;
				}
			}
			if (!isGot) {//Dzwięk nie został pobrany, tekstura nie ma przypisanego dzwięku.
				currentSound = sounds[0];//Ustawiam dzwięk domyślny.
			}
		}
	} 


    /**
     * Metoda dostarcza dzwięk pobrany z obiektu, z którym koliduje obiekt gracza.
     */
    void OnControllerColliderHit(ControllerColliderHit hit) {        
        Transform collideObject = hit.collider.gameObject.GetComponent<Transform>();
                
        if (collideObject.tag == "Teren") { //Czy gracz porusza się po terenie.
            isCollide = false; //Nie ma kolizji z obiektem nastąpi pobranie dzwięku tekstury.
        } else {
            ObjectSound objectSound = collideObject.GetComponent<ObjectSound>();//Pobieram komponent z dzwiękiem.
            if (objectSound != null && objectSound.textureSound.sound != null) {
                currentSound = objectSound.textureSound; //Ustawiam dzwięk kroku pobrany z obiektu.
            } else {
                //Obiekt ma podpięty skrypt dzwięku ale dzwięk nie został ustawiony więc pobieram dźwięk domyślny.
                currentSound = sounds[0];//Ustawiam dzwięk domyślny.
            }
            isCollide = true; //Kolizja z obiektem.
        }        
    }

    private void SetDefaultStepWalkSound() {
        if(sounds.Length > 0 && sounds[0].sound != null) {
            currentSound = sounds[0];
        }
    }
   

}

