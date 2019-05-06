using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalDatas : MonoBehaviour
{

    public static bool forestPuzzleDone;
    public static GameObject book, well, garden;
    public static GameObject doorMain, boatDoor, gardenDoor;

    public static bool boatPuzzlesDone;
    public static GameObject book2, fireplace;

    public static bool gardenPuzzleDone;
    public static GameObject book3, stove;

    private void Awake(){
        GameObject[] settings = GameObject.FindGameObjectsWithTag("GlobalSett");
        if (settings.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= Check;
    }

    // TO DO upon scene changes
    private void Check(Scene scene, LoadSceneMode mode){
        if (SceneManager.GetActiveScene().name == "About" || SceneManager.GetActiveScene().name == "Ending1" || SceneManager.GetActiveScene().name == "Ending2" || SceneManager.GetActiveScene().name == "MainMenu")
            Destroy(gameObject);

        // if all things in forest has been solved, mark all objects complete and maintain persistence between scenes
        else if (SceneManager.GetActiveScene().name == "Audrey")
        {
            book = GameObject.Find("BookFirst");
            well = GameObject.Find("WellPuzzle");
            garden = GameObject.Find("PatchPuzzle");
            doorMain = GameObject.Find("HouseDoor");
            boatDoor = GameObject.Find("BoatDoor");
            gardenDoor = GameObject.Find("GardenDoor");

            // forest settings
            if (forestPuzzleDone)
            {
                // garden patch already solved
                if (garden.transform.GetChild(0).name == "Initial"){
                    Destroy(garden.transform.GetChild(0).gameObject);
                    Destroy(garden.transform.GetChild(1).gameObject);
                    Destroy(garden.transform.GetChild(2).gameObject);
                }

                // book already solved
                if (book.transform.GetChild(0).name == "ReadBook"){
                    Destroy(book.transform.GetChild(0).gameObject);
                    Destroy(book.transform.Find("Canvas").gameObject);
                }

                // boat door already solved
                if (boatDoor.transform.GetChild(0).name == "Locked")
                    Destroy(boatDoor.transform.GetChild(0).gameObject);
            }

            // unlock main house door
            if (gardenPuzzleDone){
                if (doorMain.transform.GetChild(0).name == "Locked")
                    Destroy(doorMain.transform.GetChild(0).gameObject);
            }

            // unlock garden house door
            if (boatPuzzlesDone){
                if (gardenDoor.transform.GetChild(0).name == "Locked")
                    Destroy(gardenDoor.transform.GetChild(0).gameObject);
            }
        }

        // boat settings
        else if (SceneManager.GetActiveScene().name == "BoatHouse"){

            book2 = GameObject.Find("Book");
            fireplace = GameObject.Find("Fireplace");

            if (boatPuzzlesDone){

                // book already solved
                if (book2.transform.GetChild(0).name == "ReadBook"){
                    Destroy(book2.transform.GetChild(0).gameObject);
                    Destroy(book2.transform.Find("Canvas").gameObject);
                }

                // fireplace solved
                if (fireplace.transform.GetChild(0).name == "Initial")
                    Destroy(fireplace.transform.GetChild(0).gameObject);
            }
        }

        // garden settings
        else if (SceneManager.GetActiveScene().name == "GardenHouse"){

            book3 = GameObject.Find("Book");
            stove = GameObject.Find("Stove");

            if (gardenPuzzleDone){
                // book already read
                if (book3.transform.GetChild(0).name == "ReadBook"){
                    Destroy(book3.transform.GetChild(0).gameObject);
                    Destroy(book3.transform.Find("Canvas").gameObject);
                }

                // stove already solved
                if (stove.transform.GetChild(0).name == "Unsolved"){
                    Destroy(stove.transform.GetChild(0).gameObject);
                    Destroy(stove.transform.GetChild(1).gameObject);
                }
            }
        }
    }

    private void OnEnable(){
        SceneManager.sceneLoaded += Check;
    }
}
