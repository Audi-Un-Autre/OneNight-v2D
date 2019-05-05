using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DiaryPage : ScriptableObject
{
    [TextArea]
    public string text;
    public string pageNumber;
    
    public Sprite diaryPage;
    public Sprite diaryScribble;
}
