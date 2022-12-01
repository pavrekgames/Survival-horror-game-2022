using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SubLines2", menuName ="Subtitles/Lines2", order = 2)]
public class SubData2 : ScriptableObject {

    [Header("Subtitles")]
    public string subtitles1;
    public string subtitles2;

    [Header("Subtitles time")]
    public float startSub1;
    public float endSub1;
    public float startSub2;

}
