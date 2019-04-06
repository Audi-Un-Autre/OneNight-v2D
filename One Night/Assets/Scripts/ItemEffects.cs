using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffects : MonoBehaviour
{
    public int effectToUse;

    // Start is called before the first frame update
    void Start()
    {
    }

    //Battery effect
    public void ItemEffect()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        switch(effectToUse)
        {
        case 0://Refresh the players light
            player[0].transform.Find("LightController").gameObject.GetComponent<LightController>().RefreshLight();
            Destroy(gameObject);
            print ("Battery Used");
            break;
        default:
            print ("No effect used");
            break;
        }
    }
}
