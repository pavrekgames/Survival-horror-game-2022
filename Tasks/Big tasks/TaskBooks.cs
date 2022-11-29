using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBooks : MonoBehaviour {

	private Menu gameMenuScript;
	private Inventory inventoryScript;
    public bool isPlaySound = false;

    private Transform player;
	private Transform butterflyBook;
	private Transform waterBook;
	private Transform computerBook;
	private Transform spaceBook;
	private Transform skyBook;
	private Transform bookPositionContainer;
	private Transform bookshelf;
	public GameObject chip;
	public List<Transform> booksList = new List<Transform>();
	public bool isBookTaken = false;
	public AudioSource audioSource;
	public AudioSource chipAudioSource;
	public AudioClip takeBookSound;
	public AudioClip putBookSound;
	public AudioClip chipSound;
	public bool isButterflyBook = false;
	public bool isWaterBook = false;
	public bool isComputerBook = false;
	public bool isSpaceBook = false;
	public bool isSkyBook = false;
	public bool isTaskDone = false;

	private Ray playerAim;
	private Camera playerCam;
	public float rayLength = 4f;

	void OnEnable () {

		playerCam = Camera.main;

		player = GameObject.Find("Player").transform;
		butterflyBook = GameObject.Find("Ksiazka_motyl").transform;
		waterBook = GameObject.Find("Ksiazka_woda").transform;
		computerBook = GameObject.Find("Ksiazka_komputer").transform;
		spaceBook = GameObject.Find("Ksiazka_kosmos").transform;
		skyBook = GameObject.Find("Ksiazka_niebo").transform;
		bookPositionContainer = GameObject.Find("Podklad").transform;
		bookshelf = GameObject.Find("Biblioteka_Ksiazki").transform;
		gameMenuScript = GameObject.Find ("CanvasMenu").GetComponent<Menu> ();
		inventoryScript = GameObject.Find ("Player").GetComponent<Inventory> ();

		chip = GameObject.Find ("ChipO").gameObject;
		chip.gameObject.SetActive (false);
		audioSource = GameObject.Find ("ZrodloPrzedmiot3_s").GetComponent<AudioSource> ();
		chipAudioSource = GameObject.Find ("Chip_s").GetComponent<AudioSource> ();
		//DzwKsiazki = Resources.Load<AudioClip>("Muzyka/Ksiazka1");
		//DzwKsiazki2 = Resources.Load<AudioClip>("Muzyka/Ksiazka2");
		//DzwChip = Resources.Load<AudioClip>("Muzyka/Kaseta");
	}
	

	void Update () {

		//playerCam = Camera.main;
		Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit; 

		float Dystans = Vector3.Distance(player.position, bookshelf.position);

		if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)){
			//Debug.Log(hit.collider.gameObject.name);
			if(hit.collider.gameObject.name == "Ksiazka_motyl" && Input.GetMouseButton(0) && isBookTaken == false && isTaskDone == false && booksList.Count == 0 && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1)
            {
				booksList.Add(butterflyBook);
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(takeBookSound);
				butterflyBook.gameObject.SetActive(false);
				isBookTaken = true;
			} else if(hit.collider.gameObject.name == "Ksiazka_motyl" && Input.GetMouseButtonUp(0) && isBookTaken == true && isTaskDone == false && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1)
            {
				bookPositionContainer.transform.position = new Vector3(booksList[0].transform.position.x, booksList[0].transform.position.y, booksList[0].transform.position.z);
				booksList[0].transform.position = new Vector3(butterflyBook.transform.position.x, butterflyBook.transform.position.y, butterflyBook.transform.position.z);
				butterflyBook.transform.position = new Vector3(bookPositionContainer.transform.position.x, bookPositionContainer.transform.position.y, bookPositionContainer.transform.position.z);
				bookPositionContainer.transform.position = new Vector3(0,0,0);
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(putBookSound);
				butterflyBook.gameObject.SetActive(true);
				waterBook.gameObject.SetActive(true);
				computerBook.gameObject.SetActive(true);
				spaceBook.gameObject.SetActive(true);
				skyBook.gameObject.SetActive(true);
				booksList.RemoveAt(0);
				isBookTaken = false;
			}
		}

		if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)){
			if(hit.collider.gameObject.name == "Ksiazka_woda" && Input.GetMouseButton(0) && isBookTaken == false && isTaskDone == false && booksList.Count == 0 && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1)
            {
				booksList.Add(waterBook);
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(takeBookSound);
				waterBook.gameObject.SetActive(false);
				isBookTaken = true;
			} else if(hit.collider.gameObject.name == "Ksiazka_woda" && Input.GetMouseButtonUp(0) && isBookTaken == true && isTaskDone == false && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1)
            {
				bookPositionContainer.transform.position = new Vector3(booksList[0].transform.position.x, booksList[0].transform.position.y, booksList[0].transform.position.z);
				booksList[0].transform.position = new Vector3(waterBook.transform.position.x, waterBook.transform.position.y, waterBook.transform.position.z);
				waterBook.transform.position = new Vector3(bookPositionContainer.transform.position.x, bookPositionContainer.transform.position.y, bookPositionContainer.transform.position.z);
				bookPositionContainer.transform.position = new Vector3(0,0,0);
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(putBookSound);
				butterflyBook.gameObject.SetActive(true);
				waterBook.gameObject.SetActive(true);
				computerBook.gameObject.SetActive(true);
				spaceBook.gameObject.SetActive(true);
				skyBook.gameObject.SetActive(true);
				booksList.RemoveAt(0);
				isBookTaken = false;
			}
		}

		if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)){
			if(hit.collider.gameObject.name == "Ksiazka_komputer" && Input.GetMouseButton(0) && isBookTaken == false && isTaskDone == false && booksList.Count == 0 && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1)
            {
				booksList.Add(computerBook);
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(takeBookSound);
				computerBook.gameObject.SetActive(false);
				isBookTaken = true;
			} else 	if(hit.collider.gameObject.name == "Ksiazka_komputer" && Input.GetMouseButtonUp(0) && isBookTaken == true && isTaskDone == false && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1)
            {
				bookPositionContainer.transform.position = new Vector3(booksList[0].transform.position.x, booksList[0].transform.position.y, booksList[0].transform.position.z);
				booksList[0].transform.position = new Vector3(computerBook.transform.position.x, computerBook.transform.position.y, computerBook.transform.position.z);
				computerBook.transform.position = new Vector3(bookPositionContainer.transform.position.x, bookPositionContainer.transform.position.y, bookPositionContainer.transform.position.z);
				bookPositionContainer.transform.position = new Vector3(0,0,0);
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(putBookSound);
				butterflyBook.gameObject.SetActive(true);
				waterBook.gameObject.SetActive(true);
				computerBook.gameObject.SetActive(true);
				spaceBook.gameObject.SetActive(true);
				skyBook.gameObject.SetActive(true);
				booksList.RemoveAt(0);
				isBookTaken = false;
			}
		}

		if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)){
			if(hit.collider.gameObject.name == "Ksiazka_kosmos" && Input.GetMouseButton(0) && isBookTaken == false && isTaskDone == false && booksList.Count == 0 && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1)
            {
				booksList.Add(spaceBook);
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(takeBookSound);
				spaceBook.gameObject.SetActive(false);
				isBookTaken = true;
			} else if(hit.collider.gameObject.name == "Ksiazka_kosmos" && Input.GetMouseButtonUp(0) && isBookTaken == true && isTaskDone == false && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1)
            {
				bookPositionContainer.transform.position = new Vector3(booksList[0].transform.position.x, booksList[0].transform.position.y, booksList[0].transform.position.z);
				booksList[0].transform.position = new Vector3(spaceBook.transform.position.x, spaceBook.transform.position.y, spaceBook.transform.position.z);
				spaceBook.transform.position = new Vector3(bookPositionContainer.transform.position.x, bookPositionContainer.transform.position.y, bookPositionContainer.transform.position.z);
				bookPositionContainer.transform.position = new Vector3(0,0,0);
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(putBookSound);
				butterflyBook.gameObject.SetActive(true);
				waterBook.gameObject.SetActive(true);
				computerBook.gameObject.SetActive(true);
				spaceBook.gameObject.SetActive(true);
				skyBook.gameObject.SetActive(true);
				booksList.RemoveAt(0);
				isBookTaken = false;
			}
		}

		if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9)){
			if(hit.collider.gameObject.name == "Ksiazka_niebo" && Input.GetMouseButton(0) && isBookTaken == false && isTaskDone == false && booksList.Count == 0 && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1)
            {
				booksList.Add(skyBook);
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(takeBookSound);
				skyBook.gameObject.SetActive(false);
				isBookTaken = true;
			} else if(hit.collider.gameObject.name == "Ksiazka_niebo" && Input.GetMouseButtonUp(0) && isBookTaken == true && isTaskDone == false && inventoryScript.isInventoryActive == false && inventoryScript.isTasksActive == false && inventoryScript.isNotesActive == false && gameMenuScript.isMenu == false && inventoryScript.isTreatmentActive == false && inventoryScript.isCollectionActive == false && Time.timeScale == 1)
            {
				bookPositionContainer.transform.position = new Vector3(booksList[0].transform.position.x, booksList[0].transform.position.y, booksList[0].transform.position.z);
				booksList[0].transform.position = new Vector3(skyBook.transform.position.x, skyBook.transform.position.y, skyBook.transform.position.z);
				skyBook.transform.position = new Vector3(bookPositionContainer.transform.position.x, bookPositionContainer.transform.position.y, bookPositionContainer.transform.position.z);
				bookPositionContainer.transform.position = new Vector3(0,0,0);
				audioSource = audioSource.GetComponent<AudioSource>();
				audioSource.PlayOneShot(putBookSound);
				butterflyBook.gameObject.SetActive(true);
				waterBook.gameObject.SetActive(true);
				computerBook.gameObject.SetActive(true);
				spaceBook.gameObject.SetActive(true);
				skyBook.gameObject.SetActive(true);
				booksList.RemoveAt(0);
				isBookTaken = false;
			}
		} 

		// Ksiazki w odpowiedniej kolejnosci

		if(isButterflyBook == true && isWaterBook == true && isComputerBook == true && isSpaceBook == true && isSkyBook == true && isTaskDone == false){
            chipAudioSource.clip = chipSound;		
			chipAudioSource.Play();
			chip.SetActive(true);
			isTaskDone = true;
		}

		// Oddalenie od zadania

		if(Dystans > 11 && booksList.Count > 0){
			butterflyBook.gameObject.SetActive(true);
			waterBook.gameObject.SetActive(true);
			computerBook.gameObject.SetActive(true);
			spaceBook.gameObject.SetActive(true);
			skyBook.gameObject.SetActive(true);
			isBookTaken = false;
			booksList.RemoveAt(0);
		}

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isPlaySound == false)
        {

            chipAudioSource.Pause();
            

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && isPlaySound == true)
        {

            chipAudioSource.UnPause();
            

            isPlaySound = false;
        }



    }

}
