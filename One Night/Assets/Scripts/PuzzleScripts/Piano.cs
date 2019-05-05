using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piano : MonoBehaviour
{
    public DialogueManager mgr;
    public GameObject g, c, a, b, d, f, selection1, selection2, selection3;
    public DialogueZoneActive active;
    public bool buttonsActive = false;
    public bool decisionMade = false;
    public GameObject openDoor;
    public bool fail;
    public bool solved;
    public GameObject opener;
    public GameObject openerDialogue;
    public GameObject Nil;
    public GameObject mainDialogue;

    void Start(){
        mgr = FindObjectOfType<DialogueManager>();
        active = GetComponentInParent<DialogueZoneActive>();
        fail = false;
    }

   
    void Update(){
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.activeSelf && !buttonsActive && !fail){
            active.enabled = false;
            g.SetActive(true);
            c.SetActive(true);
            selection1.SetActive(true);
            selection1.GetComponent<Button>().Select();
            g.GetComponent<Text>().text = "Press G";
            c.GetComponent<Text>().text = "Press C";
            buttonsActive = true;
        }
        
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(1).gameObject.activeSelf && !buttonsActive)
        {
            decisionMade = false;
            active.enabled = false;
            d.SetActive(true);
            a.SetActive(true);
            selection2.SetActive(true);
            selection2.GetComponent<Button>().Select();
            d.GetComponent<Text>().text = "Press D";
            a.GetComponent<Text>().text = "Press A";
            buttonsActive = true;
        }

        if (mgr.lastSentence && gameObject.transform.parent.GetChild(2).gameObject.activeSelf && !buttonsActive)
        {
            decisionMade = false;
            active.enabled = false;
            f.SetActive(true);
            b.SetActive(true);
            selection3.SetActive(true);
            selection3.GetComponent<Button>().Select();
            f.GetComponent<Text>().text = "Press F";
            b.GetComponent<Text>().text = "Press B";
            buttonsActive = true;
        }   
    }

    public void PuzzleFailed(){
        fail = true;
    }

    public void G(){
        // turn buttons off after choices are made and enable paused scripts
        g.SetActive(false);
        c.SetActive(false);
        selection1.SetActive(false);

        gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);

        buttonsActive = false;
        decisionMade = true;

        gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
    }

    public void A()
    {
        // turn buttons off after choices are made and enable paused scripts
        d.SetActive(false);
        a.SetActive(false);
        selection2.SetActive(false);

        gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);

        buttonsActive = false;
        decisionMade = true;

        gameObject.transform.parent.GetChild(2).gameObject.SetActive(true);
    }

    public void B()
    {
        // turn buttons off after choices are made and enable paused scripts
        f.SetActive(false);
        b.SetActive(false);
        selection3.SetActive(false);

        gameObject.transform.parent.GetChild(2).gameObject.SetActive(false);

        buttonsActive = false;
        decisionMade = true;

        if(fail){
            WrongChoice();
            gameObject.transform.parent.GetChild(3).GetComponent<DialogueTrigger>().startDialogue();
        }
        else{
            RightChoice();
            //gameObject.transform.parent.GetChild(4).GetComponent<DialogueTrigger>().startDialogue();
            Destroy(gameObject.transform.parent.GetChild(3).gameObject);
            Destroy(gameObject.transform.parent.GetChild(4).gameObject);
            GameObject.Find("MainDoor").GetComponent<DialogueZoneActive>().enabled = true;
            if (gameObject.transform.parent.name == "Piano"){
                Destroy(GameObject.Find("IntialDoor").transform.GetChild(0).gameObject);
                HouseIntro.pianoSolved = true;
            }
            if (gameObject.transform.parent.name == "Piano2"){
                Destroy(GameObject.Find("SecretWall"));
                gameObject.transform.parent.GetChild(4).GetComponent<DialogueTrigger>().startDialogue();
            }
        }
    }

    public void WrongChoice(){
        // turn buttons off after choices are made and enable paused scripts
        g.SetActive(false);
        c.SetActive(false);

        d.SetActive(false);
        a.SetActive(false);

        f.SetActive(false);
        b.SetActive(false);

        selection1.SetActive(false);
        selection2.SetActive(false);
        selection3.SetActive(false);

        
        mgr.DisplayNext();
        active.enabled = true;

        decisionMade = false;
        buttonsActive = false;

        gameObject.transform.parent.GetChild(0).gameObject.SetActive(true);
    }

    public void RightChoice(){

        //Disable all canvas components
        g.SetActive(false);
        c.SetActive(false);

        d.SetActive(false);
        a.SetActive(false);

        f.SetActive(false);
        b.SetActive(false);

        selection1.SetActive(false);
        selection2.SetActive(false);
        selection3.SetActive(false);

        mgr.DisplayNext();
        active.enabled = true;

        decisionMade = false;
        buttonsActive = false;
        solved = true;

        //open the door block the player in and block off the maindoor from exit
        //Destroy(openDoor);
        GameObject.Find("MainDoor").GetComponent<CompositeCollider2D>().isTrigger = false;
    }
}
