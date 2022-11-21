using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour {

	private Canvas pavrekSceneCanvas;
	private AudioSource audioSource;
	public AudioClip stormSound;
	private Animator animator;
	private Animator ligtingAnimator;
	public bool isPass1 = false;
	public bool isPass2 = false;

	void Start () {

		pavrekSceneCanvas = GameObject.Find ("CanvasPavrek").GetComponent<Canvas> ();
		audioSource = GameObject.Find ("ZrodloDzwieku").GetComponent<AudioSource> ();
		animator = GameObject.Find ("Logo").GetComponent<Animator> ();
		ligtingAnimator = GameObject.Find ("Tlo").GetComponent<Animator> ();
		audioSource.clip = stormSound;
		audioSource.Play ();
        Cursor.visible = false;
	}

	void Update () {

		if (audioSource.time > 3 && isPass2 == false) {

			ligtingAnimator.SetTrigger ("Blyski");
			isPass2 = true;

		}

		if (audioSource.time < 10 && isPass1 == false) {

			audioSource.volume = audioSource.volume += (Time.deltaTime / 4);

		}

		if (audioSource.time > 10 && isPass1 == false) {
			animator.SetTrigger ("LogoPavrek");
			isPass1 = true;
		}

		if (audioSource.time > 17 && isPass1 == true) {

			audioSource.volume = audioSource.volume -= (Time.deltaTime / 4);

		}

		if (audioSource.volume == 0 && isPass1 == true) {

			SceneManager.LoadScene ("MenuGlowne");

		}

	}
}
