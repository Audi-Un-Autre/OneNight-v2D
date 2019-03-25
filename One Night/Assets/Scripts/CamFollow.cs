using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        cam.backgroundColor = Color.black;
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

    }
}
