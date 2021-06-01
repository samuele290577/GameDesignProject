 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float interval;

    void Update()
    {
        if(interval > 0)
        {
            interval -= Time.deltaTime; 
        }
        else
        {
            enabled = false;
        }
    }
}
