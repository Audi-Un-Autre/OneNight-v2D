using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creeper : MonoBehaviour
{
    public GameObject yes, no, selection;
    public DialogueZoneActive active;
    public DialogueManager mgr;
    public bool buttonsActive = false;
    public bool decisionMade = false;
    public GameObject door1, door2;
    public bool spokeTo;
    public int ending;

    void Start(){
        mgr = FindObjectOfType<DialogueManager>();
        active = GetComponentInParent<DialogueZoneActive>();
    }

    void Update(){
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "Solve" && !buttonsActive)
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

        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "Initial"){
            if (GameObject.Find("Food Puzzle").transform.GetChild(0).name == "Unsolved")
                Destroy(GameObject.Find("Food Puzzle").transform.GetChild(0).gameObject);
        }

        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "Solve"){
            //Destroy(gameObject.transform.parent.GetComponent<SpriteRenderer>());
            //Destroy(gameObject.transform.parent.GetComponent<BoxCollider2D>());
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

        if (gameObject.transform.parent.GetChild(0).gameObject.name == "Solve")
            Destroy(gameObject.transform.parent.GetChild(0).gameObject);
        Destroy(GameObject.Find("IntialDoor").transform.GetChild(0).gameObject);

        buttonsActive = false;
        decisionMade = true;

        Destroy(door1.transform.GetChild(0).gameObject);
        Destroy(door2.transform.GetChild(0).gameObject);

        ending = 1;
        gameObject.transform.parent.gameObject.SetActive(false);
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

        Destroy(door1.transform.GetChild(0).gameObject);
        Destroy(door2.transform.GetChild(0).gameObject);

        ending = 2;
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
