using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueBegin : MonoBehaviour
{
    DialogueManager mgr;
    bool dialogueStarted = false;
    public bool falsePause;

    public GameObject start, quit, falseContinue, pause, opening, title, mainDialogue;


    private void Start()
    {
        mgr = GameObject.FindObjectOfType<DialogueManager>();
    }

    public void AdvanceText(){
        if (mgr.DisplayNext()){
            // reactive/deactive needed buttons and objects to return to normal state
            if (SceneManager.GetActiveScene().name == "AudreyHouse"){
                start.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);
                falseContinue.gameObject.SetActive(false);
                falsePause = false;
                opening.SetActive(false);
                title.gameObject.SetActive(true);
                mainDialogue.SetActive(true);
                Time.timeScale = 1f;
                gameObject.SetActive(false);
            }

            else if (SceneManager.GetActiveScene().name == "Ending1" || SceneManager.GetActiveScene().name == "Ending2"){
                SceneManager.LoadScene("MainMenu");
            }
            else
                SceneManager.LoadScene("Audrey");
        }
    }


    private void Update()
    {
        // dialogue with the doctor 'false pause screen'
        // activate and deactivate needed buttons
        if (falsePause){
            start.gameObject.SetActive(false);
            quit.gameObject.SetActive(false);
            falseContinue.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
        }

        if (!dialogueStarted)
        {
            gameObject.GetComponent<DialogueTrigger>().startDialogue();
            dialogueStarted = true;
        }
    }

}
