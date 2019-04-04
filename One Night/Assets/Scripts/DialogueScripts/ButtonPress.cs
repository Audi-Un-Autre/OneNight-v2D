using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour
{

    public string _name;

    private void Update()
    {
        
    }

    public void buttonClick(Button btn){
        Debug.Log("Clicked " + btn.name);
        _name = btn.name;
    }
}
