using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private static GameObject damagePanel;

    private bool firstHit=true;

    public static void SetDamagePanel(GameObject panel){
        damagePanel=panel;
    }

    void OnCollisionEnter(Collision col){
        //Debug.Log("BoomBarrier colidiu com "+col.gameObject.tag);
        if(col.gameObject.tag=="wallLeft"){
            Destroy(GetComponent<HingeJoint>());
        }
        if(col.gameObject.tag=="player"){
            Destroy(GetComponent<HingeJoint>());
            damagePanel.SetActive(true);
            if(firstHit){
                firstHit=false;
                col.gameObject.GetComponent<Player>().PointLoss();
            }
        }
    }

    void OnTriggerEnter(Collider col){
        //Debug.Log("BoomBarrier trigou em "+col.gameObject.tag);
    }
}
