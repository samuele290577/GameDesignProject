using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{

    public static PlayerDeck player1;
    public static PlayerDeck player2;


    public  PlayerDeck GetPlayerData(int playerID)
    {
        switch (playerID)
        {
            case 1:
                return player1;
            case 2:
                return player2;
            default:
                UnityEngine.Debug.LogError("Invalid player ID!!!!");
                return null;
        }
    }

    public void SetPlayerData(PlayerDeck playerData, int playerID)
    {


        switch (playerID)
        {
            case 1:
                player1 = playerData;
                break;
            case 2:
                player2 = playerData;
                break;
            default:
                UnityEngine.Debug.LogError("Invalid player ID!!!!");
                break;
        }
    }

    public PlayerDeck GetPlantDeck()
    {
        if (player1.getTeam().Equals("Plants"))
        {
            return player1;
        }
        else return player2; 
    }
    public PlayerDeck GetHumanDeck()
    {
        if (player1.getTeam().Equals("Humans"))
        {
            return player1;
        }
        else return player2;
    }
}
