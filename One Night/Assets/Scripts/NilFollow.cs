using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NilFollow : MonoBehaviour
{

    GameObject player;
    public bool found;
    Vector3 direction;
    public bool sense;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){

        if (player != null)
            sense = true;
        else
            sense = false;

        // look at player
        direction = player.transform.position - transform.position;
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(rotz - 90, Vector3.forward);
    }

    private void FixedUpdate(){

        if (sense){
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 200f);
            Debug.DrawRay(transform.position, direction, Color.red);

            // if nil is looking right at player, damage
            if (hit.collider.tag.Contains("Player")){
                found = true;
                player.GetComponent<playerController>().health -= 10f * Time.deltaTime;
            }
            else{
                found = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.transform.tag == "Player"){
            player.GetComponent<playerController>().health -= 10f;
        }
    }
}
