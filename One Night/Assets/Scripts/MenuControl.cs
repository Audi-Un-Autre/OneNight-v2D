using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    GameObject isPaused;
    public bool falsePause;

    private void Start()
    {
        isPaused = GameObject.Find("Pause");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Audrey" || SceneManager.GetActiveScene().name == "AudreyHouse" || SceneManager.GetActiveScene().name == "BoatHouse" || SceneManager.GetActiveScene().name == "GardenHouse"){
            if (Time.timeScale == 0f){
                isPaused.SetActive(true);
            }
            else
                isPaused.SetActive(false);
        }
    }

    public void Title(){
        if (SceneManager.GetActiveScene().name == "Audrey" || SceneManager.GetActiveScene().name == "AudreyHouse" || SceneManager.GetActiveScene().name == "BoatHouse" || SceneManager.GetActiveScene().name == "GardenHouse"){
            Time.timeScale = 1f;
            PlayerSpawn.firstRun = true;
        }
        Destroy(GameObject.Find("GlobalObjects"));
        PlayerSpawn.firstRun = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void NewGame(){
        SceneManager.LoadScene("About");
    }

    public void ContinueGame(){
        Time.timeScale = 1f;
        isPaused.SetActive(false);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
