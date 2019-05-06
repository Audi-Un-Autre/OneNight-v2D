using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePlacePuzzle : MonoBehaviour
{
    public GameObject yes, no, selection;
    public DialogueZoneActive active;
    public DialogueManager mgr;
    public bool buttonsActive = false;
    public bool decisionMade = false;
    public bool gotKey = false;

    void Start(){
        mgr = FindObjectOfType<DialogueManager>();
        active = GetComponentInParent<DialogueZoneActive>();
    }

    void Update(){
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "Initial" && !buttonsActive)
        {
            active.enabled = false;
            yes.SetActive(true);
            no.SetActive(true);
            selection.SetActive(true);
            selection.GetComponent<Button>().Select();
            yes.GetComponent<Text>().text = "Yes.";
            no.GetComponent<Text>().text = "No!";
            buttonsActive = true;
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

        if (gameObject.transform.parent.GetChild(0).gameObject.name == "Initial")
            Destroy(gameObject.transform.parent.GetChild(0).gameObject);

        gotKey = true;
        GlobalDatas.boatPuzzlesDone = true;

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
