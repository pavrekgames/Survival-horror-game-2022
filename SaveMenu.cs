using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;


public class SaveMenu : MonoBehaviour {

	public AudioClip DzwMenuZapis;
	public AudioSource ZrodloDzwieku;

	public Toggle TogglePelnyEkran;
	public TMP_Dropdown Rozdzielczosc;
	public TMP_Dropdown JakoscTekstur;
	public TMP_Dropdown WygladzanieKrawedzi;
	public TMP_Dropdown VsyncDropdown;
	public TMP_Dropdown Cienie;
    public Slider SuwakJasnosc;

    public Slider SuwakMuzyka;
	public Slider SuwakDzwieki;
	public AudioMixer GlownyMixer;
	public float Music;
	public float Sound;
	public bool MuzykaUstawiona_ok = false;
	public bool DzwiekUstawiony_ok = false;

	public Slider SuwakIntensywnosc;

	public TMP_Dropdown WyborJezyka;
	public Toggle ToggleNapisy;

    public Menu MenuGry;

	void Awake () {

		//DzwMenuZapis = Resources.Load<AudioClip>("Muzyka/ZapisMenu");
		/*ZrodloDzwieku = GameObject.Find ("MuzykaCzynnosc").GetComponent<AudioSource> ();

		TogglePelnyEkran = GameObject.Find ("TogglePelnyEkran").GetComponent<Toggle> ();
		Rozdzielczosc = GameObject.Find ("Rozdzielczosc").GetComponent<Dropdown> ();
		JakoscTekstur = GameObject.Find ("JakoscTekstur").GetComponent<Dropdown> ();
		WygladzanieKrawedzi = GameObject.Find ("WygladzanieKrawedzi").GetComponent<Dropdown> ();
		VsyncDropdown = GameObject.Find ("VsyncDropdown").GetComponent<Dropdown> ();
		Cienie = GameObject.Find ("Cienie").GetComponent<Dropdown> ();

		SuwakMuzyka = GameObject.Find ("SuwakMuzyka").GetComponent<Slider> ();
		SuwakDzwieki = GameObject.Find ("SuwakDzwieki").GetComponent<Slider> ();
		//GlownyMixer = Resources.Load<AudioMixer>("Mixery/GłownyMixer");

		SuwakIntensywnosc = GameObject.Find ("SuwakIntensywnosc").GetComponent<Slider> ();

		WyborJezyka = GameObject.Find ("WyborJezyka").GetComponent<Dropdown> ();
		ToggleNapisy = GameObject.Find ("ToggleNapisy").GetComponent<Toggle> (); */



	}
	

	void Update () {

		if (SuwakMuzyka.value != Music && MuzykaUstawiona_ok == false) {
			SuwakMuzyka.value = Mathf.Lerp (SuwakMuzyka.value, Music, Time.deltaTime * 5);
		} 

		if (SuwakMuzyka.value == Music && MuzykaUstawiona_ok == false) {
			MuzykaUstawiona_ok = true;
		}

		if (SuwakDzwieki.value != Sound && DzwiekUstawiony_ok == false) {
			SuwakDzwieki.value = Mathf.Lerp (SuwakDzwieki.value, Sound, Time.deltaTime * 5);
		} 

		if (SuwakDzwieki.value == Sound && DzwiekUstawiony_ok == false) {
			DzwiekUstawiony_ok = true;
		}

	}

	public void Zapisz(){


		FileStream Plik = File.Create(Application.persistentDataPath + "/MenuSave.pav");

		MenuDane Dane = new MenuDane ();

		Dane.FullScreen = TogglePelnyEkran.isOn;
		Dane.Resolution = Rozdzielczosc.value;
		Dane.TextureQuality = JakoscTekstur.value;
		Dane.AntiAliasing = WygladzanieKrawedzi.value;
		Dane.Vsync = VsyncDropdown.value;
		Dane.Shadows = Cienie.value;
        Dane.brightness = SuwakJasnosc.value;


		Dane.Music = SuwakMuzyka.value;
		Dane.Sound = SuwakDzwieki.value;

		Dane.MouseIntensity = SuwakIntensywnosc.value;

		Dane.Language = WyborJezyka.value;
		Dane.Subtitles = ToggleNapisy.isOn;

		BinaryFormatter Bf = new BinaryFormatter ();
		Bf.Serialize (Plik, Dane);
		Plik.Close ();

		ZrodloDzwieku.PlayOneShot (DzwMenuZapis);

	}

	public void Wczytaj(){

		if (File.Exists (Application.persistentDataPath + "/MenuSave.pav")) {

			FileStream Plik = File.Open (Application.persistentDataPath + "/MenuSave.pav", FileMode.Open);

			BinaryFormatter Bf = new BinaryFormatter ();

			MenuDane Dane = (MenuDane)Bf.Deserialize (Plik);

			Plik.Close ();

			TogglePelnyEkran.isOn = Dane.FullScreen;
			Rozdzielczosc.value = Dane.Resolution;
			JakoscTekstur.value = Dane.TextureQuality;
            MenuGry.SetTextureQuality();
			WygladzanieKrawedzi.value = Dane.AntiAliasing;
			VsyncDropdown.value = Dane.Vsync;
			Cienie.value = Dane.Shadows;
            SuwakJasnosc.value = Dane.brightness;

			SuwakMuzyka.value = Dane.Music;
			SuwakDzwieki.value = Dane.Sound;
			Music = Dane.Music;
			Sound = Dane.Sound;
			//GlownyMixer.SetFloat ("DzwiekiVol", Dane.Sound);
			//GlownyMixer.SetFloat ("MuzykaVol", Dane.Music);


			SuwakIntensywnosc.value = Dane.MouseIntensity;

			WyborJezyka.value = Dane.Language;
			ToggleNapisy.isOn = Dane.Subtitles;



		}

	}


}

[Serializable]
class MenuDane{

	//grafika

	public bool FullScreen;
	public int Resolution;
	public int TextureQuality;
	public int AntiAliasing;
	public int Vsync;
	public int Shadows;
    public float brightness;

	//dzwiek

	public float Music;
	public float Sound;

	//input

	public float MouseIntensity;

	//jezyk

	public int Language;
	public bool Subtitles;

}
