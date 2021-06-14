using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using System;

public class Launcher : MonoBehaviour
{ 

    void Awake()
    {
        //AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onReady += OnReady;
        AirConsole.instance.onConnect += OnConnect;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Popola il database di carte 
        CardDatabase.Populate();
    }

    void OnReady(string code)
    {
        //Since people might be coming to the game from the AirConsole store once the game is live, 
        //I have to check for already connected devices here and cannot rely only on the OnConnect event 
        //DA FARE, QUI è fatto ad minchiam.
        List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
        foreach (int deviceID in connectedDevices)
        {
            AddNewPlayer(deviceID);
        }
    }

    void OnConnect(int device)
    {
        AddNewPlayer(device);
    }

    private void AddNewPlayer(int deviceID)
    {

        if (MasterController.getPlayerFromId(deviceID) != null) return; //esiste già in registro, ignora.

        if (MasterController.player1 == null)
        {
            MasterController.player1 = new Player(deviceID);
            Debug.Log("Added Player1 with ID: " + deviceID);
            return;
        }
        else if (MasterController.player2 == null)
        {
            MasterController.player2 = new Player(deviceID);
            Debug.Log("Added Player2 with ID: " + deviceID);
            return;
        }
        return;
    }

    private void Update()
    {
        if(MasterController.player1!=null && MasterController.player2 != null)
        {
            Debug.Log("Ready to Go!");
            SceneManager.LoadScene("SceltaTeam");
        }
    }
}
