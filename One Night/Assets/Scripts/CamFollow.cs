using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform playerLoc;
    [SerializeField] Camera cam;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerLoc = player.transform;
        cam = GetComponent<Camera>();
        cam.backgroundColor = Color.black;
    }
    private void FixedUpdate(){
        transform.position = new Vector3(playerLoc.position.x, playerLoc.position.y, transform.position.z);
    }
}
