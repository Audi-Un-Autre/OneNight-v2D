using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float offset;
    public GameObject light;
    private bool isOn;
    public float maxLight;
    private float batteryLeft;
    public float batterDrainRate;
    private Light lightComp;
    public float intensityModifier;

    void Start()
    {
        isOn = false;
        batteryLeft = maxLight;
        lightComp = light.GetComponent<Light>();
    }

    public void RefreshLight()
    {
        batteryLeft = maxLight;
    }

    void Update()
    {
        if(batteryLeft <= 0)
        {
            isOn = false;
            light.SetActive(isOn);
        }

        if(Input.GetMouseButtonDown(1) && batteryLeft > 0)
        {
            light.SetActive(isOn = !isOn);
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(isOn)
        {
            batteryLeft -= batterDrainRate * Time.deltaTime;
        }

        lightComp.intensity = batteryLeft/maxLight * intensityModifier;

        Debug.Log("Battery Left: " + batteryLeft);
    }
 
}
