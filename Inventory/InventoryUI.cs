﻿using System.Collections;
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

    public void ShowDescriptionSlot1()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 1)
                {
                    itemAudioSource3.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = items[i].name + " - " + items[i].description;
                    break;
                }

            } // do fora

        } // do 1 ifa

    } // do funkcji

    public void ShowDescriptionSlot2()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 2)
                {
                    itemAudioSource3.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = items[i].name + " - " + items[i].description;
                    break;
                }
            }

        }

    }

    public void ShowDescriptionSlot3()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 3)
                {
                    itemAudioSource3.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = items[i].name + " - " + items[i].description;
                    break;
                }
            }

        }

    }

    public void ShowDescriptionSlot4()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 4)
                {
                    itemAudioSource3.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = items[i].name + " - " + items[i].description;
                    break;
                }
            }

        }

    }

    public void ShowDescriptionSlot5()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 5)
                {
                    itemAudioSource3.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = items[i].name + " - " + items[i].description;
                    break;
                }
            }

        }

    }

    public void ShowDescriptionSlot6()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 6)
                {
                    itemAudioSource3.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = items[i].name + " - " + items[i].description;
                    break;
                }
            }

        }

    }

    public void ShowDescriptionSlot7()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 7)
                {
                    itemAudioSource3.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = items[i].name + " - " + items[i].description;
                    break;
                }
            }

        }

    }

    public void ShowDescriptionSlot8()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 8)
                {
                    itemAudioSource3.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = items[i].name + " - " + items[i].description;
                    break;
                }
            }

        }

    }

    public void ShowDescriptionSlot9()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 9)
                {
                    itemAudioSource3.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = items[i].name + " - " + items[i].description;
                    break;
                }
            }

        }

    }

    public void UseItemFromSlot1()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 1)
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
                if (items[i].id == 1)
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

    public void UseItemFromSlot2()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 2)
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
                if (items[i].id == 2)
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

    public void UseItemFromSlot3()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 3)
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
                if (items[i].id == 3)
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

    public void UseItemFromSlot4()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 4)
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
                if (items[i].id == 4)
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

    public void UseItemFromSlot5()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 5)
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
                if (items[i].id == 5)
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

    public void UseItemFromSlot6()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 6)
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
                if (items[i].id == 6)
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

    public void UseItemFromSlot7()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 7)
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
                if (items[i].id == 7)
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

    public void UseItemFromSlot8()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 8)
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
                if (items[i].id == 8)
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

    public void UseItemFromSlot9()
    {

        if (items.Count > 0)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == 9)
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
                if (items[i].id == 9)
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


}
