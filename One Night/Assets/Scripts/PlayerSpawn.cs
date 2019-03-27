using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public static bool firstRun = true;
    [SerializeField] string previous_scene;
    [SerializeField] string current_scene;
    [SerializeField] Vector3 playerLoc;
    [SerializeField] Scene _scene;

    public GameObject player;
    public GameObject cam;
    [SerializeField] GameObject spawnIntro;
    [SerializeField] GameObject spawnMain;
    [SerializeField] GameObject spawnGarden;
    [SerializeField] GameObject spawnBoat;
    [SerializeField] GameObject spawnDefault;

    private void Start(){
        _scene = SceneManager.GetActiveScene();
        cam = GameObject.Find("Main Camera");

        //If player is in forest and firstload, instantiate
        if (_scene.name == "Audrey"){
            if(firstRun){ 
                GameObject playerNew;
                playerNew = Instantiate(player, spawnIntro.transform.position, Quaternion.identity);
                current_scene = "Audrey";
                previous_scene = "Audrey";
                firstRun = false;
                this.enabled = false;
            }

            //if player is in forest and not firstload, find player and set previous and current scenes
            if(!firstRun){
                player = GameObject.FindGameObjectWithTag("Player");
                current_scene = player.GetComponent<playerController>().currentRoom;
                previous_scene = player.GetComponent<playerController>().previousRoom;

                //spawn the player outside of the house they had exited from
                switch (previous_scene){
                    case "AudreyHouse":
                        player.transform.position = spawnMain.transform.position;
                        break;

                    case "GardenHouse":
                        player.transform.position = spawnGarden.transform.position;
                        break;

                    case "BoatHouse":
                        player.transform.position = spawnBoat.transform.position;
                        break;
                }

                this.enabled = false;
            }
        }
        else{
            //If not in forest, find spawpoint in house and place player there
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = spawnDefault.transform.position;
            this.enabled = false;
        }
        cam.GetComponent<CamFollow>().enabled = true;
    }
}
