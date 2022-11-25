using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notifications : MonoBehaviour {

    public bool isPlaySound = false; // wznawianie i zatrzymywanie dzwiekow

    private Canvas notificationsCanvas;

    private Menu gameMenuScript;
	private Inventory inventoryScript;
	private Tasks tasksScript;
	private TaskWell taskWellScript;
	private TaskBooks taskBooksScript;
	private Screamer screamerScript;
    private Player playerScript;
    public PlayerManager playerManagerScript;

	private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;

	//public Canvas CanvasKomunikaty;
	public TextMeshProUGUI mainNotificationTextMesh;
	public TextMeshProUGUI infoNotificationTextMesh;
	public TextMeshProUGUI taskNotificationTextMesh;
    public TextMeshProUGUI doorNotificationTextMesh;
    public TextMeshProUGUI saveGameNotificationTextMesh;
	public TextMeshProUGUI secretItemsNotificationTextMesh;
	public TextMeshProUGUI secretPlacesNotificationTextMesh;
    public Canvas herbsNotificationCanvas;
    public Canvas saveGameNotificationCanvas;
    public Canvas pushNotificationCanvas;
    public Canvas secretNotificationCanvas;
    public Canvas itemsNotificationCanvas;
    public Canvas inventoryNotificationCanvas;
    public float secretItemsTime = 3f;
	public float secretPlacesTime = 3f;
	public float notificationTime = 3f;
	public bool isNotificationTimeOn = false;
	public bool isSecretItemNotification = false;
	public bool isGreenHerbNotification = false;
	public bool isBlueHerbNotification = false;
    public bool isVialNotification = false;
    public bool isStaminaPotNotification = false;
    public bool isHealthPotNotification = false;
    public bool isBadgeNotification = false;
    public bool isPhotoNotification = false;
    public bool isTipNotification = false;

    public bool isTutorialNotification = false;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource tutorialAudioSource;
    public AudioSource audioSource4;
    public AudioClip doorLockedSound;
	public AudioClip planksSound;
	public AudioClip lackPowerSound;
	public AudioClip insertCasseteSound;
	public AudioClip metalDoorLockedSound;
	public AudioClip lackChipSound;
    public AudioClip tutorialSound;

	public bool isLightNotification = false;
	public bool isLight2Notification = false;
	public bool isTaskInfoNotification = false;
	public bool isSprintNotification = false;
	public bool isMapNotification = false;
	public bool isCrouchNotification = false;
    public bool isDoorNotification = false;
    public bool isHerbsNotification = false;
    public bool isSaveNotification = false;
    public bool isDragNotification = false;
    public bool isPushNotification = false;
    public bool isSecretNotification = false;
    public bool isItemsNotification = false;
    public bool isInventoryNotification = false;
    private Door firstDoorSoundScript;
    public bool isBatteriesNotification = false;
	public bool isChipNotification = false;
	public bool isCasseteNotification = false;
	public bool isCassete3Notification = false;

	private Transform player;
    private Transform bookShelf;

    public bool isGardenDoor = false;
    public bool isCornfieldDoor = false;
    public bool isStableDoor = false;
    public bool isCorridorWardrobe = false;
    public bool isUncleDoor = false;
    public bool isKitchenWardrobe = false;
    public bool isSecretRoomDoor = false;
    public bool isPlanks = false;
    public bool isToolShedDoor = false;
    public bool isNicheDoor = false;
    public bool isCassetePlayer = false;
    public bool isAliceRoomDoor = false;
    public bool isFactoryMetalDoor = false;
    public bool isVictorInvention = false;
    public bool isFactoryWoodenDoor = false;
    public bool isShedCupboard = false;
    public bool isTomRoomDoor = false;
    public bool isTomUpstairsDoor = false;
    public bool isPumpkinPile = false;
    public bool isCassetePlayer2 = false;
    public bool isOldWardrobe = false;
    public bool isCassetePlayer3 = false;
    public bool isStevenDoor = false;
    public bool isStevenGrille = false;
    public bool isPaulDoor = false;
    public bool isPaulJumpscareDoor = false;
    public bool isThorns = false;

    // teksty do komunikatów
    public string keyInsideMessage = "A Key is inside...";
    public string keyToFixMessage = "Put the key you want to repair";
    public string woodenWheelMessage = "One element is missing";
    public string edwardKeyMessage = "I have to find a Edward's key";
    public string pumpkinMessage = "One pumpkin is missing";
    public string booksMessage = "Select a book to replace";
    public string insertCasseteMessage = "Insert the Cassete";
    public string lackChipMessage = "No Chip...";
    public string lockedDoorMessage = "This door is locked...";
    public string lockedWardrobeMessage = "I need a key...";
    public string thornsMessage = "I need something strong to destroy this";
    public string lockedGardenDoorMessage = "I need an oil or something like this";
    public string lockedFactoryDoorMessage = "I need the crowbar...";
    public string lockedCornfieldDoorMessage = "I have to find a tool to cut this wire";
    public string planksMessage = "Hmmm I have to destroy this";
	public string stevenGrilleMessage = "I need something strong to destroy this...";
    public string factoryLeverMessage = "Needs power...";
    public string flashlightHint = "Press <color=#280DF6FF>[F]</color> to turn on / off a flashlight";
    public string lightHint = "Press <color=#280DF6FF> Middle Mouse Button</color> to increase range of light";
    public string tasksHint = "Press <color=#280DF6FF>[ I ]</color> to see Inventory and Tasks";
	public string sprintHint = "Press <color=#280DF6FF>[Left Shift]</color> to sprint";
    public string mapHint = "Press <color=#280DF6FF>[M]</color> to see a Map";
    public string crouchHint = "Press <color=#280DF6FF>[C]</color> to Crouch";
    public string doorHint = "Hold down <color=#280DF6FF>[Left Mouse Button]</color> and move the mouse in order to move the door.";
    public string secretItemNotification = "You picked up a Secret Item";
	public string greenHerbNotification = "You picked up a <color=#33D047FF>Green Herb</color>";
	public string blueHerbNotification = "You picked up a <color=#006EFFFF>Blue Herb</color>";
    public string vialNotification = "You picked up a <color=#F6FF04FF>Vial</color>";
    public string staminaPotNotification = "You picked up a <color=#FF00FFFF>Stamina Mixture</color>";
    public string healthPotNotification = "You picked up a <color=#F6FF04FF>Health Potion</color>";
    public string badgeNotification = "You picked up a <color=#F6FF04FF>Badge</color> to collection";
    public string photoNotification = "You picked up a <color=#F6FF04FF>Photo</color> to collection";
    public string tipNotification = "You picked up a <color=#F6FF04FF>Tip</color> to collection";
    public string dragHint = "Hold down <color=#280DF6FF>[Left Mouse Button]</color> and move the mouse in order to move some objects.";

    // komunikaty nad drzwiami

    public string uncleDoorMessage = "Uncle's room";
    public string stableDoorMessage = "Stable";
    public string gardenDoorMessage = "A metal door to the garden";
    public string cornfieldDoorMessage = "Door to the corn field";
    public string corridorWardrobeMessage = "Wardrobe in corridor";
    public string kitchenWardrobeMessage = "Wardrobe in the kitchen";
    public string toolShedDoorMessage = "Shed";
    public string secretRoomDoorMessage = "Secret room";
    public string nicheDoorMessage = "Wooden door";
    public string aliceRoomDoorMessage = "Alice's living room";
    public string factoryWoodenDoorMessage = "Victor's workshop";
    public string shedCupboardMessage = "Edward's cupboard";
    public string tomRoomDoorMessage = "Tom's room";
    public string tomUpstairsDoorMessage = "Tom's office";
    public string oldWardrobeMessage = "Old wardrobe";
    public string stevenDoorMessage = "Steven's room";
    public string paulDoorMessage = "Scientist's room";
    public string paulJumpscareDoorMessage = "Scientist's office";

    // komunikat dodania nowego zadania

    public TextMeshProUGUI taskHintTextMesh;
    public Image taskHintBackground;
    public float taskHintTime = 5f;

    public enum NotificationType
    {
        None, 
        SecretItem,
        GreenHerb,
        BlueHerb,
        Vial ,
        StaminaPot,
        HealthPot,
        Badge,
        Photo,
        Tip,
        Tutorial
}

    public NotificationType notificationType;

    void OnEnable () {

        notificationsCanvas = GameObject.Find("CanvasKomunikaty").GetComponent<Canvas>();

		playerCam = Camera.main;
        playerScript = GameObject.Find("Player").GetComponent<Player>();

        firstDoorSoundScript = GameObject.Find("DrzwiDom").GetComponent<Door>();
		player = GameObject.Find("Player").transform;
        bookShelf = GameObject.Find("Biblioteka_Ksiazki").transform;

        gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
		inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();
		tasksScript = GameObject.Find ("Player").GetComponent<Tasks> ();
		taskWellScript = GameObject.Find ("StudniaTrigger").GetComponent<TaskWell> ();
		taskBooksScript = GameObject.Find ("Player").GetComponent<TaskBooks> ();
		screamerScript = GameObject.Find ("Player").GetComponent<Screamer> ();

		//CanvasKomunikaty = GameObject.Find ("CanvasKomunikaty").GetComponent<Canvas> ();
		mainNotificationTextMesh = GameObject.Find ("GlownyKomunikat").GetComponent<TextMeshProUGUI> ();
		infoNotificationTextMesh = GameObject.Find ("InfoKomunikat").GetComponent<TextMeshProUGUI> ();
		taskNotificationTextMesh = GameObject.Find ("ZadanieKomunikat").GetComponent<TextMeshProUGUI> ();
        doorNotificationTextMesh = GameObject.Find("DrzwiInfoKomunikat").GetComponent<TextMeshProUGUI>();
        saveGameNotificationTextMesh = GameObject.Find ("ZapisKomunikat").GetComponent<TextMeshProUGUI> ();
		secretItemsNotificationTextMesh = GameObject.Find ("SecretItemKomunikat").GetComponent<TextMeshProUGUI> ();
		secretPlacesNotificationTextMesh = GameObject.Find ("SecretPlaceKomunikat").GetComponent<TextMeshProUGUI> ();

		audioSource = GameObject.Find("ZrodloPrzedmiot3_s").GetComponent<AudioSource>();
		audioSource2 = GameObject.Find("ZrodloPrzedmiot2_s").GetComponent<AudioSource>();
        tutorialAudioSource = GameObject.Find("ZrodloKomunikat_s").GetComponent<AudioSource>();
        audioSource4 = GameObject.Find("ZrodloPrzedmiot4_s").GetComponent<AudioSource>();

        herbsNotificationCanvas = GameObject.Find("CanvasKomZiola").GetComponent<Canvas>();
        saveGameNotificationCanvas = GameObject.Find("CanvasKomZapis").GetComponent<Canvas>();
        pushNotificationCanvas = GameObject.Find("CanvasKomPchanie").GetComponent<Canvas>();
        secretNotificationCanvas = GameObject.Find("CanvasKomSecret").GetComponent<Canvas>();
        itemsNotificationCanvas = GameObject.Find("CanvasKomItems").GetComponent<Canvas>();
        inventoryNotificationCanvas = GameObject.Find("CanvasKomInventory").GetComponent<Canvas>();

        taskHintTextMesh = GameObject.Find("ZadanieWskazowka").GetComponent<TextMeshProUGUI>();
        taskHintBackground = GameObject.Find("ZadanieWskazowkaTlo").GetComponent<Image>();

    }
	

	void Update () {

		if (isNotificationTimeOn == true && notificationTime <= 3) {
			notificationTime += 1 * Time.deltaTime;
		} else if (notificationTime > 3) {
			infoNotificationTextMesh.text = "";
            doorNotificationTextMesh.text = "";
			isNotificationTimeOn = false;
			//CanvasKomunikaty.enabled = false;
		}


		HideMainNotification ();
		NotificationTime ();

		//Debug.Log(DystansOdtwarzacz);
		 
		// Komunikat przy studni w lesie na zachod od domu

		if (taskWellScript.enabled == true) {

			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit; 

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {

				//Debug.Log(hit.collider.gameObject.name);

				if (hit.collider.gameObject.name == "BlokadaStudniaKamienie" && taskWellScript.stonesCount < 5) {  //  && DystansStudnia <= 5
					notificationTime = 0;
					isNotificationTimeOn = true;
					//CanvasKomunikaty.enabled = true;
					infoNotificationTextMesh.text = keyInsideMessage;
				}
			}
		}

		// Komunikat do ksiazek

		if (taskBooksScript.enabled == true) {

			float DystansBibliotekaKsiazki = Vector3.Distance (player.position, bookShelf.position);

			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit; 

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {

				if (hit.collider.gameObject.tag == "Hand" && DystansBibliotekaKsiazki < 11 && taskBooksScript.isBookTaken == true) {
					notificationTime = 0;
					isNotificationTimeOn = true;
					//CanvasKomunikaty.enabled = true;
					infoNotificationTextMesh.text = booksMessage;
				}
			}
		}

		// glowne komunikaty

		if (Input.GetMouseButtonDown (0) && playerManagerScript.isPlayerCanInput == true) {

			//playerCam = Camera.main;
			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit; 

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {

				// Komunikat do drzwi w ogrodzie

				if (hit.collider.gameObject.name == "DrzwiOgrod" && tasksScript.isGardenDoorLocked == true && isGardenDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;
					KomunikatDrzwiOgrod ();
                    doorNotificationTextMesh.text = gardenDoorMessage;
				}

			// Komunikat do drzwi na polu kukurydzy

			else if (hit.collider.gameObject.name == "DrzwiKukurydza" && tasksScript.isCornfieldDoorLocked == true && isCornfieldDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;
					KomunikatDrzwikukurydza ();
                    doorNotificationTextMesh.text = cornfieldDoorMessage;
                }
				
			// Komunikat do drzwi stajni

			else if (hit.collider.gameObject.name == "DrzwiStajnia" && tasksScript.isStableDoorLocked == true && isStableDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = stableDoorMessage;
                }

			// Komunikat do szafki w korytarzu

			else if (hit.collider.gameObject.name == "SzafaKorytarz" && tasksScript.isCorridorWardrobeLocked == true && isCorridorWardrobe == false) {  
					notificationTime = 0;
					isNotificationTimeOn = true;
					KomunikatSzafa ();
                    doorNotificationTextMesh.text = corridorWardrobeMessage;
                }

			// Komunikat do drzwi do pokoju W

			else if (hit.collider.gameObject.name == "DrzwiPokojW" && tasksScript.isUncleDoorLocked == true && isUncleDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = uncleDoorMessage;
                }

			// Komunikat do szafki w kuchni

			else if (hit.collider.gameObject.name == "SzafaKuchnia" && tasksScript.isKitchenWardrobeLocked == true && isKitchenWardrobe == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;
					KomunikatSzafa ();
                    doorNotificationTextMesh.text = kitchenWardrobeMessage;
                }

			// Komunikat do drzwi od kampingu

			else if (hit.collider.gameObject.name == "DrzwiKamping" && tasksScript.isSecretRoomDoorLocked == true && isSecretRoomDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = secretRoomDoorMessage;
                }

			// Komunikat do zabitych desek przy szopie

			else if (hit.collider.gameObject.name == "DeskiSzopa" && tasksScript.isPlanksLocked == true && isPlanks == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDeskiSzopa ();
				}

			// Komunikat do drzwi do szopy z narzedziami w 1 lokacji

			else if (hit.collider.gameObject.name == "DrzwiSzopaNarzedzia" && tasksScript.isToolShedDoorLocked == true && isToolShedDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = toolShedDoorMessage;
                }

			// Komunikat do drzwi wneki

			else if (hit.collider.gameObject.name == "DrzwiWneka" && tasksScript.isNicheDoorLocked == true && isNicheDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = nicheDoorMessage;
                }

			// Komunikat do odtwarzacza bez kasety

			else if (hit.collider.gameObject.name == "Odtwarzacz" && tasksScript.isCasseteInserted == false && tasksScript.isBatteriesPut == false)
                { // DystansOdtwarzacz <= 11 && // 
                    notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatKaseta ();
				}

            else if (hit.collider.gameObject.name == "Odtwarzacz" && tasksScript.isCasseteInserted == true && tasksScript.isBatteriesPut == false)
                { 
                    audioSource.clip = lackPowerSound;
                    audioSource.Play();
					isBatteriesNotification = true;
				}

				// Komunikat do drzwi do salonu na poludniu

				if (hit.collider.gameObject.name == "DrzwiSalonPoludnie" && tasksScript.isAliceRoomDoorLocked == true && isAliceRoomDoor == false) {  
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = aliceRoomDoorMessage;
                }
				
			// Komunikat do metalowych drzwi w fabryce 

			else if (hit.collider.gameObject.name == "DrzwiFabrykaMetal" && tasksScript.isFactoryMetalDoorLocked == true && isFactoryMetalDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDrzwiFabrykaMetal ();
				}

			// Komunikat do urzadzenia Victora bez klucza

			else if ((hit.collider.gameObject.name == "UrzadzenieVictora" || hit.collider.gameObject.name == "BrakujaceDrewnianeKolo") && tasksScript.isBrokenKey == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					infoNotificationTextMesh.text = keyToFixMessage;
				}

			// Komunikat do urzadzenia Victora bez klucza

			else if (hit.collider.gameObject.name == "UrzadzenieVictora" && tasksScript.isBrokenKey == true && tasksScript.isWheel == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					infoNotificationTextMesh.text = woodenWheelMessage;
				}

			// Komunikat do drewnianych drzwi fabryki 

			else if (hit.collider.gameObject.name == "DrzwiFabrykaDrewno" && tasksScript.isFactoryWoodenDoorLocked == true && isFactoryWoodenDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = factoryWoodenDoorMessage;
                }

			// Komunikat do szafki w szopie

			else if (hit.collider.gameObject.name == "SzafkaSzopa" && tasksScript.isShedCupboardLocked == true && isShedCupboard == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					infoNotificationTextMesh.text = edwardKeyMessage;
                    doorNotificationTextMesh.text = shedCupboardMessage;
                }

			// Komunikat do drzwi do pokoju Toma 

			else if (hit.collider.gameObject.name == "DrzwiPokojTom" && tasksScript.isTomRoomDoorLocked == true && isTomRoomDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = tomRoomDoorMessage;
                }

			// Komunikat do drzwi do pokoju u Toma na gorze 

			else if (hit.collider.gameObject.name == "DrzwiTomGora" && tasksScript.isTomUpstairsDoorLocked == true && isTomUpstairsDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = tomUpstairsDoorMessage;
                }

			// Komunikat do palu bez dyni

			else if (hit.collider.gameObject.name == "PalDynia" && tasksScript.isPumpkin == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					infoNotificationTextMesh.text = pumpkinMessage;
				}
					
			// Komunikat do odtwarzacza 2 bez kasety

			else if (hit.collider.gameObject.name == "Odtwarzacz2" && tasksScript.isCassete3Inserted == false && tasksScript.isChipPut == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					infoNotificationTextMesh.text = insertCasseteMessage;
				}

				// Komunikat do odtwarzacza bez chipu

			/*	if (hit.collider.gameObject.name == "Odtwarzacz2" && Tasks.WlozKasete3_ok == true && Tasks.WlozChip_ok == false && JestKaseta3_ok == false) { // DystansOdtwarzacz2 <= 11 &&
					//ZrodloDzwieku2.PlayOneShot (DzwWlozKasete);
					JestKaseta3_ok = true;
				} */

				else if (hit.collider.gameObject.name == "Odtwarzacz2" && tasksScript.isCassete3Inserted == true && tasksScript.isChipPut == false) { 
					//ZrodloDzwieku.PlayOneShot (DzwBrakChipu);
                    audioSource4.clip = lackChipSound;
                    audioSource4.Play();
					isChipNotification = true;
					//Tasks.BrakChip_ok = true;
				}
				

			// Komunikat do szafki w opuszczonym domu

			else if (hit.collider.gameObject.name == "SzafaStaryDom" && tasksScript.isOldWardrobeLocked == true && isOldWardrobe == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatSzafa ();
                    doorNotificationTextMesh.text = oldWardrobeMessage;
                }

			// Komunikat do odtwarzacza 3

			else if (hit.collider.gameObject.name == "Odtwarzacz3" && tasksScript.isCassete4Inserted == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					infoNotificationTextMesh.text = insertCasseteMessage;
				}

			// Komunikat do drzwi w domu Stevena

			else if (hit.collider.gameObject.name == "DrzwiSteven" && tasksScript.isStevenDoorLocked == true && isStevenDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = stevenDoorMessage;
                }

			// Komunikat do kart szopy Stevena

			else if (hit.collider.gameObject.name == "KratySteven" && tasksScript.isStevenGrille == true) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatKratySteven ();
				}

			// Komunikat do drzwi w domu lokatora za potokiem na zachodzie

			else if (hit.collider.gameObject.name == "DrzwiZachod" && tasksScript.isPaulDoorLocked == true && isPaulDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = paulDoorMessage;
                } 

			// Komunikat do drzwi jumpscare na zachodzie

			else if (hit.collider.gameObject.name == "DrzwiOtworzJmp" && screamerScript.isOpenDoor == false && isPaulJumpscareDoor == false) { 
					notificationTime = 0;
					isNotificationTimeOn = true;	
					KomunikatDrzwi ();
                    doorNotificationTextMesh.text = paulJumpscareDoorMessage;
                }

            // Komunikat do cierni

			else if (hit.collider.gameObject.name == "CiernieKryjowka2_c") { 
					notificationTime = 0;
					isNotificationTimeOn = true;
					KomunikatCiernie ();
				}

			} // Klamra do Raycast 
				
			
		else if (tasksScript.isBatteriesPut == true) { 
				isBatteriesNotification = false;
			}

		} // klamra do przycisku

		// kaseta 1 i bateria

		if (audioSource.isPlaying == false && isBatteriesNotification == true && playerManagerScript.isPlayerCanInput == true) { 
			isBatteriesNotification = false;
			notificationTime = 0;
			isNotificationTimeOn = true;
			KomunikatEnergia();
		}

		// kaseta 3 i chip

		if (audioSource.isPlaying == false && isChipNotification == true && playerManagerScript.isPlayerCanInput == true) { 
			notificationTime = 0;
			isNotificationTimeOn = true;	
			//CanvasKomunikaty.enabled = true;
			infoNotificationTextMesh.text = lackChipMessage;

			if (tasksScript.isTomChipTask == true) {
				isChipNotification = false;
			}

		}

        // Zatrzymanie odtwarzania dzwiekow oraz wylaczanie canvasa komunikatow

        if (Time.timeScale == 0 && isPlaySound == false)
        {

            audioSource.Pause();
            audioSource2.Pause();

            notificationsCanvas.enabled = false;

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow oraz wlaczanie canvasa komunikatow

        if (Time.timeScale == 1 && isPlaySound == true)
        {

            audioSource.UnPause();
            audioSource2.UnPause();

            notificationsCanvas.enabled = true;

            isPlaySound = false;
        }

} // klamra do update


	void HideMainNotification(){

		if(isLightNotification == false){
			//CanvasKomunikaty.enabled = true;
			mainNotificationTextMesh.text = flashlightHint;
		}

		if(Input.GetButtonDown("Flashlight") && isLightNotification == false && playerManagerScript.isPlayerCanInput == true)
        {
            isLightNotification = true;
			mainNotificationTextMesh.text = "";
		}

		if(Input.GetButtonDown("Sprint") && isSprintNotification == false && playerManagerScript.isPlayerCanInput == true)
        {
			isSprintNotification = true;
			mainNotificationTextMesh.text = "";
		}

		if(Input.GetMouseButton(2) && isLight2Notification == false && playerManagerScript.isPlayerCanInput == true)
        {
			isLight2Notification = true;
			mainNotificationTextMesh.text = "";
		}

		if(Input.GetButtonDown("Inventory") && isTaskInfoNotification == false && playerManagerScript.isPlayerCanInput == true)
        {
			isTaskInfoNotification = true;
			mainNotificationTextMesh.text = "";
		}

		if(Input.GetButtonDown("Map") && isMapNotification == false && playerManagerScript.isPlayerCanInput == true)
        {
			isMapNotification = true;
			mainNotificationTextMesh.text = "";
		}

		if(Input.GetButtonDown("Crouch") && isCrouchNotification == false && playerManagerScript.isPlayerCanInput == true)
        {
			isCrouchNotification = true;
			mainNotificationTextMesh.text = "";
		}

        if (isDoorNotification == false && firstDoorSoundScript.isOpen == true) {

            isDoorNotification = true;

        }

	}

	void NotificationTime(){

		if (secretItemsTime < 3) {
			
			secretItemsTime += 1 * Time.deltaTime;
			//CanvasKomunikaty.enabled = true;

			if (notificationType == NotificationType.SecretItem) {
				secretItemsNotificationTextMesh.text = secretItemNotification;

			} else if (notificationType == NotificationType.GreenHerb) {
				secretItemsNotificationTextMesh.text = greenHerbNotification;

			} else if (notificationType == NotificationType.BlueHerb) {
				secretItemsNotificationTextMesh.text = blueHerbNotification;

			} else if (notificationType == NotificationType.Vial) {
				secretItemsNotificationTextMesh.text = vialNotification;

			} else if (notificationType == NotificationType.Badge) {
				secretItemsNotificationTextMesh.text = badgeNotification;

			} else if (notificationType == NotificationType.Photo) {
				secretItemsNotificationTextMesh.text = photoNotification;

			} else if (notificationType == NotificationType.Tip) {
				secretItemsNotificationTextMesh.text = tipNotification;
			}
            else if (notificationType == NotificationType.StaminaPot)
            {
                secretItemsNotificationTextMesh.text = staminaPotNotification;
            }
            else if (notificationType == NotificationType.HealthPot)
            {
                secretItemsNotificationTextMesh.text = healthPotNotification;
            }


        } else {
			isSecretItemNotification = false;
			isGreenHerbNotification = false;
			isBlueHerbNotification = false;
			secretItemsNotificationTextMesh.text = "";
		}

		if (secretPlacesTime < 3) {
			secretPlacesTime += 1 * Time.deltaTime;
		} else {
			secretPlacesNotificationTextMesh.text = "";
		}

        if (taskHintTime < 5)
        {
            taskHintTime += 1 * Time.deltaTime;
        }
        else
        {
            taskHintTextMesh.text = "";
            taskHintBackground.enabled = false;
        }
    }

    public void KomunikatZadanieWskazowka()
    {
        taskHintTime = 0;
        taskHintBackground.enabled = true;
        taskHintTextMesh.text = tasksHint;
    }

	void KomunikatDrzwi(){
	
		infoNotificationTextMesh.text = lockedDoorMessage;
		audioSource.PlayOneShot (doorLockedSound);
	}
		

	void KomunikatSzafa(){
		
		infoNotificationTextMesh.text = lockedWardrobeMessage;
		audioSource.PlayOneShot (doorLockedSound);
	}

    void KomunikatCiernie()
    {
		
        infoNotificationTextMesh.text = thornsMessage;
    }


    void KomunikatDrzwiOgrod(){
		
		infoNotificationTextMesh.text = gardenDoorMessage;
	}

	void KomunikatDrzwiFabrykaMetal(){
		
		infoNotificationTextMesh.text = lockedFactoryDoorMessage;
	}

	void KomunikatDrzwikukurydza(){
		
		infoNotificationTextMesh.text = cornfieldDoorMessage;
	}


	void KomunikatDeskiSzopa(){
		
		infoNotificationTextMesh.text = planksMessage;
		audioSource.PlayOneShot (planksSound);
	}
		

	void KomunikatKaseta(){
		
		infoNotificationTextMesh.text = insertCasseteMessage;
	}

	void KomunikatEnergia(){
		
		infoNotificationTextMesh.text = factoryLeverMessage;
	}

	void KomunikatKratySteven(){
		
		infoNotificationTextMesh.text = stevenGrilleMessage;
	}

    public void ShowMainNotification(string notificationText)
    {
        mainNotificationTextMesh.text = notificationText;
    }

    public void ShowSecretPlaceNotification(string notificationText, Text pointer)
    {
        secretPlacesTime = 0f;
        secretPlacesNotificationTextMesh.text = notificationText;
        pointer.enabled = true;
        inventoryScript.itemAudioSource4.clip = inventoryScript.secretPlaceSound;
        inventoryScript.itemAudioSource4.Play();
        inventoryScript.secretPlacesCount++;
    }

    public void ShowTutorialNotification(Canvas tutorialCanvas)
    {
        notificationType = NotificationType.Tutorial;
        tutorialCanvas.enabled = true;
        tutorialAudioSource.PlayOneShot(tutorialSound);
        Time.timeScale = 0;
        gameMenuScript.playerScript.enabled = false;
        gameMenuScript.cursorScript.m_ShowCursor = true;
        Cursor.visible = true;
        gameMenuScript.headbobberScript.enabled = false;
        gameMenuScript.playerScript.currentVelocity = gameMenuScript.playerScript.walkVelocity;
        playerScript.isSprint = false;
    }

    public void HideTutorialNotification(Canvas tutorialCanvas)
    {
        notificationType = NotificationType.None;
        tutorialCanvas.enabled = false;
        tutorialAudioSource.PlayOneShot(tutorialSound);
        Time.timeScale = 1;
        gameMenuScript.playerScript.enabled = true;
        gameMenuScript.cursorScript.m_ShowCursor = false;
        Cursor.visible = false;
        gameMenuScript.headbobberScript.enabled = true;
        gameMenuScript.playerScript.currentVelocity = gameMenuScript.playerScript.walkVelocity;
        playerScript.isSprint = false;
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("PtakSzalas_trigger") && isDragNotification == false)
        {
            mainNotificationTextMesh.text = "";

            if (player.gameObject.GetComponent<DragObject>().objectToDrag != null)
            {
                isDragNotification = true;
            }
        }
    }
}

