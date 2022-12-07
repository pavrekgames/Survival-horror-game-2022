﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using TMPro;

public class Notes : MonoBehaviour {

    public bool isPlaySound = false; // wznawianie i zatrzymywanie dzwiekow
    public PlayerManager playerManagerScript;

    public AudioSource audioSource;
   
    public AudioClip notesSound;
	public bool isNotes = false;
	public Canvas[] notesCanvas;
	public Canvas[] notesCanvas2;
	public Canvas defaultNoteCanvas;
	public Button[] notesIcons;
	private Blur blurScript;
	private Menu gameMenuScript;
	private Inventory inventoryScript;
    //private Jezyk Language;
	private CrosshairGUI cursorScript;
	private Player playerScript;
	public Sprite noteIcon1;
	public Sprite noteIcon2;
	public Sprite noteIcon3;
	public Sprite noteIcon4;
	public Sprite noteIcon5;
	public Sprite noteIcon6;
	public Sprite noteIcon7;
	public Sprite noteIcon8;
	public Sprite noteDefaultIcon;
	public TextMeshProUGUI noteTitleTextMesh;
    public int notesCount = 0;

	private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;
 

	void OnEnable(){

		playerCam = Camera.main;

		notesCanvas = new Canvas[95];
		notesCanvas [0] = GameObject.Find ("CanvasNotatka1").GetComponent<Canvas> ();
		notesCanvas [1] = GameObject.Find ("CanvasNotatka2").GetComponent<Canvas> ();
		notesCanvas [2] = GameObject.Find ("CanvasNotatka3").GetComponent<Canvas> ();
		notesCanvas [3] = GameObject.Find ("CanvasNotatka4").GetComponent<Canvas> ();
		notesCanvas [4] = GameObject.Find ("CanvasNotatka5").GetComponent<Canvas> ();
		notesCanvas [5] = GameObject.Find ("CanvasNotatka6").GetComponent<Canvas> ();
		notesCanvas [6] = GameObject.Find ("CanvasNotatka7").GetComponent<Canvas> ();
		notesCanvas [7] = GameObject.Find ("CanvasNotatka8").GetComponent<Canvas> ();
		notesCanvas [8] = GameObject.Find ("CanvasNotatka9").GetComponent<Canvas> ();
		notesCanvas [9] = GameObject.Find ("CanvasNotatka10").GetComponent<Canvas> ();
		notesCanvas [10] = GameObject.Find ("CanvasNotatka11").GetComponent<Canvas> ();
		notesCanvas [11] = GameObject.Find ("CanvasNotatka12").GetComponent<Canvas> ();
		notesCanvas [12] = GameObject.Find ("CanvasNotatka13").GetComponent<Canvas> ();
		notesCanvas [13] = GameObject.Find ("CanvasNotatka14").GetComponent<Canvas> ();
		notesCanvas [14] = GameObject.Find ("CanvasNotatka15").GetComponent<Canvas> ();
		notesCanvas [15] = GameObject.Find ("CanvasNotatka16").GetComponent<Canvas> ();
		notesCanvas [16] = GameObject.Find ("CanvasNotatka17").GetComponent<Canvas> ();
		notesCanvas [17] = GameObject.Find ("CanvasNotatka18").GetComponent<Canvas> ();
		notesCanvas [18] = GameObject.Find ("CanvasNotatka19").GetComponent<Canvas> ();
		notesCanvas [19] = GameObject.Find ("CanvasNotatka20").GetComponent<Canvas> ();
		notesCanvas [20] = GameObject.Find ("CanvasNotatka21").GetComponent<Canvas> ();
		notesCanvas [21] = GameObject.Find ("CanvasNotatka22").GetComponent<Canvas> ();
		notesCanvas [22] = GameObject.Find ("CanvasNotatka23").GetComponent<Canvas> ();
		notesCanvas [23] = GameObject.Find ("CanvasNotatka24").GetComponent<Canvas> ();
		notesCanvas [24] = GameObject.Find ("CanvasNotatka25").GetComponent<Canvas> ();
		notesCanvas [25] = GameObject.Find ("CanvasNotatka26").GetComponent<Canvas> ();
		notesCanvas [26] = GameObject.Find ("CanvasNotatka27").GetComponent<Canvas> ();
		notesCanvas [27] = GameObject.Find ("CanvasNotatka28").GetComponent<Canvas> ();
		notesCanvas [28] = GameObject.Find ("CanvasNotatka29").GetComponent<Canvas> ();
		notesCanvas [29] = GameObject.Find ("CanvasNotatka30").GetComponent<Canvas> ();
		notesCanvas [30] = GameObject.Find ("CanvasNotatka31").GetComponent<Canvas> ();
		notesCanvas [31] = GameObject.Find ("CanvasNotatka32").GetComponent<Canvas> ();
		notesCanvas [32] = GameObject.Find ("CanvasNotatka33").GetComponent<Canvas> ();
		notesCanvas [33] = GameObject.Find ("CanvasNotatka34").GetComponent<Canvas> ();
		notesCanvas [34] = GameObject.Find ("CanvasNotatka35").GetComponent<Canvas> ();
		notesCanvas [35] = GameObject.Find ("CanvasNotatka36").GetComponent<Canvas> ();
		notesCanvas [36] = GameObject.Find ("CanvasNotatka37").GetComponent<Canvas> ();
		notesCanvas [37] = GameObject.Find ("CanvasNotatka38").GetComponent<Canvas> ();
		notesCanvas [38] = GameObject.Find ("CanvasNotatka39").GetComponent<Canvas> ();
		notesCanvas [39] = GameObject.Find ("CanvasNotatka40").GetComponent<Canvas> ();
		notesCanvas [40] = GameObject.Find ("CanvasNotatka41").GetComponent<Canvas> ();
		notesCanvas [41] = GameObject.Find ("CanvasNotatka42").GetComponent<Canvas> ();
		notesCanvas [42] = GameObject.Find ("CanvasNotatka43").GetComponent<Canvas> ();
		notesCanvas [43] = GameObject.Find ("CanvasNotatka44").GetComponent<Canvas> ();
		notesCanvas [44] = GameObject.Find ("CanvasNotatka45").GetComponent<Canvas> ();
		notesCanvas [45] = GameObject.Find ("CanvasNotatka46").GetComponent<Canvas> ();
		notesCanvas [46] = GameObject.Find ("CanvasNotatka47").GetComponent<Canvas> ();
		notesCanvas [47] = GameObject.Find ("CanvasNotatka48").GetComponent<Canvas> ();
		notesCanvas [48] = GameObject.Find ("CanvasNotatka49").GetComponent<Canvas> ();
		notesCanvas [49] = GameObject.Find ("CanvasNotatka50").GetComponent<Canvas> ();
		notesCanvas [50] = GameObject.Find ("CanvasNotatka51").GetComponent<Canvas> ();
		notesCanvas [51] = GameObject.Find ("CanvasNotatka52").GetComponent<Canvas> ();
		notesCanvas [52] = GameObject.Find ("CanvasNotatka53").GetComponent<Canvas> ();
		notesCanvas [53] = GameObject.Find ("CanvasNotatka54").GetComponent<Canvas> ();
		notesCanvas [54] = GameObject.Find ("CanvasNotatkaLisy").GetComponent<Canvas>();
		notesCanvas [55] = GameObject.Find ("CanvasZdjecieDrewno").GetComponent<Canvas>();
		notesCanvas [56] = GameObject.Find ("CanvasZdjecieZeno").GetComponent<Canvas>();
		notesCanvas [57] = GameObject.Find ("CanvasNotatkaZakupy").GetComponent<Canvas>();
		notesCanvas [58] = GameObject.Find ("CanvasNotatkaCytat1").GetComponent<Canvas>();
		notesCanvas [59] = GameObject.Find ("CanvasRysunekKukurydza").GetComponent<Canvas>();
		notesCanvas [60] = GameObject.Find ("CanvasNotatkaPotokLewy").GetComponent<Canvas>();
		notesCanvas [61] = GameObject.Find ("CanvasNotatkaGrzyby").GetComponent<Canvas>();
		notesCanvas [62] = GameObject.Find ("CanvasZdjeciePotok3").GetComponent<Canvas>();
		notesCanvas [63] = GameObject.Find ("CanvasZdjeciePotok2").GetComponent<Canvas>();
		notesCanvas [64] = GameObject.Find ("CanvasZdjeciePotok1").GetComponent<Canvas>();
		notesCanvas [65] = GameObject.Find ("CanvasRysunekSimon").GetComponent<Canvas>();
		notesCanvas [66] = GameObject.Find ("CanvasNotatkaRap").GetComponent<Canvas>();
		notesCanvas [67] = GameObject.Find ("CanvasZdjecieAmbona").GetComponent<Canvas>();
		notesCanvas [68] = GameObject.Find ("CanvasZdjecieStudnia").GetComponent<Canvas>();
		notesCanvas [69] = GameObject.Find ("CanvasNotatkaCytat2").GetComponent<Canvas>();
		notesCanvas [70] = GameObject.Find ("CanvasZdjeciePomnik").GetComponent<Canvas>();
		notesCanvas [71] = GameObject.Find ("CanvasNotatkaWynalazki").GetComponent<Canvas>();
		notesCanvas [72] = GameObject.Find ("CanvasZdjecieWarsztat").GetComponent<Canvas>();
		notesCanvas [73] = GameObject.Find ("CanvasNotatkaCiemny").GetComponent<Canvas>();
		notesCanvas [74] = GameObject.Find ("CanvasNotatkaZwierzeta").GetComponent<Canvas>();
		notesCanvas [75] = GameObject.Find ("CanvasNotatkaNoc").GetComponent<Canvas>();
		notesCanvas [76] = GameObject.Find ("CanvasZdjecieSzafa").GetComponent<Canvas>();
		notesCanvas [77] = GameObject.Find ("CanvasZdjecieSzopa").GetComponent<Canvas>();
		notesCanvas [78] = GameObject.Find ("CanvasZdjecieOboz").GetComponent<Canvas>();
		notesCanvas [79] = GameObject.Find ("CanvasNotatkaMary").GetComponent<Canvas>();
		notesCanvas [80] = GameObject.Find ("CanvasRysunekCorki").GetComponent<Canvas>();
		notesCanvas [81] = GameObject.Find ("CanvasNotatkaDyplom").GetComponent<Canvas>();
		notesCanvas [82] = GameObject.Find ("CanvasRysunekTom").GetComponent<Canvas>();
		notesCanvas [83] = GameObject.Find ("CanvasNotatkaCytat3").GetComponent<Canvas>();
		notesCanvas [84] = GameObject.Find ("CanvasRysunekPotwor").GetComponent<Canvas>();
		notesCanvas [85] = GameObject.Find ("CanvasNotatkaSzepty").GetComponent<Canvas>();
		notesCanvas [86] = GameObject.Find ("CanvasNotatkaCytat4").GetComponent<Canvas>();
		notesCanvas [87] = GameObject.Find ("CanvasRysunekRosliny").GetComponent<Canvas>();
		notesCanvas [88] = GameObject.Find ("CanvasNotatkaPole").GetComponent<Canvas>();
		notesCanvas [89] = GameObject.Find ("CanvasNotatkaArena").GetComponent<Canvas>();
		notesCanvas [90] = GameObject.Find ("CanvasNotatkaCytat5").GetComponent<Canvas>();
		notesCanvas [91] = GameObject.Find ("CanvasZdjeciePotok4").GetComponent<Canvas>();
		notesCanvas [92] = GameObject.Find ("CanvasNotatkaKosmici").GetComponent<Canvas>();
		notesCanvas [93] = GameObject.Find ("CanvasNotatkaCytat6").GetComponent<Canvas>();
		notesCanvas [94] = GameObject.Find ("CanvasNotatkaDemona").GetComponent<Canvas>();

		notesCanvas2 = new Canvas[54];
		notesCanvas2 [0] = GameObject.Find ("CanvasListaNotatek_1").GetComponent<Canvas> ();
		notesCanvas2 [1] = GameObject.Find ("CanvasListaNotatek_2").GetComponent<Canvas> ();
		notesCanvas2 [2] = GameObject.Find ("CanvasListaNotatek_3").GetComponent<Canvas> ();
		notesCanvas2 [3] = GameObject.Find ("CanvasListaNotatek_4").GetComponent<Canvas> ();
		notesCanvas2 [4] = GameObject.Find ("CanvasListaNotatek_5").GetComponent<Canvas> ();
		notesCanvas2 [5] = GameObject.Find ("CanvasListaNotatek_6").GetComponent<Canvas> ();
		notesCanvas2 [6] = GameObject.Find ("CanvasListaNotatek_7").GetComponent<Canvas> ();
		notesCanvas2 [7] = GameObject.Find ("CanvasListaNotatek_8").GetComponent<Canvas> ();
		notesCanvas2 [8] = GameObject.Find ("CanvasListaNotatek_9").GetComponent<Canvas> ();
		notesCanvas2 [9] = GameObject.Find ("CanvasListaNotatek_10").GetComponent<Canvas> ();
		notesCanvas2 [10] = GameObject.Find ("CanvasListaNotatek_11").GetComponent<Canvas> ();
		notesCanvas2 [11] = GameObject.Find ("CanvasListaNotatek_12").GetComponent<Canvas> ();
		notesCanvas2 [12] = GameObject.Find ("CanvasListaNotatek_13").GetComponent<Canvas> ();
		notesCanvas2 [13] = GameObject.Find ("CanvasListaNotatek_14").GetComponent<Canvas> ();
		notesCanvas2 [14] = GameObject.Find ("CanvasListaNotatek_15").GetComponent<Canvas> ();
		notesCanvas2 [15] = GameObject.Find ("CanvasListaNotatek_16").GetComponent<Canvas> ();
		notesCanvas2 [16] = GameObject.Find ("CanvasListaNotatek_17").GetComponent<Canvas> ();
		notesCanvas2 [17] = GameObject.Find ("CanvasListaNotatek_18").GetComponent<Canvas> ();
		notesCanvas2 [18] = GameObject.Find ("CanvasListaNotatek_19").GetComponent<Canvas> ();
		notesCanvas2 [19] = GameObject.Find ("CanvasListaNotatek_20").GetComponent<Canvas> ();
		notesCanvas2 [20] = GameObject.Find ("CanvasListaNotatek_21").GetComponent<Canvas> ();
		notesCanvas2 [21] = GameObject.Find ("CanvasListaNotatek_22").GetComponent<Canvas> ();
		notesCanvas2 [22] = GameObject.Find ("CanvasListaNotatek_23").GetComponent<Canvas> ();
		notesCanvas2 [23] = GameObject.Find ("CanvasListaNotatek_24").GetComponent<Canvas> ();
		notesCanvas2 [24] = GameObject.Find ("CanvasListaNotatek_25").GetComponent<Canvas> ();
		notesCanvas2 [25] = GameObject.Find ("CanvasListaNotatek_26").GetComponent<Canvas> ();
		notesCanvas2 [26] = GameObject.Find ("CanvasListaNotatek_27").GetComponent<Canvas> ();
		notesCanvas2 [27] = GameObject.Find ("CanvasListaNotatek_28").GetComponent<Canvas> ();
		notesCanvas2 [28] = GameObject.Find ("CanvasListaNotatek_29").GetComponent<Canvas> ();
		notesCanvas2 [29] = GameObject.Find ("CanvasListaNotatek_30").GetComponent<Canvas> ();
		notesCanvas2 [30] = GameObject.Find ("CanvasListaNotatek_31").GetComponent<Canvas> ();
		notesCanvas2 [31] = GameObject.Find ("CanvasListaNotatek_32").GetComponent<Canvas> ();
		notesCanvas2 [32] = GameObject.Find ("CanvasListaNotatek_33").GetComponent<Canvas> ();
		notesCanvas2 [33] = GameObject.Find ("CanvasListaNotatek_34").GetComponent<Canvas> ();
		notesCanvas2 [34] = GameObject.Find ("CanvasListaNotatek_35").GetComponent<Canvas> ();
		notesCanvas2 [35] = GameObject.Find ("CanvasListaNotatek_36").GetComponent<Canvas> ();
		notesCanvas2 [36] = GameObject.Find ("CanvasListaNotatek_37").GetComponent<Canvas> ();
		notesCanvas2 [37] = GameObject.Find ("CanvasListaNotatek_38").GetComponent<Canvas> ();
		notesCanvas2 [38] = GameObject.Find ("CanvasListaNotatek_39").GetComponent<Canvas> ();
		notesCanvas2 [39] = GameObject.Find ("CanvasListaNotatek_40").GetComponent<Canvas> ();
		notesCanvas2 [40] = GameObject.Find ("CanvasListaNotatek_41").GetComponent<Canvas> ();
		notesCanvas2 [41] = GameObject.Find ("CanvasListaNotatek_42").GetComponent<Canvas> ();
		notesCanvas2 [42] = GameObject.Find ("CanvasListaNotatek_43").GetComponent<Canvas> ();
		notesCanvas2 [43] = GameObject.Find ("CanvasListaNotatek_44").GetComponent<Canvas> ();
		notesCanvas2 [44] = GameObject.Find ("CanvasListaNotatek_45").GetComponent<Canvas> ();
		notesCanvas2 [45] = GameObject.Find ("CanvasListaNotatek_46").GetComponent<Canvas> ();
		notesCanvas2 [46] = GameObject.Find ("CanvasListaNotatek_47").GetComponent<Canvas> ();
		notesCanvas2 [47] = GameObject.Find ("CanvasListaNotatek_48").GetComponent<Canvas> ();
		notesCanvas2 [48] = GameObject.Find ("CanvasListaNotatek_49").GetComponent<Canvas> ();
		notesCanvas2 [49] = GameObject.Find ("CanvasListaNotatek_50").GetComponent<Canvas> ();
		notesCanvas2 [50] = GameObject.Find ("CanvasListaNotatek_51").GetComponent<Canvas> ();
		notesCanvas2 [51] = GameObject.Find ("CanvasListaNotatek_52").GetComponent<Canvas> ();
		notesCanvas2 [52] = GameObject.Find ("CanvasListaNotatek_53").GetComponent<Canvas> ();
		notesCanvas2 [53] = GameObject.Find ("CanvasListaNotatek_54").GetComponent<Canvas> ();

		notesIcons = new Button[54];
		notesIcons [0] = GameObject.Find ("Notatka1").GetComponent<Button> ();
		notesIcons [1] = GameObject.Find ("Notatka2").GetComponent<Button> ();
		notesIcons [2] = GameObject.Find ("Notatka3").GetComponent<Button> ();
		notesIcons [3] = GameObject.Find ("Notatka4").GetComponent<Button> ();
		notesIcons [4] = GameObject.Find ("Notatka5").GetComponent<Button> ();
		notesIcons [5] = GameObject.Find ("Notatka6").GetComponent<Button> ();
		notesIcons [6] = GameObject.Find ("Notatka7").GetComponent<Button> ();
		notesIcons [7] = GameObject.Find ("Notatka8").GetComponent<Button> ();
		notesIcons [8] = GameObject.Find ("Notatka9").GetComponent<Button> ();
		notesIcons [9] = GameObject.Find ("Notatka10").GetComponent<Button> ();
		notesIcons [10] = GameObject.Find ("Notatka11").GetComponent<Button> ();
		notesIcons [11] = GameObject.Find ("Notatka12").GetComponent<Button> ();
		notesIcons [12] = GameObject.Find ("Notatka13").GetComponent<Button> ();
		notesIcons [13] = GameObject.Find ("Notatka14").GetComponent<Button> ();
		notesIcons [14] = GameObject.Find ("Notatka15").GetComponent<Button> ();
		notesIcons [15] = GameObject.Find ("Notatka16").GetComponent<Button> ();
		notesIcons [16] = GameObject.Find ("Notatka17").GetComponent<Button> ();
		notesIcons [17] = GameObject.Find ("Notatka18").GetComponent<Button> ();
		notesIcons [18] = GameObject.Find ("Notatka19").GetComponent<Button> ();
		notesIcons [19] = GameObject.Find ("Notatka20").GetComponent<Button> ();
		notesIcons [20] = GameObject.Find ("Notatka21").GetComponent<Button> ();
		notesIcons [21] = GameObject.Find ("Notatka22").GetComponent<Button> ();
		notesIcons [22] = GameObject.Find ("Notatka23").GetComponent<Button> ();
		notesIcons [23] = GameObject.Find ("Notatka24").GetComponent<Button> ();
		notesIcons [24] = GameObject.Find ("Notatka25").GetComponent<Button> ();
		notesIcons [25] = GameObject.Find ("Notatka26").GetComponent<Button> ();
		notesIcons [26] = GameObject.Find ("Notatka27").GetComponent<Button> ();
		notesIcons [27] = GameObject.Find ("Notatka28").GetComponent<Button> ();
		notesIcons [28] = GameObject.Find ("Notatka29").GetComponent<Button> ();
		notesIcons [29] = GameObject.Find ("Notatka30").GetComponent<Button> ();
		notesIcons [30] = GameObject.Find ("Notatka31").GetComponent<Button> ();
		notesIcons [31] = GameObject.Find ("Notatka32").GetComponent<Button> ();
		notesIcons [32] = GameObject.Find ("Notatka33").GetComponent<Button> ();
		notesIcons [33] = GameObject.Find ("Notatka34").GetComponent<Button> ();
		notesIcons [34] = GameObject.Find ("Notatka35").GetComponent<Button> ();
		notesIcons [35] = GameObject.Find ("Notatka36").GetComponent<Button> ();
		notesIcons [36] = GameObject.Find ("Notatka37").GetComponent<Button> ();
		notesIcons [37] = GameObject.Find ("Notatka38").GetComponent<Button> ();
		notesIcons [38] = GameObject.Find ("Notatka39").GetComponent<Button> ();
		notesIcons [39] = GameObject.Find ("Notatka40").GetComponent<Button> ();
		notesIcons [40] = GameObject.Find ("Notatka41").GetComponent<Button> ();
		notesIcons [41] = GameObject.Find ("Notatka42").GetComponent<Button> ();
		notesIcons [42] = GameObject.Find ("Notatka43").GetComponent<Button> ();
		notesIcons [43] = GameObject.Find ("Notatka44").GetComponent<Button> ();
		notesIcons [44] = GameObject.Find ("Notatka45").GetComponent<Button> ();
		notesIcons [45] = GameObject.Find ("Notatka46").GetComponent<Button> ();
		notesIcons [46] = GameObject.Find ("Notatka47").GetComponent<Button> ();
		notesIcons [47] = GameObject.Find ("Notatka48").GetComponent<Button> ();
		notesIcons [48] = GameObject.Find ("Notatka49").GetComponent<Button> ();
		notesIcons [49] = GameObject.Find ("Notatka50").GetComponent<Button> ();
		notesIcons [50] = GameObject.Find ("Notatka51").GetComponent<Button> ();
		notesIcons [51] = GameObject.Find ("Notatka52").GetComponent<Button> ();
		notesIcons [52] = GameObject.Find ("Notatka53").GetComponent<Button> ();
		notesIcons [53] = GameObject.Find ("Notatka54").GetComponent<Button> ();

		blurScript = GameObject.Find ("Kamera").GetComponent<Blur> ();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
		inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();
		cursorScript = GameObject.Find ("Kamera").GetComponent<CrosshairGUI> ();
		playerScript = GameObject.Find ("Player").GetComponent<Player> ();

		audioSource = GameObject.Find ("ZrodloPrzedmiotPause_s").GetComponent<AudioSource> ();
		//DzwNotatki = Resources.Load<AudioClip>("Muzyka/Notatka");
		defaultNoteCanvas = GameObject.Find ("CanvasNotatkaDefault").GetComponent<Canvas> ();
	
		noteTitleTextMesh = GameObject.Find ("TytulNotatki").GetComponent<TextMeshProUGUI> ();


}

	void Update () {

		// Zbieranie notatek

		if (Input.GetMouseButtonDown (0) && isNotes == false && playerManagerScript.isPlayerCanInput == true) {

			Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)) {
					
				if (hit.collider.gameObject.tag == "Note") {
                    hit.transform.gameObject.GetComponent<Note>().PickUpNote();
				}

			} 
		} 

		else if ((Input.GetMouseButtonDown (0)) && isNotes == true && notesCanvas.Length > 0 && gameMenuScript.isMenu == false && Time.timeScale == 0) { 

            HideNote();

		}

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isPlaySound == false)
        {

           

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && isPlaySound == true)
        {

           

            isPlaySound = false;
        }

    } // klamra do update

    // Wylacz notatki

    public void HideNote()
    {

        Time.timeScale = 1;
        blurScript.enabled = false;
        isNotes = false;
        Cursor.visible = true;
        cursorScript.enabled = true;
        playerScript.enabled = true;

        for (int i = 0; i < notesCanvas.Length; i++)
        {
            notesCanvas[i].enabled = false;
        }

        for (int i = 0; i < notesCanvas2.Length; i++)
        {
            notesCanvas2[i].enabled = false;
        }
    }

    public void ReadNote(Canvas noteCanvas)
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(notesSound);
        noteCanvas.enabled = true;
        isNotes = true;
        blurScript.enabled = true;
        Cursor.visible = false;
        cursorScript.m_ShowCursor = false;
        Time.timeScale = 0;
        playerScript.enabled = false;
        notesCount++;
    }

}

