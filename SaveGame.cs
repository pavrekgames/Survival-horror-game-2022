using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {

	private Transform player;
	private Transform flashlight;
	private Animator animator;
	private Tasks tasksScript;
	private Inventory inventoryScript;
	private VoiceActing voiceActingScript;
	private GameManager gameManagerScript;
	private Menu gameMenuScript;
    private BeginGame beginGameScript;

	public bool Wczytano_ok = false;

	// punkty zapisu

	public bool PoczatekZapis_ok = false;
	public bool DomZapis_ok = false;
	public bool StudniaZapis_ok = false;
	public bool OgrodZapis_ok = false;
	public bool KosciZapis_ok = false;
	public bool IdzAliceZapis_ok = false;
	public bool DomAliceZapis_ok = false;
	public bool BrakujaceKoloZapis_ok = false;
	public bool NaprawionyKluczZapis_ok = false;
	public bool FabrykaZapis_ok = false;
	public bool FabrykaZapis2_ok = false;
	public bool LewyPotokZapis_ok = false;
	public bool KombinerkiZapis_ok = false;
	public bool KukurydzaZapis_ok = false;
	public bool KluczSzafaKorytarzZapis_ok = false;
	public bool IdzSzlakZapis_ok = false;
    public bool PrzedPajakJumpscareZapis_ok = false;
    public bool PrzedostanSieZapis_ok = false;
	public bool ObozTomZapis_ok = false;
	public bool TomGoraZapis_ok = false;
	public bool MonsterTomZapis_ok = false;
	public bool IdzWawozZapis_ok = false;
	public bool PrzedStevenZapis_ok = false;
	public bool MonsterMiesoZapis_ok = false;
	public bool GrzybZapis_ok = false;
	public bool SzopaStevenZapis_ok = false;
	public bool PaulZapis_ok = false;
	public bool PaulGoraZapis_ok = false;
	public bool ChatkaZapis_ok = false;
	public bool KryjowkaZapis_ok = false;

	void Start () {
		
		player = GameObject.Find ("Player").transform;
		flashlight = GameObject.Find ("Latarka").transform;
		animator = GameObject.Find ("ZapisKomunikat").GetComponent<Animator> ();
		tasksScript = GameObject.Find ("Player").GetComponent<Tasks> ();
		inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();
		voiceActingScript = GameObject.Find ("Player").GetComponent<VoiceActing> ();
		gameManagerScript = GameObject.Find ("Player").GetComponent<GameManager> ();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
        beginGameScript = GameObject.Find("Player").GetComponent<BeginGame>();
    }
	

	void Update () {

		if (PoczatekZapis_ok == false && beginGameScript.Koniec_ok == true) {
			PoczatekZapis_ok = true;
			Zapisz ();
		}

		if(StudniaZapis_ok == false && tasksScript.isWellStonesTask == true){
			StudniaZapis_ok = true;
			Zapisz ();
		}

		if(KosciZapis_ok == false && tasksScript.isBonesTask == true){
			KosciZapis_ok = true;
			Zapisz ();
		}

		if(IdzAliceZapis_ok == false && tasksScript.isGoToAliceTask == true){
			IdzAliceZapis_ok = true;
			Zapisz ();
		}

	

		if(KukurydzaZapis_ok == false && tasksScript.isCornfieldDoorLocked == false){
			KukurydzaZapis_ok = true;
			Zapisz ();
		}

		

		if(IdzSzlakZapis_ok == false && tasksScript.isGoToTrialTask == true){
			IdzSzlakZapis_ok = true;
			Zapisz ();
		}

        if (PrzedPajakJumpscareZapis_ok == false && tasksScript.isGoTrailTask == true)
        {
            PrzedPajakJumpscareZapis_ok = true;
            Zapisz();
        }

        if (PrzedostanSieZapis_ok == false && tasksScript.isGetToTomRoadTask == true) {
			PrzedostanSieZapis_ok = true;
			Zapisz ();
		}

		if (TomGoraZapis_ok == false && tasksScript.isRavineTask == true) {
			TomGoraZapis_ok = true;
			Zapisz ();
		} 

		if (IdzWawozZapis_ok == false && tasksScript.isGoRavineTask == true) {
			IdzWawozZapis_ok = true;
			Zapisz ();
		}

	

        if (SzopaStevenZapis_ok == false && voiceActingScript.isStevenShedRecording == true && voiceActingScript.isEndRetro == true && voiceActingScript.retroEffectScript.intensity == 0)
        {
            SzopaStevenZapis_ok = true;
            Zapisz();
        }

        if (PaulGoraZapis_ok == false && tasksScript.isHutTask == true) {
			PaulGoraZapis_ok = true;
			Zapisz ();
		}

		if (ChatkaZapis_ok == false && tasksScript.isDevilsBrookTask == true) {
			ChatkaZapis_ok = true;
			Zapisz ();
		}

	}

	public void Zapisz(){


			animator.SetTrigger ("Zapis");

			FileStream Plik = File.Create (Application.persistentDataPath + "/PlayerSave.pav");

			GraczDane Dane = new GraczDane ();
			Dane.NazwaSceny = SceneManager.GetActiveScene ().name;
			//Dane.Zdrowie = Gracz.GetComponent<Zdrowie> ().AktualneZdrowie;
			Dane.Pozycja = new Vector3Gracz (player.GetComponent<Transform> ().position);
			Dane.Obrot = new QuaternionGracz (player.GetComponent<Transform> ().rotation);

			Dane.PoczatekZapis_ok = PoczatekZapis_ok;
			Dane.DomZapis_ok = DomZapis_ok;
			Dane.StudniaZapis_ok = StudniaZapis_ok;
			Dane.OgrodZapis_ok = OgrodZapis_ok;
			Dane.KosciZapis_ok = KosciZapis_ok;
			Dane.IdzAliceZapis_ok = IdzAliceZapis_ok;
			Dane.DomAliceZapis_ok = DomAliceZapis_ok;
			Dane.BrakujaceKoloZapis_ok = BrakujaceKoloZapis_ok;
			Dane.NaprawionyKluczZapis_ok = NaprawionyKluczZapis_ok;
			Dane.FabrykaZapis_ok = FabrykaZapis_ok;
			Dane.FabrykaZapis2_ok = FabrykaZapis2_ok;
			Dane.LewyPotokZapis_ok = LewyPotokZapis_ok;
			Dane.KombinerkiZapis_ok = KombinerkiZapis_ok;
			Dane.KukurydzaZapis_ok = KukurydzaZapis_ok;
			Dane.KluczSzafaKorytarzZapis_ok = KluczSzafaKorytarzZapis_ok;
			Dane.IdzSzlakZapis_ok = IdzSzlakZapis_ok;
            Dane.PrzedPajakJumpscareZapis_ok = PrzedPajakJumpscareZapis_ok;
			Dane.PrzedostanSieZapis_ok = PrzedostanSieZapis_ok;
			Dane.ObozTomZapis_ok = ObozTomZapis_ok;
			Dane.TomGoraZapis_ok = TomGoraZapis_ok;
			Dane.MonsterTomZapis_ok = MonsterTomZapis_ok;
			Dane.IdzWawozZapis_ok = IdzWawozZapis_ok;
			Dane.PrzedStevenZapis_ok = PrzedStevenZapis_ok;
			Dane.MonsterMiesoZapis_ok = MonsterMiesoZapis_ok;
			Dane.GrzybZapis_ok = GrzybZapis_ok;
			Dane.SzopaStevenZapis_ok = SzopaStevenZapis_ok;
			Dane.PaulZapis_ok = PaulZapis_ok;
			Dane.PaulGoraZapis_ok = PaulGoraZapis_ok;
			Dane.ChatkaZapis_ok = ChatkaZapis_ok;
			Dane.KryjowkaZapis_ok = KryjowkaZapis_ok;

			// gracz
			Dane.MaxStamina = player.GetComponent<Player> ().maxStamina;
			Dane.RegeneracjaStaminy = player.GetComponent<Player> ().staminaRegenerationFactor;

			// ekwipunek
			Dane.IloscSecretItems = player.GetComponent<Inventory> ().secretItemsCount;
			Dane.IloscSecretPlaces = player.GetComponent<Inventory> ().secretPlacesCount;
			Dane.IloscNiebieskieZiola = player.GetComponent<Inventory> ().blueHerbsCount;
			Dane.IloscZieloneZiola = player.GetComponent<Inventory> ().greenHerbsCount;
			Dane.IloscMiksturaZdrowie = player.GetComponent<Inventory> ().healthPotsCount;
			Dane.IloscMiksturaStamina = player.GetComponent<Inventory> ().staminaPotsCount;
            Dane.IloscFiolek = player.GetComponent<Inventory> ().vialsCount;

			Dane.SPGrobRocky_ok = player.GetComponent<Inventory> ().isRockyGraveSP;
			Dane.SPCmentarzZwierzat_ok = player.GetComponent<Inventory> ().isAnimalCementarySP;
			Dane.SPOgrodSimona_ok = player.GetComponent<Inventory> ().isSimonGardenSP;
			Dane.SPObozToma_ok = player.GetComponent<Inventory> ().isTomCampSP;
			Dane.SPKryjowkaDiably_ok = player.GetComponent<Inventory> ().isDevilsShelterSP;
			Dane.SPCmentarzWojna_ok = player.GetComponent<Inventory> ().isWarCementarySP;
			Dane.SPDomek_ok = player.GetComponent<Inventory> ().isHutSP;
			Dane.SPPiwnica_ok = player.GetComponent<Inventory> ().isBasementSP;
			Dane.SPPoleGrzybowe_ok = player.GetComponent<Inventory> ().isMushroomFieldSP;
			Dane.SPCiemnyLas_ok = player.GetComponent<Inventory> ().isDarkForestSP;
			Dane.SPWiezaKosci_ok = player.GetComponent<Inventory> ().isBonesTowerSP;
			Dane.SPNozowaArena_ok = player.GetComponent<Inventory> ().isKnifeArenaSP;
			Dane.SPJaskinia_ok = player.GetComponent<Inventory> ().isCaveSP;
			Dane.SPPomnik_ok = player.GetComponent<Inventory> ().isMonumentSP;
			Dane.SPStatekKosmiczny_ok = player.GetComponent<Inventory> ().isSpaceshipSP;

		
        
        
			
         
			
        
            Dane.IloscOdznak = player.GetComponent<Inventory> ().badgesCount;
            Dane.IloscWskazowek = player.GetComponent<Inventory> ().tipsCount;
            Dane.IloscFoto = player.GetComponent<Inventory> ().photosCount;
            Dane.IloscUmiejetnosci = player.GetComponent<Inventory> ().skillsCount;

			// glos bohatera
			Dane.GlosPoczatek_ok = player.GetComponent<VoiceActing> ().isBeginGameRecording;
			Dane.GlosOgrodzenie_ok = player.GetComponent<VoiceActing> ().isFenceRecording;
			Dane.GlosSwiatloDomu_ok = player.GetComponent<VoiceActing> ().isHouseLightRecording;
			Dane.GlosKuchnia_ok = player.GetComponent<VoiceActing> ().isKitchenRecording;
			Dane.GlosDuzyPokoj_ok = player.GetComponent<VoiceActing> ().isBigRoomRecording;
			Dane.GlosPokojArtura_ok = player.GetComponent<VoiceActing> ().isArthurRoomRecording;
			Dane.GlosSzopaNarzedzia_ok = player.GetComponent<VoiceActing> ().isToolShedRecording;
			Dane.GlosDomAlice_ok = player.GetComponent<VoiceActing> ().isAliceHouseRecording;
			Dane.GlosHalucynacje_ok = player.GetComponent<VoiceActing> ().isHallunsRecording;
			Dane.GlosWarsztat_ok = player.GetComponent<VoiceActing> ().isWorkshopRecording;
			Dane.GlosLewyPotok_ok = player.GetComponent<VoiceActing> ().isLeftBrookRecording;
			Dane.GlosNotatkaAnna_ok = player.GetComponent<VoiceActing> ().isAnnaNoteRecording;
			Dane.GlosKombinerki_ok = player.GetComponent<VoiceActing> ().isPliersRecording;
			Dane.GlosKukurydza_ok = player.GetComponent<VoiceActing> ().isCornfieldRecording;
			Dane.GlosStaraSzopa_ok = player.GetComponent<VoiceActing> ().isOldShedRecording;
			Dane.GlosSiekiera_ok = player.GetComponent<VoiceActing> ().isAxeRecording;
			Dane.GlosNagranie_ok = player.GetComponent<VoiceActing> ().isAfterCasseteRecording;
			Dane.GlosKsiazki_ok = player.GetComponent<VoiceActing> ().isBooksRecording;
			Dane.GlosWawoz_ok = player.GetComponent<VoiceActing> ().isRavineRecording;
			Dane.GlosDomStevena_ok = player.GetComponent<VoiceActing> ().isStevenHouseRecording;
			Dane.GlosEliksir_ok = player.GetComponent<VoiceActing> ().isAcidRecording;
			Dane.GlosSzopaSteven_ok = player.GetComponent<VoiceActing> ().isStevenShedRecording;
			Dane.GlosPotokDiably_ok = player.GetComponent<VoiceActing> ().isDevilsBrookRecording;
			Dane.GlosKryjowka_ok = player.GetComponent<VoiceActing> ().isDevilsShelterRecording;

            Dane.GlosSzalas_ok = player.GetComponent<VoiceActing>().isWellRecording;
            Dane.GlosStudnia_ok = player.GetComponent<VoiceActing>().isStableRecording;
            Dane.GlosStajnia_ok = player.GetComponent<VoiceActing>().isGardenRecording;
            Dane.GlosOgrod_ok = player.GetComponent<VoiceActing>().isGardenRecording;
            Dane.GlosKamping_ok = player.GetComponent<VoiceActing>().isSecretRoomRecording;
            Dane.GlosUrzadzenieVictora_ok = player.GetComponent<VoiceActing>().isInventionRecording;
            Dane.GlosSzafaKorytarz_ok = player.GetComponent<VoiceActing>().isWardrobeCorridorRecording;
            Dane.GlosChip_ok = player.GetComponent<VoiceActing>().isChipRecording;
            Dane.GlosWskazowkiArtura_ok = player.GetComponent<VoiceActing>().isArthurTipRecording;
            Dane.GlosRoslinyPotworow_ok = player.GetComponent<VoiceActing>().isMonstersPlantsRecording;
            Dane.GlosZeno_ok = player.GetComponent<VoiceActing>().isZenoRecording;


            Dane.RetroDuzyPokoj_ok = player.GetComponent<VoiceActing> ().isRetroBigRoomRecording;
			Dane.RetroPokojArtura_ok = player.GetComponent<VoiceActing> ().isRetroArthurRoomRecording;
			Dane.RetroSzopaNarzedzia_ok = player.GetComponent<VoiceActing> ().isRetroToolShedRecording;
			Dane.RetroDomAlice_ok = player.GetComponent<VoiceActing> ().isRetroAliceHouseRecording;
			Dane.RetroWarsztat_ok = player.GetComponent<VoiceActing> ().isRetroWorkshopRecording;
			Dane.RetroKukurydza_ok = player.GetComponent<VoiceActing> ().isRetroCornfieldRecording;
			Dane.RetroStaraSzopa_ok = player.GetComponent<VoiceActing> ().isRetroOldShedRecording;
			Dane.RetroKsiazki_ok = player.GetComponent<VoiceActing> ().isRetroBooksRecording;
			Dane.RetroDomStevena_ok = player.GetComponent<VoiceActing> ().isRetroStevenHouseRecording;
			Dane.RetroSzopaSteven_ok = player.GetComponent<VoiceActing> ().isRetroStevenShedRecording;

			Dane.PoczatekGryNap_ok = player.GetComponent<VoiceActing> ().isBeginGameSubtitles;
			Dane.OgrodzenieNap_ok = player.GetComponent<VoiceActing> ().isFenceSubtitles;
			Dane.SwiatloDomuNap_ok = player.GetComponent<VoiceActing> ().isHouseLightSubtitles;
			Dane.KuchniaNap_ok = player.GetComponent<VoiceActing> ().isKitchenSubtitles;
			Dane.DuzyPokojNap_ok = player.GetComponent<VoiceActing> ().isBigRoomSubtitles;
			Dane.PokojArthuraNap_ok = player.GetComponent<VoiceActing> ().isArthurRoomSubtitles;
			Dane.SzopaNarzedziaNap_ok = player.GetComponent<VoiceActing> ().isToolShedSubtitles;
			Dane.Kaseta1Nap_ok = player.GetComponent<VoiceActing> ().isCassete1Subtitles;
			Dane.DomAliceNap_ok = player.GetComponent<VoiceActing> ().isAliceHouseSubtitles;
			Dane.HalucynacjeNap_ok = player.GetComponent<VoiceActing> ().isHallunsSubtitles;
			Dane.WarsztatNap_ok = player.GetComponent<VoiceActing> ().isWorkshopSubtitles;
			Dane.LewyPotokNap_ok = player.GetComponent<VoiceActing> ().isLeftBrookSubtitles;
			Dane.NotatkaAnnaNap_ok = player.GetComponent<VoiceActing> ().isAnnaNoteSubtitles;
			Dane.KombinerkiNap_ok = player.GetComponent<VoiceActing> ().isPliersSubtitles;
			Dane.KukurydzaNap_ok = player.GetComponent<VoiceActing> ().isCornfieldSubtitles;
			Dane.SiekieraNap_ok = player.GetComponent<VoiceActing> ().isAxeSubtitles;
			Dane.StaraSzopaNap_ok = player.GetComponent<VoiceActing> ().isOldShedSubtitles;
			Dane.Kaseta2Nap_ok = player.GetComponent<VoiceActing> ().isCassete2Subtitles;
			Dane.NagranieNap_ok = player.GetComponent<VoiceActing> ().isAfterCasseteSubtitles;
			Dane.KsiazkiNap_ok = player.GetComponent<VoiceActing> ().isBooksSubtitles;
			Dane.Kaseta3Nap_ok = player.GetComponent<VoiceActing> ().isCassete3Subtitles;
			Dane.WawozNap_ok = player.GetComponent<VoiceActing> ().isRavineSubtitles;
			Dane.Kaseta4Nap_ok = player.GetComponent<VoiceActing> ().isCassete4Subtitles;
			Dane.DomStevenaNap_ok = player.GetComponent<VoiceActing> ().isStevenHouseSubtitles;
			Dane.EliksirNap_ok = player.GetComponent<VoiceActing> ().isAcidSubtitles;
			Dane.SzopaStevenNap_ok = player.GetComponent<VoiceActing> ().isStevenShedSubtitles;
			Dane.PotokDiablyNap_ok = player.GetComponent<VoiceActing> ().isDevilsBrookSubtitles;
			Dane.Kaseta5Nap_ok = player.GetComponent<VoiceActing> ().isCassete5Subtitles;
			Dane.KryjowkaNap_ok = player.GetComponent<VoiceActing> ().isDevilsShelterSubtitles;

            Dane.SzalasNap_ok = player.GetComponent<VoiceActing>().isWoodSubtitles;
            Dane.StudniaNap_ok = player.GetComponent<VoiceActing>().isWellSubtitles;
            Dane.StajniaNap_ok = player.GetComponent<VoiceActing>().isStableSubtitles;
            Dane.OgrodNap_ok = player.GetComponent<VoiceActing>().isGardenSubtitles;
            Dane.KampingNap_ok = player.GetComponent<VoiceActing>().isSecretRoomSubtitles;
            Dane.UrzadzenieVictoraNap_ok = player.GetComponent<VoiceActing>().isInventionSubtitles;
            Dane.SzafaKorytarzNap_ok = player.GetComponent<VoiceActing>().isWardrobeCorridorSubtitles;
            Dane.ChipNap_ok = player.GetComponent<VoiceActing>().isChipSubtitles;
            Dane.WskazowkiArturaNap_ok = player.GetComponent<VoiceActing>().isArthurTipSubtitles;
            Dane.RoslinyPotworowNap_ok = player.GetComponent<VoiceActing>().isMonstersPlantsSubtitles;
            Dane.ZenoNap_ok = player.GetComponent<VoiceActing>().isZenoSubtitles;

        // jumpscare
            Dane.MonsterPotok1_ok = player.GetComponent<Jumpscare> ().isBrookMonster1_On;
            Dane.MonsterPotok1Wyl_ok = player.GetComponent<Jumpscare> ().isBrookMonster1_Off;
			Dane.MonsterKukurydza_ok = player.GetComponent<Jumpscare> ().isCornfieldMonster;
			Dane.MonsterKorytarz_ok = player.GetComponent<Jumpscare> ().isCorridorMonster;
			Dane.MonsterKukurydza2_ok = player.GetComponent<Jumpscare> ().isCornfieldMonster2;
			Dane.MonsterKoryto_ok = player.GetComponent<Jumpscare> ().isChannelMonster;
			Dane.MonstersLasMieso_ok = player.GetComponent<Jumpscare> ().isMeatMonsters;
			Dane.MonsterPokojZachod_ok = player.GetComponent<Jumpscare> ().isPaulRoomMonster;
			Dane.MonsterDrzwiZachod_ok = player.GetComponent<Jumpscare> ().isPaulDoorMonster;
			Dane.MonsterOgrod_ok = player.GetComponent<Jumpscare> ().isGardenMonster;
			Dane.MonsterWarsztat_ok = player.GetComponent<Jumpscare> ().isWorkshopMonster;
			Dane.MonsterDynia_ok = player.GetComponent<Jumpscare> ().isPumpkinMonster_On;
			Dane.MonsterDyniaWylacz_ok = player.GetComponent<Jumpscare> ().isPumpkinMonster_Off;
			Dane.MonsterOpuszczony1_ok = player.GetComponent<Jumpscare> ().isAbandonedMonster;
			Dane.MonsterSzopa1_ok = player.GetComponent<Jumpscare> ().isShedMonster1;
			Dane.MonsterTom_ok = player.GetComponent<Jumpscare> ().isTomMonster;
			Dane.MonsterRoslina_ok = player.GetComponent<Jumpscare> ().isPlantMonster;
			Dane.MonsterKrzaki_ok = player.GetComponent<Jumpscare> ().isBushMonster_On;
			Dane.MonsterKrzakiWyl_ok = player.GetComponent<Jumpscare> ().isBushMonster_Off;
			Dane.MonsterZachodGora_ok = player.GetComponent<Jumpscare> ().isPaulDownstairsMonster;
			Dane.MonsterSzopaSteven1_ok = player.GetComponent<Jumpscare> ().isStevenShedMonster1;
			Dane.MonsterSzopaSteven2_ok = player.GetComponent<Jumpscare> ().isStevenShedMonster2;
			Dane.StopCzasOpuszczony_ok = player.GetComponent<Jumpscare> ().isAbandonedMonsterStop;
            Dane.MonsterPoczatek_ok = player.GetComponent<Jumpscare> ().isBeginMonster;
            Dane.MonsterStajnia_ok = player.GetComponent<Jumpscare> ().isStableMonster;
            Dane.MonsterKamping_ok = player.GetComponent<Jumpscare> ().isSecretRoomMonster;
            Dane.WilkPoczatek_ok = player.GetComponent<Jumpscare> ().isBeginWolves;
            Dane.PajakJumpscare1_ok = player.GetComponent<Jumpscare> ().isJumpscareSpider1;
            Dane.PajakJumpscare2_ok = player.GetComponent<Jumpscare> ().isJumpscareSpider2;
            Dane.Pajak3_ok = player.GetComponent<Jumpscare> ().isSpider3_On;
            Dane.Pajak3Wylacz_ok = player.GetComponent<Jumpscare> ().isSpider3_Off;
            Dane.Pajak4_ok = player.GetComponent<Jumpscare> ().isSpider4;

			// komunikat
			Dane.KomSwiatlo_ok = player.GetComponent<Notifications> ().isLightNotification;
			Dane.KomSprint_ok = player.GetComponent<Notifications> ().isSprintNotification;
			Dane.KomSwiatlo2_ok = player.GetComponent<Notifications> ().isLight2Notification;
			Dane.KomZadaniaInfo_ok = player.GetComponent<Notifications> ().isTaskInfoNotification;
			Dane.KomMapa_ok = player.GetComponent<Notifications> ().isMapNotification;
			Dane.KomKucanie_ok = player.GetComponent<Notifications> ().isCrouchNotification;
            Dane.KomDrzwiWskazowka_ok = player.GetComponent<Notifications>().isDoorNotification;
            Dane.KomZiola_ok = player.GetComponent<Notifications>().isHerbsNotification;
            Dane.KomZapis_ok = player.GetComponent<Notifications>().isSaveNotification;
            Dane.KomPodnoszenie_ok = player.GetComponent<Notifications>().isDragNotification;
            Dane.KomPchanie_ok = player.GetComponent<Notifications>().isPushNotification;
            Dane.KomSecret_ok = player.GetComponent<Notifications>().isSecretNotification;
            Dane.KomItems_ok = player.GetComponent<Notifications>().isItemsNotification;
            Dane.KomInventory_ok = player.GetComponent<Notifications>().isInventoryNotification;
            Dane.InfoBaterie_ok = player.GetComponent<Notifications> ().isBatteriesNotification;
			Dane.InfoChip_ok = player.GetComponent<Notifications> ().isChipNotification;
			Dane.JestKaseta_ok = player.GetComponent<Notifications> ().isCasseteNotification;
			Dane.JestKaseta3_ok = player.GetComponent<Notifications> ().isCassete3Notification;

			// latarka
			Dane.PromienSwiatla = flashlight.GetComponent<Flashlight> ().lightRange;
			Dane.Latarka_ok = flashlight.GetComponent<Flashlight> ().isFlashlightOn;

			// zapis muzyki

			//Dane.WylaczMuzyke_ok = Gracz.GetComponent<Muzyka> ().WylaczMuzyke_ok;
			Dane.WylaczSwiatloDomu_ok = player.GetComponent<Music> ().isHouseLightMusicOff;
			Dane.WylaczWarsztatSimon_ok = player.GetComponent<Music> ().isSimonWorkshopMusicOff;
			Dane.WylaczStaraSzopa_ok = player.GetComponent<Music> ().isOldShedMusic2Off;
			Dane.WylaczPoTom_ok = player.GetComponent<Music> ().isAfterTomMusicOff;
            Dane.WylaczStaraSzopaDreszcz_ok = player.GetComponent<Music> ().isOldShedMusicOff;

            Dane.MuzykaPoczatek_ok = player.GetComponent<Music> ().isBeginMusic;
            Dane.MuzykaPoczatekStop_ok = player.GetComponent<Music> ().isBeginMonsterMusicStop;
            Dane.MuzykaMonsterPoczatek_ok = player.GetComponent<Music> ().isBeginMonsterMusic;
			Dane.MuzykaPoWilku_ok = player.GetComponent<Music> ().isAfterWolfMusic;
			Dane.NiepokojPrzedDomem_ok = player.GetComponent<Music> ().isBehindHouseMusic;
			Dane.NiepokojKuchnia_ok = player.GetComponent<Music> ().isKitchenMusic;
			Dane.NiepokojPokojUncle_ok = player.GetComponent<Music> ().isUncleRoomMusic;
			Dane.MuzykaTloStop_ok = player.GetComponent<Music> ().isMusicStop;
			Dane.KlimatSzopaNarzedzia_ok = player.GetComponent<Music> ().isToolShedMusic;
			Dane.KlimatStudnia_ok = player.GetComponent<Music> ().isWellMusic;
			Dane.NiepokojStudnia_ok = player.GetComponent<Music> ().isWellAnxiousMusic;
			Dane.NiepokojStajnia_ok = player.GetComponent<Music> ().isStableMusic;
			Dane.KlimatOgrod_ok = player.GetComponent<Music> ().isGardenMusic;
			Dane.KlimatKosci_ok = player.GetComponent<Music> ().isBonesMusic;
			Dane.NiepokojAlice_ok = player.GetComponent<Music> ().isAliceMusic;
			Dane.KlimatSzopaAlice_ok = player.GetComponent<Music> ().isAliceShedMusic;
			Dane.NiepokojWarsztat_ok = player.GetComponent<Music> ().isWorkshopMusic;
			Dane.KlimatWarsztatSimon_ok = player.GetComponent<Music> ().isWorkshopSimonMusic;
			Dane.KlimatCmentarzZwierzat_ok = player.GetComponent<Music> ().isAnimalCemetaryMusic;
			Dane.NiepokojSalonAlice_ok = player.GetComponent<Music> ().isAliceRoomMusic;
			Dane.NiepokojSzopa_ok = player.GetComponent<Music> ().isShedMusic;
			Dane.KlimatStaraSzopa_ok = player.GetComponent<Music> ().isOldShedMusic;
			Dane.KlimatPrzedTom_ok = player.GetComponent<Music> ().isBeforeTomMusic;
			Dane.NiepokojTom_ok = player.GetComponent<Music> ().isTomMusic;
			Dane.KlimatSala_ok = player.GetComponent<Music> ().isTomHallMusic;
			Dane.NiepokojTom2_ok = player.GetComponent<Music> ().isTom2Music;
			Dane.KlimatKsiazki_ok = player.GetComponent<Music> ().isBooksMusic;
			Dane.NiepokojTom3_ok = player.GetComponent<Music> ().isTom3Music;
			Dane.KlimatKukurydza_ok = player.GetComponent<Music> ().isCornfieldMusic;
			Dane.KlimatOboz_ok = player.GetComponent<Music> ().isTomCampMusic;
			Dane.KlimatTomGora_ok = player.GetComponent<Music> ().isTomUpstairsMusic;
			Dane.KlimatTomGora2_ok = player.GetComponent<Music> ().isTomUpstairs2Music;
			Dane.KlimatPoTom_ok = player.GetComponent<Music> ().isAfterTomMusic;
			Dane.KlimatKarmnik_ok = player.GetComponent<Music> ().isFeederMusic;
			Dane.KlimatPrzedSteven_ok = player.GetComponent<Music> ().isBeforeStevenMusic;
			Dane.KlimatSteven_ok = player.GetComponent<Music> ().isStevenMusic;
			Dane.KlimatMieso_ok = player.GetComponent<Music> ().isMeatMusic;
			Dane.KlimatStevenGora_ok = player.GetComponent<Music> ().isStevenUpstairsMusic;
			Dane.NiepokojSzopaSteven_ok = player.GetComponent<Music> ().isStevenShedMusic;
			Dane.KlimatPrzedPaul_ok = player.GetComponent<Music> ().isBeforePaulMusic;
			Dane.NiepokojPaul_ok = player.GetComponent<Music> ().isPaulMusic;
			Dane.KlimatPaulGora_ok = player.GetComponent<Music> ().isPaulUpstairsMusic;
			Dane.KlimatChatka_ok = player.GetComponent<Music> ().isHutMusic;
			Dane.KlimatMonsterGora1_ok = player.GetComponent<Music> ().isMonsterUpstairsMusic;
			Dane.KlimatMonsterGora2_ok = player.GetComponent<Music> ().isMonsterUpstairs2Music;
			Dane.KlimatPrzedKryjowka_ok = player.GetComponent<Music> ().isBeforeShelterMusic;
			Dane.KlimatKryjowka_ok = player.GetComponent<Music> ().isShelterMusic;
			Dane.KlimatKryjowka2_ok = player.GetComponent<Music> ().isShelter2Music;
			Dane.MuzykaKoniec_ok = player.GetComponent<Music> ().isEndGameMusic;
			Dane.PotworOpuszczonyPiwnica_ok = player.GetComponent<Music> ().isBasementMonsterMusic;
            Dane.MuzykaDuzyR_ok = player.GetComponent<Music> ().isBigRoomMusic;
            Dane.MuzykaPotokLewySkrzypce_ok = player.GetComponent<Music> ().isLeftBrookMusic;
            Dane.KlimatKukurydza1_ok = player.GetComponent<Music> ().isCornfield1Music;
            Dane.KlimatPoLatarka_ok = player.GetComponent<Music> ().isAfterFlashlightMusic;
            Dane.KlimatDrzwiBabcia_ok = player.GetComponent<Music> ().isGrandmaDoorMusic;
	
			// notatki
            Dane.IloscNotatek = player.GetComponent<Notes> ().notesCount;
			Dane.Notatka1_ok = player.GetComponent<Notes> ().isNote1;
			Dane.Notatka2_ok = player.GetComponent<Notes> ().isNote2;
			Dane.Notatka3_ok = player.GetComponent<Notes> ().isNote3;
			Dane.Notatka4_ok = player.GetComponent<Notes> ().isNote4;
			Dane.Notatka5_ok = player.GetComponent<Notes> ().isNote5;
			Dane.Notatka6_ok = player.GetComponent<Notes> ().isNote6;
			Dane.Notatka7_ok = player.GetComponent<Notes> ().isNote7;
			Dane.Notatka8_ok = player.GetComponent<Notes> ().isNote8;
			Dane.Notatka9_ok = player.GetComponent<Notes> ().isNote9;
			Dane.Notatka10_ok = player.GetComponent<Notes> ().isNote10;
			Dane.Notatka11_ok = player.GetComponent<Notes> ().isNote11;
			Dane.Notatka12_ok = player.GetComponent<Notes> ().isNote12;
			Dane.Notatka13_ok = player.GetComponent<Notes> ().isNote13;
			Dane.Notatka14_ok = player.GetComponent<Notes> ().isNote14;
			Dane.Notatka15_ok = player.GetComponent<Notes> ().isNote15;
			Dane.Notatka16_ok = player.GetComponent<Notes> ().isNote16;
			Dane.Notatka17_ok = player.GetComponent<Notes> ().isNote17;
			Dane.Notatka18_ok = player.GetComponent<Notes> ().isNote18;
			Dane.Notatka19_ok = player.GetComponent<Notes> ().isNote19;
			Dane.Notatka20_ok = player.GetComponent<Notes> ().isNote20;
			Dane.Notatka21_ok = player.GetComponent<Notes> ().isNote21;
			Dane.Notatka22_ok = player.GetComponent<Notes> ().isNote22;
			Dane.Notatka23_ok = player.GetComponent<Notes> ().isNote23;
			Dane.Notatka24_ok = player.GetComponent<Notes> ().isNote24;
			Dane.Notatka25_ok = player.GetComponent<Notes> ().isNote25;
			Dane.Notatka26_ok = player.GetComponent<Notes> ().isNote26;
			Dane.Notatka27_ok = player.GetComponent<Notes> ().isNote27;
			Dane.Notatka28_ok = player.GetComponent<Notes> ().isNote28;
			Dane.Notatka29_ok = player.GetComponent<Notes> ().isNote29;
			Dane.Notatka30_ok = player.GetComponent<Notes> ().isNote30;
			Dane.Notatka31_ok = player.GetComponent<Notes> ().isNote31;
			Dane.Notatka32_ok = player.GetComponent<Notes> ().isNote32;
			Dane.Notatka33_ok = player.GetComponent<Notes> ().isNote33;
			Dane.Notatka34_ok = player.GetComponent<Notes> ().isNote34;
			Dane.Notatka35_ok = player.GetComponent<Notes> ().isNote35;
			Dane.Notatka36_ok = player.GetComponent<Notes> ().isNote36;
			Dane.Notatka37_ok = player.GetComponent<Notes> ().isNote37;
			Dane.Notatka38_ok = player.GetComponent<Notes> ().isNote38;
			Dane.Notatka39_ok = player.GetComponent<Notes> ().isNote39;
			Dane.Notatka40_ok = player.GetComponent<Notes> ().isNote40;
			Dane.Notatka41_ok = player.GetComponent<Notes> ().isNote41;
			Dane.Notatka42_ok = player.GetComponent<Notes> ().isNote42;
			Dane.Notatka43_ok = player.GetComponent<Notes> ().isNote43;
			Dane.Notatka44_ok = player.GetComponent<Notes> ().isNote44;
			Dane.Notatka45_ok = player.GetComponent<Notes> ().isNote45;
			Dane.Notatka46_ok = player.GetComponent<Notes> ().isNote46;
			Dane.Notatka47_ok = player.GetComponent<Notes> ().isNote47;
			Dane.Notatka48_ok = player.GetComponent<Notes> ().isNote48;
			Dane.Notatka49_ok = player.GetComponent<Notes> ().isNote49;
			Dane.Notatka50_ok = player.GetComponent<Notes> ().isNote50;
			Dane.Notatka51_ok = player.GetComponent<Notes> ().isNote51;
			Dane.Notatka52_ok = player.GetComponent<Notes> ().isNote52;
			Dane.Notatka53_ok = player.GetComponent<Notes> ().isNote53;
			Dane.Notatka54_ok = player.GetComponent<Notes> ().isNote54;
			Dane.NotatkaLisy_ok = player.GetComponent<Notes> ().isFoxNote;
			Dane.ZdjecieDrewno_ok = player.GetComponent<Notes> ().isWoodPhoto;
			Dane.ZdjecieZeno_ok = player.GetComponent<Notes> ().isZenoPhoto;
			Dane.NotatkaZakupy_ok = player.GetComponent<Notes> ().isShoppingNote;
			Dane.NotatkaCytat1_ok = player.GetComponent<Notes> ().isQuote1Note;
			Dane.RysunekKukurydza_ok = player.GetComponent<Notes> ().isCornfieldPicture;
			Dane.NotatkaPotokLewy_ok = player.GetComponent<Notes> ().isLeftBrookNote;
			Dane.NotatkaGrzyby_ok = player.GetComponent<Notes> ().isMushroomNote;
			Dane.ZdjeciePotok3_ok = player.GetComponent<Notes> ().isBrookPhoto3;
			Dane.ZdjeciePotok2_ok = player.GetComponent<Notes> ().isBrookPhoto2;
			Dane.ZdjeciePotok1_ok = player.GetComponent<Notes> ().isBrookPhoto1;
			Dane.RysunekSimon_ok = player.GetComponent<Notes> ().isSimonPicture;
			Dane.NotatkaRap_ok = player.GetComponent<Notes> ().isRapNote;
			Dane.ZdjecieAmbona_ok = player.GetComponent<Notes> ().isTowerPhoto;
			Dane.ZdjecieStudnia_ok = player.GetComponent<Notes> ().isWellPhoto;
			Dane.NotatkaCytat2_ok = player.GetComponent<Notes> ().isQuote2Note;
			Dane.ZdjeciePomnik_ok = player.GetComponent<Notes> ().isMonumentPhoto;
			Dane.NotatkaWynalazki_ok = player.GetComponent<Notes> ().isInventionNote;
			Dane.ZdjecieWarsztat_ok = player.GetComponent<Notes> ().isWorkshopPhoto;
			Dane.NotatkaCiemny_ok = player.GetComponent<Notes> ().isDarkForestNote;
			Dane.NotatkaZwierzeta_ok = player.GetComponent<Notes> ().isAnimalsNote;
			Dane.NotatkaNoc_ok = player.GetComponent<Notes> ().isNightNote;
			Dane.ZdjecieSzafa_ok = player.GetComponent<Notes> ().isWardrobePhoto;
			Dane.ZdjecieSzopa_ok = player.GetComponent<Notes> ().isShedPhoto;
			Dane.ZdjecieOboz_ok = player.GetComponent<Notes> ().isCampPhoto;
			Dane.NotatkaMary_ok = player.GetComponent<Notes> ().isMaryNote;
			Dane.RysunekCorki_ok = player.GetComponent<Notes> ().isDaughterPicture;
			Dane.NotatkaDyplom_ok = player.GetComponent<Notes> ().isDiplomaNote;
			Dane.RysunekTom_ok = player.GetComponent<Notes> ().isTomPicture;
			Dane.NotatkaCytat3_ok = player.GetComponent<Notes> ().isQuote3Note;
			Dane.RysunekPotwor_ok = player.GetComponent<Notes> ().isMonsterPicture;
			Dane.NotatkaSzepty_ok = player.GetComponent<Notes> ().iswhisperNote;
			Dane.NotatkaCytat4_ok = player.GetComponent<Notes> ().isQuote4Note;
			Dane.RysunekRosliny_ok = player.GetComponent<Notes> ().isPlantPicture;
			Dane.NotatkaPole_ok = player.GetComponent<Notes> ().isFieldNote;
			Dane.NotatkaArena_ok = player.GetComponent<Notes> ().isArenaNote;
			Dane.NotatkaCytat5_ok = player.GetComponent<Notes> ().isQuote5Note;
			Dane.ZdjeciePotok4_ok = player.GetComponent<Notes> ().isBrookPhoto4;
			Dane.NotatkaKosmici_ok = player.GetComponent<Notes> ().isAliensNote;
			Dane.NotatkaCytat6_ok = player.GetComponent<Notes> ().isQuote6Note;
            Dane.NotatkaDemona_ok = player.GetComponent<Notes> ().isDemonNote;

			// screamer
			Dane.Zegar_ok = player.GetComponent<Screamer> ().isClock;
			Dane.Lampa_ok = player.GetComponent<Screamer> ().isKitchenLamp;
			Dane.Lampa_przed_ok = player.GetComponent<Screamer> ().isLampBefore;
			Dane.Swiatlo2_ok = player.GetComponent<Screamer> ().isLight;
			Dane.Szelest_ok = player.GetComponent<Screamer> ().isRustle;
			Dane.Siano_ok = player.GetComponent<Screamer> ().isHay;
			Dane.Drewno_ok = player.GetComponent<Screamer> ().isWood;
			Dane.Wilk_ok = player.GetComponent<Screamer> ().isWolf;
			Dane.Szelest2_ok = player.GetComponent<Screamer> ().isRustle2;
			Dane.Klimat_ok = player.GetComponent<Screamer> ().isAtmosphere;
			Dane.Szept_ok = player.GetComponent<Screamer> ().isWhisper;
			Dane.RadioSpain_ok = player.GetComponent<Screamer> ().isRadioSpain;
			Dane.StudniaKrzyk_ok = player.GetComponent<Screamer> ().isWellScream;
			Dane.DrewnoSzopa_ok = player.GetComponent<Screamer> ().isWoodShed;
			Dane.Szczur_ok = player.GetComponent<Screamer> ().isRat;
			Dane.StudniaWoda_ok = player.GetComponent<Screamer> ().isWellWater;
			Dane.RadioStrzaly_ok = player.GetComponent<Screamer> ().isRadioFires;
			Dane.OdglosyFabryka_ok = player.GetComponent<Screamer> ().isFactory;
			Dane.Lancuchy_ok = player.GetComponent<Screamer> ().isChains;
			Dane.OdglosyFabryka2_ok = player.GetComponent<Screamer> ().isFactory2;
			Dane.WrednySmiech_ok = player.GetComponent<Screamer> ().isMeanLaugh;
			Dane.AktywujSmiech_ok = player.GetComponent<Screamer> ().isActiveLaugh;
			Dane.Kruki_ok = player.GetComponent<Screamer> ().isRaven;
			Dane.SmiechDzw_ok = player.GetComponent<Screamer> ().isGirlLaugh;
			Dane.KrzykDzw_ok = player.GetComponent<Screamer> ().isClock;
			Dane.Pozytywka_ok = player.GetComponent<Screamer> ().isMusicBox;
			Dane.Pukanie_ok = player.GetComponent<Screamer> ().isKnock;
			Dane.Szklo_ok = player.GetComponent<Screamer> ().isGlass;
			Dane.SkrzypienieSchody_ok = player.GetComponent<Screamer> ().isStairsCreak;
			Dane.KrzykSteven_ok = player.GetComponent<Screamer> ().isStevenScream;
			Dane.DzwonekDrzwiWlacz_ok = player.GetComponent<Screamer> ().isDoorBellActive;
			Dane.DzwonekDrzwi_ok = player.GetComponent<Screamer> ().isDoorBell;
			Dane.SkrzypienieZachod_ok = player.GetComponent<Screamer> ().isPaulCreak;
			Dane.Kroki_ok = player.GetComponent<Screamer> ().isSteps;
			Dane.SkrzypienieSchodyZachod_ok = player.GetComponent<Screamer> ().isPaulStairsCreak;
			Dane.DrzwiZamknij_ok = player.GetComponent<Screamer> ().isCloseDoor;
			Dane.DrzwiOtworz_ok = player.GetComponent<Screamer> ().isOpenDoor;
			Dane.Trup_ok = player.GetComponent<Screamer> ().isCorpse;
			Dane.Szept2_ok = player.GetComponent<Screamer> ().isWhisper2;
			Dane.Wiatr_ok = player.GetComponent<Screamer> ().isWind;
			Dane.WiatrEfekt_ok = player.GetComponent<Screamer> ().isWindEffect;
			Dane.Narzedzia_ok = player.GetComponent<Screamer> ().isTool;
			Dane.Kosci_ok = player.GetComponent<Screamer> ().isBones;
			Dane.Ciernie_ok = player.GetComponent<Screamer> ().isThorns;
			Dane.Jedzenie_ok = player.GetComponent<Screamer> ().isFood;
			Dane.Pies_ok = player.GetComponent<Screamer> ().isDog;
			Dane.Potok_ok = player.GetComponent<Screamer> ().isBrook;
			Dane.Oddech1_ok = player.GetComponent<Screamer> ().isBreath;
			Dane.Oddech2_ok = player.GetComponent<Screamer> ().isBreath2;
			Dane.Telefon_ok = player.GetComponent<Screamer> ().isPhone;
			Dane.TelefonBeep_ok = player.GetComponent<Screamer> ().isPhone2;
			Dane.SzeptyStudnia_ok = player.GetComponent<Screamer> ().isWellWhispers;
            Dane.RykPsa_ok = player.GetComponent<Screamer> ().isDogRoar;
            Dane.OddechSzopaKosc_ok = player.GetComponent<Screamer> ().isBoneShedBreath;
            Dane.PtakSzalas_ok = player.GetComponent<Screamer> ().isWoodBird;
            Dane.LiscieGanja_ok = player.GetComponent<Screamer> ().isLeaves;
            Dane.SzopaMeble_ok = player.GetComponent<Screamer> ().isShedFurniture;
            Dane.KrzykPotok_ok = player.GetComponent<Screamer>().isBrookScream;
            Dane.SzkloBabcia_ok = player.GetComponent<Screamer>().isGrandmaGlass;
            Dane.PukanieSzyba_ok = player.GetComponent<Screamer>().isGlassKnock;
            Dane.SzopaAlice_ok = player.GetComponent<Screamer>().isAliceShed;
            Dane.SwiatloChatka_ok = player.GetComponent<Screamer>().isHutLight;
            Dane.SkrzypPodloga_ok = player.GetComponent<Screamer>().isFloorCreak;
            Dane.StrasznaSowa_ok = player.GetComponent<Screamer>().isScaryOwl;
            Dane.StrasznaSowa2_ok = player.GetComponent<Screamer>().isScaryOwl2;
            Dane.WodaPlusk_ok = player.GetComponent<Screamer>().isWaterSplash;
            Dane.KrzykLisa_ok = player.GetComponent<Screamer>().isFoxScream;
            Dane.KrzykShock_ok = player.GetComponent<Screamer>().isShockScream;
            Dane.DrzewoFall_ok = player.GetComponent<Screamer>().isFallTree;
            Dane.DrzwiOtworzJmpPo_ok = player.GetComponent<Screamer>().isOpenJumpscareDoor;

        // zadania
            Dane.ZadaniePoczatek_ok = player.GetComponent<Tasks> ().isFirstTask;	
			Dane.ZadanieSzukajInfo_ok = player.GetComponent<Tasks> ().isSearchTask;
			Dane.ZadanieKluczDrewno_ok = player.GetComponent<Tasks> ().isWoodKeyTask;
			Dane.ZadanieMagicznaStudnia_ok = player.GetComponent<Tasks> ().isMagicWellTask;
			Dane.ZadanieKamienieStudnia_ok = player.GetComponent<Tasks> ().isWellStonesTask;
			Dane.ZadanieKaseta1_ok = player.GetComponent<Tasks> ().isCassete1Task;
            Dane.ZadanieDrzwiOgrod_ok = player.GetComponent<Tasks> ().isGardenDoorTask;
			Dane.ZadanieKosci_ok = player.GetComponent<Tasks> ().isBonesTask;
			Dane.ZadanieIdzAlice_ok = player.GetComponent<Tasks> ().isGoToAliceTask;
			Dane.ZadanieAliceInfo_ok = player.GetComponent<Tasks> ().isAliceSearchTask;
			Dane.ZadanieSimonElement_ok = player.GetComponent<Tasks> ().isSimonElementTask;
            Dane.ZadanieWarsztat_ok = player.GetComponent<Tasks>().isWorkshopTask;
            Dane.ZadanieZepsutyKlucz_ok = player.GetComponent<Tasks> ().isBrokenKeyTask;
			Dane.ZadanieNaprawKlucz_ok = player.GetComponent<Tasks> ().isFixKeyTask;
			Dane.ZadanieCmentarzZwierz_ok = player.GetComponent<Tasks> ().isAnimalCemetaryTask;
			Dane.ZadanieVictorPotok_ok = player.GetComponent<Tasks> ().isVictorBrookTask;
			Dane.ZadanieSalonAlice_ok = player.GetComponent<Tasks> ().isAliceRoomTask;
			Dane.ZadanieKukurydza_ok = player.GetComponent<Tasks> ().isCornfieldTask;
			Dane.ZadanieSiekiera_ok = player.GetComponent<Tasks> ().isAxeTask;
			Dane.ZadanieSzafaKorytarz_ok = player.GetComponent<Tasks> ().isCorridorWardrobeTask;
			Dane.ZadanieSzafkaEdward_ok = player.GetComponent<Tasks> ().isEdwardCupboardTask;
			Dane.ZadanieKaseta2_ok = player.GetComponent<Tasks> ().isCassete2Task;
			Dane.ZadanieIdzSzlak_ok = player.GetComponent<Tasks> ().isGoToTrialTask;
			Dane.ZadanieKierujSzlak_ok = player.GetComponent<Tasks> ().isGoTrailTask;
			Dane.ZadaniePrzedostanSie_ok = player.GetComponent<Tasks> ().isGetToTomRoadTask;
			Dane.ZadanieTomInfo_ok = player.GetComponent<Tasks> ().isTomSearchTask;
			Dane.ZadanieTomKukurydza_ok = player.GetComponent<Tasks> ().isTomCornifieldTask;
			Dane.ZadanieKaseta3_ok = player.GetComponent<Tasks> ().isCassete3Task;
			Dane.ZadanieTomOboz_ok = player.GetComponent<Tasks> ().isTompCampTask;
			Dane.ZadanieTomDynia_ok = player.GetComponent<Tasks> ().isTomPumpkinTask;
			Dane.ZadanieTomChip_ok = player.GetComponent<Tasks> ().isTomChipTask;
			Dane.ZadanieWawoz_ok = player.GetComponent<Tasks> ().isRavineTask;
			Dane.ZadanieIdzWawoz_ok = player.GetComponent<Tasks> ().isGoRavineTask;
			Dane.ZadanieOpuszczonyInfo_ok = player.GetComponent<Tasks> ().isAbandonedSearchTask;
			Dane.ZadanieKaseta4_ok = player.GetComponent<Tasks> ().isCassete4Task;
			Dane.ZadanieStevenInfo_ok = player.GetComponent<Tasks> ().isStevenSearchTask;
			Dane.ZadanieStevenKlucz_ok = player.GetComponent<Tasks> ().isStevenKeyTask;
			Dane.ZadanieStevenGrzyb_ok = player.GetComponent<Tasks> ().isStevenMushroomTask;
			Dane.ZadanieStevenRoslina_ok = player.GetComponent<Tasks> ().isStevenPlantTask;
			Dane.ZadanieStevenCzaszka_ok = player.GetComponent<Tasks> ().isStevenSkullTask;
			Dane.ZadanieKwas_ok = player.GetComponent<Tasks> ().isStevenAcidTask;
			Dane.ZadanieStevenSzopa_ok = player.GetComponent<Tasks> ().isStevenShedTask;
			Dane.ZadanieStevenNotatka_ok = player.GetComponent<Tasks> ().isStevenNoteTask;
			Dane.ZadanieStevenPotok_ok = player.GetComponent<Tasks> ().isStevenBrookTask;
			Dane.ZadaniePaulInfo_ok = player.GetComponent<Tasks> ().isPaulSearchTask;
			Dane.ZadaniePaulDrzwi_ok = player.GetComponent<Tasks> ().isPaulDoorTask;
			Dane.ZadanieChatka_ok = player.GetComponent<Tasks> ().isHutTask;
			Dane.ZadaniePotokDiably_ok = player.GetComponent<Tasks> ().isDevilsBrookTask;
			Dane.ZadanieKryjowkaDiably_ok = player.GetComponent<Tasks> ().isDevilsShelterTask;
			Dane.ZadanieKryjowkaRodzina_ok = player.GetComponent<Tasks> ().isShelterFamilyTask;

			Dane.ZadaniePoczatek_Usun = player.GetComponent<Tasks> ().isFirstTaskRemoved;
			Dane.ZadanieSzukajInfo_Usun = player.GetComponent<Tasks> ().isSearchTaskRemoved;
			Dane.ZadanieKluczDrewno_Usun = player.GetComponent<Tasks> ().isWoodKeyTaskRemoved;
			Dane.ZadanieMagicznaStudnia_Usun = player.GetComponent<Tasks> ().isMagicWellTaskRemoved;
			Dane.ZadanieKamienieStudnia_Usun = player.GetComponent<Tasks> ().isWellStonesTaskRemoved;
			Dane.ZadanieKaseta1_Usun = player.GetComponent<Tasks> ().isCassete1TaskRemoved;
            Dane.ZadanieDrzwiOgrod_Usun = player.GetComponent<Tasks> ().isGardenDoorTaskRemoved;
			Dane.ZadanieKosci_Usun = player.GetComponent<Tasks> ().isBonesTaskRemoved;
			Dane.ZadanieIdzAlice_Usun = player.GetComponent<Tasks> ().isGoToAliceTaskRemoved;
			Dane.ZadanieAliceInfo_Usun = player.GetComponent<Tasks> ().isAliceSearchTaskRemoved;
			Dane.ZadanieSimonElement_Usun = player.GetComponent<Tasks> ().isSimonElementTaskRemoved;
            Dane.ZadanieWarsztat_Usun = player.GetComponent<Tasks>().isWorkshopTaskRemoved;
            Dane.ZadanieZepsutyKlucz_Usun = player.GetComponent<Tasks> ().isBrokenKeyTaskRemoved;
			Dane.ZadanieNaprawKlucz_Usun = player.GetComponent<Tasks> ().isFixKeyTaskRemoved;
			Dane.ZadanieCmentarzZwierz_Usun = player.GetComponent<Tasks> ().isAnimalCemetaryTaskRemoved;
			Dane.ZadanieVictorPotok_Usun = player.GetComponent<Tasks> ().isVictorBrookTaskRemoved;
			Dane.ZadanieSalonAlice_Usun = player.GetComponent<Tasks> ().isAliceRoomTaskRemoved;
			Dane.ZadanieKukurydza_Usun = player.GetComponent<Tasks> ().isCornfieldTaskRemoved;
			Dane.ZadanieSiekiera_Usun = player.GetComponent<Tasks> ().isAxeTaskRemoved;
			Dane.ZadanieSzafaKorytarz_Usun = player.GetComponent<Tasks> ().isCorridorWardrobeTaskRemoved;
			Dane.ZadanieSzafkaEdward_Usun = player.GetComponent<Tasks> ().isEdwardCupboardTaskRemoved;
			Dane.ZadanieKaseta2_Usun = player.GetComponent<Tasks> ().isCassete2TaskRemoved;
			Dane.ZadanieIdzSzlak_Usun = player.GetComponent<Tasks> ().isGoToTrialTaskRemoved;
			Dane.ZadanieKierujSzlak_Usun = player.GetComponent<Tasks> ().isGoTrailTaskRemoved;
			Dane.ZadaniePrzedostanSie_Usun = player.GetComponent<Tasks> ().isGetToTomRoadTaskRemoved;
			Dane.ZadanieTomInfo_Usun = player.GetComponent<Tasks> ().isTomSearchTaskRemoved;
			Dane.ZadanieTomKukurydza_Usun = player.GetComponent<Tasks> ().isTomCornifieldTaskRemoved;
			Dane.ZadanieKaseta3_Usun = player.GetComponent<Tasks> ().isCassete3TaskRemoved;
			Dane.ZadanieTomOboz_Usun = player.GetComponent<Tasks> ().isTompCampTaskRemoved;
			Dane.ZadanieTomDynia_Usun = player.GetComponent<Tasks> ().isTomPumpkinTaskRemoved;
			Dane.ZadanieTomChip_Usun = player.GetComponent<Tasks> ().isTomChipTaskRemoved;
			Dane.ZadanieWawoz_Usun = player.GetComponent<Tasks> ().isRavineTaskRemoved;
			Dane.ZadanieIdzWawoz_Usun = player.GetComponent<Tasks> ().isGoRavineTaskRemoved;
			Dane.ZadanieOpuszczonyInfo_Usun = player.GetComponent<Tasks> ().isAbandonedSearchTaskRemoved;
			Dane.ZadanieKaseta4_Usun = player.GetComponent<Tasks> ().isCassete4TaskRemoved;
			Dane.ZadanieStevenInfo_Usun = player.GetComponent<Tasks> ().isStevenSearchTaskRemoved;
			Dane.ZadanieStevenKlucz_Usun = player.GetComponent<Tasks> ().isStevenKeyTaskRemoved;
			Dane.ZadanieStevenGrzyb_Usun = player.GetComponent<Tasks> ().isStevenMushroomTaskRemoved;
			Dane.ZadanieStevenRoslina_Usun = player.GetComponent<Tasks> ().isStevenPlantTaskRemoved;
			Dane.ZadanieStevenCzaszka_Usun = player.GetComponent<Tasks> ().isStevenSkullTaskRemoved;
			Dane.ZadanieKwas_Usun = player.GetComponent<Tasks> ().isStevenAcidTaskRemoved;
			Dane.ZadanieStevenSzopa_Usun = player.GetComponent<Tasks> ().isStevenShedTaskRemoved;
			Dane.ZadanieStevenNotatka_Usun = player.GetComponent<Tasks> ().isStevenNoteTaskRemoved;
			Dane.ZadanieStevenPotok_Usun = player.GetComponent<Tasks> ().isStevenBrookTaskRemoved;
			Dane.ZadaniePaulInfo_Usun = player.GetComponent<Tasks> ().isPaulSearchTaskRemoved;
			Dane.ZadaniePaulDrzwi_Usun = player.GetComponent<Tasks> ().isPaulDoorTaskRemoved;
			Dane.ZadanieChatka_Usun = player.GetComponent<Tasks> ().isHutTaskRemoved;
			Dane.ZadaniePotokDiably_Usun = player.GetComponent<Tasks> ().isDevilsBrookTaskRemoved;
			Dane.ZadanieKryjowkaDiably_Usun = player.GetComponent<Tasks> ().isDevilsShelterTaskRemoved;
			Dane.ZadanieKryjowkaRodzina_Usun = player.GetComponent<Tasks> ().isShelterFamilyTaskRemoved;

			Dane.GlosIdzSzlak_ok = player.GetComponent<Tasks> ().isGoTrailVoice;

			Dane.DrzwiOgrod_lock = player.GetComponent<Tasks> ().isGardenDoorLocked;
			Dane.DrzwiKukurydza_lock = player.GetComponent<Tasks> ().isCornfieldDoorLocked;
			Dane.DrzwiStajnia_lock = player.GetComponent<Tasks> ().isStableDoorLocked;
			Dane.SzafkaKorytarz_lock = player.GetComponent<Tasks> ().isCorridorWardrobeLocked;
			Dane.DrzwiPokojW_lock = player.GetComponent<Tasks> ().isUncleDoorLocked;
			Dane.SzafkaKuchnia_lock = player.GetComponent<Tasks> ().isKitchenWardrobeLocked;
			Dane.DrzwiKamping_lock = player.GetComponent<Tasks> ().isSecretRoomDoorLocked;
			Dane.DeskiSzopa_lock = player.GetComponent<Tasks> ().isPlanksLocked;
			Dane.DeskiZniszczone_ok = player.GetComponent<Tasks> ().isPlanksDestroyed;
			Dane.DrzwiSzopaNarzedzia_lock = player.GetComponent<Tasks> ().isToolShedDoorLocked;
			Dane.DrzwiWneka_lock = player.GetComponent<Tasks> ().isNicheDoorLocked;
			Dane.WlozKasete_ok = player.GetComponent<Tasks> ().isCasseteInserted;
			Dane.WlozBaterie_ok = player.GetComponent<Tasks> ().isBatteriesPut;
			Dane.DrzwiSalonPoludnie_lock = player.GetComponent<Tasks> ().isAliceRoomDoorLocked;
			Dane.Halucynacje_ok = player.GetComponent<Tasks> ().isHalluns;
			Dane.DrzwiFabrykaMetal_lock = player.GetComponent<Tasks> ().isFactoryMetalDoorLocked;
			Dane.ZepsutyKlucz_ok = player.GetComponent<Tasks> ().isBrokenKey;
			Dane.Kolo_ok = player.GetComponent<Tasks> ().isWheel;
			Dane.NaprawionyKlucz_ok = player.GetComponent<Tasks> ().isFixedKey;
			Dane.DrzwiFabrykaDrewno_lock = player.GetComponent<Tasks> ().isFactoryWoodenDoorLocked;
			Dane.SzafkaSzopa_lock = player.GetComponent<Tasks> ().isShedCupboardLocked;
			Dane.WlozKasete2_ok = player.GetComponent<Tasks> ().isCassete2Inserted;
			Dane.DrzwiPokojTom_lock = player.GetComponent<Tasks> ().isTomRoomDoorLocked;
			Dane.DrzwiTomGora_lock = player.GetComponent<Tasks> ().isTomUpstairsDoorLocked;
			Dane.WlozKasete3_ok = player.GetComponent<Tasks> ().isCassete3Inserted;
			Dane.BrakChip_ok = player.GetComponent<Tasks> ().isLackChip;
			Dane.WlozChip_ok = player.GetComponent<Tasks> ().isChipPut;
			Dane.SzafaStaryDom_lock = player.GetComponent<Tasks> ().isOldWardrobeLocked;
			Dane.WlozKasete4_ok = player.GetComponent<Tasks> ().isCassete4Inserted;
			Dane.DrzwiSteven_lock = player.GetComponent<Tasks> ().isStevenDoorLocked;
			Dane.KratySteven_lock = player.GetComponent<Tasks> ().isStevenGrille;
			Dane.DrzwiZachod_lock = player.GetComponent<Tasks> ().isPaulDoorLocked;
			Dane.Kaseta1Odtworzona = player.GetComponent<Tasks> ().isCassete1Played;
			Dane.Kaseta2Odtworzona = player.GetComponent<Tasks> ().isCassete2Played;
			Dane.Kaseta3Odtworzona = player.GetComponent<Tasks> ().isCassete3Played;
			Dane.Kaseta4Odtworzona = player.GetComponent<Tasks> ().isCassete4Played;
			Dane.Kaseta5Odtworzona = player.GetComponent<Tasks> ().isCassete5Played;
			Dane.SzopaStevenMonster_ok = player.GetComponent<Tasks> ().isStevenShedLocked;
            Dane.HalunyOgrodFlashback_ok = player.GetComponent<Tasks> ().isHallunsFlashback;
			Dane.DyniaZad_ok = player.GetComponent<Tasks> ().isPumpkin;
			Dane.RoslinaLabZad_ok = player.GetComponent<Tasks> ().isLabPlant;
			Dane.GrzybLabZad_ok = player.GetComponent<Tasks> ().isLabMushroom;
			Dane.CzaszkaLabZad_ok = player.GetComponent<Tasks> ().isLabSkull;
			Dane.Lab_ok = player.GetComponent<Tasks> ().isLab;
			Dane.LabMikstura_ok = player.GetComponent<Tasks> ().isLabPot;
			Dane.KratyZniszczone_ok = player.GetComponent<Tasks> ().isGrilleDestroyed;

			// ksiazki
			Dane.Wykonane_ok = player.GetComponent<TaskBooks> ().isTaskDone;

            // kolekcja

         

            // haluny 

            Dane.Marysia1_ok = player.GetComponent<Halluns>().isStartGanja1;
            Dane.Marysia2_ok = player.GetComponent<Halluns>().isStartGanja2;
            Dane.Marysia3_ok = player.GetComponent<Halluns>().isStartGanja3;
            Dane.Marysia4_ok = player.GetComponent<Halluns>().isStartGanja4;
            Dane.Marysia5_ok = player.GetComponent<Halluns>().isStartGanja5;
            Dane.KoniecMarysia1_ok = player.GetComponent<Halluns>().isEndGanja1;
            Dane.KoniecMarysia2_ok = player.GetComponent<Halluns>().isEndGanja2;
            Dane.KoniecMarysia3_ok = player.GetComponent<Halluns>().isEndGanja3;
            Dane.KoniecMarysia4_ok = player.GetComponent<Halluns>().isEndGanja4;
            Dane.KoniecMarysia5_ok = player.GetComponent<Halluns>().isEndGanja5;
            Dane.IloscZapalen = Halluns.fireCount;

            // scarecrow straszak

            Dane.MonsterKorytarzScarecrow_ok = player.GetComponent<StraszakScarecrow>().MonsterKorytarzScarecrow_ok;
            Dane.MonsterStajniaScarecrow_ok = player.GetComponent<StraszakScarecrow>().MonsterStajniaScarecrow_ok;
            Dane.MonsterWychodekScarecrow_ok = player.GetComponent<StraszakScarecrow>().MonsterWychodekScarecrow_ok;
            Dane.MonsterSzalasScarecrow_ok = player.GetComponent<StraszakScarecrow>().MonsterSzalasScarecrow_ok;
            Dane.MonsterSzalasSchowal_ok = player.GetComponent<StraszakScarecrow>().MonsterSzalasSchowal_ok;
            Dane.MonsterSzopaScarecrow_ok = player.GetComponent<StraszakScarecrow>().MonsterSzopaScarecrow_ok;

            BinaryFormatter Bf = new BinaryFormatter ();
			Bf.Serialize (Plik, Dane);
			Plik.Close ();

	}

	public void Wczytaj(){

		if (File.Exists (Application.persistentDataPath + "/PlayerSave.pav")) {
		
			FileStream Plik = File.Open (Application.persistentDataPath + "/PlayerSave.pav", FileMode.Open);

			BinaryFormatter Bf = new BinaryFormatter ();

			GraczDane Dane = (GraczDane)Bf.Deserialize (Plik);
			Plik.Close ();

			PlayerInstance.isRespown = false;

			if (SceneManager.GetActiveScene ().name == "MenuGlowne") {
                //Debug.Log(Dane.NazwaSceny);
                //SceneManager.LoadScene (Dane.NazwaSceny);
                SceneManager.LoadScene("ScenaGlowna");
            }

			player.GetComponent<Health> ().health = Dane.Zdrowie;
			player.GetComponent<Transform> ().position = Dane.Pozycja.PobierzPozycje ();
			player.GetComponent<Transform> ().rotation = Dane.Obrot.PobierzObrot ();

			PoczatekZapis_ok = Dane.PoczatekZapis_ok;
			DomZapis_ok = Dane.DomZapis_ok;
			StudniaZapis_ok = Dane.StudniaZapis_ok;
			OgrodZapis_ok = Dane.OgrodZapis_ok;
			KosciZapis_ok = Dane.KosciZapis_ok;
			IdzAliceZapis_ok = Dane.IdzAliceZapis_ok;
			DomAliceZapis_ok = Dane.DomAliceZapis_ok;
			BrakujaceKoloZapis_ok = Dane.BrakujaceKoloZapis_ok;
			NaprawionyKluczZapis_ok = Dane.NaprawionyKluczZapis_ok;
			FabrykaZapis_ok = Dane.FabrykaZapis_ok;
			FabrykaZapis2_ok = Dane.FabrykaZapis2_ok;
			LewyPotokZapis_ok = Dane.LewyPotokZapis_ok;
			KombinerkiZapis_ok = Dane.KombinerkiZapis_ok;
			KukurydzaZapis_ok = Dane.KukurydzaZapis_ok;
			KluczSzafaKorytarzZapis_ok = Dane.KluczSzafaKorytarzZapis_ok;
			IdzSzlakZapis_ok = Dane.IdzSzlakZapis_ok;
            PrzedPajakJumpscareZapis_ok = Dane.PrzedPajakJumpscareZapis_ok;
            PrzedostanSieZapis_ok = Dane.PrzedostanSieZapis_ok;
			ObozTomZapis_ok = Dane.ObozTomZapis_ok;
			TomGoraZapis_ok = Dane.TomGoraZapis_ok;
			MonsterTomZapis_ok = Dane.MonsterTomZapis_ok;
			IdzWawozZapis_ok = Dane.IdzWawozZapis_ok;
			PrzedStevenZapis_ok = Dane.PrzedStevenZapis_ok;
			MonsterMiesoZapis_ok = Dane.MonsterMiesoZapis_ok;
			GrzybZapis_ok = Dane.GrzybZapis_ok;
			SzopaStevenZapis_ok = Dane.SzopaStevenZapis_ok;
			PaulZapis_ok = Dane.PaulZapis_ok;
			PaulGoraZapis_ok = Dane.PaulGoraZapis_ok;
			ChatkaZapis_ok = Dane.ChatkaZapis_ok;
			KryjowkaZapis_ok = Dane.KryjowkaZapis_ok;


			// gracz
			player.GetComponent<Player> ().maxStamina = Dane.MaxStamina;
			player.GetComponent<Player> ().staminaRegenerationFactor = Dane.RegeneracjaStaminy;

			// ekwipunek
			player.GetComponent<Inventory> ().secretItemsCount = Dane.IloscSecretItems;
			player.GetComponent<Inventory> ().secretPlacesCount = Dane.IloscSecretPlaces;
			player.GetComponent<Inventory> ().blueHerbsCount = Dane.IloscNiebieskieZiola;
			player.GetComponent<Inventory> ().greenHerbsCount = Dane.IloscZieloneZiola;
			player.GetComponent<Inventory> ().healthPotsCount = Dane.IloscMiksturaZdrowie;
			player.GetComponent<Inventory> ().staminaPotsCount = Dane.IloscMiksturaStamina;
            player.GetComponent<Inventory>().vialsCount = Dane.IloscFiolek;

            player.GetComponent<Inventory> ().isRockyGraveSP = Dane.SPGrobRocky_ok;
			player.GetComponent<Inventory> ().isAnimalCementarySP = Dane.SPCmentarzZwierzat_ok;
			player.GetComponent<Inventory> ().isSimonGardenSP = Dane.SPOgrodSimona_ok;
			player.GetComponent<Inventory> ().isTomCampSP = Dane.SPObozToma_ok;
			player.GetComponent<Inventory> ().isDevilsShelterSP = Dane.SPKryjowkaDiably_ok;
			player.GetComponent<Inventory> ().isWarCementarySP = Dane.SPCmentarzWojna_ok;
			player.GetComponent<Inventory> ().isHutSP = Dane.SPDomek_ok;
			player.GetComponent<Inventory> ().isBasementSP = Dane.SPPiwnica_ok;
			player.GetComponent<Inventory> ().isMushroomFieldSP = Dane.SPPoleGrzybowe_ok;
			player.GetComponent<Inventory> ().isDarkForestSP = Dane.SPCiemnyLas_ok;
			player.GetComponent<Inventory> ().isBonesTowerSP = Dane.SPWiezaKosci_ok;
			player.GetComponent<Inventory> ().isKnifeArenaSP = Dane.SPNozowaArena_ok;
			player.GetComponent<Inventory> ().isCaveSP = Dane.SPJaskinia_ok;
			player.GetComponent<Inventory> ().isMonumentSP = Dane.SPPomnik_ok;
			player.GetComponent<Inventory> ().isSpaceshipSP = Dane.SPStatekKosmiczny_ok;


			

            

         


            player.GetComponent<Inventory>().badgesCount = Dane.IloscOdznak;
            player.GetComponent<Inventory>().tipsCount = Dane.IloscWskazowek;
            player.GetComponent<Inventory>().photosCount = Dane.IloscFoto;
            player.GetComponent<Inventory>().skillsCount = Dane.IloscUmiejetnosci;

            // glos bohatera
            player.GetComponent<VoiceActing> ().isBeginGameRecording = Dane.GlosPoczatek_ok;
			player.GetComponent<VoiceActing> ().isFenceRecording = Dane.GlosOgrodzenie_ok;
			player.GetComponent<VoiceActing> ().isHouseLightRecording = Dane.GlosSwiatloDomu_ok;
			player.GetComponent<VoiceActing> ().isKitchenRecording = Dane.GlosKuchnia_ok;
			player.GetComponent<VoiceActing> ().isBigRoomRecording = Dane.GlosDuzyPokoj_ok;
			player.GetComponent<VoiceActing> ().isArthurRoomRecording = Dane.GlosPokojArtura_ok;
			player.GetComponent<VoiceActing> ().isToolShedRecording = Dane.GlosSzopaNarzedzia_ok;
			player.GetComponent<VoiceActing> ().isAliceHouseRecording = Dane.GlosDomAlice_ok;
			player.GetComponent<VoiceActing> ().isHallunsRecording = Dane.GlosHalucynacje_ok;
			player.GetComponent<VoiceActing> ().isWorkshopRecording = Dane.GlosWarsztat_ok;
			player.GetComponent<VoiceActing> ().isLeftBrookRecording = Dane.GlosLewyPotok_ok;
			player.GetComponent<VoiceActing> ().isAnnaNoteRecording = Dane.GlosNotatkaAnna_ok;
			player.GetComponent<VoiceActing> ().isPliersRecording = Dane.GlosKombinerki_ok;
			player.GetComponent<VoiceActing> ().isCornfieldRecording = Dane.GlosKukurydza_ok;
			player.GetComponent<VoiceActing> ().isOldShedRecording = Dane.GlosStaraSzopa_ok;
			player.GetComponent<VoiceActing> ().isAxeRecording = Dane.GlosSiekiera_ok;
			player.GetComponent<VoiceActing> ().isAfterCasseteRecording = Dane.GlosNagranie_ok;
			player.GetComponent<VoiceActing> ().isBooksRecording = Dane.GlosKsiazki_ok; 
			player.GetComponent<VoiceActing> ().isRavineRecording = Dane.GlosWawoz_ok;
			player.GetComponent<VoiceActing> ().isStevenHouseRecording = Dane.GlosDomStevena_ok;
			player.GetComponent<VoiceActing> ().isAcidRecording = Dane.GlosEliksir_ok;
			player.GetComponent<VoiceActing> ().isStevenShedRecording = Dane.GlosSzopaSteven_ok;
			player.GetComponent<VoiceActing> ().isDevilsBrookRecording = Dane.GlosPotokDiably_ok;
			player.GetComponent<VoiceActing> ().isDevilsShelterRecording = Dane.GlosKryjowka_ok;

            player.GetComponent<VoiceActing>().isWellRecording = Dane.GlosSzalas_ok;
            player.GetComponent<VoiceActing>().isStableRecording = Dane.GlosStudnia_ok;
            player.GetComponent<VoiceActing>().isGardenRecording = Dane.GlosStajnia_ok;
            player.GetComponent<VoiceActing>().isGardenRecording = Dane.GlosOgrod_ok;
            player.GetComponent<VoiceActing>().isSecretRoomRecording = Dane.GlosKamping_ok;
            player.GetComponent<VoiceActing>().isInventionRecording = Dane.GlosUrzadzenieVictora_ok;
            player.GetComponent<VoiceActing>().isWardrobeCorridorRecording = Dane.GlosSzafaKorytarz_ok;
            player.GetComponent<VoiceActing>().isChipRecording = Dane.GlosChip_ok;
            player.GetComponent<VoiceActing>().isArthurTipRecording = Dane.GlosWskazowkiArtura_ok;
            player.GetComponent<VoiceActing>().isMonstersPlantsRecording = Dane.GlosRoslinyPotworow_ok;
            player.GetComponent<VoiceActing>().isZenoRecording = Dane.GlosZeno_ok;


            player.GetComponent<VoiceActing> ().isRetroBigRoomRecording = Dane.RetroDuzyPokoj_ok;
			player.GetComponent<VoiceActing> ().isRetroArthurRoomRecording = Dane.RetroPokojArtura_ok;
			player.GetComponent<VoiceActing> ().isRetroToolShedRecording = Dane.RetroSzopaNarzedzia_ok;
			player.GetComponent<VoiceActing> ().isRetroAliceHouseRecording = Dane.RetroDomAlice_ok;
			player.GetComponent<VoiceActing> ().isRetroWorkshopRecording = Dane.RetroWarsztat_ok;
			player.GetComponent<VoiceActing> ().isRetroCornfieldRecording = Dane.RetroKukurydza_ok;
			player.GetComponent<VoiceActing> ().isRetroOldShedRecording = Dane.RetroStaraSzopa_ok;
			player.GetComponent<VoiceActing> ().isRetroBooksRecording = Dane.RetroKsiazki_ok;
			player.GetComponent<VoiceActing> ().isRetroStevenHouseRecording = Dane.RetroDomStevena_ok;
			player.GetComponent<VoiceActing> ().isRetroStevenShedRecording = Dane.RetroSzopaSteven_ok;

			player.GetComponent<VoiceActing> ().isBeginGameSubtitles = Dane.PoczatekGryNap_ok;
			player.GetComponent<VoiceActing> ().isFenceSubtitles = Dane.OgrodzenieNap_ok;
			player.GetComponent<VoiceActing> ().isHouseLightSubtitles = Dane.SwiatloDomuNap_ok;
			player.GetComponent<VoiceActing> ().isKitchenSubtitles = Dane.KuchniaNap_ok;
			player.GetComponent<VoiceActing> ().isBigRoomSubtitles = Dane.DuzyPokojNap_ok;
			player.GetComponent<VoiceActing> ().isArthurRoomSubtitles = Dane.PokojArthuraNap_ok;
			player.GetComponent<VoiceActing> ().isToolShedSubtitles = Dane.SzopaNarzedziaNap_ok;
			player.GetComponent<VoiceActing> ().isCassete1Subtitles = Dane.Kaseta1Nap_ok;
			player.GetComponent<VoiceActing> ().isAliceHouseSubtitles = Dane.DomAliceNap_ok;
			player.GetComponent<VoiceActing> ().isHallunsSubtitles = Dane.HalucynacjeNap_ok;
			player.GetComponent<VoiceActing> ().isWorkshopSubtitles = Dane.WarsztatNap_ok;
			player.GetComponent<VoiceActing> ().isLeftBrookSubtitles = Dane.LewyPotokNap_ok;
			player.GetComponent<VoiceActing> ().isAnnaNoteSubtitles = Dane.NotatkaAnnaNap_ok;
			player.GetComponent<VoiceActing> ().isPliersSubtitles = Dane.KombinerkiNap_ok;
			player.GetComponent<VoiceActing> ().isCornfieldSubtitles = Dane.KukurydzaNap_ok;
			player.GetComponent<VoiceActing> ().isAxeSubtitles = Dane.SiekieraNap_ok;
			player.GetComponent<VoiceActing> ().isOldShedSubtitles = Dane.StaraSzopaNap_ok;
			player.GetComponent<VoiceActing> ().isCassete2Subtitles = Dane.Kaseta2Nap_ok;
			player.GetComponent<VoiceActing> ().isAfterCasseteSubtitles = Dane.NagranieNap_ok;
			player.GetComponent<VoiceActing> ().isBooksSubtitles = Dane.KsiazkiNap_ok;
			player.GetComponent<VoiceActing> ().isCassete3Subtitles = Dane.Kaseta3Nap_ok;
			player.GetComponent<VoiceActing> ().isRavineSubtitles = Dane.WawozNap_ok;
			player.GetComponent<VoiceActing> ().isCassete4Subtitles = Dane.Kaseta4Nap_ok;
			player.GetComponent<VoiceActing> ().isStevenHouseSubtitles = Dane.DomStevenaNap_ok;
			player.GetComponent<VoiceActing> ().isAcidSubtitles = Dane.EliksirNap_ok;
			player.GetComponent<VoiceActing> ().isStevenShedSubtitles = Dane.SzopaStevenNap_ok;
			player.GetComponent<VoiceActing> ().isDevilsBrookSubtitles = Dane.PotokDiablyNap_ok;
			player.GetComponent<VoiceActing> ().isCassete5Subtitles = Dane.Kaseta5Nap_ok;
			player.GetComponent<VoiceActing> ().isDevilsShelterSubtitles = Dane.KryjowkaNap_ok;

            player.GetComponent<VoiceActing>().isWoodSubtitles = Dane.SzalasNap_ok;
            player.GetComponent<VoiceActing>().isWellSubtitles = Dane.StudniaNap_ok;
            player.GetComponent<VoiceActing>().isStableSubtitles = Dane.StajniaNap_ok;
            player.GetComponent<VoiceActing>().isGardenSubtitles = Dane.OgrodNap_ok;
            player.GetComponent<VoiceActing>().isSecretRoomSubtitles = Dane.KampingNap_ok;
            player.GetComponent<VoiceActing>().isInventionSubtitles = Dane.UrzadzenieVictoraNap_ok;
            player.GetComponent<VoiceActing>().isWardrobeCorridorSubtitles = Dane.SzafaKorytarzNap_ok;
            player.GetComponent<VoiceActing>().isChipSubtitles = Dane.ChipNap_ok;
            player.GetComponent<VoiceActing>().isArthurTipSubtitles = Dane.WskazowkiArturaNap_ok;
            player.GetComponent<VoiceActing>().isMonstersPlantsSubtitles = Dane.RoslinyPotworowNap_ok;
            player.GetComponent<VoiceActing>().isZenoSubtitles = Dane.ZenoNap_ok;

            // jumpscare
            player.GetComponent<Jumpscare> ().isBrookMonster1_On = Dane.MonsterPotok1_ok;
            player.GetComponent<Jumpscare> ().isBrookMonster1_Off = Dane.MonsterPotok1Wyl_ok;
            player.GetComponent<Jumpscare> ().isCornfieldMonster = Dane.MonsterKukurydza_ok;
			player.GetComponent<Jumpscare> ().isCorridorMonster = Dane.MonsterKorytarz_ok;
			player.GetComponent<Jumpscare> ().isCornfieldMonster2 = Dane.MonsterKukurydza2_ok;
			player.GetComponent<Jumpscare> ().isChannelMonster = Dane.MonsterKoryto_ok;
			player.GetComponent<Jumpscare> ().isMeatMonsters = Dane.MonstersLasMieso_ok;
			player.GetComponent<Jumpscare> ().isPaulRoomMonster = Dane.MonsterPokojZachod_ok;
			player.GetComponent<Jumpscare> ().isPaulDoorMonster = Dane.MonsterDrzwiZachod_ok;
			player.GetComponent<Jumpscare> ().isGardenMonster = Dane.MonsterOgrod_ok;
			player.GetComponent<Jumpscare> ().isWorkshopMonster = Dane.MonsterWarsztat_ok;
			player.GetComponent<Jumpscare> ().isPumpkinMonster_On = Dane.MonsterDynia_ok;
			player.GetComponent<Jumpscare> ().isPumpkinMonster_Off = Dane.MonsterDyniaWylacz_ok;
			player.GetComponent<Jumpscare> ().isAbandonedMonster = Dane.MonsterOpuszczony1_ok;
			player.GetComponent<Jumpscare> ().isShedMonster1 = Dane.MonsterSzopa1_ok;
			player.GetComponent<Jumpscare> ().isTomMonster = Dane.MonsterTom_ok;
			player.GetComponent<Jumpscare> ().isPlantMonster = Dane.MonsterRoslina_ok;
			player.GetComponent<Jumpscare> ().isBushMonster_On = Dane.MonsterKrzaki_ok;
			player.GetComponent<Jumpscare> ().isBushMonster_Off = Dane.MonsterKrzakiWyl_ok;
			player.GetComponent<Jumpscare> ().isPaulDownstairsMonster = Dane.MonsterZachodGora_ok;
			player.GetComponent<Jumpscare> ().isStevenShedMonster1 = Dane.MonsterSzopaSteven1_ok;
			player.GetComponent<Jumpscare> ().isStevenShedMonster2 = Dane.MonsterSzopaSteven2_ok;
			player.GetComponent<Jumpscare> ().isAbandonedMonsterStop = Dane.StopCzasOpuszczony_ok;
            player.GetComponent<Jumpscare> ().isBeginMonster = Dane.MonsterPoczatek_ok;
            player.GetComponent<Jumpscare> ().isStableMonster = Dane.MonsterStajnia_ok;
            player.GetComponent<Jumpscare> ().isSecretRoomMonster = Dane.MonsterKamping_ok;
            player.GetComponent<Jumpscare> ().isBeginWolves = Dane.WilkPoczatek_ok;
            player.GetComponent<Jumpscare> ().isJumpscareSpider1 = Dane.PajakJumpscare1_ok;
            player.GetComponent<Jumpscare> ().isJumpscareSpider2 = Dane.PajakJumpscare2_ok;
            player.GetComponent<Jumpscare> ().isSpider3_On = Dane.Pajak3_ok;
            player.GetComponent<Jumpscare> ().isSpider3_Off = Dane.Pajak3Wylacz_ok;
            player.GetComponent<Jumpscare> ().isSpider4 = Dane.Pajak4_ok;

            // komunikat
            player.GetComponent<Notifications> ().isLightNotification = Dane.KomSwiatlo_ok;
			player.GetComponent<Notifications> ().isSprintNotification = Dane.KomSprint_ok;
			player.GetComponent<Notifications> ().isLight2Notification = Dane.KomSwiatlo2_ok;
			player.GetComponent<Notifications> ().isTaskInfoNotification = Dane.KomZadaniaInfo_ok;
			player.GetComponent<Notifications> ().isMapNotification = Dane.KomMapa_ok;
			player.GetComponent<Notifications> ().isCrouchNotification = Dane.KomKucanie_ok;
            player.GetComponent<Notifications> ().isDoorNotification = Dane.KomDrzwiWskazowka_ok;
            player.GetComponent<Notifications> ().isHerbsNotification = Dane.KomZiola_ok;
            player.GetComponent<Notifications> ().isSaveNotification= Dane.KomZapis_ok;
            player.GetComponent<Notifications> ().isDragNotification = Dane.KomPodnoszenie_ok;
            player.GetComponent<Notifications> ().isPushNotification = Dane.KomPchanie_ok;
            player.GetComponent<Notifications> ().isSecretNotification = Dane.KomSecret_ok;
            player.GetComponent<Notifications> ().isItemsNotification = Dane.KomItems_ok;
            player.GetComponent<Notifications> ().isInventoryNotification = Dane.KomInventory_ok;
            player.GetComponent<Notifications> ().isBatteriesNotification = Dane.InfoBaterie_ok;
			player.GetComponent<Notifications> ().isChipNotification = Dane.InfoChip_ok;
			player.GetComponent<Notifications> ().isCasseteNotification = Dane.JestKaseta_ok;
			player.GetComponent<Notifications> ().isCassete3Notification = Dane.JestKaseta3_ok;

			// latarka
			flashlight.GetComponent<Flashlight> ().lightRange = Dane.PromienSwiatla;
			flashlight.GetComponent<Flashlight> ().isFlashlightOn = Dane.Latarka_ok;

			// muzyka

			//Gracz.GetComponent<Muzyka> ().WylaczMuzyke_ok = Dane.WylaczMuzyke_ok;
			player.GetComponent<Music> ().isHouseLightMusicOff = Dane.WylaczSwiatloDomu_ok;
			player.GetComponent<Music> ().isSimonWorkshopMusicOff = Dane.WylaczWarsztatSimon_ok;
			player.GetComponent<Music> ().isOldShedMusic2Off = Dane.WylaczStaraSzopa_ok;
			player.GetComponent<Music> ().isAfterTomMusicOff = Dane.WylaczPoTom_ok;
            player.GetComponent<Music> ().isOldShedMusicOff = Dane.WylaczStaraSzopaDreszcz_ok;

            player.GetComponent<Music> ().isBeginMusic = Dane.MuzykaPoczatek_ok;
            player.GetComponent<Music> ().isBeginMonsterMusicStop = Dane.MuzykaPoczatekStop_ok;
            player.GetComponent<Music> ().isBeginMonsterMusic = Dane.MuzykaMonsterPoczatek_ok;
            player.GetComponent<Music> ().isAfterWolfMusic = Dane.MuzykaPoWilku_ok;
			player.GetComponent<Music> ().isBehindHouseMusic = Dane.NiepokojPrzedDomem_ok;
			player.GetComponent<Music> ().isKitchenMusic = Dane.NiepokojKuchnia_ok;
			player.GetComponent<Music> ().isUncleRoomMusic = Dane.NiepokojPokojUncle_ok;
			player.GetComponent<Music> ().isMusicStop = Dane.MuzykaTloStop_ok;
			player.GetComponent<Music> ().isToolShedMusic = Dane.KlimatSzopaNarzedzia_ok;
			player.GetComponent<Music> ().isWellMusic = Dane.KlimatStudnia_ok;
			player.GetComponent<Music> ().isWellAnxiousMusic = Dane.NiepokojStudnia_ok;
			player.GetComponent<Music> ().isStableMusic = Dane.NiepokojStajnia_ok;
			player.GetComponent<Music> ().isGardenMusic = Dane.KlimatOgrod_ok;
			player.GetComponent<Music> ().isBonesMusic = Dane.KlimatKosci_ok;
			player.GetComponent<Music> ().isAliceMusic = Dane.NiepokojAlice_ok;
			player.GetComponent<Music> ().isAliceShedMusic = Dane.KlimatSzopaAlice_ok;
			player.GetComponent<Music> ().isWorkshopMusic = Dane.NiepokojWarsztat_ok;
			player.GetComponent<Music> ().isWorkshopSimonMusic = Dane.KlimatWarsztatSimon_ok;
			player.GetComponent<Music> ().isAnimalCemetaryMusic = Dane.KlimatCmentarzZwierzat_ok;
			player.GetComponent<Music> ().isAliceRoomMusic = Dane.NiepokojSalonAlice_ok;
			player.GetComponent<Music> ().isShedMusic = Dane.NiepokojSzopa_ok;
			player.GetComponent<Music> ().isOldShedMusic = Dane.KlimatStaraSzopa_ok;
			player.GetComponent<Music> ().isBeforeTomMusic = Dane.KlimatPrzedTom_ok;
			player.GetComponent<Music> ().isTomMusic = Dane.NiepokojTom_ok;
			player.GetComponent<Music> ().isTomHallMusic = Dane.KlimatSala_ok;
			player.GetComponent<Music> ().isTom2Music = Dane.NiepokojTom2_ok;
			player.GetComponent<Music> ().isBooksMusic = Dane.KlimatKsiazki_ok;
			player.GetComponent<Music> ().isTom3Music = Dane.NiepokojTom3_ok;
			player.GetComponent<Music> ().isCornfieldMusic = Dane.KlimatKukurydza_ok;
			player.GetComponent<Music> ().isTomCampMusic = Dane.KlimatOboz_ok;
			player.GetComponent<Music> ().isTomUpstairsMusic = Dane.KlimatTomGora_ok;
			player.GetComponent<Music> ().isTomUpstairs2Music = Dane.KlimatTomGora2_ok;
			player.GetComponent<Music> ().isAfterTomMusic = Dane.KlimatPoTom_ok;
			player.GetComponent<Music> ().isFeederMusic = Dane.KlimatKarmnik_ok;
			player.GetComponent<Music> ().isBeforeStevenMusic = Dane.KlimatPrzedSteven_ok;
			player.GetComponent<Music> ().isStevenMusic = Dane.KlimatSteven_ok;
			player.GetComponent<Music> ().isMeatMusic = Dane.KlimatMieso_ok;
			player.GetComponent<Music> ().isStevenUpstairsMusic = Dane.KlimatStevenGora_ok;
			player.GetComponent<Music> ().isStevenShedMusic = Dane.NiepokojSzopaSteven_ok;
			player.GetComponent<Music> ().isBeforePaulMusic = Dane.KlimatPrzedPaul_ok;
			player.GetComponent<Music> ().isPaulMusic = Dane.NiepokojPaul_ok ;
			player.GetComponent<Music> ().isPaulUpstairsMusic = Dane.KlimatPaulGora_ok;
			player.GetComponent<Music> ().isHutMusic = Dane.KlimatChatka_ok;
			player.GetComponent<Music> ().isMonsterUpstairsMusic = Dane.KlimatMonsterGora1_ok;
			player.GetComponent<Music> ().isMonsterUpstairs2Music = Dane.KlimatMonsterGora2_ok;
			player.GetComponent<Music> ().isBeforeShelterMusic = Dane.KlimatPrzedKryjowka_ok;
			player.GetComponent<Music> ().isShelterMusic = Dane.KlimatKryjowka_ok;
			player.GetComponent<Music> ().isShelter2Music = Dane.KlimatKryjowka2_ok;
			player.GetComponent<Music> ().isEndGameMusic = Dane.MuzykaKoniec_ok;
			player.GetComponent<Music> ().isBasementMonsterMusic = Dane.PotworOpuszczonyPiwnica_ok;
            player.GetComponent<Music> ().isBigRoomMusic = Dane.MuzykaDuzyR_ok;
            player.GetComponent<Music> ().isLeftBrookMusic = Dane.MuzykaPotokLewySkrzypce_ok;
            player.GetComponent<Music> ().isCornfield1Music = Dane.KlimatKukurydza1_ok;
            player.GetComponent<Music>().isAfterFlashlightMusic = Dane.KlimatPoLatarka_ok;
            player.GetComponent<Music>().isGrandmaDoorMusic = Dane.KlimatDrzwiBabcia_ok;

            // notatki
            player.GetComponent<Notes>().notesCount = Dane.IloscNotatek;
            player.GetComponent<Notes> ().isNote1 = Dane.Notatka1_ok;
			player.GetComponent<Notes> ().isNote2 = Dane.Notatka2_ok;
			player.GetComponent<Notes> ().isNote3 = Dane.Notatka3_ok;
			player.GetComponent<Notes> ().isNote4 = Dane.Notatka4_ok;
			player.GetComponent<Notes> ().isNote5 = Dane.Notatka5_ok;
			player.GetComponent<Notes> ().isNote6 = Dane.Notatka6_ok;
			player.GetComponent<Notes> ().isNote7 = Dane.Notatka7_ok;
			player.GetComponent<Notes> ().isNote8 = Dane.Notatka8_ok;
			player.GetComponent<Notes> ().isNote9 = Dane.Notatka9_ok;
			player.GetComponent<Notes> ().isNote10 = Dane.Notatka10_ok;
			player.GetComponent<Notes> ().isNote11 = Dane.Notatka11_ok;
			player.GetComponent<Notes> ().isNote12 = Dane.Notatka12_ok;
			player.GetComponent<Notes> ().isNote13 = Dane.Notatka13_ok;
			player.GetComponent<Notes> ().isNote14 = Dane.Notatka14_ok;
			player.GetComponent<Notes> ().isNote15 = Dane.Notatka15_ok;
			player.GetComponent<Notes> ().isNote16 = Dane.Notatka16_ok;
			player.GetComponent<Notes> ().isNote17 = Dane.Notatka17_ok;
			player.GetComponent<Notes> ().isNote18 = Dane.Notatka18_ok;
			player.GetComponent<Notes> ().isNote19 = Dane.Notatka19_ok;
			player.GetComponent<Notes> ().isNote20 = Dane.Notatka20_ok;
			player.GetComponent<Notes> ().isNote21 = Dane.Notatka21_ok;
			player.GetComponent<Notes> ().isNote22 = Dane.Notatka22_ok;
			player.GetComponent<Notes> ().isNote23 = Dane.Notatka23_ok;
			player.GetComponent<Notes> ().isNote24 = Dane.Notatka24_ok;
			player.GetComponent<Notes> ().isNote25 = Dane.Notatka25_ok;
			player.GetComponent<Notes> ().isNote26 = Dane.Notatka26_ok;
			player.GetComponent<Notes> ().isNote27 = Dane.Notatka27_ok;
			player.GetComponent<Notes> ().isNote28 = Dane.Notatka28_ok;
			player.GetComponent<Notes> ().isNote29 = Dane.Notatka29_ok;
			player.GetComponent<Notes> ().isNote30 = Dane.Notatka30_ok;
			player.GetComponent<Notes> ().isNote31 = Dane.Notatka31_ok;
			player.GetComponent<Notes> ().isNote32 = Dane.Notatka32_ok;
			player.GetComponent<Notes> ().isNote33 = Dane.Notatka33_ok;
			player.GetComponent<Notes> ().isNote34 = Dane.Notatka34_ok;
			player.GetComponent<Notes> ().isNote35 = Dane.Notatka35_ok;
			player.GetComponent<Notes> ().isNote36 = Dane.Notatka36_ok;
			player.GetComponent<Notes> ().isNote37 = Dane.Notatka37_ok;
			player.GetComponent<Notes> ().isNote38 = Dane.Notatka38_ok;
			player.GetComponent<Notes> ().isNote39 = Dane.Notatka39_ok;
			player.GetComponent<Notes> ().isNote40 = Dane.Notatka40_ok;
			player.GetComponent<Notes> ().isNote41 = Dane.Notatka41_ok;
			player.GetComponent<Notes> ().isNote42 = Dane.Notatka42_ok;
			player.GetComponent<Notes> ().isNote43 = Dane.Notatka43_ok;
			player.GetComponent<Notes> ().isNote44 = Dane.Notatka44_ok;
			player.GetComponent<Notes> ().isNote45 = Dane.Notatka45_ok;
			player.GetComponent<Notes> ().isNote46 = Dane.Notatka46_ok;
			player.GetComponent<Notes> ().isNote47 = Dane.Notatka47_ok;
			player.GetComponent<Notes> ().isNote48 = Dane.Notatka48_ok;
			player.GetComponent<Notes> ().isNote49 = Dane.Notatka49_ok;
			player.GetComponent<Notes> ().isNote50 = Dane.Notatka50_ok;
			player.GetComponent<Notes> ().isNote51 = Dane.Notatka51_ok;
			player.GetComponent<Notes> ().isNote52 = Dane.Notatka52_ok;
			player.GetComponent<Notes> ().isNote53 = Dane.Notatka53_ok;
			player.GetComponent<Notes> ().isNote54 = Dane.Notatka54_ok;
			player.GetComponent<Notes> ().isFoxNote = Dane.NotatkaLisy_ok;
			player.GetComponent<Notes> ().isWoodPhoto = Dane.ZdjecieDrewno_ok;
			player.GetComponent<Notes> ().isZenoPhoto = Dane.ZdjecieZeno_ok;
			player.GetComponent<Notes> ().isShoppingNote = Dane.NotatkaZakupy_ok;
			player.GetComponent<Notes> ().isQuote1Note = Dane.NotatkaCytat1_ok;
			player.GetComponent<Notes> ().isCornfieldPicture = Dane.RysunekKukurydza_ok;
			player.GetComponent<Notes> ().isLeftBrookNote = Dane.NotatkaPotokLewy_ok;
			player.GetComponent<Notes> ().isMushroomNote = Dane.NotatkaGrzyby_ok;
			player.GetComponent<Notes> ().isBrookPhoto3 = Dane.ZdjeciePotok3_ok;
			player.GetComponent<Notes> ().isBrookPhoto2 = Dane.ZdjeciePotok2_ok;
			player.GetComponent<Notes> ().isBrookPhoto1 = Dane.ZdjeciePotok1_ok;
			player.GetComponent<Notes> ().isSimonPicture = Dane.RysunekSimon_ok;
			player.GetComponent<Notes> ().isRapNote = Dane.NotatkaRap_ok;
			player.GetComponent<Notes> ().isTowerPhoto = Dane.ZdjecieAmbona_ok;
			player.GetComponent<Notes> ().isWellPhoto = Dane.ZdjecieStudnia_ok;
			player.GetComponent<Notes> ().isQuote2Note = Dane.NotatkaCytat2_ok;
			player.GetComponent<Notes> ().isMonumentPhoto = Dane.ZdjeciePomnik_ok;
			player.GetComponent<Notes> ().isInventionNote = Dane.NotatkaWynalazki_ok;
			player.GetComponent<Notes> ().isWorkshopPhoto = Dane.ZdjecieWarsztat_ok;
			player.GetComponent<Notes> ().isDarkForestNote = Dane.NotatkaCiemny_ok;
			player.GetComponent<Notes> ().isAnimalsNote = Dane.NotatkaZwierzeta_ok;
			player.GetComponent<Notes> ().isNightNote = Dane.NotatkaNoc_ok;
			player.GetComponent<Notes> ().isWardrobePhoto = Dane.ZdjecieSzafa_ok;
			player.GetComponent<Notes> ().isShedPhoto = Dane.ZdjecieSzopa_ok;
			player.GetComponent<Notes> ().isCampPhoto = Dane.ZdjecieOboz_ok;
			player.GetComponent<Notes> ().isMaryNote = Dane.NotatkaMary_ok;
			player.GetComponent<Notes> ().isDaughterPicture = Dane.RysunekCorki_ok;
			player.GetComponent<Notes> ().isDiplomaNote = Dane.NotatkaDyplom_ok;
			player.GetComponent<Notes> ().isTomPicture = Dane.RysunekTom_ok;
			player.GetComponent<Notes> ().isQuote3Note = Dane.NotatkaCytat3_ok;
			player.GetComponent<Notes> ().isMonsterPicture = Dane.RysunekPotwor_ok;
			player.GetComponent<Notes> ().iswhisperNote = Dane.NotatkaSzepty_ok;
			player.GetComponent<Notes> ().isQuote4Note = Dane.NotatkaCytat4_ok;
			player.GetComponent<Notes> ().isPlantPicture = Dane.RysunekRosliny_ok;
			player.GetComponent<Notes> ().isFieldNote = Dane.NotatkaPole_ok;
			player.GetComponent<Notes> ().isArenaNote = Dane.NotatkaArena_ok;
			player.GetComponent<Notes> ().isQuote5Note = Dane.NotatkaCytat5_ok;
			player.GetComponent<Notes> ().isBrookPhoto4 = Dane.ZdjeciePotok4_ok;
			player.GetComponent<Notes> ().isAliensNote = Dane.NotatkaKosmici_ok;
			player.GetComponent<Notes> ().isQuote6Note = Dane.NotatkaCytat6_ok;
            player.GetComponent<Notes> ().isDemonNote = Dane.NotatkaDemona_ok;

            // screamer
            player.GetComponent<Screamer> ().isClock = Dane.Zegar_ok;
			player.GetComponent<Screamer> ().isKitchenLamp = Dane.Lampa_ok;
			player.GetComponent<Screamer> ().isLampBefore = Dane.Lampa_przed_ok;
			player.GetComponent<Screamer> ().isLight = Dane.Swiatlo2_ok;
			player.GetComponent<Screamer> ().isRustle = Dane.Szelest_ok;
			player.GetComponent<Screamer> ().isHay = Dane.Siano_ok;
			player.GetComponent<Screamer> ().isWood = Dane.Drewno_ok;
			player.GetComponent<Screamer> ().isWolf = Dane.Wilk_ok;
			player.GetComponent<Screamer> ().isRustle2 = Dane.Szelest2_ok;
			player.GetComponent<Screamer> ().isAtmosphere = Dane.Klimat_ok;
			player.GetComponent<Screamer> ().isWhisper = Dane.Szept_ok;
			player.GetComponent<Screamer> ().isRadioSpain = Dane.RadioSpain_ok;
			player.GetComponent<Screamer> ().isWellScream = Dane.StudniaKrzyk_ok;
			player.GetComponent<Screamer> ().isWoodShed = Dane.DrewnoSzopa_ok;
			player.GetComponent<Screamer> ().isRat = Dane.Szczur_ok;
			player.GetComponent<Screamer> ().isWellWater = Dane.StudniaWoda_ok;
			player.GetComponent<Screamer> ().isRadioFires = Dane.RadioStrzaly_ok;
			player.GetComponent<Screamer> ().isFactory = Dane.OdglosyFabryka_ok;
			player.GetComponent<Screamer> ().isChains = Dane.Lancuchy_ok;
			player.GetComponent<Screamer> ().isFactory2 = Dane.OdglosyFabryka2_ok;
			player.GetComponent<Screamer> ().isMeanLaugh = Dane.WrednySmiech_ok;
			player.GetComponent<Screamer> ().isActiveLaugh = Dane.AktywujSmiech_ok;
			player.GetComponent<Screamer> ().isRaven = Dane.Kruki_ok;
			player.GetComponent<Screamer> ().isGirlLaugh = Dane.SmiechDzw_ok;
			player.GetComponent<Screamer> ().isClock = Dane.KrzykDzw_ok;
			player.GetComponent<Screamer> ().isMusicBox = Dane.Pozytywka_ok;
			player.GetComponent<Screamer> ().isKnock = Dane.Pukanie_ok;
			player.GetComponent<Screamer> ().isGlass = Dane.Szklo_ok;
			player.GetComponent<Screamer> ().isStairsCreak = Dane.SkrzypienieSchody_ok;
			player.GetComponent<Screamer> ().isStevenScream = Dane.KrzykSteven_ok;
			player.GetComponent<Screamer> ().isDoorBellActive = Dane.DzwonekDrzwiWlacz_ok;
			player.GetComponent<Screamer> ().isDoorBell = Dane.DzwonekDrzwi_ok;
			player.GetComponent<Screamer> ().isPaulCreak = Dane.SkrzypienieZachod_ok;
			player.GetComponent<Screamer> ().isSteps = Dane.Kroki_ok;
			player.GetComponent<Screamer> ().isPaulStairsCreak = Dane.SkrzypienieSchodyZachod_ok;
			player.GetComponent<Screamer> ().isCloseDoor = Dane.DrzwiZamknij_ok;
			player.GetComponent<Screamer> ().isOpenDoor = Dane.DrzwiOtworz_ok;
			player.GetComponent<Screamer> ().isCorpse = Dane.Trup_ok;
			player.GetComponent<Screamer> ().isWhisper2 = Dane.Szept2_ok;
			player.GetComponent<Screamer> ().isWind = Dane.Wiatr_ok;
			player.GetComponent<Screamer> ().isWindEffect = Dane.WiatrEfekt_ok;
			player.GetComponent<Screamer> ().isTool = Dane.Narzedzia_ok;
			player.GetComponent<Screamer> ().isBones = Dane.Kosci_ok;
			player.GetComponent<Screamer> ().isThorns = Dane.Ciernie_ok;
			player.GetComponent<Screamer> ().isFood = Dane.Jedzenie_ok;
			player.GetComponent<Screamer> ().isDog = Dane.Pies_ok;
			player.GetComponent<Screamer> ().isBrook = Dane.Potok_ok;
			player.GetComponent<Screamer> ().isBreath = Dane.Oddech1_ok;
			player.GetComponent<Screamer> ().isBreath2 = Dane.Oddech2_ok;
			player.GetComponent<Screamer> ().isPhone = Dane.Telefon_ok;
			player.GetComponent<Screamer> ().isPhone2 = Dane.TelefonBeep_ok;
			player.GetComponent<Screamer> ().isWellWhispers = Dane.SzeptyStudnia_ok;
            player.GetComponent<Screamer>().isDogRoar = Dane.RykPsa_ok;
            player.GetComponent<Screamer>().isBoneShedBreath = Dane.OddechSzopaKosc_ok;
            player.GetComponent<Screamer>().isWoodBird = Dane.PtakSzalas_ok;
            player.GetComponent<Screamer>().isLeaves = Dane.LiscieGanja_ok;
            player.GetComponent<Screamer>().isShedFurniture = Dane.SzopaMeble_ok;
            player.GetComponent<Screamer>().isBrookScream = Dane.KrzykPotok_ok;
            player.GetComponent<Screamer>().isGrandmaGlass = Dane.SzkloBabcia_ok;
            player.GetComponent<Screamer>().isGlassKnock = Dane.PukanieSzyba_ok;
            player.GetComponent<Screamer>().isAliceShed = Dane.SzopaAlice_ok;
            player.GetComponent<Screamer>().isHutLight = Dane.SwiatloChatka_ok;
            player.GetComponent<Screamer>().isFloorCreak = Dane.SkrzypPodloga_ok;
            player.GetComponent<Screamer>().isScaryOwl = Dane.StrasznaSowa_ok;
            player.GetComponent<Screamer>().isScaryOwl2 = Dane.StrasznaSowa2_ok;
            player.GetComponent<Screamer>().isWaterSplash = Dane.WodaPlusk_ok;
            player.GetComponent<Screamer>().isFoxScream = Dane.KrzykLisa_ok;
            player.GetComponent<Screamer>().isShockScream = Dane.KrzykShock_ok;
            player.GetComponent<Screamer>().isFallTree = Dane.DrzewoFall_ok;
            player.GetComponent<Screamer>().isOpenJumpscareDoor = Dane.DrzwiOtworzJmpPo_ok;

            // zadania
            player.GetComponent<Tasks> ().isFirstTask = Dane.ZadaniePoczatek_ok;	
			player.GetComponent<Tasks> ().isSearchTask = Dane.ZadanieSzukajInfo_ok;
			player.GetComponent<Tasks> ().isWoodKeyTask = Dane.ZadanieKluczDrewno_ok;
			player.GetComponent<Tasks> ().isMagicWellTask = Dane.ZadanieMagicznaStudnia_ok;
			player.GetComponent<Tasks> ().isWellStonesTask = Dane.ZadanieKamienieStudnia_ok;
			player.GetComponent<Tasks> ().isCassete1Task = Dane.ZadanieKaseta1_ok;
            player.GetComponent<Tasks> ().isGardenDoorTask = Dane.ZadanieDrzwiOgrod_ok;
            player.GetComponent<Tasks> ().isBonesTask = Dane.ZadanieKosci_ok;
			player.GetComponent<Tasks> ().isGoToAliceTask = Dane.ZadanieIdzAlice_ok;
			player.GetComponent<Tasks> ().isAliceSearchTask = Dane.ZadanieAliceInfo_ok;
			player.GetComponent<Tasks> ().isSimonElementTask = Dane.ZadanieSimonElement_ok;
            player.GetComponent<Tasks> ().isWorkshopTask = Dane.ZadanieWarsztat_ok;
            player.GetComponent<Tasks> ().isBrokenKeyTask = Dane.ZadanieZepsutyKlucz_ok;
			player.GetComponent<Tasks> ().isFixKeyTask = Dane.ZadanieNaprawKlucz_ok;
			player.GetComponent<Tasks> ().isAnimalCemetaryTask = Dane.ZadanieCmentarzZwierz_ok;
			player.GetComponent<Tasks> ().isVictorBrookTask = Dane.ZadanieVictorPotok_ok;
			player.GetComponent<Tasks> ().isAliceRoomTask = Dane.ZadanieSalonAlice_ok;
			player.GetComponent<Tasks> ().isCornfieldTask = Dane.ZadanieKukurydza_ok;
			player.GetComponent<Tasks> ().isAxeTask = Dane.ZadanieSiekiera_ok;
			player.GetComponent<Tasks> ().isCorridorWardrobeTask = Dane.ZadanieSzafaKorytarz_ok;
			player.GetComponent<Tasks> ().isEdwardCupboardTask = Dane.ZadanieSzafkaEdward_ok;
			player.GetComponent<Tasks> ().isCassete2Task = Dane.ZadanieKaseta2_ok;
			player.GetComponent<Tasks> ().isGoToTrialTask = Dane.ZadanieIdzSzlak_ok;
			player.GetComponent<Tasks> ().isGoTrailTask = Dane.ZadanieKierujSzlak_ok;
			player.GetComponent<Tasks> ().isGetToTomRoadTask = Dane.ZadaniePrzedostanSie_ok;
			player.GetComponent<Tasks> ().isTomSearchTask = Dane.ZadanieTomInfo_ok;
			player.GetComponent<Tasks> ().isTomCornifieldTask = Dane.ZadanieTomKukurydza_ok;
			player.GetComponent<Tasks> ().isCassete3Task = Dane.ZadanieKaseta3_ok;
			player.GetComponent<Tasks> ().isTompCampTask = Dane.ZadanieTomOboz_ok;
			player.GetComponent<Tasks> ().isTomPumpkinTask = Dane.ZadanieTomDynia_ok;
			player.GetComponent<Tasks> ().isTomChipTask = Dane.ZadanieTomChip_ok;
			player.GetComponent<Tasks> ().isRavineTask = Dane.ZadanieWawoz_ok;
			player.GetComponent<Tasks> ().isGoRavineTask = Dane.ZadanieIdzWawoz_ok;
			player.GetComponent<Tasks> ().isAbandonedSearchTask = Dane.ZadanieOpuszczonyInfo_ok;
			player.GetComponent<Tasks> ().isCassete4Task = Dane.ZadanieKaseta4_ok;
			player.GetComponent<Tasks> ().isStevenSearchTask = Dane.ZadanieStevenInfo_ok;
			player.GetComponent<Tasks> ().isStevenKeyTask = Dane.ZadanieStevenKlucz_ok;
			player.GetComponent<Tasks> ().isStevenMushroomTask = Dane.ZadanieStevenGrzyb_ok;
			player.GetComponent<Tasks> ().isStevenPlantTask = Dane.ZadanieStevenRoslina_ok;
			player.GetComponent<Tasks> ().isStevenSkullTask = Dane.ZadanieStevenCzaszka_ok;
			player.GetComponent<Tasks> ().isStevenAcidTask = Dane.ZadanieKwas_ok;
			player.GetComponent<Tasks> ().isStevenShedTask = Dane.ZadanieStevenSzopa_ok;
			player.GetComponent<Tasks> ().isStevenNoteTask = Dane.ZadanieStevenNotatka_ok;
			player.GetComponent<Tasks> ().isStevenBrookTask = Dane.ZadanieStevenPotok_ok;
			player.GetComponent<Tasks> ().isPaulSearchTask = Dane.ZadaniePaulInfo_ok;
			player.GetComponent<Tasks> ().isPaulDoorTask = Dane.ZadaniePaulDrzwi_ok;
			player.GetComponent<Tasks> ().isHutTask = Dane.ZadanieChatka_ok;
			player.GetComponent<Tasks> ().isDevilsBrookTask = Dane.ZadaniePotokDiably_ok;
			player.GetComponent<Tasks> ().isDevilsShelterTask = Dane.ZadanieKryjowkaDiably_ok;
			player.GetComponent<Tasks> ().isShelterFamilyTask = Dane.ZadanieKryjowkaRodzina_ok;

			player.GetComponent<Tasks> ().isFirstTaskRemoved = Dane.ZadaniePoczatek_Usun;
			player.GetComponent<Tasks> ().isSearchTaskRemoved = Dane.ZadanieSzukajInfo_Usun;
			player.GetComponent<Tasks> ().isWoodKeyTaskRemoved = Dane.ZadanieKluczDrewno_Usun;
			player.GetComponent<Tasks> ().isMagicWellTaskRemoved = Dane.ZadanieMagicznaStudnia_Usun;
			player.GetComponent<Tasks> ().isWellStonesTaskRemoved = Dane.ZadanieKamienieStudnia_Usun;
			player.GetComponent<Tasks> ().isCassete1TaskRemoved = Dane.ZadanieKaseta1_Usun;
            player.GetComponent<Tasks> ().isGardenDoorTaskRemoved = Dane.ZadanieDrzwiOgrod_Usun;
            player.GetComponent<Tasks> ().isBonesTaskRemoved = Dane.ZadanieKosci_Usun;
			player.GetComponent<Tasks> ().isGoToAliceTaskRemoved = Dane.ZadanieIdzAlice_Usun;
			player.GetComponent<Tasks> ().isAliceSearchTaskRemoved = Dane.ZadanieAliceInfo_Usun;
			player.GetComponent<Tasks> ().isSimonElementTaskRemoved = Dane.ZadanieSimonElement_Usun;
            player.GetComponent<Tasks> ().isWorkshopTaskRemoved = Dane.ZadanieWarsztat_Usun;
            player.GetComponent<Tasks> ().isBrokenKeyTaskRemoved = Dane.ZadanieZepsutyKlucz_Usun;
			player.GetComponent<Tasks> ().isFixKeyTaskRemoved = Dane.ZadanieNaprawKlucz_Usun;
			player.GetComponent<Tasks> ().isAnimalCemetaryTaskRemoved = Dane.ZadanieCmentarzZwierz_Usun;
			player.GetComponent<Tasks> ().isVictorBrookTaskRemoved = Dane.ZadanieVictorPotok_Usun;
			player.GetComponent<Tasks> ().isAliceRoomTaskRemoved = Dane.ZadanieSalonAlice_Usun;
			player.GetComponent<Tasks> ().isCornfieldTaskRemoved = Dane.ZadanieKukurydza_Usun;
			player.GetComponent<Tasks> ().isAxeTaskRemoved = Dane.ZadanieSiekiera_Usun;
			player.GetComponent<Tasks> ().isCorridorWardrobeTaskRemoved = Dane.ZadanieSzafaKorytarz_Usun;
			player.GetComponent<Tasks> ().isEdwardCupboardTaskRemoved = Dane.ZadanieSzafkaEdward_Usun;
			player.GetComponent<Tasks> ().isCassete2TaskRemoved = Dane.ZadanieKaseta2_Usun;
			player.GetComponent<Tasks> ().isGoToTrialTaskRemoved = Dane.ZadanieIdzSzlak_Usun;
			player.GetComponent<Tasks> ().isGoTrailTaskRemoved = Dane.ZadanieKierujSzlak_Usun;
			player.GetComponent<Tasks> ().isGetToTomRoadTaskRemoved = Dane.ZadaniePrzedostanSie_Usun;
			player.GetComponent<Tasks> ().isTomSearchTaskRemoved = Dane.ZadanieTomInfo_Usun;
			player.GetComponent<Tasks> ().isTomCornifieldTaskRemoved = Dane.ZadanieTomKukurydza_Usun;
			player.GetComponent<Tasks> ().isCassete3TaskRemoved = Dane.ZadanieKaseta3_Usun;
			player.GetComponent<Tasks> ().isTompCampTaskRemoved = Dane.ZadanieTomOboz_Usun;
			player.GetComponent<Tasks> ().isTomPumpkinTaskRemoved = Dane.ZadanieTomDynia_Usun;
			player.GetComponent<Tasks> ().isTomChipTaskRemoved = Dane.ZadanieTomChip_Usun;
			player.GetComponent<Tasks> ().isRavineTaskRemoved = Dane.ZadanieWawoz_Usun;
			player.GetComponent<Tasks> ().isGoRavineTaskRemoved = Dane.ZadanieIdzWawoz_Usun;
			player.GetComponent<Tasks> ().isAbandonedSearchTaskRemoved = Dane.ZadanieOpuszczonyInfo_Usun;
			player.GetComponent<Tasks> ().isCassete4TaskRemoved = Dane.ZadanieKaseta4_Usun;
			player.GetComponent<Tasks> ().isStevenSearchTaskRemoved = Dane.ZadanieStevenInfo_Usun;
			player.GetComponent<Tasks> ().isStevenKeyTaskRemoved = Dane.ZadanieStevenKlucz_Usun;
			player.GetComponent<Tasks> ().isStevenMushroomTaskRemoved = Dane.ZadanieStevenGrzyb_Usun;
			player.GetComponent<Tasks> ().isStevenPlantTaskRemoved = Dane.ZadanieStevenRoslina_Usun;
			player.GetComponent<Tasks> ().isStevenSkullTaskRemoved = Dane.ZadanieStevenCzaszka_Usun;
			player.GetComponent<Tasks> ().isStevenAcidTaskRemoved = Dane.ZadanieKwas_Usun;
			player.GetComponent<Tasks> ().isStevenShedTaskRemoved = Dane.ZadanieStevenSzopa_Usun;
			player.GetComponent<Tasks> ().isStevenNoteTaskRemoved = Dane.ZadanieStevenNotatka_Usun;
			player.GetComponent<Tasks> ().isStevenBrookTaskRemoved = Dane.ZadanieStevenPotok_Usun;
			player.GetComponent<Tasks> ().isPaulSearchTaskRemoved = Dane.ZadaniePaulInfo_Usun;
			player.GetComponent<Tasks> ().isPaulDoorTaskRemoved = Dane.ZadaniePaulDrzwi_Usun;
			player.GetComponent<Tasks> ().isHutTaskRemoved = Dane.ZadanieChatka_Usun;
			player.GetComponent<Tasks> ().isDevilsBrookTaskRemoved = Dane.ZadaniePotokDiably_Usun;
			player.GetComponent<Tasks> ().isDevilsShelterTaskRemoved = Dane.ZadanieKryjowkaDiably_Usun;
			player.GetComponent<Tasks> ().isShelterFamilyTaskRemoved = Dane.ZadanieKryjowkaRodzina_Usun;

			player.GetComponent<Tasks> ().isGoTrailVoice = Dane.GlosIdzSzlak_ok;

			player.GetComponent<Tasks> ().isGardenDoorLocked = Dane.DrzwiOgrod_lock;
			player.GetComponent<Tasks> ().isCornfieldDoorLocked = Dane.DrzwiKukurydza_lock;
			player.GetComponent<Tasks> ().isStableDoorLocked = Dane.DrzwiStajnia_lock;
			player.GetComponent<Tasks> ().isCorridorWardrobeLocked = Dane.SzafkaKorytarz_lock;
			player.GetComponent<Tasks> ().isUncleDoorLocked = Dane.DrzwiPokojW_lock;
			player.GetComponent<Tasks> ().isKitchenWardrobeLocked = Dane.SzafkaKuchnia_lock;
			player.GetComponent<Tasks> ().isSecretRoomDoorLocked = Dane.DrzwiKamping_lock;
			player.GetComponent<Tasks> ().isPlanksLocked = Dane.DeskiSzopa_lock;
			player.GetComponent<Tasks> ().isPlanksDestroyed = Dane.DeskiZniszczone_ok;
			player.GetComponent<Tasks> ().isToolShedDoorLocked = Dane.DrzwiSzopaNarzedzia_lock;
			player.GetComponent<Tasks> ().isNicheDoorLocked = Dane.DrzwiWneka_lock;
			player.GetComponent<Tasks> ().isCasseteInserted = Dane.WlozKasete_ok;
			player.GetComponent<Tasks> ().isBatteriesPut = Dane.WlozBaterie_ok;
			player.GetComponent<Tasks> ().isAliceRoomDoorLocked = Dane.DrzwiSalonPoludnie_lock;
			player.GetComponent<Tasks> ().isHalluns = Dane.Halucynacje_ok;
			player.GetComponent<Tasks> ().isFactoryMetalDoorLocked = Dane.DrzwiFabrykaMetal_lock;
			player.GetComponent<Tasks> ().isBrokenKey = Dane.ZepsutyKlucz_ok;
			player.GetComponent<Tasks> ().isWheel = Dane.Kolo_ok;
			player.GetComponent<Tasks> ().isFixedKey = Dane.NaprawionyKlucz_ok;
			player.GetComponent<Tasks> ().isFactoryWoodenDoorLocked = Dane.DrzwiFabrykaDrewno_lock;
			player.GetComponent<Tasks> ().isShedCupboardLocked = Dane.SzafkaSzopa_lock;
			player.GetComponent<Tasks> ().isCassete2Inserted = Dane.WlozKasete2_ok;
			player.GetComponent<Tasks> ().isTomRoomDoorLocked = Dane.DrzwiPokojTom_lock;
			player.GetComponent<Tasks> ().isTomUpstairsDoorLocked = Dane.DrzwiTomGora_lock;
			player.GetComponent<Tasks> ().isCassete3Inserted = Dane.WlozKasete3_ok;
			player.GetComponent<Tasks> ().isLackChip = Dane.BrakChip_ok;
			player.GetComponent<Tasks> ().isChipPut = Dane.WlozChip_ok;
			player.GetComponent<Tasks> ().isOldWardrobeLocked = Dane.SzafaStaryDom_lock;
			player.GetComponent<Tasks> ().isCassete4Inserted = Dane.WlozKasete4_ok;
			player.GetComponent<Tasks> ().isStevenDoorLocked = Dane.DrzwiSteven_lock;
			player.GetComponent<Tasks> ().isStevenGrille = Dane.KratySteven_lock;
			player.GetComponent<Tasks> ().isPaulDoorLocked = Dane.DrzwiZachod_lock;
			player.GetComponent<Tasks> ().isCassete1Played = Dane.Kaseta1Odtworzona;
			player.GetComponent<Tasks> ().isCassete2Played = Dane.Kaseta2Odtworzona;
			player.GetComponent<Tasks> ().isCassete3Played = Dane.Kaseta3Odtworzona;
			player.GetComponent<Tasks> ().isCassete4Played = Dane.Kaseta4Odtworzona;
			player.GetComponent<Tasks> ().isCassete5Played = Dane.Kaseta5Odtworzona;
			player.GetComponent<Tasks> ().isStevenShedLocked = Dane.SzopaStevenMonster_ok;
            player.GetComponent<Tasks> ().isHallunsFlashback = Dane.HalunyOgrodFlashback_ok;
            player.GetComponent<Tasks> ().isPumpkin = Dane.DyniaZad_ok;
			player.GetComponent<Tasks> ().isLabPlant = Dane.RoslinaLabZad_ok;
			player.GetComponent<Tasks> ().isLabMushroom = Dane.GrzybLabZad_ok;
			player.GetComponent<Tasks> ().isLabSkull = Dane.CzaszkaLabZad_ok;
			player.GetComponent<Tasks> ().isLab = Dane.Lab_ok;
			player.GetComponent<Tasks> ().isLabPot = Dane.LabMikstura_ok;
			player.GetComponent<Tasks> ().isGrilleDestroyed = Dane.KratyZniszczone_ok;

			// ksiazki
			player.GetComponent<TaskBooks> ().isTaskDone = Dane.Wykonane_ok;


            // haluny

            player.GetComponent<Halluns>().isStartGanja1 = Dane.Marysia1_ok;
            player.GetComponent<Halluns>().isStartGanja2 = Dane.Marysia2_ok;
            player.GetComponent<Halluns>().isStartGanja3 = Dane.Marysia3_ok;
            player.GetComponent<Halluns>().isStartGanja4 = Dane.Marysia4_ok;
            player.GetComponent<Halluns>().isStartGanja5 = Dane.Marysia5_ok;
            player.GetComponent<Halluns>().isEndGanja1 = Dane.KoniecMarysia1_ok;
            player.GetComponent<Halluns>().isEndGanja2 = Dane.KoniecMarysia2_ok;
            player.GetComponent<Halluns>().isEndGanja3 = Dane.KoniecMarysia3_ok;
            player.GetComponent<Halluns>().isEndGanja4 = Dane.KoniecMarysia4_ok;
            player.GetComponent<Halluns>().isEndGanja5 = Dane.KoniecMarysia5_ok;
            Halluns.fireCount = Dane.IloscZapalen;

            // scarecrow straszak

            player.GetComponent<StraszakScarecrow>().MonsterKorytarzScarecrow_ok = Dane.MonsterKorytarzScarecrow_ok;
            player.GetComponent<StraszakScarecrow>().MonsterStajniaScarecrow_ok = Dane.MonsterStajniaScarecrow_ok;
            player.GetComponent<StraszakScarecrow>().MonsterWychodekScarecrow_ok = Dane.MonsterWychodekScarecrow_ok;
            player.GetComponent<StraszakScarecrow>().MonsterSzalasScarecrow_ok = Dane.MonsterSzalasScarecrow_ok;
            player.GetComponent<StraszakScarecrow>().MonsterSzalasSchowal_ok = Dane.MonsterSzalasSchowal_ok;
            player.GetComponent<StraszakScarecrow>().MonsterSzopaScarecrow_ok = Dane.MonsterSzopaScarecrow_ok;

            //ManagerGry.enabled = true;

        }

		Wczytano_ok = true;

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag("MuzykaTlo1_stop") && DomZapis_ok == false)
		{
			DomZapis_ok = true;
			Zapisz ();
		}

		else if (other.gameObject.CompareTag("MuzykaKlimat4_trigger") && OgrodZapis_ok == false)
		{
			OgrodZapis_ok = true;
			Zapisz ();
		}

		else if (other.gameObject.CompareTag("ZadanieAliceInfo_trigger") && DomAliceZapis_ok == false && tasksScript.isGoToAliceTask == true)
		{
			DomAliceZapis_ok = true;
			Zapisz ();
		}

		else if (other.gameObject.CompareTag("MuzykaKlimat7_trigger") && FabrykaZapis_ok == false)
		{
			FabrykaZapis_ok = true;
			Zapisz ();
		}

		else if (other.gameObject.CompareTag("ZapisWarsztat_trigger") && FabrykaZapis2_ok == false)
		{
			FabrykaZapis2_ok = true;
			Zapisz ();
		}

		else if (other.gameObject.CompareTag("LewyPotokZapis_trigger") && LewyPotokZapis_ok == false && tasksScript.isVictorBrookTask == true)
		{
			LewyPotokZapis_ok = true;
			Zapisz ();
		}

		else if (other.gameObject.CompareTag("MonsterDyniaWylacz_trigger") && ObozTomZapis_ok == false && tasksScript.isTompCampTask == true)
		{
			ObozTomZapis_ok = true;
			Zapisz ();
		}

		else if (other.gameObject.CompareTag("MonsterTomZapis_trigger") && MonsterTomZapis_ok == false && tasksScript.isRavineTask == true)
		{
			MonsterTomZapis_ok = true;
			Zapisz ();
		}

		else if (other.gameObject.CompareTag("MuzykaPrzedSteven_trigger") && PrzedStevenZapis_ok == false && tasksScript.isStevenSearchTask == true)
		{
			PrzedStevenZapis_ok = true;
			Zapisz ();
		}

		else if (other.gameObject.CompareTag("MonstersLasMiesoWylacz_trigger") && MonsterMiesoZapis_ok == false && tasksScript.isStevenKeyTask == true)
		{
			MonsterMiesoZapis_ok = true;
			Zapisz ();
		}

		//else if (other.gameObject.CompareTag("MonsterSzopaStevenBezpieczny_trigger") && SzopaStevenZapis_ok == false)
		//{
		//	SzopaStevenZapis_ok = true;
		//	Zapisz ();
		//}

		else if (other.gameObject.CompareTag("PaulZapis_trigger") && PaulZapis_ok == false && tasksScript.isPaulSearchTask == true)
		{
			PaulZapis_ok = true;
			Zapisz ();
		}

		else if (other.gameObject.CompareTag("KryjowkaDiablow_trigger") && KryjowkaZapis_ok == false && tasksScript.isDevilsShelterTask == true)
		{
			KryjowkaZapis_ok = true;
			Zapisz ();
		}

	}

}

[Serializable]
class GraczDane{

	public string NazwaSceny;
	public float Zdrowie;
	public Vector3Gracz Pozycja;
	public QuaternionGracz Obrot;

	// punkty zapisu

	public bool PoczatekZapis_ok = false;
	public bool DomZapis_ok = false;
	public bool StudniaZapis_ok = false;
	public bool OgrodZapis_ok = false;
	public bool KosciZapis_ok = false;
	public bool IdzAliceZapis_ok = false;
	public bool DomAliceZapis_ok = false;
	public bool BrakujaceKoloZapis_ok = false;
	public bool NaprawionyKluczZapis_ok = false;
	public bool FabrykaZapis_ok = false;
	public bool FabrykaZapis2_ok = false;
	public bool LewyPotokZapis_ok = false;
	public bool KombinerkiZapis_ok = false;
	public bool KukurydzaZapis_ok = false;
	public bool KluczSzafaKorytarzZapis_ok = false;
	public bool IdzSzlakZapis_ok = false;
    public bool PrzedPajakJumpscareZapis_ok = false;
    public bool PrzedostanSieZapis_ok = false;
	public bool ObozTomZapis_ok = false;
	public bool TomGoraZapis_ok = false;
	public bool MonsterTomZapis_ok = false;
	public bool IdzWawozZapis_ok = false;
	public bool PrzedStevenZapis_ok = false;
	public bool MonsterMiesoZapis_ok = false;
	public bool GrzybZapis_ok = false;
	public bool SzopaStevenZapis_ok = false;
	public bool PaulZapis_ok = false;
	public bool PaulGoraZapis_ok = false;
	public bool ChatkaZapis_ok = false;
	public bool KryjowkaZapis_ok = false;


	//zapis gracz
	public float MaxStamina;
	public int RegeneracjaStaminy;
	public bool muchy;

	// Zapis ekwipunku
	public int IloscSecretItems;
	public int IloscSecretPlaces;
	public int IloscNiebieskieZiola;
	public int IloscZieloneZiola;
	public int IloscMiksturaZdrowie;
	public int IloscMiksturaStamina;
    public int IloscFiolek;

    // sekretne miejsca
    public bool SPGrobRocky_ok;
	public bool SPCmentarzZwierzat_ok;
	public bool SPOgrodSimona_ok;
	public bool SPObozToma_ok;
	public bool SPKryjowkaDiably_ok;
	public bool SPCmentarzWojna_ok;
	public bool SPDomek_ok;
	public bool SPPiwnica_ok;
	public bool SPPoleGrzybowe_ok;
	public bool SPCiemnyLas_ok;
	public bool SPWiezaKosci_ok;
	public bool SPNozowaArena_ok;
	public bool SPJaskinia_ok;
	public bool SPPomnik_ok;
	public bool SPStatekKosmiczny_ok;

	public bool KluczV1_ok;
	public bool Oliwa_ok;
	public bool KluczV2_ok;
	public bool KluczV3_ok;
	public bool KluczV4_ok;
	public bool Baterie_ok;
	public bool Kaseta1_ok;
	public bool Kosc1_ok;
	public bool Kosc2_ok;
	public bool Kosc3_ok;
	public bool Kosc4_ok;
	public bool Kosc5_ok;
	public bool KluczWneka_ok;
	public bool KluczKamping_ok;
	public bool KluczFabrykaBroken_ok;
	public bool BrakujaceKolo_ok;
	public bool KluczFabrykaFixed_ok;
	public bool Lom_ok;
	public bool KluczSalonPoludnie_ok;
	public bool Kombinerki_ok;
	public bool Siekiera_ok;
	public bool KluczSzafaKorytarz_ok;
	public bool KluczSzafkaSzopa_ok;
	public bool Kaseta2_ok;
	public bool Dynia_ok;
	public bool KluczTomGora_ok;
	public bool KluczPokojTom_ok;
	public bool Kaseta3_ok;
	public bool Chip_ok;
	public bool KluczSzafaStaryDom_ok;
	public bool Kaseta4_ok;
	public bool KluczStevena_ok;
	public bool RoslinaLab_ok;
	public bool GrzybLab_ok;
	public bool CzaszkaLab_ok;
	public bool Mikstura_ok;
	public bool KluczPokojZachod_ok;

	public bool KluczV1_Usun;
	public bool Oliwa_Usun;
	public bool KluczV2_Usun;
	public bool KluczV3_Usun;
	public bool KluczV4_Usun;
	public bool Baterie_Usun;
	public bool Kaseta1_Usun;
	public bool Kosc1_Usun;
	public bool Kosc2_Usun;
	public bool Kosc3_Usun;
	public bool Kosc4_Usun;
	public bool Kosc5_Usun;
	public bool KluczWneka_Usun;
	public bool KluczKamping_Usun;
	public bool KluczFabrykaBroken_Usun;
	public bool BrakujaceKolo_Usun;
	public bool KluczFabrykaFixed_Usun;
	public bool Lom_Usun;
	public bool KluczSalonPoludnie_Usun;
	public bool Kombinerki_Usun;
	public bool Siekiera_Usun;
	public bool KluczSzafaKorytarz_Usun;
	public bool KluczSzafkaSzopa_Usun;
	public bool Kaseta2_Usun;
	public bool Dynia_Usun;
	public bool KluczTomGora_Usun;
	public bool KluczPokojTom_Usun;
	public bool Kaseta3_Usun;
	public bool Chip_Usun;
	public bool KluczSzafaStaryDom_Usun;
	public bool Kaseta4_Usun;
	public bool KluczStevena_Usun;
	public bool RoslinaLab_Usun;
	public bool GrzybLab_Usun;
	public bool CzaszkaLab_Usun;
	public bool Mikstura_Usun;
	public bool KluczPokojZachod_Usun;

	public bool SecretItem1_ok;
	public bool SecretItem2_ok;
	public bool SecretItem3_ok;
	public bool SecretItem4_ok;
	public bool SecretItem5_ok;
	public bool SecretItem6_ok;
	public bool SecretItem7_ok;
	public bool SecretItem8_ok;
	public bool SecretItem9_ok;
	public bool SecretItem10_ok;
	public bool SecretItem11_ok;
	public bool SecretItem12_ok;
	public bool SecretItem13_ok;
	public bool SecretItem14_ok;
	public bool SecretItem15_ok;
	public bool SecretItem16_ok;
	public bool SecretItem17_ok;
	public bool SecretItem18_ok;
	public bool SecretItem19_ok;
	public bool SecretItem20_ok;
	public bool SecretItem21_ok;
	public bool SecretItem22_ok;
	public bool SecretItem23_ok;
	public bool SecretItem24_ok;
	public bool SecretItem25_ok;
    public bool SecretItem26_ok;
    public bool SecretItem27_ok;
    public bool SecretItem28_ok;
    public bool SecretItem29_ok;
    public bool SecretItem30_ok;
    public bool SecretItem31_ok;
    public bool SecretItem32_ok;

    public bool ZieloneZiolo1_ok;
	public bool ZieloneZiolo2_ok;
	public bool ZieloneZiolo3_ok;
	public bool ZieloneZiolo4_ok;
	public bool ZieloneZiolo5_ok;
	public bool ZieloneZiolo6_ok;
	public bool ZieloneZiolo7_ok;
	public bool ZieloneZiolo8_ok;
	public bool ZieloneZiolo9_ok;
	public bool ZieloneZiolo10_ok;
	public bool ZieloneZiolo11_ok;
	public bool ZieloneZiolo12_ok;
	public bool ZieloneZiolo13_ok;
	public bool ZieloneZiolo14_ok;
	public bool ZieloneZiolo15_ok;
	public bool ZieloneZiolo16_ok;
	public bool ZieloneZiolo17_ok;
	public bool ZieloneZiolo18_ok;
	public bool ZieloneZiolo19_ok;
	public bool ZieloneZiolo20_ok;
	public bool ZieloneZiolo21_ok;
	public bool ZieloneZiolo22_ok;
    public bool ZieloneZiolo23_ok;
    public bool ZieloneZiolo24_ok;
    public bool ZieloneZiolo25_ok;
    public bool ZieloneZiolo26_ok;
    public bool ZieloneZiolo27_ok;
    public bool ZieloneZiolo28_ok;
    public bool ZieloneZiolo29_ok;
    public bool ZieloneZiolo30_ok;
    public bool ZieloneZiolo31_ok;
    public bool ZieloneZiolo32_ok;

    public bool NiebieskieZiolo1_ok;
	public bool NiebieskieZiolo2_ok;
	public bool NiebieskieZiolo3_ok;
	public bool NiebieskieZiolo4_ok;
	public bool NiebieskieZiolo5_ok;
	public bool NiebieskieZiolo6_ok;
	public bool NiebieskieZiolo7_ok;
	public bool NiebieskieZiolo8_ok;
	public bool NiebieskieZiolo9_ok;
	public bool NiebieskieZiolo10_ok;
	public bool NiebieskieZiolo11_ok;
	public bool NiebieskieZiolo12_ok;
	public bool NiebieskieZiolo13_ok;
	public bool NiebieskieZiolo14_ok;
	public bool NiebieskieZiolo15_ok;
	public bool NiebieskieZiolo16_ok;
	public bool NiebieskieZiolo17_ok;
	public bool NiebieskieZiolo18_ok;
	public bool NiebieskieZiolo19_ok;
	public bool NiebieskieZiolo20_ok;
	public bool NiebieskieZiolo21_ok;
	public bool NiebieskieZiolo22_ok;
    public bool NiebieskieZiolo23_ok;
    public bool NiebieskieZiolo24_ok;
    public bool NiebieskieZiolo25_ok;
    public bool NiebieskieZiolo26_ok;
    public bool NiebieskieZiolo27_ok;
    public bool NiebieskieZiolo28_ok;
    public bool NiebieskieZiolo29_ok;
    public bool NiebieskieZiolo30_ok;
    public bool NiebieskieZiolo31_ok;
    public bool NiebieskieZiolo32_ok;

    public bool Fiolka1_ok;
    public bool Fiolka2_ok;
    public bool Fiolka3_ok;
    public bool Fiolka4_ok;
    public bool Fiolka5_ok;
    public bool Fiolka6_ok;
    public bool Fiolka7_ok;
    public bool Fiolka8_ok;
    public bool Fiolka9_ok;
    public bool Fiolka10_ok;
    public bool Fiolka11_ok;
    public bool Fiolka12_ok;
    public bool Fiolka13_ok;
    public bool Fiolka14_ok;
    public bool Fiolka15_ok;
    public bool Fiolka16_ok;


    public bool EliksirStamina1_ok;
    public bool EliksirStamina2_ok;
    public bool EliksirStamina3_ok;
    public bool EliksirStamina4_ok;
    public bool EliksirStamina5_ok;

    public bool EliksirZdrowie1_ok;
    public bool EliksirZdrowie2_ok;
    public bool EliksirZdrowie3_ok;
    public bool EliksirZdrowie4_ok;
    public bool EliksirZdrowie5_ok;
    public bool EliksirZdrowie6_ok;

    public bool Skill1_ok;
	public bool Skill2_ok;
	public bool Skill3_ok;
	public bool Skill4_ok;

    public int IloscOdznak;
    public int IloscWskazowek;
    public int IloscFoto;
    public int IloscUmiejetnosci;

    // zapis glos bohatera

    public bool GlosPoczatek_ok;
	public bool GlosOgrodzenie_ok;
	public bool GlosSwiatloDomu_ok;
	public bool GlosKuchnia_ok;
	public bool GlosDuzyPokoj_ok;
	public bool GlosPokojArtura_ok;
	public bool GlosSzopaNarzedzia_ok;
	public bool GlosDomAlice_ok;
	public bool GlosHalucynacje_ok;
	public bool GlosWarsztat_ok;
	public bool GlosLewyPotok_ok;
	public bool GlosNotatkaAnna_ok;
	public bool GlosKombinerki_ok;
	public bool GlosKukurydza_ok;
	public bool GlosStaraSzopa_ok;
	public bool GlosSiekiera_ok;
	public bool GlosNagranie_ok;
	public bool GlosKsiazki_ok;
	public bool GlosWawoz_ok;
	public bool GlosDomStevena_ok;
	public bool GlosEliksir_ok;
	public bool GlosSzopaSteven_ok;
	public bool GlosPotokDiably_ok;
	public bool GlosKryjowka_ok;

    public bool GlosSzalas_ok;
    public bool GlosStudnia_ok;
    public bool GlosStajnia_ok;
    public bool GlosOgrod_ok;
    public bool GlosKamping_ok;
    public bool GlosUrzadzenieVictora_ok;
    public bool GlosSzafaKorytarz_ok;
    public bool GlosChip_ok;
    public bool GlosWskazowkiArtura_ok;
    public bool GlosRoslinyPotworow_ok;
    public bool GlosZeno_ok;

    public bool RetroDuzyPokoj_ok;
	public bool RetroPokojArtura_ok;
	public bool RetroSzopaNarzedzia_ok;
	public bool RetroDomAlice_ok;
	public bool RetroWarsztat_ok;
	public bool RetroKukurydza_ok;
	public bool RetroStaraSzopa_ok;
	public bool RetroKsiazki_ok;
	public bool RetroDomStevena_ok;
	public bool RetroSzopaSteven_ok;

	public bool PoczatekGryNap_ok;
	public bool OgrodzenieNap_ok;
	public bool SwiatloDomuNap_ok;
	public bool KuchniaNap_ok;
	public bool DuzyPokojNap_ok;
	public bool PokojArthuraNap_ok;
	public bool SzopaNarzedziaNap_ok;
	public bool Kaseta1Nap_ok;
	public bool DomAliceNap_ok;
	public bool HalucynacjeNap_ok;
	public bool WarsztatNap_ok;
	public bool LewyPotokNap_ok;
	public bool NotatkaAnnaNap_ok;
	public bool KombinerkiNap_ok;
	public bool KukurydzaNap_ok;
	public bool SiekieraNap_ok;
	public bool StaraSzopaNap_ok;
	public bool Kaseta2Nap_ok;
	public bool NagranieNap_ok;
	public bool KsiazkiNap_ok;
	public bool Kaseta3Nap_ok;
	public bool WawozNap_ok;
	public bool Kaseta4Nap_ok;
	public bool DomStevenaNap_ok;
	public bool EliksirNap_ok;
	public bool SzopaStevenNap_ok;
	public bool PotokDiablyNap_ok;
	public bool Kaseta5Nap_ok;
	public bool KryjowkaNap_ok;

    public bool SzalasNap_ok;
    public bool StudniaNap_ok;
    public bool StajniaNap_ok;
    public bool OgrodNap_ok;
    public bool KampingNap_ok;
    public bool UrzadzenieVictoraNap_ok;
    public bool SzafaKorytarzNap_ok;
    public bool ChipNap_ok;
    public bool WskazowkiArturaNap_ok;
    public bool RoslinyPotworowNap_ok;
    public bool ZenoNap_ok;

    // zapis jumpscare

    public bool MonsterPotok1_ok;
    public bool MonsterPotok1Wyl_ok;
	public bool MonsterKukurydza_ok;
	public bool MonsterKorytarz_ok;
	public bool MonsterKukurydza2_ok;
	public bool MonsterKoryto_ok;
	public bool MonstersLasMieso_ok;
	public bool MonsterPokojZachod_ok;
	public bool MonsterDrzwiZachod_ok;
	public bool MonsterOgrod_ok;
	public bool MonsterWarsztat_ok;
	public bool MonsterDynia_ok;
	public bool MonsterDyniaWylacz_ok;
	public bool MonsterOpuszczony1_ok;
	public bool MonsterSzopa1_ok;
	public bool MonsterTom_ok;
	public bool MonsterRoslina_ok;
	public bool MonsterKrzaki_ok;
	public bool MonsterKrzakiWyl_ok;
	public bool MonsterZachodGora_ok;
	public bool MonsterSzopaSteven1_ok;
	public bool MonsterSzopaSteven2_ok;
	public bool StopCzasOpuszczony_ok;
    public bool MonsterPoczatek_ok;
    public bool MonsterStajnia_ok;
    public bool MonsterKamping_ok;
    public bool WilkPoczatek_ok;
    public bool PajakJumpscare1_ok;
    public bool PajakJumpscare2_ok;
    public bool Pajak3_ok = false;
    public bool Pajak3Wylacz_ok = false;
    public bool Pajak4_ok = false;

    // zapis komunikat

    public bool KomSwiatlo_ok;
	public bool KomSprint_ok;
	public bool KomSwiatlo2_ok;
	public bool KomZadaniaInfo_ok;
	public bool KomMapa_ok;
	public bool KomKucanie_ok;
    public bool KomDrzwiWskazowka_ok;
    public bool KomZiola_ok;
    public bool KomZapis_ok;
    public bool KomPodnoszenie_ok;
    public bool KomPchanie_ok;
    public bool KomSecret_ok;
    public bool KomItems_ok;
    public bool KomInventory_ok;
    public bool InfoBaterie_ok;
	public bool InfoChip_ok;
	public bool JestKaseta_ok;
	public bool JestKaseta3_ok;

	// zapis latarki

	public int PromienSwiatla;
	public bool Latarka_ok;

	// zapis muzyki

	//public bool WylaczMuzyke_ok;
	public bool WylaczSwiatloDomu_ok;
	public bool WylaczWarsztatSimon_ok;
	public bool WylaczStaraSzopa_ok;
	public bool WylaczPoTom_ok;
    public bool WylaczStaraSzopaDreszcz_ok;

    public bool MuzykaPoczatek_ok = false;
    public bool MuzykaMonsterPoczatek_ok = false;
    public bool MuzykaPoczatekStop_ok = false;
    public bool MuzykaPoWilku_ok;
	public bool NiepokojPrzedDomem_ok;
	public bool NiepokojKuchnia_ok;
	public bool NiepokojPokojUncle_ok;
	public bool MuzykaTloStop_ok;
	public bool KlimatSzopaNarzedzia_ok;
	public bool KlimatStudnia_ok;
	public bool NiepokojStudnia_ok;
	public bool NiepokojStajnia_ok;
	public bool KlimatOgrod_ok;
	public bool KlimatKosci_ok;
	public bool NiepokojAlice_ok;
	public bool KlimatSzopaAlice_ok;
	public bool NiepokojWarsztat_ok;
	public bool KlimatWarsztatSimon_ok;
	public bool KlimatCmentarzZwierzat_ok;
	public bool NiepokojSalonAlice_ok;
	public bool NiepokojSzopa_ok;
	public bool KlimatStaraSzopa_ok;
	public bool KlimatPrzedTom_ok;
	public bool NiepokojTom_ok;
	public bool KlimatSala_ok;
	public bool NiepokojTom2_ok;
	public bool KlimatKsiazki_ok;
	public bool NiepokojTom3_ok;
	public bool KlimatKukurydza_ok;
	public bool KlimatOboz_ok;
	public bool KlimatTomGora_ok;
	public bool KlimatTomGora2_ok;
	public bool KlimatPoTom_ok;
	public bool KlimatKarmnik_ok;
	public bool KlimatPrzedSteven_ok;
	public bool KlimatSteven_ok;
	public bool KlimatMieso_ok;
	public bool KlimatStevenGora_ok;
	public bool NiepokojSzopaSteven_ok;
	public bool KlimatPrzedPaul_ok;
	public bool NiepokojPaul_ok;
	public bool KlimatPaulGora_ok;
	public bool KlimatChatka_ok;
	public bool KlimatMonsterGora1_ok;
	public bool KlimatMonsterGora2_ok;
	public bool KlimatPrzedKryjowka_ok;
	public bool KlimatKryjowka_ok;
	public bool KlimatKryjowka2_ok;
	public bool MuzykaKoniec_ok;
	public bool PotworOpuszczonyPiwnica_ok;
    public bool MuzykaDuzyR_ok;
    public bool MuzykaPotokLewySkrzypce_ok;
    public bool KlimatKukurydza1_ok;
    public bool KlimatPoLatarka_ok;
    public bool KlimatDrzwiBabcia_ok;

    // zapis notatki

    public int IloscNotatek;
    public bool Notatka1_ok;
	public bool Notatka2_ok;
	public bool Notatka3_ok;
	public bool Notatka4_ok;
	public bool Notatka5_ok;
	public bool Notatka6_ok;
	public bool Notatka7_ok;
	public bool Notatka8_ok;
	public bool Notatka9_ok;
	public bool Notatka10_ok;
	public bool Notatka11_ok;
	public bool Notatka12_ok;
	public bool Notatka13_ok;
	public bool Notatka14_ok;
	public bool Notatka15_ok;
	public bool Notatka16_ok;
	public bool Notatka17_ok;
	public bool Notatka18_ok;
	public bool Notatka19_ok;
	public bool Notatka20_ok;
	public bool Notatka21_ok;
	public bool Notatka22_ok;
	public bool Notatka23_ok;
	public bool Notatka24_ok;
	public bool Notatka25_ok;
	public bool Notatka26_ok;
	public bool Notatka27_ok;
	public bool Notatka28_ok;
	public bool Notatka29_ok;
	public bool Notatka30_ok;
	public bool Notatka31_ok;
	public bool Notatka32_ok;
	public bool Notatka33_ok;
	public bool Notatka34_ok;
	public bool Notatka35_ok;
	public bool Notatka36_ok;
	public bool Notatka37_ok;
	public bool Notatka38_ok;
	public bool Notatka39_ok;
	public bool Notatka40_ok;
	public bool Notatka41_ok;
	public bool Notatka42_ok;
	public bool Notatka43_ok;
	public bool Notatka44_ok;
	public bool Notatka45_ok;
	public bool Notatka46_ok;
	public bool Notatka47_ok;
	public bool Notatka48_ok;
	public bool Notatka49_ok;
	public bool Notatka50_ok;
	public bool Notatka51_ok;
	public bool Notatka52_ok;
	public bool Notatka53_ok;
	public bool Notatka54_ok;
	public bool NotatkaLisy_ok;
	public bool ZdjecieDrewno_ok;
	public bool ZdjecieZeno_ok;
	public bool NotatkaZakupy_ok;
	public bool NotatkaCytat1_ok;
	public bool RysunekKukurydza_ok;
	public bool NotatkaPotokLewy_ok;
	public bool NotatkaGrzyby_ok;
	public bool ZdjeciePotok3_ok;
	public bool ZdjeciePotok2_ok;
	public bool ZdjeciePotok1_ok;
	public bool RysunekSimon_ok;
	public bool NotatkaRap_ok;
	public bool ZdjecieAmbona_ok;
	public bool ZdjecieStudnia_ok;
	public bool NotatkaCytat2_ok;
	public bool ZdjeciePomnik_ok;
	public bool NotatkaWynalazki_ok;
	public bool ZdjecieWarsztat_ok;
	public bool NotatkaCiemny_ok;
	public bool NotatkaZwierzeta_ok;
	public bool NotatkaNoc_ok;
	public bool ZdjecieSzafa_ok;
	public bool ZdjecieSzopa_ok;
	public bool ZdjecieOboz_ok;
	public bool NotatkaMary_ok;
	public bool RysunekCorki_ok;
	public bool NotatkaDyplom_ok;
	public bool RysunekTom_ok;
	public bool NotatkaCytat3_ok;
	public bool RysunekPotwor_ok;
	public bool NotatkaSzepty_ok;
	public bool NotatkaCytat4_ok;
	public bool RysunekRosliny_ok;
	public bool NotatkaPole_ok;
	public bool NotatkaArena_ok;
	public bool NotatkaCytat5_ok;
	public bool ZdjeciePotok4_ok;
	public bool NotatkaKosmici_ok;
	public bool NotatkaCytat6_ok;
    public bool NotatkaDemona_ok;

	// zapis screamer

	public bool Zegar_ok;
	public bool Lampa_ok;
	public bool Lampa_przed_ok;
	public bool Swiatlo2_ok;
	public bool Szelest_ok;
	public bool Siano_ok;
	public bool Drewno_ok;
	public bool Wilk_ok;
	public bool Szelest2_ok;
	public bool Klimat_ok;
	public bool Szept_ok;
	public bool RadioSpain_ok;
	public bool StudniaKrzyk_ok;
	public bool DrewnoSzopa_ok;
	public bool Szczur_ok;
	public bool StudniaWoda_ok;
	public bool RadioStrzaly_ok;
	public bool OdglosyFabryka_ok;
	public bool Lancuchy_ok;
	public bool OdglosyFabryka2_ok;
	public bool WrednySmiech_ok;
	public bool AktywujSmiech_ok; 
	public bool Kruki_ok; 
	public bool SmiechDzw_ok; 
	public bool KrzykDzw_ok; 
	public bool Pozytywka_ok; 
	public bool Pukanie_ok; 
	public bool Szklo_ok;
	public bool SkrzypienieSchody_ok;
	public bool KrzykSteven_ok;
	public bool DzwonekDrzwiWlacz_ok;
	public bool DzwonekDrzwi_ok;
	public bool SkrzypienieZachod_ok;
	public bool Kroki_ok;
	public bool SkrzypienieSchodyZachod_ok;
	public bool DrzwiZamknij_ok;
	public bool DrzwiOtworz_ok;
	public bool Trup_ok;
	public bool Szept2_ok;
	public bool Wiatr_ok;
	public bool WiatrEfekt_ok;
	public bool Narzedzia_ok;
	public bool Kosci_ok;
	public bool Ciernie_ok;
	public bool Jedzenie_ok;
	public bool Pies_ok;
	public bool Potok_ok;
	public bool Oddech1_ok;
	public bool Oddech2_ok;
	public bool Telefon_ok;
	public bool TelefonBeep_ok;
	public bool SzeptyStudnia_ok;
    public bool RykPsa_ok;
    public bool OddechSzopaKosc_ok;
    public bool PtakSzalas_ok;
    public bool LiscieGanja_ok;
    public bool SzopaMeble_ok;
    public bool KrzykPotok_ok;
    public bool SzkloBabcia_ok;
    public bool PukanieSzyba_ok;
    public bool SzopaAlice_ok;
    public bool SwiatloChatka_ok;
    public bool SkrzypPodloga_ok;
    public bool StrasznaSowa_ok;
    public bool StrasznaSowa2_ok;
    public bool WodaPlusk_ok;
    public bool KrzykLisa_ok;
    public bool KrzykShock_ok;
    public bool DrzewoFall_ok;
    public bool DrzwiOtworzJmpPo_ok;

    // zapis zadan

    public bool ZadaniePoczatek_ok;
	public bool ZadanieSzukajInfo_ok;
	public bool ZadanieKluczDrewno_ok;
	public bool ZadanieMagicznaStudnia_ok;
	public bool ZadanieKamienieStudnia_ok;
	public bool ZadanieKaseta1_ok;
    public bool ZadanieDrzwiOgrod_ok;
    public bool ZadanieKosci_ok;
	public bool ZadanieIdzAlice_ok;
	public bool ZadanieAliceInfo_ok;
	public bool ZadanieSimonElement_ok;
    public bool ZadanieWarsztat_ok;
    public bool ZadanieZepsutyKlucz_ok;
	public bool ZadanieNaprawKlucz_ok;
	public bool ZadanieCmentarzZwierz_ok;
	public bool ZadanieVictorPotok_ok;
	public bool ZadanieSalonAlice_ok;
	public bool ZadanieKukurydza_ok;
	public bool ZadanieSiekiera_ok;
	public bool ZadanieSzafaKorytarz_ok;
	public bool ZadanieSzafkaEdward_ok;
	public bool ZadanieKaseta2_ok;
	public bool ZadanieIdzSzlak_ok;
	public bool ZadanieKierujSzlak_ok;
	public bool ZadaniePrzedostanSie_ok;
	public bool ZadanieTomInfo_ok;
	public bool ZadanieTomKukurydza_ok;
	public bool ZadanieKaseta3_ok;
	public bool ZadanieTomOboz_ok;
	public bool ZadanieTomDynia_ok;
	public bool ZadanieTomChip_ok;
	public bool ZadanieWawoz_ok; 
	public bool ZadanieIdzWawoz_ok;
	public bool ZadanieOpuszczonyInfo_ok;
	public bool ZadanieKaseta4_ok;
	public bool ZadanieStevenInfo_ok;
	public bool ZadanieStevenKlucz_ok;
	public bool ZadanieStevenGrzyb_ok;
	public bool ZadanieStevenRoslina_ok;
	public bool ZadanieStevenCzaszka_ok;
	public bool ZadanieKwas_ok;
	public bool ZadanieStevenSzopa_ok;
	public bool ZadanieStevenNotatka_ok;
	public bool ZadanieStevenPotok_ok;
	public bool ZadaniePaulInfo_ok;
	public bool ZadaniePaulDrzwi_ok;
	public bool ZadanieChatka_ok;
	public bool ZadaniePotokDiably_ok;
	public bool ZadanieKryjowkaDiably_ok;
	public bool ZadanieKryjowkaRodzina_ok;

	public bool ZadaniePoczatek_Usun;
	public bool ZadanieSzukajInfo_Usun;
	public bool ZadanieKluczDrewno_Usun;
	public bool ZadanieMagicznaStudnia_Usun;
	public bool ZadanieKamienieStudnia_Usun;
	public bool ZadanieKaseta1_Usun;
    public bool ZadanieDrzwiOgrod_Usun;
    public bool ZadanieKosci_Usun;
	public bool ZadanieIdzAlice_Usun;
	public bool ZadanieAliceInfo_Usun;
	public bool ZadanieSimonElement_Usun;
    public bool ZadanieWarsztat_Usun;
    public bool ZadanieZepsutyKlucz_Usun;
	public bool ZadanieNaprawKlucz_Usun;
	public bool ZadanieCmentarzZwierz_Usun;
	public bool ZadanieVictorPotok_Usun;
	public bool ZadanieSalonAlice_Usun;
	public bool ZadanieKukurydza_Usun;
	public bool ZadanieSiekiera_Usun;
	public bool ZadanieSzafaKorytarz_Usun;
	public bool ZadanieSzafkaEdward_Usun;
	public bool ZadanieKaseta2_Usun;
	public bool ZadanieIdzSzlak_Usun;
	public bool ZadanieKierujSzlak_Usun;
	public bool ZadaniePrzedostanSie_Usun;
	public bool ZadanieTomInfo_Usun;
	public bool ZadanieTomKukurydza_Usun;
	public bool ZadanieKaseta3_Usun;
	public bool ZadanieTomOboz_Usun;
	public bool ZadanieTomDynia_Usun;
	public bool ZadanieTomChip_Usun;
	public bool ZadanieWawoz_Usun;
	public bool ZadanieIdzWawoz_Usun;
	public bool ZadanieOpuszczonyInfo_Usun;
	public bool ZadanieKaseta4_Usun;
	public bool ZadanieStevenInfo_Usun;
	public bool ZadanieStevenKlucz_Usun;
	public bool ZadanieStevenGrzyb_Usun;
	public bool ZadanieStevenRoslina_Usun;
	public bool ZadanieStevenCzaszka_Usun;
	public bool ZadanieKwas_Usun;
	public bool ZadanieStevenSzopa_Usun;
	public bool ZadanieStevenNotatka_Usun;
	public bool ZadanieStevenPotok_Usun;
	public bool ZadaniePaulInfo_Usun;
	public bool ZadaniePaulDrzwi_Usun;
	public bool ZadanieChatka_Usun;
	public bool ZadaniePotokDiably_Usun;
	public bool ZadanieKryjowkaDiably_Usun;
	public bool ZadanieKryjowkaRodzina_Usun;

	public bool GlosIdzSzlak_ok;

	public bool DrzwiOgrod_lock;
	public bool DrzwiKukurydza_lock;
	public bool DrzwiStajnia_lock;
	public bool SzafkaKorytarz_lock;
	public bool DrzwiPokojW_lock;
	public bool SzafkaKuchnia_lock;
	public bool DrzwiKamping_lock;
	public bool DeskiSzopa_lock;
	public bool DeskiZniszczone_ok;
	public bool DrzwiSzopaNarzedzia_lock;
	public bool DrzwiWneka_lock;
	public bool WlozKasete_ok;
	public bool WlozBaterie_ok;
	public bool DrzwiSalonPoludnie_lock;
	public bool Halucynacje_ok;
	public bool DrzwiFabrykaMetal_lock;
	public bool ZepsutyKlucz_ok;
	public bool Kolo_ok;
	public bool NaprawionyKlucz_ok;
	public bool DrzwiFabrykaDrewno_lock;
	public bool SzafkaSzopa_lock;
	public bool WlozKasete2_ok;
	public bool DrzwiPokojTom_lock;
	public bool DrzwiTomGora_lock;
	public bool WlozKasete3_ok;
	public bool BrakChip_ok;
	public bool WlozChip_ok;
	public bool SzafaStaryDom_lock;
	public bool WlozKasete4_ok;
	public bool DrzwiSteven_lock;
	public bool KratySteven_lock;
	public bool DrzwiZachod_lock;
	public bool Kaseta1Odtworzona;
	public bool Kaseta2Odtworzona;
	public bool Kaseta3Odtworzona;
	public bool Kaseta4Odtworzona;
	public bool Kaseta5Odtworzona;
	public bool SzopaStevenMonster_ok;
    public bool HalunyOgrodFlashback_ok;
    public bool DyniaZad_ok;
	public bool RoslinaLabZad_ok;
	public bool GrzybLabZad_ok;
	public bool CzaszkaLabZad_ok;
	public bool Lab_ok;
	public bool LabMikstura_ok;
	public bool KratyZniszczone_ok;

	// zapis ksiazki

	public bool Wykonane_ok;

    // zapis kolekcji

    public bool Odznaka1_ok;
    public bool Odznaka2_ok;
    public bool Odznaka3_ok;
    public bool Odznaka4_ok;
    public bool Odznaka5_ok;
    public bool Odznaka6_ok;
    public bool Odznaka7_ok;
    public bool Odznaka8_ok;
    public bool Odznaka9_ok;
    public bool Odznaka10_ok;
    public bool Odznaka11_ok;
    public bool Odznaka12_ok;

    public bool Foto1_ok;
    public bool Foto2_ok;
    public bool Foto3_ok;
    public bool Foto4_ok;
    public bool Foto5_ok;
    public bool Foto6_ok;
    public bool Foto7_ok;
    public bool Foto8_ok;
    public bool Foto9_ok;
    public bool Foto10_ok;
    public bool Foto11_ok;
    public bool Foto12_ok;

    public bool Wskazowka1_ok;
    public bool Wskazowka2_ok;
    public bool Wskazowka3_ok;
    public bool Wskazowka4_ok;
    public bool Wskazowka5_ok;
    public bool Wskazowka6_ok;
    public bool Wskazowka7_ok;
    public bool Wskazowka8_ok;
    public bool Wskazowka9_ok;
    public bool Wskazowka10_ok;
    public bool Wskazowka11_ok;
    public bool Wskazowka12_ok;

    // zapis halucynacje marihuany

    public bool Marysia1_ok;
    public bool Marysia2_ok;
    public bool Marysia3_ok;
    public bool Marysia4_ok;
    public bool Marysia5_ok;
    public bool KoniecMarysia1_ok;
    public bool KoniecMarysia2_ok;
    public bool KoniecMarysia3_ok;
    public bool KoniecMarysia4_ok;
    public bool KoniecMarysia5_ok;
    public int IloscZapalen;

    // zapis scarecrow straszak

    public bool MonsterKorytarzScarecrow_ok;
    public bool MonsterStajniaScarecrow_ok;
    public bool MonsterWychodekScarecrow_ok;
    public bool MonsterSzalasScarecrow_ok;
    public bool MonsterSzalasSchowal_ok;
    public bool MonsterSzopaScarecrow_ok;

}

[Serializable]
class Vector3Gracz{

	public float x;
	public float y;
	public float z;

	public Vector3Gracz(Vector3 Pozycja){
		UstawPozycje (Pozycja);
	}

	public void UstawPozycje(Vector3 Pozycja){
		this.x = Pozycja.x;
		this.y = Pozycja.y;
		this.z = Pozycja.z;
	}

	public Vector3 PobierzPozycje(){
		Vector3 Vec = new Vector3 ();
		Vec.x = this.x;
		Vec.y = this.y;
		Vec.z = this.z;
		return Vec;
	}

}

[Serializable]
class QuaternionGracz{

	public float x;
	public float y;
	public float z;
	public float w;

	public QuaternionGracz(Quaternion Obrot){
		UstawObrot (Obrot);
	}

	public void UstawObrot(Quaternion Obrot){
		this.x = Obrot.x;
		this.y = Obrot.y;
		this.z = Obrot.z;
		this.w = Obrot.w;
	}

	public Quaternion PobierzObrot(){
		Quaternion Vec = new Quaternion ();
		Vec.x = this.x;
		Vec.y = this.y;
		Vec.z = this.z;
		Vec.w = this.w;
		return Vec;
	}

}
