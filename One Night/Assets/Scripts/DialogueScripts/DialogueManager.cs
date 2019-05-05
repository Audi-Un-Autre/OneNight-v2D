using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text name;
    public Text dialogueText;
    public bool dialogueStarted = false;
    public bool lastSentence = false;
    public GameObject player;
    public GameObject pause;

    private void Start(){
        sentences = new Queue<string>();
        if (SceneManager.GetActiveScene().name != "About" && SceneManager.GetActiveScene().name != "Ending1" && SceneManager.GetActiveScene().name != "Ending2")
            player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update(){
        if (gameObject.transform.parent.gameObject.name != "Opening" && SceneManager.GetActiveScene().name != "About" && SceneManager.GetActiveScene().name != "Ending1" && SceneManager.GetActiveScene().name != "Ending2"){
            if (dialogueStarted){
                GetComponent<FadeElements>().Fade_In();
            }
            if (!dialogueStarted){
                GetComponent<FadeElements>().Fade_Out();
            }
        }
        if (sentences.Count == 0 && dialogueStarted)
            lastSentence = true;
    }

    public void StartEvent(Dialogue dialogue){
        //Cursor.lockState = CursorLockMode.Locked;
        if (SceneManager.GetActiveScene().name != "About" && SceneManager.GetActiveScene().name != "Ending1" && SceneManager.GetActiveScene().name != "Ending2")
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        dialogueStarted = true;
        name.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNext();
    }

    public bool DisplayNext(){
        if (sentences.Count == 0){
            End();
            return true;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        return false;
    }

    public void End(){
        //Cursor.lockState = CursorLockMode.None;
        if (SceneManager.GetActiveScene().name != "About" && SceneManager.GetActiveScene().name != "Ending1" && SceneManager.GetActiveScene().name != "Ending2")
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        dialogueStarted = false;
        lastSentence = false;
    }
}
