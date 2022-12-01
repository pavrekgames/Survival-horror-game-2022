using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SubLines4", menuName = "Subtitles/Lines4", order = 4)]
public class SubData4 : ScriptableObject
{

    [Header("Subtitles")]
    public string subtitles1;
    public string subtitles2;
    public string subtitles3;
    public string subtitles4;

    [Header("Subtitles time")]
    public float startSub1;
    public float endSub1;
    public float startSub2;
    public float endSub2;
    public float startSub3;
    public float endSub3;
    public float startSub4;

}
