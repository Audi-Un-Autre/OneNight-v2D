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
        Vector3 direction = player.transform.position - transform.position;
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(rotz - 90, Vector3.forward);
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
