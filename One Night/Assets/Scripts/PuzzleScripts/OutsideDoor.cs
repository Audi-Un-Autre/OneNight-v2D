using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OutsideDoor : MonoBehaviour
{
    public DialogueManager mgr;

    private void Update(){
        if (mgr.lastSentence && gameObject.transform.parent.GetChild(0).gameObject.name == "Unlock"){
            Destroy(gameObject.transform.parent.GetChild(0).gameObject);

            switch (gameObject.transform.parent.name){
                case "GardenDoor":
                    ObtainedKey();
                    break;

                case "BoatDoor":
                    ObtainedKey();
                    break;

                case "HouseDoor":
                    ObtainedKey();
                    break;
            }
        }
    }

    public void ObtainedKey(){
        gameObject.transform.parent.GetComponent<CompositeCollider2D>().isTrigger = true;
        Destroy(gameObject.transform.parent.GetChild(0).gameObject);
    }
}
