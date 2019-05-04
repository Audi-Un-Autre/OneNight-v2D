using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryPageCollision : MonoBehaviour
{
    public GameObject canvas;
    private bool isRead;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        isRead = false;
    }

    void Update()
    {
        if(isRead && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<playerController>().speed = 3;
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player"))
		{
            player = other.gameObject;
            GetComponent<BoxCollider2D>().enabled = false;
            canvas.SetActive(true);
            other.GetComponent<playerController>().speed = 0;
            isRead = true;
        }
	}
}
