using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    public float speed=0;
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            Debug.Log(speed);
            anim.SetBool("isJumping",true);
            transform.position += new Vector3(0, 0.1f, 0);
        }
        if(Input.GetKey(KeyCode.D)){
            speed+=0.2f;
        }
        if(Input.GetKey(KeyCode.A)){
            speed-=0.2f;
        }
        anim.SetFloat("speed",speed);
    }
    //verticalInput * movementSpeed * Time.deltaTime

    void OnCollisionEnter(Collision col){
        Debug.Log("Player colidiu com "+col);
        if(col.gameObject.tag=="treadmill"){
            anim.SetBool("isJumping",false);
        }
    }
}
