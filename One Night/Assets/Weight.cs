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
    public GameObject currPlate;

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
            currPlate = collision.gameObject;
        }
        else
        {
            isOnPlate = false;
            currPlate = null;
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
            currPlate = null;
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
        Debug.Log("ASDADS");
    }

    void OnDestroy()
    {
        if(!isPlate && isOnPlate)
        {
            currPlate.GetComponent<Weight>().SubtractItem();
        }
    }
}
