using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBooks : MonoBehaviour {

    public bool isPlaySound = false;

    private PlayerManager playerManagerScript;
    private Transform player;
    
    [Header("Objects")]
	[SerializeField] private Transform bookPositionContainer;
	[SerializeField] private Transform bookshelf;
    [SerializeField] private GameObject chip;
	public List<Transform> booksList = new List<Transform>();

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource chipAudioSource;
    [SerializeField] private AudioClip takeBookSound;
    [SerializeField] private AudioClip putBookSound;
    [SerializeField] private AudioClip chipSound;

    [Header("Books states")]
    public bool isBookTaken = false;
	public bool isTaskDone = false;

    struct Book
    {
        public GameObject bookObject;
        public string bookName;
        public bool isBook;
    }

    private Book[] books;

	private Ray playerAim;
	private Camera playerCam;
    [SerializeField] private float rayLength = 4f;

	void OnEnable () {

		playerCam = Camera.main;
		player = GameObject.Find("Player").transform;
		chip.gameObject.SetActive (false);
	
	}

    void Update()
    {

        float distance = Vector3.Distance(player.position, bookshelf.position);

        CheckPlayerDistance(distance);

        if (Input.GetMouseButton(0) && isBookTaken == false && isTaskDone == false && playerManagerScript.isPlayerCanInput == true)
        {
            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9))
            {

                if (hit.collider.gameObject.name == books[0].bookName)
                {
                    TakeBook(books[0]);
                }
                else if (hit.collider.gameObject.name == books[1].bookName)
                {
                    TakeBook(books[1]);
                }
                else if (hit.collider.gameObject.name == books[2].bookName)
                {
                    TakeBook(books[2]);
                }
                else if (hit.collider.gameObject.name == books[3].bookName)
                {
                    TakeBook(books[3]);
                }
                else if (hit.collider.gameObject.name == books[4].bookName)
                {
                    TakeBook(books[4]);
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && isBookTaken == true && isTaskDone == false && playerManagerScript.isPlayerCanInput == true)
        {

            Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9))
            {
                if (hit.collider.gameObject.name == books[0].bookName)
                {
                    SwapBook(books[0]);
                }
                else if (hit.collider.gameObject.name == books[1].bookName)
                {
                    SwapBook(books[1]);
                }
                else if (hit.collider.gameObject.name == books[2].bookName)
                {
                    SwapBook(books[2]);
                }
                else if (hit.collider.gameObject.name == books[3].bookName)
                {
                    SwapBook(books[3]);
                }
                else if (hit.collider.gameObject.name == books[4].bookName)
                {
                    SwapBook(books[4]);
                }
            }
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

    void TakeBook(Book book)
    {
        booksList.Add(book.bookObject.transform);
        audioSource.PlayOneShot(takeBookSound);
        book.bookObject.gameObject.SetActive(false);
        isBookTaken = true;
    }

    void SwapBook(Book book)
    {
        bookPositionContainer.transform.position = new Vector3(booksList[0].transform.position.x, booksList[0].transform.position.y, booksList[0].transform.position.z);
        booksList[0].transform.position = new Vector3(book.bookObject.transform.position.x, book.bookObject.transform.position.y, book.bookObject.transform.position.z);
        book.bookObject.transform.position = new Vector3(bookPositionContainer.transform.position.x, bookPositionContainer.transform.position.y, bookPositionContainer.transform.position.z);
        bookPositionContainer.transform.position = new Vector3(0, 0, 0);
        audioSource.PlayOneShot(putBookSound);
        EnableBooks();
        booksList.RemoveAt(0);
        isBookTaken = false;
    }

    void CheckPlayerDistance(float _distance)
    {
        if (_distance > 11 && booksList.Count > 0)
        {
            EnableBooks();
            isBookTaken = false;
            booksList.RemoveAt(0);
        }
    }

    void EnableBooks()
    {
        foreach(var book in books)
        {
            book.bookObject.SetActive(false);
        }
    }

}
