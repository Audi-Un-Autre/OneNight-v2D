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
    public GameObject player;

    void Start()
    {
        isOn = false;
        batteryLeft = maxLight;
        lightComp = light.GetComponent<Light>();
        player = transform.root.gameObject;
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

        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        Vector3 difference = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.AngleAxis(rotZ, Vector3.forward);

        if (isOn)
        {
            batteryLeft -= batterDrainRate * Time.deltaTime;
        }

        lightComp.intensity = batteryLeft/maxLight * intensityModifier;

        //Debug.Log("Battery Left: " + batteryLeft);
    }
 
}
