using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamPickerManager : MonoBehaviour
{
    public Button button_plants;
    public Button button_humans;
    public PlayerDeck player;
    public KeyCode plants;
    public KeyCode humans;
    public KeyCode ready; 

   

    public Team team;
    public void Start()
    {
        team.isReady = false;
    }

    public void ChosenPlants()
    {
       
            team.team_name = "Plants";
            button_plants.image.color = Color.green;
            button_humans.image.color = Color.white;
            player.setTeam(team);
            Debug.Log("" + team.team_name + "scelto");

    }
    public void ChosenHumans()
    {
        
            team.team_name = "Humans";
            button_humans.image.color = Color.red;
            button_plants.image.color = Color.white;
            player.setTeam(team);
            Debug.Log("" + team.team_name + "scelto"); 

    }
    private void Update()
    {
        if (Input.GetKey(plants))
        {
            ChosenPlants();
        }
        if (Input.GetKey(humans))
        {
            ChosenHumans();
        }
        if (Input.GetKey(ready))
        {
            team.isReady = true;
        }
    }
}
