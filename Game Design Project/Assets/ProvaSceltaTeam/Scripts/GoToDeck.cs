using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToDeck : MonoBehaviour
{
    public GameObject team1;
    public string team1_name;
    public string team2_name;
    public GameObject team2;
  
    
    public Button button; 
    
    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
        team1_name = team1.GetComponent<TeamPickerManager>().chosenTeam;
        team2_name = team2.GetComponent<TeamPickerManager>().chosenTeam;
        Debug.Log(team1_name + " " + team2_name);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(team1_name + "ao" + team2_name);
    }
}
