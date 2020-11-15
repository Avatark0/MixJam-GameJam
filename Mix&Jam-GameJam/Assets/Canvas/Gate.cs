using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        Debug.Log("BoomBarrier colidiu com "+col.gameObject.tag);
        if(col.gameObject.tag=="wallLeft"){
            Destroy(GetComponent<HingeJoint>());
        }
    }

    void OnTriggerEnter(Collider col){
        Debug.Log("BoomBarrier trigou em "+col.gameObject.tag);
    }
}
