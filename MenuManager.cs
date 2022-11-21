using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	private Menu MenuGlowne;
	private Transform CanvasMenu;
	public bool MenuWylaczone_ok = false;
	private SaveGame Saving;
	private Health ZdrowieGracza;
	private GameManager ManagerGry;
	private Map MapaGry;
	private Tasks Tasks;
	private Music Music;
	private VoiceActing BohaterGlos;
	private FactoryButton PrzyciskFabryka;
	private TaskTower ZadAmbona;
	private TaskFactory ZadFabryka;
    private RandomJumpscare StraszakLosowy;

	private Transform MonsterPotok1;
	private Transform MonsterKukurydza;
	private Transform MonsterKorytarz;
	private Transform MonsterKukurydza2;
	private Transform MonsterKoryto;
	private Transform Monster1_v3;
	private Transform Monster1_v4;
	private Transform MonsterPokojZachod;
	private Transform MonsterDrzwiZachod;
	private Transform MonsterOgrod;
	private Transform MonsterWarsztat;
	private Transform MonsterDynia;
	private Transform MonsterOpuszczony;
	private Transform MonsterSzopa1;
	private Transform MonsterTom;
	private Transform MonsterRoslina;
	private Transform MonsterKrzaki;
	private Transform MonsterZachodDol;
	private Transform MonsterSzopaSteven1;
	private Transform MonsterSzopaSteven2;
    private Transform MonsterPoczatek;
    //private Transform MonsterStajnia;
    //private Transform MonsterKamping;
    private Transform Wilk1;
    private Transform Wilk2;
    private Transform Wilk3;
    private Transform WilkPoczatek1;
    private Transform WilkPoczatek2;
    private Transform PajakJumpscare1;
    private Transform PajakJumpscare2;
    private Transform Pajak3;
    private Transform Pajak4;
    private Transform Pajak5;
    private Transform MonsterSzopaScarecrow;
    private Transform MonsterSzalasScarecrow2;

    private GameObject Ciernie1;
	private GameObject Ciernie2;
	private GameObject Ciernie3;

	public Transform Kamien1;
	public Transform Kamien2;
	public Transform Kamien3;
	public Transform Kamien4;
	public Transform Kamien5;

	public Transform SkrzyniaAmbona1;
	public Transform SkrzyniaAmbonaGora1;
	public Transform SkrzyniaAmbonaGora2;
	private Transform PalAmbona;

	public Transform SkrzyniaPrzedostan;
	public Transform SkrzyniaPrzedostan2;
	public Transform DeskaPrzedostan1;
	public Transform DeskaPrzedostan2;
	public Transform DeskaPrzedostan3;

	public Transform KratySteven;
	private string KolorK = "000000";
	private Color KolorKraty;

	private Transform SkrzyniaSteven1;
	private Transform SkrzyniaSteven2;
	private Transform SkrzyniaSteven3;

	private Transform Trup;
    private Transform KoliderOtworzDrzwi;

	private Transform DrzwiPokojW;
	private Transform SzafaKuchnia;
	private Transform DrzwiWneka;
	private Transform SzafaKorytarz;
	private Transform DrzwiStajnia;
	private Transform DrzwiSzopaNarzedzia;
	private Transform DrzwiKamping;
	private Transform SzafkaSzopa;
	private Transform SzafkaSzopa2;
	private Transform DrzwiKukurydza;
	private Transform DrzwiOgrod;
	private Transform DrzwiDomAlice;
	private Transform DrzwiSalonPoludnie;
	private Transform DrzwiFabrykaDrewno;
	private Transform DrzwiFabrykaMetal;
	private Transform DrzwiDomTom;
	private Transform DrzwiPokojTom;
	private Transform DrzwiSalaTom;
	private Transform DrzwiKsiazkiTom;
	private Transform DrzwiTomGora;
	private Transform DrzwiOpuszczony;
	private Transform SzafaStaryDom;
	private Transform DrzwiDomSteven;
	private Transform DrzwiSteven;
	private Transform DrzwiDomPaul;
	private Transform DrzwiMonster;
	private Transform DrzwiOtworzJmp;
	private Transform DrzwiZachod;
	private Transform SzafaPaul;
	private Transform DrzwiDomek;

    private Transform Odznaka1;
    private Transform Odznaka2;
    private Transform Odznaka3;
    private Transform Odznaka4;
    private Transform Odznaka5;
    private Transform Odznaka6;
    private Transform Odznaka7;
    private Transform Odznaka8;
    private Transform Odznaka9;
    private Transform Odznaka10;
    private Transform Odznaka11;
    private Transform Odznaka12;

    private Transform Foto1;
    private Transform Foto2;
    private Transform Foto3;
    private Transform Foto4;
    private Transform Foto5;
    private Transform Foto6;
    private Transform Foto7;
    private Transform Foto8;
    private Transform Foto9;
    private Transform Foto10;
    private Transform Foto11;
    private Transform Foto12;

    private Transform Wskazowka1;
    private Transform Wskazowka2;
    private Transform Wskazowka3;
    private Transform Wskazowka4;
    private Transform Wskazowka5;
    private Transform Wskazowka6;
    private Transform Wskazowka7;
    private Transform Wskazowka8;
    private Transform Wskazowka9;
    private Transform Wskazowka10;
    private Transform Wskazowka11;
    private Transform Wskazowka12;

    private Transform YoundDead;
    private GameObject KurzDrzewoFall;

    void Start () {

		CanvasMenu = GameObject.Find ("CanvasMenu").transform;
		MenuGlowne = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
		Saving = GameObject.Find ("Player").GetComponent<SaveGame> ();
		ZdrowieGracza = GameObject.Find ("Player").GetComponent<Health> ();
		ManagerGry = GameObject.Find ("Player").GetComponent<GameManager> ();
		MapaGry = GameObject.Find ("Player").GetComponent<Map> ();
		Tasks = GameObject.Find ("Player").GetComponent<Tasks> ();
		Music = GameObject.Find ("Player").GetComponent<Music> ();
		BohaterGlos = GameObject.Find ("Player").GetComponent<VoiceActing> ();
        StraszakLosowy = GameObject.Find("Player").GetComponent<RandomJumpscare>();

        //Application.targetFrameRate = 60;

    }


	void Update () {

		if (SceneManager.GetActiveScene ().name == "MenuGlowne" && MenuWylaczone_ok == false) {
			CanvasMenu.gameObject.GetComponent<Menu> ().enabled = true;
			MenuWylaczone_ok = true;
		} else if (SceneManager.GetActiveScene ().name == "ScenaGlowna" && MenuWylaczone_ok == true) {
			CanvasMenu.gameObject.GetComponent<Menu> ().enabled = true;
			ManagerGry.enabled = true;
			MenuWylaczone_ok = false;
		} else if (SceneManager.GetActiveScene ().name == "ScenaGlowna" && MenuWylaczone_ok == false && MenuGlowne.isLoadedGame == false && ZdrowieGracza.isGameLoaded == true) {
			CanvasMenu.gameObject.GetComponent<Menu> ().enabled = true;
			MenuWylaczone_ok = false;
		} 

		if (MenuGlowne.enabled == false && MenuWylaczone_ok == true && SceneManager.GetActiveScene ().name == "MenuGlowne" && MenuGlowne.isToGame == true) {
			SceneManager.LoadScene ("ScenaGlowna");
		} else if (MenuGlowne.enabled == false && MenuWylaczone_ok == false && SceneManager.GetActiveScene ().name == "ScenaGlowna" && MenuGlowne.isToMenu == true ) { // nie bylo MenuGlowne.WczytajGre_ok == false
			SceneManager.LoadScene ("MenuGlowne");
		}

		if (MenuGlowne.enabled == false && MenuWylaczone_ok == true && SceneManager.GetActiveScene ().name == "MenuGlowne" && MenuGlowne.isLoadedGame == true && Saving.Wczytano_ok == false) {
			MenuGlowne.isLoadedGame = false;
			Saving.Wczytaj ();
		} else if (MenuGlowne.enabled == false && MenuWylaczone_ok == false && SceneManager.GetActiveScene ().name == "ScenaGlowna" && MenuGlowne.isLoadedGame == true && Saving.Wczytano_ok == false) {
			//Saving.Wczytano_ok = false;
			MenuGlowne.isLoadedGame = false;
			Saving.Wczytaj ();
			WartosciPoczatkowe ();
			CanvasMenu.gameObject.GetComponent<Menu> ().enabled = true;
			ManagerGry.enabled = true;
		}
			
			
	}

	public void WartosciPoczatkowe(){

        ManagerGry.Trup.gameObject.SetActive(true);

		ManagerGry.KluczV1.gameObject.SetActive (true);
		ManagerGry.Oliwa.gameObject.SetActive (true);
		ManagerGry.KluczV2.gameObject.SetActive (true);
		ManagerGry.KluczV3.gameObject.SetActive (true);
		ManagerGry.KluczV4.gameObject.SetActive (true);
		ManagerGry.Baterie.gameObject.SetActive (true);
		ManagerGry.Kaseta1.gameObject.SetActive (true);
		ManagerGry.Kosc1.gameObject.SetActive (true);
		ManagerGry.Kosc2.gameObject.SetActive (true);
		ManagerGry.Kosc3.gameObject.SetActive (true);
		ManagerGry.Kosc4.gameObject.SetActive (true);
		ManagerGry.Kosc5.gameObject.SetActive (true);
		ManagerGry.KluczWneka.gameObject.SetActive (true);
		ManagerGry.KluczKamping.gameObject.SetActive (true);
		ManagerGry.KluczFabrykaBroken.gameObject.SetActive (true);
		ManagerGry.BrakujaceKolo.gameObject.SetActive (true);
        ManagerGry.KluczNaprawiony.gameObject.SetActive(true);
        ManagerGry.KluczSalonPoludnie.gameObject.SetActive (true);
		ManagerGry.Lom.gameObject.SetActive (true);
		ManagerGry.Kombinerki.gameObject.SetActive (true);
		ManagerGry.Siekiera.gameObject.SetActive (true);
		ManagerGry.KluczSzafaKorytarz.gameObject.SetActive (true);
		ManagerGry.KluczSzafkaSzopa.gameObject.SetActive (true);
		ManagerGry.Kaseta2.gameObject.SetActive (true);
		ManagerGry.KluczPokojTom.gameObject.SetActive (true);
		ManagerGry.Kaseta3.gameObject.SetActive (true);
		ManagerGry.KluczSzafaStaryDom.gameObject.SetActive (true);
		ManagerGry.Kaseta4.gameObject.SetActive (true);
		ManagerGry.KluczStevena.gameObject.SetActive (true);
		ManagerGry.RoslinaLab.gameObject.SetActive (true);
		ManagerGry.GrzybLab.gameObject.SetActive (true);
		ManagerGry.CzaszkaLab.gameObject.SetActive (true);
		ManagerGry.KluczPokojZachod.gameObject.SetActive (true);
		ManagerGry.Dynia.gameObject.SetActive (true);
		ManagerGry.KluczTomGora.gameObject.SetActive (true);
		ManagerGry.Chip.gameObject.SetActive (true);
		ManagerGry.Mikstura.gameObject.SetActive (true);

		ManagerGry.SecretItem1.gameObject.SetActive (true);
		ManagerGry.SecretItem2.gameObject.SetActive (true);
		ManagerGry.SecretItem3.gameObject.SetActive (true);
		ManagerGry.SecretItem4.gameObject.SetActive (true);
		ManagerGry.SecretItem5.gameObject.SetActive (true);
		ManagerGry.SecretItem6.gameObject.SetActive (true);
		ManagerGry.SecretItem7.gameObject.SetActive (true);
		ManagerGry.SecretItem8.gameObject.SetActive (true);
		ManagerGry.SecretItem9.gameObject.SetActive (true);
		ManagerGry.SecretItem10.gameObject.SetActive (true);
		ManagerGry.SecretItem11.gameObject.SetActive (true);
		ManagerGry.SecretItem12.gameObject.SetActive (true);
		ManagerGry.SecretItem13.gameObject.SetActive (true);
		ManagerGry.SecretItem14.gameObject.SetActive (true);
		ManagerGry.SecretItem15.gameObject.SetActive (true);
		ManagerGry.SecretItem16.gameObject.SetActive (true);
		ManagerGry.SecretItem17.gameObject.SetActive (true);
		ManagerGry.SecretItem18.gameObject.SetActive (true);
		ManagerGry.SecretItem19.gameObject.SetActive (true);
		ManagerGry.SecretItem20.gameObject.SetActive (true);
		ManagerGry.SecretItem21.gameObject.SetActive (true);
		ManagerGry.SecretItem22.gameObject.SetActive (true);
		ManagerGry.SecretItem23.gameObject.SetActive (true);
		ManagerGry.SecretItem24.gameObject.SetActive (true);
		ManagerGry.SecretItem25.gameObject.SetActive (true);
        ManagerGry.SecretItem26.gameObject.SetActive(true);
        ManagerGry.SecretItem27.gameObject.SetActive(true);
        ManagerGry.SecretItem28.gameObject.SetActive(true);
        ManagerGry.SecretItem29.gameObject.SetActive(true);
        ManagerGry.SecretItem30.gameObject.SetActive(true);
        ManagerGry.SecretItem31.gameObject.SetActive(true);
        ManagerGry.SecretItem32.gameObject.SetActive(true);

        ManagerGry.ZieloneZiolo1.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo2.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo3.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo4.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo5.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo6.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo7.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo8.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo9.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo10.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo11.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo12.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo13.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo14.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo15.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo16.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo17.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo18.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo19.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo20.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo21.gameObject.SetActive (true);
		ManagerGry.ZieloneZiolo22.gameObject.SetActive (true);
        ManagerGry.ZieloneZiolo23.gameObject.SetActive(true);
        ManagerGry.ZieloneZiolo24.gameObject.SetActive(true);
        ManagerGry.ZieloneZiolo25.gameObject.SetActive(true);
        ManagerGry.ZieloneZiolo26.gameObject.SetActive(true);
        ManagerGry.ZieloneZiolo27.gameObject.SetActive(true);
        ManagerGry.ZieloneZiolo28.gameObject.SetActive(true);
        ManagerGry.ZieloneZiolo29.gameObject.SetActive(true);
        ManagerGry.ZieloneZiolo30.gameObject.SetActive(true);
        ManagerGry.ZieloneZiolo31.gameObject.SetActive(true);
        ManagerGry.ZieloneZiolo32.gameObject.SetActive(true);

        ManagerGry.NiebieskieZiolo1.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo2.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo3.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo4.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo5.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo6.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo7.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo8.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo9.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo10.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo11.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo12.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo13.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo14.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo15.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo16.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo17.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo18.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo19.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo20.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo21.gameObject.SetActive (true);
		ManagerGry.NiebieskieZiolo22.gameObject.SetActive (true);
        ManagerGry.NiebieskieZiolo23.gameObject.SetActive(true);
        ManagerGry.NiebieskieZiolo24.gameObject.SetActive(true);
        ManagerGry.NiebieskieZiolo25.gameObject.SetActive(true);
        ManagerGry.NiebieskieZiolo26.gameObject.SetActive(true);
        ManagerGry.NiebieskieZiolo27.gameObject.SetActive(true);
        ManagerGry.NiebieskieZiolo28.gameObject.SetActive(true);
        ManagerGry.NiebieskieZiolo29.gameObject.SetActive(true);
        ManagerGry.NiebieskieZiolo30.gameObject.SetActive(true);
        ManagerGry.NiebieskieZiolo31.gameObject.SetActive(true);
        ManagerGry.NiebieskieZiolo32.gameObject.SetActive(true);

        ManagerGry.Fiolka1.gameObject.SetActive(true);
        ManagerGry.Fiolka2.gameObject.SetActive(true);
        ManagerGry.Fiolka3.gameObject.SetActive(true);
        ManagerGry.Fiolka4.gameObject.SetActive(true);
        ManagerGry.Fiolka5.gameObject.SetActive(true);
        ManagerGry.Fiolka6.gameObject.SetActive(true);
        ManagerGry.Fiolka7.gameObject.SetActive(true);
        ManagerGry.Fiolka8.gameObject.SetActive(true);
        ManagerGry.Fiolka9.gameObject.SetActive(true);
        ManagerGry.Fiolka10.gameObject.SetActive(true);
        ManagerGry.Fiolka11.gameObject.SetActive(true);
        ManagerGry.Fiolka12.gameObject.SetActive(true);
        ManagerGry.Fiolka13.gameObject.SetActive(true);
        ManagerGry.Fiolka14.gameObject.SetActive(true);
        ManagerGry.Fiolka15.gameObject.SetActive(true);
        ManagerGry.Fiolka16.gameObject.SetActive(true);

        ManagerGry.EliksirStamina1.gameObject.SetActive(true);
        ManagerGry.EliksirStamina2.gameObject.SetActive(true);
        ManagerGry.EliksirStamina3.gameObject.SetActive(true);
        ManagerGry.EliksirStamina4.gameObject.SetActive(true);
        ManagerGry.EliksirStamina5.gameObject.SetActive(true);

        ManagerGry.EliksirZdrowie1.gameObject.SetActive(true);
        ManagerGry.EliksirZdrowie2.gameObject.SetActive(true);
        ManagerGry.EliksirZdrowie3.gameObject.SetActive(true);
        ManagerGry.EliksirZdrowie4.gameObject.SetActive(true);
        ManagerGry.EliksirZdrowie5.gameObject.SetActive(true);
        ManagerGry.EliksirZdrowie6.gameObject.SetActive(true);

        ManagerGry.MiesoDlaPotwora1.gameObject.SetActive(true);
        ManagerGry.MiesoDlaPotwora2.gameObject.SetActive(true);
        ManagerGry.MiesoDlaPotwora3.gameObject.SetActive(true);

        ManagerGry.KoliderOgrod.gameObject.SetActive (true);
		ManagerGry.KoliderKukurydza.gameObject.SetActive (true);
		ManagerGry.KoliderStajnia.gameObject.SetActive (true);
		ManagerGry.KoliderSzafkaKorytarz.gameObject.SetActive (true);
		ManagerGry.KoliderPokojW.gameObject.SetActive (true);
		ManagerGry.KoliderSzafkaKuchnia.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiKamping.gameObject.SetActive (true);
		ManagerGry.DeskiSzopa.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiSzopaNarzedzia.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiWneka.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiSalonPoludnie.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiFabrykaMetal.gameObject.SetActive (true);
		ManagerGry.DrewnianeKolo.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiFabrykaDrewno.gameObject.SetActive (true);
		ManagerGry.KoliderSzafkaSzopa.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiPokojTom.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiTomGora.gameObject.SetActive (true);
		ManagerGry.KoliderSzafaStaryDom.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiSteven.gameObject.SetActive (true);
		ManagerGry.KratySteven.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiZachod.gameObject.SetActive (true);
		ManagerGry.KoliderDrzwiPokojZachod.gameObject.SetActive (true);

       

        ManagerGry.Notatka1.gameObject.SetActive (true);
		ManagerGry.Notatka2.gameObject.SetActive (true);
		ManagerGry.Notatka3.gameObject.SetActive (true);
		ManagerGry.Notatka4.gameObject.SetActive (true);
		ManagerGry.Notatka5.gameObject.SetActive (true);
		ManagerGry.Notatka6.gameObject.SetActive (true);
		ManagerGry.Notatka7.gameObject.SetActive (true);
		ManagerGry.Notatka8.gameObject.SetActive (true);
		ManagerGry.Notatka9.gameObject.SetActive (true);
		ManagerGry.Notatka10.gameObject.SetActive (true);
		ManagerGry.Notatka11.gameObject.SetActive (true);
		ManagerGry.Notatka12.gameObject.SetActive (true);
		ManagerGry.Notatka13.gameObject.SetActive (true);
		ManagerGry.Notatka14.gameObject.SetActive (true);
		ManagerGry.Notatka15.gameObject.SetActive (true);
		ManagerGry.Notatka16.gameObject.SetActive (true);
		ManagerGry.Notatka17.gameObject.SetActive (true);
		ManagerGry.Notatka18.gameObject.SetActive (true);
		ManagerGry.Notatka19.gameObject.SetActive (true);
		ManagerGry.Notatka20.gameObject.SetActive (true);
		ManagerGry.Notatka21.gameObject.SetActive (true);
		ManagerGry.Notatka22.gameObject.SetActive (true);
		ManagerGry.Notatka23.gameObject.SetActive (true);
		ManagerGry.Notatka24.gameObject.SetActive (true);
		ManagerGry.Notatka25.gameObject.SetActive (true);
		ManagerGry.Notatka26.gameObject.SetActive (true);
		ManagerGry.Notatka27.gameObject.SetActive (true);
		ManagerGry.Notatka28.gameObject.SetActive (true);
		ManagerGry.Notatka29.gameObject.SetActive (true);
		ManagerGry.Notatka30.gameObject.SetActive (true);
		ManagerGry.Notatka31.gameObject.SetActive (true);
		ManagerGry.Notatka32.gameObject.SetActive (true);
		ManagerGry.Notatka33.gameObject.SetActive (true);
		ManagerGry.Notatka34.gameObject.SetActive (true);
		ManagerGry.Notatka35.gameObject.SetActive (true);
		ManagerGry.Notatka36.gameObject.SetActive (true);
		ManagerGry.Notatka37.gameObject.SetActive (true);
		ManagerGry.Notatka38.gameObject.SetActive (true);
		ManagerGry.Notatka39.gameObject.SetActive (true);
		ManagerGry.Notatka40.gameObject.SetActive (true);
		ManagerGry.Notatka41.gameObject.SetActive (true);
		ManagerGry.Notatka42.gameObject.SetActive (true);
		ManagerGry.Notatka43.gameObject.SetActive (true);
		ManagerGry.Notatka44.gameObject.SetActive (true);
		ManagerGry.Notatka45.gameObject.SetActive (true);
		ManagerGry.Notatka46.gameObject.SetActive (true);
		ManagerGry.Notatka47.gameObject.SetActive (true);
		ManagerGry.Notatka48.gameObject.SetActive (true);
		ManagerGry.Notatka49.gameObject.SetActive (true);
		ManagerGry.Notatka50.gameObject.SetActive (true);
		ManagerGry.Notatka51.gameObject.SetActive (true);
		ManagerGry.Notatka52.gameObject.SetActive (true);
		ManagerGry.Notatka53.gameObject.SetActive (true);
		ManagerGry.Notatka54.gameObject.SetActive (true);
		ManagerGry.NotatkaLisy.gameObject.SetActive (true);
		ManagerGry.ZdjecieDrewno.gameObject.SetActive (true);
		ManagerGry.ZdjecieZeno.gameObject.SetActive (true);
		ManagerGry.NotatkaZakupy.gameObject.SetActive (true);
		ManagerGry.NotatkaCytat1.gameObject.SetActive (true);
		ManagerGry.RysunekKukurydza.gameObject.SetActive (true);
		ManagerGry.NotatkaPotokLewy.gameObject.SetActive (true);
		ManagerGry.NotatkaGrzyby.gameObject.SetActive (true);
		ManagerGry.ZdjeciePotok3.gameObject.SetActive (true);
		ManagerGry.ZdjeciePotok2.gameObject.SetActive (true);
		ManagerGry.ZdjeciePotok1.gameObject.SetActive (true);
		ManagerGry.RysunekSimon.gameObject.SetActive (true);
		ManagerGry.NotatkaRap.gameObject.SetActive (true);
		ManagerGry.ZdjecieAmbona.gameObject.SetActive (true);
		ManagerGry.ZdjecieStudnia.gameObject.SetActive (true);
		ManagerGry.NotatkaCytat2.gameObject.SetActive (true);
		ManagerGry.ZdjeciePomnik.gameObject.SetActive (true);
		ManagerGry.NotatkaWynalazki.gameObject.SetActive (true);
		ManagerGry.ZdjecieWarsztat.gameObject.SetActive (true);
		ManagerGry.NotatkaCiemny.gameObject.SetActive (true);
		ManagerGry.NotatkaZwierzeta.gameObject.SetActive (true);
		ManagerGry.NotatkaNoc.gameObject.SetActive (true);
		ManagerGry.ZdjecieSzafa.gameObject.SetActive (true);
		ManagerGry.ZdjecieSzopa.gameObject.SetActive (true);
		ManagerGry.ZdjecieOboz.gameObject.SetActive (true);
		ManagerGry.NotatkaMary.gameObject.SetActive (true);
		ManagerGry.RysunekCorki.gameObject.SetActive (true);
		ManagerGry.NotatkaDyplom.gameObject.SetActive (true);
		ManagerGry.RysunekTom.gameObject.SetActive (true);
		ManagerGry.NotatkaCytat3.gameObject.SetActive (true);
		ManagerGry.RysunekPotwor.gameObject.SetActive (true);
		ManagerGry.NotatkaSzepty.gameObject.SetActive (true);
		ManagerGry.NotatkaCytat4.gameObject.SetActive (true);
		ManagerGry.RysunekRosliny.gameObject.SetActive (true);
		ManagerGry.NotatkaPole.gameObject.SetActive (true);
		ManagerGry.NotatkaArena.gameObject.SetActive (true);
		ManagerGry.NotatkaCytat5.gameObject.SetActive (true);
		ManagerGry.ZdjeciePotok4.gameObject.SetActive (true);
		ManagerGry.NotatkaKosmici.gameObject.SetActive (true);
		ManagerGry.NotatkaCytat6.gameObject.SetActive (true);
		ManagerGry.NotatkaDemona.gameObject.SetActive (true);

		ManagerGry.SwiatloMalaSzopa.gameObject.SetActive (true);
		ManagerGry.Swiatlo2.gameObject.SetActive (true);

		ManagerGry.KoscZad1.gameObject.SetActive (true);
		ManagerGry.KoscZad2.gameObject.SetActive (true);
		ManagerGry.KoscZad3.gameObject.SetActive (true);
		ManagerGry.KoscZad4.gameObject.SetActive (true);
		ManagerGry.KoscZad5.gameObject.SetActive (true);

		ManagerGry.Kamien1.gameObject.SetActive (true);
		ManagerGry.Kamien2.gameObject.SetActive (true);
		ManagerGry.Kamien3.gameObject.SetActive (true);
		ManagerGry.Kamien4.gameObject.SetActive (true);
		ManagerGry.Kamien5.gameObject.SetActive (true);

		ManagerGry.BramaFabryka.gameObject.SetActive (true);

		ManagerGry.KoliderDomAlice.gameObject.SetActive (true);
		ManagerGry.KoliderDomTom.gameObject.SetActive (true);
		ManagerGry.KoliderTomKsiazki.gameObject.SetActive (true);
		ManagerGry.KoliderTomSala.gameObject.SetActive (true);
		ManagerGry.KoliderOpuszczonyDom.gameObject.SetActive (true);
		ManagerGry.KoliderDomStevena.gameObject.SetActive (true);
		ManagerGry.KoliderDomPaul.gameObject.SetActive (true);
		ManagerGry.KoliderPaulTyl.gameObject.SetActive (true);
		ManagerGry.KoliderChatka.gameObject.SetActive (true);
        ManagerGry.KoliderOtworzDrzwi.gameObject.SetActive(true);

		ManagerGry.MonsterStatic1.gameObject.SetActive (true);
		ManagerGry.MonsterStatic2.gameObject.SetActive (true);
		ManagerGry.MonsterGlowny.gameObject.SetActive (true);

		ManagerGry.Jumpscare.pumpkinMonster.SetActive(true);
		ManagerGry.Jumpscare.brookMonster1.SetActive(true);
		ManagerGry.Jumpscare.cornfieldMonster.SetActive(true);
		ManagerGry.Jumpscare.staticCornfieldMonster.SetActive (true);
		ManagerGry.Jumpscare.corridorMonster.SetActive(true);
		ManagerGry.Jumpscare.cornfieldMonster2.SetActive(true);
		ManagerGry.Jumpscare.channelMonster.SetActive(true);
		ManagerGry.Jumpscare.meatMonster1.SetActive(true);
		ManagerGry.Jumpscare.meatMonster2.SetActive(true);
		ManagerGry.Jumpscare.paulRoomMonster.SetActive(true);
		ManagerGry.Jumpscare.paulDoorMonster.SetActive(true);
		ManagerGry.Jumpscare.gardenMonster.SetActive(true);
		ManagerGry.Jumpscare.workshopMonster.SetActive(true);
		ManagerGry.Jumpscare.abandonedMonster.SetActive(true);
		ManagerGry.Jumpscare.shedMonster1.SetActive(true);
		ManagerGry.Jumpscare.tomMonster.SetActive(true);
		ManagerGry.Jumpscare.plantMonster.SetActive(true);
		ManagerGry.Jumpscare.bushMonster.SetActive(true);
		ManagerGry.Jumpscare.paulDownstairsMonster.SetActive(true);
		ManagerGry.Jumpscare.stevenShedMonster1.SetActive(true);
		ManagerGry.Jumpscare.stevenShedMonster2.SetActive(true);
        ManagerGry.Jumpscare.beginMonster.SetActive(true);
        ManagerGry.Jumpscare.stableMonster.SetActive(true);
        ManagerGry.Jumpscare.secretRoomMonster.SetActive(true);
        ManagerGry.Jumpscare.wolf1.SetActive(true);
        ManagerGry.Jumpscare.wolf2.SetActive(true);
        ManagerGry.Jumpscare.wolf3.SetActive(true);
        ManagerGry.Jumpscare.beginWolf1.SetActive(true);
        ManagerGry.Jumpscare.beginWolf2.SetActive(true);
        ManagerGry.Jumpscare.jumpscareSpider1.SetActive(true);
        ManagerGry.Jumpscare.jumpscareSpider2.SetActive(true);
        ManagerGry.Jumpscare.spider3.SetActive(true);
        ManagerGry.Jumpscare.spider4.SetActive(true);
        ManagerGry.Jumpscare.spider5.SetActive(true);

        ManagerGry.ScarecrowStraszak.MonsterKorytarz.SetActive(true);
        ManagerGry.ScarecrowStraszak.MonsterStajnia.SetActive(true);
        ManagerGry.ScarecrowStraszak.MonsterWychodek.SetActive(true);
        ManagerGry.ScarecrowStraszak.MonsterSzalas.SetActive(true);
        ManagerGry.ScarecrowStraszak.MonsterSzalas2.SetActive(true);
        ManagerGry.ScarecrowStraszak.MonsterSzopa.SetActive(true);

        ManagerGry.MonsterLosowy.gameObject.SetActive(true);
        ManagerGry.MonsterLosowy2.gameObject.SetActive(true);
        ManagerGry.MonsterLosowy3.gameObject.SetActive(true);

        ManagerGry.Odznaka1.gameObject.SetActive(true);
        ManagerGry.Odznaka2.gameObject.SetActive(true);
        ManagerGry.Odznaka3.gameObject.SetActive(true);
        ManagerGry.Odznaka4.gameObject.SetActive(true);
        ManagerGry.Odznaka5.gameObject.SetActive(true);
        ManagerGry.Odznaka6.gameObject.SetActive(true);
        ManagerGry.Odznaka7.gameObject.SetActive(true);
        ManagerGry.Odznaka8.gameObject.SetActive(true);
        ManagerGry.Odznaka9.gameObject.SetActive(true);
        ManagerGry.Odznaka10.gameObject.SetActive(true);
        ManagerGry.Odznaka11.gameObject.SetActive(true);
        ManagerGry.Odznaka12.gameObject.SetActive(true);

        ManagerGry.Foto1.gameObject.SetActive(true);
        ManagerGry.Foto2.gameObject.SetActive(true);
        ManagerGry.Foto3.gameObject.SetActive(true);
        ManagerGry.Foto4.gameObject.SetActive(true);
        ManagerGry.Foto5.gameObject.SetActive(true);
        ManagerGry.Foto6.gameObject.SetActive(true);
        ManagerGry.Foto7.gameObject.SetActive(true);
        ManagerGry.Foto8.gameObject.SetActive(true);
        ManagerGry.Foto9.gameObject.SetActive(true);
        ManagerGry.Foto10.gameObject.SetActive(true);
        ManagerGry.Foto11.gameObject.SetActive(true);
        ManagerGry.Foto12.gameObject.SetActive(true);

        ManagerGry.Wskazowka1.gameObject.SetActive(true);
        ManagerGry.Wskazowka2.gameObject.SetActive(true);
        ManagerGry.Wskazowka3.gameObject.SetActive(true);
        ManagerGry.Wskazowka4.gameObject.SetActive(true);
        ManagerGry.Wskazowka5.gameObject.SetActive(true);
        ManagerGry.Wskazowka6.gameObject.SetActive(true);
        ManagerGry.Wskazowka7.gameObject.SetActive(true);
        ManagerGry.Wskazowka8.gameObject.SetActive(true);
        ManagerGry.Wskazowka9.gameObject.SetActive(true);
        ManagerGry.Wskazowka10.gameObject.SetActive(true);
        ManagerGry.Wskazowka11.gameObject.SetActive(true);
        ManagerGry.Wskazowka12.gameObject.SetActive(true);

        ManagerGry.YoundDead.gameObject.SetActive(true);
        ManagerGry.KurzDrzewoFall.gameObject.SetActive(true);

        ManagerGry.DrutKukurydza.SetActive(true);

        MapaGry.mapCamera.gameObject.SetActive (true);
		Tasks.mainPumpkin.SetActive (true);
		Tasks.flame1.SetActive (true);
		Tasks.flame2.SetActive (true);
		Tasks.flame3.SetActive (true);

		Music.backgroundAudioSource1.clip = null;
		Music.backgroundAudioSource2.clip = null;
		Music.backgroundAudioSource3.clip = null;
		Music.monsterBackgroundAudioSource1.clip = null;
		Music.monsterBackgroundAudioSource2.clip = null;
		Music.backgroundAudioSource1.loop = false;
		Music.backgroundAudioSource2.loop = false;
		Music.backgroundAudioSource3.loop = false;

		BohaterGlos.playerAudioSource1.clip = null;
		BohaterGlos.playerAudioSource2.clip = null;
		BohaterGlos.playerAudioSource3.clip = null;
		BohaterGlos.playerAudioSource4.clip = null;
		BohaterGlos.retrospectionAudioSource.clip = null;

		MonsterPotok1 = GameObject.Find("Monster1_Potok1").transform;
		MonsterKukurydza = GameObject.Find("Monster2_v1").transform;
		MonsterKorytarz = GameObject.Find("Monster2_v2").transform;
		MonsterKukurydza2 = GameObject.Find("Monster2_v3").transform;
		MonsterKoryto = GameObject.Find("MonsterKoryto").transform;
		Monster1_v3 = GameObject.Find("Monster1_v3").transform;
		Monster1_v4 = GameObject.Find("Monster1_v4").transform;
		MonsterPokojZachod = GameObject.Find("MonsterPokojZachod").transform;
		MonsterDrzwiZachod = GameObject.Find("MonsterDrzwiZachod").transform;
		MonsterOgrod = GameObject.Find("Monster1_v1").transform;
		MonsterWarsztat = GameObject.Find("Monster1_v2").transform;
		MonsterOpuszczony = GameObject.Find("Monster2_Opuszczony").transform;
		MonsterSzopa1 = GameObject.Find("Monster1_Szopa1").transform;
		MonsterTom = GameObject.Find("Monster1_Tom").transform;
		MonsterRoslina = GameObject.Find("Monster2_Roslina").transform;
		MonsterKrzaki = GameObject.Find("Monster1_Krzaki").transform;
		MonsterZachodDol = GameObject.Find("Monster2_ZachodDol").transform;
		MonsterSzopaSteven1 = GameObject.Find("Monster1_SzopaSteven").transform;
		MonsterSzopaSteven2 = GameObject.Find("Monster1_SzopaSteven2").transform;
		MonsterDynia = GameObject.Find("Monster1_Dynia").transform;
        MonsterPoczatek = GameObject.Find("Monster1_Poczatek").transform;
        //MonsterStajnia = GameObject.Find("Monster2_Stajnia").transform;
        //MonsterKamping = GameObject.Find("Monster2_Kamping").transform;
        Wilk1 = GameObject.Find("Wilk_v1").transform;
        Wilk2 = GameObject.Find("Wilk_v2").transform;
        Wilk3 = GameObject.Find("Wilk_v3").transform;
        WilkPoczatek1 = GameObject.Find("WilkPoczatek1").transform;
        WilkPoczatek2 = GameObject.Find("WilkPoczatek2").transform;
        PajakJumpscare1 = GameObject.Find("PajakJumpscare1").transform;
        PajakJumpscare2 = GameObject.Find("PajakJumpscare2").transform;
        Pajak3 = GameObject.Find("Pajak_v3").transform;
        Pajak4 = GameObject.Find("Pajak_v4").transform;
        Pajak5 = GameObject.Find("Pajak_v5").transform;

        MonsterSzopaScarecrow = GameObject.Find("MonsterSzopa_Scarecrow").transform;
        MonsterSzalasScarecrow2 = GameObject.Find("MonsterSzalas_Scarecrow2").transform;

        /*	Ciernie1 = GameObject.Find("CiernieKryjowka1").gameObject;
            Ciernie2 = GameObject.Find("CiernieKryjowka2").gameObject;
            Ciernie3 = GameObject.Find("CiernieKryjowka3").gameObject;
            Ciernie1.SetActive (true);
            Ciernie2.SetActive (true);
            Ciernie3.SetActive (true); */

        MonsterPotok1.transform.position = new Vector3 (1310.44f, 1.92f, 2739.86f);
		MonsterKukurydza.transform.position = new Vector3 (1200.8f, 39.21f, 2185.6f);
		MonsterKorytarz.transform.position = new Vector3 (1322.04f, 38.87566f, 2032.11f);
		MonsterKukurydza2.transform.position = new Vector3 (1351.712f, 55.19136f, 3032.091f);
		MonsterKoryto.transform.position = new Vector3 (1945.62f, 48.1f, 2695.79f);
		Monster1_v3.transform.position = new Vector3 (2382.1f, 75.56f, 2171.8f);
		Monster1_v4.transform.position = new Vector3 (2371.73f, 75.77f, 2213.46f);
		MonsterPokojZachod.transform.position = new Vector3 (1763.11f, 51.26f, 767.2f);
		MonsterDrzwiZachod.transform.position = new Vector3 (1765.206f, 52.16f, 804.425f);
        MonsterDrzwiZachod.transform.rotation = Quaternion.Euler(0, 266.645f, 0);
		MonsterOgrod.transform.position = new Vector3 (1180.984f, 40.72445f, 1955.017f);
		MonsterWarsztat.transform.position = new Vector3 (557.39f, 33.76f, 2622.97f);
		MonsterOpuszczony.transform.position = new Vector3 (2154.42f, 71.73f, 2645.84f);
		MonsterSzopa1.transform.position = new Vector3 (1281.8f, 41.72f, 1900.31f);
		MonsterTom.transform.position = new Vector3 (1478.71f, 53.4f, 2885.53f);
		MonsterRoslina.transform.position = new Vector3 (1952.91f, 52.82915f, 2201.95f);
		MonsterKrzaki.transform.position = new Vector3 (2129.819f, 54.58905f, 1910.808f);
		MonsterZachodDol.transform.position = new Vector3 (1748.585f, 52.78f, 796.586f);
        MonsterZachodDol.transform.rotation = Quaternion.Euler(0, 271.033f, 0);
        MonsterSzopaSteven1.transform.position = new Vector3 (2363.457f, 66.82f, 1645.851f);
		MonsterSzopaSteven2.transform.position = new Vector3 (2277.92f, 66.78f, 1607.33f);
		MonsterDynia.transform.position = new Vector3 (1045.19f, 32.69f, 2827.85f);
        MonsterPoczatek.transform.position = new Vector3(443.32f, 7.59f, 1839.45f);
        // MonsterStajnia.transform.position = new Vector3(443.25f, 5.55f, 1839.4f);
        // MonsterKamping.transform.position = new Vector3(443.25f, 5.55f, 1839.4f);
        Wilk1.transform.position = new Vector3(1037.6f, 33.4f, 2373.8f);
        Wilk2.transform.position = new Vector3(1949.182f, 57.35228f, 1614.711f);
        Wilk3.transform.position = new Vector3(1189.503f, 48.60358f, 1410.823f);
        WilkPoczatek1.transform.position = new Vector3(947.85f, 30.52459f, 2070.3f);
        WilkPoczatek2.transform.position = new Vector3(942.04f, 31.78f, 2073.25f);
        PajakJumpscare1.transform.position = new Vector3(1319.6f, 38.997f, 1978.5f);
        PajakJumpscare2.transform.position = new Vector3(1321.4f, 39.201f, 1971.2f);
        Pajak3.transform.position = new Vector3(1310.92f, 40.38f, 1861.95f);
        Pajak4.transform.position = new Vector3(1645.64f, 61.93f, 2705.24f);
        Pajak4.transform.rotation = Quaternion.Euler(0, 93.729f, 0);
        Pajak5.transform.position = new Vector3(1145.54f, 17.932f, 981.61f);

        // straszak scarecrow

        MonsterSzopaScarecrow.transform.position = new Vector3(1430.11f, 44.89f, 1954.72f);
        MonsterSzopaScarecrow.transform.rotation = Quaternion.Euler(0, 150.79f, 0);

        MonsterSzalasScarecrow2.transform.position = new Vector3(885.67f, 35.353f, 1848.32f);
        MonsterSzalasScarecrow2.transform.rotation = Quaternion.Euler(-0.433f, 315.441f, 0.609f);

        Kamien1 = GameObject.Find ("KamienStudnia1").transform;
		Kamien2 = GameObject.Find ("KamienStudnia2").transform;
		Kamien3 = GameObject.Find ("KamienStudnia3").transform;
		Kamien4 = GameObject.Find ("KamienStudnia4").transform;
		Kamien5 = GameObject.Find ("KamienStudnia5").transform;

		Kamien1.transform.position = new Vector3 (1131.5f, 38.55f, 2457.23f);
		Kamien2.transform.position = new Vector3 (1245.09f, 39.82f, 2446.39f);
		Kamien3.transform.position = new Vector3 (1094.275f, 38.172f, 2405.655f);
		Kamien4.transform.position = new Vector3 (1189.05f, 37.16f, 2497.77f);
		Kamien5.transform.position = new Vector3 (1127.203f, 39.001f, 2456.972f);

		SkrzyniaAmbona1 = GameObject.Find ("SkrzyniaMisjaKojotM1").transform;
		SkrzyniaAmbonaGora1 = GameObject.Find ("SkrzyniaMisjaKojotM_gora1").transform;
		SkrzyniaAmbonaGora2 = GameObject.Find ("SkrzyniaMisjaKojotM_gora2").transform;
		PalAmbona = GameObject.Find ("PalAmbona").transform;

		SkrzyniaAmbona1.transform.position = new Vector3 (721.733f, 27.02f, 1792.232f);
		SkrzyniaAmbonaGora1.transform.position = new Vector3 (724.28f, 30.866f, 1795.64f);
		SkrzyniaAmbonaGora2.transform.position = new Vector3 (723.96f, 32.076f, 1795.98f);
		PalAmbona.transform.localRotation = Quaternion.Euler(0, 301.554f, 0);

		SkrzyniaPrzedostan = GameObject.Find ("SkrzyniaPrzedostanSie").transform;
		SkrzyniaPrzedostan2 = GameObject.Find ("SkrzyniaDoPrzelozenia").transform;
		DeskaPrzedostan1 = GameObject.Find ("DeskaDoPrzejscia").transform;
		DeskaPrzedostan2 = GameObject.Find ("DeskaDoPrzejscia2").transform;
		DeskaPrzedostan3 = GameObject.Find ("DeskaDoPrzejscia3").transform;

		SkrzyniaPrzedostan.transform.position = new Vector3 (1546.3f, 53.192f, 2842.22f);
		SkrzyniaPrzedostan2.transform.position = new Vector3 (1537.48f, 53.23f, 2855.58f);
		DeskaPrzedostan1.transform.position = new Vector3 (1544.918f, 52.455f, 2836.52f);
		DeskaPrzedostan2.transform.position = new Vector3 (1550.317f, 54.711f, 2848.126f);
		DeskaPrzedostan3.transform.position = new Vector3 (1537.825f, 52.455f, 2836.767f);

		KratySteven = GameObject.Find ("KratySteven").transform;
		KratySteven.transform.position = new Vector3 (2297.85f, 65.65f, 1677.47f);
		ColorUtility.TryParseHtmlString (KolorK, out KolorKraty);
		//KratySteven.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
		KratySteven.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
		//KratySteven.GetComponent<Renderer>().material.SetColor("_EmissionColor", KolorKraty);
		KratySteven.transform.localRotation = Quaternion.Euler(0, 179.165f, 0);

        if (KratySteven.gameObject.GetComponent<Rigidbody>())
        {
            Destroy(KratySteven.gameObject.GetComponent<Rigidbody>());
        }

		SkrzyniaSteven1 = GameObject.Find ("SkrzyniaSteven1").transform;
		SkrzyniaSteven2 = GameObject.Find ("SkrzyniaSteven2").transform;
		SkrzyniaSteven3 = GameObject.Find ("SkrzyniaSteven3").transform;

		SkrzyniaSteven1.transform.position = new Vector3 (2367.75f, 66.307f, 1639.82f);
		SkrzyniaSteven2.transform.position = new Vector3 (2329.92f, 66.3f, 1667.95f);
		SkrzyniaSteven3.transform.position = new Vector3 (2282.05f, 66.301f, 1611.57f);

		Trup = GameObject.Find ("TrupL").transform;
		Trup.transform.position = new Vector3 (1760.144f, 64.08f, 782.376f);
		Trup.transform.localRotation = Quaternion.Euler(-90.00001f, 0f, 183.722f);

        if (Trup.gameObject.GetComponent<Rigidbody>())
        {
            Destroy(Trup.gameObject.GetComponent<Rigidbody>());
        }

        // kolider otworz drzwi screaner

        KoliderOtworzDrzwi = GameObject.Find("KoliderOtworzDrzwi").transform;
        KoliderOtworzDrzwi.transform.position = new Vector3(1750.4f, 65.938f, 798.072f);
        KoliderOtworzDrzwi.transform.localRotation = Quaternion.Euler(0, 0, 0);

        if (KoliderOtworzDrzwi.gameObject.GetComponent<Rigidbody>())
        {
            Destroy(KoliderOtworzDrzwi.gameObject.GetComponent<Rigidbody>());
        }

        // drzwi i szafki

        DrzwiPokojW = GameObject.Find ("DrzwiPokojW").transform;
		DrzwiPokojW.transform.localPosition = new Vector3 (-0.9535713f, -0.03286743f, -0.1560337f);
		DrzwiPokojW.transform.rotation = Quaternion.Euler(-180, -177.494f, 180);

	/*	SzafaKuchnia = GameObject.Find ("SzafaKuchnia").transform;
		SzafaKuchnia.transform.localPosition = new Vector3 (-96.9f, 106.5228f, 22.6f);
        SzafaKuchnia.transform.localRotation = Quaternion.Euler(0, 0, 180); */

      /*  DrzwiWneka = GameObject.Find ("DrzwiWneka").transform;
		DrzwiWneka.transform.position = new Vector3 (0.0249707f, 0.2184987f, -0.4597453f);
		DrzwiWneka.transform.rotation = Quaternion.Euler(-90.00001f, 0, 0); */

		SzafaKorytarz = GameObject.Find ("SzafaKorytarz").transform;
		SzafaKorytarz.transform.localPosition = new Vector3 (-96.9f, 106.5228f, 22.6f);
		SzafaKorytarz.transform.localRotation = Quaternion.Euler(0, 0, 180);

		DrzwiStajnia = GameObject.Find ("DrzwiStajnia").transform;
		//DrzwiStajnia.transform.position = new Vector3 (-0.9535713f, -0.03286743f, -0.1560337f);
		//DrzwiStajnia.transform.localRotation = Quaternion.Euler(-180, -177.494f, 180);

		DrzwiSzopaNarzedzia = GameObject.Find ("DrzwiSzopaNarzedzia").transform;
		DrzwiSzopaNarzedzia.transform.localPosition = new Vector3 (-0.9535713f, -0.03286743f, -0.1560337f);
		DrzwiSzopaNarzedzia.transform.localRotation = Quaternion.Euler(-180, -177.494f, 180);

	/*	DrzwiKamping = GameObject.Find ("DrzwiKamping").transform;
		DrzwiKamping.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiKamping.transform.localRotation = Quaternion.Euler(89.00001f, 90.00001f, 90.00001f); */

	/*	SzafkaSzopa = GameObject.Find ("SzafkaSzopa").transform;
		SzafkaSzopa.transform.position = new Vector3 (-0.5645f, -0.1812287f, 0.1763129f);
		SzafkaSzopa.transform.localRotation = Quaternion.Euler(179.846f, 0.001998901f, 0.7399902f);

		SzafkaSzopa2 = GameObject.Find ("SzafkaSzopa2").transform;
		SzafkaSzopa2.transform.position = new Vector3 (0.5645f, -0.1812287f, 0.1763129f);
		SzafkaSzopa2.transform.localRotation = Quaternion.Euler(0, 0, -1); */

	/*	DrzwiKukurydza = GameObject.Find ("DrzwiKukurydza").transform;
		DrzwiKukurydza.transform.position = new Vector3 (-0.134f, 0.178f, -0.603f);
		DrzwiKukurydza.transform.rotation = Quaternion.Euler(-90.00001f, 0, -2.313f); */

		DrzwiOgrod = GameObject.Find ("DrzwiOgrod").transform;
		DrzwiOgrod.transform.localPosition = new Vector3 (1246f, 40.955f, 2048.814f);
		DrzwiOgrod.transform.localRotation = Quaternion.Euler(0, -4.406f, 0);

		DrzwiDomAlice = GameObject.Find ("DrzwiDomAlice").transform;
		DrzwiDomAlice.transform.position = new Vector3 (-0.624f, 0.04f, -1.948f);
		DrzwiDomAlice.transform.localRotation = Quaternion.Euler(90.61099f, -67.392f, -67.379f);

		DrzwiSalonPoludnie = GameObject.Find ("DrzwiSalonPoludnie").transform;
		DrzwiSalonPoludnie.transform.position = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiSalonPoludnie.transform.localRotation = Quaternion.Euler(90.91199f, -85.43701f, -85.41199f);

		DrzwiFabrykaDrewno = GameObject.Find ("DrzwiFabrykaDrewno").transform;
		DrzwiFabrykaDrewno.transform.position = new Vector3 (569.55f, 27.99f, 2601.97f);
		DrzwiFabrykaDrewno.transform.localRotation = Quaternion.Euler(-90.49899f, -3.459991f, 270.089f);

		/*DrzwiFabrykaMetal = GameObject.Find ("DrzwiFabrykaMetal").transform;
		DrzwiFabrykaMetal.transform.position = new Vector3 (543.207f, 30.716f, 2632.677f);
		DrzwiFabrykaMetal.transform.localRotation = Quaternion.Euler(0, -84.442f, 0); */

		DrzwiDomTom = GameObject.Find ("DrzwiDomTom").transform;
		DrzwiDomTom.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiDomTom.transform.localRotation = Quaternion.Euler(89.00001f, 90.00101f, 90.00101f);

		DrzwiPokojTom = GameObject.Find ("DrzwiPokojTom").transform;
		DrzwiPokojTom.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiPokojTom.transform.localRotation = Quaternion.Euler(90.46399f, -80.444f, -80.37598f);

		DrzwiSalaTom = GameObject.Find ("DrzwiSalaTom").transform;
		DrzwiSalaTom.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiSalaTom.transform.localRotation = Quaternion.Euler(88.994f, 89.999f, 89.999f);

		DrzwiKsiazkiTom = GameObject.Find ("DrzwiKsiazkiTom").transform;
		DrzwiKsiazkiTom.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiKsiazkiTom.transform.localRotation = Quaternion.Euler(90.68201f, -81.68399f, -81.64999f);

		DrzwiTomGora = GameObject.Find ("DrzwiTomGora").transform;
		DrzwiTomGora.transform.position = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiTomGora.transform.localRotation = Quaternion.Euler(91.22601f, -84.01898f, -83.99899f);

		DrzwiOpuszczony = GameObject.Find ("DrzwiOpuszczony").transform;
		DrzwiOpuszczony.transform.localPosition = new Vector3 (2182.5f, 74.13f, 2640.01f);
		DrzwiOpuszczony.transform.localRotation = Quaternion.Euler(-89.94401f, 0, 183.52f);

		SzafaStaryDom = GameObject.Find ("SzafaStaryDom").transform;
		SzafaStaryDom.transform.localPosition = new Vector3 (-96.9f, 106.5228f, 22.6f);
		SzafaStaryDom.transform.localRotation = Quaternion.Euler(0, 0, 180);

		DrzwiDomSteven = GameObject.Find ("DrzwiDomSteven").transform;
		DrzwiDomSteven.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiDomSteven.transform.localRotation = Quaternion.Euler(89.00001f, 90.00001f, 90.00001f);

		DrzwiSteven = GameObject.Find ("DrzwiSteven").transform;
		DrzwiSteven.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiSteven.transform.localRotation = Quaternion.Euler(90.76199f, -81.37f, -81.37201f);

		DrzwiDomPaul = GameObject.Find ("DrzwiDomPaul").transform;
		DrzwiDomPaul.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiDomPaul.transform.localRotation = Quaternion.Euler(89.00001f, 90.00001f, 90.00001f);

		DrzwiMonster = GameObject.Find ("DrzwiMonster").transform;
		DrzwiMonster.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiMonster.transform.localRotation = Quaternion.Euler(89.00001f, 90.00101f, 90.00101f);

		DrzwiOtworzJmp = GameObject.Find ("DrzwiOtworzJmp").transform;
		DrzwiOtworzJmp.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiOtworzJmp.transform.localRotation = Quaternion.Euler(95.53601f, -75.91599f, -75.64099f);

		DrzwiZachod = GameObject.Find ("DrzwiZachod").transform;
		DrzwiZachod.transform.localPosition = new Vector3 (-0.6195f, 0.04128f, -2.045296f);
		DrzwiZachod.transform.localRotation = Quaternion.Euler(89.204f, 90.00101f, 90.00101f);

		SzafaPaul = GameObject.Find ("SzafaPaul").transform;
		SzafaPaul.transform.localPosition = new Vector3 (-96.9f, 106.5228f, 22.6f);
		SzafaPaul.transform.localRotation = Quaternion.Euler(0, 0, 180);

		DrzwiDomek = GameObject.Find ("DrzwiDomek").transform;
		DrzwiDomek.transform.localPosition = new Vector3 (1348.059f, 49.03f, 1207.175f);
		DrzwiDomek.transform.localRotation = Quaternion.Euler(-89.75101f, 84.915f, 454.702f);

        Odznaka1 = GameObject.Find("Odznaka1").transform;
        Odznaka2 = GameObject.Find("Odznaka2").transform;
        Odznaka3 = GameObject.Find("Odznaka3").transform;
        Odznaka4 = GameObject.Find("Odznaka4").transform;
        Odznaka5 = GameObject.Find("Odznaka5").transform;
        Odznaka6 = GameObject.Find("Odznaka6").transform;
        Odznaka7 = GameObject.Find("Odznaka7").transform;
        Odznaka8 = GameObject.Find("Odznaka8").transform;
        Odznaka9 = GameObject.Find("Odznaka9").transform;
        Odznaka10 = GameObject.Find("Odznaka10").transform;
        Odznaka11 = GameObject.Find("Odznaka11").transform;
        Odznaka12 = GameObject.Find("Odznaka12").transform;

        Odznaka1.gameObject.SetActive(true);
        Odznaka2.gameObject.SetActive(true);
        Odznaka3.gameObject.SetActive(true);
        Odznaka4.gameObject.SetActive(true);
        Odznaka5.gameObject.SetActive(true);
        Odznaka6.gameObject.SetActive(true);
        Odznaka7.gameObject.SetActive(true);
        Odznaka8.gameObject.SetActive(true);
        Odznaka9.gameObject.SetActive(true);
        Odznaka10.gameObject.SetActive(true);
        Odznaka11.gameObject.SetActive(true);
        Odznaka12.gameObject.SetActive(true);

        Foto1 = GameObject.Find("Foto1").transform;
        Foto2 = GameObject.Find("Foto2").transform;
        Foto3 = GameObject.Find("Foto3").transform;
        Foto4 = GameObject.Find("Foto4").transform;
        Foto5 = GameObject.Find("Foto5").transform;
        Foto6 = GameObject.Find("Foto6").transform;
        Foto7 = GameObject.Find("Foto7").transform;
        Foto8 = GameObject.Find("Foto8").transform;
        Foto9 = GameObject.Find("Foto9").transform;
        Foto10 = GameObject.Find("Foto10").transform;
        Foto11 = GameObject.Find("Foto11").transform;
        Foto12 = GameObject.Find("Foto12").transform;

        Foto1.gameObject.SetActive(true);
        Foto2.gameObject.SetActive(true);
        Foto3.gameObject.SetActive(true);
        Foto4.gameObject.SetActive(true);
        Foto5.gameObject.SetActive(true);
        Foto6.gameObject.SetActive(true);
        Foto7.gameObject.SetActive(true);
        Foto8.gameObject.SetActive(true);
        Foto9.gameObject.SetActive(true);
        Foto10.gameObject.SetActive(true);
        Foto11.gameObject.SetActive(true);
        Foto12.gameObject.SetActive(true);

        Wskazowka1 = GameObject.Find("Wskazowka1").transform;
        Wskazowka2 = GameObject.Find("Wskazowka2").transform;
        Wskazowka3 = GameObject.Find("Wskazowka3").transform;
        Wskazowka4 = GameObject.Find("Wskazowka4").transform;
        Wskazowka5 = GameObject.Find("Wskazowka5").transform;
        Wskazowka6 = GameObject.Find("Wskazowka6").transform;
        Wskazowka7 = GameObject.Find("Wskazowka7").transform;
        Wskazowka8 = GameObject.Find("Wskazowka8").transform;
        Wskazowka9 = GameObject.Find("Wskazowka9").transform;
        Wskazowka10 = GameObject.Find("Wskazowka10").transform;
        Wskazowka11 = GameObject.Find("Wskazowka11").transform;
        Wskazowka12 = GameObject.Find("Wskazowka12").transform;

        Wskazowka1.gameObject.SetActive(true);
        Wskazowka2.gameObject.SetActive(true);
        Wskazowka3.gameObject.SetActive(true);
        Wskazowka4.gameObject.SetActive(true);
        Wskazowka5.gameObject.SetActive(true);
        Wskazowka6.gameObject.SetActive(true);
        Wskazowka7.gameObject.SetActive(true);
        Wskazowka8.gameObject.SetActive(true);
        Wskazowka9.gameObject.SetActive(true);
        Wskazowka10.gameObject.SetActive(true);
        Wskazowka11.gameObject.SetActive(true);
        Wskazowka12.gameObject.SetActive(true);

        YoundDead = GameObject.Find("YoungDead").transform;
        YoundDead.gameObject.SetActive(true);

        KurzDrzewoFall = GameObject.Find("KurzDrzewoFall").gameObject;
        KurzDrzewoFall.SetActive(true);

    }

}
