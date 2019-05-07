using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{

    public playerController player;
    public GameObject other;
    private bool isTriggered;

    void Start()
    {
        isTriggered = false;
        other = null;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isTriggered)
        {
                player = other.GetComponent<playerController>();
                if(!player.isHiding)
                {
                    player.isHiding = true;
                    player.walkSpeed = 0f;
                    other.GetComponent<SpriteRenderer>().enabled = false;
                    for (int i = 0; i < other.transform.childCount; i++)
                    {
                        other.transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
                else if(player.isHiding)
                {
                    player.isHiding = false;
                    player.walkSpeed = player.speed;
                    other.GetComponent<SpriteRenderer>().enabled = true;
                    for (int i = 0; i < other.transform.childCount; i++)
                    {
                        other.transform.GetChild(i).gameObject.SetActive(true);
                    }
                }
        }
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player"))
        {
            isTriggered = true;
            this.other = other.gameObject;            
        }
    }
        void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("Player"))
        {
            isTriggered = false;
            this.other = null;            
        }
    }
}
