using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piano : MonoBehaviour
{
    public DialogueManager mgr;
    public GameObject yes, no, selection;
    public DialogueZoneActive active;
    public bool buttonsActive = false;
    public bool choice = false;
    public GameObject openDoor;
    public char[] pianoLetters;

    void Start(){
        mgr = FindObjectOfType<DialogueManager>();
        active = GetComponentInParent<DialogueZoneActive>();
    }

    void Update(){
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "G" && !buttonsActive){
            active.enabled = false;
            yes.SetActive(true);
            no.SetActive(true);
            selection.SetActive(true);
            selection.GetComponent<Button>().Select();
            yes.GetComponent<Text>().text = "Press G";
            no.GetComponent<Text>().text = "Press A";
            buttonsActive = true;
        }

        else if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "A" && !buttonsActive)
        {
            active.enabled = false;
            yes.SetActive(true);
            no.SetActive(true);
            selection.SetActive(true);
            selection.GetComponent<Button>().Select();
            yes.GetComponent<Text>().text = "Press A";
            no.GetComponent<Text>().text = "Press G";
            buttonsActive = true;
        }

        else if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "B" && !buttonsActive)
        {
            active.enabled = false;
            yes.SetActive(true);
            no.SetActive(true);
            selection.SetActive(true);
            selection.GetComponent<Button>().Select();
            yes.GetComponent<Text>().text = "Press A";
            no.GetComponent<Text>().text = "Press B";
            buttonsActive = true;
        }
    }

    public void RightChoice(){
        // turn buttons off after choices are made and enable paused scripts
        yes.SetActive(false);
        no.SetActive(false);
        selection.SetActive(false);

        mgr.DisplayNext();
        active.enabled = true;

        buttonsActive = false;
        choice = true;
    }

    public void WrongChoice(){
        // turn buttons off after choices are made and enable paused scripts
        yes.SetActive(false);
        no.SetActive(false);
        selection.SetActive(false);

        mgr.DisplayNext();
        active.enabled = true;

        choice = false;
        buttonsActive = false;
    }
}
