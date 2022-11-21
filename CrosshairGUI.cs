using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

public class CrosshairGUI : MonoBehaviour {

    private Push pushScript;
    private DragObject dragScript;
    private DragRigidbody dragRigidbodyScript;
    private OpenCloseObject openCloseObjectScript;
    private Notes notesScript;
    private Health healthScript;

    public Texture2D m_crosshairTexture;
	public Texture2D m_useTexture;
	public Texture2D m_useHandTexture;
	public Texture2D m_useNoteTexture;
	public Texture2D m_usePushTexture;
	public Texture2D m_useSaveTexture;
    public Texture2D m_useDrawersTexture;
    public Texture2D m_useWardrobeTexture;
    public Texture2D m_useMoveTexture;
    public float rayLength = 3f;

	public bool m_DefaultReticle;
	public bool m_UseReticle;
	public bool m_ShowCursor = false;
	public bool m_HandTexture;
	public bool m_NoteTexture;
	public bool m_PushTexture;
	public bool m_SaveTexture;
    public bool m_Drawers1Texture;
    public bool m_Drawers2Texture;
    public bool m_WardrobeTexture;
    public bool m_ObjectTexture;
    public bool m_Object2Texture;
    public bool m_MoveTexture;
    public bool m_Move2Texture;
    public bool m_MoveZadTexture;

    private bool m_bIsCrosshairVisible = true;
	private Rect m_crosshairRect;
	private Ray playerAim;
	public Camera playerCam;

	void OnEnable(){

		playerCam = Camera.main;
        pushScript = GameObject.Find("Player").GetComponent<Push>();
        dragScript = GameObject.Find("Player").GetComponent<DragObject>();
        dragRigidbodyScript = GameObject.Find("Player").GetComponent<DragRigidbody>();
        openCloseObjectScript = GameObject.Find("Player").GetComponent<OpenCloseObject>();
        notesScript = GameObject.Find("Player").GetComponent<Notes>();
        healthScript = GameObject.Find("Player").GetComponent<Health>();
        //playerAim = playerCam.GetComponent<Camera> ();
    }

	void  Update (){
		
		//playerCam = Camera.main;
		//Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;

      /*  if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(playerAim, out hit, RayLength))
            {
                Debug.Log(hit.transform.gameObject.name);
            }

        } */

		if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9) && notesScript.isNotes == false)
		{
			if(hit.collider.gameObject.tag == "Interact")
			{
				m_DefaultReticle = false;
				m_UseReticle = true;
				m_HandTexture = false;
				m_NoteTexture = false;
				m_PushTexture = false;
				m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = false;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }
			if(hit.collider.gameObject.tag == "InteractItem")
			{
				m_DefaultReticle = false;
				m_UseReticle = true;
				m_HandTexture = false;
				m_NoteTexture = false;
				m_PushTexture = false;
				m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = false;

               // SkryptDrag.Przywroc();
               // SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }
			if(hit.collider.gameObject.tag == "Door" && m_ShowCursor == false)
			{
				m_DefaultReticle = false;
				m_UseReticle = true;
				m_HandTexture = false;
				m_NoteTexture = false;
				m_PushTexture = false;
				m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = true;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }

			else if(hit.collider.gameObject.tag == "Hand" && m_ShowCursor == false)
			{
				m_DefaultReticle = false;
				m_UseReticle = false;
				m_HandTexture = true;
				m_NoteTexture = false;
				m_PushTexture = false;
				m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = false;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }

			else if(hit.collider.gameObject.tag == "Note" && m_ShowCursor == false)
			{
				m_DefaultReticle = false;
				m_UseReticle = false;
				m_HandTexture = false;
				m_NoteTexture = true;
				m_PushTexture = false;
				m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = false;

               // SkryptDrag.Przywroc();
               // SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            } 

			else if(hit.collider.gameObject.tag == "Push" && m_ShowCursor == false)
			{
				m_DefaultReticle = false;
				m_UseReticle = false;
				m_HandTexture = false;
				m_NoteTexture = false;
				m_PushTexture = true;
				m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                pushScript.enabled = true;
                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = false;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;
            }

			else if(hit.collider.gameObject.tag == "Zapis" && m_ShowCursor == false)
			{
				m_DefaultReticle = false;
				m_UseReticle = false;
				m_HandTexture = false;
				m_NoteTexture = false;
				m_PushTexture = false;
				m_SaveTexture = true;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = false;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }

            else if (hit.collider.gameObject.tag == "Drawers1" && m_ShowCursor == false)
            {
                m_DefaultReticle = false;
                m_UseReticle = false;
                m_HandTexture = false;
                m_NoteTexture = false;
                m_PushTexture = false;
                m_SaveTexture = false;
                m_Drawers1Texture = true;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = true;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;
            }

            else if (hit.collider.gameObject.tag == "Drawers2" && m_ShowCursor == false)
            {
                m_DefaultReticle = false;
                m_UseReticle = false;
                m_HandTexture = false;
                m_NoteTexture = false;
                m_PushTexture = false;
                m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = true;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = true;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }

            else if (hit.collider.gameObject.tag == "Szafka" && m_ShowCursor == false)
            {
                m_DefaultReticle = false;
                m_UseReticle = false;
                m_HandTexture = false;
                m_NoteTexture = false;
                m_PushTexture = false;
                m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = true;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = true;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }

            else if (hit.collider.gameObject.tag == "Obiekt" && m_ShowCursor == false)
            {
                m_DefaultReticle = false;
                m_UseReticle = false;
                m_HandTexture = false;
                m_NoteTexture = false;
                m_PushTexture = false;
                m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = true;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = true;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }

            else if (hit.collider.gameObject.tag == "Obiekt2" && m_ShowCursor == false)
            {
                m_DefaultReticle = false;
                m_UseReticle = false;
                m_HandTexture = false;
                m_NoteTexture = false;
                m_PushTexture = false;
                m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = true;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = true;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }

            else if (hit.collider.gameObject.tag == "Move" && m_ShowCursor == false && healthScript.health > 0)
            {
                m_DefaultReticle = false;
                m_UseReticle = false;
                m_HandTexture = false;
                m_NoteTexture = false;
                m_PushTexture = false;
                m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = true;
                m_Move2Texture = false;
                m_MoveZadTexture = false;

                dragScript.enabled = true;
                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }

            else if (hit.collider.gameObject.tag == "Move2" && m_ShowCursor == false && healthScript.health > 0)
            {
                m_DefaultReticle = false;
                m_UseReticle = false;
                m_HandTexture = false;
                m_NoteTexture = false;
                m_PushTexture = false;
                m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = true;
                m_MoveZadTexture = false;

                dragRigidbodyScript.enabled = true;
               // SkryptDrag.enabled = false;
                openCloseObjectScript.enabled = false;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }

            else if (hit.collider.gameObject.tag == "MoveZad" && m_ShowCursor == false && healthScript.health > 0)
            {
                m_DefaultReticle = false;
                m_UseReticle = false;
                m_HandTexture = false;
                m_NoteTexture = false;
                m_PushTexture = false;
                m_SaveTexture = false;
                m_Drawers1Texture = false;
                m_Drawers2Texture = false;
                m_WardrobeTexture = false;
                m_ObjectTexture = false;
                m_Object2Texture = false;
                m_MoveTexture = false;
                m_Move2Texture = false;
                m_MoveZadTexture = true;

                dragScript.enabled = true;
                dragRigidbodyScript.enabled = false;
                openCloseObjectScript.enabled = false;

                //SkryptDrag.Przywroc();
                //SkryptDrag.enabled = false;

                pushScript.DefaultSettings();
                pushScript.enabled = false;

            }

            //else if(hit.collider.gameObject.tag != "Note" || hit.collider.gameObject.tag != "Hand" || hit.collider.gameObject.tag != "Door"){
            //	m_DefaultReticle = true;
            //	m_UseReticle = false;
            //	m_HandTexture = false;
            //m_NoteTexture = false;
            //}

        }

        else if (notesScript.isNotes == true)
        {
            m_DefaultReticle = false;
            m_UseReticle = false;
            m_HandTexture = false;
            m_NoteTexture = false;
            m_PushTexture = false;
            m_SaveTexture = false;
            m_Drawers1Texture = false;
            m_Drawers2Texture = false;
            m_WardrobeTexture = false;
            m_ObjectTexture = false;
            m_Object2Texture = false;
            m_MoveTexture = false;
            m_Move2Texture = false;
            m_MoveZadTexture = false;
            Cursor.visible = (false);

        }

        else {
			m_DefaultReticle = true;
			m_UseReticle = false;
			m_HandTexture = false;
			m_NoteTexture = false;
			m_PushTexture = false;
			m_SaveTexture = false;
            m_Drawers1Texture = false;
            m_Drawers2Texture = false;
            m_WardrobeTexture = false;
            m_ObjectTexture = false;
            m_Object2Texture = false;
            m_MoveTexture = false;
            m_Move2Texture = false;
            m_MoveZadTexture = false;

            dragRigidbodyScript.enabled = false;

            //SkryptDrag.Przywroc();
            //SkryptDrag.enabled = false;

            pushScript.DefaultSettings();
            pushScript.enabled = false;

        }
			

		if(m_ShowCursor == true){
			m_DefaultReticle = false;
			m_UseReticle = false;
			m_HandTexture = false;
			m_NoteTexture = false;
			m_PushTexture = false;
			m_SaveTexture = false;
            m_Drawers1Texture = false;
            m_Drawers2Texture = false;
            m_WardrobeTexture = false;
            m_ObjectTexture = false;
            m_Object2Texture = false;
            m_MoveTexture = false;
            m_Move2Texture = false;
            m_MoveZadTexture = false;
            Cursor.visible = (true);
			Cursor.lockState = CursorLockMode.None;	
		}else{
			Cursor.visible = (false);
			Cursor.lockState = CursorLockMode.Locked;						
		}

		if(m_DefaultReticle){
			m_crosshairRect = new Rect((Screen.width - m_crosshairTexture.width) / 2, 
				(Screen.height - m_crosshairTexture.height) / 2, 
				m_crosshairTexture.width, 
				m_crosshairTexture.height);
		}

		if(m_UseReticle){
			m_crosshairRect = new Rect((Screen.width - m_useTexture.width) / 2, 
				(Screen.height - m_useTexture.height) / 2, 
				m_useTexture.width, 
				m_useTexture.height);
		}

		if(m_HandTexture){
			m_crosshairRect = new Rect((Screen.width - m_useHandTexture.width) / 2, 
				(Screen.height - m_useHandTexture.height) / 2, 
				m_useHandTexture.width, 
				m_useHandTexture.height);
		}

		if(m_NoteTexture){
			m_crosshairRect = new Rect((Screen.width - m_useNoteTexture.width) / 2, 
				(Screen.height - m_useNoteTexture.height) / 2, 
				m_useNoteTexture.width, 
				m_useNoteTexture.height);
		}

		if(m_PushTexture){
			m_crosshairRect = new Rect((Screen.width - m_usePushTexture.width) / 2, 
				(Screen.height - m_usePushTexture.height) / 2, 
				m_usePushTexture.width, 
				m_usePushTexture.height);
		}

		if(m_SaveTexture){
			m_crosshairRect = new Rect((Screen.width - m_useSaveTexture.width) / 2, 
				(Screen.height - m_useSaveTexture.height) / 2, 
				m_useSaveTexture.width, 
				m_useSaveTexture.height);
		}

        if (m_Drawers1Texture)
        {
            m_crosshairRect = new Rect((Screen.width - m_useDrawersTexture.width) / 2,
                (Screen.height - m_useDrawersTexture.height) / 2,
                m_useDrawersTexture.width,
                m_useDrawersTexture.height);
        }

        if (m_Drawers2Texture)
        {
            m_crosshairRect = new Rect((Screen.width - m_useDrawersTexture.width) / 2,
                (Screen.height - m_useDrawersTexture.height) / 2,
                m_useDrawersTexture.width,
                m_useDrawersTexture.height);
        }

        if (m_WardrobeTexture)
        {
            m_crosshairRect = new Rect((Screen.width - m_useWardrobeTexture.width) / 2,
                (Screen.height - m_useWardrobeTexture.height) / 2,
                m_useWardrobeTexture.width,
                m_useWardrobeTexture.height);
        }

        if (m_ObjectTexture)
        {
            m_crosshairRect = new Rect((Screen.width - m_useWardrobeTexture.width) / 2,
                (Screen.height - m_useWardrobeTexture.height) / 2,
                m_useWardrobeTexture.width,
                m_useWardrobeTexture.height);
        }

        if (m_Object2Texture)
        {
            m_crosshairRect = new Rect((Screen.width - m_useWardrobeTexture.width) / 2,
                (Screen.height - m_useWardrobeTexture.height) / 2,
                m_useWardrobeTexture.width,
                m_useWardrobeTexture.height);
        }

        if (m_MoveTexture)
        {
            m_crosshairRect = new Rect((Screen.width - m_useMoveTexture.width) / 2,
                (Screen.height - m_useMoveTexture.height) / 2,
                m_useMoveTexture.width,
                m_useMoveTexture.height);
        }

        if (m_Move2Texture)
        {
            m_crosshairRect = new Rect((Screen.width - m_useMoveTexture.width) / 2,
                (Screen.height - m_useMoveTexture.height) / 2,
                m_useMoveTexture.width,
                m_useMoveTexture.height);
        }

        if (m_MoveZadTexture)
        {
            m_crosshairRect = new Rect((Screen.width - m_useMoveTexture.width) / 2,
                (Screen.height - m_useMoveTexture.height) / 2,
                m_useMoveTexture.width,
                m_useMoveTexture.height);
        }

    }
		

	void  OnGUI (){
		if(m_bIsCrosshairVisible)
		if(m_DefaultReticle){
			GUI.DrawTexture(m_crosshairRect, m_crosshairTexture);
		}
		if(m_UseReticle){
			GUI.DrawTexture(m_crosshairRect, m_useTexture);
		}

		if(m_HandTexture){
			GUI.DrawTexture(m_crosshairRect, m_useHandTexture);
		}

		if(m_NoteTexture){
			GUI.DrawTexture(m_crosshairRect, m_useNoteTexture);
		}

		if(m_PushTexture){
			GUI.DrawTexture(m_crosshairRect, m_usePushTexture);
		}

		if(m_SaveTexture){
			GUI.DrawTexture(m_crosshairRect, m_useSaveTexture);
		}

        if (m_Drawers1Texture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useDrawersTexture);
        }

        if (m_Drawers2Texture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useDrawersTexture);
        }

        if (m_WardrobeTexture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useWardrobeTexture);
        }

        if (m_ObjectTexture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useWardrobeTexture);
        }

        if (m_Object2Texture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useWardrobeTexture);
        }

        if (m_MoveTexture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useMoveTexture);
        }

        if (m_Move2Texture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useMoveTexture);
        }

        if (m_MoveZadTexture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useMoveTexture);
        }

    }

	void OnEnabled(){
		m_ShowCursor = false;
	}
		

}