using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPivot : MonoBehaviour
{
    public float rotSpeed=1;
    void Update()
    {
        Vector3 rotation=new Vector3(0,0,rotSpeed*Time.deltaTime);
        transform.Rotate(rotation,Space.Self);
    }
}
