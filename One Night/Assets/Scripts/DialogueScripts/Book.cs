﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public GameObject yes, no, selection;
    public Canvas canvas;
    public DialogueZoneActive active;
    public DialogueManager mgr;
    public bool buttonsActive = false;
    public bool decisionMade = false;

    void Start(){
        mgr = FindObjectOfType<DialogueManager>();
        active = GetComponentInParent<DialogueZoneActive>();
    }

    void Update(){
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "ReadBook" && !buttonsActive){
            active.enabled = false;
            yes.SetActive(true);
            no.SetActive(true);
            selection.SetActive(true);
            selection.GetComponent<Button>().Select();
            yes.GetComponent<Text>().text = "Read the book.";
            no.GetComponent<Text>().text = "Nah ... I'm good.";
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

        if (gameObject.transform.parent.GetChild(0).gameObject.name == "ReadBook")
            Destroy(gameObject.transform.parent.GetChild(0).gameObject);

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
}
