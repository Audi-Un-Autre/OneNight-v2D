using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text name;
    public Text dialogueText;
    bool dialogueStarted = false;

    private void Start(){
        sentences = new Queue<string>();
    }

    private void Update(){
        if (dialogueStarted){
            GetComponent<FadeElements>().Fade_In();
        }
        if (!dialogueStarted){
            GetComponent<FadeElements>().Fade_Out();
        }
    }

    public void StartEvent(Dialogue dialogue){
        dialogueStarted = true;
        name.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNext();
    }

    public bool DisplayNext(){
        if (sentences.Count == 0){
            End();
            return true;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        return false;
    }

    public void End(){
        dialogueStarted = false;
    }
}
