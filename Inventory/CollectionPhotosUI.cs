using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionPhotosUI : MonoBehaviour {

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

    private Transform photo1;
    public bool isPhoto1 = false;
    private Transform photo2;
    public bool isPhoto2 = false;
    private Transform photo3;
    public bool isPhoto3 = false;
    private Transform photo4;
    public bool isPhoto4 = false;
    private Transform photo5;
    public bool isPhoto5 = false;
    private Transform photo6;
    public bool isPhoto6 = false;
    private Transform photo7;
    public bool isPhoto7 = false;
    private Transform photo8;
    public bool isPhoto8 = false;
    private Transform photo9;
    public bool isPhoto9 = false;
    private Transform photo10;
    public bool isPhoto10 = false;
    private Transform photo11;
    public bool isPhoto11 = false;
    private Transform photo12;
    public bool isPhoto12 = false;

    public string[] collectionTitles;

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isCollectionActive == true)
        {
            CollectionBackFunction();
        }
    }

    public void ShowPhotoCollection()
    {
        InventoryUIManager.ResetUI();
        itemAudioSource3.PlayOneShot(menuButtonSound);
        photoCollectionCanvas.enabled = true;
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

    public void CollectionFoto1()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto1 == true)
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
            collectionCanvas[13].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[15];

        }

    }

    public void CollectionFoto2()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto2 == true)
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
            collectionCanvas[14].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[16];

        }

    }

    public void CollectionFoto3()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto3 == true)
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
            collectionCanvas[15].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[17];

        }

    }

    public void CollectionFoto4()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto4 == true)
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
            collectionCanvas[16].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[18];

        }

    }

    public void CollectionFoto5()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto5 == true)
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
            collectionCanvas[17].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[19];

        }

    }

    public void CollectionFoto6()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto6 == true)
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
            collectionCanvas[18].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[20];

        }

    }

    public void CollectionFoto7()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto7 == true)
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
            collectionCanvas[19].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[21];

        }

    }

    public void CollectionFoto8()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto8 == true)
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
            collectionCanvas[20].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[22];

        }

    }

    public void CollectionFoto9()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto9 == true)
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
            collectionCanvas[21].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[23];

        }

    }

    public void CollectionFoto10()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto10 == true)
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
            collectionCanvas[22].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[24];

        }

    }

    public void CollectionFoto11()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto11 == true)
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
            collectionCanvas[23].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[25];

        }

    }

    public void CollectionFoto12()
    {

        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = true;
        tipCollectionCanvas.enabled = false;

        if (isPhoto12 == true)
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
            collectionCanvas[24].enabled = true;
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
            photoCollectionTitleText.text = collectionTitles[26];

        }

    }


}
