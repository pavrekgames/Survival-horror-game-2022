using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	private AudioSource ZrodloDzwieku;
	public AudioClip Muzyka;
	public bool Muzyka_ok = false;
	private Canvas Gazeta1;
	public bool Gazeta1_ok = false;
	private Canvas Gazeta2;
	public bool Gazeta2_ok = false;
	private Animator Przejscie1;
	public bool Przejscie1_ok = false;
	private Animator Przejscie2;
	public bool Przejscie2_ok = false;
	public float Licznik = 0;
	private Canvas Credits;
	public bool Credits_ok = false;
	private Image Napisy;
	private Animator NapisyAnim;
	private Transform Player;
	private Menu MenuGlowne;
	private Canvas CzarnyEkran;
	private MenuManager ManagerMenu;
	private CrosshairGUI Kursor;

	void OnEnable () {

		ZrodloDzwieku = GameObject.Find ("MuzykaTlo").GetComponent<AudioSource> ();
		//Muzyka = Resources.Load<AudioClip>("Muzyka/Muzyka_v15");
		Gazeta1 = GameObject.Find ("CanvasGazeta1").GetComponent<Canvas> ();
		Gazeta2 = GameObject.Find ("CanvasGazeta2").GetComponent<Canvas> ();
		Przejscie1 = GameObject.Find ("CzarnyObrazGazeta").GetComponent<Animator> ();
		Przejscie2 = GameObject.Find ("CzarnyObrazGazeta2").GetComponent<Animator> ();
		Credits = GameObject.Find ("CanvasCredits").GetComponent<Canvas> ();
		Napisy = GameObject.Find ("TloCredits").GetComponent<Image> ();
		NapisyAnim = GameObject.Find ("CreditsAll").GetComponent<Animator> ();
		Player = GameObject.Find ("Player").transform;
		MenuGlowne = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
		CzarnyEkran = GameObject.Find("CanvasCzynnoscSiekiera").GetComponent<Canvas>();
		ManagerMenu = GameObject.Find ("Player").GetComponent<MenuManager> ();
		Kursor = GameObject.Find ("Kamera").GetComponent<CrosshairGUI> ();

	}


	void Update () {

		Licznik += (1 * Time.deltaTime);

		if (Licznik > 3 && Muzyka_ok == false) {

			ZrodloDzwieku.clip = Muzyka;
			ZrodloDzwieku.loop = true;
			ZrodloDzwieku.Play ();
			Muzyka_ok = true;
		}

		if(ZrodloDzwieku.time > 3 && Gazeta1_ok == false){

			Gazeta1.enabled = true;
			Przejscie1.SetTrigger ("Przejscie2");
			Gazeta1_ok = true;
		}

		if (ZrodloDzwieku.time > 14 && Przejscie1_ok == false) {
			Przejscie1.SetTrigger ("Przejscie1");
			Przejscie1_ok = true;
		}

		if (ZrodloDzwieku.time > 20 && Gazeta2_ok == false) {
			Gazeta2.enabled = true;
			Przejscie2.SetTrigger ("Przejscie2");
			Gazeta2_ok = true;
		}

		if (ZrodloDzwieku.time > 28 && Przejscie2_ok == false) {
			Przejscie2_ok = true;
			Przejscie2.SetTrigger ("Przejscie1");
		}

		if (Licznik >= 35 && Credits_ok == false) {
			Gazeta2.enabled = false;
			Credits.enabled = true;
			Credits_ok = true;
			NapisyAnim.SetTrigger ("Napisy");
		}

		if (NapisyAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && NapisyAnim.GetCurrentAnimatorStateInfo(0).IsName("Credits2") && !NapisyAnim.IsInTransition(0) && Credits_ok == true && Credits.enabled == true) {
            NapisyAnim.SetTrigger("NapisyDefault");
			Player.GetComponent<Crouch> ().enabled = true;
			MenuGlowne.enabled = true;
			Credits.enabled = false;
			CzarnyEkran.enabled = false;
			MenuGlowne.ExitToMenu ();
			MenuGlowne.enabled = false;
			Kursor.m_ShowCursor = true;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;	
			//SceneManager.LoadScene ("MenuGlowne");
		}

	}
}
