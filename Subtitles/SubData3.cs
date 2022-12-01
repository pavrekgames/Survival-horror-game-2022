using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SubLines3", menuName = "Subtitles/Lines3", order = 3)]
public class SubData3 : ScriptableObject
{

    [Header("Subtitles")]
    public string subtitles1;
    public string subtitles2;
    public string subtitles3;

    [Header("Subtitles time")]
    public float startSub1;
    public float endSub1;
    public float startSub2;
    public float endSub2;
    public float startSub3;

}
