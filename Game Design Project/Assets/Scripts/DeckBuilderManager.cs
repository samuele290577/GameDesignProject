using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using UnityEngine.UI;

public class DeckBuilderManager : MonoBehaviour
{
    private bool playerPlantsReady = false;
    private bool playerHumansReady = false;

    public void PlayerReady(string team)
    {
        switch (team)
        {
            case "Plants":
                playerPlantsReady = true;
                AirConsole.instance.Message(MasterController.getPlayerFromTeam(team).id, new
                {
                    action = "deckBuilderUI",
                    content = new
                    {
                        goToWar = 2,
                        up = -1,
                        down = -1,
                        add = -1,
                        remove = -1
                    }
                });
                break;
            case "Humans":
                playerHumansReady = true;
                AirConsole.instance.Message(MasterController.getPlayerFromTeam(team).id, new
                {
                    action = "deckBuilderUI",
                    content = new
                    {
                        goToWar = 2,
                        up = -1,
                        down = -1,
                        add = -1,
                        remove = -1
                    }
                });
                break;
        }
    }

    private void Update()
    {
        if (playerPlantsReady && playerHumansReady)
        {
            SceneManager.LoadScene("Earth");
        }
    }
}
