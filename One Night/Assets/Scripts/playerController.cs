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


    // Start is called before the first frame update
    void Start()
    {
			rb = GetComponent<Rigidbody2D>();
			lastPos = transform.position;
			walkSpeed = speed;
			canRun = true;
			currStamina = stamina;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.name == "MansionDoor")
        {
            SceneManager.LoadScene("AudreyHouse", LoadSceneMode.Single);
            testDoor = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.name == "GreenhouseDoor")
        {
            SceneManager.LoadScene("GardenHouse", LoadSceneMode.Single);
            testDoor = true;

        }
        else if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.name == "BoatyardDoor")
        {
            SceneManager.LoadScene("BoatHouse", LoadSceneMode.Single);
            testDoor = true;

        }
        else if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.name == "MainDoor")
        {
            SceneManager.LoadScene("Audrey", LoadSceneMode.Single);
            testDoor = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision){
        testDoor = false;
    }
}
