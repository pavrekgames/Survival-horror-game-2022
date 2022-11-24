using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour {

    // inventory UI
    
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI usedItemText;
    public Text secretItemsText;
    public Text secretPlacesText;
    public AudioClip menuButtonSound;
    public AudioClip useItemSound;
    public AudioClip itemDesciptionSound;
    private Player playerScript;
    private CrosshairGUI cursorScript;
    private AudioSource itemAudioSource3;
    private Canvas inventoryCanvas;
    public string usingItemText = " is using now!";

    public Image[] itemIcons;
    private PlayerManager playerManagerScript;
    public List<Item> items = new List<Item>();
    private Animator animator;
    private Transform player;
    private Map mapScript;
    private BeginGame beginGameScript;
    public Flashlight flashlightScript;
    private SaveGame SaveGameScript;
    private Canvas uiCanvas;
    public TextMeshProUGUI currenntItemTitle;
    public Image currentItemIcon;
    public bool isInventoryActive = false;
    private Menu gameMenuScript;
    public Notifications notificationScript;
    public Tasks tasksScript;
    public TaskBones bonesTaskScript;
    public AudioSource itemAudioSource1;
    public AudioSource itemAudioSource2;
    public AudioSource itemAudioSource4;
    public AudioSource pauseAudioSource;
    public Health healthScript;
    public Notes notesScript;
    public VoiceActing voiceActingScript;

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

    private ScrollRect notesScrollRect;
    private Scrollbar notesScrollbar;

    // treatment

    // treatment UI

    public Canvas treatmentCanvas;
    public TextMeshProUGUI mixturesText;
    public TextMeshProUGUI vialsText;
    public Text blueHerbsText;
    public Text greenHerbsText;
    public Text vialsCountText;
    public Text healthPotsText;
    public Text staminaPotsText;
    private TextMeshProUGUI healthConditionText;
    public bool isTreatmentActive = false;
    public AudioClip createPotSound;
    public AudioClip usePotSound;
    public AudioClip lackVialsSound;

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

    public bool isSkill1_Unlocked = false;
    public AudioClip skillUnlockedSound;
    public Image skill1_Icon;

    public bool isSkill2_Unlocked = false;
    public Image skill2_Icon;

    public bool isSkill3_Unlocked = false;
    public Image skill3_Icon;

    public bool isSkill4_Unlocked = false;
    public Image skill4_Icon;

    public int skillsCount = 0;

    void OnEnable()
    {
        
        itemDescriptionText = GameObject.Find("InventoryOpis").GetComponent<TextMeshProUGUI>();
        usedItemText = GameObject.Find("InventoryUsing").GetComponent<TextMeshProUGUI>();
        secretItemsText = GameObject.Find("InventorySecretItemsWynik").GetComponent<Text>();
        secretPlacesText = GameObject.Find("InventorySecretPlacesWynik").GetComponent<Text>();

    }

    public void BackFunction()
    {
        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;
        itemAudioSource3.PlayOneShot(menuButtonSound);
    }

    public void InventoryBackFunction()
    {

        //Panel.enabled = true;
        //Panel_ok = true;
        inventoryCanvas.enabled = false;
        isInventoryActive = false;
        //ZrodloDzwieku3.PlayOneShot (PrzyciskMenu);

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        noteDefaultCanvas.enabled = false;

        for (int i = 0; i < notesScript.notesCanvas2.Length; i++)
        {
            notesScript.notesCanvas2[i].enabled = false;
        }

        for (int i = 0; i < collectionCanvas.Length; i++)
        {
            collectionCanvas[i].enabled = false;
        }

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;

    }

    public void ShowDescription(int itemId)
    {
        if (items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == itemId)
                {
                    itemAudioSource3.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = items[i].name + " - " + items[i].description;
                    break;
                }
            } 
        }
    }

    public void UseItemFromSlot(int itemId)
    {
        if (items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == itemId)
                {
                    if (items[i].type == "KluczPokojW")
                    {

                        notificationScript.isUncleDoor = true;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczSzafkaKuchnia")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = true;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczStajnia")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = true;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczSzopa")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = true;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "Oliwa")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = true;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczWneka")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = true;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczKamping")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = true;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "FixedKey")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = true;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "Lom")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = true;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczSalonPoludnie")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = true;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "Kombinerki")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = true;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "Siekiera")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = true;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczSzafaKorytarz")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = true;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczSzafaSzopa")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = true;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczTomGora")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = true;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczPokojTom")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = true;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczStaryDom")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = true;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczSteven")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = true;
                        notificationScript.isPaulDoor = false;
                    }

                    else if (items[i].type == "KluczPokojZachod")
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = true;
                    }
                    else
                    {
                        notificationScript.isUncleDoor = false;
                        notificationScript.isKitchenWardrobe = false;
                        notificationScript.isStableDoor = false;
                        notificationScript.isToolShedDoor = false;
                        notificationScript.isGardenDoor = false;
                        notificationScript.isNicheDoor = false;
                        notificationScript.isSecretRoomDoor = false;
                        notificationScript.isFactoryWoodenDoor = false;
                        notificationScript.isFactoryMetalDoor = false;
                        notificationScript.isAliceRoomDoor = false;
                        notificationScript.isCornfieldDoor = false;
                        notificationScript.isPlanks = false;
                        notificationScript.isCorridorWardrobe = false;
                        notificationScript.isShedCupboard = false;
                        notificationScript.isTomUpstairsDoor = false;
                        notificationScript.isTomRoomDoor = false;
                        notificationScript.isOldWardrobe = false;
                        notificationScript.isStevenDoor = false;
                        notificationScript.isPaulDoor = false;
                    }

                    usedItemText.text = items[i].name + usingItemText;

                    currentItemIcon.sprite = items[i].icon;
                    currentItemIcon.color = Color.white;
                    currenntItemTitle.text = items[i].name;

                    // funkcja inventory back bez wywolania dzwieku menu

                    inventoryCanvas.enabled = false;
                    isInventoryActive = false;

                    noteDefaultCanvas.enabled = false;

                    for (int j = 0; i < notesScript.notesCanvas2.Length; i++)
                    {
                        notesScript.notesCanvas2[i].enabled = false;
                    }

                    for (int j = 0; i < collectionCanvas.Length; i++)
                    {
                        collectionCanvas[i].enabled = false;
                    }

                    Time.timeScale = 1;
                    playerScript.enabled = true;
                    playerScript.audioSource.UnPause();
                    cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;

                    // koniec funkcji inventory back

                    break;
                }
            }

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == itemId)
                {
                    items[i].isUsed = true;
                    itemAudioSource3.PlayOneShot(useItemSound);
                }
                else
                {
                    items[i].isUsed = false;
                }
            }

        }

    }

    public void UnlockSkill1()
    {
        if (secretItemsCount >= 7 && secretPlacesCount >= 2 && isSkill1_Unlocked == false)
        {
            itemAudioSource3.PlayOneShot(skillUnlockedSound);
            skill1_Icon.color = Color.green;
            isSkill1_Unlocked = true;
            playerScript.maxStamina = 200;
            skillsCount++;
        }
    }

    public void UnlockSkill2()
    {
        if (secretItemsCount >= 13 && secretPlacesCount >= 6 && isSkill2_Unlocked == false)
        {
            itemAudioSource3.PlayOneShot(skillUnlockedSound);
            skill2_Icon.color = Color.green;
            isSkill2_Unlocked = true;
            flashlightScript.lightRange = 50;
            skillsCount++;
        }
    }

    public void UnlockSkill3()
    {
        if (secretItemsCount >= 18 && secretPlacesCount >= 10 && isSkill3_Unlocked == false)
        {
            itemAudioSource3.PlayOneShot(skillUnlockedSound);
            skill3_Icon.color = Color.green;
            isSkill3_Unlocked = true;
            playerScript.staminaRegenerationFactor = 9;
            skillsCount++;
        }
    }

    public void UnlockSkill4()
    {
        if (secretItemsCount >= 22 && secretPlacesCount >= 13 && isSkill4_Unlocked == false)
        {
            itemAudioSource3.PlayOneShot(skillUnlockedSound);
            skill4_Icon.color = Color.green;
            isSkill4_Unlocked = true;
            skillsCount++;
        }
    }


}
