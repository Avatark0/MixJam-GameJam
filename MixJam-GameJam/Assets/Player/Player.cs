using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    public float speed=0;

    private Rigidbody rb;

    public float jumpStrenght;
    private float jumpLenght=0.13f;//0.26 seconds total duration
    private float timer;

    public int steps=0;
    public int score=30;
    public int difficulty=1;

    private bool playerStarted=false;

    private SpeedControl speedControl;

    void Awake()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
        speedControl=GameObject.FindWithTag("speedManager").GetComponent<SpeedControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerStarted)return;
        else if(speedControl.speedControl<4){
            speedControl.IncreaseWorldSpeed();
            speed=(speedControl.speedControl/2)*1.3f;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            timer=Time.time;
            anim.SetBool("isJumping",true);
            rb.velocity = new Vector3(0,jumpStrenght,0);
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            if(!anim.GetBool("isCrouching"))
                 anim.SetBool("isCrouching",true);
        }
        else anim.SetBool("isCrouching",false);

        if(speed<1)speed=1;
        if(speed>4)speed=4;

        anim.SetFloat("speed",speed);
        anim.SetFloat("crouchSpeed",0.6f+(0.2f*speed));
        jumpStrenght=3+speed-1;

        speed-=0.08f*Time.deltaTime*difficulty;

        if(score<=0) Defeat();
    }

    void Defeat(){
        //ativar botao defeat e play again
    }

    public void GameStart(){
        if(!anim.GetBool("gameStarted"))speed=1;
        anim.SetBool("gameStarted",true);
        playerStarted=true;
    }

    public void EnergyButton(){
        speed+=3;
        score+=10;
    }

    public void PointLoss(){
        score-=5;
    }

    void OnCollisionEnter(Collision col){
        //Debug.Log("Player colidiu com "+col.gameObject.tag);
        if(col.gameObject.tag=="treadmill"){
            steps++;
            if(timer < Time.time-jumpLenght){
                anim.SetBool("isJumping",false);
            }
        }
    }

    void OnTriggerEnter(Collider col){
       // Debug.Log("Player colidiu com "+col.gameObject.tag);
        if(col.gameObject.tag=="jumpTutorial"){
            speed=3;
            Debug.Log("JT");
        }
        if(col.gameObject.tag=="crouchTutorial"){
            speed=3;
            Debug.Log("CT");
        }
    }
}
