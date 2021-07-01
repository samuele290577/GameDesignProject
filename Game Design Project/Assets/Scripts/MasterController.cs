using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MasterController
{

    public static Player player1;
    public static Player player2;


    public static Player getPlayerFromId(int id)
    {
        if (player1 != null && player1.getId() == id) return player1;
        else if (player2 != null && player2.getId() == id) return player2;
        else return null;
    }

    public static Player getPlayerFromTeam(string team)
    {
        if (player1.team == team) return player1;
        else if (player2.team == team) return player2;
        else return null;
    }

    public static int getPlayerNumberFromTeam(string team)
    {
        if (player1.team == team) return 1;
        else if (player2.team == team) return 2;
        else return -1;
    }

    public static object getGameStats()
    {
        var p1 = new
        {
            id = player1.id,
            team = player1.team
        };
        var p2 = new
        {
            id = player2.id,
            team = player2.team
        };
        return new { p1, p2 };
    }

    /*
     * COSE CHE AVEVA SCRITTO BATTEGAZZORRE. Il nostro problema è che non per forza gli ID sono 1 e 2, dipende da AirConsole
    public Player GetPlayerFromId(int playerID)
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

    public void SetPlayerData(Player playerData, string team)
    {
        switch (team)
        {
            case "Plants":
                if (player1.team.Equals("Plants"))
                {
                    player1 = playerData;
                }
                else
                {
                    player2 = playerData;
                }

                break;
            case "Humans":
                if (player1.team.Equals("Humans"))
                {
                    player1 = playerData;
                }
                else { 
                    player2 = playerData;

                }

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

    public string getCards()
    {
        string stringa_pianta = "";
        string stringa_humans = "";
        for(int i = 0; i < player1.getSize(); i++)
        {
            stringa_pianta+= " " + player1.getCards()[i].getCardName();

        }
        for (int j = 0; j < player1.getSize(); j++)
        {
            stringa_humans += " " + player2.getCards()[j].getCardName();

        }
        return stringa_pianta +" " + stringa_humans;
       
        }

    */

    }

