using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {

    private PlayerManager playerManagerScript;

	public float couchFactor = 0.6f;
	public float couchTime = 5f;
	public float currentHeight;
	public float getUpHeight;
	public float crouchHeight;
	public bool isCrouch = false;

	public CrouchCollision crouchCollisionScript;
	private Transform player;
	private Animator animator;
    private AudioSource audioSource;
    public AudioClip crouchSound;

	void OnEnable(){

		player = GameObject.Find("Player").transform;
        playerManagerScript = player.GetComponent<PlayerManager>();
        currentHeight = transform.localScale.y;
		getUpHeight = transform.localScale.y;
		crouchHeight = transform.localScale.y * couchFactor;
		animator = GetComponent<Animator>();
        audioSource = GameObject.Find("CrouchAudioSource").GetComponent<AudioSource>();

    }
			
	void Update () {


		if(Input.GetButtonDown("Crouch") && isCrouch == false && playerManagerScript.isPlayerCanInput == true)
        {

			CrouchFunc ();

		}else if(Input.GetButtonDown("Crouch") && isCrouch == true && playerManagerScript.isPlayerCanInput == true)
        {
			
			GetUp ();
		}

		transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, currentHeight, 5 * Time.deltaTime), transform.localScale.z);

	}

	void CrouchFunc(){
            currentHeight = crouchHeight;
            isCrouch = true;
            animator.SetBool("isCrouch", true);
            animator.SetBool("isGetUp", false);
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.PlayOneShot(crouchSound);
	}
		
	public void GetUp(){

        if(crouchCollisionScript.isCollide == false)
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
