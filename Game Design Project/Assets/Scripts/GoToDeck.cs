using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToDeck : MonoBehaviour
{
    public bool diversi;

    public bool player1Ready = false;
    public bool player2Ready = false;
    public Text ready_player_1;
    public Text ready_player_2;


    public void Start()
    {
        ready_player_1.text = "";
        ready_player_2.text = "";
    }
    public void teamReady(int teamNumber, string type)
    {
        if (teamNumber == 1)
        {
            player1Ready = true;
        }
        else if (teamNumber == 2)
        {
            player2Ready = true;
        }

        else Debug.LogError("Wrong team number in team Ready Script!");
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Ready == true)
        {
            ready_player_1.text = "Ready";
        }
        else
        {
            ready_player_1.text = "Not Ready";
        }
        if (player2Ready == true)
        {
            ready_player_2.text = "Ready";
        }
        else
        {
            ready_player_2.text = "Not Ready";
        }
        diversi = !(MasterController.player1.getTeam().Equals(MasterController.player2.getTeam()));

        if (player1Ready && player2Ready && diversi)
        {
            SceneManager.LoadScene("carte_codice");
        }
    }
}