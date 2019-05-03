using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueBegin : MonoBehaviour
{
    DialogueManager mgr;
    bool dialogueStarted = false;


    private void Start()
    {
        mgr = GameObject.FindObjectOfType<DialogueManager>();
    }

    public void AdvanceText(){
        if (mgr.DisplayNext()){
            SceneManager.LoadScene("Audrey");
        }
    }


    private void Update()
    {
        if (!dialogueStarted){
            gameObject.GetComponent<DialogueTrigger>().startDialogue();
            dialogueStarted = true;
        }
    }

}
