using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public float time = 90;

    public Text timerText;
    public GameObject logic;
    
    // Update is called once per frame
    void Update()
    {
        float reset = logic.GetComponent<Logic_Earth>().change;
        if (reset == time)
        {
            timeValue = time;
            
        }
        else if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        //Debug.Log("bool:" + reset);
        /*if(reset == true)
        {
            timeValue = time;
            reset = false;
        }
        else if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }*/
        DisplayTime(reset);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
