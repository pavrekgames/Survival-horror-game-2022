using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreatmentUI : MonoBehaviour {

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

    public string defaultPotDescription = "Hover over the mixture to get more information.";
    public string healthPotDescription = "Health Mixture  - Increase your health. You need 2 green herbs and 2 blue herbs to create it.";
    public string staminaPotDescription = "Stamina Mixture  - Increase your Stamina. You need 1 green herb and 2 blue herbs to create it.";
    public string stateGoodText = "<color=#08FF5BFF>Good</color>";
    public string stateInjuredText = "<color=#FFC117FF>Injured</color>";
    public string stateCriticalText = "<color=#FF4E26FF>Critical</color>";
    public string stateTiredText = "<color=#BF42C7FF>Tired</color>";
    public string lackComponentsText = "<color=#FF0000FF>You don't have enough herbs or a vial</color>";

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isTreatmentActive == true)
        {
            TreatmentBackFunction();
        }
    }

    public void ShowTreatment()
    {

        CheckHealthCondition();
        itemAudioSource3.PlayOneShot(menuButtonSound);

        inventoryCanvas.enabled = false;
        isInventoryActive = false;
        tasksCanvas.enabled = false;
        isTasksActive = false;
        notesCanvas.enabled = false;
        isNotesActive = false;
        treatmentCanvas.enabled = true;
        isTreatmentActive = true;
        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;
        isCollectionActive = false;

        noteDefaultCanvas.enabled = false;

    }

    public void TreatmentBackFunction()
    {

        //Panel.enabled = true;
        //Panel_ok = true;
        treatmentCanvas.enabled = false;
        isTreatmentActive = false;
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

    // funkcje do apteczki

    public void ShowHealthPotDescription()
    {
        itemAudioSource3.PlayOneShot(itemDesciptionSound);
        mixturesText.text = healthPotDescription;
    }

    public void ShowStaminaPotDescription()
    {
        itemAudioSource3.PlayOneShot(itemDesciptionSound);
        mixturesText.text = staminaPotDescription;
    }

    public void CreateHealthPot()
    {

        if (greenHerbsCount >= 2 && blueHerbsCount >= 2 && vialsCount > 0)
        {
            greenHerbsCount -= 2;
            blueHerbsCount -= 2;
            vialsCount--;
            healthPotsCount++;
            itemAudioSource1.PlayOneShot(createPotSound);
            healthPotsText.text = healthPotsCount + "";
            greenHerbsText.text = greenHerbsCount + "";
            blueHerbsText.text = blueHerbsCount + "";
            vialsCountText.text = vialsCount + "";
        }
        else
        {
            itemAudioSource3.PlayOneShot(lackVialsSound);
            mixturesText.text = lackComponentsText;
        }
    }

    public void CreateStaminaPot()
    {

        if (greenHerbsCount >= 1 && blueHerbsCount >= 2 && vialsCount > 0)
        {
            greenHerbsCount -= 1;
            blueHerbsCount -= 2;
            vialsCount--;
            staminaPotsCount++;
            itemAudioSource3.PlayOneShot(createPotSound);
            staminaPotsText.text = staminaPotsCount + "";
            greenHerbsText.text = greenHerbsCount + "";
            blueHerbsText.text = blueHerbsCount + "";
            vialsCountText.text = vialsCount + "";
        }
        else
        {
            itemAudioSource3.PlayOneShot(lackVialsSound);
            mixturesText.text = lackComponentsText;
        }
    }

    public void UseHealthPot()
    {

        if (healthPotsCount > 0)
        {
            healthPotsCount--;
            healthScript.health += 50;
            itemAudioSource4.PlayOneShot(usePotSound);
            healthPotsText.text = healthPotsCount + "";
        }
    }

    public void UseStaminaPot()
    {

        if (staminaPotsCount > 0)
        {
            staminaPotsCount--;
            playerScript.currentStamina += 60;
            itemAudioSource4.PlayOneShot(usePotSound);
            staminaPotsText.text = staminaPotsCount + "";
        }
    }

    void CheckHealthCondition()
    {

        if (healthScript.health >= 70 && playerScript.isRest == true)
        {
            healthConditionText.text = stateGoodText;
        }
        else if (healthScript.health > 40 && healthScript.health < 70)
        {
            healthConditionText.text = stateInjuredText;
        }
        else if (healthScript.health <= 40)
        {
            healthConditionText.text = stateCriticalText;
        }
        else if (healthScript.health >= 70 && playerScript.isRest == false)
        {
            healthConditionText.text = stateTiredText;
        }

    }

    public void HoverButton()
    {

        itemAudioSource3.PlayOneShot(itemDesciptionSound);

    }

}
