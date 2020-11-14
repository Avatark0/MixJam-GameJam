using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotation : MonoBehaviour
{
    private GameObject botao;
    void Start()
    {
        botao=Resources.Load("button") as GameObject;
        Vector3 rotation=new Vector3(0,0,0.5f);
        for(int i=0;i<720;i++){
            Instantiate(botao,new Vector3(0,2,0),Quaternion.identity, transform);
            transform.Rotate(rotation,Space.Self);            
        }
    }

    void Update()
    {
        Vector3 rotation=new Vector3(0,0,1*Time.deltaTime);
        transform.Rotate(rotation,Space.Self);
    }
}
