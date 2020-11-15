using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    public static float speed=4f;
    public float speedControl=4f;
    // Update is called once per frame
    void Update()
    {
        speed=speedControl;
    }
}
