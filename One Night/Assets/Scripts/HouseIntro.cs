using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseIntro : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update(){
        Vector3 diff = Camera.main.ScreenToWorldPoint(player.transform.position) - transform.position;
        diff.Normalize();
        float rotz = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz - 90);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        // dialogue
        // scene goes to black
        // remove intro doors
        // block off main door
        // place player into 
        // destroy this script
    }
}
