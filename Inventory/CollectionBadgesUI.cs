using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionBadgesUI : MonoBehaviour {

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
    public static bool isCollectionActive = false;

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

    private Transform badge1;
    public bool isBadge1 = false;
    private Transform badge2;
    public bool isBadge2 = false;
    private Transform badge3;
    public bool isBadge3 = false;
    private Transform badge4;
    public bool isBadge4 = false;
    private Transform badge5;
    public bool isBadge5 = false;
    private Transform badge6;
    public bool isBadge6 = false;
    private Transform badge7;
    public bool isBadge7 = false;
    private Transform badge8;
    public bool isBadge8 = false;
    private Transform badge9;
    public bool isBadge9 = false;
    private Transform badge10;
    public bool isBadge10 = false;
    private Transform badge11;
    public bool isBadge11 = false;
    private Transform badge12;
    public bool isBadge12 = false;

    public string[] collectionTitles;

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isCollectionActive == true)
        {
            CollectionBackFunction();
        }
    }

    public void ShowBadgeCollection()
    {
        InventoryUIManager.ResetUI();
        itemAudioSource3.PlayOneShot(menuButtonSound);
        badgeCollectionCanvas.enabled = true;
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

    public void CollectionOdznaka1()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge1 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[3];

        }

    }

    public void CollectionOdznaka2()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge2 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[4];

        }

    }

    public void CollectionOdznaka3()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge3 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[5];

        }

    }

    public void CollectionOdznaka4()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge4 == true)
        {


            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[6];

        }

    }

    public void CollectionOdznaka5()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge5 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[7];

        }

    }

    public void CollectionOdznaka6()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge6 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[8];

        }

    }

    public void CollectionOdznaka7()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge7 == true)
        {

            itemAudioSource3.PlayOneShot(menuButtonSound);
            collectionCanvas[0].enabled = false;
            collectionCanvas[1].enabled = false;
            collectionCanvas[2].enabled = false;
            collectionCanvas[3].enabled = false;
            collectionCanvas[4].enabled = false;
            collectionCanvas[5].enabled = false;
            collectionCanvas[6].enabled = false;
            collectionCanvas[7].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[9];

        }

    }

    public void CollectionOdznaka8()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge8 == true)
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
            collectionCanvas[8].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[10];

        }

    }

    public void CollectionOdznaka9()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge9 == true)
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
            collectionCanvas[9].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[11];

        }

    }

    public void CollectionOdznaka10()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge10 == true)
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
            collectionCanvas[10].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[12];

        }

    }

    public void CollectionOdznaka11()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge11 == true)
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
            collectionCanvas[11].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[13];

        }

    }

    public void CollectionOdznaka12()
    {

        badgeCollectionCanvas.enabled = true;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;

        if (isBadge12 == true)
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
            collectionCanvas[12].enabled = true;
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
            collectionCanvas[36].enabled = false;
            badgeCollectionTitleText.text = collectionTitles[14];

        }

    }


}
