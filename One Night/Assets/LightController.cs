using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float offset;
    public GameObject light;
    private bool isOn;
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
        {
            light.SetActive(isOn = !isOn);
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
 
}
