using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public int weight;
    private bool isPlate;
    private bool isOnPlate;
    public GameObject MasterPlate;
    private int counter;
    public Weight currPlate;

    void Start()
    {
        if(gameObject.tag == "PressurePlate")
        {
            isPlate = true;
        }
        else
        {
            isPlate = false;
            MasterPlate = null;
        }
        isOnPlate = false;
        counter = 0;
    }


    public int GetWeight()
    {
        return weight;
    }

    public void UpdateMasterPlate(Weight PressurePlate)
    {
        PressurePlate.MasterPlate.GetComponent<PressurePlatePuzzle>().UpdateCurrentPressure();
    }
    public void SetWeight(int newWeight)
    {
        this.weight = newWeight;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isPlate && collision.gameObject.tag == "PressurePlate" && !isOnPlate)
        {
            Weight pressurePlate = collision.gameObject.GetComponent<Weight>();
            pressurePlate.counter++;
            isOnPlate = true;
            pressurePlate.SetWeight(GetWeight());
            UpdateMasterPlate(pressurePlate);
            currPlate = pressurePlate;
        }
        else
        {
            isOnPlate = false;
        }

        if(isPlate && collision.gameObject.tag != "Item")
        {
            SetWeight(0);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(isPlate && collision.gameObject.tag == "Item")
        {
            counter--;
            if(counter < 0)
            {
                counter = 0;
            }
            if(counter == 0)
            {
                SetWeight(0);
                UpdateMasterPlate(this);
            }
        }
        else
        {
            isOnPlate = false;
        }
    }

    public void SubtractItem()
    {
        counter--;
        if(counter < 0)
        {
            counter = 0;
        }
        if(counter == 0)
        {
            SetWeight(0);
            UpdateMasterPlate(this);
        }
    }

    void OnDestroy()
    {
        if(!isPlate && isOnPlate)
        {
            currPlate.SubtractItem();
        }
    }
}
