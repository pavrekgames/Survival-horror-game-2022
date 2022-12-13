using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Note", menuName = "Note")]
public class NoteData : ScriptableObject
{

    public string title;
    [TextArea]
    public string content;
    public Canvas noteCanvas;

}
