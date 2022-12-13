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
    public Texture2D m_doorTexture;
    public Texture2D m_useHandTexture;
    public Texture2D m_useNoteTexture;
    public Texture2D m_usePushTexture;
    public Texture2D m_useSaveTexture;
    public Texture2D m_useDrawersTexture;
    public Texture2D m_useWardrobeTexture;
    public Texture2D m_useMoveTexture;

    public CursorState currentCursorState;

    public bool m_ShowCursor = false;

    private bool m_bIsCrosshairVisible = true;
    private Rect m_crosshairRect;

    [SerializeField] private float rayLength = 3f;
    private Camera playerCam;

    void OnEnable()
    {
        playerCam = Camera.main;
        pushScript = GameObject.Find("Player").GetComponent<Push>();
        dragScript = GameObject.Find("Player").GetComponent<DragObject>();
        dragRigidbodyScript = GameObject.Find("Player").GetComponent<DragRigidbody>();
        openCloseObjectScript = GameObject.Find("Player").GetComponent<OpenCloseObject>();
        notesScript = GameObject.Find("Player").GetComponent<Notes>();
        healthScript = GameObject.Find("Player").GetComponent<Health>();
    }

    void Update()
    {
        ShowHideCursor();
        SetCursorState();
        SetCursorTexture();
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

    void SetCursorState()
    {
        Ray playerAim = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(playerAim, out hit, rayLength, 1 << 9) && notesScript.isNotes == false)
        {
            if (hit.collider.gameObject.tag == "Door" && m_ShowCursor == false)
            {
                currentCursorState = CursorState.DoorTexture;
            }
            else if (hit.collider.gameObject.tag == "Hand" && m_ShowCursor == false)
            {
                currentCursorState = CursorState.HandTexture;
            }
            else if (hit.collider.gameObject.tag == "Note" && m_ShowCursor == false)
            {
                currentCursorState = CursorState.NoteTexture;
            }
            else if (hit.collider.gameObject.tag == "Push" && m_ShowCursor == false)
            {
                currentCursorState = CursorState.PushTexture;
            }
            else if (hit.collider.gameObject.tag == "Save" && m_ShowCursor == false)
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
            HideCursorDuringNotes();
        }
        else
        {
            currentCursorState = CursorState.DefaultTexture;
        }
    }

    void SetCursorTexture()
    {
        switch (currentCursorState)
        {
            case CursorState.DefaultTexture:
                DefaultCursorTexture();
                break;
            case CursorState.DoorTexture:
                DoorCursorTexture();
                break;
            case CursorState.HandTexture:
                HandCursorTexture();
                break;
            case CursorState.NoteTexture:
                NoteCursorTexture();
                break;
            case CursorState.PushTexture:
                PushCursorTexture();
                break;
            case CursorState.SaveTexture:
                SaveCursorTexture();
                break;
            case CursorState.Drawers1Texture:
                Drawers1CursorTexture();
                break;
            case CursorState.Drawers2Texture:
                Drawers2CursorTexture();
                break;
            case CursorState.WardrobeTexture:
                WardrobeCursorTexture();
                break;
            case CursorState.Object1Texture:
                Object1CursorTexture();
                break;
            case CursorState.Object2Texture:
                Object2CursorTexture();
                break;
            case CursorState.Move1Texture:
                Move1CursorTexture();
                break;
            case CursorState.Move2Texture:
                Move2CursorTexture();
                break;
            case CursorState.MoveTaskTexture:
                MoveTaskCursorTexture();
                break;
        }
    }

    void DoorCursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_doorTexture);
        openCloseObjectScript.enabled = true;
    }

    void HandCursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useHandTexture);
    }

    void NoteCursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useNoteTexture);
    }

    void PushCursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_usePushTexture);
        pushScript.enabled = true;
    }

    void SaveCursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useSaveTexture);
    }

    void Drawers1CursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useDrawersTexture);
        openCloseObjectScript.enabled = true;
    }

    void Drawers2CursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useDrawersTexture);
        openCloseObjectScript.enabled = true;
    }

    void WardrobeCursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useWardrobeTexture);
        openCloseObjectScript.enabled = true;
    }

    void Object1CursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useWardrobeTexture);
        openCloseObjectScript.enabled = true;
    }

    void Object2CursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useWardrobeTexture);
        openCloseObjectScript.enabled = true;
    }

    void Move1CursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useMoveTexture);
        dragScript.enabled = true;
    }

    void Move2CursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useMoveTexture);
        dragRigidbodyScript.enabled = true;
    }

    void MoveTaskCursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_useMoveTexture);
        dragScript.enabled = true;
    }

    void HideCursorDuringNotes()
    {
        Cursor.visible = (false);
    }

    void DefaultCursorTexture()
    {
        SetDefaultScriptsSettings();
        SetCrosshairRect(m_crosshairTexture);
    }

    void SetCrosshairRect(Texture2D texture)
    {
        m_crosshairRect = new Rect((Screen.width - texture.width) / 2,
                (Screen.height - texture.height) / 2,
                texture.width,
                texture.height);
    }

    void SetDefaultScriptsSettings()
    {
        dragRigidbodyScript.enabled = false;
        pushScript.DefaultSettings();
        pushScript.enabled = false;
    }

    void OnGUI()
    {
        if (m_bIsCrosshairVisible)
            switch (currentCursorState)
            {
                case CursorState.DefaultTexture:
                    GUI.DrawTexture(m_crosshairRect, m_crosshairTexture);
                    break;
                case CursorState.DoorTexture:
                    GUI.DrawTexture(m_crosshairRect, m_doorTexture);
                    break;
                case CursorState.HandTexture:
                    GUI.DrawTexture(m_crosshairRect, m_useHandTexture);
                    break;
                case CursorState.NoteTexture:
                    GUI.DrawTexture(m_crosshairRect, m_useNoteTexture);
                    break;
                case CursorState.PushTexture:
                    GUI.DrawTexture(m_crosshairRect, m_usePushTexture);
                    break;
                case CursorState.SaveTexture:
                    GUI.DrawTexture(m_crosshairRect, m_useSaveTexture);
                    break;
                case CursorState.Drawers1Texture:
                    GUI.DrawTexture(m_crosshairRect, m_useDrawersTexture);
                    break;
                case CursorState.Drawers2Texture:
                    GUI.DrawTexture(m_crosshairRect, m_useDrawersTexture);
                    break;
                case CursorState.WardrobeTexture:
                    GUI.DrawTexture(m_crosshairRect, m_useWardrobeTexture);
                    break;
                case CursorState.Object1Texture:
                    GUI.DrawTexture(m_crosshairRect, m_useWardrobeTexture);
                    break;
                case CursorState.Object2Texture:
                    GUI.DrawTexture(m_crosshairRect, m_useWardrobeTexture);
                    break;
                case CursorState.Move1Texture:
                    GUI.DrawTexture(m_crosshairRect, m_useMoveTexture);
                    break;
                case CursorState.Move2Texture:
                    GUI.DrawTexture(m_crosshairRect, m_useMoveTexture);
                    break;
                case CursorState.MoveTaskTexture:
                    GUI.DrawTexture(m_crosshairRect, m_useMoveTexture);
                    break;
            }
    }

    void OnEnabled()
    {
        m_ShowCursor = false;
    }
}