using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Inventory : MonoBehaviour {

    // inventory
    private PlayerManager playerManagerScript;
    public List<Item> items = new List<Item>();
    private Animator animator;
    private CrosshairGUI cursorScript;
    private Player playerScript;
    private Canvas uiCanvas;
    public TextMeshProUGUI currenntItemTitle;
    public Image currentItemIcon;
    public bool isInventoryActive = false;
    private Menu gameMenuScript;
    public Notifications notificationScript;
    public AudioSource itemAudioSource1;
    public AudioSource itemAudioSource2;
    public AudioSource itemAudioSource3;
    public AudioSource itemAudioSource4;
    public AudioSource pauseAudioSource;
    public Health healthScript;
    public Notes notesScript;
    public AudioClip menuButtonSound;
    public Canvas inventoryCanvas;

    public InventoryUI inventoryUI;
    public TasksUI tasksUI;
    public NotesUI notesUI;
    public TreatmentUI treatmentUI;
    public CollectionBadgesUI collectionBadgesUI;

    public int secretItemsCount = 0;
    public int secretPlacesCount = 0;
    public int blueHerbsCount = 0;
    public int greenHerbsCount = 0;
    public int healthPotsCount = 0;
    public int staminaPotsCount = 0;
    public int vialsCount = 0;

    public AudioClip secretItemSound;
    public AudioClip secretItemSound2;
    public AudioClip secretPlaceSound;
    public AudioClip collectHerbSound;
    public AudioClip collectVialSound;
    public AudioClip collectItemSound;
    public AudioClip openInventorySound;


    // tasks UI

    public Canvas tasksCanvas;
    public bool isTasksActive = false;
    // notes UI

    public Canvas notesCanvas;
    public Canvas noteDefaultCanvas;
    public bool isNotesActive = false;

    public Canvas treatmentCanvas;
    public bool isTreatmentActive = false;

    // collection badges


    // collection badges UI

    public Canvas badgeCollectionCanvas;
    public Canvas[] collectionCanvas;
    private TextMeshProUGUI badgeCollectionTitleText;
    public bool isCollectionActive = false;

    public Sprite badgeSprite;
    public Sprite badgeOKSprite;
    public Image[] collectionTextures;

    // collection photos


    // collection photos UI

    public Canvas photoCollectionCanvas;
    private TextMeshProUGUI photoCollectionTitleText;
    public Sprite photoSprite;
    public Sprite photoOKSprite;

    // collection tips


    // collection tips UI

    public Canvas tipCollectionCanvas;
    private TextMeshProUGUI tipCollectionTitleText;
    public Sprite tipSprite;
    public Sprite tipOKSprite;

    // Notification

    public bool isRockyGraveSP = false;
	public Text rockyGraveTextPointer;
	public bool isAnimalCementarySP = false;
	public Text animalCementaryTextPointer;
	public bool isSimonGardenSP = false;
	public Text simonGardenTextPointer;
	public bool isTomCampSP = false;
	public Text tomCampTextPointer;
	public bool isDevilsShelterSP = false;
	public bool isWarCementarySP = false;
	public Text warCementaryTextPointer;
	public bool isHutSP = false;
	public Text hutTextPointer;
	public bool isBasementSP = false;
	public Text basementTextPointer;
	public bool isMushroomFieldSP = false;
	public Text mushroomFieldTextPointer;
	public bool isDarkForestSP = false;
	public Text darkForestTextPointer;
	public bool isBonesTowerSP = false;
	public Text bonesTowerTextPointer;
	public bool isKnifeArenaSP = false;
	public Text knifeArenaTextPointer;
	public bool isCaveSP = false;
	public Text caveTextPointer;
	public bool isMonumentSP = false;
	public Text monumentTextPointer;
	public bool isSpaceshipSP = false;
	public Text spaceshipTextPointer;

    //------------------------------------------------------------------------

    private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;

    // teksty do kolekcji

    public string[] collectionTitles;

    // tekst aktualny item

    public string currentItemText = "Item";

    // Do osiagniec Steam

    public int badgesCount = 0;
    public int tipsCount = 0;
    public int photosCount = 0;
    public int skillsCount = 0;

	void OnEnable(){

        playerCam = Camera.main;

        playerManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
    
		cursorScript = GameObject.Find ("Kamera").GetComponent<CrosshairGUI>();
		playerScript = GameObject.Find ("Player").GetComponent<Player>();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu>();
		animator = GameObject.Find ("Player").GetComponent<Animator>();
		
		healthScript = GameObject.Find ("Player").GetComponent<Health>();
		notesScript = GameObject.Find ("Player").GetComponent<Notes>();
		
	
		notificationScript = GameObject.Find ("Player").GetComponent<Notifications>();

		
		tasksCanvas = GameObject.Find ("CanvasTasks").GetComponent<Canvas>();
		notesCanvas = GameObject.Find ("CanvasNotatki").GetComponent<Canvas>();
		treatmentCanvas = GameObject.Find ("CanvasTreatment").GetComponent<Canvas>();
		noteDefaultCanvas = GameObject.Find ("CanvasNotatkaDefault").GetComponent<Canvas>();
        badgeCollectionCanvas = GameObject.Find("CanvasCollectionOdznaki").GetComponent<Canvas>();
        photoCollectionCanvas = GameObject.Find("CanvasCollectionFoto").GetComponent<Canvas>();
        tipCollectionCanvas = GameObject.Find("CanvasCollectionWskazowki").GetComponent<Canvas>();
        

		itemAudioSource1 = GameObject.Find ("ZrodloPrzedmiot_s").GetComponent<AudioSource>();      // klucze
		itemAudioSource2 = GameObject.Find ("ZrodloPrzedmiot2_s").GetComponent<AudioSource>();    // glosne
		itemAudioSource3 = GameObject.Find ("ZrodloPrzedmiot3_s").GetComponent<AudioSource>();    // srednie
		itemAudioSource4 = GameObject.Find ("ZrodloPrzedmiot4_s").GetComponent<AudioSource>();    // ciche
        pauseAudioSource = GameObject.Find("ZrodloPrzedmiotPause_s").GetComponent<AudioSource>();


        rockyGraveTextPointer = GameObject.Find ("SPGrobRockyPointer").GetComponent<Text>();
		animalCementaryTextPointer = GameObject.Find ("SPCmentarzZwierzatPointer").GetComponent<Text>();
		simonGardenTextPointer = GameObject.Find ("SPOgrodSimonaPointer").GetComponent<Text>();
		tomCampTextPointer = GameObject.Find ("SPObozTomaPointer").GetComponent<Text>();
		warCementaryTextPointer = GameObject.Find ("SPCmentarzWojnaPointer").GetComponent<Text>();
		hutTextPointer = GameObject.Find ("SPDomekPointer").GetComponent<Text>();
		basementTextPointer = GameObject.Find ("SPPiwnicaPointer").GetComponent<Text>();
		mushroomFieldTextPointer = GameObject.Find ("SPPoleGrzybowePointer").GetComponent<Text>();
		darkForestTextPointer = GameObject.Find ("SPCiemnyLasPointer").GetComponent<Text>();
		bonesTowerTextPointer = GameObject.Find ("SPWiezaKosciPointer").GetComponent<Text>();
		knifeArenaTextPointer = GameObject.Find ("SPNozowaArenaPointer").GetComponent<Text>();
		caveTextPointer = GameObject.Find ("SPJaskiniaPointer").GetComponent<Text>();
		monumentTextPointer = GameObject.Find ("SPPomnikPointer").GetComponent<Text>();
		spaceshipTextPointer = GameObject.Find ("SPStatekKosmicznyPointer").GetComponent<Text>();

        // kolekcja tekstury

        collectionTextures = new Image[36];
        collectionTextures[0] = GameObject.Find("Odznaka1Image").GetComponent<Image>();
        collectionTextures[1] = GameObject.Find("Odznaka2Image").GetComponent<Image>();
        collectionTextures[2] = GameObject.Find("Odznaka3Image").GetComponent<Image>();
        collectionTextures[3] = GameObject.Find("Odznaka4Image").GetComponent<Image>();
        collectionTextures[4] = GameObject.Find("Odznaka5Image").GetComponent<Image>();
        collectionTextures[5] = GameObject.Find("Odznaka6Image").GetComponent<Image>();
        collectionTextures[6] = GameObject.Find("Odznaka7Image").GetComponent<Image>();
        collectionTextures[7] = GameObject.Find("Odznaka8Image").GetComponent<Image>();
        collectionTextures[8] = GameObject.Find("Odznaka9Image").GetComponent<Image>();
        collectionTextures[9] = GameObject.Find("Odznaka10Image").GetComponent<Image>();
        collectionTextures[10] = GameObject.Find("Odznaka11Image").GetComponent<Image>();
        collectionTextures[11] = GameObject.Find("Odznaka12Image").GetComponent<Image>();
        collectionTextures[12] = GameObject.Find("Foto1Image").GetComponent<Image>();
        collectionTextures[13] = GameObject.Find("Foto2Image").GetComponent<Image>();
        collectionTextures[14] = GameObject.Find("Foto3Image").GetComponent<Image>();
        collectionTextures[15] = GameObject.Find("Foto4Image").GetComponent<Image>();
        collectionTextures[16] = GameObject.Find("Foto5Image").GetComponent<Image>();
        collectionTextures[17] = GameObject.Find("Foto6Image").GetComponent<Image>();
        collectionTextures[18] = GameObject.Find("Foto7Image").GetComponent<Image>();
        collectionTextures[19] = GameObject.Find("Foto8Image").GetComponent<Image>();
        collectionTextures[20] = GameObject.Find("Foto9Image").GetComponent<Image>();
        collectionTextures[21] = GameObject.Find("Foto10Image").GetComponent<Image>();
        collectionTextures[22] = GameObject.Find("Foto11Image").GetComponent<Image>();
        collectionTextures[23] = GameObject.Find("Foto12Image").GetComponent<Image>();
        collectionTextures[24] = GameObject.Find("Wskazowki1Image").GetComponent<Image>();
        collectionTextures[25] = GameObject.Find("Wskazowki2Image").GetComponent<Image>();
        collectionTextures[26] = GameObject.Find("Wskazowki3Image").GetComponent<Image>();
        collectionTextures[27] = GameObject.Find("Wskazowki4Image").GetComponent<Image>();
        collectionTextures[28] = GameObject.Find("Wskazowki5Image").GetComponent<Image>();
        collectionTextures[29] = GameObject.Find("Wskazowki6Image").GetComponent<Image>();
        collectionTextures[30] = GameObject.Find("Wskazowki7Image").GetComponent<Image>();
        collectionTextures[31] = GameObject.Find("Wskazowki8Image").GetComponent<Image>();
        collectionTextures[32] = GameObject.Find("Wskazowki9Image").GetComponent<Image>();
        collectionTextures[33] = GameObject.Find("Wskazowki10Image").GetComponent<Image>();
        collectionTextures[34] = GameObject.Find("Wskazowki11Image").GetComponent<Image>();
        collectionTextures[35] = GameObject.Find("Wskazowki12Image").GetComponent<Image>();

    
        // Canvasy kolekcje z tablicy

        collectionCanvas = new Canvas[37];
        collectionCanvas[0] = GameObject.Find("CanvasCollectionDefault").GetComponent<Canvas>();
        collectionCanvas[1] = GameObject.Find("CanvasCollectionOdznaka1").GetComponent<Canvas>();
        collectionCanvas[2] = GameObject.Find("CanvasCollectionOdznaka2").GetComponent<Canvas>();
        collectionCanvas[3] = GameObject.Find("CanvasCollectionOdznaka3").GetComponent<Canvas>();
        collectionCanvas[4] = GameObject.Find("CanvasCollectionOdznaka4").GetComponent<Canvas>();
        collectionCanvas[5] = GameObject.Find("CanvasCollectionOdznaka5").GetComponent<Canvas>();
        collectionCanvas[6] = GameObject.Find("CanvasCollectionOdznaka6").GetComponent<Canvas>();
        collectionCanvas[7] = GameObject.Find("CanvasCollectionOdznaka7").GetComponent<Canvas>();
        collectionCanvas[8] = GameObject.Find("CanvasCollectionOdznaka8").GetComponent<Canvas>();
        collectionCanvas[9] = GameObject.Find("CanvasCollectionOdznaka9").GetComponent<Canvas>();
        collectionCanvas[10] = GameObject.Find("CanvasCollectionOdznaka10").GetComponent<Canvas>();
        collectionCanvas[11] = GameObject.Find("CanvasCollectionOdznaka11").GetComponent<Canvas>();
        collectionCanvas[12] = GameObject.Find("CanvasCollectionOdznaka12").GetComponent<Canvas>();
        collectionCanvas[13] = GameObject.Find("CanvasCollectionFoto1").GetComponent<Canvas>();
        collectionCanvas[14] = GameObject.Find("CanvasCollectionFoto2").GetComponent<Canvas>();
        collectionCanvas[15] = GameObject.Find("CanvasCollectionFoto3").GetComponent<Canvas>();
        collectionCanvas[16] = GameObject.Find("CanvasCollectionFoto4").GetComponent<Canvas>();
        collectionCanvas[17] = GameObject.Find("CanvasCollectionFoto5").GetComponent<Canvas>();
        collectionCanvas[18] = GameObject.Find("CanvasCollectionFoto6").GetComponent<Canvas>();
        collectionCanvas[19] = GameObject.Find("CanvasCollectionFoto7").GetComponent<Canvas>();
        collectionCanvas[20] = GameObject.Find("CanvasCollectionFoto8").GetComponent<Canvas>();
        collectionCanvas[21] = GameObject.Find("CanvasCollectionFoto9").GetComponent<Canvas>();
        collectionCanvas[22] = GameObject.Find("CanvasCollectionFoto10").GetComponent<Canvas>();
        collectionCanvas[23] = GameObject.Find("CanvasCollectionFoto11").GetComponent<Canvas>();
        collectionCanvas[24] = GameObject.Find("CanvasCollectionFoto12").GetComponent<Canvas>();
        collectionCanvas[25] = GameObject.Find("CanvasCollectionWskazowka1").GetComponent<Canvas>();
        collectionCanvas[26] = GameObject.Find("CanvasCollectionWskazowka2").GetComponent<Canvas>();
        collectionCanvas[27] = GameObject.Find("CanvasCollectionWskazowka3").GetComponent<Canvas>();
        collectionCanvas[28] = GameObject.Find("CanvasCollectionWskazowka4").GetComponent<Canvas>();
        collectionCanvas[29] = GameObject.Find("CanvasCollectionWskazowka5").GetComponent<Canvas>();
        collectionCanvas[30] = GameObject.Find("CanvasCollectionWskazowka6").GetComponent<Canvas>();
        collectionCanvas[31] = GameObject.Find("CanvasCollectionWskazowka7").GetComponent<Canvas>();
        collectionCanvas[32] = GameObject.Find("CanvasCollectionWskazowka8").GetComponent<Canvas>();
        collectionCanvas[33] = GameObject.Find("CanvasCollectionWskazowka9").GetComponent<Canvas>();
        collectionCanvas[34] = GameObject.Find("CanvasCollectionWskazowka10").GetComponent<Canvas>();
        collectionCanvas[35] = GameObject.Find("CanvasCollectionWskazowka11").GetComponent<Canvas>();
        collectionCanvas[36] = GameObject.Find("CanvasCollectionWskazowka12").GetComponent<Canvas>();

        badgeCollectionTitleText = GameObject.Find("TytulCollectionOdznaki").GetComponent<TextMeshProUGUI>();
        photoCollectionTitleText = GameObject.Find("TytulCollectionFoto").GetComponent<TextMeshProUGUI>();
        tipCollectionTitleText = GameObject.Find("TytulCollectionWskazowki").GetComponent<TextMeshProUGUI>();

        // tablica tekstow do kolekcji
        collectionTitles = new string[39];
        collectionTitles[0] = "Badges";
        collectionTitles[1] = "Photos";
        collectionTitles[2] = "Tips";
        collectionTitles[3] = "Fresh Blood Badge";
        collectionTitles[4] = "Sun Badge ";
        collectionTitles[5] = "Nature Badge";
        collectionTitles[6] = "A Badge Of Endurance";
        collectionTitles[7] = "Heaven Badge";
        collectionTitles[8] = "War Badge";
        collectionTitles[9] = "Infinity Badge";
        collectionTitles[10] = "A Badge Of Holiness";
        collectionTitles[11] = "Death Badge";
        collectionTitles[12] = "Badge Of Life ";
        collectionTitles[13] = "Combat Badge";
        collectionTitles[14] = "Fire Badge";
        collectionTitles[15] = "Old photo 1";
        collectionTitles[16] = "Old photo 2";
        collectionTitles[17] = "Old photo 3";
        collectionTitles[18] = "Old photo 4";
        collectionTitles[19] = "Old photo 5";
        collectionTitles[20] = "Old photo 6";
        collectionTitles[21] = "Old photo 7";
        collectionTitles[22] = "Old photo 8";
        collectionTitles[23] = "Old photo 9";
        collectionTitles[24] = "Old photo 10";
        collectionTitles[25] = "Old photo 11";
        collectionTitles[26] = "Old photo 12";
        collectionTitles[27] = "Tip 1";
        collectionTitles[28] = "Tip 2";
        collectionTitles[29] = "Tip 3";
        collectionTitles[30] = "Tip 4";
        collectionTitles[31] = "Tip 5";
        collectionTitles[32] = "Tip 6";
        collectionTitles[33] = "Tip 7";
        collectionTitles[34] = "Tip 8";
        collectionTitles[35] = "Tip 9";
        collectionTitles[36] = "Tip 10";
        collectionTitles[37] = "Tip 11";
        collectionTitles[38] = "Tip 12";



        // aktualny przedmiot

        uiCanvas = GameObject.Find("CanvasUI").GetComponent<Canvas>();
        currenntItemTitle = GameObject.Find("AktualnyItemTytul").GetComponent<TextMeshProUGUI>();
        currentItemIcon = GameObject.Find("AktualnyItem").GetComponent<Image>();

    }

    void Update()
    {

        if (Time.timeScale == 0)
        {
            uiCanvas.enabled = false;
        }
        else if (Time.timeScale == 1)
        {
            uiCanvas.enabled = true;
        }

        CheckHealthCondition();

        if (Input.GetButtonDown("Inventory") && playerManagerScript.isPlayerCanInput == true)
        {

            ShowInventory();

            Time.timeScale = 0;
            cursorScript.m_ShowCursor = true;
            playerScript.audioSource.Pause();
            playerScript.enabled = false;
            pauseAudioSource.pitch = 1;
            pauseAudioSource.PlayOneShot(openInventorySound);

        }


        else if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isInventoryActive == true)
        {
            inventoryUI.InventoryBackFunction();
        }

        else if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isTasksActive == true)
        {
            tasksUI.TasksBackFunction();
        }

        else if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isNotesActive == true)
        {
            notesUI.NotesBackFunction();
        }

        else if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isTreatmentActive == true)
        {
            treatmentUI.TreatmentBackFunction();
        }

        else if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isCollectionActive == true)
        {
            collectionBadgesUI.CollectionBackFunction();
        }

        else if (gameMenuScript.isMenu == true)
        {
            cursorScript.m_ShowCursor = true; // !Kursor.m_ShowCursor
        }


        //------------------PODNOSZENIE PRZEDMIOTOW----------------------

        if (Input.GetMouseButtonDown(0) && playerManagerScript.isPlayerCanInput == true)
        {
            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9))
            {

                if (hit.collider.gameObject.tag == "TaskItem")
                {
                    hit.transform.gameObject.GetComponent<TaskItem>().PickUpItem();
                }

                else if (hit.collider.gameObject.tag == "CollectibleItem")
                {
                    hit.transform.gameObject.GetComponent<CollectibleItem>().PickUpItem();
                }

            }

        }

    }

    // Wlaczanie panelu

    public void ShowInventory()
    {

        if (Time.timeScale == 0)
        {
            itemAudioSource3.PlayOneShot(menuButtonSound);
        }


        inventoryCanvas.enabled = true;
        isInventoryActive = true;
        tasksCanvas.enabled = false;
        isTasksActive = false;
        notesCanvas.enabled = false;
        isNotesActive = false;
        treatmentCanvas.enabled = false;
        isTreatmentActive = false;
        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;
        isCollectionActive = false;

        noteDefaultCanvas.enabled = false;

        for (int i = 0; i < notesScript.notesCanvas2.Length; i++)
        {
            notesScript.notesCanvas2[i].enabled = false;
        }

        for (int i = 0; i < collectionCanvas.Length; i++)
        {
            collectionCanvas[i].enabled = false;
        }

        notificationScript.taskHintTime = 5f;

    }

   public void AddItem(Item item, AudioClip pickUpSound)
    {
        animator.SetTrigger("PickUp");
        itemAudioSource1.PlayOneShot(pickUpSound);

        items.Add(item);
        item.isTaken = true;
        item.id += 1;
    }

    void TymczasoweDane()
    {
        // AddKeyV1()

        if (notificationScript.isInventoryNotification == false)
        {
            notificationScript.ShowTutorialNotification(notificationScript.inventoryNotificationCanvas);
        }

        //AddKictenWardrobe()

        if (notificationScript.isInventoryNotification == false)
        {
            notificationScript.ShowTutorialNotification(notificationScript.inventoryNotificationCanvas);
        }

        //tasksScript.RemoveKluczWychodekPointer();

        // AddShedKey()
        //tasksScript.AddSzopaNarzedziaPointer();

        //AddBone3()
        if (notificationScript.isInventoryNotification == false)
        {
            notificationScript.ShowTutorialNotification(notificationScript.inventoryNotificationCanvas);
        }

        //tasksScript.RemoveKoscSzopaPointer();

        //AddBone4()
        if (notificationScript.isInventoryNotification == false)
        {
            notificationScript.ShowTutorialNotification(notificationScript.inventoryNotificationCanvas);
        }

        //tasksScript.RemoveKoscStajniaPointer();

        //AddSecretRoom()
        //tasksScript.AddSekretnyPokojPointer();

        //AddPliers()
       // voiceActingScript.GlosKombinerki();

        //AddAxe()
        //voiceActingScript.GlosSiekiera();

        //AddCassete2()
        //tasksScript.RemoveSzafkaEdwardPointer();

        //AddStrongAcid()
        //voiceActingScript.GlosEliksir();
    }

   public void AddSecretItem(AudioClip secretItemSound)
    {
        itemAudioSource1.PlayOneShot(secretItemSound);
        secretItemsCount++;
        notificationScript.collectibleTime = 0;
        notificationScript.collectibleNotificationType = Notifications.CollectibleNotificationType.SecretItem;
        notificationScript.StartCoroutine(notificationScript.CollectibleNotificationIE());
        animator.SetTrigger("PickUp");
    }

	public void AddGreenHerb(AudioClip greenHerbSound){
		itemAudioSource2.PlayOneShot (collectHerbSound);
		greenHerbsCount++;
		notificationScript.collectibleTime = 0;
        notificationScript.collectibleNotificationType = Notifications.CollectibleNotificationType.GreenHerb;
        notificationScript.StartCoroutine(notificationScript.CollectibleNotificationIE());
        animator.SetTrigger ("PickUp");
		//greenHerbsText.text = greenHerbsCount + "";
	}

	public void AddBlueHerb(AudioClip blueHerbSound)
    {
		itemAudioSource2.PlayOneShot (collectHerbSound);
		blueHerbsCount++;
		notificationScript.collectibleTime = 0;
        notificationScript.collectibleNotificationType = Notifications.CollectibleNotificationType.BlueHerb;
        notificationScript.StartCoroutine(notificationScript.CollectibleNotificationIE());
        animator.SetTrigger ("PickUp");
		//blueHerbsText.text = blueHerbsCount + "";
	}

    public void AddVial(AudioClip vialSound) {

        itemAudioSource2.PlayOneShot(collectVialSound);
        vialsCount++;
        notificationScript.collectibleTime = 0;
        notificationScript.collectibleNotificationType = Notifications.CollectibleNotificationType.Vial;
        notificationScript.StartCoroutine(notificationScript.CollectibleNotificationIE());
        animator.SetTrigger("PickUp");
        //vialsCountText.text = vialsCount + "";
    }

    public void AddStaminaPot(AudioClip staminaPotSound)
    {

        itemAudioSource2.PlayOneShot(collectVialSound);
        staminaPotsCount++;
        notificationScript.collectibleNotificationType = Notifications.CollectibleNotificationType.StaminaPot;
        notificationScript.StartCoroutine(notificationScript.CollectibleNotificationIE());
        animator.SetTrigger("PickUp");
        //staminaPotsText.text = staminaPotsCount + "";
    }

    public void AddHealthPot(AudioClip HealthPotSound)
    {

        itemAudioSource2.PlayOneShot(collectVialSound);
        healthPotsCount++;
        notificationScript.collectibleTime = 0;
        notificationScript.collectibleNotificationType = Notifications.CollectibleNotificationType.HealthPot;
        notificationScript.StartCoroutine(notificationScript.CollectibleNotificationIE());
        animator.SetTrigger("PickUp");
        //healthPotsText.text = healthPotsCount + "";
    }

    public void AddBadge(AudioClip badgeSound, Image badgeTexture)
    {
        itemAudioSource3.pitch = Random.Range(0.8f, 1.5f);
        itemAudioSource3.PlayOneShot(collectItemSound);
        itemAudioSource3.pitch = 1;
        notificationScript.collectibleTime = 0;
        notificationScript.collectibleNotificationType = Notifications.CollectibleNotificationType.Badge;
        notificationScript.StartCoroutine(notificationScript.CollectibleNotificationIE());
        animator.SetTrigger("PickUp");
        badgeTexture.sprite = badgeOKSprite;
        badgesCount++;
    }

   public void AddPhoto(AudioClip photoSound, Image photoTexture)
    {
        itemAudioSource3.pitch = Random.Range(0.8f, 1.5f);
        itemAudioSource3.PlayOneShot(collectItemSound);
        itemAudioSource3.pitch = 1;
        notificationScript.collectibleTime = 0;
        notificationScript.collectibleNotificationType = Notifications.CollectibleNotificationType.Photo;
        notificationScript.StartCoroutine(notificationScript.CollectibleNotificationIE());
        animator.SetTrigger("PickUp");
        photoTexture.sprite = photoOKSprite;
        photosCount++;
    }

    public void AddTip(AudioClip TipSound, Image tipTexture)
    {
        itemAudioSource3.pitch = Random.Range(0.8f, 1.5f);
        itemAudioSource3.PlayOneShot(collectItemSound);
        itemAudioSource3.pitch = 1;
        notificationScript.collectibleTime = 0;
        notificationScript.collectibleNotificationType = Notifications.CollectibleNotificationType.Tip;
        notificationScript.StartCoroutine(notificationScript.CollectibleNotificationIE());
        animator.SetTrigger("PickUp");
        tipTexture.sprite = tipOKSprite;
        tipsCount++;
    }

    public void RemoveItem(Item item, bool isItemRemoved)
    {      
                items.Remove(item);

                //itemDescriptionText.text = defaultDescription;
                //usedItemText.text = defaultUsingItemText;
                isItemRemoved = true;

                currentItemIcon.sprite = null;
                currentItemIcon.color = Color.black;
                currenntItemTitle.text = currentItemText;
    }

    // do health script ?

    public void CheckHealthCondition()
    {

        if (healthScript.health >= 70 && playerScript.isRest == true)
        {
            //healthConditionText.text = stateGoodText;
        }
        else if (healthScript.health > 40 && healthScript.health < 70)
        {
            //healthConditionText.text = stateInjuredText;
        }
        else if (healthScript.health <= 40)
        {
            //healthConditionText.text = stateCriticalText;
        }
        else if (healthScript.health >= 70 && playerScript.isRest == false)
        {
            //healthConditionText.text = stateTiredText;
        }

    }

}


