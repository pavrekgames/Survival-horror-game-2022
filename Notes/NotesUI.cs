using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotesUI : MonoBehaviour {

    public Canvas tasksCanvas;
    public bool isTasksActive = false;
    public AudioSource audioSource;
    public Canvas[] notesCanvas2;
    public Canvas defaultNoteCanvas;
    public AudioClip notesSound;
    public AudioClip hoverNoteSound;
    public AudioSource hoverAudioSource;
    public TextMeshProUGUI noteTitleTextMesh;

    public Sprite noteIcon1;
    public Sprite noteIcon2;
    public Sprite noteIcon3;
    public Sprite noteIcon4;
    public Sprite noteIcon5;
    public Sprite noteIcon6;
    public Sprite noteIcon7;
    public Sprite noteIcon8;
    public Sprite noteDefaultIcon;
    public Button[] notesIcons;

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

    public AudioClip openInventorySound;

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

    public bool isNote1 = false;
    public bool isNote2 = false;
    public bool isNote3 = false;
    public bool isNote4 = false;
    public bool isNote5 = false;
    public bool isNote6 = false;
    public bool isNote7 = false;
    public bool isNote8 = false;
    public bool isNote9 = false;
    public bool isNote10 = false;
    public bool isNote11 = false;
    public bool isNote12 = false;
    public bool isNote13 = false;
    public bool isNote14 = false;
    public bool isNote15 = false;
    public bool isNote16 = false;
    public bool isNote17 = false;
    public bool isNote18 = false;
    public bool isNote19 = false;
    public bool isNote20 = false;
    public bool isNote21 = false;
    public bool isNote22 = false;
    public bool isNote23 = false;
    public bool isNote24 = false;
    public bool isNote25 = false;
    public bool isNote26 = false;
    public bool isNote27 = false;
    public bool isNote28 = false;
    public bool isNote29 = false;
    public bool isNote30 = false;
    public bool isNote31 = false;
    public bool isNote32 = false;
    public bool isNote33 = false;
    public bool isNote34 = false;
    public bool isNote35 = false;
    public bool isNote36 = false;
    public bool isNote37 = false;
    public bool isNote38 = false;
    public bool isNote39 = false;
    public bool isNote40 = false;
    public bool isNote41 = false;
    public bool isNote42 = false;
    public bool isNote43 = false;
    public bool isNote44 = false;
    public bool isNote45 = false;
    public bool isNote46 = false;
    public bool isNote47 = false;
    public bool isNote48 = false;
    public bool isNote49 = false;
    public bool isNote50 = false;
    public bool isNote51 = false;
    public bool isNote52 = false;
    public bool isNote53 = false;
    public bool isNote54 = false;

    void Update()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Inventory")) && isNotesActive == true)
        {
            NotesBackFunction();
        }
    }

    public void ShowNotes()
    {

        StartCoroutine(ShowNotesIE());

    }

    public IEnumerator ShowNotesIE()
    {

        itemAudioSource3.PlayOneShot(menuButtonSound);

        inventoryCanvas.enabled = false;
        isInventoryActive = false;
        tasksCanvas.enabled = false;
        isTasksActive = false;
        notesCanvas.enabled = true;
        isNotesActive = true;
        treatmentCanvas.enabled = false;
        isTreatmentActive = false;
        badgeCollectionCanvas.enabled = false;
        photoCollectionCanvas.enabled = false;
        tipCollectionCanvas.enabled = false;
        isCollectionActive = false;

        noteDefaultCanvas.enabled = true;

        yield return new WaitForSecondsRealtime(0.01f);

        notesScrollRect.GetComponent<ScrollRect>().enabled = true;
        notesScrollbar.value = 1;
        StopCoroutine(ShowNotesIE());

    }

    public void NotesBackFunction()
    {

        notesCanvas.enabled = false;
        isNotesActive = false;
        noteDefaultCanvas.enabled = false;

        pauseAudioSource.pitch = 1.3f;
        pauseAudioSource.PlayOneShot(openInventorySound, 0.5f);

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

    public void ShowNote(int id)
    {
        defaultNoteCanvas.enabled = false;

        for (int i = 0; i < notesCanvas2.Length; i++)
        {
            if (i == id)
            {
                notesCanvas2[i].enabled = true;
                audioSource.pitch = Random.Range(0.8f, 1.5f);
                audioSource.PlayOneShot(notesSound);
            }
            else
            {
                notesCanvas2[i].enabled = false;
            }
        }
    }

    public void ShowNoteTitle(string noteTitle)
    {
        noteTitleTextMesh.text = noteTitle;
        hoverAudioSource.PlayOneShot(hoverNoteSound);
    }

    // -----------Funkcje do zbierania notatek-----------------

    void ZnalezioneNotatki()
    {
        if (isNote1 == true)
        {
            notesIcons[0].image.sprite = noteIcon1;
        }
        else
        {
            notesIcons[0].image.sprite = noteDefaultIcon;
        }

        if (isNote2 == true)
        {
            notesIcons[1].image.sprite = noteIcon2;
        }
        else
        {
            notesIcons[1].image.sprite = noteDefaultIcon;
        }

        if (isNote3 == true)
        {
            notesIcons[2].image.sprite = noteIcon3;
        }
        else
        {
            notesIcons[2].image.sprite = noteDefaultIcon;
        }

        if (isNote4 == true)
        {
            notesIcons[3].image.sprite = noteIcon4;
        }
        else
        {
            notesIcons[3].image.sprite = noteDefaultIcon;
        }

        if (isNote5 == true)
        {
            notesIcons[4].image.sprite = noteIcon3;
        }
        else
        {
            notesIcons[4].image.sprite = noteDefaultIcon;
        }

        if (isNote6 == true)
        {
            notesIcons[5].image.sprite = noteIcon5;
        }
        else
        {
            notesIcons[5].image.sprite = noteDefaultIcon;
        }

        if (isNote7 == true)
        {
            notesIcons[6].image.sprite = noteIcon6;
        }
        else
        {
            notesIcons[6].image.sprite = noteDefaultIcon;
        }

        if (isNote8 == true)
        {
            notesIcons[7].image.sprite = noteIcon7;
        }
        else
        {
            notesIcons[7].image.sprite = noteDefaultIcon;
        }

        if (isNote9 == true)
        {
            notesIcons[8].image.sprite = noteIcon4;
        }
        else
        {
            notesIcons[8].image.sprite = noteDefaultIcon;
        }

        if (isNote10 == true)
        {
            notesIcons[9].image.sprite = noteIcon1;
        }
        else
        {
            notesIcons[9].image.sprite = noteDefaultIcon;
        }

        if (isNote11 == true)
        {
            notesIcons[10].image.sprite = noteIcon6;
        }
        else
        {
            notesIcons[10].image.sprite = noteDefaultIcon;
        }

        if (isNote12 == true)
        {
            notesIcons[11].image.sprite = noteIcon5;
        }
        else
        {
            notesIcons[11].image.sprite = noteDefaultIcon;
        }

        if (isNote13 == true)
        {
            notesIcons[12].image.sprite = noteIcon2;
        }
        else
        {
            notesIcons[12].image.sprite = noteDefaultIcon;
        }

        if (isNote14 == true)
        {
            notesIcons[13].image.sprite = noteIcon7;
        }
        else
        {
            notesIcons[13].image.sprite = noteDefaultIcon;
        }

        if (isNote15 == true)
        {
            notesIcons[14].image.sprite = noteIcon8;
        }
        else
        {
            notesIcons[14].image.sprite = noteDefaultIcon;
        }

        if (isNote16 == true)
        {
            notesIcons[15].image.sprite = noteIcon3;
        }
        else
        {
            notesIcons[15].image.sprite = noteDefaultIcon;
        }

        if (isNote17 == true)
        {
            notesIcons[16].image.sprite = noteIcon5;
        }
        else
        {
            notesIcons[16].image.sprite = noteDefaultIcon;
        }

        if (isNote18 == true)
        {
            notesIcons[17].image.sprite = noteIcon4;
        }
        else
        {
            notesIcons[17].image.sprite = noteDefaultIcon;
        }

        if (isNote19 == true)
        {
            notesIcons[18].image.sprite = noteIcon7;
        }
        else
        {
            notesIcons[18].image.sprite = noteDefaultIcon;
        }

        if (isNote20 == true)
        {
            notesIcons[19].image.sprite = noteIcon1;
        }
        else
        {
            notesIcons[19].image.sprite = noteDefaultIcon;
        }

        if (isNote21 == true)
        {
            notesIcons[20].image.sprite = noteIcon6;
        }
        else
        {
            notesIcons[20].image.sprite = noteDefaultIcon;
        }

        if (isNote22 == true)
        {
            notesIcons[21].image.sprite = noteIcon8;
        }
        else
        {
            notesIcons[21].image.sprite = noteDefaultIcon;
        }

        if (isNote23 == true)
        {
            notesIcons[22].image.sprite = noteIcon2;
        }
        else
        {
            notesIcons[22].image.sprite = noteDefaultIcon;
        }

        if (isNote24 == true)
        {
            notesIcons[23].image.sprite = noteIcon3;
        }
        else
        {
            notesIcons[23].image.sprite = noteDefaultIcon;
        }

        if (isNote25 == true)
        {
            notesIcons[24].image.sprite = noteIcon4;
        }
        else
        {
            notesIcons[24].image.sprite = noteDefaultIcon;
        }

        if (isNote26 == true)
        {
            notesIcons[25].image.sprite = noteIcon1;
        }
        else
        {
            notesIcons[25].image.sprite = noteDefaultIcon;
        }

        if (isNote27 == true)
        {
            notesIcons[26].image.sprite = noteIcon5;
        }
        else
        {
            notesIcons[26].image.sprite = noteDefaultIcon;
        }

        if (isNote28 == true)
        {
            notesIcons[27].image.sprite = noteIcon2;
        }
        else
        {
            notesIcons[27].image.sprite = noteDefaultIcon;
        }

        if (isNote29 == true)
        {
            notesIcons[28].image.sprite = noteIcon7;
        }
        else
        {
            notesIcons[28].image.sprite = noteDefaultIcon;
        }

        if (isNote30 == true)
        {
            notesIcons[29].image.sprite = noteIcon1;
        }
        else
        {
            notesIcons[29].image.sprite = noteDefaultIcon;
        }

        if (isNote31 == true)
        {
            notesIcons[30].image.sprite = noteIcon6;
        }
        else
        {
            notesIcons[30].image.sprite = noteDefaultIcon;
        }

        if (isNote32 == true)
        {
            notesIcons[31].image.sprite = noteIcon5;
        }
        else
        {
            notesIcons[31].image.sprite = noteDefaultIcon;
        }

        if (isNote33 == true)
        {
            notesIcons[32].image.sprite = noteIcon3;
        }
        else
        {
            notesIcons[32].image.sprite = noteDefaultIcon;
        }

        if (isNote34 == true)
        {
            notesIcons[33].image.sprite = noteIcon4;
        }
        else
        {
            notesIcons[33].image.sprite = noteDefaultIcon;
        }

        if (isNote35 == true)
        {
            notesIcons[34].image.sprite = noteIcon8;
        }
        else
        {
            notesIcons[34].image.sprite = noteDefaultIcon;
        }

        if (isNote36 == true)
        {
            notesIcons[35].image.sprite = noteIcon2;
        }
        else
        {
            notesIcons[35].image.sprite = noteDefaultIcon;
        }

        if (isNote37 == true)
        {
            notesIcons[36].image.sprite = noteIcon8;
        }
        else
        {
            notesIcons[36].image.sprite = noteDefaultIcon;
        }

        if (isNote38 == true)
        {
            notesIcons[37].image.sprite = noteIcon7;
        }
        else
        {
            notesIcons[37].image.sprite = noteDefaultIcon;
        }

        if (isNote39 == true)
        {
            notesIcons[38].image.sprite = noteIcon1;
        }
        else
        {
            notesIcons[38].image.sprite = noteDefaultIcon;
        }

        if (isNote40 == true)
        {
            notesIcons[39].image.sprite = noteIcon6;
        }
        else
        {
            notesIcons[39].image.sprite = noteDefaultIcon;
        }

        if (isNote41 == true)
        {
            notesIcons[40].image.sprite = noteIcon5;
        }
        else
        {
            notesIcons[40].image.sprite = noteDefaultIcon;
        }

        if (isNote42 == true)
        {
            notesIcons[41].image.sprite = noteIcon3;
        }
        else
        {
            notesIcons[41].image.sprite = noteDefaultIcon;
        }

        if (isNote43 == true)
        {
            notesIcons[42].image.sprite = noteIcon8;
        }
        else
        {
            notesIcons[42].image.sprite = noteDefaultIcon;
        }

        if (isNote44 == true)
        {
            notesIcons[43].image.sprite = noteIcon6;
        }
        else
        {
            notesIcons[43].image.sprite = noteDefaultIcon;
        }

        if (isNote45 == true)
        {
            notesIcons[44].image.sprite = noteIcon7;
        }
        else
        {
            notesIcons[44].image.sprite = noteDefaultIcon;
        }

        if (isNote46 == true)
        {
            notesIcons[45].image.sprite = noteIcon4;
        }
        else
        {
            notesIcons[45].image.sprite = noteDefaultIcon;
        }

        if (isNote47 == true)
        {
            notesIcons[46].image.sprite = noteIcon1;
        }
        else
        {
            notesIcons[46].image.sprite = noteDefaultIcon;
        }

        if (isNote48 == true)
        {
            notesIcons[47].image.sprite = noteIcon5;
        }
        else
        {
            notesIcons[47].image.sprite = noteDefaultIcon;
        }

        if (isNote49 == true)
        {
            notesIcons[48].image.sprite = noteIcon7;
        }
        else
        {
            notesIcons[48].image.sprite = noteDefaultIcon;
        }

        if (isNote50 == true)
        {
            notesIcons[49].image.sprite = noteIcon6;
        }
        else
        {
            notesIcons[49].image.sprite = noteDefaultIcon;
        }

        if (isNote51 == true)
        {
            notesIcons[50].image.sprite = noteIcon8;
        }
        else
        {
            notesIcons[50].image.sprite = noteDefaultIcon;
        }

        if (isNote52 == true)
        {
            notesIcons[51].image.sprite = noteIcon3;
        }
        else
        {
            notesIcons[51].image.sprite = noteDefaultIcon;
        }

        if (isNote53 == true)
        {
            notesIcons[52].image.sprite = noteIcon4;
        }
        else
        {
            notesIcons[52].image.sprite = noteDefaultIcon;
        }

        if (isNote54 == true)
        {
            notesIcons[53].image.sprite = noteIcon5;
        }
        else
        {
            notesIcons[53].image.sprite = noteDefaultIcon;
        }

    }

}
