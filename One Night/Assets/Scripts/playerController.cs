using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	public float speed;
	public float walkSpeed;

	private Rigidbody2D rb;
	private Vector2 moveVelocity;
	private Vector2 lastPos;
	private float distanceTraveled;
	public float stamina;
	private float currStamina;
	private bool canRun;
	public float recoverStam;


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
}
