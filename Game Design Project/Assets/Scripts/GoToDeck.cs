using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

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
        AirConsole.instance.Broadcast(new
        {
            action = "teamPickerUI",
            content = new
            {
                ready = 0,
                humans = 0,
                plants = 0,
            }
        });
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
            AirConsole.instance.Broadcast(new { action = "gameStats", content = MasterController.getGameStats() });
            AirConsole.instance.Broadcast(new { action = "showBuildDeck" });
            SceneManager.LoadScene("SceltaCarte");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Skip for Development");
            MasterController.player1.team = "Humans";
            MasterController.player1.deck = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            MasterController.player2.team = "Plants";
            MasterController.player2.deck = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            AirConsole.instance.Broadcast(new { action = "gameStats", content = MasterController.getGameStats() });
            SceneManager.LoadScene("Earth");
        }
    }


    //SKIP TO EARTH with automatic team and card selection
    void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    void OnMessage(int fromDeviceID, JToken data)
    {
        if (data["action"] != null && data["action"].ToString() == "skip_build")
        {
            MasterController.player1.team = "Humans";
            MasterController.player1.deck = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            MasterController.player2.team = "Plants";
            MasterController.player2.deck = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            AirConsole.instance.Broadcast(new { action = "gameStats", content = MasterController.getGameStats() });
            SceneManager.LoadScene("Earth");
        }
    }
}