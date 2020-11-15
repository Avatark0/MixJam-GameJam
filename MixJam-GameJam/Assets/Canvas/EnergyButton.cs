using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyButton : MonoBehaviour
{
    void Start()
    {
        float poX=Random.Range(-1f,1f);
        float poY=Random.Range(-1.0f,1.0f);
        float poZ=Random.Range(0f,1.9f);
        transform.position+=new Vector3(poX,poY,poZ);
    }
}
