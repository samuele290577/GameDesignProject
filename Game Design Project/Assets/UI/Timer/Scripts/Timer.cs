using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public float time = 90;

    public Text timerText;
    public GameObject logic;
    
    // Update is called once per frame
    void Update()
    {
        bool reset = logic.GetComponent<Logic_Earth>().change;
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else if(reset==true)
        {
            timeValue = time;
            reset = false;
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
