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

    // collection badges UI

    public Canvas badgeCollectionCanvas;
    public Canvas[] collectionCanvas;
    public bool isCollectionActive = false;

    public Sprite badgeSprite;
    public Sprite badgeOKSprite;

    // collection photos UI

    public Canvas photoCollectionCanvas;
    public Sprite photoOKSprite;

    // collection tips


    // collection tips UI

    public Canvas tipCollectionCanvas;
    public Sprite tipSprite;
    public Sprite tipOKSprite;

    private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;

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

        // aktualny przedmiot

        uiCanvas = GameObject.Find("CanvasUI").GetComponent<Canvas>();
        currenntItemTitle = GameObject.Find("AktualnyItemTytul").GetComponent<TextMeshProUGUI>();
        currentItemIcon = GameObject.Find("AktualnyItem").GetComponent<Image>();

    }

    void Update()
    {

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

        else if (gameMenuScript.isMenu == true)
        {
            cursorScript.m_ShowCursor = true; 
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


