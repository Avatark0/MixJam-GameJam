using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    public float speed=0;

    private Rigidbody rb;

    public float jumpStrenght=3.4f;
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
            Debug.Log("Jump!");
        }
        if(Input.GetKeyDown(KeyCode.E)){
            jumpStrenght-=0.2f;
            anim.SetBool("isSliding",true);
            Debug.Log("Slide!");
        }
        if(Input.GetKeyDown(KeyCode.D)){
            speed+=0.2f;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            speed-=0.2f;
        }
        if(Input.GetKeyDown(KeyCode.W)){
            jumpStrenght+=0.2f;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            jumpStrenght-=0.2f;
        }
        anim.SetFloat("speed",speed);
    }

    void FixedUpdate(){
        if(timer>Time.time-jumpLenght){
            Debug.Log("Subindo");
        }
    }
    //verticalInput * movementSpeed * Time.deltaTime

    void OnCollisionEnter(Collision col){
        Debug.Log("Player colidiu com "+col.gameObject.tag);
        if(col.gameObject.tag=="treadmill" && timer < Time.time-jumpLenght){
            anim.SetBool("isJumping",false);
        }
    }
}
