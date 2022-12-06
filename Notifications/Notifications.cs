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

	void Update () {

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

	
}

