using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamPickerManager : MonoBehaviour
{
    public Button button_plants;
    public Button button_humans;
    
    public string chosenTeam;

    public void ChosenPlants()
    {
        chosenTeam = "Plants";
        Debug.Log(chosenTeam);
        button_plants.image.color = Color.green;
        button_humans.image.color = Color.white;
    }
    public void ChosenHumans()
    {
        chosenTeam = "Humans";
        Debug.Log(chosenTeam);
        button_humans.image.color = Color.red;
        button_plants.image.color = Color.white;
    }
}
