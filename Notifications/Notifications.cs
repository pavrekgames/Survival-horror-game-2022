﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notifications : MonoBehaviour {

    public bool isPlaySound = false; // wznawianie i zatrzymywanie dzwiekow

    private Canvas notificationsCanvas;

    private Menu gameMenuScript;
	private Inventory inventoryScript;
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

	public bool isNotificationTimeOn = false;
	

    public bool isTutorialNotification = false;

    public AudioSource audioSource;
    public AudioSource tutorialAudioSource;
    public AudioSource audioSource4;
    
    public AudioClip tutorialSound;
    public AudioClip secretPlaceSound;

	public bool isLightNotification = false;
	public bool isLight2Notification = false;
	public bool isTaskInfoNotification = false;
	public bool isSprintNotification = false;
	public bool isMapNotification = false;
	public bool isCrouchNotification = false;
    public bool isDoorNotification = false;


    private Door firstDoorSoundScript;

    
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

    // komunikat dodania nowego zadania

    public TextMeshProUGUI taskHintTextMesh;
    public Image taskHintBackground;
    public float taskHintTime = 5f;

    public NotificationType notificationType;

    void OnEnable () {

        notificationsCanvas = GameObject.Find("CanvasKomunikaty").GetComponent<Canvas>();

		playerCam = Camera.main;
        playerScript = GameObject.Find("Player").GetComponent<Player>();

        firstDoorSoundScript = GameObject.Find("DrzwiDom").GetComponent<Door>();

        gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
		inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();

		//CanvasKomunikaty = GameObject.Find ("CanvasKomunikaty").GetComponent<Canvas> ();
		mainNotificationTextMesh = GameObject.Find ("GlownyKomunikat").GetComponent<TextMeshProUGUI> ();
		infoNotificationTextMesh = GameObject.Find ("InfoKomunikat").GetComponent<TextMeshProUGUI> ();
		taskNotificationTextMesh = GameObject.Find ("ZadanieKomunikat").GetComponent<TextMeshProUGUI> ();
        doorNotificationTextMesh = GameObject.Find("DrzwiInfoKomunikat").GetComponent<TextMeshProUGUI>();
        saveGameNotificationTextMesh = GameObject.Find ("ZapisKomunikat").GetComponent<TextMeshProUGUI> ();
		collectibleNotificationTextMesh = GameObject.Find ("SecretItemKomunikat").GetComponent<TextMeshProUGUI> ();
		secretPlacesNotificationTextMesh = GameObject.Find ("SecretPlaceKomunikat").GetComponent<TextMeshProUGUI> ();

		audioSource = GameObject.Find("ZrodloPrzedmiot3_s").GetComponent<AudioSource>();
		
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

    void Start()
    {
        inventoryScript.OnAddedCollectibleItem += CallCollectibleNotification;
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
            

            notificationsCanvas.enabled = false;

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow oraz wlaczanie canvasa komunikatow

        if (Time.timeScale == 1 && isPlaySound == true)
        {

            audioSource.UnPause();
           

            notificationsCanvas.enabled = true;

            isPlaySound = false;
        }

} 

	void HideMainNotification(){

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

    public void CallCollectibleNotification()
    {
        StartCoroutine(CollectibleNotificationIE());
    }

   public IEnumerator CollectibleNotificationIE()
    {
        if (notificationType == NotificationType.SecretItem)
        {
            collectibleNotificationTextMesh.text = secretItemNotification;
        }
        else if (notificationType == NotificationType.GreenHerb)
        {
            collectibleNotificationTextMesh.text = greenHerbNotification;
        }
        else if (notificationType == NotificationType.BlueHerb)
        {
            collectibleNotificationTextMesh.text = blueHerbNotification;
        }
        else if (notificationType == NotificationType.Vial)
        {
            collectibleNotificationTextMesh.text = vialNotification;
        }
        else if (notificationType == NotificationType.Badge)
        {
            collectibleNotificationTextMesh.text = badgeNotification;
        }
        else if (notificationType == NotificationType.Photo)
        {
            collectibleNotificationTextMesh.text = photoNotification;
        }
        else if (notificationType == NotificationType.Tip)
        {
            collectibleNotificationTextMesh.text = tipNotification;
        }
        else if (notificationType == NotificationType.StaminaPot)
        {
            collectibleNotificationTextMesh.text = staminaPotNotification;
        }
        else if (notificationType == NotificationType.HealthPot)
        {
            collectibleNotificationTextMesh.text = healthPotNotification;
        }

        yield return new WaitForSeconds(3);
        notificationType = NotificationType.None;
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
        isNotificationTimeOn = true;
        StartCoroutine("NotificationTimeIE");
    }

    public void ShowInfoNotification(string notificationText, AudioClip notificationSound)
    {
        infoNotificationTextMesh.text = notificationText;
        audioSource.PlayOneShot(notificationSound);
        isNotificationTimeOn = true;
        StartCoroutine("NotificationTimeIE");
    }

    public void ShowDoorNameNotification(string notificationText, string doorName, AudioClip notificationSound)
    {
        infoNotificationTextMesh.text = notificationText;
        audioSource.PlayOneShot(notificationSound);
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
        secretPlacesNotificationTextMesh.text = notificationText;
        pointer.enabled = true;
        audioSource.clip = secretPlaceSound;
        audioSource4.Play();
        inventoryScript.secretPlacesCount++;
        StartCoroutine("SecretPlaceNotificationIE");
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
}

