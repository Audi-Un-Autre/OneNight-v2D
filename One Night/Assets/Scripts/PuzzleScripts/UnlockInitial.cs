using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockInitial : MonoBehaviour
{

    public GameObject yes, no, selection;
    public DialogueZoneActive active;
    public DialogueManager mgr;
    public bool buttonsActive = false;
    public bool decisionMade = false;

    void Start()
    {
        mgr = FindObjectOfType<DialogueManager>();
        active = GetComponentInParent<DialogueZoneActive>();
    }

    void Update()
    {
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "UseKey" && !buttonsActive)
        {
            active.enabled = false;
            yes.SetActive(true);
            no.SetActive(true);
            selection.SetActive(true);
            selection.GetComponent<Button>().Select();
            yes.GetComponent<Text>().text = "YES.";
            no.GetComponent<Text>().text = "Not yet . . .";
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

        if (gameObject.transform.parent.GetChild(0).gameObject.name == "UseKey")
            Destroy(gameObject.transform.parent.GetChild(0).gameObject);

        buttonsActive = false;
        decisionMade = true;

        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.Find("SpawnEscape").transform.position;

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
