using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
	public float speed;
	public float walkSpeed;

    public float health;

	private Rigidbody2D rb;
	public Vector2 moveVelocity;
	private Vector2 lastPos;
	private float distanceTraveled;
	public float stamina;
	private float currStamina;
	private bool canRun;
    public bool isHiding;
	public float recoverStam;
    public float recoverHealth;

    public bool testDoor;
    public string previousRoom;
    public string currentRoom;
    public GameObject player;
    public Vector3 playerLoc;
    private Vector3 outsideLoc;
    private bool playerDestroyed;
    private bool firstLoad;
    public Vector3 firstLoadLoc;
    GameObject menu;

    float startingHealth;
    public Image healthbar;
    

    // Start is called before the first frame update
    void Start()
    {
            health = 100f;
			rb = GetComponent<Rigidbody2D>();
			lastPos = transform.position;
			walkSpeed = speed;
			canRun = true;
            isHiding = false;
			currStamina = stamina;
            playerLoc = transform.position;
            menu = GameObject.Find("Pause");
            startingHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "About" || SceneManager.GetActiveScene().name == "DeathMenu" || SceneManager.GetActiveScene().name == "Ending1" || SceneManager.GetActiveScene().name == "Ending2"){
            Destroy(gameObject);
        }

        healthbar.fillAmount = health / startingHealth;
        if (health <= 60 && health > 30){
            healthbar.color = Color.Lerp(healthbar.color, new Color(255, 154, 0), Mathf.PingPong(Time.time, 1));
        }

        if (health <= 30)
            healthbar.color = Color.Lerp(healthbar.color, Color.red, Mathf.PingPong(Time.time, 1));

        if (health <= 0f){
            //Destroy(GameObject.Find("GlobalObjects"));
            //PlayerSpawn.firstRun = true;
            SceneManager.LoadScene("DeathMenu");
        }
        if(isHiding && health < 100f)
        {
            health += recoverHealth * Time.fixedDeltaTime;
        }

            // pause menu
            if (Input.GetKey(KeyCode.Escape)){
                    Time.timeScale = 0f;
            }

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

            if(!isHiding)
            {
                if(Input.GetKey(KeyCode.LeftShift) && canRun)
                {
                    walkSpeed = speed * 2f;
                    currStamina -= Vector2.Distance(transform.position, lastPos);
                }
                else
                {
                    walkSpeed = speed;
                }
            }

			lastPos = transform.position;
			rb.MovePosition (rb.position + moveVelocity * Time.fixedDeltaTime);
            rb.freezeRotation = true;
        }

	void FixedUpdate()
	{

	}

    public void OnTriggerStay2D(Collider2D collision){
        switch (collision.gameObject.name){
            /////////////////// Outside Doors /////////////////////
            case "HouseDoor":
                currentRoom = "AudreyHouse";
                previousRoom = "Audrey";
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("AudreyHouse", LoadSceneMode.Single);
                break;

            case "GardenDoor":
                currentRoom = "GreenHouse";
                previousRoom = "Audrey";
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("GardenHouse", LoadSceneMode.Single);
                break;

            case "BoatDoor":
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

            case "GardenDoorIn":
                currentRoom = "Audrey";
                previousRoom = "GardenHouse";
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("Audrey", LoadSceneMode.Single);
                break;

            case "BoatDoorIn":
                currentRoom = "Audrey";
                previousRoom = "BoatHouse";
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("Audrey", LoadSceneMode.Single);
                break;

        }
    }
}
