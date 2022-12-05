using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour {

    // inventory
    private PlayerManager playerManagerScript;
    public List<Item> items = new List<Item>();
    private Animator animator;
    private CrosshairGUI cursorScript;
    private Player playerScript;
    public bool isInventoryActive = false;
    private Menu gameMenuScript;
    public Notifications notificationScript;
    public AudioSource itemAudioSource1;
    public AudioSource itemAudioSource2;
    public AudioSource itemAudioSource3;
    public AudioSource itemAudioSource4;
    public AudioSource pauseAudioSource;

    public InventoryUI inventoryUI;

    public int secretItemsCount = 0;
    public int secretPlacesCount = 0;
    public int blueHerbsCount = 0;
    public int greenHerbsCount = 0;
    public int healthPotsCount = 0;
    public int staminaPotsCount = 0;
    public int vialsCount = 0;

    public AudioClip openInventorySound;

    private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;

    // Do osiagniec Steam

    public int badgesCount = 0;
    public int tipsCount = 0;
    public int photosCount = 0;
    public int skillsCount = 0;

    public event Action OnAddedCollectibleItem;

	void OnEnable(){

        playerCam = Camera.main;

        playerManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
    
		cursorScript = GameObject.Find ("Kamera").GetComponent<CrosshairGUI>();
		playerScript = GameObject.Find ("Player").GetComponent<Player>();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu>();
		animator = GameObject.Find ("Player").GetComponent<Animator>();
	
		notificationScript = GameObject.Find ("Player").GetComponent<Notifications>();
        
		itemAudioSource1 = GameObject.Find ("ZrodloPrzedmiot_s").GetComponent<AudioSource>();      // klucze
		itemAudioSource2 = GameObject.Find ("ZrodloPrzedmiot2_s").GetComponent<AudioSource>();    // glosne
		itemAudioSource3 = GameObject.Find ("ZrodloPrzedmiot3_s").GetComponent<AudioSource>();    // srednie
		itemAudioSource4 = GameObject.Find ("ZrodloPrzedmiot4_s").GetComponent<AudioSource>();    // ciche
        pauseAudioSource = GameObject.Find("ZrodloPrzedmiotPause_s").GetComponent<AudioSource>();

    }

    void Update()
    {
        InventoryInput();
        PickUpItem();
    }

    void InventoryInput()
    {
        if (Input.GetButtonDown("Inventory") && playerManagerScript.isPlayerCanInput == true)
        {
            OpenInventory();
        }
        else if (gameMenuScript.isMenu == true)
        {
            cursorScript.m_ShowCursor = true;
        }
    }

    void PickUpItem()
    {
        if (Input.GetMouseButtonDown(0) && playerManagerScript.isPlayerCanInput == true)
        {
            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9))
            {

                if (hit.collider.gameObject.tag == "TaskItem")
                {
                    hit.transform.gameObject.GetComponent<TaskItem>().PickUpItem();
                }

                else if (hit.collider.gameObject.tag == "CollectibleItem")
                {
                    hit.transform.gameObject.GetComponent<CollectibleItem>().PickUpItem();
                }
            }
        }
    }

   void OpenInventory()
    {
        inventoryUI.ShowInventory();
        Time.timeScale = 0;
        cursorScript.m_ShowCursor = true;
        playerScript.audioSource.Pause();
        playerScript.enabled = false;
        pauseAudioSource.pitch = 1;
        pauseAudioSource.PlayOneShot(openInventorySound);
    }

   public void AddItem(Item item, AudioClip pickUpSound)
    {
        animator.SetTrigger("PickUp");
        itemAudioSource1.PlayOneShot(pickUpSound);

        items.Add(item);
        item.isTaken = true;
        item.id += 1;
    }

    public void AddCollectibleItem(AudioSource audioSource, AudioClip itemSound, int itemsCount, NotificationType notificationType)
    {
        audioSource.PlayOneShot(itemSound);
        itemsCount++;
        notificationScript.notificationType = notificationType;
        animator.SetTrigger("PickUp");

        if(OnAddedCollectibleItem != null)
        {
            OnAddedCollectibleItem.Invoke();
        }

    }

    public void RemoveItem(Item item, bool isItemRemoved)
    {
        item.isRemoved = isItemRemoved;
        items.Remove(item);
    }

}


