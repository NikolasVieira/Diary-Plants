using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Page", menuName ="Diary/Page")]
public class SCR_DIARY_PAGE : ScriptableObject
{
    public Sprite Artwork;
    public string NameCommon;
    public string NameCientific;
    [TextArea(10, 100)]
    public string Description;
}

