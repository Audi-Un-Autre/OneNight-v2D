using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlatePuzzle : MonoBehaviour
{

    public int neededPressure;
    public int currentPressure;
    private bool isDone;
    public GameObject[] plates;
    GameObject reward;
    bool rewarded;

    void Start()
    {
        isDone = false;
        currentPressure = 0;
        plates = GameObject.FindGameObjectsWithTag("PressurePlate");
        reward = GameObject.Find("Battery");
        rewarded = false;
    }

    public void UpdateCurrentPressure()
    {
        int sum = 0;
        for(int i = 0; i < plates.Length; i++)
        {
            sum += plates[i].GetComponent<Weight>().GetWeight();
        } 

        currentPressure = sum;
    }

    void Update()
    {
        if(currentPressure == neededPressure)
        {
            isDone = true;
            Debug.Log("You completed the puzzle!");
            //insert reward here
            if (!rewarded){
                reward.SetActive(true);
                rewarded = true;
            }
            
        }
        else
            reward.SetActive(false);
    }
}
