using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamPickerManager : MonoBehaviour
{
    public Button button_plants;
    public Button button_humans;

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
        team.isReady = true;
    }
    public void ChosenHumans()
    {
        team.team_name = "Humans";
        button_humans.image.color = Color.red;
        button_plants.image.color = Color.white;
        team.isReady = true;
    }
}
