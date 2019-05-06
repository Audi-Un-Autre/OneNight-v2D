using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChairWeight : MonoBehaviour
{
    public DialogueManager mgr;
    public GameObject yes, no, selection;
    public DialogueZoneActive active;
    public bool buttonsActive = false;
    public bool decisionMade = false;
    public bool succeed = false;

    void Start(){
        mgr = FindObjectOfType<DialogueManager>();
        active = GetComponentInParent<DialogueZoneActive>();
    }

    void Update(){
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "Initial" && !buttonsActive)
        {
            // make this an onClick() event
            //Destroy(gameObject.transform.parent.GetChild(0).gameObject); 

            active.enabled = false;
            yes.SetActive(true);
            no.SetActive(true);
            selection.SetActive(true);
            selection.GetComponent<Button>().Select();
            yes.GetComponent<Text>().text = "Pick it up.";
            no.GetComponent<Text>().text = "No.";
            buttonsActive = true;
        }

        if (decisionMade && !succeed){
            gameObject.transform.parent.Find("Obtained").GetComponent<DialogueTrigger>().startDialogue();
            succeed = true;
        }
    }

    public void Yes()
    {
        // turn buttons off after choices are made and enable paused scripts
        yes.SetActive(false);
        no.SetActive(false);
        selection.SetActive(false);

        mgr.DisplayNext();
        active.enabled = true;

        // make the collider now a triggerable event
        if (gameObject.transform.parent.GetChild(0).gameObject.name == "Initial"){
            Destroy(gameObject.transform.parent.GetChild(0).gameObject);
            gameObject.transform.parent.GetComponent<CompositeCollider2D>().isTrigger = true;
        }

        buttonsActive = false;
        decisionMade = true;

    }

    public void No()
    {
        // turn buttons off after choices are made and enable paused scripts
        yes.SetActive(false);
        no.SetActive(false);
        selection.SetActive(false);

        mgr.DisplayNext();
        active.enabled = true;

        decisionMade = false;
        buttonsActive = false;
    }
}
