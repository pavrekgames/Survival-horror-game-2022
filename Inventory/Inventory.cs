using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour {

    private PlayerManager playerManagerScript;
    private Animator animator;
    private CrosshairGUI cursorScript;
    private Player playerScript;
    private Menu gameMenuScript;
    private Notifications notificationScript;
    private InventoryUI inventoryUIScript;

    [Header("Inventory components")]
    [SerializeField] private AudioSource itemAudioSource;
    [SerializeField] private AudioSource pauseAudioSource;
    [SerializeField] private AudioClip openInventorySound;
    [SerializeField] private float rayLength = 4f;
    private Ray playerAim;
    private Camera playerCam;

    public List<Item> items = new List<Item>();

    [Header("Collectible items counts")]
    public int secretItemsCount = 0;
    public int secretPlacesCount = 0;
    public int blueHerbsCount = 0;
    public int greenHerbsCount = 0;
    public int healthPotsCount = 0;
    public int staminaPotsCount = 0;
    public int vialsCount = 0;

    [Header("Steam achievements")]
    public int badgesCount = 0;
    public int tipsCount = 0;
    public int photosCount = 0;
    public int skillsCount = 0;

    public event Action OnAddedCollectibleItem;

	void OnEnable(){

        playerCam = Camera.main;
        playerManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
		cursorScript = GameObject.Find ("PlayerCamera").GetComponent<CrosshairGUI>();
		playerScript = GameObject.Find ("Player").GetComponent<Player>();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu>();
		animator = GameObject.Find ("Player").GetComponent<Animator>();
		notificationScript = GameObject.Find ("Player").GetComponent<Notifications>();
		itemAudioSource = GameObject.Find ("ZrodloPrzedmiot_s").GetComponent<AudioSource>();  

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
        inventoryUIScript.ShowInventory();
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
        itemAudioSource.PlayOneShot(pickUpSound);

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


