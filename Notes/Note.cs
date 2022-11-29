using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public event Action OnPickUpNote;

   [SerializeField] private Canvas noteCanvas;
   [SerializeField] private Notes notesScript;

    public bool isRead;

    void Start()
    {
        notesScript = GameObject.Find("Player").GetComponent<Notes>();
    }

    public void PickUpNote()
    {
        notesScript.ReadNote(noteCanvas);
        gameObject.SetActive(false);

        if(OnPickUpNote != null)
        {
            OnPickUpNote.Invoke();
        }

    }

}
