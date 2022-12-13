using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map : MonoBehaviour
{

    private PlayerManager playerManagerScript;
    public Canvas mapCanvas;
    public RectTransform resolutionRect;
    public bool isMap = false;
    private AudioSource audioSource;
    private AudioClip mapSound;
    public Camera mapCamera;
    private Transform player;
    private Player playerScript;
    private StraszakScarecrow scarecrowJumpscareScript;

    private RectTransform wholeMapRect;
    private RectTransform pointerRect;

    private Camera playerCam;
    private CrosshairGUI cursorScript;

    public bool isFastTravel = true;

    void OnEnable()
    {
        playerCam = Camera.main;
        player = GameObject.Find("Player").transform;
        playerManagerScript = player.GetComponent<PlayerManager>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        scarecrowJumpscareScript = GameObject.Find("Player").GetComponent<StraszakScarecrow>();
        mapCanvas = GameObject.Find("CanvasMap").GetComponent<Canvas>();
        resolutionRect = GameObject.Find("CanvasNotifications").GetComponent<RectTransform>();
        pointerRect = GameObject.Find("PlayerPointer").GetComponent<RectTransform>();
        wholeMapRect = mapCanvas.GetComponent<RectTransform>();

        audioSource = GameObject.Find("AudioSurce_Map").GetComponent<AudioSource>();
        mapCamera = GameObject.Find("MapCamera").GetComponent<Camera>();

        cursorScript = GameObject.Find("PlayerCamera").GetComponent<CrosshairGUI>();

        SetPointer();

        mapCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Map") && isMap == false && playerManagerScript.isPlayerCanInput == true)
        {
            ShowMap();
        }
        else if ((Input.GetButtonDown("Map") || Input.GetButtonDown("Cancel")) && isMap == true)
        {
            HideMap();
        }
    }

    void ShowMap()
    {
        mapCanvas.enabled = true;
        isMap = true;
        playerScript.enabled = false;
        Time.timeScale = 0;
        mapCamera.gameObject.SetActive(true);
        audioSource.PlayOneShot(mapSound);
        SetPointer();
        cursorScript.m_ShowCursor = true;
        Cursor.visible = true;
    }

    public void HideMap()
    {
        mapCanvas.enabled = false;
        isMap = false;
        playerScript.enabled = true;
        Time.timeScale = 1;
        mapCamera.gameObject.SetActive(false);
        Cursor.visible = true;
        audioSource.PlayOneShot(mapSound);
        cursorScript.m_ShowCursor = false;
        Cursor.visible = false;
    }

    void SetPointer()
    {
        Vector2 position = mapCamera.WorldToViewportPoint(player.transform.position);

        Vector2 mapPosition = new Vector2(
        ((position.x * resolutionRect.sizeDelta.x) - (resolutionRect.sizeDelta.x * 0.5f)),
        ((position.y * resolutionRect.sizeDelta.y) - (resolutionRect.sizeDelta.y * 0.5f)));

        pointerRect.anchoredPosition = mapPosition;

        Vector3 playerRotation = player.eulerAngles;
        playerRotation = new Vector3(0, 0, 360 - playerRotation.y);
        pointerRect.localRotation = Quaternion.Euler(playerRotation);
    }
}
