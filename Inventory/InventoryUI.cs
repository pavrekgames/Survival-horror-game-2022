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
    public string defaultDescription;
    public string defaultUsingItemText;
    public string usingItemText = " is using now!";

    public Image[] inventorySlots;
    private Inventory inventoryScript;
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
    public static bool isInventoryActive = false;
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
            itemAudioSource3.PlayOneShot(menuButtonSound);
        }

        inventoryCanvas.enabled = true;
        isInventoryActive = true;
        notificationScript.taskHintTime = 5f;

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

                    usedItemText.text = items[i].name + usingItemText;

                    currentItemIcon.sprite = items[i].icon;
                    currentItemIcon.color = Color.white;
                    currenntItemTitle.text = items[i].name;

                    // funkcja inventory back bez wywolania dzwieku menu

                    inventoryCanvas.enabled = false;
                    isInventoryActive = false;

                    noteDefaultCanvas.enabled = false;

                    for (int j = 0; j < notesScript.notesCanvas2.Length; j++)
                    {
                        notesScript.notesCanvas2[j].enabled = false;
                    }

                    for (int j = 0; j < collectionCanvas.Length; j++)
                    {
                        collectionCanvas[j].enabled = false;
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

    public void HoverButton()
    {

        itemAudioSource3.PlayOneShot(itemDesciptionSound);

    }
}
