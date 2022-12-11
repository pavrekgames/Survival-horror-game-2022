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
    private NotificationUI notificationUIScript;
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
    public event Action OnAddedItem;
    public event Action OnRemovedItem;

	void OnEnable(){

        playerCam = Camera.main;
        playerManagerScript = GameObject.Find("Player").GetComponent<PlayerManager>();
		cursorScript = GameObject.Find ("PlayerCamera").GetComponent<CrosshairGUI>();
		playerScript = GameObject.Find ("Player").GetComponent<Player>();
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu>();
		animator = GameObject.Find ("Player").GetComponent<Animator>();
		notificationUIScript = GameObject.Find ("CanvasKomunikaty").GetComponent<NotificationUI>();
		itemAudioSource = GameObject.Find ("ZrodloPrzedmiot_s").GetComponent<AudioSource>();
        inventoryUIScript = GameObject.Find("CanvasInventory").GetComponent<InventoryUI>();

    }

    void Update()
    {
        InventoryInput();
        PickUpItem();
    }

    void InventoryInput()
    {
        if (Input.GetButtonUp("Inventory") && playerManagerScript.isPlayerCanInput == true)
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

                if (hit.collider.gameObject.tag == "Hand")
                {
                    IItem item = hit.transform.GetComponent<IItem>() as IItem;
                    if (item != null)
                    {
                        item.PickUpItem();
                    }
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
        item.id = items.Count;

        if(OnAddedItem != null)
        {
            OnAddedItem.Invoke();
        }
    }

    public void AddCollectibleItem(AudioSource audioSource, AudioClip itemSound, int itemsCount, NotificationType notificationType)
    {
        audioSource.PlayOneShot(itemSound);
        itemsCount++;
        notificationUIScript.notificationType = notificationType;
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

        if (OnRemovedItem != null)
        {
            OnRemovedItem.Invoke();
        }

    }

}


