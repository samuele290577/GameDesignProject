using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignPlayer : MonoBehaviour
{
    public ControllerManager manager;
    public PlayerDeck playerPlants; 
    public PlayerDeck playerHumans;
    public Text idPlayerPlants; 
    public Text idPlayerHumans; 
    

    void Start()
    {
        playerHumans.id = manager.GetHumanDeck().getId();
        playerHumans.team = manager.GetHumanDeck().getTeam();
        playerPlants.id = manager.GetPlantDeck().getId();
        playerPlants.team = manager.GetPlantDeck().getTeam();
        idPlayerPlants.text = "" + playerPlants.getId();
        idPlayerHumans.text = "" + playerHumans.getId();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
