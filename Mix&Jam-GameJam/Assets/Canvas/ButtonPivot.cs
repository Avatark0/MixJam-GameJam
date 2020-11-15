using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPivot : MonoBehaviour
{
    public float rotSpeed;
  
    void Update()
    {
        rotSpeed=SpeedControl.speed;
        Vector3 rotation=new Vector3(0,0,rotSpeed*Time.deltaTime);
        transform.Rotate(rotation,Space.Self);
    }
}
