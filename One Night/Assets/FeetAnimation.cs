using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetAnimation : MonoBehaviour
{
    public Animator anim;

    public GameObject player;
    public playerController controller;
    public float animSpeed;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.root.gameObject;
        anim = GetComponent<Animator>();
        controller = player.GetComponent<playerController>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        controller = player.GetComponent<playerController>();
        if(controller.moveVelocity == new Vector2(0.0f, 0.0f))
        {
            anim.SetFloat("speed", 0);
        }
        else if(controller.walkSpeed == controller.speed && controller.moveVelocity != new Vector2(0.0f, 0.0f))
        {
            anim.SetFloat("speed", animSpeed);
        }
        else if(controller.walkSpeed > controller.speed && controller.moveVelocity != new Vector2(0.0f, 0.0f))
        {
            anim.SetFloat("speed", (animSpeed * 2));
        }
    }

    void PlayAudioNow()
    {
        audio.Play(0);
    }

}
