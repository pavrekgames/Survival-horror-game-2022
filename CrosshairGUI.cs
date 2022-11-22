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

    public enum CursorState {
        DefaultTexture,
        DoorTexture,
        HandTexture,
        NoteTexture,
        PushTexture,
        SaveTexture,
        Drawers1Texture,
        Drawers2Texture,
        WardrobeTexture,
        Object1Texture,
        Object2Texture,
        Move1Texture,
        Move2Texture,
        MoveTaskTexture
    };

    public CursorState currentCursorState;

    public bool m_ShowCursor = false;

    private bool m_bIsCrosshairVisible = true;
	private Rect m_crosshairRect;
	private Ray playerAim;
	private Camera playerCam;

	void OnEnable(){

		playerCam = Camera.main;
        pushScript = GameObject.Find("Player").GetComponent<Push>();
        dragScript = GameObject.Find("Player").GetComponent<DragObject>();
        dragRigidbodyScript = GameObject.Find("Player").GetComponent<DragRigidbody>();
        openCloseObjectScript = GameObject.Find("Player").GetComponent<OpenCloseObject>();
        notesScript = GameObject.Find("Player").GetComponent<Notes>();
        healthScript = GameObject.Find("Player").GetComponent<Health>();
    }

	void  Update (){
		
		Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;

        ShowHideCursor();

		if (Physics.Raycast (playerAim, out hit, rayLength, 1 << 9) && notesScript.isNotes == false)
		{
			
			if(hit.collider.gameObject.tag == "Door" && m_ShowCursor == false)
			{
                currentCursorState = CursorState.DoorTexture;
            }

			else if(hit.collider.gameObject.tag == "Hand" && m_ShowCursor == false)
			{
                currentCursorState = CursorState.HandTexture;
            }

			else if(hit.collider.gameObject.tag == "Note" && m_ShowCursor == false)
			{
                currentCursorState = CursorState.NoteTexture;
            } 

			else if(hit.collider.gameObject.tag == "Push" && m_ShowCursor == false)
			{
                currentCursorState = CursorState.PushTexture;
            }

			else if(hit.collider.gameObject.tag == "Save" && m_ShowCursor == false)
			{
                currentCursorState = CursorState.SaveTexture;
            }

            else if (hit.collider.gameObject.tag == "Drawers1" && m_ShowCursor == false)
            {
                currentCursorState = CursorState.Drawers1Texture;
            }

            else if (hit.collider.gameObject.tag == "Drawers2" && m_ShowCursor == false)
            {
                currentCursorState = CursorState.Drawers2Texture;
            }

            else if (hit.collider.gameObject.tag == "Wardrobe" && m_ShowCursor == false)
            {
                currentCursorState = CursorState.WardrobeTexture;
            }

            else if (hit.collider.gameObject.tag == "Object1" && m_ShowCursor == false)
            {
                currentCursorState = CursorState.Object1Texture;
            }

            else if (hit.collider.gameObject.tag == "Object2" && m_ShowCursor == false)
            {
                currentCursorState = CursorState.Object2Texture;
            }

            else if (hit.collider.gameObject.tag == "Move1" && m_ShowCursor == false && healthScript.health > 0)
            {
                currentCursorState = CursorState.Move1Texture;
            }

            else if (hit.collider.gameObject.tag == "Move2" && m_ShowCursor == false && healthScript.health > 0)
            {
                currentCursorState = CursorState.Move2Texture;
            }

            else if (hit.collider.gameObject.tag == "MoveTask" && m_ShowCursor == false && healthScript.health > 0)
            {
                currentCursorState = CursorState.MoveTaskTexture;
            }

        }

        else if (notesScript.isNotes == true)
        {
            NotesEnabledCursorState();
        }

        else {
            DefaultCursorState();
        }	

    }
		
    void ShowHideCursor()
    {
        if (m_ShowCursor == true)
        {
            Cursor.visible = (true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = (false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void CheckCursorState()
    {
        switch (currentCursorState)
        {
            case CursorState.DefaultTexture:
                DefaultCursorState();
                break;
            case CursorState.DoorTexture:
                DoorCursorState();
                break;
            case CursorState.HandTexture:
                HandCursorState();
                break;
            case CursorState.NoteTexture:
                NoteCursorState();
                break;
            case CursorState.PushTexture:
                PushCursorState();
                break;
            case CursorState.SaveTexture:
                SaveCursorState();
                break;
            case CursorState.Drawers1Texture:
                Drawers1CursorState();
                break;
            case CursorState.Drawers2Texture:
                Drawers1CursorState();
                break;
            case CursorState.WardrobeTexture:
                WardrobeCursorState();
                break;
            case CursorState.Object1Texture:
                Object1CursorState();
                break;
            case CursorState.Object2Texture:
                Object1CursorState();
                break;
            case CursorState.Move1Texture:
                Move1CursorState();
                break;
            case CursorState.Move2Texture:
                Move2CursorState();
                break;
            case CursorState.MoveTaskTexture:
                MoveTaskCursorState();
                break;
        }
    }

    void DoorCursorState()
    {
        SetDefaultScriptsSettings();
        openCloseObjectScript.enabled = true;

        m_crosshairRect = new Rect((Screen.width - m_useTexture.width) / 2,
                (Screen.height - m_useTexture.height) / 2,
                m_useTexture.width,
                m_useTexture.height);
    }

    void HandCursorState()
    {
        SetDefaultScriptsSettings();

        m_crosshairRect = new Rect((Screen.width - m_useHandTexture.width) / 2,
                (Screen.height - m_useHandTexture.height) / 2,
                m_useHandTexture.width,
                m_useHandTexture.height);
    }

    void NoteCursorState()
    {
        
        SetDefaultScriptsSettings();
        m_crosshairRect = new Rect((Screen.width - m_useNoteTexture.width) / 2,
                (Screen.height - m_useNoteTexture.height) / 2,
                m_useNoteTexture.width,
                m_useNoteTexture.height);
    }

    void PushCursorState()
    {
        SetDefaultScriptsSettings();
        pushScript.enabled = true;

        m_crosshairRect = new Rect((Screen.width - m_usePushTexture.width) / 2,
                (Screen.height - m_usePushTexture.height) / 2,
                m_usePushTexture.width,
                m_usePushTexture.height);
    }

    void SaveCursorState()
    {
        SetDefaultScriptsSettings();

        m_crosshairRect = new Rect((Screen.width - m_useSaveTexture.width) / 2,
                (Screen.height - m_useSaveTexture.height) / 2,
                m_useSaveTexture.width,
                m_useSaveTexture.height);
    }

    void Drawers1CursorState()
    {  
        SetDefaultScriptsSettings();
        openCloseObjectScript.enabled = true;

        m_crosshairRect = new Rect((Screen.width - m_useDrawersTexture.width) / 2,
                (Screen.height - m_useDrawersTexture.height) / 2,
                m_useDrawersTexture.width,
                m_useDrawersTexture.height);
    }

    void Drawers2CursorState()
    {
        SetDefaultScriptsSettings();
        openCloseObjectScript.enabled = true;

        m_crosshairRect = new Rect((Screen.width - m_useDrawersTexture.width) / 2,
                (Screen.height - m_useDrawersTexture.height) / 2,
                m_useDrawersTexture.width,
                m_useDrawersTexture.height);
    }

    void WardrobeCursorState()
    {
        SetDefaultScriptsSettings();
        openCloseObjectScript.enabled = true;

        m_crosshairRect = new Rect((Screen.width - m_useWardrobeTexture.width) / 2,
                (Screen.height - m_useWardrobeTexture.height) / 2,
                m_useWardrobeTexture.width,
                m_useWardrobeTexture.height);
    }

    void Object1CursorState()
    {
        SetDefaultScriptsSettings();
        openCloseObjectScript.enabled = true;

        m_crosshairRect = new Rect((Screen.width - m_useWardrobeTexture.width) / 2,
                (Screen.height - m_useWardrobeTexture.height) / 2,
                m_useWardrobeTexture.width,
                m_useWardrobeTexture.height);
    }

    void Object2CursorState()
    {
        SetDefaultScriptsSettings();
        openCloseObjectScript.enabled = true;

        m_crosshairRect = new Rect((Screen.width - m_useWardrobeTexture.width) / 2,
                (Screen.height - m_useWardrobeTexture.height) / 2,
                m_useWardrobeTexture.width,
                m_useWardrobeTexture.height);
    }

    void Move1CursorState()
    {
        SetDefaultScriptsSettings();
        dragScript.enabled = true;

        m_crosshairRect = new Rect((Screen.width - m_useMoveTexture.width) / 2,
                (Screen.height - m_useMoveTexture.height) / 2,
                m_useMoveTexture.width,
                m_useMoveTexture.height);
    }

    void Move2CursorState()
    {
        SetDefaultScriptsSettings();
        dragRigidbodyScript.enabled = true;

        m_crosshairRect = new Rect((Screen.width - m_useMoveTexture.width) / 2,
                (Screen.height - m_useMoveTexture.height) / 2,
                m_useMoveTexture.width,
                m_useMoveTexture.height);
    }

    void MoveTaskCursorState()
    {
        SetDefaultScriptsSettings();
        dragScript.enabled = true;

        m_crosshairRect = new Rect((Screen.width - m_useMoveTexture.width) / 2,
                (Screen.height - m_useMoveTexture.height) / 2,
                m_useMoveTexture.width,
                m_useMoveTexture.height);
    }

    void NotesEnabledCursorState()
    {
        Cursor.visible = (false);
    }

    void DefaultCursorState()
    {
        SetDefaultScriptsSettings();
        m_crosshairRect = new Rect((Screen.width - m_crosshairTexture.width) / 2,
                (Screen.height - m_crosshairTexture.height) / 2,
                m_crosshairTexture.width,
                m_crosshairTexture.height);
    }

    void SetDefaultScriptsSettings()
    {
        dragRigidbodyScript.enabled = false;
        openCloseObjectScript.enabled = false;
        pushScript.DefaultSettings();
        pushScript.enabled = false;
    }

 /*   void  OnGUI (){
		if(m_bIsCrosshairVisible)
		if(m_DefaultTexture){
			GUI.DrawTexture(m_crosshairRect, m_crosshairTexture);
		}
		if(m_DoorTexture){
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

        if (m_Object1Texture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useWardrobeTexture);
        }

        if (m_Object2Texture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useWardrobeTexture);
        }

        if (m_Move1Texture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useMoveTexture);
        }

        if (m_Move2Texture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useMoveTexture);
        }

        if (m_MoveTaskTexture)
        {
            GUI.DrawTexture(m_crosshairRect, m_useMoveTexture);
        }

    } */

	void OnEnabled(){
		m_ShowCursor = false;
	}
		

}