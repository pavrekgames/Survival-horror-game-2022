using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerSounds : MonoBehaviour {

    private Transform player;
    private Player playerScript;
    private Health healtScript;
    private Crouch crouchScript;
    private CharacterController characterControler;

    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;
    [SerializeField] private float stepCounter = 0f;
    [SerializeField] private float stepDuration = 0.6f;
	
	public bool isGround;
	public bool isRun = false;

    [SerializeField] private TextureSound[] sounds;
    private TextureSound currentSound;
    private bool isCollide = false;

    void OnEnable()
    {
        SetDefaultStepWalkSound();

        player = GetComponent<Transform>();
        playerScript = GetComponent<Player>();
        healtScript = player.GetComponent<Health>();
        crouchScript = GetComponent<Crouch>();
        characterControler = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (audioSource1 != null)
        {
            PlayStepWalkSound();
        }
    }

    private void PlayStepWalkSound()
    {

        if ((Input.GetKeyDown("left shift") && Input.GetAxis("Vertical") > 0))
        {
            isRun = true;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            isRun = false;
        }

        if (stepCounter > 0)
        {
            if (isRun == true && characterControler.isGrounded)
            {
                stepCounter -= Time.deltaTime * 1.3f;
            }
            else
            {
                stepCounter -= Time.deltaTime;
            }
        }

        if ((Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0) && characterControler.isGrounded && stepCounter <= 0 && healtScript.health > 0)
        {
            GetSound();
            audioSource1.pitch = Random.Range(0.8f, 1.5f);
            stepCounter = stepDuration;
            audioSource1.PlayOneShot(currentSound.sound);
        }

        if (Input.GetButtonDown("Jump") && crouchScript.isCrouch == false && healtScript.health > 0 && isGround)
        {
            audioSource2.pitch = Random.Range(0.8f, 1.1f);
            audioSource2.clip = jumpSound;
            audioSource2.Play();
        }

        if (!isGround && characterControler.isGrounded && healtScript.health > 0)
        {
            audioSource1.pitch = Random.Range(0.8f, 1.5f);
            audioSource1.PlayOneShot(landSound);
        }
        isGround = characterControler.isGrounded;
    }

    private void GetSound()
    {
        if (!isCollide)
        {
            bool isGot = false;
            for (int i = 0; i < sounds.Length; i++)
            {
                TextureSound sound = sounds[i];
                if (sound.texture != null && sound.texture.name.Equals(TerrainSurface.TextureNameInPosition(player.position)))
                {
                    currentSound = sound;
                    isGot = true;
                    break;
                }
            }
            if (!isGot)
            {
                currentSound = sounds[0];
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Transform collideObject = hit.collider.gameObject.GetComponent<Transform>();

        if (collideObject.tag == "Terrain")
        {
            isCollide = false;
        }
        else
        {
            ObjectSound objectSound = collideObject.GetComponent<ObjectSound>();
            if (objectSound != null && objectSound.textureSound.sound != null)
            {
                currentSound = objectSound.textureSound;
            }
            else
            {
                currentSound = sounds[0];
            }
            isCollide = true;
        }
    }

    private void SetDefaultStepWalkSound()
    {
        if (sounds.Length > 0 && sounds[0].sound != null)
        {
            currentSound = sounds[0];
        }
    }
}

