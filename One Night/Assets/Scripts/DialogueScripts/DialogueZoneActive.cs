using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueZoneActive : MonoBehaviour
{
    private bool dialougeStarted;
    private DialogueManager mgr;
    private bool colliding;
    private GameObject player;

    private void Start(){
        dialougeStarted = false;
        colliding = false;
        mgr = FindObjectOfType<DialogueManager>();
    }

    private void Update(){
        if (colliding && Input.GetKeyDown(KeyCode.E) && !dialougeStarted){
            // initial dialogue & freeze player in place
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; 
            gameObject.GetComponent<DialogueTrigger>().startDialogue();
            dialougeStarted = true;
        }
        else if (colliding && Input.GetKeyDown(KeyCode.E) && dialougeStarted){
            // subsuequent dialogues & unfreeze player when done
            if (mgr.DisplayNext() == true){
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
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
