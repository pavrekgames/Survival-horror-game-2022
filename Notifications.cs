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
	public TextMeshProUGUI collectibleNotificationTextMesh;
	public TextMeshProUGUI secretPlacesNotificationTextMesh;
    public Canvas herbsNotificationCanvas;
    public Canvas saveGameNotificationCanvas;
    public Canvas pushNotificationCanvas;
    public Canvas secretNotificationCanvas;
    public Canvas itemsNotificationCanvas;
    public Canvas inventoryNotificationCanvas;
    public float collectibleTime = 3f;
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

    public string uncleDoorName = "Uncle's room";
    public string stableDoorName = "Stable";
    public string gardenDoorName = "A metal door to the garden";
    public string cornfieldDoorName = "Door to the corn field";
    public string corridorWardrobeName = "Wardrobe in corridor";
    public string kitchenWardrobeName = "Wardrobe in the kitchen";
    public string toolShedDoorName = "Shed";
    public string secretRoomDoorName = "Secret room";
    public string nicheDoorName = "Wooden door";
    public string aliceRoomDoorName = "Alice's living room";
    public string factoryWoodenDoorName = "Victor's workshop";
    public string shedCupboardName = "Edward's cupboard";
    public string tomRoomDoorName = "Tom's room";
    public string tomUpstairsDoorName = "Tom's office";
    public string oldWardrobeName = "Old wardrobe";
    public string stevenDoorName = "Steven's room";
    public string paulDoorName = "Scientist's room";
    public string paulJumpscareDoorName = "Scientist's office";

    // komunikat dodania nowego zadania

    public TextMeshProUGUI taskHintTextMesh;
    public Image taskHintBackground;
    public float taskHintTime = 5f;

    public enum CollectibleNotificationType
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

    public CollectibleNotificationType collectibleNotificationType;

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
		collectibleNotificationTextMesh = GameObject.Find ("SecretItemKomunikat").GetComponent<TextMeshProUGUI> ();
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

		HideMainNotification ();

		if (Input.GetMouseButtonDown (0) && playerManagerScript.isPlayerCanInput == true) {

			Ray playerAim = playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hit; 

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {

				if (hit.collider.gameObject.tag == "Door" || hit.collider.gameObject.tag == "Hand") {

                    if (hit.transform.gameObject.GetComponent<RaycastNotification>())
                    {
                        hit.transform.gameObject.GetComponent<RaycastNotification>().SendNotification();
                    }
				}
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

} 

	void HideMainNotification(){

		if(isLightNotification == false){
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

    IEnumerator NotificationTimeIE()
    {
        yield return new WaitForSeconds(3);
        infoNotificationTextMesh.text = "";
        doorNotificationTextMesh.text = "";
        isNotificationTimeOn = false;
        StopCoroutine("NotificationTimeIE");
    }

   public IEnumerator CollectibleNotificationIE()
    {
        if (collectibleNotificationType == CollectibleNotificationType.SecretItem)
        {
            collectibleNotificationTextMesh.text = secretItemNotification;
        }
        else if (collectibleNotificationType == CollectibleNotificationType.GreenHerb)
        {
            collectibleNotificationTextMesh.text = greenHerbNotification;
        }
        else if (collectibleNotificationType == CollectibleNotificationType.BlueHerb)
        {
            collectibleNotificationTextMesh.text = blueHerbNotification;
        }
        else if (collectibleNotificationType == CollectibleNotificationType.Vial)
        {
            collectibleNotificationTextMesh.text = vialNotification;
        }
        else if (collectibleNotificationType == CollectibleNotificationType.Badge)
        {
            collectibleNotificationTextMesh.text = badgeNotification;
        }
        else if (collectibleNotificationType == CollectibleNotificationType.Photo)
        {
            collectibleNotificationTextMesh.text = photoNotification;
        }
        else if (collectibleNotificationType == CollectibleNotificationType.Tip)
        {
            collectibleNotificationTextMesh.text = tipNotification;
        }
        else if (collectibleNotificationType == CollectibleNotificationType.StaminaPot)
        {
            collectibleNotificationTextMesh.text = staminaPotNotification;
        }
        else if (collectibleNotificationType == CollectibleNotificationType.HealthPot)
        {
            collectibleNotificationTextMesh.text = healthPotNotification;
        }

        yield return new WaitForSeconds(3);
        collectibleNotificationType = CollectibleNotificationType.None;
        collectibleNotificationTextMesh.text = "";
        StopCoroutine("CollectibleNotificationIE");
    }

    IEnumerator SecretPlaceNotificationIE()
    {
        yield return new WaitForSeconds(3);
        secretPlacesNotificationTextMesh.text = "";
        StopCoroutine("SecretPlaceNotificationIE");
    }

    IEnumerator TaskHintTimeIE()
    {
        yield return new WaitForSeconds(5);
        taskHintTextMesh.text = "";
        taskHintBackground.enabled = false;
        StopCoroutine("TaskHintTimeIE");
    }

    public void TaskHintNotification()
    {
        taskHintTime = 0;
        taskHintBackground.enabled = true;
        taskHintTextMesh.text = tasksHint;
        StartCoroutine("TaskHintTimeIE");
    }

    public void ShowInfoNotification(string notificationText)
    {
        infoNotificationTextMesh.text = notificationText;
        notificationTime = 0;
        isNotificationTimeOn = true;
        StartCoroutine("NotificationTimeIE");
    }

    public void ShowInfoNotification(string notificationText, AudioClip notificationSound)
    {
        infoNotificationTextMesh.text = notificationText;
        audioSource.PlayOneShot(notificationSound);
        notificationTime = 0;
        isNotificationTimeOn = true;
        StartCoroutine("NotificationTimeIE");
    }

    public void ShowDoorNameNotification(string notificationText, string doorName, AudioClip notificationSound)
    {
        infoNotificationTextMesh.text = notificationText;
        audioSource.PlayOneShot(notificationSound);
        notificationTime = 0;
        isNotificationTimeOn = true;
        doorNotificationTextMesh.text = doorName;
        StartCoroutine("NotificationTimeIE");
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
        StartCoroutine("SecretPlaceNotificationIE");
    }

    public void ShowTutorialNotification(Canvas tutorialCanvas)
    {
        collectibleNotificationType = CollectibleNotificationType.Tutorial;
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
        collectibleNotificationType = CollectibleNotificationType.None;
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

