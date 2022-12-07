using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryUI : MonoBehaviour {

    public static bool isInventoryActive = false;

    private Inventory inventoryScript;
    private Player playerScript;
    private CrosshairGUI cursorScript;
    private Flashlight flashlightScript;

    [Header("UI elements")]
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private TextMeshProUGUI usedItemText;
    [SerializeField] private Canvas inventoryCanvas;
    [SerializeField] private Image[] inventorySlots;

    public Text secretItemsText;
    public Text secretPlacesText;

    [Header("Audio elements")]
    [SerializeField] private AudioSource itemAudioSource;
    [SerializeField] private AudioSource pauseAudioSource;
    [SerializeField] private AudioClip menuButtonSound;
    [SerializeField] private AudioClip useItemSound;
    [SerializeField] private AudioClip itemDesciptionSound;
    [SerializeField] private AudioClip openInventorySound;

    [Header("Texts")]
    private string defaultDescription = "Hover on object to see description";
    private string defaultUsingItemText = "Click on item to use it";
    private string usingItemText = " is using now!";

    [Header("Skills")]
    [SerializeField] private bool isSkill1_Unlocked = false;
    [SerializeField] private AudioClip skillUnlockedSound;
    [SerializeField] private Image skill1_Icon;

    [SerializeField] private bool isSkill2_Unlocked = false;
    [SerializeField] private Image skill2_Icon;

    [SerializeField] private bool isSkill3_Unlocked = false;
    [SerializeField] private Image skill3_Icon;

    [SerializeField] private bool isSkill4_Unlocked = false;
    [SerializeField] private Image skill4_Icon;

    [SerializeField] private int skillsCount = 0;

    public event Action OnUsedItemFromSlot;

    void Start()
    {
        inventoryScript.OnAddedItem += UpdateInventorySlots;
        inventoryScript.OnRemovedItem += UpdateInventorySlots;
        inventoryScript.OnAddedCollectibleItem += UpdateSecretPlaceCount;
    }

    void OnEnable()
    {
        itemDescriptionText = GameObject.Find("InventoryOpis").GetComponent<TextMeshProUGUI>();
        usedItemText = GameObject.Find("InventoryUsing").GetComponent<TextMeshProUGUI>();
        secretItemsText = GameObject.Find("InventorySecretItemsWynik").GetComponent<Text>();
        secretPlacesText = GameObject.Find("InventorySecretPlacesWynik").GetComponent<Text>();
    }

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isInventoryActive == true)
        {
            InventoryBackFunction();
        }
    }

    public void ShowInventory()
    {

        InventoryUIManager.ResetUI();

        if (Time.timeScale == 0)
        {
            itemAudioSource.PlayOneShot(menuButtonSound);
        }

        inventoryCanvas.enabled = true;
        isInventoryActive = true;

    }

    void UpdateInventorySlots()
    {

        foreach(var slot in inventorySlots)
        {
            slot.sprite = null;
            slot.color = Color.black;
        }


        for (int i = 0; i < inventoryScript.items.Count; i++)
        {
            inventorySlots[i].sprite = inventoryScript.items[i].icon;
            inventorySlots[i].color = Color.white;
            break;
        }


        itemDescriptionText.text = defaultDescription;
        usedItemText.text = defaultUsingItemText;

    }

    void UpdateSecretPlaceCount()
    {
        secretItemsText.text = inventoryScript.secretItemsCount.ToString();
    }

    public void InventoryBackFunction()
    {

        InventoryUIManager.ResetUI();

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;

    }

    public void ShowDescription(int itemId)
    {
        if (inventoryScript.items.Count > 0)
        {
            for (int i = 0; i < inventoryScript.items.Count; i++)
            {
                if (inventoryScript.items[i].id == itemId)
                {
                    itemAudioSource.PlayOneShot(itemDesciptionSound);
                    itemDescriptionText.text = inventoryScript.items[i].name + " - " + inventoryScript.items[i].description;
                    break;
                }
            } 
        }
    }

    public void UseItemFromSlot(int itemId)
    {
        if (inventoryScript.items.Count > 0)
        {
            for (int i = 0; i < inventoryScript.items.Count; i++)
            {
                if (inventoryScript.items[i].id == itemId)
                {

                    InventoryUIManager.ResetUI();

                    inventoryScript.items[i].isUsed = true;
                    itemAudioSource.PlayOneShot(useItemSound);
                    usedItemText.text = inventoryScript.items[i].name + usingItemText;

                    Time.timeScale = 1;
                    playerScript.enabled = true;
                    playerScript.audioSource.UnPause();
                    cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;

                    if(OnUsedItemFromSlot != null)
                    {
                        OnUsedItemFromSlot.Invoke();
                    }

                    break;
                }
            }
        }
    }

    public void UnlockSkill1()
    {
        if (inventoryScript.secretItemsCount >= 7 && inventoryScript.secretPlacesCount >= 2 && isSkill1_Unlocked == false)
        {
            itemAudioSource.PlayOneShot(skillUnlockedSound);
            skill1_Icon.color = Color.green;
            isSkill1_Unlocked = true;
            Player.maxStamina = 200;
            inventoryScript.skillsCount++;
        }
    }

    public void UnlockSkill2()
    {
        if (inventoryScript.secretItemsCount >= 13 && inventoryScript.secretPlacesCount >= 6 && isSkill2_Unlocked == false)
        {
            itemAudioSource.PlayOneShot(skillUnlockedSound);
            skill2_Icon.color = Color.green;
            isSkill2_Unlocked = true;
            flashlightScript.lightRange = 50;
            inventoryScript.skillsCount++;
        }
    }

    public void UnlockSkill3()
    {
        if (inventoryScript.secretItemsCount >= 18 && inventoryScript.secretPlacesCount >= 10 && isSkill3_Unlocked == false)
        {
            itemAudioSource.PlayOneShot(skillUnlockedSound);
            skill3_Icon.color = Color.green;
            isSkill3_Unlocked = true;
            playerScript.staminaRegenerationFactor = 9;
            inventoryScript.skillsCount++;
        }
    }

    public void UnlockSkill4()
    {
        if (inventoryScript.secretItemsCount >= 22 && inventoryScript.secretPlacesCount >= 13 && isSkill4_Unlocked == false)
        {
            itemAudioSource.PlayOneShot(skillUnlockedSound);
            skill4_Icon.color = Color.green;
            isSkill4_Unlocked = true;
            inventoryScript.skillsCount++;
        }
    }

    public void HoverButton()
    {
        itemAudioSource.PlayOneShot(itemDesciptionSound);
    }
}
