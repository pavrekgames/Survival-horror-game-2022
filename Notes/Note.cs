using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

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
    }

}
