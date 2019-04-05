using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueZoneActive : MonoBehaviour
{
    private bool dialougeStarted;
    private DialogueManager mgr;
    private bool colliding;
    private GameObject player;
    private bool requirementMet;
    public bool initial = false;

    private void Start(){
        dialougeStarted = false;
        colliding = false;
        mgr = FindObjectOfType<DialogueManager>();
        requirementMet = false;
    }

    private void Update(){
        if (colliding && Input.GetKeyDown(KeyCode.E) && !dialougeStarted){
            // initial dialogue & freeze player in place

            if (gameObject.name == "PatchPuzzle"){
                if (!gameObject.GetComponent<GardenPuzzle>().enabled)
                    gameObject.GetComponent<GardenPuzzle>().enabled = true;
                if (FindObjectOfType<Well>().enabled)
                    FindObjectOfType<Well>().enabled = false;
            }
            else if (gameObject.name == "WellPuzzle"){
                if (!gameObject.GetComponent<Well>().enabled)
                    gameObject.GetComponent<Well>().enabled = true;
                if (FindObjectOfType<GardenPuzzle>().enabled)
                    FindObjectOfType<GardenPuzzle>().enabled = false;
            }


            //initial = true;
            gameObject.GetComponentInChildren<DialogueTrigger>().startDialogue();
            dialougeStarted = true;
        }
        else if (colliding && Input.GetKeyDown(KeyCode.E) && dialougeStarted){
            // subsuequent dialogues & unfreeze player when done
            if (mgr.DisplayNext() == true){
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.tag == "Player"){
            player = collision.gameObject;
            colliding = true;
            Debug.Log("Colliding");
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if (collision.transform.tag == "Player"){
            dialougeStarted = false;
            colliding = false;
            Debug.Log("Left Collision Zone");
        }
    }
}
