using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using TMPro;

public class VoiceActing : MonoBehaviour {

	public AudioSource playerAudioSource1;
	public AudioSource playerAudioSource2;
	public AudioSource playerAudioSource3;
	public AudioSource playerAudioSource4;
	public AudioSource retrospectionAudioSource;
    public AudioSource chipAudioSource;
    private Transform player;
    private Tasks tasksScript;
    private Notes notesScript;
	private Inventory inventoryScript;
	private Crouch crouchScript;
	private Map mapScript;
	private Flashlight flashlightScript;
	private TextMeshProUGUI subtitlesTextMesh;
	private TextMeshProUGUI beginSubtitlesTextMesh;
	private Menu gameMenuScript;
    private Music musicScript;
    private Player playerScript;
    private Screamer screamerScript;
    private Jumpscare jumpscareScript;
    private TaskBooks taskBooksScript;
    private RandomJumpscare randomJumpscareScript;
    private Health healthScript;
    public Canvas uiCanvas;
	public bool isGameBegin = false;

	public AudioClip beginGameRecording;
    public AudioClip fenceRecording;
    public AudioClip houseLightRecording;
    public AudioClip kitchenRecording;
    public AudioClip bigRoomRecording;
    public AudioClip arthurRoomRecording;
    public AudioClip toolShedRecording;
    public AudioClip aliceHouseRecording;
	public AudioClip hallunsRecording;
    public AudioClip workshopRecording;
    public AudioClip leftBrookRecording;
    public AudioClip annaNoteRecording;
    public AudioClip pliersRecording;
    public AudioClip cornfieldRecording;
    public AudioClip oldShedRecording;
    public AudioClip axeRecording;
    public AudioClip afterCasseteRecording;
    public AudioClip booksRecording;
    public AudioClip ravineRecording;
    public AudioClip stevenHouseRecording;
    public AudioClip acidRecording;
    public AudioClip stevenShedRecording;
    public AudioClip devilsBrookRecording;
    public AudioClip devilsShelterRecording;

    // dodatkowe

    public AudioClip woodRecording;
    public AudioClip wellRecording;
    public AudioClip stableRecording;
    public AudioClip gardenRecording;
    public AudioClip secretRoomRecording;
    public AudioClip inventionRecording;
    public AudioClip wardrobeCorridorRecording;
    public AudioClip chipRecording;
    public AudioClip arthurTipRecording;
    public AudioClip monstersPlantsRecording;
    public AudioClip zenoRecording;

    public bool isBeginGameRecording = false;
    public bool isFenceRecording = false;
    public bool isHouseLightRecording = false;
    public bool isKitchenRecording = false;
    public bool isBigRoomRecording = false;
    public bool isArthurRoomRecording = false;
    public bool isToolShedRecording = false;
    public bool isAliceHouseRecording = false;
	public bool isHallunsRecording = false;
    public bool isWorkshopRecording = false;
    public bool isLeftBrookRecording = false;
    public bool isAnnaNoteRecording = false;
    public bool isPliersRecording = false;
    public bool isCornfieldRecording = false;
    public bool isOldShedRecording = false;
    public bool isAxeRecording = false;
    public bool isAfterCasseteRecording = false;
    public bool isBooksRecording = false;
    public bool isRavineRecording = false;
    public bool isStevenHouseRecording = false;
    public bool isAcidRecording = false;
    public bool isStevenShedRecording = false;
    public bool isDevilsBrookRecording = false;
    public bool isDevilsShelterRecording = false;

    public bool isWoodRecording = false;
    public bool isWellRecording = false;
    public bool isStableRecording = false;
    public bool isGardenRecording = false;
    public bool isSecretRoomRecording = false;
    public bool isInventionRecording = false;
    public bool isWardrobeCorridorRecording = false;
    public bool isChipRecording = false;
    public bool isArthurTipRecording = false;
    public bool isMonstersPlantsRecording = false;
    public bool isZenoRecording = false;

    public bool isRetroBigRoomRecording = false;
    public bool isRetroArthurRoomRecording = false;
    public bool isRetroToolShedRecording = false;
    public bool isRetroAliceHouseRecording = false;
    public bool isRetroWorkshopRecording = false;
    public bool isRetroCornfieldRecording = false;
    public bool isRetroOldShedRecording = false;
    public bool isRetroBooksRecording = false;
    public bool isRetroStevenHouseRecording = false;
    public bool isRetroStevenShedRecording = false;

    // Do retrospekcji

    public ScreenOverlay retroEffectScript;  
    public bool isStartRetro = false;
    public bool isMidRetro = false;
    public bool isEndRetro = false;
    public bool isResetRetro = false;

    // napisy 

    public bool isBeginGameSubtitles = false;
	public string beginGameSubtitles1 = "<color=#91D4FFFF>Gabriel:</color> Hi grandma… I’m sorry that I’m calling so late.";
	public string beginGameSubtitles2 = "<color=#91D4FFFF>Gabriel:</color> I didn’t manage to catch the bus and I had to wait for the next one.";
	public string beginGameSubtitles3 = "<color=#91D4FFFF>Gabriel:</color> Don’t worry, I’ll be there in a few minutes!...";
	public string beginGameSubtitles4 = "<color=#91D4FFFF>Gabriel:</color> Ok, I have to go. My battery is dying. See you soon!";

	public bool isFenceSubtitles = false;
	public string fenceSubtitles = "<color=#91D4FFFF>Gabriel:</color> Hmm, I didn’t know this fence was here. All right, now I just have to get through the forest.";

	public bool isHouseLightSubtitles = false;
	public string houseLightSubtitles = "<color=#91D4FFFF>Gabriel:</color> Alright, I’m almost there.";

	public bool isKitchenSubtitles = false;
	public string kitchenSubtitles = "<color=#91D4FFFF>Gabriel:</color> Hello, is anybody here…? It’s me Gabriel. I’m back. Hello?  Grandma? Uncle Edward?";

	public bool isBigRoomSubtitles = false;
	public string bigRoomSubtitles1 = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> It’s almost done. Flowers are watered, kitchen is clean. Oh!.. I almost forgot about plates.</color>";
	public string bigRoomSubtitles2 = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> One for Gabriel, one for Edward, one for Arthur and one for me.</color>";
	public string bigRoomSubtitles3 = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> What a pity, that Zeno is no longer with us… really sad.</color>";

	public bool isArthurRoomSubtitles = false;
	public string arthurRoomSubtitles1 = "<color=#524CFFFF>Arthur:</color><color=#FF6565FF> It’s amazing! This wildlife, the forest, but it… It’s really sharp.</color>";
	public string arthurRoomSubtitles2 = "<color=#524CFFFF>Arthur:</color><color=#FF6565FF> Everything what he wrote is true. They can’t find out about it.</color>";

	public bool isToolShedSubtitles = false;
	public string toolShedSubtitles1 = "<color=#524CFFFF>Edward:</color><color=#FF6565FF> I've said so many times not to take my tools without asking.</color>";
	public string toolShedSubtitles2 = "<color=#524CFFFF>Edward:</color><color=#FF6565FF> They drive me crazy! Where is my axe ? Where is my pliers? Even my keys will be locked up now!</color>";

	public bool isCassete1Subtitles = false;
	public string cassete1Subtitles1 = "<color=#91D4FFFF>Arthur:</color> Ok, the last board’s nailed… Quickly we don’t have much time, he can come back in a minute now… all of them.";
	public string cassete1Subtitles2 = "<color=#91D4FFFF>Arthur:</color> Anna run to Alice, It's the easiest way. You will be safe there. Me and Edward…";

	public bool isAliceHouseSubtitles = false;
	public string aliceHouseSubtitles1 = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> Hi Alice! You won’t believe me what’s happened. All my hens have disappeared.</color>";
	public string aliceHouseSubtitles2 = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> I don’t know if they were eaten by hawks or foxes? or they escaped somehow.</color>";
	public string aliceHouseSubtitles3 = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> And what about your animals, I know that they are really precious for Victor.</color>";
	public string aliceHouseSubtitles4 = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> Oh… and I‘ve just seen your son Simon. I got a bit scared because he had strange eyes.</color>";

	public bool isHallunsSubtitles = false;
	public string hallunsSubtitles = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> Gabriel, you have to find us. We don’t want to die! Do it Gabriel! Find us! Find us!</color>";

	public bool isWorkshopSubtitles = false;
	public string workshopSubtitles1 = "<color=#524CFFFF>Edward:</color><color=#FF6565FF> Didn’t you think Victor that you can’t meet any foxes lately.</color>";
	public string workshopSubtitles2 = "<color=#524CFFFF>Edward:</color><color=#FF6565FF> Neighbours say that foxes eat their hens, but they aren’t there.</color>";
	public string workshopSubtitles3 = "<color=#524CFFFF>Edward:</color><color=#FF6565FF> Oh! and here are the pliers which I have borrowed from you. All my things are disappearing lately.</color>";

	public bool isLeftBrookSubtitles = false;
	public string leftBrookSubtitles = "<color=#91D4FFFF>Gabriel:</color> Alright, looks I’m headed in the right direction.";

	public bool isAnnaNoteSubtitles = false;
	public string annaNoteSubtitles = "<color=#91D4FFFF>Gabriel:</color> So my grandma escaped to Arthur, but where…";

	public bool isPliersSubtitles = false;
	public string pliersSubtitles = "<color=#91D4FFFF>Gabriel:</color> I know where I can use these.";

	public bool isCornfieldSubtitles = false;
	public string cornfieldSubtitles1 = "<color=#524CFFFF>Arthur:</color><color=#FF6565FF> Damn it! However, the weeds haven’t disappeared. But I threw them in there…</color>";
	public string cornfieldSubtitles2 = "<color=#524CFFFF>Arthur:</color><color=#FF6565FF> Hmm, apparently what is written in the book is true.</color>";

	public bool isAxeSubtitles = false;
	public string axeSubtitles = "<color=#91D4FFFF>Gabriel:</color> I needed this.";

	public bool isOldShedSubtitles = false;
	public string oldShedSubtitles = "<color=#524CFFFF>Gabriel:</color><color=#FF6565FF> I don’t want to go to this shed, grandma. I’m scared. Grandpa told me that monsters live here.</color>";

	public bool isCassete2Subtitles = false;
	public string cassete2Subtitles1 = "<color=#91D4FFFF>Edward:</color> Stop! This way! Quickly! Jump… Anna probably succeeded.";
	public string cassete2Subtitles2 = "<color=#91D4FFFF>Edward:</color> Ok Arthur run to Tom. I’m sure he will help us.";
	public string cassete2Subtitles3 = "<color=#91D4FFFF>Edward:</color> I will hide in the alcoholic’s house…  It will be fine.";

	public bool isAfterCasseteSubtitles = false;
	public string afterCasseteSubtitles = "<color=#91D4FFFF>Gabriel:</color> Tom lives behind the west brook. I’ll have to follow the trail.";

	public bool isBooksSubtitles = false;
	public string booksSubtitles1 = "<color=#524CFFFF>Arthur:</color><color=#FF6565FF> Oh! You have a large collection of books. I also have a lot of them.</color>";
	public string booksSubtitles2 = "<color=#524CFFFF>Arthur:</color><color=#FF6565FF> You know how I like wildlife, science… secrets hehe…</color>";
	public string booksSubtitles3 = "<color=#524CFFFF>Arthur:</color><color=#FF6565FF> Recently I have read about a rare blue mushroom.</color>";
	public string booksSubtitles4 = "<color=#524CFFFF>Arthur:</color><color=#FF6565FF> I even placed several ingredients in Edward's forest, but without any effects…</color>";

	public bool isCassete3Subtitles = false;
	public string cassete3Subtitles1 = "<color=#91D4FFFF>Arthur:</color> Damn it! I knew it wouldn’t work, but Tom thought opposite.";
	public string cassete3Subtitles2 = "<color=#91D4FFFF>Arthur:</color> I don’t know where they are now. I have hidden on his corn field, but I’m just running out from here.";
	public string cassete3Subtitles3 = "<color=#91D4FFFF>Arthur:</color> He knows I’m here and he will want to get me.";
	public string cassete3Subtitles4 = "<color=#91D4FFFF>Arthur:</color> If you listen to this, follow the ravine to the north of the brook ... and find me…";

	public bool isRavineSubtitles = false;
	public string ravineSubtitles = "<color=#91D4FFFF>Gabriel:</color> It’s the ravine Uncle Arthur spoke about. Just hang on a bit longer.";

	public bool isCassete4Subtitles = false;
	public string cassete4Subtitles1 = "<color=#91D4FFFF>Arthur:</color> I don’t know what to do. I thought it would be safe here, but these monsters are getting closer.";
	public string cassete4Subtitles2 = "<color=#91D4FFFF>Arthur:</color> Soon they will be able to catch me. I have to escape. The nearest shelter is Steven's house.";
	public string cassete4Subtitles3 = "<color=#91D4FFFF>Arthur:</color> I don’t know where Anna and Edward are, but I hope they are fine.";

	public bool isStevenHouseSubtitles = false;
	public string stevenHouseSubtitles1 = "<color=#524CFFFF>Edward:</color><color=#FF6565FF> Well,since you have your own lab here, don’t come to me for beer. It will be the best, if you end with this shit.</color>";
	public string stevenHouseSubtitles2 = "<color=#524CFFFF>Edward:</color><color=#FF6565FF> You overreacted yesterday when you insulted my father.</color>";
	public string stevenHouseSubtitles3 = "<color=#524CFFFF>Edward:</color><color=#FF6565FF> He is dead… remember about it… A little respect.</color>";

	public bool isAcidSubtitles = false;
	public string acidSubtitles = "<color=#91D4FFFF>Gabriel:</color> This big shed. There still must be some information lying around.";

	public bool isStevenShedSubtitles = false;
	public string stevenShedSubtitles1 = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> I found you here, Steven. I heard what you said today about my father.</color>";
	public string stevenShedSubtitles2 = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> You should be ashamed, you don’t even know how much he did for us when we our mother passed away!</color>";
	public string stevenShedSubtitles3 = "<color=#524CFFFF>Anna:</color><color=#FF6565FF> He is still with us, I threw his ashes into our corn field. He is still with us…</color>";

	public bool isDevilsBrookSubtitles = false;
	public string devilsBrookSubtitles = "<color=#91D4FFFF>Gabriel:</color> The scientist lives behind this brook. This is my last hope.";

	public bool isCassete5Subtitles = false;
	public string cassete5Subtitles1 = "<color=#91D4FFFF>Scientist:</color> I've never seen anything like this before. Mutated plants that cut your body like a thread.";
	public string cassete5Subtitles2 = "<color=#91D4FFFF>Scientist:</color> They make sounds as if the souls didn’t want to last in eternity. And… these monsters, devils whatever it is.";
	public string cassete5Subtitles3 = "<color=#91D4FFFF>Scientist:</color> If you are brave, head east until you reach the brook. Watch out for spikes my friend.";
	public string cassete5Subtitles4 = "<color=#91D4FFFF>Scientist:</color> I won’t tell you where their hideout is, I want to forget about it.";

	public bool isDevilsShelterSubtitles = false;
	public string devilsShelterSubtitles = "<color=#91D4FFFF>Gabriel:</color> Shit! I didn’t make it. No, no, no, no! This can’t be happening! I’m begging you… please!";

    // dodatkowe

    public bool isWoodSubtitles = false;
    public string woodSubtitles = "<color=#91D4FFFF>Gabriel:</color> This is where uncle Arthur was working. I have to find the key.";

    public bool isWellSubtitles = false;
    public string wellSubtitles = "<color=#91D4FFFF>Gabriel:</color> These are the wells uncle Edward wrote about.";

    public bool isStableSubtitles = false;
    public string stableSubtitles = "<color=#91D4FFFF>Gabriel:</color> Who was that? Hey! Is somebody here?";

    public bool isGardenSubtitles = false;
    public string gardenSubtitles = "<color=#91D4FFFF>Gabriel:</color> Please tell me that was only the foxes...";

    public bool isSecretRoomSubtitles = false;
    public string secretRoomSubtitles1 = "<color=#91D4FFFF>Gabriel:</color> I don’t have the right items to investigate everything here.";
    public string secretRoomSubtitles2 = "<color=#91D4FFFF>Gabriel:</color> Maybe, at Alice’s farm, I will find what I’m looking for.";

    public bool isInventionSubtitles = false;
    public string inventionSubtitles = "<color=#91D4FFFF>Gabriel:</color> The Victor’s invention should work. I have to try fixing the key now.";

    public bool isWardrobeCorridorSubtitles = false;
    public string wardrobeCorridorSubtitles = "<color=#91D4FFFF>Gabriel:</color> I recognize this key. I’m sure it opens the door to the wardrobe in the corridor.";

    public bool isChipSubtitles = false;
    public string chipSubtitles = "<color=#91D4FFFF>Gabriel:</color> The books are in the right spots. I can take the chip now.";

    public bool isArthurTipSubtitles = false;
    public string arthurTipSubtitles = "<color=#91D4FFFF>Gabriel:</color> Uncle Arthur gave me clues. I hope, thanks to this, I’ll be able to find them.";

    public bool isMonstersPlantsSubtitles = false;
    public string monstersPlantsSubtitles = "<color=#91D4FFFF>Gabriel:</color> The big tree in the brook looked like a—a human. Damn it. It must have been Victor.";

    public bool isZenoSubtitles = false;
    public string zenoSubtitles = "<color=#91D4FFFF>Gabriel:</color> So the monster that was chasing me was a Zeno, but how? Why?";



    // Zakonczenie gry

    private Transform playerCamera;
	public AudioSource monsterAudioSource;
	public AudioClip monsterSound;
	public AudioClip deadSound;
	public bool isEndGame = false;
	public bool isMonster = false;
	public bool isDead = false;
	public AudioClip whisperSound;
	public bool isWhisper = false;
	private Canvas blackScreenCanvas;
	private Transform staticMonsterShelter1;
	private Transform staticMonsterShelter2;
	private Transform shelterMainMonster;
	private Transform corpse;
	private AudioSource deadAudioSource;
	private AudioSource whisperAudioSource;

    void OnEnable () {

		subtitlesTextMesh = GameObject.Find("NapisyNagrania").GetComponent<TextMeshProUGUI>();
		beginSubtitlesTextMesh = GameObject.Find("NapisyNagraniaPoczatek").GetComponent<TextMeshProUGUI>();
		gameMenuScript = GameObject.Find("CanvasMenu").GetComponent<Menu>();
		tasksScript = GameObject.Find("Player").GetComponent<Tasks>();
		inventoryScript = GameObject.Find("Player").GetComponent<Inventory>();
		notesScript = GameObject.Find("Player").GetComponent<Notes>();
		retroEffectScript = GameObject.Find("Kamera").GetComponent<ScreenOverlay>();
		player = GameObject.Find ("Player").transform;
		crouchScript = GameObject.Find ("Player").GetComponent<Crouch> ();
		mapScript = GameObject.Find ("Player").GetComponent<Map> ();
		flashlightScript = GameObject.Find ("Latarka").GetComponent<Flashlight> ();
        musicScript = GameObject.Find("Player").GetComponent<Music>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        screamerScript = GameObject.Find("Player").GetComponent<Screamer>();
        jumpscareScript = GameObject.Find("Player").GetComponent<Jumpscare>();
        taskBooksScript = GameObject.Find("Player").GetComponent<TaskBooks>();
        randomJumpscareScript = GameObject.Find("Player").GetComponent<RandomJumpscare>();
        healthScript = GameObject.Find("Player").GetComponent<Health>();

        playerAudioSource1 = GameObject.Find("MuzykaGlosBohatera").GetComponent<AudioSource>(); // srednie
		playerAudioSource2 = GameObject.Find("MuzykaGlosBohatera2").GetComponent<AudioSource>(); // Retrospekcja
		playerAudioSource3 = GameObject.Find("MuzykaGlosBohatera3").GetComponent<AudioSource>(); // Ciernie
		playerAudioSource4 = GameObject.Find("MuzykaGlosBohatera4").GetComponent<AudioSource>(); // klucze
		retrospectionAudioSource = GameObject.Find("MuzykaRetrospekcja").GetComponent<AudioSource>();
        chipAudioSource = GameObject.Find("Chip_s").GetComponent<AudioSource>();


        //ZrodloDzwiekuB2.PlayOneShot (DzwGlosPoczatek);

        playerCamera = GameObject.Find ("Kamera").transform;
		//DzwPotwor = Resources.Load<AudioClip>("Muzyka/Monster_v7L");
		//DzwSmierc = Resources.Load<AudioClip>("Muzyka/GraczSmierc_v2");
		//DzwSzepty = Resources.Load<AudioClip>("Muzyka/Szepty3");
		blackScreenCanvas = GameObject.Find("CanvasCzynnoscSiekiera").GetComponent<Canvas>();
		corpse = GameObject.Find ("RodzinaTrup").transform;
		staticMonsterShelter1 = GameObject.Find ("MonsterKryjowkaStatic").transform;
		staticMonsterShelter2 = GameObject.Find ("MonsterKryjowkaStatic2").transform;
		shelterMainMonster = GameObject.Find ("MonsterKryjowkaGlowny").transform;
		monsterAudioSource = GameObject.Find ("MonsterKryjowkaCialo").GetComponent<AudioSource>();
		deadAudioSource = GameObject.Find ("ZrodloPrzedmiot4_s").GetComponent<AudioSource> ();
		whisperAudioSource = GameObject.Find ("ZrodloMapa_s").GetComponent<AudioSource> ();
	}
	

	void Update () {



		if (isGameBegin == true && isBeginGameRecording == false) {
			GlosPoczatek ();
		}
			

        if (notesScript.isNote25 == true && Time.timeScale == 1 && isAnnaNoteRecording == false)
        {
            GlosNotatkaAnna();
        }

        if(isBigRoomRecording == true && isRetroBigRoomRecording == false)
        {
       
			Retrospekcja();

            if(isResetRetro == true)
            {
                isRetroBigRoomRecording = true;
            }
        }

        if (isArthurRoomRecording == true && isRetroArthurRoomRecording == false)
        {
            
			Retrospekcja();

            if (isResetRetro == true)
            {
                isRetroArthurRoomRecording = true;
            }
        }

        if (isToolShedRecording == true && isRetroToolShedRecording == false)
        {
			Retrospekcja();

            if (isResetRetro == true)
            {
                isRetroToolShedRecording = true;
            }
        }

        if (isAliceHouseRecording == true && isRetroAliceHouseRecording == false)
        {
			Retrospekcja();

            if (isResetRetro == true)
            {
                isRetroAliceHouseRecording = true;
            }
        }

        if (isWorkshopRecording == true && isRetroWorkshopRecording == false)
        {

			Retrospekcja();

            if (isResetRetro == true)
            {
                isRetroWorkshopRecording = true;
            }
        }

        if (isCornfieldRecording == true && isRetroCornfieldRecording == false)
        {
            
			Retrospekcja();

            if (isResetRetro == true)
            {
                isRetroCornfieldRecording = true;
            }
        }

        if (isOldShedRecording == true && isRetroOldShedRecording == false)
        {
			Retrospekcja();

            if (isResetRetro == true)
            {
                isRetroOldShedRecording = true;
            }
        }

        if (isBooksRecording == true && isRetroBooksRecording == false)
        {
			Retrospekcja();

            if (isResetRetro == true)
            {
                isRetroBooksRecording = true;
            }
        }

        if (isStevenHouseRecording == true && isRetroStevenHouseRecording == false)
        {
			Retrospekcja();

            if (isResetRetro == true)
            {
                isRetroStevenHouseRecording = true;
            }
        }


        if (isStevenShedRecording == true && isRetroStevenShedRecording == false)
        {
			Retrospekcja();

            if (isResetRetro == true)
            {
                isRetroStevenShedRecording = true;
            }
        }

		if (tasksScript.hallunsTimer > 5 && isHallunsRecording == false) {
			GlosHalucynacje ();
		}

		// napisy do nagran

		if ((playerAudioSource1.isPlaying == false && playerAudioSource2.isPlaying == false && playerAudioSource3.isPlaying == false && playerAudioSource4.isPlaying == false && retrospectionAudioSource.isPlaying == false && tasksScript.cassete1_AudioSource.isPlaying == false && tasksScript.cassete3_AudioSource.isPlaying == false && tasksScript.cassete4_AudioSource.isPlaying == false && tasksScript.cassete5_AudioSource.isPlaying == false) || gameMenuScript.subtitlesToggle.isOn == false ) { // GlosOgrodzenie_ok == true && OgrodzenieNap_ok == true
			subtitlesTextMesh.text = "";
		}

		if (playerAudioSource2.isPlaying == false || gameMenuScript.subtitlesToggle.isOn == false) {
			beginSubtitlesTextMesh.text = "";
		}

		// nie powtarzanie napisow

		if (playerAudioSource2.isPlaying == false && isBeginGameRecording == true && isBeginGameSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1) {
			isBeginGameSubtitles = true;
		}

		else if (playerAudioSource2.isPlaying == false && isFenceRecording == true && isFenceSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1) {
			isFenceSubtitles = true;
		}

		else if (playerAudioSource2.isPlaying == false && isHouseLightRecording == true && isHouseLightSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1) {
			isHouseLightSubtitles = true;
		}

		else if (playerAudioSource2.isPlaying == false && isKitchenRecording == true && isKitchenSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1) {
			isKitchenSubtitles = true;
		}

		else if (retrospectionAudioSource.isPlaying == false && isBigRoomRecording == true && isBigRoomSubtitles == false && retrospectionAudioSource.clip == null && Time.timeScale == 1) {
			isBigRoomSubtitles = true;
		}

		else if (retrospectionAudioSource.isPlaying == false && isArthurRoomRecording == true && isArthurRoomSubtitles == false && retrospectionAudioSource.clip == null && Time.timeScale == 1) {
			isArthurRoomSubtitles = true;
		}

		else if (retrospectionAudioSource.isPlaying == false && isToolShedRecording == true && isToolShedSubtitles == false && retrospectionAudioSource.clip == null && Time.timeScale == 1) {
			isToolShedSubtitles = true;
		}

		else if (tasksScript.cassete1_AudioSource.isPlaying == false && tasksScript.isCassete1Played == true && isCassete1Subtitles == false && tasksScript.cassete1_AudioSource.clip == null && Time.timeScale == 1) {
			isCassete1Subtitles = true;
		}

		else if (retrospectionAudioSource.isPlaying == false && isAliceHouseRecording == true && isAliceHouseSubtitles == false && retrospectionAudioSource.clip == null && Time.timeScale == 1) {
			isAliceHouseSubtitles = true;
		}

		else if (playerAudioSource1.isPlaying == false && isHallunsRecording == true && isHallunsSubtitles == false && playerAudioSource1.clip == null && Time.timeScale == 1) {
			isHallunsSubtitles = true;
		}

		else if (retrospectionAudioSource.isPlaying == false && isWorkshopRecording == true && isWorkshopSubtitles == false && retrospectionAudioSource.clip == null && Time.timeScale == 1) {
			isWorkshopSubtitles = true;
		}

		else if (playerAudioSource2.isPlaying == false && isLeftBrookRecording == true && isLeftBrookSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1) {
			isLeftBrookSubtitles = true;
		}

		else if (playerAudioSource3.isPlaying == false && isAnnaNoteRecording == true && isAnnaNoteSubtitles == false && playerAudioSource3.clip == null && Time.timeScale == 1) {
			isAnnaNoteSubtitles = true;
		}

		else if (playerAudioSource3.isPlaying == false && isPliersRecording == true && isPliersSubtitles == false && playerAudioSource3.clip == null && Time.timeScale == 1) {
			isPliersSubtitles = true;
		}

		else if (retrospectionAudioSource.isPlaying == false && isCornfieldRecording == true && isCornfieldSubtitles == false && retrospectionAudioSource.clip == null && Time.timeScale == 1) {
			isCornfieldSubtitles = true;
		}

		else if (playerAudioSource3.isPlaying == false && isAxeRecording == true && isAxeSubtitles == false && playerAudioSource3.clip == null && Time.timeScale == 1) {
			isAxeSubtitles = true;
		}

		else if (retrospectionAudioSource.isPlaying == false && isOldShedRecording == true && isOldShedSubtitles == false && retrospectionAudioSource.clip == null && Time.timeScale == 1) {
			isOldShedSubtitles = true;
		}

		else if (tasksScript.cassete1_AudioSource.isPlaying == false && tasksScript.isCassete2Played == true && isCassete2Subtitles == false && tasksScript.cassete1_AudioSource.clip == null && Time.timeScale == 1) {
			isCassete2Subtitles = true;
		}

		else if (playerAudioSource2.isPlaying == false && isAfterCasseteRecording == true && isAfterCasseteSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1) {
			isAfterCasseteSubtitles = true;
		}

		else if (retrospectionAudioSource.isPlaying == false && isBooksRecording == true && isBooksSubtitles == false && retrospectionAudioSource.clip == null && Time.timeScale == 1) {
			isBooksSubtitles = true;
		}

		else if (tasksScript.cassete3_AudioSource.isPlaying == false && tasksScript.isCassete3Played == true && isCassete3Subtitles == false && tasksScript.cassete3_AudioSource.clip == null && Time.timeScale == 1) {
			isCassete3Subtitles = true;
		}

		else if (playerAudioSource2.isPlaying == false && isRavineRecording == true && isRavineSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1) {
			isRavineSubtitles = true;
		}

		else if (tasksScript.cassete4_AudioSource.isPlaying == false && tasksScript.isCassete4Played == true && isCassete4Subtitles == false && tasksScript.cassete4_AudioSource.clip == null && Time.timeScale == 1) {
			isCassete4Subtitles = true;
		}

		else if (retrospectionAudioSource.isPlaying == false && isStevenHouseRecording == true && isStevenHouseSubtitles == false && retrospectionAudioSource.clip == null && Time.timeScale == 1) {
			isStevenHouseSubtitles = true;
		}

		else if (playerAudioSource2.isPlaying == false && isAcidRecording == true && isAcidSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1) {
			isAcidSubtitles = true;
		}

		else if (retrospectionAudioSource.isPlaying == false && isStevenShedRecording == true && isStevenShedSubtitles == false && retrospectionAudioSource.clip == null && Time.timeScale == 1) {
			isStevenShedSubtitles = true;
		}

		else if (playerAudioSource2.isPlaying == false && isDevilsBrookRecording == true && isDevilsBrookSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1) {
			isDevilsBrookSubtitles = true;
		}

		else if (tasksScript.cassete5_AudioSource.isPlaying == false && tasksScript.isCassete5Played == true && isCassete5Subtitles == false && tasksScript.cassete5_AudioSource.clip == null && Time.timeScale == 1) {
			isCassete5Subtitles = true;
		}

		else if (playerAudioSource1.isPlaying == false && isDevilsShelterRecording == true && isDevilsShelterSubtitles == false && playerAudioSource1.clip == null && Time.timeScale == 1) {
			isDevilsShelterSubtitles = true;
		}

        else if (playerAudioSource1.isPlaying == false && isWellRecording == true && isWoodSubtitles == false && playerAudioSource1.clip == null && Time.timeScale == 1) //
        {
            isWoodSubtitles = true;
        }

        else if (playerAudioSource1.isPlaying == false && isStableRecording == true && isWellSubtitles == false && playerAudioSource1.clip == null && Time.timeScale == 1)
        {
            isWellSubtitles = true;
        }

        else if (playerAudioSource1.isPlaying == false && isGardenRecording == true && isStableSubtitles == false && playerAudioSource1.clip == null && Time.timeScale == 1)
        {
            isStableSubtitles = true;
        }

        else if (playerAudioSource3.isPlaying == false && isGardenRecording == true && isGardenSubtitles == false && playerAudioSource3.clip == null && Time.timeScale == 1)
        {
            isGardenSubtitles = true;
        }

        else if (playerAudioSource1.isPlaying == false && isSecretRoomRecording == true && isSecretRoomSubtitles == false && playerAudioSource1.clip == null && Time.timeScale == 1)
        {
            isSecretRoomSubtitles = true;
        }

        else if (playerAudioSource1.isPlaying == false && isInventionRecording == true && isInventionSubtitles == false && playerAudioSource1.clip == null && Time.timeScale == 1)
        {
            isInventionSubtitles = true;
        }

        else if (playerAudioSource2.isPlaying == false && isWardrobeCorridorRecording == true && isWardrobeCorridorSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1)
        {
            isWardrobeCorridorSubtitles = true;
        }

        else if (playerAudioSource2.isPlaying == false && isChipRecording == true && isChipSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1)
        {
            isChipSubtitles = true;
        }

        else if (playerAudioSource1.isPlaying == false && isArthurTipRecording == true && isArthurTipSubtitles == false && playerAudioSource1.clip == null && Time.timeScale == 1)
        {
            isArthurTipSubtitles = true;
        }

        else if (playerAudioSource2.isPlaying == false && isMonstersPlantsRecording == true && isMonstersPlantsSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1)
        {
            isMonstersPlantsSubtitles = true;
        }

        else if (playerAudioSource2.isPlaying == false && isZenoRecording == true && isZenoSubtitles == false && playerAudioSource2.clip == null && Time.timeScale == 1)
        {
            isZenoSubtitles = true;
        }

        // wlaczanie napisow

        if (playerAudioSource2.clip != null && isBeginGameRecording == true && isBeginGameSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			PoczatekGryNapisy ();
		}

		else if (playerAudioSource2.clip != null && isFenceRecording == true && isFenceSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			OgrodzenieNapisy ();
		}

		else if (playerAudioSource2.clip != null && isHouseLightRecording == true && isHouseLightSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			SwiatloDomuNapisy ();
		}

		else if (playerAudioSource2.clip != null && isKitchenRecording == true && isKitchenSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true && Time.timeScale == 1) {
			KuchniaNapisy ();
		}

		else if (retrospectionAudioSource.clip != null && isBigRoomRecording == true && isBigRoomSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			DuzyPokojNapisy ();
		}

		else if (retrospectionAudioSource.clip != null && isArthurRoomRecording == true && isArthurRoomSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			PokojArthurNapisy ();
		}

		else if (retrospectionAudioSource.clip != null && isToolShedRecording == true && isToolShedSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			SzopaNarzedziaNapisy ();
		}

		else if (tasksScript.cassete1_AudioSource.clip != null && tasksScript.isCassete1Played == true && isCassete1Subtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			Kaseta1Napisy ();
		}

		else if (retrospectionAudioSource.clip != null && isAliceHouseRecording == true && isAliceHouseSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			DomAliceNapisy ();
		}

		else if (playerAudioSource1.clip != null && isHallunsRecording == true && isHallunsSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)  {
			HalucynacjeNapisy ();
		}

		else if (retrospectionAudioSource.clip != null && isWorkshopRecording == true && isWorkshopSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			WarsztatNapisy ();
		}

		else if (playerAudioSource2.clip != null && isLeftBrookRecording == true && isLeftBrookSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			LewyPotokNapisy ();
		}

		else if (playerAudioSource3.clip != null && isAnnaNoteRecording == true && isAnnaNoteSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			NotatkaAnnaNapisy ();
		}

		else if (playerAudioSource3.clip != null && isPliersRecording == true && isPliersSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			KombinerkiNapisy ();
		}
			
		else if (retrospectionAudioSource.clip != null && isCornfieldRecording == true && isCornfieldSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			KukurydzaNapisy ();
		}

		else if (playerAudioSource3.clip != null && isAxeRecording == true && isAxeSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			SiekieraNapisy ();
		}

		else if (retrospectionAudioSource.clip != null && isOldShedRecording == true && isOldShedSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			StaraSzopaNapisy ();
		}

		else if (tasksScript.cassete1_AudioSource.clip != null && tasksScript.isCassete2Played == true && isCassete2Subtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			Kaseta2Napisy ();
		}

		else if (playerAudioSource2.clip != null && isAfterCasseteRecording == true && isAfterCasseteSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			NagranieNapisy ();
		}

		else if (retrospectionAudioSource.clip != null && isBooksRecording == true && isBooksSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			KsiazkiNapisy ();
		}

		else if (tasksScript.cassete3_AudioSource.clip != null && tasksScript.isCassete3Played == true && isCassete3Subtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			Kaseta3Napisy ();
		}

		else if (playerAudioSource2.clip != null && isRavineRecording == true && isRavineSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			WawozNapisy ();
		}

		else if (tasksScript.cassete4_AudioSource.clip != null && tasksScript.isCassete4Played == true && isCassete4Subtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			Kaseta4Napisy ();
		}

		else if (retrospectionAudioSource.isPlaying == true && isStevenHouseRecording == true && isStevenHouseSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			DomStevenaNapisy ();
		}

		else if (playerAudioSource2.clip != null && isAcidRecording == true && isAcidSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			EliksirNapisy ();
		}

		else if (retrospectionAudioSource.clip != null && isStevenShedRecording == true && isStevenShedSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			SzopaStevenNapisy ();
		}

		else if (playerAudioSource2.clip != null && isDevilsBrookRecording == true && isDevilsBrookSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			PotokDiablyNapisy ();
		}

		else if (tasksScript.cassete5_AudioSource.clip != null && tasksScript.isCassete5Played == true && isCassete5Subtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			Kaseta5Napisy ();
		}

		else if (playerAudioSource1.clip != null && isDevilsShelterRecording == true && isDevilsShelterSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true) {
			KryjowkaNapisy ();
		}

        else if (playerAudioSource1.clip != null && isWellRecording == true && isWoodSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            SzalasNapisy();
        }

        else if (playerAudioSource1.clip != null && isStableRecording == true && isWellSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            StudniaNapisy();
        }

        else if (playerAudioSource1.clip != null && isGardenRecording == true && isStableSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            StajniaNapisy();
        }

        else if (playerAudioSource3.clip != null && isGardenRecording == true && isGardenSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            OgrodNapisy();
        }

        else if (playerAudioSource1.clip != null && isSecretRoomRecording == true && isSecretRoomSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            KampingNapisy();
        }

        else if (playerAudioSource1.clip != null && isInventionRecording == true && isInventionSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            UrzadzenieVictoraNapisy();
        }

        else if (playerAudioSource2.clip != null && isWardrobeCorridorRecording == true && isWardrobeCorridorSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            SzafaKorytarzNapisy();
        }

        else if (playerAudioSource2.clip != null && isChipRecording == true && isChipSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            ChipNapisy();
        }

        else if (playerAudioSource1.clip != null && isArthurTipRecording == true && isArthurTipSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            WskazowkiArturaNapisy();
        }

        else if (playerAudioSource2.clip != null && isMonstersPlantsRecording == true && isMonstersPlantsSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            RoslinyPotworowNapisy();
        }

        else if (playerAudioSource2.clip != null && isZenoRecording == true && isZenoSubtitles == false && gameMenuScript.subtitlesToggle.isOn == true)
        {
            ZenoNapisy();
        }

        if (Time.timeScale == 0) {
			if (playerAudioSource1.clip != null) {
				playerAudioSource1.Pause ();
			} else if (playerAudioSource2.clip != null) {
				playerAudioSource2.Pause ();
			} else if (playerAudioSource3.clip != null) {
				playerAudioSource3.Pause ();
			} else if (playerAudioSource4.clip != null) {
				playerAudioSource4.Pause ();
			} else if (retrospectionAudioSource.clip != null) {
				retrospectionAudioSource.Pause ();
			} else if (tasksScript.cassete1_AudioSource.clip != null) {
				tasksScript.cassete1_AudioSource.Pause ();
			} else if (tasksScript.cassete3_AudioSource.clip != null) {
				tasksScript.cassete3_AudioSource.Pause ();
			} else if (tasksScript.cassete4_AudioSource.clip != null) {
				tasksScript.cassete4_AudioSource.Pause ();
			} else if (tasksScript.cassete5_AudioSource.clip != null) {
				tasksScript.cassete5_AudioSource.Pause ();
			}
		}

		if (Time.timeScale == 1) {
			if (playerAudioSource1.clip != null) {
				playerAudioSource1.UnPause ();
			} else if (playerAudioSource2.clip != null) {
				playerAudioSource2.UnPause ();
			} else if (playerAudioSource3.clip != null) {
				playerAudioSource3.UnPause ();
			} else if (playerAudioSource4.clip != null) {
				playerAudioSource4.UnPause ();
			} else if (retrospectionAudioSource.clip != null) {
				retrospectionAudioSource.UnPause ();
			} else if (tasksScript.cassete1_AudioSource.clip != null) {
				tasksScript.cassete1_AudioSource.UnPause ();
			} else if (tasksScript.cassete3_AudioSource.clip != null) {
				tasksScript.cassete3_AudioSource.UnPause ();
			} else if (tasksScript.cassete4_AudioSource.clip != null) {
				tasksScript.cassete4_AudioSource.UnPause ();
			} else if (tasksScript.cassete5_AudioSource.clip != null) {
				tasksScript.cassete5_AudioSource.UnPause ();
			}
		}

		if (playerAudioSource1.isPlaying == false && playerAudioSource1.clip != null && Time.timeScale == 1) {
			playerAudioSource1.clip = null;
		} else if (playerAudioSource2.isPlaying == false && playerAudioSource2.clip != null && Time.timeScale == 1) {
			playerAudioSource2.clip = null;
		} else if (playerAudioSource3.isPlaying == false && playerAudioSource3.clip != null && Time.timeScale == 1) {
			playerAudioSource3.clip = null;
		} else if (playerAudioSource4.isPlaying == false && playerAudioSource4.clip != null && Time.timeScale == 1) {
			playerAudioSource4.clip = null;
		} else if (retrospectionAudioSource.isPlaying == false && retrospectionAudioSource.clip != null && Time.timeScale == 1) {
			retrospectionAudioSource.clip = null;
		} else if (tasksScript.cassete1_AudioSource.isPlaying == false && tasksScript.cassete1_AudioSource.clip != null && Time.timeScale == 1) {
			tasksScript.cassete1_AudioSource.clip = null;
		} else if (tasksScript.cassete3_AudioSource.isPlaying == false && tasksScript.cassete3_AudioSource.clip != null && Time.timeScale == 1) {
			tasksScript.cassete3_AudioSource.clip = null;
		} else if (tasksScript.cassete4_AudioSource.isPlaying == false && tasksScript.cassete4_AudioSource.clip != null && Time.timeScale == 1) {
			tasksScript.cassete4_AudioSource.clip = null;
		} else if (tasksScript.cassete5_AudioSource.isPlaying == false && tasksScript.cassete5_AudioSource.clip != null && Time.timeScale == 1) {
			tasksScript.cassete5_AudioSource.clip = null;
		}

		// Zakonczenie gry

		if(isDevilsShelterRecording == true && isEndGame == false){
			ZakonczenieGry ();
		}


		if (isDevilsShelterRecording == true && playerAudioSource1.isPlaying == true) {

			player.transform.rotation = Quaternion.Slerp (player.rotation, Quaternion.LookRotation(corpse.position), 2 * Time.deltaTime);

		}

		if(playerAudioSource1.isPlaying == false && isEndGame == true && isMonster == false){

            player.gameObject.GetComponent<Music>().backgroundAudioSource2.clip = null;
			monsterAudioSource.clip = monsterSound;
			monsterAudioSource.Play ();
			isMonster = true;
			staticMonsterShelter1.gameObject.SetActive (true);
			staticMonsterShelter2.gameObject.SetActive (true);
			shelterMainMonster.gameObject.SetActive (true);
			shelterMainMonster.gameObject.GetComponent<MonsterKryjowka> ().enabled = true;
		}

		if (monsterAudioSource.isPlaying == true && isMonster == true && monsterAudioSource.time > 0.6f && monsterAudioSource.time < 1.6f) {

			player.transform.rotation = Quaternion.Slerp (player.rotation, Quaternion.LookRotation(shelterMainMonster.position - player.position), 3 * Time.deltaTime);

		}

		if (whisperAudioSource.isPlaying == true && isWhisper == true && whisperAudioSource.time > 10) {
			whisperAudioSource.volume -= (Time.deltaTime / 4);
		}

		if (whisperAudioSource.volume <= 0 && isWhisper == true && isDead == false) { // bylo odloSzepty.isPlaying == false
			player.gameObject.GetComponent<EndGame> ().enabled = true;
            whisperAudioSource.Stop();
            isDead = true;
		}

        // koniec zakonczenia

        // glos szalas

        if (screamerScript.woodBirdAudioSource.isPlaying == false && screamerScript.isWoodBird == true && Time.timeScale == 1 && isWellRecording == false)
        {
            GlosSzalas();
        }

        // glos stajnia

        if (jumpscareScript.stableMonsterAudioSource.time > 3 && jumpscareScript.isStableMonster == true && Time.timeScale == 1 && isGardenRecording == false)
        {
            GlosStajnia();
        }

        // glos ogrod

        if (screamerScript.rustleAudioSource.isPlaying == false && screamerScript.isRustle == true && Time.timeScale == 1 && isGardenRecording == false)
        {
            GlosOgrod();
        }

        // glos kamping

        if (tasksScript.cassete1_AudioSource.isPlaying == false && tasksScript.isCassete1Played == true && isSecretRoomRecording == false && Time.timeScale == 1)
        {
            GlosKamping();
        }

        // glos urzadzenie Victora

        if (inventoryScript.isWoodenWheelRemoved == true && isInventionRecording == false && Time.timeScale == 1)
        {
            GlosUrzadzenieVictora();
        }

        // glos szafa korytarz

        if (inventoryScript.isWardrobeCorridorKeyTaken == true && isWardrobeCorridorRecording == false && Time.timeScale == 1)
        {
            GlosSzafaKorytarz();
        }

        // glos chip

        if (chipAudioSource.isPlaying == false && taskBooksScript.isTaskDone == true && isChipRecording == false && Time.timeScale == 1)
        {
            GlosChip();
        }

        // glos wskazowki Artura

        if (tasksScript.cassete3_AudioSource.isPlaying == false && tasksScript.isCassete3Played == true && isArthurTipRecording == false && Time.timeScale == 1)
        {
            GlosWskazowkiArtura();
        }

        // glos rosliny potworow

        if (notesScript.isNote48 == true && isMonstersPlantsRecording == false && Time.timeScale == 1)
        {
            GlosRoslinyPotworow();
        }

        // glos Zeno

        if (notesScript.isNote52 == true && isZenoRecording == false && Time.timeScale == 1)
        {
            GlosZeno();
        }

    }

    void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag("GlosOgrodzenie_trigger") && isFenceRecording == false && isKitchenRecording == false)
        {
            GlosOgrodzenie();
        }

		else if (other.gameObject.CompareTag("GlosSwiatloDomu_trigger") && isHouseLightRecording == false && isKitchenRecording == false)
        {
            GlosSwiatloDomu();
        }

		else if (other.gameObject.CompareTag("GlosKuchnia_trigger") && isKitchenRecording == false)
        {
            GlosKuchnia();
        }

		else if (other.gameObject.CompareTag("GlosDuzyPokoj_trigger") && isBigRoomRecording == false)
        {
            GlosDuzyPokoj();
        }

		else if (other.gameObject.CompareTag("GlosPokojArtura_trigger") && isArthurRoomRecording == false)
        {
            GlosPokojArtura();
        }

		else if (other.gameObject.CompareTag("GlosSzopaNarzedzia_trigger") && isToolShedRecording == false)
        {
            GlosSzopaNarzedzia();
        }

		else if (other.gameObject.CompareTag("GlosDomAlice_trigger") && isAliceHouseRecording == false)
        {
            GlosDomAlice();
        }

		else if (other.gameObject.CompareTag("GlosWarsztat_trigger") && isWorkshopRecording == false)
        {
            GlosWarsztat();
        }

		else if (other.gameObject.CompareTag("GlosLewyPotok_trigger") && isLeftBrookRecording == false && tasksScript.isVictorBrookTask == true && inventoryScript.isAliceKeyTaken == false)
        {
            GlosLewyPotok();
        }

		else if (other.gameObject.CompareTag("GlosKukurydza_trigger") && isCornfieldRecording == false)
        {
            GlosKukurydza();
        }

		else if (other.gameObject.CompareTag("GlosStaraSzopa_trigger") && isOldShedRecording == false)
        {
            GlosStaraSzopa();
        }

		else if (other.gameObject.CompareTag("MuzykaKlimat13_trigger") && isBooksRecording == false) 
        {
            GlosKsiazki();
        }

		else if (other.gameObject.CompareTag("IdzWawoz_trigger") && isRavineRecording == false && tasksScript.isRavineTask == true && notesScript.isNote36 == false) 
        {
            GlosWawoz();
        }

		else if (other.gameObject.CompareTag("GlosDomStevena_trigger") && isStevenHouseRecording == false)
        {
            GlosDomStevena();
        }

		else if (other.gameObject.CompareTag("MuzykaKlimat21_trigger") && isStevenShedRecording == false)
        {
            GlosSzopaSteven();
        }

		else if (other.gameObject.CompareTag("PaulInfo_trigger") && isDevilsBrookRecording == false && tasksScript.isStevenBrookTask == true && tasksScript.isHutTask == false)
        {
            GlosPotokDiably();
        }

		else if (other.gameObject.CompareTag("GlosKryjowka_trigger") && isDevilsShelterRecording == false)
        {
            GlosKryjowka();
        }

        else if (other.gameObject.CompareTag("GlosStudnia_trigger") && isStableRecording == false && tasksScript.isMagicWellTask == true)
        {
            GlosStudnia();
        }

    }

	void GlosPoczatek()
	{
		//ZrodloDzwiekuB.PlayOneShot(DzwGlosOgrodzenie);
		isBeginGameRecording = true;
		playerAudioSource2.clip = beginGameRecording;
		playerAudioSource2.Play ();
	}

	void PoczatekGryNapisy()
	{
		if (playerAudioSource2.time > 0.5f && playerAudioSource2.time < 4.1f && playerAudioSource2.isPlaying == true) {
			beginSubtitlesTextMesh.text = beginGameSubtitles1;
		} 

		else if (playerAudioSource2.time >= 4.1f && playerAudioSource2.time < 8f && playerAudioSource2.isPlaying == true) {
			beginSubtitlesTextMesh.text = beginGameSubtitles2;
		} 

		else if (playerAudioSource2.time >= 8f && playerAudioSource2.time < 12.4f && playerAudioSource2.isPlaying == true) {
			beginSubtitlesTextMesh.text = beginGameSubtitles3;
		}

		else if (playerAudioSource2.time >= 12.4f && playerAudioSource2.isPlaying == true) {
			beginSubtitlesTextMesh.text = beginGameSubtitles4;
		} 

	}

    void GlosOgrodzenie()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosOgrodzenie);
        isFenceRecording = true;
		playerAudioSource2.clip = fenceRecording;
		playerAudioSource2.Play ();
        playerScript.audioSource.Stop();
    }

	void OgrodzenieNapisy()
	{
		if (playerAudioSource2.isPlaying == true && playerAudioSource2.time > 0.6f) {
			subtitlesTextMesh.text = fenceSubtitles;
		} 
	}

    void GlosSwiatloDomu()
    {
        //ZrodloDzwiekuB2.PlayOneShot(DzwGlosSwiatloDomu);
        isHouseLightRecording = true;
		playerAudioSource2.clip = houseLightRecording;
		playerAudioSource2.Play ();
        playerScript.audioSource.Stop();
    }

	void SwiatloDomuNapisy()
	{
		if (playerAudioSource2.isPlaying == true && playerAudioSource2.time > 0.9f) {
			subtitlesTextMesh.text = houseLightSubtitles;
		} 
	}

    void GlosKuchnia()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKuchnia);
        retrospectionAudioSource.Stop();
        isKitchenRecording = true;
		playerAudioSource2.clip = kitchenRecording;
		playerAudioSource2.Play ();
        playerScript.audioSource.Stop();
    }

	void KuchniaNapisy()
	{
		if (playerAudioSource2.isPlaying == true && playerAudioSource2.time > 0.5f) {
			subtitlesTextMesh.text = kitchenSubtitles;
		}   
	}

    void GlosDuzyPokoj()
    {
        //ZrodloDzwiekuR.PlayOneShot(DzwGlosDuzyPokoj);
        playerAudioSource2.Stop();
        isBigRoomRecording = true;
		retrospectionAudioSource.clip = bigRoomRecording;
		retrospectionAudioSource.Play ();
        isStartRetro = false;
        isMidRetro = false;
        isEndRetro = false;
        playerScript.audioSource.Stop();
    }


	public void DuzyPokojNapisy()
	{
		if (retrospectionAudioSource.time > 0.5f && retrospectionAudioSource.time < 7f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = bigRoomSubtitles1;
		} 

		else if (retrospectionAudioSource.time >= 7f && retrospectionAudioSource.time < 12.5f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = bigRoomSubtitles2;
		} 

		else if (retrospectionAudioSource.time >= 12.5f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = bigRoomSubtitles3;
		}
			
	}


    void GlosPokojArtura()
    {
        //ZrodloDzwiekuR.PlayOneShot(DzwGlosPokojArtura);
        isArthurRoomRecording = true;
		retrospectionAudioSource.clip = arthurRoomRecording;
		retrospectionAudioSource.Play ();
        isStartRetro = false;
        isMidRetro = false;
        isEndRetro = false;
        playerScript.audioSource.Stop();
    }

	public void PokojArthurNapisy()
	{
		if (retrospectionAudioSource.time > 1.6f && retrospectionAudioSource.time < 9f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = arthurRoomSubtitles1;
		} 

		else if (retrospectionAudioSource.time >= 9f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = arthurRoomSubtitles2;
		} 

	}

    void GlosSzopaNarzedzia()
    {
        //ZrodloDzwiekuR.PlayOneShot(DzwGlosSzopaNarzedzia);
        isToolShedRecording = true;
		retrospectionAudioSource.clip = toolShedRecording;
		retrospectionAudioSource.Play ();
        isStartRetro = false;
        isMidRetro = false;
        isEndRetro = false;
        playerScript.audioSource.Stop();
    }

	public void SzopaNarzedziaNapisy()
	{
		if (retrospectionAudioSource.time > 1f && retrospectionAudioSource.time < 5.4f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = toolShedSubtitles1;
		} 

		else if (retrospectionAudioSource.time >= 5.4f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = toolShedSubtitles2;
		} 
			
	}

	public void Kaseta1Napisy()
	{
		if (tasksScript.cassete1_AudioSource.time > 1.3f && tasksScript.cassete1_AudioSource.time < 10.4f && tasksScript.cassete1_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete1Subtitles1;
		} 

		else if (tasksScript.cassete1_AudioSource.time >= 10.4f && tasksScript.cassete1_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete1Subtitles2;
		} 
			
	}

	public void Kaseta2Napisy()
	{
		if (tasksScript.cassete1_AudioSource.time > 0.5f && tasksScript.cassete1_AudioSource.time < 4.4f && tasksScript.cassete1_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete2Subtitles1;
		} 

		else if (tasksScript.cassete1_AudioSource.time >= 4.4f && tasksScript.cassete1_AudioSource.time < 7.7f && tasksScript.cassete1_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete2Subtitles2;
		} 

		else if (tasksScript.cassete1_AudioSource.time >= 7.7f && tasksScript.cassete1_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete2Subtitles3;
		} 
			
	}

	public void Kaseta3Napisy()
	{
		if (tasksScript.cassete3_AudioSource.time > 0.9f && tasksScript.cassete3_AudioSource.time < 7.6f && tasksScript.cassete3_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete3Subtitles1;
		} 

		else if (tasksScript.cassete3_AudioSource.time >= 7.6f && tasksScript.cassete3_AudioSource.time < 14.7f && tasksScript.cassete3_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete3Subtitles2;
		} 

		else if (tasksScript.cassete3_AudioSource.time >= 14.7f && tasksScript.cassete3_AudioSource.time < 19.3f && tasksScript.cassete3_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete3Subtitles3;
		} 

		else if (tasksScript.cassete3_AudioSource.time >= 19.3f && tasksScript.cassete3_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete3Subtitles4;
		} 
			
	}

	public void Kaseta4Napisy()
	{
		if (tasksScript.cassete4_AudioSource.time > 0.5f && tasksScript.cassete4_AudioSource.time < 14.3f && tasksScript.cassete4_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete4Subtitles1;
		} 

		else if (tasksScript.cassete4_AudioSource.time >= 14.3f && tasksScript.cassete4_AudioSource.time < 23.9f && tasksScript.cassete4_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete4Subtitles2;
		} 

		else if (tasksScript.cassete4_AudioSource.time >= 23.9f && tasksScript.cassete4_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete4Subtitles3;
		} 
			
	}

	public void Kaseta5Napisy()
	{
		if (tasksScript.cassete5_AudioSource.time > 0.7f && tasksScript.cassete5_AudioSource.time < 9.5f && tasksScript.cassete5_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete5Subtitles1;
		} 

		else if (tasksScript.cassete5_AudioSource.time >= 9.5f && tasksScript.cassete5_AudioSource.time < 20.3f && tasksScript.cassete5_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete5Subtitles2;
		} 

		else if (tasksScript.cassete5_AudioSource.time >= 20.3f && tasksScript.cassete5_AudioSource.time < 28.1f && tasksScript.cassete5_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete5Subtitles3;
		} 

		else if (tasksScript.cassete5_AudioSource.time >= 28.1f && tasksScript.cassete5_AudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cassete5Subtitles4;
		} 
			
	}

    void GlosDomAlice()
    {
        //ZrodloDzwiekuR.PlayOneShot(DzwGlosDomAlice);
        isAliceHouseRecording = true;
		retrospectionAudioSource.clip = aliceHouseRecording;
		retrospectionAudioSource.Play ();
        isStartRetro = false;
        isMidRetro = false;
        isEndRetro = false;
        playerScript.audioSource.Stop();
    }

	void DomAliceNapisy()
	{
		if (retrospectionAudioSource.time > 0.5f && retrospectionAudioSource.time < 5.6f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = aliceHouseSubtitles1;
		} 

		else if (retrospectionAudioSource.time >= 5.6f && retrospectionAudioSource.time < 11f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = aliceHouseSubtitles2;
		} 

		else if (retrospectionAudioSource.time >= 11f && retrospectionAudioSource.time < 16.9f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = aliceHouseSubtitles3;
		}

		else if (retrospectionAudioSource.time >= 16.9f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = aliceHouseSubtitles4;
		} 
			
	}

	void GlosHalucynacje()
	{
		//ZrodloDzwiekuB.PlayOneShot(DzwGlosHalucynacje);
		isHallunsRecording = true;
		playerAudioSource1.clip = hallunsRecording;
		playerAudioSource1.Play ();
        musicScript.KlimatAlice();
        playerScript.audioSource.Stop();
    }

	void HalucynacjeNapisy()
	{
		if (playerAudioSource1.time > 0.4f && playerAudioSource1.isPlaying == true) {
			subtitlesTextMesh.text = hallunsSubtitles;
		}  
	}

    void GlosWarsztat()
    {
        //ZrodloDzwiekuR.PlayOneShot(DzwGlosWarsztat);
        isWorkshopRecording = true;
		retrospectionAudioSource.clip = workshopRecording;
		retrospectionAudioSource.Play ();
        isStartRetro = false;
        isMidRetro = false;
        isEndRetro = false;
        playerScript.audioSource.Stop();
    }

	void WarsztatNapisy()
	{
		if (retrospectionAudioSource.time > 0.8f && retrospectionAudioSource.time < 4.4f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = workshopSubtitles1;
		} 

		else if (retrospectionAudioSource.time >= 4.4f && retrospectionAudioSource.time < 9f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = workshopSubtitles2;
		} 

		else if (retrospectionAudioSource.time >= 9f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = workshopSubtitles3;
		}
			
	}

    void GlosLewyPotok()
    {
		//ZrodloDzwiekuB2.PlayOneShot(DzwGlosLewyPotok);
		isLeftBrookRecording = true;
		playerAudioSource2.clip = leftBrookRecording; //
		playerAudioSource2.Play ();
        playerScript.audioSource.Stop();
    }

	void LewyPotokNapisy()
	{
		if (playerAudioSource2.time > 0.1f && playerAudioSource2.isPlaying == true) {
			subtitlesTextMesh.text = leftBrookSubtitles;
		}  
	}

    void GlosNotatkaAnna()
    {
        //ZrodloDzwiekuB3.PlayOneShot(DzwGlosNotatkaAnna);
        isAnnaNoteRecording = true;
		playerAudioSource3.clip = annaNoteRecording;
		playerAudioSource3.Play ();
        playerScript.audioSource.Stop();
    }

	void NotatkaAnnaNapisy()
	{
		if (playerAudioSource3.time > 0.1f && playerAudioSource3.isPlaying == true) {
			subtitlesTextMesh.text = annaNoteSubtitles;
		} 
	}

	public void GlosKombinerki()
	{
		//ZrodloDzwiekuB3.PlayOneShot(DzwGlosKombinerki);
		isPliersRecording = true;
		playerAudioSource3.clip = pliersRecording;
		playerAudioSource3.Play ();
        playerScript.audioSource.Stop();
    }

	public void KombinerkiNapisy()
	{
		if (playerAudioSource3.time > 0.1f && playerAudioSource3.isPlaying == true) {
			subtitlesTextMesh.text = pliersSubtitles;
		} 
	}

    void GlosKukurydza()
    {
        //ZrodloDzwiekuR.PlayOneShot(DzwGlosKukurydza);
        isCornfieldRecording = true;
		retrospectionAudioSource.clip = cornfieldRecording;
		retrospectionAudioSource.Play ();
        isStartRetro = false;
        isMidRetro = false;
        isEndRetro = false;
        playerScript.audioSource.Stop();
    }

	void KukurydzaNapisy()
	{
		if (retrospectionAudioSource.time > 0.9f && retrospectionAudioSource.time < 7.2f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cornfieldSubtitles1;
		} 

		else if (retrospectionAudioSource.time >= 7.2f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = cornfieldSubtitles2;
		} 
			
	}

	public void GlosSiekiera()
	{
		//ZrodloDzwiekuB.PlayOneShot(DzwGlosSiekiera);
		isAxeRecording = true;
		playerAudioSource3.clip = axeRecording;
		playerAudioSource3.Play ();
        playerScript.audioSource.Stop();
    }

	public void SiekieraNapisy()
	{
		if (playerAudioSource3.time > 0.6f && playerAudioSource3.isPlaying == true) {
			subtitlesTextMesh.text = axeSubtitles;
		}  
	}

    void GlosStaraSzopa()
    {
        //ZrodloDzwiekuR.PlayOneShot(DzwGlosStaraSzopa);
        isOldShedRecording = true;
		retrospectionAudioSource.clip = oldShedRecording;
		retrospectionAudioSource.Play ();
        isStartRetro = false;
        isMidRetro = false;
        isEndRetro = false;
        playerScript.audioSource.Stop();
    }

	void StaraSzopaNapisy()
	{
		if (retrospectionAudioSource.time > 0.6f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = oldShedSubtitles;
		}  
	}

	public void GlosNagranie()
	{
		//ZrodloDzwiekuB.PlayOneShot(DzwGlosNagranie);
		isAfterCasseteRecording = true;
		playerAudioSource2.clip = afterCasseteRecording;
		playerAudioSource2.Play ();
        musicScript.KlimatPoKasecie2();
        playerScript.audioSource.Stop();
    }

	public void NagranieNapisy()
	{
		if (playerAudioSource2.time > 0.6f && playerAudioSource2.isPlaying == true) {
			subtitlesTextMesh.text = afterCasseteSubtitles;
		} 
	}

    void GlosKsiazki()
    {
        //ZrodloDzwiekuR.PlayOneShot(DzwGlosKsiazki);
        isBooksRecording = true;
		retrospectionAudioSource.clip = booksRecording;
		retrospectionAudioSource.Play ();
        isStartRetro = false;
        isMidRetro = false;
        isEndRetro = false;
        playerScript.audioSource.Stop();
    }

	void KsiazkiNapisy()
	{
		if (retrospectionAudioSource.time > 1.5f && retrospectionAudioSource.time < 7.4f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = booksSubtitles1;
		} 

		else if (retrospectionAudioSource.time >= 7.4f && retrospectionAudioSource.time < 13.4f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = booksSubtitles2;
		} 

		else if (retrospectionAudioSource.time >= 13.4f && retrospectionAudioSource.time < 16.9f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = booksSubtitles3;
		}

		else if (retrospectionAudioSource.time >= 16.9f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = booksSubtitles4;
		} 
			
	}

    void GlosWawoz()
    {
        //ZrodloDzwiekuB4.PlayOneShot(DzwGlosWawoz);
        isRavineRecording = true;
		playerAudioSource2.clip = ravineRecording;
		playerAudioSource2.Play ();
        playerScript.audioSource.Stop();
    }

	void WawozNapisy()
	{
		if (playerAudioSource2.time > 2.5f && playerAudioSource2.isPlaying == true) {
			subtitlesTextMesh.text = ravineSubtitles;
		}  
	}

    void GlosDomStevena()
    {
        //ZrodloDzwiekuR.PlayOneShot(DzwGlosDomStevena);
        isStevenHouseRecording = true;
		retrospectionAudioSource.clip = stevenHouseRecording;
		retrospectionAudioSource.Play ();
        isStartRetro = false;
        isMidRetro = false;
        isEndRetro = false;
        playerScript.audioSource.Stop();
    }

	void DomStevenaNapisy()
	{
		if (retrospectionAudioSource.time > 0.4f && retrospectionAudioSource.time < 6.9f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = stevenHouseSubtitles1;
		} 

		else if (retrospectionAudioSource.time >= 6.9f && retrospectionAudioSource.time < 10.4f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = stevenHouseSubtitles2;
		} 

		else if (retrospectionAudioSource.time >= 10.4f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = stevenHouseSubtitles3;
		}
			
	}

	public void GlosEliksir()
	{
		//ZrodloDzwiekuB2.PlayOneShot(DzwGlosEliksir);
		isAcidRecording = true;
		playerAudioSource2.clip = acidRecording;
		playerAudioSource2.Play ();
        playerScript.audioSource.Stop();
    }

	public void EliksirNapisy()
	{
		if (playerAudioSource2.time > 0.7f && playerAudioSource2.isPlaying == true) {
			subtitlesTextMesh.text = acidSubtitles;
		} 
	}

    void GlosSzopaSteven()
    {
        //ZrodloDzwiekuR.PlayOneShot(DzwGlosSzopaSteven);
        isStevenShedRecording = true;
		retrospectionAudioSource.clip = stevenShedRecording;
		retrospectionAudioSource.Play ();
        isStartRetro = false;
        isMidRetro = false;
        isEndRetro = false;
        playerScript.audioSource.Stop();
    }

	void SzopaStevenNapisy()
	{
		if (retrospectionAudioSource.time > 0.4f && retrospectionAudioSource.time < 5.2f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = stevenShedSubtitles1;
		} 

		else if (retrospectionAudioSource.time >= 5.2f && retrospectionAudioSource.time < 11f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = stevenShedSubtitles2;
		} 

		else if (retrospectionAudioSource.time >= 11f && retrospectionAudioSource.isPlaying == true) {
			subtitlesTextMesh.text = stevenShedSubtitles3;
		}
			
	}

    void GlosPotokDiably()
    {
        //ZrodloDzwiekuB2.PlayOneShot(DzwGlosPotokDiably);
        isDevilsBrookRecording = true;
		playerAudioSource2.clip = devilsBrookRecording;
		playerAudioSource2.Play ();
        playerScript.audioSource.Stop();
    }

	void PotokDiablyNapisy()
	{
		if (playerAudioSource2.time > 1.2f && playerAudioSource2.isPlaying == true) {
			subtitlesTextMesh.text = devilsBrookSubtitles;
		} 
	}

    void GlosKryjowka()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isDevilsShelterRecording = true;
		playerAudioSource1.clip = devilsShelterRecording;
		playerAudioSource1.Play ();
        screamerScript.whisper2AudioSource.Stop();
        screamerScript.whisper2AudioSource.clip = null;
        playerScript.audioSource.Stop();
    }

	void KryjowkaNapisy()
	{
		if (playerAudioSource1.time > 1.3f && playerAudioSource1.isPlaying == true) {
			subtitlesTextMesh.text = devilsShelterSubtitles;
		} 
	}

    // dodatkowe nagrania

    void GlosSzalas()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isWellRecording = true;
        playerAudioSource1.clip = woodRecording;
        playerAudioSource1.Play();
        playerScript.audioSource.Stop();
    }

    void SzalasNapisy()
    {
        if (playerAudioSource1.time > 0.4f && playerAudioSource1.isPlaying == true)
        {
            subtitlesTextMesh.text = woodSubtitles;
        }
    }

    void GlosStudnia()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isStableRecording = true;
        playerAudioSource1.clip = wellRecording;
        playerAudioSource1.Play();
        playerScript.audioSource.Stop();
    }

    void StudniaNapisy()
    {
        if (playerAudioSource1.time > 0.2f && playerAudioSource1.isPlaying == true)
        {
            subtitlesTextMesh.text = wellSubtitles;
        }
    }

    void GlosStajnia()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isGardenRecording = true;
        playerAudioSource1.clip = stableRecording;
        playerAudioSource1.Play();
        playerScript.audioSource.Stop();
    }

    void StajniaNapisy()
    {
        if (playerAudioSource1.time > 0.7f && playerAudioSource1.isPlaying == true)
        {
            subtitlesTextMesh.text = stableSubtitles;
        }
    }

    void GlosOgrod()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka); //
        isGardenRecording = true;
        playerAudioSource3.clip = gardenRecording;
        playerAudioSource3.Play();
        playerScript.audioSource.Stop();
    }

    void OgrodNapisy()
    {
        if (playerAudioSource3.time > 1.2f && playerAudioSource3.isPlaying == true)
        {
            subtitlesTextMesh.text = gardenSubtitles;
        }
    }

    void GlosKamping()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isSecretRoomRecording = true;
        playerAudioSource1.clip = secretRoomRecording;
        playerAudioSource1.Play();
        playerScript.audioSource.Stop();
    }

    void KampingNapisy()
    {
        if (playerAudioSource1.time > 0.2f && playerAudioSource1.time < 3.1f && playerAudioSource1.isPlaying == true)
        {
            subtitlesTextMesh.text = secretRoomSubtitles1;
        }

        else if (playerAudioSource1.time >= 3.1f && playerAudioSource1.isPlaying == true)
        {
            subtitlesTextMesh.text = secretRoomSubtitles2;
        }
    }

    void GlosUrzadzenieVictora()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isInventionRecording = true;
        playerAudioSource1.clip = inventionRecording;
        playerAudioSource1.Play();
        playerScript.audioSource.Stop();
    }

    void UrzadzenieVictoraNapisy()
    {
        if (playerAudioSource1.time > 0.3f && playerAudioSource1.isPlaying == true)
        {
            subtitlesTextMesh.text = inventionSubtitles;
        }
    }

    void GlosSzafaKorytarz()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isWardrobeCorridorRecording = true;
        playerAudioSource2.clip = wardrobeCorridorRecording;
        playerAudioSource2.Play();
        playerScript.audioSource.Stop();
    }

    void SzafaKorytarzNapisy()
    {
        if (playerAudioSource2.time > 0.2f && playerAudioSource2.isPlaying == true)
        {
            subtitlesTextMesh.text = wardrobeCorridorSubtitles;
        }
    }

    void GlosChip()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isChipRecording = true;
        playerAudioSource2.clip = chipRecording;
        playerAudioSource2.Play();
        playerScript.audioSource.Stop();
    }

    void ChipNapisy()
    {
        if (playerAudioSource2.time > 0.3f && playerAudioSource2.isPlaying == true)
        {
            subtitlesTextMesh.text = chipSubtitles;
        }
    }

    void GlosWskazowkiArtura()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isArthurTipRecording = true;
        playerAudioSource1.clip = arthurTipRecording;
        playerAudioSource1.Play();
        playerScript.audioSource.Stop();
    }

    void WskazowkiArturaNapisy()
    {
        if (playerAudioSource1.time > 0.3f && playerAudioSource1.isPlaying == true)
        {
            subtitlesTextMesh.text = arthurTipSubtitles;
        }
    }

    void GlosRoslinyPotworow()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isMonstersPlantsRecording = true;
        playerAudioSource2.clip = monstersPlantsRecording;
        playerAudioSource2.Play();
        playerScript.audioSource.Stop();
    }

    void RoslinyPotworowNapisy()
    {
        if (playerAudioSource2.time > 0.3f && playerAudioSource2.isPlaying == true)
        {
            subtitlesTextMesh.text = monstersPlantsSubtitles;
        }
    }

    void GlosZeno()
    {
        //ZrodloDzwiekuB.PlayOneShot(DzwGlosKryjowka);
        isZenoRecording = true;
        playerAudioSource2.clip = zenoRecording;
        playerAudioSource2.Play();
        playerScript.audioSource.Stop();
    }

    void ZenoNapisy()
    {
        if (playerAudioSource2.time > 0.4f && playerAudioSource2.isPlaying == true)
        {
            subtitlesTextMesh.text = zenoSubtitles;
        }
    }

    void Retrospekcja()
    {
        if (isStartRetro == false && isMidRetro == false && isEndRetro == false)
        {
            isResetRetro = false;
            mapScript.isFastTravel = false;

            if (retroEffectScript.intensity <= 1.7)
            {
                retroEffectScript.intensity += 1.3f * Time.deltaTime;
            }else
            {
                isStartRetro = true;
            }
        }else if(isStartRetro == true && isMidRetro == false && isEndRetro == false)
        {
            if (retroEffectScript.intensity >= 0.25) // wczesniej 0.45
            {
                retroEffectScript.intensity -= 1.3f * Time.deltaTime;
            }
            else
            {
                isMidRetro = true;
            }
        }

        if(retrospectionAudioSource.isPlaying == false && isStartRetro == true && isMidRetro == true && isEndRetro == false && isResetRetro == false)
        {
            if (retroEffectScript.intensity <= 1.7)
            {
                retroEffectScript.intensity += 1.3f * Time.deltaTime;
            }
            else
            {
                isEndRetro = true;
            }
        }else if (retrospectionAudioSource.isPlaying == false && isStartRetro == true && isMidRetro == true && isEndRetro == true && isResetRetro == false)
        {
            if (retroEffectScript.intensity >= 0)
            {
                retroEffectScript.intensity -= 1.3f * Time.deltaTime;
            }
            else
            {
                isResetRetro = true;
				retroEffectScript.intensity = 0;
                mapScript.isFastTravel = true;
            }
        }

    }

	void ZakonczenieGry(){

		crouchScript.GetUp ();
		crouchScript.enabled = false;
		inventoryScript.enabled = false;
		mapScript.enabled = false;
		player.gameObject.GetComponent<Player> ().enabled = false;
		flashlightScript.TurnOnFlashlight ();
		flashlightScript.enabled = false;
		playerCamera.gameObject.GetComponent<Headbobber> ().enabled = false;
		gameMenuScript.enabled = false;
		Cursor.visible = false;
		playerCamera.gameObject.GetComponent<CrosshairGUI> ().enabled = false;
		player.gameObject.GetComponent<PlayerSounds> ().enabled = false;
        healthScript.health = healthScript.maxHealth;
        uiCanvas.enabled = false;
        randomJumpscareScript.DisableMonsters();
        randomJumpscareScript.enabled = false;
		isEndGame = true;
	}
		
	public void AtakPotwora(){

		blackScreenCanvas.enabled = true;
		shelterMainMonster.gameObject.SetActive (false);
		shelterMainMonster.gameObject.GetComponent<MonsterKryjowka> ().enabled = false;
		deadAudioSource.PlayOneShot (deadSound);
		whisperAudioSource.clip = whisperSound;
		whisperAudioSource.Play ();
		isWhisper = true;
	}

}
