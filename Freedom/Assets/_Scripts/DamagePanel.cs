using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePanel : MonoBehaviour
{
    private float timerDisable;
    private float timerBlink;
    private float blinkingTime=0.1f;

    void Awake()
    {
        Gate.SetDamagePanel(gameObject);
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        timerDisable=Time.time;
    }

    void Update()
    {
        if(timerDisable<Time.time-blinkingTime){
            gameObject.SetActive(false);
        }
    }
}
