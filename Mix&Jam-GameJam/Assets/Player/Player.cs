using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    public float speed=1;

    private Rigidbody rb;

    public float jumpStrenght;
    private float jumpLenght=0.13f;//0.26 seconds total duration
    private float timer;

    void Awake()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            timer=Time.time;
            anim.SetBool("isJumping",true);
            rb.velocity = new Vector3(0,jumpStrenght,0);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            if(!anim.GetBool("isCrouching"))
                 anim.SetBool("isCrouching",true);
            else anim.SetBool("isCrouching",false);
        }

        if(Input.GetKey(KeyCode.D)){
            speed+=0.1f*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A)){
            speed-=0.1f*Time.deltaTime;
        }

        if(speed<1)speed=1;
        if(speed>4)speed=4;

        anim.SetFloat("speed",speed);
        anim.SetFloat("crouchSpeed",0.6f+(0.2f*speed));
        jumpStrenght=3+speed-1;
    }

    void OnCollisionEnter(Collision col){
        Debug.Log("Player colidiu com "+col.gameObject.tag);
        if(col.gameObject.tag=="treadmill" && timer < Time.time-jumpLenght){
            anim.SetBool("isJumping",false);
        }
    }

    void OnTriggerEnter(Collider col){
        Debug.Log("Player colidiu com "+col.gameObject.tag);
        if(col.gameObject.tag=="obstacleBot"){
            Debug.Log("hit bot");
        }
        if(col.gameObject.tag=="obstacleTop"){
            Debug.Log("hit top");
        }
    }
}
