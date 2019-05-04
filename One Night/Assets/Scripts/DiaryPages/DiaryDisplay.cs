using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryDisplay : MonoBehaviour
{

    public DiaryPage diaryPage;
    public Text diaryText;
    public Text pageNumber;
    public Image page;
    public Image scribble;

    // Start is called before the first frame update
    void Start()
    {
        pageNumber.text = diaryPage.pageNumber;
        diaryText.text = diaryPage.text;

        page.sprite = diaryPage.diaryPage;
        scribble.sprite = diaryPage.diaryScribble;
    }
}
