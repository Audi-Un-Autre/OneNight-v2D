using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GardenPuzzle : MonoBehaviour
{
    private DialogueManager mgr;
    public bool bookRead = false;
    public GameObject yes, no, selection;
    public bool decisionMade = false;
    public bool buttonsActive = false;
    public bool initialized = false;
    public GameObject spawnTo;
    public GameObject spawnBack;
    private GameObject player;
    public DialogueZoneActive active;
    public bool gotKey = false;
    public bool inWoods = true;
    public bool beenThere;
    public bool solved = false;

    private void Start(){
        mgr = FindObjectOfType<DialogueManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        active = GetComponent<DialogueZoneActive>();
    }

    private void Update(){
        if (bookRead && !initialized){
            Destroy(gameObject.transform.GetChild(0).gameObject);
            initialized = true;
        }

        if (bookRead && mgr.lastSentence && initialized && !buttonsActive && !solved){
            active.enabled = false;
            yes.SetActive(true);
            no.SetActive(true);
            selection.SetActive(true);
            selection.GetComponent<Button>().Select();
            yes.GetComponent<Text>().text = "Traverse the garden patch.";
            no.GetComponent<Text>().text = "What the hell, NO.";
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

        if (inWoods && !gotKey){
            player.transform.position = spawnTo.transform.position;
            if(!beenThere){
                Destroy(gameObject.transform.GetChild(0).gameObject);
                beenThere = true;
            }
            inWoods = false;
        }else if (!inWoods && !gotKey){
            player.transform.position = spawnBack.transform.position;
            inWoods = true;
        }else if (!inWoods && gotKey){
            player.transform.position = spawnBack.transform.position;
            Destroy(gameObject.transform.GetChild(0).gameObject);
            solved = true;
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

    public void ObtainedKey(){
        gotKey = true;
    }
}
