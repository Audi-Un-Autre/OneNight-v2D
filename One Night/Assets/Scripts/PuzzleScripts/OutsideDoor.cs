using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OutsideDoor : MonoBehaviour
{
    public DialogueManager mgr;
    public GameObject yes, no, selection;
    public DialogueZoneActive active;
    public bool buttonsActive = false;
    public bool decisionMade = false;

    private void Start(){
        mgr = FindObjectOfType<DialogueManager>();
        active = GetComponentInParent<DialogueZoneActive>();
    }

    /*
     * What needs to happen here :
     * upon obtaining the key, delete the dialogue that says the door is locked
     * 
     * upon interacting with the door after getting the key ->
     * allow the dialogue to prompt that the user has the key -> 
     * use the key -> 
     * delete the dialogue that just played ->
     * transport player inside the house
     */

    private void Update(){
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "Unlock" && !buttonsActive){
            // make this an onClick() event
            //Destroy(gameObject.transform.parent.GetChild(0).gameObject); 

            active.enabled = false;
            yes.SetActive(true);
            no.SetActive(true);
            selection.SetActive(true);
            selection.GetComponent<Button>().Select();
            yes.GetComponent<Text>().text = "Enter the house. . .";
            no.GetComponent<Text>().text = "Not yet.";
            buttonsActive = true;
        }
    }

    public void Yes(){
        // turn buttons off after choices are made and enable paused scripts
        yes.SetActive(false);
        no.SetActive(false);
        selection.SetActive(false);

        mgr.DisplayNext();
        active.enabled = true;

        // make the collider now a triggerable event
        if (gameObject.transform.parent.GetChild(0).gameObject.name == "Unlock"){
            //Destroy(gameObject.transform.parent.GetChild(0).gameObject);
            gameObject.transform.parent.GetComponent<CompositeCollider2D>().isTrigger = true;
        }

        buttonsActive = false;
        decisionMade = true;
    }

    public void No(){
        // turn buttons off after choices are made and enable paused scripts
        yes.SetActive(false);
        no.SetActive(false);
        selection.SetActive(false);

        mgr.DisplayNext();
        active.enabled = true;

        decisionMade = false;
        buttonsActive = false;
    }

    public void ObtainedGardenKey(){
        GameObject door = GameObject.Find("GardenDoor");
        Destroy(door.transform.GetChild(0).gameObject);
        
    }

    public void ObtainedHouseKey(){
        GameObject door = GameObject.Find("HouseDoor");
        Destroy(door.transform.GetChild(0).gameObject);
    }

    public void ObtainBoatKey(){
        GameObject door = GameObject.Find("BoatDoor");
        Destroy(door.transform.GetChild(0).gameObject);
    }
}
