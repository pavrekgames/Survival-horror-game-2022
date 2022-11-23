using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {

	public float couchFactor = 0.6f;
	public float couchTime = 5f;
	public float currentHeight;
	public float getUpHeight;
	public float crouchHeight;
	public bool isCrouch = false;
	public CrouchCollision crouchCollisionScript;
	private Transform player;
	private Health healthScript;
	private Animator animator;
    private AudioSource audioSource;
    public AudioClip crouchSound;

	void Awake(){

		animator = GetComponent<Animator>();

	}

	void OnEnable(){

		player = GameObject.Find("Player").transform;
        healthScript = player.GetComponent<Health>();
        currentHeight = transform.localScale.y;
		getUpHeight = transform.localScale.y;
		crouchHeight = transform.localScale.y * couchFactor;
		animator = GetComponent<Animator>();
        audioSource = GameObject.Find("CrouchAudioSource").GetComponent<AudioSource>();

    }
			

	void Update () {


		if(Input.GetButtonDown("Crouch") && isCrouch == false && Time.timeScale == 1)
        {

			CrouchFunc ();

		}else if(Input.GetButtonDown("Crouch") && isCrouch == true && Time.timeScale == 1)
        {
			
			GetUp ();
		}

		transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, currentHeight, 5 * Time.deltaTime), transform.localScale.z);

	}

	void CrouchFunc(){

        if(healthScript.health > 0)
        {
            currentHeight = crouchHeight;
            isCrouch = true;
            animator.SetBool("isCrouch", true);
            animator.SetBool("isGetUp", false);
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(crouchSound);
        }
		
	}
		
	public void GetUp(){

        if(crouchCollisionScript.isCollide == false && healthScript.health > 0)
        {
            currentHeight = getUpHeight;
            isCrouch = false;
            animator.SetBool("isCrouch", false);
            animator.SetBool("isGetUp", true);
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(crouchSound);
        }
		
    }

}
