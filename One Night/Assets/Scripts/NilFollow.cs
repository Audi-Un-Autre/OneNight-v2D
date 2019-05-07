using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NilFollow : MonoBehaviour
{

    GameObject player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        // look at player
        Vector3 direction = player.transform.position - transform.position;
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(rotz - 90, Vector3.forward);
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.transform.tag == "Player"){
            player.GetComponent<playerController>().health -= 10f;
        }
    }
}
