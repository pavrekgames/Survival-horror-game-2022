using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using TMPro;

public class VoiceActing : MonoBehaviour {

    public event Action OnStopTalking;

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

    public enum RetroEffectState
    {
        None,
        StartEffect1,
        StartEffect2,
        EndEffect1,
        EndEffect2
    }

    public RetroEffectState retroEffectState;

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

        Retrospection();

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
            StopTalking();
		} else if (playerAudioSource2.isPlaying == false && playerAudioSource2.clip != null && Time.timeScale == 1) {
			playerAudioSource2.clip = null;
            StopTalking();
        } else if (playerAudioSource3.isPlaying == false && playerAudioSource3.clip != null && Time.timeScale == 1) {
			playerAudioSource3.clip = null;
            StopTalking();
        } else if (playerAudioSource4.isPlaying == false && playerAudioSource4.clip != null && Time.timeScale == 1) {
			playerAudioSource4.clip = null;
            StopTalking();
        } else if (retrospectionAudioSource.isPlaying == false && retrospectionAudioSource.clip != null && Time.timeScale == 1) {
			retrospectionAudioSource.clip = null;
		} 

    }

    public void StopTalking()
    {
        if(OnStopTalking != null)
        {
            OnStopTalking.Invoke();
        }
    }

    void TymczasoweDane()
    {
        // glos halucynajce
        musicScript.KlimatAlice();
        //glos nagranie
        musicScript.KlimatPoKasecie2();
        // glos kryjowka
    }

    public void PlayVoice(AudioSource audioSource, AudioClip voiceRecording)
    {
        audioSource.clip = voiceRecording;
        audioSource.Play();
        playerScript.audioSource.Stop();
    }

    public void PlayRetrospection(AudioClip retroRecording)
    {
        retrospectionAudioSource.clip = bigRoomRecording;
        retrospectionAudioSource.Play();
        retroEffectState = RetroEffectState.StartEffect1;
        playerScript.audioSource.Stop();
    }

    void Retrospection()
    {
        RetroStartEffect();
        RetroEndEffect();
    }

    void RetroStartEffect()
    {
        if (retroEffectState == RetroEffectState.StartEffect1)
        {
            isResetRetro = false;
            mapScript.isFastTravel = false;

            if (retroEffectScript.intensity <= 1.7)
            {
                retroEffectScript.intensity += 1.3f * Time.deltaTime;
            }
            else
            {
                retroEffectState = RetroEffectState.StartEffect2;
            }

        }
        else if (retroEffectState == RetroEffectState.StartEffect2)
        {
            if (retroEffectScript.intensity >= 0.25)
            {
                retroEffectScript.intensity -= 1.3f * Time.deltaTime;
            }
            else
            {
                retroEffectState = RetroEffectState.EndEffect1;
            }
        }
    }

    void RetroEndEffect()
    {
        if (retrospectionAudioSource.isPlaying == false && retroEffectState == RetroEffectState.EndEffect1)
        {
            if (retroEffectScript.intensity <= 1.7)
            {
                retroEffectScript.intensity += 1.3f * Time.deltaTime;
            }
            else
            {
                retroEffectState = RetroEffectState.EndEffect2;
            }
        }
        else if (retrospectionAudioSource.isPlaying == false && retroEffectState == RetroEffectState.EndEffect2)
        {
            if (retroEffectScript.intensity >= 0)
            {
                retroEffectScript.intensity -= 1.3f * Time.deltaTime;
            }
            else
            {
                retroEffectState = RetroEffectState.None;
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
