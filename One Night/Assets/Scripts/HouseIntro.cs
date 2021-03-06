﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseIntro : MonoBehaviour
{
    [SerializeField] GameObject player;
    public static bool pianoSolved; // GLOBAL
    public DialogueManager mgr;
    public GameObject opener;
    public GameObject openerDialogue;
    public GameObject mainDialogue;
    public bool wait;
    public float waitTime = 0f;
    public float waitMax = 3f;
    public bool started;

    public GameObject startNil;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update(){
        // look at player
        Vector3 direction = player.transform.position - transform.position;
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(rotz - 90, Vector3.forward);

        // Transition when piano is solved
        if (pianoSolved && !wait){
            //if (!wait)
            //    waitTime += Time.deltaTime;
            //if (waitTime >= waitMax && !wait){
                gameObject.transform.GetChild(1).GetComponent<DialogueTrigger>().startDialogue();
                wait = true;
            //}
        }

        if (wait && !mgr.dialogueStarted){
            // Send player to capture room and activate dialogue with the doctor
            mainDialogue.SetActive(false);
            opener.SetActive(true);
            openerDialogue.SetActive(true);
            openerDialogue.gameObject.GetComponent<DialogueBegin>().falsePause = true;
            Time.timeScale = 0f;
            player.transform.position = GameObject.Find("CaptureRoom").gameObject.transform.position;
            startNil.SetActive(true);
            Destroy(gameObject);
        }
    }
}
