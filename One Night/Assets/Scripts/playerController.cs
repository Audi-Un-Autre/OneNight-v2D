using System.Collections;
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
    public GameObject boatHouseLoc;
    public GameObject gardenHouseLoc;
    public GameObject MansionLoc;
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
            currentRoom = "Audrey";
            previousRoom = "Audrey";

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

            case "MainDoor": 
                switch (currentRoom){
                    case "AudreyHouse":
                        DontDestroyOnLoad(this.gameObject);
                        SceneManager.LoadScene("Audrey", LoadSceneMode.Single);
                        previousRoom = currentRoom;
                        currentRoom = "Audrey";
                        outsideLoc = MansionLoc.transform.position;
                        playerLoc.x = outsideLoc.x;
                        playerLoc.y = outsideLoc.y - 10;
                        break;

                    case "GardenHouse":
                        DontDestroyOnLoad(this.gameObject);
                        SceneManager.LoadScene("Audrey", LoadSceneMode.Single);
                        previousRoom = currentRoom;
                        currentRoom = "Audrey";
                        outsideLoc = gardenHouseLoc.transform.position;
                        playerLoc.x = outsideLoc.x;
                        playerLoc.y = outsideLoc.y - 10;
                        break;

                    case "BoatyardDoor":                     
                        DontDestroyOnLoad(this.gameObject);
                        SceneManager.LoadScene("Audrey", LoadSceneMode.Single);
                        previousRoom = currentRoom;
                        currentRoom = "Audrey";
                        outsideLoc = boatHouseLoc.transform.position;
                        playerLoc.x = outsideLoc.x;
                        playerLoc.y = outsideLoc.y - 10;
                        break;
                }

                SceneManager.LoadScene("Audrey", LoadSceneMode.Single);
                break;
        }
    }
}
