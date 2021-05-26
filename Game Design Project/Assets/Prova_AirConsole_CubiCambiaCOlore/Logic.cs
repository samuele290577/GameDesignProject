using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class Logic: MonoBehaviour {

	public GameObject Cube;

	public Dictionary<int, GameObject> players = new Dictionary<int, GameObject>();

	private int i = 0; //Serve per lo spawn dei cubi, per distanziarli

#if !DISABLE_AIRCONSOLE
	void Awake()
	{
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onReady += OnReady;
		AirConsole.instance.onConnect += OnConnect;
	}

	void OnReady(string code)
	{
		//Since people might be coming to the game from the AirConsole store once the game is live, 
		//I have to check for already connected devices here and cannot rely only on the OnConnect event 
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

		if (players.ContainsKey(deviceID)) return;

		//Instantiate player prefab, store device id + cube in a dictionary
		GameObject newPlayer = Instantiate(Cube, new Vector3(i*2,0,0),  transform.rotation) as GameObject;
		players.Add(deviceID, newPlayer);
		i++;
	}

	void OnMessage(int fromDeviceID, JToken data)
	{
		//Log to on-screen Console
		Debug.Log("Incoming message from device: " + fromDeviceID + ": " + data + " \n \n");

		// Change Cube color
		if (data["action"] != null && data["action"].ToString() == "color")
		{
			players[fromDeviceID].GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
		}
	}

	void OnDestroy()
	{
		if (AirConsole.instance != null)
		{
			AirConsole.instance.onMessage -= OnMessage;
			AirConsole.instance.onReady -= OnReady;
			AirConsole.instance.onConnect -= OnConnect;
		}
	}
#endif
}

