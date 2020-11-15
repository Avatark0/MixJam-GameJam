using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        //Debug.Log("Shredder destruiu "+col.gameObject.tag);
        Destroy(col.gameObject);
    }

    void OnTriggerEnter(Collider col){
        //Debug.Log("Shredder destruiu o trigger "+col.gameObject.tag);
        Destroy(col.gameObject);
    }
}
