using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class Logic_ProvaTurniDiGioco: MonoBehaviour {

	public GameObject Player;

	private Player_ProvaTurniDiGioco PlayerA = null;
	private Player_ProvaTurniDiGioco PlayerB = null;

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

		AirConsole.instance.Message(device, getPlayer(device).getCards());
	}

	private void AddNewPlayer(int deviceID)
	{

		if (getPlayer(deviceID) != null) return; //esiste già in registro, ignora.

		//Instantiate player prefab
		if (PlayerA == null)
		{
			Debug.Log("Set PlayerA");
			PlayerA = Instantiate(Player).GetComponent<Player_ProvaTurniDiGioco>();
			PlayerA.setID(deviceID);
			return;
		}
		if (PlayerB == null)
		{
			Debug.Log("SetPlayerB");
			PlayerB = Instantiate(Player).GetComponent<Player_ProvaTurniDiGioco>();
			PlayerB.setID(deviceID);
			return;
		}
		return;
	}

	private Player_ProvaTurniDiGioco getPlayer(int deviceID)
    {
		if (PlayerA && PlayerA.getID() == deviceID) return PlayerA;
		if (PlayerB && PlayerB.getID() == deviceID) return PlayerB;
		Debug.Log("No Player with this ID found");
		return null; //boh bisogna ritornare qualcosa
    }

	void OnMessage(int fromDeviceID, JToken data)
	{
		//Log to on-screen Console
		Debug.Log("Incoming message from device: " + fromDeviceID + ": " + data + " \n \n");

		// Send Alive message
		if (data["action"] != null && data["action"].ToString() == "alive")
		{
			getPlayer(fromDeviceID).Noitify();
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

