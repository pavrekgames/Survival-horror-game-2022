using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SubLine1", menuName = "Subtitles/Line1", order =1)]
public class SubData1 : ScriptableObject {

    [Header("Subtitles")]
    public string subtitles;

    [Header("Subtitles time")]
    public float startTime;

}
