using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    public static float speed;
    public float speedControl=0;

    // Update is called once per frame
    void Update()
    {
        speed=speedControl;
    }

    public void StartWorldSpeed(){
        speedControl=1;
    }

    public void IncreaseWorldSpeed(){
        speedControl+=1*Time.deltaTime;
    }

    public void StopWorldSpeed(){
        if(speedControl>0)speedControl-=1*Time.deltaTime;
        else speedControl=0;
    }
}
