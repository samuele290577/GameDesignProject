/*
 * 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AssignPlayer : MonoBehaviour
{
    public ControllerManager manager;
    public PlayerDeck playerPlants; 
    public PlayerDeck playerHumans;
    public Text idPlayerPlants; 
    public Text idPlayerHumans; 
    

    void Start()
    { 
        playerHumans.deck = manager.GetHumanDeck().getCards();
        playerHumans.id = manager.GetHumanDeck().getId();
        playerHumans.team = manager.GetHumanDeck().getTeam();
        playerPlants.deck = manager.GetPlantDeck().getCards();
        playerPlants.id = manager.GetPlantDeck().getId();
        playerPlants.team = manager.GetPlantDeck().getTeam();
        idPlayerPlants.text = "" + playerPlants.getId();
        idPlayerHumans.text = "" + playerHumans.getId();
    }

    private void Update()
    {

        manager.SetPlayerData(playerPlants, "Plants");
        manager.SetPlayerData(playerHumans, "Humans");
    }

    // Update is called once per frame
    public void SceneSwitcher()
    {
        SceneManager.LoadScene("Scena_test");
    }
}
*/