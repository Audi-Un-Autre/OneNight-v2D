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
    private GameObject[] puzzles;

    private void Start(){
        dialougeStarted = false;
        colliding = false;
        mgr = FindObjectOfType<DialogueManager>();
        requirementMet = false;
        puzzles = GameObject.FindGameObjectsWithTag("Puzzle");
    }

    private void Update(){
        if (colliding && Input.GetKeyDown(KeyCode.E) && !dialougeStarted){
            // disables all other puzzles/dialogues while the one the current one is active
            foreach (GameObject puzzle in puzzles){
                if (puzzle.transform.parent.name == gameObject.name)
                    puzzle.SetActive(true);
                else
                    puzzle.SetActive(false);
            }

            // initial dialogue
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
