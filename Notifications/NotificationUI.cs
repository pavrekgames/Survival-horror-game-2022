using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotificationUI : MonoBehaviour {

    private Menu gameMenuScript;
    private Inventory inventoryScript;
    private Player playerScript;
    private PlayerManager playerManagerScript;
    private Door firstDoorSoundScript;

    [Header("Text Meshes")]
    [SerializeField] private TextMeshProUGUI mainNotificationTextMesh;
    [SerializeField] private TextMeshProUGUI infoNotificationTextMesh;
    [SerializeField] private TextMeshProUGUI taskNotificationTextMesh;
    [SerializeField] private TextMeshProUGUI doorNotificationTextMesh;
    [SerializeField] private TextMeshProUGUI saveGameNotificationTextMesh;
    [SerializeField] private TextMeshProUGUI collectibleNotificationTextMesh;
    [SerializeField] private TextMeshProUGUI secretPlacesNotificationTextMesh;

    [Header("Canvases")]
    public Canvas herbsNotificationCanvas;
    public Canvas saveGameNotificationCanvas;
    public Canvas pushNotificationCanvas;
    public Canvas secretNotificationCanvas;
    public Canvas itemsNotificationCanvas;
    public Canvas inventoryNotificationCanvas;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioSource tutorialAudioSource;
    [SerializeField] private AudioClip tutorialSound;
    [SerializeField] private AudioClip secretPlaceSound;

    [Header("Hints")]
    public string lightHint = "Press <color=#280DF6FF> Middle Mouse Button</color> to increase range of light";
    public string tasksHint = "Press <color=#280DF6FF>[ I ]</color> to see Inventory and Tasks";
    public string sprintHint = "Press <color=#280DF6FF>[Left Shift]</color> to sprint";
    public string mapHint = "Press <color=#280DF6FF>[M]</color> to see a Map";
    public string crouchHint = "Press <color=#280DF6FF>[C]</color> to Crouch";
    public string doorHint = "Hold down <color=#280DF6FF>[Left Mouse Button]</color> and move the mouse in order to move the door.";

    [Header("Collectible objects notifications")]
    public string secretItemNotification = "You picked up a Secret Item";
    public string greenHerbNotification = "You picked up a <color=#33D047FF>Green Herb</color>";
    public string blueHerbNotification = "You picked up a <color=#006EFFFF>Blue Herb</color>";
    public string vialNotification = "You picked up a <color=#F6FF04FF>Vial</color>";
    public string staminaPotNotification = "You picked up a <color=#FF00FFFF>Stamina Mixture</color>";
    public string healthPotNotification = "You picked up a <color=#F6FF04FF>Health Potion</color>";
    public string badgeNotification = "You picked up a <color=#F6FF04FF>Badge</color> to collection";
    public string photoNotification = "You picked up a <color=#F6FF04FF>Photo</color> to collection";
    public string tipNotification = "You picked up a <color=#F6FF04FF>Tip</color> to collection";

    public bool isLightNotification = false;
    public bool isLight2Notification = false;
    public bool isTaskInfoNotification = false;
    public bool isSprintNotification = false;
    public bool isMapNotification = false;
    public bool isCrouchNotification = false;
    public bool isDoorNotification = false;

    public bool isNotificationTimeOn = false;

    public TextMeshProUGUI taskHintTextMesh;
    public Image taskHintBackground;
    public float taskHintTime = 5f;

    public NotificationType notificationType;

    void Start()
    {
        inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
        gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        playerManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();

        inventoryScript.OnAddedCollectibleItem += CallCollectibleNotification;
    }

    void Update () {

        HideMainNotification();

    }

    void HideMainNotification()
    {

        if (Input.GetButtonDown("Flashlight") && isLightNotification == false && playerManagerScript.isPlayerCanInput == true)
        {
            isLightNotification = true;
            mainNotificationTextMesh.text = "";
        }

        if (Input.GetButtonDown("Sprint") && isSprintNotification == false && playerManagerScript.isPlayerCanInput == true)
        {
            isSprintNotification = true;
            mainNotificationTextMesh.text = "";
        }

        if (Input.GetMouseButton(2) && isLight2Notification == false && playerManagerScript.isPlayerCanInput == true)
        {
            isLight2Notification = true;
            mainNotificationTextMesh.text = "";
        }

        if (Input.GetButtonDown("Inventory") && isTaskInfoNotification == false && playerManagerScript.isPlayerCanInput == true)
        {
            isTaskInfoNotification = true;
            mainNotificationTextMesh.text = "";
        }

        if (Input.GetButtonDown("Map") && isMapNotification == false && playerManagerScript.isPlayerCanInput == true)
        {
            isMapNotification = true;
            mainNotificationTextMesh.text = "";
        }

        if (Input.GetButtonDown("Crouch") && isCrouchNotification == false && playerManagerScript.isPlayerCanInput == true)
        {
            isCrouchNotification = true;
            mainNotificationTextMesh.text = "";
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
        audioSource2.Play();
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
