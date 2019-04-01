﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerController : MonoBehaviour
{
	public float speed;
	private float walkSpeed;

	private Rigidbody2D rb;
	private Vector2 moveVelocity;
	private Vector2 lastPos;
	private float distanceTraveled;
	public float stamina;
	private float currStamina;
	private bool canRun;
	public float recoverStam;

    public bool testDoor;
    public string previousRoom;
    public string currentRoom;
    public GameObject player;
    public Vector3 playerLoc;
    private Vector3 outsideLoc;
    private bool playerDestroyed;
    private bool firstLoad;
    public Vector3 firstLoadLoc;

    // Start is called before the first frame update
    void Start()
    {
			rb = GetComponent<Rigidbody2D>();
			lastPos = transform.position;
			walkSpeed = speed;
			canRun = true;
			currStamina = stamina;
            playerLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
			Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			moveVelocity = moveInput.normalized * walkSpeed;
		
			Debug.Log("Stamina Left: " + currStamina);

			if(currStamina <= 0)
			{
				canRun = false;
				currStamina = 1;
			}
			else if(currStamina >= stamina)
			{
				canRun = true;
			}

			if(canRun && currStamina < stamina && !Input.GetKey(KeyCode.LeftShift))
			{
				currStamina += recoverStam * Time.fixedDeltaTime;
			}
			else if(!canRun)
			{
				currStamina += recoverStam * Time.fixedDeltaTime;
			}

			if(Input.GetKey(KeyCode.LeftShift) && canRun)
			{
				walkSpeed = speed * 2f;
				currStamina -= Vector2.Distance(transform.position, lastPos);
				
			}
			else
			{
				walkSpeed = speed;
			}

			lastPos = transform.position;
			rb.MovePosition (rb.position + moveVelocity * Time.fixedDeltaTime);
        }

	void FixedUpdate()
	{

	}

    private void OnTriggerEnter2D(Collider2D collision){
        switch (collision.gameObject.name){
            /////////////////// Outside Doors /////////////////////
            case "MansionDoor":
                currentRoom = "AudreyHouse";
                previousRoom = "Audrey";
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("AudreyHouse", LoadSceneMode.Single);
                break;

            case "GreenhouseDoor":
                currentRoom = "GreenHouse";
                previousRoom = "Audrey";
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("GardenHouse", LoadSceneMode.Single);
                break;

            case "BoatyardDoor":
                currentRoom = "BoatHouse";
                previousRoom = "Audrey";
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("BoatHouse", LoadSceneMode.Single);
                break;

                /////////////// Inside Doors /////////////////
            case "MainDoor":
                currentRoom = "Audrey";
                previousRoom = "AudreyHouse";
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("Audrey", LoadSceneMode.Single);
                break;

            case "GardenDoor":
                currentRoom = "Audrey";
                previousRoom = "GardenHouse";
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("Audrey", LoadSceneMode.Single);
                break;

            case "BoatDoor":
                currentRoom = "Audrey";
                previousRoom = "BoatHouse";
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("Audrey", LoadSceneMode.Single);
                break;

        }
    }
}