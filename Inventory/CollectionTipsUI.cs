using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionTipsUI : MonoBehaviour {

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

    private Transform tip1;
    public bool isTip1 = false;
    private Transform tip2;
    public bool isTip2 = false;
    private Transform tip3;
    public bool isTip3 = false;
    private Transform tip4;
    public bool isTip4 = false;
    private Transform tip5;
    public bool isTip5 = false;
    private Transform tip6;
    public bool isTip6 = false;
    private Transform tip7;
    public bool isTip7 = false;
    private Transform tip8;
    public bool isTip8 = false;
    private Transform tip9;
    public bool isTip9 = false;
    private Transform tip10;
    public bool isTip10 = false;
    private Transform tip11;
    public bool isTip11 = false;
    private Transform tip12;
    public bool isTip12 = false;

    public string[] collectionTitles;

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isCollectionActive == true)
        {
            CollectionBackFunction();
        }
    }

    public void ShowTipCollection()
    {
        InventoryUIManager.ResetUI();
        itemAudioSource3.PlayOneShot(menuButtonSound);
        tipCollectionCanvas.enabled = true;
        isCollectionActive = true;
    }

    public void CollectionBackFunction()
    {
        InventoryUIManager.ResetUI();

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

        Time.timeScale = 1;
        playerScript.enabled = true;
        playerScript.audioSource.UnPause();
        cursorScript.m_ShowCursor = !cursorScript.m_ShowCursor;

    }

    public void CollectionWskazowka1()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip1 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = true;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[27];

        }

    }

    public void CollectionWskazowka2()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip2 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = true;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[28];

        }

    }

    public void CollectionWskazowka3()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip3 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = true;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[29];

        }

    }

    public void CollectionWskazowka4()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip4 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = true;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[30];

        }

    }

    public void CollectionWskazowka5()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip5 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = true;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[31];

        }

    }

    public void CollectionWskazowka6()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip6 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = true;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[32];

        }

    }

    public void CollectionWskazowka7()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip7 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = true;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[33];

        }

    }

    public void CollectionWskazowka8()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip8 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = true;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[34];

        }

    }

    public void CollectionWskazowka9()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip9 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = true;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[35];

        }

    }

    public void CollectionWskazowka10()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip10 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = true;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[36];

        }

    }

    public void CollectionWskazowka11()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip11 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = true;
            collectionCanvas[36].enabled = false;
            tipCollectionTitleText.text = collectionTitles[37];

        }

    }

    public void CollectionWskazowka12()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = true;

        if (isTip12 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = false;
            collectionCanvas[8].enabled = false;
            collectionCanvas[9].enabled = false;
            collectionCanvas[10].enabled = false;
            collectionCanvas[11].enabled = false;
            collectionCanvas[12].enabled = false;
            collectionCanvas[13].enabled = false;
            collectionCanvas[14].enabled = false;
            collectionCanvas[15].enabled = false;
            collectionCanvas[16].enabled = false;
            collectionCanvas[17].enabled = false;
            collectionCanvas[18].enabled = false;
            collectionCanvas[19].enabled = false;
            collectionCanvas[20].enabled = false;
            collectionCanvas[21].enabled = false;
            collectionCanvas[22].enabled = false;
            collectionCanvas[23].enabled = false;
            collectionCanvas[24].enabled = false;
            collectionCanvas[25].enabled = false;
            collectionCanvas[26].enabled = false;
            collectionCanvas[27].enabled = false;
            collectionCanvas[28].enabled = false;
            collectionCanvas[29].enabled = false;
            collectionCanvas[30].enabled = false;
            collectionCanvas[31].enabled = false;
            collectionCanvas[32].enabled = false;
            collectionCanvas[33].enabled = false;
            collectionCanvas[34].enabled = false;
            collectionCanvas[35].enabled = false;
            collectionCanvas[36].enabled = true;
            tipCollectionTitleText.text = collectionTitles[38];

        }

    }

}
