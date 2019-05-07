using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{

    public playerController player;

    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag ("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player hit E");
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
}
