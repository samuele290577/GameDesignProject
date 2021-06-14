﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class TeamPickerManager : MonoBehaviour
{
    public Button button_plants;
    public Button button_humans;
    public KeyCode plants;
    public KeyCode humans;
    public KeyCode ready;
    public int playerNumber;
    public GoToDeck GoToDeck;

    private Player player;

    private void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
    }


    public void Start()
    {
        if (playerNumber == 1) player = MasterController.player1;
        else if (playerNumber == 2) player = MasterController.player2;
        else Debug.LogError("Errore nell'assegnazione del giocatore!");
    }

    public void ChosenPlants()
    {
        player.setTeam("Plants");
        button_plants.image.color = Color.green;
        button_humans.image.color = Color.white;
        Debug.Log("Player" + player.getId() + " ha scelto" + player.getTeam());

    }
    public void ChosenHumans()
    {

        player.setTeam("Humans");
        button_humans.image.color = Color.red;
        button_plants.image.color = Color.white;
        Debug.Log("Player" + player.getId() + " ha scelto" + player.getTeam());

    }

    /*
     * Rimpiazzato da controlli AirConsole
    private void Update()
    {
        if (Input.GetKey(plants))
        {
            ChosenPlants();
            GoToDeck.player1Ready = false;
            GoToDeck.player2Ready = false;
        }
        if (Input.GetKey(humans))
        {
            ChosenHumans();
            GoToDeck.player1Ready = false;
            GoToDeck.player2Ready = false;
        }
        if (Input.GetKey(ready))
        {
            if (player.getTeam() == "unset") return; //se non è stato scelto il team, non si può confermare
            GoToDeck.teamReady(playerNumber, player.getTeam());
            Debug.Log("Player" + playerNumber + " ha scelto " + player.getTeam() + "ed è ready");

        }
    }
    */

    void OnMessage(int fromDeviceID, JToken data)
    {
        Debug.Log("new message from " + fromDeviceID + ": " + data);

        if (data["action"] != null && data["action"].ToString() == "pick_humans" && fromDeviceID==player.id)
        {
            ChosenHumans();
            GoToDeck.player1Ready = false;
            GoToDeck.player2Ready = false;
        }
        else if (data["action"] != null && data["action"].ToString() == "pick_plants" && fromDeviceID == player.id)
        {
            ChosenPlants();
            GoToDeck.player1Ready = false;
            GoToDeck.player2Ready = false;
        }
        else if (data["action"] != null && data["action"].ToString() == "team_ready" && fromDeviceID == player.id)
        {
            if (player.getTeam() == "unset") return; //se non è stato scelto il team, non si può confermare
            GoToDeck.teamReady(playerNumber, player.getTeam());
            Debug.Log("Player" + playerNumber + " ha scelto " + player.getTeam() + " ed è ready");
        }
    }
}