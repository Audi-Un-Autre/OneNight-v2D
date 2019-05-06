using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoveDoor : MonoBehaviour
{
    public GameObject yes, no, selection;
    public DialogueZoneActive active;
    public DialogueManager mgr;
    public bool buttonsActive = false;
    public bool decisionMade = false;
    public bool gotKey = false;
    bool bookRead;
    bool initialized;

    void Start()
    {
        mgr = FindObjectOfType<DialogueManager>();
        active = GetComponentInParent<DialogueZoneActive>();
    }

    private void Update(){
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "Ready" && !buttonsActive){
            active.enabled = false;
            yes.SetActive(true);
            no.SetActive(true);
            selection.SetActive(true);
            selection.GetComponent<Button>().Select();
            yes.GetComponent<Text>().text = "Reach under the oven.";
            no.GetComponent<Text>().text = "Not right now.";
            buttonsActive = true;
        }
    }

    public void Yes(){
        // turn buttons off after choices are made and enable paused scripts
        yes.SetActive(false);
        no.SetActive(false);
        selection.SetActive(false);
        gotKey = true;

        mgr.DisplayNext();
        active.enabled = true;

        if (gameObject.transform.parent.GetChild(0).gameObject.name == "Ready")
            Destroy(gameObject.transform.parent.GetChild(0).gameObject);

        GlobalDatas.gardenPuzzleDone = true;

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

    public void ObtainedBook()
    {
        bookRead = true;
        FirstTime();
    }

    public void FirstTime()
    {
        if (bookRead && !initialized)
        {
            Destroy(gameObject.transform.parent.GetChild(0).gameObject);
            initialized = true;
        }
    }
}
