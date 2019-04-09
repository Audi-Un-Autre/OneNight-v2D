using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeElements : MonoBehaviour
{
    public void Fade_Out(){
        StartCoroutine(FadeOut());
    }

    public void Fade_In(){
        StartCoroutine(FadeIn());
    }
    
    public IEnumerator FadeOut(){
        CanvasGroup UI = GetComponentInParent<CanvasGroup>();
        while (UI.alpha > 0f){
            UI.alpha -= Time.deltaTime / 25f;
            yield return null;
        }
        //UI.interactable = false;
        yield return null;
    }

    public IEnumerator FadeIn()
    {
        CanvasGroup UI = GetComponentInParent<CanvasGroup>();
        while (UI.alpha != 1f)
        {
            UI.alpha += Time.deltaTime / 5f;
            yield return null;
        }
        //UI.interactable = false;
        yield return null;
    }
}
